using Cares.Models.DomainModels;
using System.Collections.Generic;

namespace Cares.Models.ResponseModels
{
    /// <summary>
    /// Company Base data response
    /// </summary>
    public sealed class CompanyBaseDataResponse
    {
        /// <summary>
        /// List of OrgGroups
        /// </summary>
        public IEnumerable<OrgGroup> OrgGroups { get; set; }

        /// <summary>
        /// List of BusinessSegments
        /// </summary>
       public IEnumerable<BusinessSegment> BusinessSegments { get; set; }

        /// <summary>
        ///List of  ParrentCompanies
        /// </summary>
        public IEnumerable<Company> ParrentCompanies { get; set; }

    }
}
