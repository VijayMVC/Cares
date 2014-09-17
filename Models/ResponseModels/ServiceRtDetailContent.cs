using System;

namespace Cares.Models.ResponseModels
{
    /// <summary>
    /// Service Rate Detail Content
    /// </summary>
    public sealed class ServiceRtDetailContent
    {
        /// <summary>
        /// Service Rate ID
        /// </summary>
        public long ServiceRtId { get; set; }
        
        /// <summary>
        ///Service Item Id 
        /// </summary>
        public long ServiceItemId { get; set; }


        /// <summary>
        ///Service Rate Main Id 
        /// </summary>
        public long ServiceRtMainId { get; set; }

        /// <summary>
        /// Service Rate
        /// </summary>
        public double ServiceRate { get; set; }

        /// <summary>
        /// Start Date
        /// </summary>
        public DateTime StartDt { get; set; }

        /// <summary>
        /// Service Item Code
        /// </summary>
        public string ServiceItemCode { get; set; }

        /// <summary>
        /// Sefrvice Item Name
        /// </summary>
        public string ServiceItemName { get; set; }

        /// <summary>
        /// Service Type Code Name
        /// </summary>
        public string ServiceTypeCodeName { get; set; }

        /// <summary>
        /// Revision Number
        /// </summary>
        public long RevisionNumber { get; set; }
        /// <summary>
        /// Is Checked
        /// </summary>
        public bool IsChecked { get; set; }

    }
}
