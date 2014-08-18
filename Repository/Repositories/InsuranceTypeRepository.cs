using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Cares.Interfaces.Repository;
using Cares.Models.DomainModels;
using Cares.Repository.BaseRepository;
using Microsoft.Practices.Unity;

namespace Cares.Repository.Repositories
{
    /// <summary>
    /// Insurance Type Repository
    /// </summary>
    public sealed class InsuranceTypeRepository : BaseRepository<InsuranceType>, IInsuranceTypeRepository
    {
        #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        public InsuranceTypeRepository(IUnityContainer container)
            : base(container)
        {

        }
        /// <summary>
        /// Primary database set
        /// </summary>
        protected override IDbSet<InsuranceType> DbSet
        {
            get
            {
                return db.InsuranceTypes;
            }
        }
        #endregion

        #region Public
        /// <summary>
        /// Get All Insurance Types for User Domain Key
        /// </summary>
        public override IEnumerable<InsuranceType> GetAll()
        {
            return DbSet.Where(insuranceType => insuranceType.UserDomainKey == UserDomainKey).ToList();
        }
      
        #endregion
    }
}
