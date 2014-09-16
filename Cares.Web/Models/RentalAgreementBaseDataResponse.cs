using System.Collections.Generic;

namespace Cares.Web.Models
{
    /// <summary>
    /// Vehicle Base Data Response Web Models
    /// </summary>
    public class RentalAgreementBaseDataResponse
    {
     
        #region Public

        /// <summary>
        /// PaymentTerms
        /// </summary>
        public IEnumerable<PaymentTermDropDown> PaymentTerms { get; set; }

        /// <summary>
        /// Operations WorkPlaces 
        /// </summary>
        public IEnumerable<OperationsWorkPlace> OperationsWorkPlaces { get; set; }

        /// <summary>
        /// Operations 
        /// </summary>
        public IEnumerable<OperationDropDown> Operations { get; set; }

        #endregion

    }
}