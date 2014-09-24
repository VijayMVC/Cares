using System;

namespace Cares.Models.DomainModels
{
    /// <summary>
    /// Ra ServiceItem Domain Models
    /// </summary>
    public class RaServiceItem
    {
        #region Persisted Properties

        /// <summary>
        ///Ra ServiceItem Id
        /// </summary>
        public long RaServiceItemId { get; set; }

        /// <summary>
        /// Service Item ID
        /// </summary>
        public long ServiceItemId { get; set; }

        /// <summary>
        /// RA Main ID
        /// </summary>
        public long RaMainId { get; set; }
        
        /// <summary>
        /// Ra ServiceItem Description
        /// </summary>
        public string RaServiceItemDescription { get; set; }

        /// <summary>
        /// Quantity
        /// </summary>
        public int Quantity { get; set; }

        /// <summary>
        /// Start Date
        /// </summary>
        public DateTime StartDtTime { get; set; }

        /// <summary>
        /// End Date
        /// </summary>
        public DateTime EndDtTime { get; set; }

        /// <summary>
        /// Service Rate
        /// </summary>
        public double ServiceRate { get; set; }

        /// <summary>
        /// Service Charge
        /// </summary>
        public double ServiceCharge { get; set; }

        /// <summary>
        /// Charged Day
        /// </summary>
        public int ChargedDay { get; set; }

        /// <summary>
        /// Charged Hour
        /// </summary>
        public int ChargedHour { get; set; }

        /// <summary>
        /// Charged Minute
        /// </summary>
        public int ChargedMinute { get; set; }

        /// <summary>
        /// Tariff Type
        /// </summary>
        public string TariffType { get; set; }

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
        /// Service Item
        /// </summary>
        public virtual ServiceItem ServiceItem { get; set; }

        /// <summary>
        /// Ra Main
        /// </summary>
        public virtual RaMain RaMain { get; set; }

        #endregion
    }
}
