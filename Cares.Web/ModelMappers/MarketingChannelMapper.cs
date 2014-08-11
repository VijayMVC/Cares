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
        ///  Create web Api model from domain entity
        /// </summary>
        public static ApiModel.MarketingChannel CreateFrom(this DomainModel.MarketingChannel source)
            {
                return new ApiModel.MarketingChannel()
                {
                    MarketingChannelId = source.MarketingChannelId,
                    MarketingChannelName = source.MarketingChannelCode + '-'+source.MarketingChannelName,
                    MarketingChannelCustomId = source.MarketingChannelId.ToString() + '-'+ source.MarketingChannelCode + '-' + source.MarketingChannelName
                };
            }
        #endregion
        #endregion
    }
}