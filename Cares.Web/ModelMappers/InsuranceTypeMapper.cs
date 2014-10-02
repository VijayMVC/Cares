using Cares.Web.Models;

namespace Cares.Web.ModelMappers
{
    /// <summary>
    /// Insurance Type Mapper
    /// </summary>
    public static class InsuranceTypeMapper
    {
        #region Public

        /// <summary>
        ///  Create web model from entity
        /// </summary>
        public static InsuranceTypeDropDown CreateFromDropDown(this Cares.Models.DomainModels.InsuranceType source)
        {
            return new InsuranceTypeDropDown
            {
                InsuranceTypeId = source.InsuranceTypeId,
                InsuranceTypeCodeName = source.InsuranceTypeCode + " - " + source.InsuranceTypeName
            };
        }

        /// <summary>
        ///  Create web model from entity
        /// </summary>
        public static InsuranceRtDetailContent CreateFrom(this Cares.Models.DomainModels.InsuranceType source)
        {
            return new InsuranceRtDetailContent
            {
                InsuranceTypeId = source.InsuranceTypeId,
                InsuranceTypeCodeName = source.InsuranceTypeCode + " - " + source.InsuranceTypeName
            };
        }

        #endregion
    }
}