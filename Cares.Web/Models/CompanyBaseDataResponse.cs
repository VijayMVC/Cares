using System.Collections.Generic;

namespace Cares.Web.Models
{
    /// <summary>
    /// company base data response
    /// </summary>
    public class CompanyBaseDataResponse
    {
        #region Public
        //Lists of objects
        public IEnumerable<OrgGroupDropDown> OrgGroups { get; set; }

        public IEnumerable<BusinessSegmentDropDown> BusinessSegments { get; set; }

        public IEnumerable<CompanyDropDown> ParrentCompanies { get; set; }

        #endregion
    }
}