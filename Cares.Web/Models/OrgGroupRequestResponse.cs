using System.Collections.Generic;
namespace Cares.Web.Models
{
    public sealed class OrgGroupRequestResponse
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