namespace Cares.Web.Models
{
    /// <summary>
    /// Business Partner Rating Type Api model
    /// </summary>
    public class BpRatingType
    {
        #region Public Properties
        /// <summary>
        /// Business Partner Rating Type ID
        /// </summary>
        public int BpRatingTypeId { get; set; }
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
        /// <summary>
        /// User Domain Key
        /// </summary>
        public long UserDomainKey { get; set; }

        #endregion
    }
}
