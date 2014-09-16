using Cares.Models.DomainModels;
using System.Collections.Generic;

namespace Cares.Models.ResponseModels
{
    /// <summary>
    /// Work Place Type BaseData Response
    /// </summary>
    public sealed class WorkPlaceTypeBaseDataResponse
    {
        /// <summary>
        /// List of WorkPlace Types
        /// </summary>
        public IEnumerable<WorkPlaceType> WorkPlaceTypes { get; set; }

    }
}
