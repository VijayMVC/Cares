using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cares.Models.DomainModels
{
    /// <summary>
    /// Vehicle Purchase Info Domain Model
    /// </summary>
    public class VehiclePurchaseInfo
    {
        #region Persisted Properties

        /// <summary>
        /// Vehicle Purchase Info Id
        /// </summary>
        public long VehiclePurchaseInfoId { get; set; }

        /// <summary>
        /// Vehicle ID
        /// </summary>
        [ForeignKey("Vehicle")]
        public long VehicleId { get; set; }

        /// <summary>
        /// Purchase Date
        /// </summary>
        public DateTime PurchaseDate { get; set; }

        /// <summary>
        /// Purchased From
        /// </summary>
        [StringLength(100)]
        public string PurchasedFrom { get; set; }

        /// <summary>
        /// Purchase Cost
        /// </summary>
        public decimal PurchaseCost { get; set; }

        /// <summary>
        /// Is Used Vehicle
        /// </summary>
        public bool IsUsedVehicle { get; set; }

        /// <summary>
        /// BP Main ID
        /// </summary>
        [ForeignKey("BusinessPartner")]
        public long? BPMainId { get; set; }

        /// <summary>
        /// Record Created Date
        /// </summary>
        [Required]
        public DateTime RecCreatedDt { get; set; }
        /// <summary>
        /// Record Last Updated Date
        /// </summary>
        [Required]
        public DateTime RecLastUpdatedDt { get; set; }

        /// <summary>
        /// Record Last Updated By
        /// </summary>
        [StringLength(100), Required]
        public string RecLastUpdatedBy { get; set; }

        /// <summary>
        /// Record Created By
        /// </summary>
        [StringLength(100), Required]
        public string RecCreatedBy { get; set; }

        /// <summary>
        /// Row Version
        /// </summary>
        [Required]
        public long RowVersion { get; set; }

        /// <summary>
        /// User Domain Key
        /// </summary>
        [Required]
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
