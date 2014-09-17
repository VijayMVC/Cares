using System;

namespace Cares.Models.DomainModels
{
    /// <summary>
    /// Vehicle Sub Status Domain Model
    /// </summary>
    public class VehicleSubStatus
    {
        #region Persisted Properties
        
        /// <summary>
        /// Vehicle Sub Status ID
        /// </summary>
        public short VehicleSubStatusId { get; set; }

        /// <summary>
        /// Vehicle Status Id
        /// </summary>
        public short VehicleStatusId { get; set; }

        /// <summary>
        /// Vehicle Sub Status Code
        /// </summary>
        public string VehicleSubStatusCode { get; set; }

        /// <summary>
        /// Vehicle Sub Status Name
        /// </summary>
        public string VehicleSubStatusName { get; set; }

        /// <summary>
        /// Vehicle Sub Status Description
        /// </summary>
        public string VehicleSubStatusDescription { get; set; }

        /// <summary>
        /// Row Version
        /// </summary>
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
        public string RecCreatedBy { get; set; }

        /// <summary>
        /// Record Last Updated Date
        /// </summary>
        public DateTime RecLastUpdatedDt { get; set; }

        /// <summary>
        /// Record Last Updated By
        /// </summary>
        public string RecLastUpdatedBy { get; set; }

        /// <summary>
        /// User Domain Key
        /// </summary>
        public long UserDomainKey { get; set; }
        
        #endregion

        #region Reference Properties

        /// <summary>
        /// Vehicle Status
        /// </summary>
        public virtual VehicleStatus VehicleStatus { get; set; }

        #endregion
    }
}
