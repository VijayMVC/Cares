using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using Cares.Interfaces.Repository;
using Cares.Models.Common;
using Cares.Models.DomainModels;
using Cares.Models.RequestModels;
using Cares.Repository.BaseRepository;
using Microsoft.Practices.Unity;

namespace Cares.Repository.Repositories
{
    /// <summary>
    /// Business Partner Main Type Repository
    /// </summary>
    public sealed class BpSubTypeRepository : BaseRepository<BusinessPartnerSubType>, IBpSubTypeRepository
    {
        #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        public BpSubTypeRepository(IUnityContainer container)
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
        
        /// <summary>
        /// Find Business Partner Sub Type By Id
        /// </summary>
        public BusinessPartnerSubType Find(int id)
        {
            return DbSet.Find(id);
        }

       
        /// <summary>
        /// Get All Business Partner Sub Types for User Domain Key
        /// </summary>
        public override IEnumerable<BusinessPartnerSubType> GetAll()
        {
            return DbSet.Where(company => company.UserDomainKey == UserDomainKey).ToList();
        }


        /// <summary>
        /// Association check between bp sub type and bp main type
        /// </summary>
       public bool IsBpSubTypeAssociatedWithBpMainType(long bpMainTypeId)
        {
            return DbSet.Count(bpMainType => bpMainType.BusinessPartnerMainTypeId == bpMainTypeId) > 0;
        }
        #endregion
    }
}
