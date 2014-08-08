namespace Cares.Web.Models
{
    /// <summary>
    /// Address Web Api Model
    /// </summary>
    public class Address
    {
        #region Public Properties
        /// <summary>
        /// Address ID
        /// </summary>
        public long? AddressId { get; set; }
        /// <summary>
        /// Contact Person
        /// </summary>
        public string ContactPerson { get; set; }
        /// <summary>
        /// Street Address
        /// </summary>
        public string StreetAddress { get; set; }
        /// <summary>
        /// Email Address
        /// </summary>
        public string EmailAddress { get; set; }
        /// <summary>
        /// Web Page
        /// </summary>
        public string WebPage { get; set; }
        /// <summary>
        /// Contact Person
        /// </summary>
        public string ZipCode { get; set; }
        /// <summary>
        /// Po Box
        /// </summary>
        public string POBox { get; set; }
        /// <summary>
        /// Country
        /// </summary>
        public short? CountryId { get; set; }
        /// <summary>
        /// Region
        /// </summary>
        public short? RegionId { get; set; }
        /// <summary>
        /// Sub Region
        /// </summary>
        public short? SubRegionId { get; set; }
        /// <summary>
        /// City
        /// </summary>
        public short? CityId { get; set; }
        /// <summary>
        /// Area
        /// </summary>
        public short? AreaId { get; set; }
        /// <summary>
        /// Address Type ID
        /// </summary>
        public short AddressTypeId { get; set; }
        /// <summary>
        /// Business Partner Id
        /// </summary>
        public long? BusinessPartnerId { get; set; }

        #endregion
    }
}