using System;
using System.Collections.Generic;

namespace Cares.Models.DomainModels
{
    /// <summary>
    /// Nrt Type Model
    /// </summary>
    public class NrtType
    {
        #region Persisted Properties
        
        /// <summary>
        /// Nrt Type ID
        /// </summary>
        public long NrtTypeId { get; set; }

        /// <summary>
        /// Nrt Type Code
        /// </summary>
        public string NrtTypeCode { get; set; }

        /// <summary>
        /// Nrt Type Name
        /// </summary>
        public string NrtTypeName { get; set; }

        /// <summary>
        /// Nrt Type Description
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Nrt Type Key
        /// </summary>
        public int? NrtTypeKey { get; set; }

        /// <summary>
        /// Standard Lifetime
        /// </summary>
        public double? StandardLifeTime { get; set; }

        /// <summary>
        /// Vehicle Status ID
        /// </summary>
        public short? VehicleStatusId { get; set; }

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
        /// Nrt Mains
        /// </summary>
        public virtual ICollection<NrtMain> NrtMains { get; set; }

        /// <summary>
        /// Vehicle Status
        /// </summary>
        public virtual VehicleStatus VehicleStatus { get; set; }

        #endregion
    }
}
