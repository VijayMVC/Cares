using System.Collections.Generic;

namespace Cares.Web.Models
{
    /// <summary>
    /// Nrt Queue Base Web Response
    /// </summary>
    public sealed class NrtQueueBaseResponse
    {
        /// <summary>
        /// Operation Work Places
        /// </summary>
        public IEnumerable<OperationsWorkPlaceDropDown> OperationWorkPlaces { get; set; }

        /// <summary>
        /// Ra Status
        /// </summary>
        public IEnumerable<RaStatusDropDown> RaStatuses { get; set; }

        /// <summary>
        ///Nrt Type
        /// </summary>
        public IEnumerable<NrtTypeDropDown> NrtTypes { get; set; }
    }
}