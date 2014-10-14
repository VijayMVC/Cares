using System.Collections.Generic;
using Cares.Models.DomainModels;

namespace Cares.Models.ResponseModels
{
    /// <summary>
    /// RA Queue Domain base Response
    /// </summary>
    public sealed class RaQueueBaseResponse
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
        ///Operation
        /// </summary>
        public IEnumerable<Operation> Operations { get; set; }

        /// <summary>
        /// Payment Terms
        /// </summary>
        public IEnumerable<PaymentTerm> PaymentTerms { get; set; }
    }
}
