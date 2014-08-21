using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cares.Models.DomainModels;

namespace Cares.Models.ResponseModels
{
    public class CompanySearchRequestResponse
    {
        #region Public
     
        public IEnumerable<Company> Companies { get; set; }

      
        public int TotalCount { get; set; }
        #endregion
    }
}
