using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Cares.Interfaces.Repository;
using Cares.Models.Common;
using Cares.Models.DomainModels;
using Cares.Models.RequestModels;
using Cares.Models.ResponseModels;
using Microsoft.Practices.Unity;
using Cares.Repository.BaseRepository;

namespace Cares.Repository.Repositories
{
    /// <summary>
    /// Service Rate Main Repository
    /// </summary>
    public class ServiceRtMainRepository : BaseRepository<ServiceRtMain>, IServiceRtMainRepository
    {
         #region Private
        private readonly Dictionary<ServiceRateByColumn, Func<ServiceRtMainContent, object>> serviceRateClause =
             new Dictionary<ServiceRateByColumn, Func<ServiceRtMainContent, object>>
                    {
                        { ServiceRateByColumn.ServiceRtCode, c => c.ServiceRtMainCode },
                        { ServiceRateByColumn.ServiceRtName, c => c.ServiceRtMainName },
                        { ServiceRateByColumn.StartDate, c => c.StartDt },
                       
                    };

        #endregion
         
        #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        public ServiceRtMainRepository(IUnityContainer container)
            : base(container)
        {

        }
        /// <summary>
        /// Primary database set
        /// </summary>
        protected override IDbSet<ServiceRtMain> DbSet
        {
            get
            {
                return db.ServiceRtMains;
            }
        }
        #endregion

        #region Public
        /// <summary>
        /// Get All Service Rate Main for User Domain Key
        /// </summary>
        public override IEnumerable<ServiceRtMain> GetAll()
        {
            return DbSet.Where(serviceRtMain => serviceRtMain.UserDomainKey == UserDomainKey).ToList();
        }

        /// <summary>
        /// Get All Service Rates based on search crateria
        /// </summary>
        public ServiceRateSearchResponse GetServiceRates(ServiceRateSearchRequest serviceRateSearchRequest)
        {
            int fromRow = (serviceRateSearchRequest.PageNo - 1) * serviceRateSearchRequest.PageSize;
            int toRow = serviceRateSearchRequest.PageSize;

            var getInsuranceRateQuery = from serviceRtMain in DbSet
                                        join tariffType in db.TariffTypes on serviceRtMain.TariffTypeCode equals tariffType.TariffTypeCode
                                        where
                                            ((!serviceRateSearchRequest.OperationId.HasValue ||
                                              tariffType.OperationId == serviceRateSearchRequest.OperationId.Value) &&
                                             (!serviceRateSearchRequest.TariffTypeId.HasValue ||
                                              tariffType.TariffTypeId == serviceRateSearchRequest.TariffTypeId))
                                        select new ServiceRtMainContent
                                        {
                                            ServiceRtMainId = serviceRtMain.ServiceRtMainId,
                                            ServiceRtMainCode = serviceRtMain.ServiceRtMainCode,
                                            ServiceRtMainName = serviceRtMain.ServiceRtMainName,
                                            ServiceRtMainDescription = serviceRtMain.ServiceRtMainDescription,
                                            StartDt = serviceRtMain.StartDt,
                                            TariffTypeId = tariffType.TariffTypeId,
                                            TariffTypeCodeName = tariffType.TariffTypeCode + " - " + tariffType.TariffTypeName,
                                            OperationId = tariffType.OperationId,
                                            OperationCodeName = tariffType.Operation.OperationCode + " - " + tariffType.Operation.OperationName,
                                        };

            IEnumerable<ServiceRtMainContent> insuranceRtMains = serviceRateSearchRequest.IsAsc
                ? getInsuranceRateQuery.OrderBy(serviceRateClause[serviceRateSearchRequest.ServiceRateByOrder])
                    .Skip(fromRow)
                    .Take(toRow)
                : getInsuranceRateQuery.OrderByDescending(serviceRateClause[serviceRateSearchRequest.ServiceRateByOrder])
                    .Skip(fromRow)
                    .Take(toRow);

            return new ServiceRateSearchResponse { ServiceRtMains = insuranceRtMains, TotalCount = getInsuranceRateQuery.Count() };
        }
        /// <summary>
        /// Get  Service Rate Main By Tariff Type Code
        /// </summary>
        public IEnumerable<ServiceRtMain> FindByTariffTypeCode(string tariffTypeCode)
        {
            return DbSet.Where(insuranceRtMain => insuranceRtMain.UserDomainKey == UserDomainKey && insuranceRtMain.TariffTypeCode == tariffTypeCode).ToList();
        }

        #endregion
    }
}
