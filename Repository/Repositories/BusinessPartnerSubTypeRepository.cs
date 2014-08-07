using System.Data.Entity;
using System.Linq;
using Cares.Interfaces.Repository;
using Cares.Models.DomainModels;
using Cares.Repository.BaseRepository;
using Microsoft.Practices.Unity;

namespace Cares.Repository.Repositories
{
    /// <summary>
    /// Business Partner SubType Repository
    /// </summary>
    public sealed class BusinessPartnerSubTypeRepository : BaseRepository<BusinessPartnerSubType>, IBusinessPartnerSubTypeRepository
    {
        #region Private
        #endregion

        #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        public BusinessPartnerSubTypeRepository(IUnityContainer container)
            : base(container)
        {

        }
        /// <summary>
        /// Primary database set
        /// </summary>
        protected override IDbSet<BusinessPartnerSubType> DbSet
        {
            get
            {
                return db.BusinessPartnerSubTypes;
            }
        }

        #endregion

        #region Public
        
        ///// <summary>
        ///// Get business partner by firstname and id
        ///// </summary>
        ///// <param name="firstname"></param>
        ///// <param name="id"></param>
        ///// <returns></returns>
        //public BusinessPartnerSubType GetBusinessPartnerIndividualByName(string firstname, int id)
        //{
        //    return DbSet.FirstOrDefault(businessPartnerIndividual => businessPartnerIndividual == firstname && businessPartnerIndividual.BusinessPartnerId == id);
        //}
        /// <summary>
        /// Get All Business Partner SubTypes for User Domain Key
        /// </summary>
        public override IQueryable<BusinessPartnerSubType> GetAll()
        {
            return DbSet.Where(businessPartnerSubType => businessPartnerSubType.UserDomainKey == UserDomainKey);
        }
        ///// <summary>
        ///// Get Business Partner SubType by Id
        ///// </summary>
        //public BusinessPartnerSubType GetById(long id)
        //{
        //    return DbSet.FirstOrDefault(businessPartnerIndividual => businessPartnerIndividual.UserDomainKey == UserDomainKey && businessPartnerIndividual.BusinessPartnerId == id);
        //}
       
        /// <summary>
        /// Get Business Partner SubType by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public BusinessPartnerSubType Find(int id)
        {
            throw new System.NotImplementedException();
        } 
        #endregion
    }
}
