using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Interfaces.Repository;
using Microsoft.Practices.Unity;
using Models.Common;
using Models.DomainModels;
using Repository.BaseRepository;

namespace Repository.Repositories
{
    /// <summary>
    /// Standard Rate Repository
    /// </summary>
    public sealed class StandardRateRepository : BaseRepository<StandardRate>, IStandardRateRepository
    {
        #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        public StandardRateRepository(IUnityContainer container)
            : base(container)
        {

        }
        /// <summary>
        /// Primary database set
        /// </summary>
        protected override IDbSet<StandardRate> DbSet
        {
            get
            {
                return db.StandardRates;
            }
        }

        #endregion
        #region Public
        /// <summary>
        /// Get All Standard Rates for User Domain Key
        /// </summary>
        public override IQueryable<StandardRate> GetAll()
        {
            return DbSet.Where(vehicleModel => vehicleModel.UserDomainKey == UserDomainKey);
        }

        #endregion
    }
}
