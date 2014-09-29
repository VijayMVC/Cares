using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Cares.Interfaces.Repository;
using Cares.Models.Common;
using Cares.Models.DomainModels;
using Cares.Models.RequestModels;
using Cares.Models.ResponseModels;
using Cares.Repository.BaseRepository;
using Microsoft.Practices.Unity;

namespace Cares.Repository.Repositories
{
    /// <summary>
    /// Seasonal Discount Main Repository
    /// </summary>
    public class SeasonalDiscountMainRepository : BaseRepository<SeasonalDiscountMain>, ISeasonalDiscountMainRepository
    {
        #region Private
        private readonly Dictionary<SeasonalDiscountByColumn, Func<SeasonalDiscountMainContent, object>> seasonalDiscountClause =
             new Dictionary<SeasonalDiscountByColumn, Func<SeasonalDiscountMainContent, object>>
                    {
                        { SeasonalDiscountByColumn.Code, c => c.Code },
                        { SeasonalDiscountByColumn.Name, c => c.Name }
                    };

        #endregion

        #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        public SeasonalDiscountMainRepository(IUnityContainer container)
            : base(container)
        {

        }
        /// <summary>
        /// Primary database set
        /// </summary>
        protected override IDbSet<SeasonalDiscountMain> DbSet
        {
            get
            {
                return db.SeasonalDiscountMains;
            }
        }
        #endregion

        #region Public

        /// <summary>
        /// Get All Seasonal Discount Main for User Domain Key
        /// </summary>
        public override IEnumerable<SeasonalDiscountMain> GetAll()
        {
            return DbSet.Where(seasonalDiscount => seasonalDiscount.UserDomainKey == UserDomainKey).ToList();
        }

        /// <summary>
        /// Get All Seasonal Discount Main based on search crateria
        /// </summary>
        public SeasonalDiscountSearchResponse GetSeasonalDiscounts(SeasonalDiscountSearchRequest request)
        {
            int fromRow = (request.PageNo - 1) * request.PageSize;
            int toRow = request.PageSize;

            var getSeasonalDiscountMainQuery = from seasonalDiscountMain in DbSet
                                               join tariffType in db.TariffTypes on seasonalDiscountMain.TariffTypeCode equals tariffType.TariffTypeCode
                                             where
                                                 ((string.IsNullOrEmpty(request.SearchString) || seasonalDiscountMain.SeasonalDiscountMainCode.Contains(request.SearchString) || seasonalDiscountMain.SeasonalDiscountMainName.Contains(request.SearchString)) &&
                                                 (!request.OperationId.HasValue ||
                                                   tariffType.OperationId == request.OperationId.Value) &&
                                                  (!request.TariffTypeId.HasValue ||
                                                   tariffType.TariffTypeId == request.TariffTypeId)) && !(tariffType.ChildTariffTypeId.HasValue)
                                               select new SeasonalDiscountMainContent
                                             {
                                                 SeasonalDiscountMainId = seasonalDiscountMain.SeasonalDiscountMainId,
                                                 Code = seasonalDiscountMain.SeasonalDiscountMainCode,
                                                 Name = seasonalDiscountMain.SeasonalDiscountMainName,
                                                 Description = seasonalDiscountMain.SeasonalDiscountMainDescription,
                                                 StartDt = seasonalDiscountMain.StartDt,
                                                 EndDt = seasonalDiscountMain.EndDt,
                                                 TariffTypeId = tariffType.TariffTypeId,
                                                 CompanyId = tariffType.Operation.Department.Company.CompanyId,
                                                 CompanyCodeName = tariffType.Operation.Department.Company.CompanyCode + " - " + tariffType.Operation.Department.Company.CompanyName,
                                                 DepartmentId = tariffType.Operation.Department.DepartmentId,
                                                 TariffTypeCodeName = tariffType.TariffTypeCode + " - " + tariffType.TariffTypeName,
                                                 OperationId = tariffType.OperationId,
                                                 OperationCodeName = tariffType.Operation.OperationCode + " - " + tariffType.Operation.OperationName,
                                             };

            IEnumerable<SeasonalDiscountMainContent> seasonalDiscountMains = request.IsAsc
                ? getSeasonalDiscountMainQuery.OrderBy(seasonalDiscountClause[request.SeasonalDiscountOrderBy])
                    .Skip(fromRow)
                    .Take(toRow)
                : getSeasonalDiscountMainQuery.OrderByDescending(seasonalDiscountClause[request.SeasonalDiscountOrderBy])
                    .Skip(fromRow)
                    .Take(toRow);

            return new SeasonalDiscountSearchResponse { SeasonalDiscountMains = seasonalDiscountMains, TotalCount = getSeasonalDiscountMainQuery.Count() };
        }

        /// <summary>
        /// Validate Seasonal Discount Main Already exist Against Tariff type Code 
        /// </summary>
        /// <param name="tariffTypeCode"></param>
        /// <returns></returns>
        public bool LoadChaufferChargeMainExist(string tariffTypeCode)
        {
            return DbSet.Where(chaufferChrg => chaufferChrg.TariffTypeCode == tariffTypeCode).ToList().Count > 0;
        }
        #endregion
    }
}

