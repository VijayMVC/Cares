using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cares.Models.Common;

namespace Cares.Models.RequestModels
{
    /// <summary>
    /// Company Search Request
    /// </summary>
    public class CompanySearchRequest : GetPagedListRequest
    {
        public string CompanyCodeText { get; set; }
        public string CompanyNameText { get; set; }
        public int? OrganizationGroupId  { get; set; }
        public int? BusinessSegmentId  { get; set; }
        public CompanyByColumn CompanyOrderBy
        {
            
            get
            {
                return (CompanyByColumn)SortBy;
            }
            set
            {
                SortBy = (short)value;
            }
        }
    }
}
