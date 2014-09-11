

namespace Cares.Web.Models
{
    /// <summary>
    /// BusinessSegment web model
    /// </summary>
    public class BusinessSegment
    {
        /// <summary>
        /// Business Segment ID
        /// </summary>
        public short BusinessSegmentId { get; set; }

        /// <summary>
        /// Business Segment Code
        /// </summary>
        public string BusinessSegmentCode { get; set; }

        /// <summary>
        /// Business Segment Name
        /// </summary>
        public string BusinessSegmentName { get; set; }

        /// <summary>
        /// Business Segment Description
        /// </summary>
        public string BusinessSegmentDescription { get; set; }
    }
}