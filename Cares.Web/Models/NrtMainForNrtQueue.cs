using System;

namespace Cares.Web.Models
{
    /// <summary>
    /// NRT Main For NRT Queue Web Model
    /// </summary>
    public sealed class NrtMainForNrtQueue
    {
        /// <summary>
        /// NRT Main ID
        /// </summary>
        public long NrtMainId { get; set; }

        /// <summary>
        /// Open Location
        /// </summary>
        public string OpenLocation { get; set; }

        /// <summary>
        /// Close Location
        /// </summary>
        public string CloseLocation { get; set; }

        /// <summary>
        /// NRT Status Code
        /// </summary>
        public string NrtStatusCode { get; set; }

        /// <summary>
        /// NRT Type Code
        /// </summary>
        public string NrtTypeCode { get; set; }

        /// <summary>
        /// Start Date
        /// </summary>
        public DateTime StartDtTime { get; set; }

        /// <summary>
        /// End Date
        /// </summary>
        public DateTime EndDtTime { get; set; }
    }
}