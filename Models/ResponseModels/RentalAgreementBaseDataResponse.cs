using System.Collections.Generic;
using Cares.Models.DomainModels;

namespace Cares.Models.ResponseModels
{
    /// <summary>
    /// Vehicle Base Data Response
    /// </summary>
    public sealed class RentalAgreementBaseDataResponse
    {
        #region Constructors
        
        /// <summary>
        /// Constructor
        /// </summary>
        public RentalAgreementBaseDataResponse()
        {
            PaymentTerms = new List<PaymentTerm>();
            OperationsWorkPlaces = new List<OperationsWorkPlace>();
            Operations = new List<Operation>();
            VehicleStatuses = new List<VehicleStatus>();
            AllocationStatuses = new List<AllocationStatus>();
            PaymentModes = new List<PaymentMode>();
        }

        #endregion

        #region Public
        
        /// <summary>
        /// PaymentTerms
        /// </summary>
        public IEnumerable<PaymentTerm> PaymentTerms { get; set; }
        
        /// <summary>
        /// Operations WorkPlaces 
        /// </summary>
        public IEnumerable<OperationsWorkPlace> OperationsWorkPlaces { get; set; }
        
        /// <summary>
        /// Operations 
        /// </summary>
        public IEnumerable<Operation> Operations { get; set; }

        /// <summary>
        /// Vehicle Statuses 
        /// </summary>
        public IEnumerable<VehicleStatus> VehicleStatuses { get; set; }

        /// <summary>
        /// Allocation Statuses 
        /// </summary>
        public IEnumerable<AllocationStatus> AllocationStatuses { get; set; }

        /// <summary>
        /// Payment Modes
        /// </summary>
        public IEnumerable<PaymentMode> PaymentModes { get; set; }

        #endregion
    }
}
