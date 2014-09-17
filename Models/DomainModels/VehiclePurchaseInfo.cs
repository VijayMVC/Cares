using System;

namespace Cares.Models.DomainModels
{
    /// <summary>
    /// Vehicle Purchase Info Domain Model
    /// </summary>
    public class VehiclePurchaseInfo
    {
        #region Persisted Properties

        /// <summary>
        /// Vehicle ID
        /// </summary>
        public long VehicleId { get; set; }

        /// <summary>
        /// Purchase Date
        /// </summary>
        public DateTime? PurchaseDate { get; set; }

        /// <summary>
        /// Purchased From
        /// </summary>
        public string PurchasedFrom { get; set; }

        /// <summary>
        /// Purchase Order Number
        /// </summary>
        public string PurchaseOrderNumber { get; set; } 
        
        /// <summary>
        /// Purchase Description
        /// </summary>
        public string PurchaseDescription { get; set; }

        /// <summary>
        /// Purchase Cost
        /// </summary>
        public decimal? PurchaseCost { get; set; }

        /// <summary>
        /// Is Used Vehicle
        /// </summary>
        public bool? IsUsedVehicle { get; set; }

        /// <summary>
        /// Business Partner Id
        /// </summary>
        public long? BusinessPartnerId { get; set; }

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
          public string RecLastUpdatedBy { get; set; }

        /// <summary>
        /// Record Created By
        /// </summary>
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
