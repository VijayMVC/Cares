using System.Collections.Generic;

namespace Cares.Web.Models
{
    /// <summary>
    /// Ra Queue Base Web Response
    /// </summary>
    public class RaQueueBaseResponse
    {
        /// <summary>
        /// Operation Work Places
        /// </summary>
        public IEnumerable<OperationsWorkPlaceDropDown> OperationWorkPlaces { get; set; }

        /// <summary>
        /// Operation
        /// </summary>
        public IEnumerable<OperationDropDown> Operations { get; set; }

        /// <summary>
        /// Ra Status
        /// </summary>
        public IEnumerable<RaStatusDropDown> RaStatuses { get; set; }

           /// <summary>
        /// Payment Term
        /// </summary>
        public IEnumerable<PaymentTermDropDown> PaymentTerms { get; set; }
    }
}