using System;
using System.Collections.Generic;

namespace Cares.Models.DomainModels
{
    /// <summary>
    /// Service Type Domain Model
    /// </summary>
    public class ServiceType
    {
        #region Persisted Properties

        /// <summary>
        ///Service Type Id
        /// </summary>
        public short ServiceTypeId { get; set; }

        /// <summary>
        /// Service Type Code
        /// </summary>
        public string ServiceTypeCode { get; set; }

        /// <summary>
        /// Service Type Name
        /// </summary>
        public string ServiceTypeName { get; set; }

        /// <summary>
        /// Service Type Description
        /// </summary>
        public string ServiceTypeDescription { get; set; }

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
        /// Row Vesion
        /// </summary>
        public long RowVersion { get; set; }

        /// <summary>
        /// User Domain Key
        /// </summary>
        public long UserDomainKey { get; set; }

        #endregion

        #region Reference Properties

        /// <summary>
        /// Service Items
        /// </summary>
        public virtual ICollection<ServiceItem> ServiceItems { get; set; }

        #endregion
    }
}
