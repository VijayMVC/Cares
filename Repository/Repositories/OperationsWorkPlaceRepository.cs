using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Cares.Interfaces.Repository;
using Cares.Models.CommonTypes;
using Cares.Models.DomainModels;
using Cares.Repository.BaseRepository;
using Microsoft.Practices.Unity;

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
        /// Get All OperationsWorkplaces for Sales
        /// </summary>
        public IEnumerable<OperationsWorkPlace> GetSalesOperationsWorkPlace()
        {
            return DbSet.Where(op => op.Operation.Department.DepartmentType == DepartmentTypes.Sales).ToList();
        }

        #endregion

    }
}
