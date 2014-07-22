using DomainModels = Models.DomainModels;
using ApiModels = Cares.Web.Models;

namespace Cares.Web.ModelMappers
{
    /// <summary>
    /// Standard Rate Main Mapper
    /// </summary>
    public static class StandardRateMainMapper
    {
        #region Public
        /// <summary>
        ///  Create web model from entity
        /// </summary>
        public static ApiModels.StandardRateMain CreateFrom(this DomainModels.StandardRateMain source)
        {
            return new ApiModels.StandardRateMain
            {

                StandardRtMainId = source.StandardRtMainId,
                StandardRtMainCode = source.StandardRtMainCode,
                StandardRtMainName = source.StandardRtMainName,
                StartDt =source.StartDt,
                EndDt = source.EndDt
               

            };

        }
        #endregion
    }
}