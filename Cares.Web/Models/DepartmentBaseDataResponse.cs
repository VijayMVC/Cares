using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cares.Web.Models
{
    /// <summary>
    /// Department BaseData Response
    /// </summary>
    public class DepartmentBaseDataResponse
    {
        /// <summary>
        /// List of compnies
        /// </summary>
        public IEnumerable<CompanyDropDown> Companies { get; set; }

    }
}