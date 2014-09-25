using System.Linq;
using DomainModel = Cares.Models.DomainModels;
using DomainResponseModel = Cares.Models.ResponseModels;
using ApiModel = Cares.Web.Models;

namespace Cares.Web.ModelMappers
{
    /// <summary>
    /// Chauffer Charge Mapper
    /// </summary>
    public static class ChaufferChargeMapper
    {

        #region Public
        /// <summary>
        /// Domain Model To Web Model
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static ApiModel.ChaufferChargeMainContent CreateFrom(this DomainResponseModel.ChaufferChargeMainContent source)
        {
            return new ApiModel.ChaufferChargeMainContent
            {
                ChaufferChargeMainId = source.ChaufferChargeMainId,
                Code = source.Code,
                Name = source.Name,
                CompanyId = source.CompanyId,
                CompanyCodeName = source.CompanyCodeName,
                DepartmentId = source.DepartmentId,
                OperationId = source.OperationId,
                OperationCodeName = source.OperationCodeName,
                TariffTypeId = source.TariffTypeId,
                TariffTypeCodeName = source.TariffTypeCodeName,
                Description = source.Description,
                StartDate = source.StartDate,
            };
        }
        /// <summary>
        /// Web Model To Domain Model
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static DomainModel.ChaufferChargeMain CreateFrom(this ApiModel.ChaufferChargeMain source)
        {
            return new DomainModel.ChaufferChargeMain
            {
                ChaufferChargeMainId = source.ChaufferChargeMainId,
                ChaufferChargeMainCode = source.Code,
                ChaufferChargeMainName = source.Name,
                TariffTypeCode = source.TariffTypeId.ToString(),
                ChaufferChargeMainDescription = source.Description,
                StartDt = source.StartDate,
                ChaufferCharges = source.chaufferCharges.Select(c => c.CreateFrom()).ToList()
            };
        }
        /// <summary>
        /// Web Model To Domain Model
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static DomainModel.ChaufferCharge CreateFrom(this ApiModel.ChaufferCharge source)
        {
            return new DomainModel.ChaufferCharge
            {
                ChaufferChargeId = source.ChaufferChargeId,
                DesigGradeId = source.DesigGradeId,
                ChaufferChargeRate = source.ChaufferChargeRate,
                StartDt = source.StartDt,
            };
        }

        /// <summary>
        /// Domain Response To Web Response
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static ApiModel.ChaufferChargeSearchResponse CreateFrom(this DomainResponseModel.ChaufferChargeSearchResponse source)
        {
            return new ApiModel.ChaufferChargeSearchResponse
            {
                ChaufferChargeMains = source.ChaufferChargeMains.Select(c => c.CreateFrom()).ToList(),
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
        public static ApiModel.ChaufferChargeBaseResponse CreateFrom(this DomainResponseModel.ChaufferChargeBaseResponse source)
        {
            return new ApiModel.ChaufferChargeBaseResponse
            {
                Companies = source.Companies.Select(c => c.CreateFrom()).ToList(),
                Departments = source.Departments.Select(c => c.CreateFrom()).ToList(),
                Operations = source.Operations.Select(c => c.CreateFrom()).ToList(),
                TariffTypes = source.TariffTypes.Select(c => c.CreateFromDropDown()).ToList(),

            };
        }
        #endregion
    }
}