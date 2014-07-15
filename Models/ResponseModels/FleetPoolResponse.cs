using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.DomainModels;

namespace Models.ResponseModels
{
    /// <summary>
    /// FleetPool Response
    /// </summary>
    public sealed class FleetPoolResponse
    {
        #region Public
        /// <summary>
        /// FleetPools List
        /// </summary>
        public IEnumerable<FleetPool> FleetPools { get; set; }

        /// <summary>
        /// FleetPools Total Count
        /// </summary>
        public int TotalCount { get; set; }
        #endregion

        #region Constructor
        /// <summary>
            /// Constructor
            /// </summary>
            public FleetPoolResponse()
            {
                FleetPools = new List<FleetPool>();
            }
        #endregion
    }
}
