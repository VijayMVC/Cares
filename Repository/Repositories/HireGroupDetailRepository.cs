using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Cryptography.X509Certificates;
using Interfaces.Repository;
using Microsoft.Practices.Unity;
using Models.Common;
using Models.DomainModels;
using Models.RequestModels;
using Models.ResponseModels;
using Repository.BaseRepository;

namespace Repository.Repositories
{
    /// <summary>
    /// Hire Group Detail Repository
    /// </summary>
    public sealed class HireGroupDetailRepository : BaseRepository<HireGroupDetail>, IHireGroupDetailRepository
    {
       
        #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        public HireGroupDetailRepository(IUnityContainer container)
            : base(container)
        {

        }
        /// <summary>
        /// Primary database set
        /// </summary>
        protected override IDbSet<HireGroupDetail> DbSet
        {
            get
            {
                return db.HireGroupDetails;
            }
        }

        #endregion
        #region Public
        /// <summary>
        /// Get All Vehicle Models for User Domain Key
        /// </summary>
        public override IQueryable<HireGroupDetail> GetAll()
        {
            return DbSet.Where(vehicleModel => vehicleModel.UserDomainKey == UserDomainKey);
        }

        /// <summary>
        /// Get Hire Group detail, based on filter criteria
        /// </summary>
        public HireGroupDetailResponse GetHireGroupDetailsForTariffRate()
        {

            IEnumerable<HireGroupDetail> hireGroupDetails = DbSet.Where(h => h.UserDomainKey == UserDomainKey).Include(x => x.HireGroup);
            return new HireGroupDetailResponse { HireGroupDetails = hireGroupDetails, TotalCount = hireGroupDetails.Count() };
        }
        #endregion
    }
}
