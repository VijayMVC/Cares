﻿
namespace Cares.Web.Models
{
    /// <summary>
    /// Service Item Web model
    /// </summary>
    public class ServiceItem
    {
       
        /// <summary>
        /// Service Type ID
        /// </summary>
        public short ServiceTypeId { get; set; }

        /// <summary>
        /// Service Type Name
        /// </summary>
        public string ServiceTypeName { get; set; }

        /// <summary>
        /// Service Type Code
        /// </summary>
        public string ServiceTypeCode { get; set; }

        /// <summary>
        ///Service Item Id
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
        /// Service Item Description
        /// </summary>
        public string ServiceItemDescription { get; set; }
    }
}