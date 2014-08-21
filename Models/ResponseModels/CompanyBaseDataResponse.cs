using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cares.Models.DomainModels;

namespace Cares.Models.ResponseModels
{
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
