using System;
using System.Collections.Generic;

namespace Cares.Models.DomainModels
{
    /// <summary>
    /// Measurement Unit Domain Model
    /// </summary>
    public class MeasurementUnit
    {
        #region Persisted Properties
        /// <summary>
        /// Measurement Unit ID
        /// </summary>
        public short MeasurementUnitId { get; set; }
        /// <summary>
        /// Measurement Unit Code
        /// </summary>
        public string MeasurementUnitCode { get; set; }
        /// <summary>
        /// Measurement Unit Name
        /// </summary>
        public string MeasurementUnitName { get; set; }
        /// <summary>
        /// Measurement Unit Description
        /// </summary>
        public string MeasurementUnitDescription { get; set; }
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

        /// <summary>
        /// Row Version
        /// </summary>
        public long RowVersion { get; set; }

        /// <summary>
        /// Measurement Unit Key
        /// </summary>
        public short MeasurementUnitKey { get; set; }

        #endregion

        #region Reference Properties

        /// <summary>
        /// tariff Types that use this Unit
        /// </summary>
        public virtual ICollection<TariffType> TariffTypes { get; set; } 

        #endregion
    }
}
