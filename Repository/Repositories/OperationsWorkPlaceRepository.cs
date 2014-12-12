using Cares.Interfaces.Repository;
using Cares.Models.CommonTypes;
using Cares.Models.DomainModels;
using Cares.Repository.BaseRepository;
using Microsoft.Practices.Unity;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Cares.Repository.Repositories
{
    /// <summary>
    /// OperationsWorkPlace Repository
    /// </summary>
    public sealed class OperationsWorkPlaceRepository : BaseRepository<OperationsWorkPlace>, IOperationsWorkPlaceRepository
    {
        #region Constructor
        
        /// <summary>
        /// Constructor
        /// </summary>
        public OperationsWorkPlaceRepository(IUnityContainer container)
            : base(container)
        {

        }

        /// <summary>
        /// Primary database set
        /// </summary>
        protected override IDbSet<OperationsWorkPlace> DbSet
        {
            get
            {
                return db.OperationsWorkPlaces;
            }
        }

        #endregion
        
        #region Public


        /// <summary>
        /// Association check b/n Operation Work Place and Fleet Pool
        /// </summary>
        public bool IsOperationWorkPlaceAssociatedWithFleetPool(double fleetPollId)
        {
            return DbSet.Count(operationworkplace => operationworkplace.FleetPoolId == fleetPollId && operationworkplace.UserDomainKey == UserDomainKey) > 0;
        }

        /// <summary>
        /// Get All OperationsWorkplaces for Sales
        /// </summary>
        public IEnumerable<OperationsWorkPlace> GetSalesOperationsWorkPlace()
        {
            return DbSet.Where(op => op.Operation.Department.DepartmentType == DepartmentTypes.Sales && op.UserDomainKey==UserDomainKey).ToList();
        }

        /// <summary>
        /// Get WorkPlace Operation By WorkPlace Id
        /// </summary>
        public IEnumerable<OperationsWorkPlace> GetWorkPlaceOperationByWorkPlaceId(long workplaceId)
        {
            List<OperationsWorkPlace> operationsWorkPlaces = DbSet.Where(operation => operation.WorkPlaceId == workplaceId && operation.UserDomainKey == UserDomainKey).ToList();
            return operationsWorkPlaces.Select(operation => GetOperationWorkPlaceWithDetails(operation.OperationsWorkPlaceId)).ToList();
        }


        /// <summary>
        /// Get Operation Work Place With Details
        /// </summary>
        public OperationsWorkPlace GetOperationWorkPlaceWithDetails(long id)
        {
            return DbSet.Include(opp => opp.Operation)
                   .Include(opp => opp.FleetPool)
                   .FirstOrDefault(opp => opp.OperationsWorkPlaceId == id && opp.UserDomainKey == UserDomainKey);
        }


        /// <summary>
        /// Get Operation Workplace by domainkey
        /// </summary>
        public IEnumerable<OperationsWorkPlace> GetSalesBranchesByDomainKey(long domainKey)
        {
            return DbSet.Where(owp => owp.UserDomainKey == domainKey && owp.Operation.Department.DepartmentType == DepartmentTypes.Sales).OrderBy(owp => owp.LocationName);
        }

        /// <summary>
        /// Get operation id by operatoin workplace id
        /// </summary>
        public long GetOperationIdByOperationWorkPlaceId(long operationWorkPlaceId)
        {
            return
                DbSet.Where(operationWorkPlace => operationWorkPlace.OperationsWorkPlaceId == operationWorkPlaceId && operationWorkPlace.UserDomainKey == UserDomainKey)
                    .Select(operation => operation.OperationId).FirstOrDefault();
        }
        
        /// <summary>
        /// Get Employee Status for User Domain Key
        /// </summary>
        public override IEnumerable<OperationsWorkPlace> GetAll()
        {
            return DbSet.Where(oWorkPlace => oWorkPlace.UserDomainKey == UserDomainKey && oWorkPlace.UserDomainKey == UserDomainKey).ToList();
        }
        #endregion
    }
}
