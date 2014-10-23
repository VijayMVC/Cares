using System.Linq;
using Cares.Models.RequestModels;
using ApiModel = Cares.Web.Models;
using DomainModel = Cares.Models.DomainModels;
namespace Cares.Web.ModelMappers
{
    /// <summary>
    /// Marketing Channel Mapper
    /// </summary>
    public static class MarketingChannelMapper
    {
        #region Public 
        #region Entity To Model

        /// <summary>
        ///  Create web Api model from domain entity [dropdown]
        /// </summary>
        public static ApiModel.MarketingChannelDropDown CreateFrom(this DomainModel.MarketingChannel source)
            {
                return new ApiModel.MarketingChannelDropDown()
                {
                    MarketingChannelId = source.MarketingChannelId,
                    MarketingChannelCodeName = source.MarketingChannelCode + " - "+source.MarketingChannelName,
                };
            }
        
        /// <summary>
        ///  Create web Api search request response model 
        /// </summary>
        public static ApiModel.MarketingChannelSearchRequestResponse CreateFromm(
            this MarketingChannelSearchRequestResponse source)
        {
            return new ApiModel.MarketingChannelSearchRequestResponse
            {
                TotalCount = source.TotalCount,
                MarketingChannels = source.MarketingChannels.Select(marketingchanel => marketingchanel.CreateFromm())
            };

        }

        /// <summary>
        ///  Create web Api model from domain entity 
        /// </summary>
        public static ApiModel.MarketingChannel CreateFromm(this DomainModel.MarketingChannel source)
        {
            return new ApiModel.MarketingChannel
            {
                MarketingChannelId = source.MarketingChannelId,
                MarketingChannelCode = source.MarketingChannelCode ,
                MarketingChannelName = source.MarketingChannelName,
                MarketingChannelDescription = source.MarketingChannelDescription
            };
        }
        #endregion
        #region Model to Entity

        /// <summary>
        ///  Create from web model
        /// </summary>
        public static DomainModel.MarketingChannel CreateFrom(this ApiModel.MarketingChannel source)
        {
            return new DomainModel.MarketingChannel
            {
                MarketingChannelId = source.MarketingChannelId,
                MarketingChannelCode = source.MarketingChannelCode.Trim(),
                MarketingChannelName = source.MarketingChannelName,
                MarketingChannelDescription = source.MarketingChannelDescription
            };
        }
        #endregion
        #endregion
    }
}