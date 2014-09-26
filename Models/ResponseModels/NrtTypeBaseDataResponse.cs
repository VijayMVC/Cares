using Cares.Models.DomainModels;
using System.Collections.Generic;

namespace Cares.Models.ResponseModels
{
    /// <summary>
    /// Nrt Type Base Data Response domain model
    /// </summary>
   public class NrtTypeBaseDataResponse
    {
        /// <summary>
        /// List of Vehicle Statuses
        /// </summary>
       public IEnumerable<VehicleStatus> VehicleStatuses { get; set; }
    }
}
