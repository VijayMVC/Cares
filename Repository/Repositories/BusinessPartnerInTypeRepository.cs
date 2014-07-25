﻿using System.Data.Entity;
using System.Linq;
using Microsoft.Practices.Unity;
using Models.DomainModels;
using Repository.BaseRepository;
using Interfaces.Repository;

namespace Repository.Repositories
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
        public override IQueryable<BusinessPartnerInType> GetAll()
        {
            return DbSet.Where(businessPartnerInType => businessPartnerInType.UserDomainKey == UserDomainKey);
        }
        /// <summary>
        /// Get Business Partner InType by Id
        /// </summary>
        public BusinessPartnerInType GetById(long id)
        {
            return DbSet.FirstOrDefault(businessPartnerInType => businessPartnerInType.UserDomainKey == UserDomainKey && businessPartnerInType.BusinessPartnerId == id);
        }
        #endregion





       
    }
}
