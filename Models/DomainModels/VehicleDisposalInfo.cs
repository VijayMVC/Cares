using System;

namespace Cares.Models.DomainModels
{

    /// <summary>
    /// Vehicle Disposal Info
    /// </summary>
    public class VehicleDisposalInfo
    {

        #region Persisted Properties

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
