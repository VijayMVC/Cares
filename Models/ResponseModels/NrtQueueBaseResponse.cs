using System.Collections.Generic;
using Cares.Models.DomainModels;

namespace Cares.Models.ResponseModels
{
    /// <summary>
    /// NRT Queue Base Domain Response
    /// </summary>
    public sealed class NrtQueueBaseResponse
    {
        /// <summary>
        /// Operation Work Places
        /// </summary>
        public IEnumerable<OperationsWorkPlace> OperationWorkPlaces { get; set; }

        /// <summary>
        /// Ra Status
        /// </summary>
        public IEnumerable<RaStatus> RaStatuses { get; set; }

        /// <summary>
        ///Nrt Type
        /// </summary>
        public IEnumerable<NrtType> NrtTypes { get; set; }
    }
}
