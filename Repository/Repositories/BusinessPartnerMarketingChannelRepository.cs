using System.Data.Entity;
using System.Linq;
using Cares.Interfaces.Repository;
using Cares.Models.DomainModels;
using Cares.Repository.BaseRepository;
using Microsoft.Practices.Unity;

namespace Cares.Repository.Repositories
{
    /// <summary>
    /// Business Partner Marketing Channel Repository
    /// </summary>
    public sealed class BusinessPartnerMarketingChannelRepository : BaseRepository<BusinessPartnerMarketingChannel>, IBusinessPartnerMarketingChannelRepository
    {
        #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        public BusinessPartnerMarketingChannelRepository(IUnityContainer container)
            : base(container)
        {

        }
        /// <summary>
        /// Primary database set
        /// </summary>
        protected override IDbSet<BusinessPartnerMarketingChannel> DbSet
        {
            get
            {
                return db.BusinessPartnerMarketingChannels;
            }
        }

        #endregion

        #region Public
        
        /// <summary>
        /// Get All Business Partner Marketing Channels for User Domain Key
        /// </summary>
        public override IQueryable<BusinessPartnerMarketingChannel> GetAll()
        {
            return DbSet.Where(businessPartnerMarketingChannel => businessPartnerMarketingChannel.UserDomainKey == UserDomainKey);
        }
        /// <summary>
        /// Get Business Partner Marketing Channel by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public BusinessPartnerMarketingChannel Find(int id)
        {
            throw new System.NotImplementedException();
        } 
        #endregion
    }
}
