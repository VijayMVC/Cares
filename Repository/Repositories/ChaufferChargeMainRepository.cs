using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
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
    /// Chauffer Charge Main Repository
    /// </summary>
    public class ChaufferChargeMainRepository : BaseRepository<ChaufferChargeMain>, IChaufferChargeMainRepository
    {
        #region Private
        private readonly Dictionary<ChaufferChargeByColumn, Func<ChaufferChargeMainContent, object>> chaufferChargeClause =
             new Dictionary<ChaufferChargeByColumn, Func<ChaufferChargeMainContent, object>>
                    {
                        { ChaufferChargeByColumn.Code, c => c.Code },
                        { ChaufferChargeByColumn.Name, c => c.Name }
                    };

        #endregion

        #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        public ChaufferChargeMainRepository(IUnityContainer container)
            : base(container)
        {

        }
        /// <summary>
        /// Primary database set
        /// </summary>
        protected override IDbSet<ChaufferChargeMain> DbSet
        {
            get
            {
                return db.ChaufferChargeMains;
            }
        }
        #endregion

        #region Public

        /// <summary>
        /// Get All Chauffer Charge Main for User Domain Key
        /// </summary>
        public override IEnumerable<ChaufferChargeMain> GetAll()
        {
            return DbSet.Where(chaufferCharge => chaufferCharge.UserDomainKey == UserDomainKey).ToList();
        }

        /// <summary>
        /// Get All Chauffer Charge Main based on search crateria
        /// </summary>
        public ChaufferChargeSearchResponse GetChaufferCharges(ChaufferChargeSearchRequest request)
        {
            int fromRow = (request.PageNo - 1) * request.PageSize;
            int toRow = request.PageSize;

            var getChaufferChargeMainQuery = from chaufferChargeMain in DbSet
                                     join tariffType in db.TariffTypes on chaufferChargeMain.TariffTypeCode equals tariffType.TariffTypeCode
                                     where
                                         ((string.IsNullOrEmpty(request.SearchString) || chaufferChargeMain.ChaufferChargeMainCode.Contains(request.SearchString) || chaufferChargeMain.ChaufferChargeMainName.Contains(request.SearchString)) &&
                                         (!request.OperationId.HasValue ||
                                           tariffType.OperationId == request.OperationId.Value) &&
                                          (!request.TariffTypeId.HasValue ||
                                           tariffType.TariffTypeId == request.TariffTypeId))
                                     select new ChaufferChargeMainContent
                                     {
                                         ChaufferChargeMainId = chaufferChargeMain.ChaufferChargeMainId,
                                         Code = chaufferChargeMain.ChaufferChargeMainCode,
                                         Name = chaufferChargeMain.ChaufferChargeMainName,
                                         Description = chaufferChargeMain.ChaufferChargeMainDescription,
                                         StartDate = chaufferChargeMain.StartDt,
                                         TariffTypeId = tariffType.TariffTypeId,
                                         CompanyId = tariffType.Operation.Department.Company.CompanyId,
                                         CompanyCodeName = tariffType.Operation.Department.Company.CompanyCode+" - "+tariffType.Operation.Department.Company.CompanyName,
                                         DepartmentId = tariffType.Operation.Department.DepartmentId,
                                         TariffTypeCodeName = tariffType.TariffTypeCode + " - " + tariffType.TariffTypeName,
                                         OperationId = tariffType.OperationId,
                                         OperationCodeName = tariffType.Operation.OperationCode + " - " + tariffType.Operation.OperationName,
                                     };

            IEnumerable<ChaufferChargeMainContent> chaufferChargeMains = request.IsAsc
                ? getChaufferChargeMainQuery.OrderBy(chaufferChargeClause[request.ChaufferChargeOrderBy])
                    .Skip(fromRow)
                    .Take(toRow)
                : getChaufferChargeMainQuery.OrderByDescending(chaufferChargeClause[request.ChaufferChargeOrderBy])
                    .Skip(fromRow)
                    .Take(toRow);

            return new ChaufferChargeSearchResponse { ChaufferChargeMains = chaufferChargeMains, TotalCount = getChaufferChargeMainQuery.Count() };
        }

        #endregion
    }
}
