using System;

namespace Cares.Web.Models
{
    /// <summary>
    /// Ra Main For Ra Queue
    /// </summary>
    public sealed class RaMainForRaQueue
    {
        /// <summary>
        /// Ra Main ID
        /// </summary>
        public long RaMainId { get; set; }

        /// <summary>
        /// Open Location
        /// </summary>
        public string OpenLocation { get; set; }

        /// <summary>
        /// Close Location
        /// </summary>
        public string CloseLocation { get; set; }

        /// <summary>
        /// Ra Status Code
        /// </summary>
        public string RaStatusCode { get; set; }

        /// <summary>
        /// Operation Code
        /// </summary>
        public string OperationCode { get; set; }

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