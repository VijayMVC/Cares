using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cares.Models.DomainModels
{
    /// <summary>
    /// Address Domain Model
    /// </summary>
    public class Address
    {
        #region Persisted Properties
        /// <summary>
        /// Address Id
        /// </summary>
        public long AddressId { get; set; }
        /// <summary>
        /// Contact Person
        /// </summary>
        [StringLength(255)]
        public string ContactPerson { get; set; }
        /// <summary>
        /// Street Address
        /// </summary>
        [Required]
        [StringLength(500)]
        public string StreetAddress { get; set; }
        /// <summary>
        /// Email Address
        /// </summary>
        [StringLength(255)]
        public string EmailAddress { get; set; }
        /// <summary>
        /// Web Page
        /// </summary>
        [StringLength(500)]
        public string WebPage { get; set; }
        /// <summary>
        /// Contact Person
        /// </summary>
        [StringLength(10)]
        public string ZipCode { get; set; }
        /// <summary>
        /// Po Box
        /// </summary>
        [StringLength(20)]
        public string POBox { get; set; }
        /// <summary>
        /// Country
        /// </summary>
        [ForeignKey("Country")]
        public short? CountryId { get; set; }
        ///// <summary>
        ///// Region
        ///// </summary>
        //[ForeignKey("Region")]
        //public int? RegionId { get; set; }
        ///// <summary>
        ///// SubRegion ID
        ///// </summary>
        //[ForeignKey("SubRegion")]
        //public int? SubRegionId { get; set; }
        ///// <summary>
        ///// City
        ///// </summary>
        //[ForeignKey("City")]
        //public int? CityId { get; set; }
        ///// <summary>
        ///// Area
        ///// </summary>
        //[ForeignKey("Area")]
        //public int? AreaId { get; set; }
        /// <summary>
        /// Address Type ID
        /// </summary>
        [ForeignKey("AddressType")]
        public int AddressTypeId { get; set; }
        /// <summary>
        /// Business Partner Id
        /// </summary>
        [ForeignKey("BusinessPartner")]
        public long? BusinessPartnerId { get; set; }
        /// <summary>
        /// Row Version
        /// </summary>
        [Required]
        public long RowVersion { get; set; }
        /// <summary>
        /// Is Active
        /// </summary>
        public bool IsActive { get; set; }
        /// <summary>
        /// Is Deleted
        /// </summary>
        public bool IsDeleted { get; set; }
        /// <summary>
        /// Is Private
        /// </summary>
        public bool IsPrivate { get; set; }
        /// <summary>
        /// Is Readonly
        /// </summary>
        public bool IsReadOnly { get; set; }
        /// <summary>
        /// Record Created Date
        /// </summary>
        public DateTime RecCreatedDt { get; set; }
        /// <summary>
        /// Record Created By
        /// </summary>
        [StringLength(100)]
        public string RecCreatedBy { get; set; }
        /// <summary>
        /// Record Last Updated Date
        /// </summary>
        public DateTime RecLastUpdatedDt { get; set; }
        /// <summary>
        /// Record Last Updated By
        /// </summary>
        [StringLength(100)]
        public string RecLastUpdatedBy { get; set; }
        /// <summary>
        /// User Domain Key
        /// </summary>
        public long UserDomainKey { get; set; }

        #endregion

        #region Reference properties
        /// <summary>
        /// Business Partner
        /// </summary>
        public virtual BusinessPartner BusinessPartner { get; set; }
        /// <summary>
        /// Address Type
        /// </summary>
        public virtual AddressType AddressType { get; set; }
        /// <summary>
        /// Country
        /// </summary>
        public virtual Country Country { get; set; }
        #endregion
    }
}
