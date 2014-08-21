using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cares.Web.Models
{
    public class CompanyBaseDataResponse
    {
        #region Public
       
        public IEnumerable<OrgGroupDropDown> OrgGroups { get; set; }

      
        public IEnumerable<BusinessSegmentDropDown> BusinessSegments { get; set; }


        public IEnumerable<CompanyDropDown> ParrentCompanies { get; set; }

        #endregion
    }
}