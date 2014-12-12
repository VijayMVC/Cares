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
    /// Business Partner InType Repository
    /// </summary>
    public sealed class BusinessPartnerInTypeRepository : BaseRepository<BusinessPartnerInType>, IBusinessPartnerInTypeRepository
    {
        #region Private
        #endregion

        #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        public BusinessPartnerInTypeRepository(IUnityContainer container)
            : base(container)
        {

        }
        /// <summary>
        /// Primary database set
        /// </summary>
        protected override IDbSet<BusinessPartnerInType> DbSet
        {
            get
            {
                return db.BusinessPartnerInTypes;
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
        public override IEnumerable<BusinessPartnerInType> GetAll()
        {
            return DbSet.Where(businessPartnerInType => businessPartnerInType.UserDomainKey == UserDomainKey).ToList();
        }
        /// <summary>
        /// Get Business Partner InType by Id
        /// </summary>
        public BusinessPartnerInType GetById(long id)
        {
            return DbSet.FirstOrDefault(businessPartnerInType => businessPartnerInType.UserDomainKey == UserDomainKey && businessPartnerInType.BusinessPartnerId == id);
        }

        /// <summary>
        /// Association check of Business Partner Sub Type and Business Partner Sub Type
        /// </summary>
        public bool IsBusinessPartnerSubTypeAssociatedWithBusinessPartnerInType(long businessPartnerSubTypeId)
        {
            return DbSet.Count(businessPartnerInType =>businessPartnerInType.UserDomainKey==UserDomainKey &&  businessPartnerInType.BusinessPartnerSubTypeId == businessPartnerSubTypeId) > 0;            
            
        }
        #endregion

    }
}
