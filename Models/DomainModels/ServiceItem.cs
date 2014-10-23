using System;
using System.Collections.Generic;

namespace Cares.Models.DomainModels
{
    /// <summary>
    /// Service Item Domain Models
    /// </summary>
    public class ServiceItem
    {
        #region Persisted Properties

        /// <summary>
        ///Service Item Id
        /// </summary>
        public long ServiceItemId { get; set; }

        /// <summary>
        /// Service Type ID
        /// </summary>
        public short ServiceTypeId { get; set; }

        /// <summary>
        /// Service Item Code
        /// </summary>
        public string ServiceItemCode { get; set; }

        /// <summary>
        /// Service Item Name
        /// </summary>
        public string ServiceItemName { get; set; }

        /// <summary>
        /// Service Item Description
        /// </summary>
        public string ServiceItemDescription { get; set; }

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
        /// Service Type
        /// </summary>
        public virtual ServiceType ServiceType { get; set; }

        /// <summary>
        /// Service Rts
        /// </summary>
        public virtual ICollection<ServiceRt> ServiceRts { get; set; }

        /// <summary>
        /// Ra Service Items
        /// </summary>
        public virtual ICollection<RaServiceItem> RaServiceItems { get; set; }

        /// <summary>
        /// Booking Service Items
        /// </summary>
        public virtual ICollection<BookingService> BookingServices { get; set; }

        #endregion
    }
}
