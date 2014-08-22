using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cares.Models.DomainModels;

namespace Cares.Models.ResponseModels
{
   public sealed class OperationSearchResponse
    {
        #region Public
        /// <summary>
        ///
        /// </summary>
        public IEnumerable<Operation> Operations { get; set; }

        /// <summary>
        /// FleetPools Total Count
        /// </summary>
        public int TotalCount { get; set; }
        #endregion
    }
}
