using System.Linq;
using Cares.Web.Models;
using DomainResponseModels = Models.ResponseModels;
namespace Cares.Web.ModelMappers
{
    /// <summary>
    /// Tariff Rate Mapper
    /// </summary>
    public static class TariffRateMapper
    {
        /// <summary>
        /// Create web model from entity
        /// </summary>
        public static TariffRateResponse CreateFrom(this DomainResponseModels.TariffRateResponse source)
        {
            return new TariffRateResponse
            {
                TariffRates = source.TariffRates.Select(company => company.CreateFrom()),
                TotalCount = source.TotalCount
            };
        }
        #region Hire Group Deatil
        /// <summary>
        ///  Create web model from entity 
        /// </summary>
        public static HireGroupDetailResponse CreateFromHireGroupDetail(this DomainResponseModels.HireGroupDetailResponse source)
        {
            return new HireGroupDetailResponse
            {
                HireGroupDetails = source.HireGroupDetails.Select(hireGroup => hireGroup.CreateFrom()),
                TotalCount = source.TotalCount
            };
        }
        #endregion
    }
}