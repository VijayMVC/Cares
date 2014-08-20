namespace Cares.Web.Models
{
    /// <summary>
    /// Phone Web Api Model
    /// </summary>
    public class Phone
    {
        #region Phone Persisted Properties
        /// <summary>
        /// Phone ID
        /// </summary>
        public long? PhoneId { get; set; }
        /// <summary>
        /// Is Default
        /// </summary>
        public bool IsDefault { get; set; }
        /// <summary>
        /// Phone Number
        /// </summary>
        public string PhoneNumber { get; set; }
        /// <summary>
        /// Business Partner Id
        /// </summary>
        public long? BusinessPartnerId { get; set; }
        /// <summary>
        /// Phone Type ID
        /// </summary>
        public int PhoneTypeId { get; set; }
        /// <summary>
        /// Phone Type Key
        /// </summary>
        public int? PhoneTypeKey { get; set; }
        /// <summary>
        /// Phone Type Name
        /// </summary>
        public string PhoneTypeName { get; set; }
        #endregion
    }
}