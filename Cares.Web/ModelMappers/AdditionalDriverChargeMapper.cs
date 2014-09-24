using System.Linq;
using ResponseModel = Cares.Models.ResponseModels;
using DomainModel = Cares.Models.DomainModels;
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
        ///Web Model To Domain MOdel
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static DomainModel.AdditionalDriverCharge CreateFrom(this ApiModel.AdditionalDriverCharge source)
        {
            return new DomainModel.AdditionalDriverCharge
            {
                AdditionalDriverChargeId = source.AdditionalDriverChargeId,
                TariffTypeCode = source.TariffTypeCode,
                StartDt = source.StartDt,
                AdditionalDriverChargeRate = source.AdditionalDriverChargeRate,
                RevisionNumber = source.RevisionNumber,

            };
        }

          /// <summary>
        /// Domain MOdel To Web Model
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static ApiModel.AdditionalDriverCharge CreateFrom(this DomainModel.AdditionalDriverCharge source)
        {
            return new ApiModel.AdditionalDriverCharge
            {
                AdditionalDriverChargeId = source.AdditionalDriverChargeId,
                TariffTypeCode = source.TariffTypeCode,
                StartDt = source.StartDt,
                AdditionalDriverChargeRate = source.AdditionalDriverChargeRate,
                RevisionNumber = source.RevisionNumber,
                RecCreatedBy = source.RecCreatedBy,
                RecLastUpdatedBy = source.RecLastUpdatedBy,
                RecLastUpdatedDt = source.RecLastUpdatedDt,

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

        #region  Base Data Response

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