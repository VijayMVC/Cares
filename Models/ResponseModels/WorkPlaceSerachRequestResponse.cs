using Cares.Models.DomainModels;
using System.Collections.Generic;

namespace Cares.Models.ResponseModels
{
    /// <summary>
    /// Work Place Search Request Response
    /// </summary>
    public class WorkPlaceSerachRequestResponse
    {
        #region Public
        /// <summary>
        /// WorkPlace List
        /// </summary>
        public IEnumerable<WorkPlace> WorkPlaces { get; set; }

        /// <summary>
        /// Total Count of WorkPlace
        /// </summary>
        public int TotalCount { get; set; }
        #endregion
    }
}
