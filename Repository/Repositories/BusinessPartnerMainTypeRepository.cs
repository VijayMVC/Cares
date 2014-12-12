using System.Collections.Generic;
using System.Linq;
using Cares.Interfaces.Repository;
using Cares.Models.DomainModels;
using Cares.Repository.BaseRepository;
using Microsoft.Practices.Unity;
using System.Data.Entity;

namespace Cares.Repository.Repositories
{
    /// <summary>
    /// Business Partner Main Type Repository
    /// </summary>
    public sealed class BusinessPartnerMainTypeRepository : BaseRepository<BusinessPartnerMainType>, IBusinessPartnerMainTypeRepository
    {
        #region Constructor
        /// <summary>
        /// Business Partner Main Type Repo. Constructor
        /// </summary>
        public BusinessPartnerMainTypeRepository(IUnityContainer container)
            : base(container)
        {

        }
        /// <summary>
        /// Primary database set
        /// </summary>
        protected override IDbSet<BusinessPartnerMainType> DbSet
        {
            get
            {
                return db.BusinessPartnerMainTypes;
            }
        }

        #endregion
        #region Public

        /// <summary>
        /// Find business Partner Main Type by id
        /// </summary>
        public BusinessPartnerMainType Find(int id)
        {
            return DbSet.FirstOrDefault(bpMainType => bpMainType.BusinessPartnerMainTypeId==id && bpMainType.UserDomainKey==UserDomainKey);
        }

        /// <summary>
        /// Get All Business Partner Main Types
        /// </summary>
        public override IEnumerable<BusinessPartnerMainType> GetAll()
        {
            return DbSet.Where(businessPartnerMainType => businessPartnerMainType.UserDomainKey == UserDomainKey).ToList();
        }


        #endregion

       
    }
}
