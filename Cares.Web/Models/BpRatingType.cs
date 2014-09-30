
namespace Cares.Web.Models
{
    /// <summary>
    /// web model
    /// </summary>
    public class BpRatingType
    {
        #region Persisted Properties

        /// <summary>
        /// Business Partner Rating Type ID
        /// </summary>
        public short BpRatingTypeId { get; set; }

        /// <summary>
        /// Business Partner Rating Type Code
        /// </summary>
        public string BpRatingTypeCode { get; set; }

        /// <summary>
        /// Business Partner Rating Type Name
        /// </summary>
        public string BpRatingTypeName { get; set; }

        /// <summary>
        /// Business Partner Rating Type Description
        /// </summary>
        public string BpRatingTypeDescription { get; set; }
        #endregion
    }
}