using System;

namespace Cares.Models.DomainModels
{
    /// <summary>
    /// domain model
    /// </summary>
    public class LicenseDetailsDefault
    {
        #region Public
        /// <summary>
        /// License Details Default Id
        /// </summary>
        public Int32 LicenseDetailsDefaultId { get; set; }

        /// <summary>
        /// License Type Id
        /// </summary>
        public Int16 LicenseTypeId { get; set; }
        /// <summary>
        /// Rental agreements per month
        /// </summary>
        public Int16 RaPerMonth { get; set; }
        /// <summary>
        /// number of Employee 
        /// </summary>
        public Int16 Employee { get; set; }
        /// <summary>
        /// Number of branches
        /// </summary>
        public Int16 Branches { get; set; }
        /// <summary>
        /// Number of Fleet Pool
        /// </summary>
        public Int16 FleetPools { get; set; }
        /// <summary>
        /// Number of Vehicles
        /// </summary>
        public Int16 Vehicles { get; set; }
       

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
        #region Navigational Properties
        /// <summary>
        /// Cares License Type
        /// </summary>
        public CaresLicenseType CaresLicenseType { get; set; }
        #endregion
    }
}
