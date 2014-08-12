namespace Cares.Web.Models
{
    /// <summary>
    /// Business Segment Dropdown Web Api Model
    /// </summary>
    public class BusinessSegmentDropDown
    {
        /// <summary>
        /// Business Segment ID
        /// </summary>
        public short BusinessSegmentId { get; set; }
        /// <summary>
        /// Business Segment Code and Name
        /// </summary>
        public string BusinessSegmentCodeName { get; set; }
    }
}