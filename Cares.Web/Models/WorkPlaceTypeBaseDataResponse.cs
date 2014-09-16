using Cares.Models.DomainModels;
using System.Collections.Generic;

namespace Cares.Web.Models
{
    /// <summary>
    /// Work Place Type Base web Data Response
    /// </summary>
    public class WorkPlaceTypeBaseDataResponse
    {
        /// <summary>
        /// List of WorkPlace Types
        /// </summary>
        public IEnumerable<WorkPlaceType> WorkPlaceTypes { get; set; }
    }
}