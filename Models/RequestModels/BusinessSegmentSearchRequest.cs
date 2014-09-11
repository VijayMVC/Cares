using Cares.Models.Common;

namespace Cares.Models.RequestModels
{
    /// <summary>
    /// Business Segment Search Request
    /// </summary>
    public class BusinessSegmentSearchRequest : GetPagedListRequest
    {
        public string BusinessSegmentFilterText { get; set; }
      
        /// <summary>
        ///  BusinessSegment By Column for sorting
        /// </summary>
        public BusinessSegmentByColumn BusinessSegmentOrderBy
        {

            get
            {
                return (BusinessSegmentByColumn)SortBy;
            }
            set
            {
                SortBy = (short)value;
            }
        }
    }
}
