using System.Linq;
using ResponseModel = Cares.Models.ResponseModels;
using ApiModel = Cares.Web.Models;

namespace Cares.Web.ModelMappers
{
    /// <summary>
    /// Additional Driver Charge Mapper
    /// </summary>
    public static class AdditionalDriverChargeMapper
    {
        #region Public
        /// <summary>
        /// Domain Response To Web Response
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static ApiModel.AdditionalDriverChargeSearchContent CreateFrom(this ResponseModel.AdditionalDriverChargeSearchContent source)
        {
            return new ApiModel.AdditionalDriverChargeSearchContent
            {
                AdditionalDriverChargeId = source.AdditionalDriverChargeId,
                TariffTypeCode = source.TariffTypeCode,
                TariffTypeCodeName = source.TariffTypeCodeName,
                StartDt = source.StartDt,
                OperationCodeName = source.OperationCodeName,
                CompanyCodeName = source.CompanyCodeName,
                AdditionalDriverChargeRate = source.AdditionalDriverChargeRate,
                CompanyId = source.CompanyId,
                DepartmentId = source.DepartmentId,
                OperationId = source.OperationId,
                TariffTypeId = source.TariffTypeId,
                RevisionNumber = source.RevisionNumber,

            };
        }

        /// <summary>
        /// Domain Response To Web Response
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static ApiModel.AdditionalDriverChargeSearchResponse CreateFrom(this ResponseModel.AdditionalDriverChargeSearchResponse source)
        {
            return new ApiModel.AdditionalDriverChargeSearchResponse
            {
                AdditionalDriverCharges = source.AdditionalDriverCharges.Select(addDriverChrg => addDriverChrg.CreateFrom()),
                TotalCount = source.TotalCount
            };
        }
        #endregion

        #region Vehicle Base Data Response

        /// <summary>
        /// Domain Response To Web Response
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static ApiModel.AdditionalDriverChargeBaseResponse CreateFrom(this ResponseModel.AdditionalDriverBaseResponse source)
        {
            return new ApiModel.AdditionalDriverChargeBaseResponse
            {
                Operations = source.Operations.Select(op => op.CreateFrom()),
                Companies = source.Companies.Select(comp => comp.CreateFrom()),
                Departments = source.Departments.Select(d => d.CreateFrom()),
                TariffTypes = source.TariffTypes.Select(d => d.CreateFromDropDown()),
            };
        }

        #endregion
    }
}