using System.Linq;
using Cares.Models.DomainModels;
using Cares.Models.ResponseModels;
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
        ///  Create web model from entity For List
        /// </summary>
        public static ApiModels.TariffRateContent CreateFrom(this TariffRateContent source)
        {
            return new ApiModels.TariffRateContent
            {
                StandardRtMainId = source.StandardRtMainId,
                StandardRtMainCode = source.StandardRtMainCode,
                StandardRtMainName = source.StandardRtMainName,
                StartDt = source.StartDt,
                EndDt = source.EndDt,
                TariffTypeCodeName=source.TariffTypeCodeName,
                StandardRtMainDescription = source.StandardRtMainDescription,
                OperationId = source.OperationId,
                TariffTypeId = source.TariffTypeId,
                OperationCodeName = source.OperationCodeName,
            };
        }
        
        /// <summary>
        ///  Create entity from web model
        /// </summary>
        public static StandardRateMain CreateFrom(this ApiModels.StandardRateMain source)
        {
            return new StandardRateMain
            {
                StandardRtMainId = source.StandardRtMainId,
                StandardRtMainCode = source.StandardRtMainCode,
                StandardRtMainName = source.StandardRtMainName,
                TariffTypeCode= source.TariffTypeId.ToString(),
                StandardRtMainDescription = source.StandardRtMainDescription,
                StartDt = source.StartDt,
                EndDt = source.EndDt,
                StandardRates = source.HireGroupDetailsInStandardRtMain!=null?source.HireGroupDetailsInStandardRtMain.Select(standardRate => standardRate.CreateFrom()).ToList():null
            };
        }
        #endregion
    }
}