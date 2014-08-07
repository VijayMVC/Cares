using Cares.Web.Models;

namespace Cares.Web.ModelMappers
{
    /// <summary>
    /// Business Partner Rating Type Mapper
    /// </summary>
    public static class BPRatingTypeMapper
    {
        #region Public
        /// <summary>
        ///  Create web api model from domail model
        /// </summary>
        public static BpRatingType CreateFrom(this Cares.Models.DomainModels.BpRatingType source)
        {
            return new BpRatingType
            {
                BpRatingTypeId = source.BpRatingTypeId,
                BpRatingTypeName = source.BpRatingTypeCode +'-'+ source.BpRatingTypeName,
                BpRatingTypeCustomId = source.BpRatingTypeId.ToString() + '-' + source.BpRatingTypeCode + '-' + source.BpRatingTypeName
            };
        }
        /// <summary>
        ///  Create domain model from web api model
        /// </summary>
        public static Cares.Models.DomainModels.BpRatingType CreateFrom(this BpRatingType source)
        {
            if (source != null)
            {
                return new Cares.Models.DomainModels.BpRatingType
                {
                    BpRatingTypeId = source.BpRatingTypeId,
                    BpRatingTypeName = source.BpRatingTypeName
                };
            }
            return new Cares.Models.DomainModels.BpRatingType();
        }
        #endregion
    }
}