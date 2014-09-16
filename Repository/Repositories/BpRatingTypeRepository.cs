using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Cares.Interfaces.Repository;
using Cares.Models.DomainModels;
using Cares.Repository.BaseRepository;
using Microsoft.Practices.Unity;

namespace Cares.Repository.Repositories
{
    public sealed class BpRatingTypeRepository : BaseRepository<BpRatingType>, IBpRatingTypeRepository
    {
        #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        public BpRatingTypeRepository(IUnityContainer container)
            : base(container)
        {

        }
        /// <summary>
        /// Primary database set
        /// </summary>
        protected override IDbSet<BpRatingType> DbSet
        {
            get
            {
                return db.BpRatingTypes;
            }
        }

        #endregion

        #region Public
        /// <summary>
        /// Get All Measurement Units for User Domain Key
        /// </summary>
        public override IEnumerable<BpRatingType> GetAll()
        {
            return DbSet.Where(bpRatingType => bpRatingType.UserDomainKey == UserDomainKey).ToList();
        }

        #endregion
    }
}
