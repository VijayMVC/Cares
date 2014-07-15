using Models.Common;

namespace Models.RequestModels
{

    public class ProductSearchRequest : GetPagedListRequest
    {
        public string CategoryId { get; set; }
        
        /// <summary>
        /// Product Order By
        /// </summary>
        public ProductByColumn ProductOrderBy
        {
            get
            {
                return (ProductByColumn)SortBy;
            }
            set
            {
                SortBy = (short)value;
            }
        }
    }
}
