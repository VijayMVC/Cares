using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cares.Models.Common;

namespace Cares.Models.RequestModels
{
    public class OperationSearchRequest : GetPagedListRequest
    {

        public string OperationCodeText { get; set; }

        public string OperationNameText { get; set; }

        public string DepartmentTypeText { get; set; }
        public int? DepartmentId { get; set; }

        public int? CompanyId { get; set; }

      
        public OperationByColumn OperationOrderBy
        {
            get
            {
                return (OperationByColumn)SortBy;
            }
            set
            {
                SortBy = (short)value;
            }
        }
    }
}
