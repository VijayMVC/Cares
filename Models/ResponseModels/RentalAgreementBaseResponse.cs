using System.Collections.Generic;
using Models.DomainModels;

namespace Models.ResponseModels
{
    /// <summary>
    /// Rental Agreement Base Response
    /// </summary>
    public sealed class RentalAgreementBaseResponse
    {
        #region Constructors
        /// <summary>
        /// Constructor
        /// </summary>
        public RentalAgreementBaseResponse()
        {
            PaymentTerms = new List<PaymentTerm>();
            Operations = new List<Operation>();
        }
        #endregion
        #region Public
        
        /// <summary>
        /// Measurement Unit 
        /// </summary>
        public IEnumerable<PaymentTerm> PaymentTerms { get; set; }
       
        /// <summary>
        /// Operations 
        /// </summary>
        public IEnumerable<Operation> Operations { get; set; }

        #endregion
    }
}
