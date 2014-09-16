using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cares.Models.DomainModels
{

    /// <summary>
    /// Vehicle Disposal Info
    /// </summary>
    public class VehicleDisposalInfo
    {

        #region Persisted Properties

        /// <summary>
        /// Vehicle Disposal Info Id
        /// </summary>
        public long VehicleDisposalInfoId { get; set; }

        /// <summary>
        /// Vehicle ID
        /// </summary>
        [ForeignKey("Vehicle")]
        public long VehicleId { get; set; }

        /// <summary>
        /// Sale Date
        /// </summary>
        public DateTime? SaleDate { get; set; }

        /// <summary>
        /// Sale Price
        /// </summary>
        public decimal? SalePrice { get; set; }

        /// <summary>
        ///Sold To
        /// </summary>
        [StringLength(255)]
        public string SoldTo { get; set; }

        /// <summary>
        ///Disposal Description
        /// </summary>
        [StringLength(500)]
        public string DisposalDescription { get; set; }

        /// <summary>
        /// BP Main ID
        /// </summary>
        [ForeignKey("BusinessPartner")]
        public long? BPMainId { get; set; }

        /// <summary>
        /// Record Created Date
        /// </summary>
       public DateTime RecCreatedDt { get; set; }
        
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
        /// Record Created By
        /// </summary>
        [StringLength(100)]
        public string RecCreatedBy { get; set; }

        /// <summary>
        /// Row Version
        /// </summary>
        public long RowVersion { get; set; }

        /// <summary>
        /// User Domain Key
        /// </summary>
        public long UserDomainKey { get; set; }


        #endregion

        #region Reference Properties

        /// <summary>
        /// Vehicle
        /// </summary>
        public virtual Vehicle Vehicle { get; set; }

        /// <summary>
        /// Business Partner
        /// </summary>
        public virtual BusinessPartner BusinessPartner { get; set; }
        #endregion
    }
}
