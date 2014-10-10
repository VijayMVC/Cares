using System.Linq;
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
        ///  Create Detail Content web model from entity
        /// </summary>
        public static InsuranceRtDetailContent CreateFrom(this Cares.Models.DomainModels.InsuranceType source)
        {
            return new InsuranceRtDetailContent
            {
                InsuranceTypeId = source.InsuranceTypeId,
                InsuranceTypeCodeName = source.InsuranceTypeCode + " - " + source.InsuranceTypeName
            };
        }

        /// <summary>
        ///  Create  From Domain Model
        /// </summary>
        public static InsuranceType CreateFromm(this Cares.Models.DomainModels.InsuranceType source)
        {
            return new InsuranceType
            {
                InsuranceTypeId = source.InsuranceTypeId,
                InsuranceTypeCode = source.InsuranceTypeCode,
                InsuranceTypeName = source.InsuranceTypeName,
                InsuranceTypeDescription = source.InsuranceTypeDescription
            };
        }

        /// <summary>
        ///  Create  From Web Model
        /// </summary>
        public static Cares.Models.DomainModels.InsuranceType CreateFromm(this InsuranceType source)
        {
            return new Cares.Models.DomainModels.InsuranceType
            {
                InsuranceTypeId = source.InsuranceTypeId,
                InsuranceTypeCode = source.InsuranceTypeCode,
                InsuranceTypeName = source.InsuranceTypeName,
                InsuranceTypeDescription = source.InsuranceTypeDescription
            };
        }

        /// <summary>
        ///  Create From Search Search Domain Response 
        /// </summary>
        public static InsuranceTypeSearchRequestResponse CreateFromm(this Cares.Models.ResponseModels.InsuranceTypeSearchRequestResponse source)
        {
            return new InsuranceTypeSearchRequestResponse
            {
                InsuranceTypes = source.InsuranceTypes.Select(insuranceType => insuranceType.CreateFromm())
            };
        }

        #endregion
    }
}