using Cares.Models.Common;

namespace Cares.Models.RequestModels
{
    /// <summary>
    /// Document Search Request web model
    /// </summary>
    public class DocumentSearchRequest : GetPagedListRequest
    {
        /// <summary>
        /// Document code and name for search
        /// </summary>
        public string DocumentCodeNameText { get; set; }

        /// <summary>
        /// Document Group ID used for search
        /// </summary>
        public int? DocumentGroypId { get; set; }
     
        /// <summary>
        ///  Document By Column for sorting
        /// </summary>
        public DocumentByColumn DocumentOrderBy
        {

            get
            {
                return (DocumentByColumn)SortBy;
            }
            set
            {
                SortBy = (short)value;
            }
        }
    }
}
