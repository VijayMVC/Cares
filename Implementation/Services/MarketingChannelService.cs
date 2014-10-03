using Cares.ExceptionHandling;
using Cares.Interfaces.IServices;
using Cares.Interfaces.Repository;
using Cares.Models.DomainModels;
using Cares.Models.RequestModels;
using System;
using System.Collections.Generic;
using System.Globalization;

namespace Cares.Implementation.Services
{
    /// <summary>
    /// Marketing Channel Service
    /// </summary>
    public class MarketingChannelService : IMarketingChannelService
    {
        #region Private
        private readonly IMarketingChannelRepository marketingChannelRepository;
        private readonly IBusinessPartnerMarketingChannelRepository businessPartnerMarketingChannelRepository;

        /// <summary>
        /// Set newly created Marketing Channel object Properties in case of adding
        /// </summary>
        private void SetRegionProperties(MarketingChannel marketingChannel, MarketingChannel dbVersion)
        {
            dbVersion.RecLastUpdatedBy=dbVersion.RecCreatedBy = marketingChannelRepository.LoggedInUserIdentity;
            dbVersion.RecLastUpdatedDt= dbVersion.RecCreatedDt = DateTime.Now;
            dbVersion.MarketingChannelCode = marketingChannel.MarketingChannelCode;
            dbVersion.MarketingChannelName = marketingChannel.MarketingChannelName;
            dbVersion.MarketingChannelDescription = marketingChannel.MarketingChannelDescription;
            dbVersion.UserDomainKey = marketingChannelRepository.UserDomainKey;
        }

        /// <summary>
        /// update  Marketing Channel object Properties in case of updation
        /// </summary>
        protected void UpdateMarketingChannelPropertie(MarketingChannel marketingChannel, MarketingChannel dbVersion)
        {
            dbVersion.RecLastUpdatedBy = marketingChannelRepository.LoggedInUserIdentity;
            dbVersion.RecLastUpdatedDt = DateTime.Now;
            dbVersion.RowVersion = dbVersion.RowVersion + 1;
            dbVersion.MarketingChannelCode = marketingChannel.MarketingChannelCode;
            dbVersion.MarketingChannelName = marketingChannel.MarketingChannelName;
            dbVersion.MarketingChannelDescription = marketingChannel.MarketingChannelDescription;
        }

        //Validation check for deletion
        private void ValidateBeforeDeletion(long marketingChannelId)
        {
            // Assocoation with other entities check 
            if (businessPartnerMarketingChannelRepository.IsBpMarketingChannelAssociatedWithMarketingChannel(marketingChannelId))
                throw new CaresException(Resources.BusinessPartner.MarketingChannel.MarketingChannelIsAssociatedWithPBMarketingChannel);

        }

        #endregion
        #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        public MarketingChannelService(IMarketingChannelRepository marketingChannelRepository, IBusinessPartnerMarketingChannelRepository 
            businessPartnerMarketingChannelRepository)
        {
            this.businessPartnerMarketingChannelRepository = businessPartnerMarketingChannelRepository;
            this.marketingChannelRepository = marketingChannelRepository;
        }
        #endregion
        #region Public

        /// <summary>
        /// Load all Marketing Channels
        /// </summary>
        public IEnumerable<MarketingChannel> LoadAll()
        {
            return marketingChannelRepository.GetAll();
        }

        /// <summary>
        /// Search Marketing Channel
        /// </summary>
        public MarketingChannelSearchRequestResponse SearchMarketingChannel(MarketingChannelSearchRequest request)
        {
            int rowCount;
            return new MarketingChannelSearchRequestResponse
            {
                MarketingChannels = marketingChannelRepository.SearchMarketingChannel(request, out rowCount),
                TotalCount = rowCount
            };
        }

        /// <summary>
        /// Delete Marketing Channel by id
        /// </summary>
        public void DeleteMarketingChannel(long marketingChannelId)
        {
            MarketingChannel dbversion = marketingChannelRepository.Find((short) marketingChannelId);
            ValidateBeforeDeletion(marketingChannelId);
            if (dbversion == null)
            {
                throw new InvalidOperationException(string.Format(CultureInfo.InvariantCulture,
                    "Marketing Channel with Id {0} not found!", marketingChannelId));
            }
            marketingChannelRepository.Delete(dbversion);
            marketingChannelRepository.SaveChanges();  
        }

        /// <summary>
        /// Add /Update Marketing Channel
        /// </summary>
        public MarketingChannel AddUpdateMarketingChannel(MarketingChannel marketingChannel)
        {
            MarketingChannel dbVersion = marketingChannelRepository.Find(marketingChannel.MarketingChannelId);
            //Code Duplication Check
            if (marketingChannelRepository.MarketingChannelCodeDuplicationCheck(marketingChannel))
                throw new CaresException(Resources.BusinessPartner.MarketingChannel.MarketingChannelCodeDuplicationError); 

            if (dbVersion != null)
            {
                UpdateMarketingChannelPropertie(marketingChannel, dbVersion);
                marketingChannelRepository.Update(dbVersion);
            }
            else
            {
                dbVersion = new MarketingChannel();
                SetRegionProperties(marketingChannel, dbVersion);
                marketingChannelRepository.Add(dbVersion);
            }
            marketingChannelRepository.SaveChanges();
            // To Load the proprties
            return marketingChannelRepository.Find(dbVersion.MarketingChannelId);
        }

      
        #endregion
    }
}