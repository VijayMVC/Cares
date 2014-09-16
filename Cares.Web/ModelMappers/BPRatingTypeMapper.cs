using Cares.Web.Models;

namespace Cares.Web.ModelMappers
{
    /// <summary>
    /// Business Partner Rating Type Mapper
    /// </summary>
    public static class BPRatingTypeMapper
    {
        /// <summary>
        ///  Create web api model from domail model
        /// </summary>
        public static BpRatingTypeDropDown CreateFrom(this Cares.Models.DomainModels.BpRatingType source)
        {
            return new BpRatingTypeDropDown
            {
                BpRatingTypeId = source.BpRatingTypeId,
                BpRatingTypeCodeName = source.BpRatingTypeCode +'-'+ source.BpRatingTypeName
            };
        }
        /// <summary>
        ///  Create domain model from web api model
        /// </summary>
        public static Cares.Models.DomainModels.BpRatingType CreateFrom(this BpRatingTypeDropDown source)
        {
            if (source != null)
            {
                return new Cares.Models.DomainModels.BpRatingType
                {
                    BpRatingTypeId = source.BpRatingTypeId,
                    BpRatingTypeName = source.BpRatingTypeCodeName
                };
            }
            return new Cares.Models.DomainModels.BpRatingType();
        }
    }
}