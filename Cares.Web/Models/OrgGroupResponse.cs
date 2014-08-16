using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cares.Web.Models
{
    public sealed class OrgGroupResponse
    {
        #region Public
        /// <summary>
        /// FleetPools List
        /// </summary>
        public IEnumerable<OrgGroup> OrgGroups { get; set; }

        /// <summary>
        /// FleetPools Total Count
        /// </summary>
        public int TotalCount { get; set; }
        #endregion
    }
}