namespace Cares.Web.Models
{
    /// <summary>
    /// Address Web Api Model
    /// </summary>
    public class Address
    {
        #region Address Persisted Properties
        /// <summary>
        /// Address ID
        /// </summary>
        public long? AddressId { get; set; }
        /// <summary>
        /// Is Default
        /// </summary>
        public bool IsDefault { get; set; }
        /// <summary>
        /// Address Number
        /// </summary>
        public string AddressNumber { get; set; }
        /// <summary>
        /// Business Partner Id
        /// </summary>
        public long? BusinessPartnerId { get; set; }
        /// <summary>
        /// Address Type ID
        /// </summary>
        public int AddressTypeId { get; set; }
        /// <summary>
        /// Address Type Name
        /// </summary>
        public string AddressTypeName { get; set; }
        #endregion
    }
}