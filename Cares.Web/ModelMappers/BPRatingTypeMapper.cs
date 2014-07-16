
using DomainModels = Models.DomainModels;
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
        public static BpRatingType CreateFrom(this DomainModels.BpRatingType source)
        {
            return new BpRatingType
            {
                BpRatingTypeId = source.BpRatingTypeId,
                BpRatingTypeName = source.BpRatingTypeName
            };
        }
        /// <summary>
        ///  Create domain model from web api model
        /// </summary>
        public static DomainModels.BpRatingType CreateFrom(this BpRatingType source)
        {
            if (source != null)
            {
                return new DomainModels.BpRatingType
                {
                    BpRatingTypeId = source.BpRatingTypeId,
                    BpRatingTypeName = source.BpRatingTypeName
                };
            }
            return new DomainModels.BpRatingType();
        }
        #endregion
    }
}