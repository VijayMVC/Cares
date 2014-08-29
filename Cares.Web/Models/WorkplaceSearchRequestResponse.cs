using Cares.Models.DomainModels;
using System.Collections.Generic;

namespace Cares.Web.Models
{
    public class WorkplaceSearchRequestResponse
    {
        #region Public
        /// <summary>
        /// Workplaces Data
        /// </summary>
        public IEnumerable<WorkPlace> WorkPlaces { get; set; }

        /// <summary>
        /// Workplaces Total Count
        /// </summary>
        public int TotalCount { get; set; }
        #endregion
    }
}