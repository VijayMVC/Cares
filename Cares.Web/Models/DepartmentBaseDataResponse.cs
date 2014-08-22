using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cares.Web.Models
{
    public class DepartmentBaseDataResponse
    {
        public IEnumerable<CompanyDropDown> Companies { get; set; }

    }
}