﻿using System.Data.Entity;
using System.Linq;
using Cares.Interfaces.Repository;
using Cares.Models.DomainModels;
using Cares.Models.IdentityModels;
using Cares.Repository.BaseRepository;
using Microsoft.Practices.Unity;

namespace Cares.Repository.Repositories
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
       #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        public UserRepository(IUnityContainer container)
            : base(container)
        {

        }
        /// <summary>
        /// Primary database set
        /// </summary>
        protected override IDbSet<User> DbSet
        {
            get
            {
                return db.Users;
            }
        }

        #endregion
        #region

        /// <summary>
        /// To get the maximum user domain key
        /// </summary>
        public double GetMaxUserDomainKey()
        {
            return DbSet.Max(user => user.UserDomainKey);
        }
        #endregion
    }
}
