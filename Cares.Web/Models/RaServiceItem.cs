using System;

namespace Cares.Web.Models
{
    /// <summary>
    /// Ra ServiceItem Web Model
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
        /// Service Item Code
        /// </summary>
        public string ServiceItemCode { get; set; }

        /// <summary>
        /// Service Item Name
        /// </summary>
        public string ServiceItemName { get; set; }

        /// <summary>
        /// Service Type Code
        /// </summary>
        public string ServiceTypeCode { get; set; }

        /// <summary>
        /// Service Type Name
        /// </summary>
        public string ServiceTypeName { get; set; }

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
        
        #endregion

    }
}