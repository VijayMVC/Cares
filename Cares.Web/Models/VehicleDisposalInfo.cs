using System;

namespace Cares.Web.Models
{
    /// <summary>
    /// Vehicle Disposal Info Web Model
    /// </summary>
    public class VehicleDisposalInfo
    {
        /// <summary>
        /// Vehicle Disposal Info Id
        /// </summary>
        public long VehicleDisposalInfoId { get; set; }

        /// <summary>
        /// Vehicle ID
        /// </summary>
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
        public string SoldTo { get; set; }

        /// <summary>
        ///Disposal Description
        /// </summary>
        public string DisposalDescription { get; set; }

        /// <summary>
        /// BP Main ID
        /// </summary>
        public long? BPMainId { get; set; }
    }
}