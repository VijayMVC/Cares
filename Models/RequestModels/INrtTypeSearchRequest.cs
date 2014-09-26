using Cares.Models.Common;

namespace Cares.Models.RequestModels
{
    /// <summary>
    /// Nrt Type Search Request model
    /// </summary>
    public class NrtTypeSearchRequest : GetPagedListRequest
    {
        /// <summary>
        /// NrtType Code and name search
        /// </summary>
        public string NrtTypeFilterText { get; set; }


        /// <summary>
        /// Vehhicle Status Id
        /// </summary>
        public int? VehhicleStatusId { get; set; }

        /// <summary>
        /// Nrt Type for sorting
        /// </summary>
        public NrtTypeByColumn NrtTypeOrderBy
        {
            get
            {
                return (NrtTypeByColumn)SortBy;
            }
            set
            {
                SortBy = (short)value;
            }
        }
    }
}
