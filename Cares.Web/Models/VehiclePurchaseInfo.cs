using System;

namespace Cares.Web.Models
{
    /// <summary>
    /// Vehicle Purchase Info Web Model
    /// </summary>
    public sealed class VehiclePurchaseInfo
    {
        /// <summary>
        /// Vehicle Purchase Info Id
        /// </summary>
        public long VehiclePurchaseInfoId { get; set; }

        /// <summary>
        /// Vehicle ID
        /// </summary>
        public long VehicleId { get; set; }

        /// <summary>
        /// Purchase Date
        /// </summary>
        public DateTime? PurchaseDate { get; set; }

        /// <summary>
        /// Purchase Description
        /// </summary>
          public string PurchaseDescription { get; set; }
        /// <summary>
        /// Purchased From
        /// </summary>
        public string PurchasedFrom { get; set; }

        /// <summary>
        /// Purchase Order Number
        /// </summary>
        public string PurchaseOrderNumber { get; set; }
        /// <summary>
        /// Purchase Cost
        /// </summary>
        public decimal? PurchaseCost { get; set; }

        /// <summary>
        /// Is Used Vehicle
        /// </summary>
        public bool? IsUsedVehicle { get; set; }

        /// <summary>
        /// BP Main ID
        /// </summary>
        public long? BPMainId { get; set; }
    }
}