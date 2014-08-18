using System.Linq;
using DomainResponseModel=Cares.Models.ResponseModels;
using ApiModel=Cares.Web.Models;
namespace Cares.Web.ModelMappers
{
    /// <summary>
    /// Insurance Rate Mapper
    /// </summary>
    public static class InsuranceRateMapper
    {
        #region Tariff Rate Base Response Mapper
        /// <summary>
        ///  Tariff Type Base Response Mapper
        /// </summary>
        public static ApiModel.InsuranceRateBaseResponse CreateFromBaseResponse(this DomainResponseModel.InsuranceRateBaseResponse source)
        {
            return new ApiModel.InsuranceRateBaseResponse
            {
                 Operations = source.Operations.Select(operation => operation.CreateFrom()),
                 TariffTypes = source.TariffTypes.Select(tariffType => tariffType.CreateFromDropDown()),
            };
        }
        #endregion
    }
}