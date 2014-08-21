using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cares.Web.Models
{
    /// <summary>
    /// Company Search Response
    /// </summary>
    public class CompanySearchRequestResponse
    {
        public IEnumerable<Company> Companies { get; set; }

        public int TotalCount { get; set; }
    }
}