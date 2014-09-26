namespace Cares.Web.Models
{
    /// <summary>
    /// RA Customer Document Model
    /// </summary>
    public class RaCustomerDocument
    {
        #region Persisted Properties

        /// <summary>
        /// RaAdditionalCharge ID
        /// </summary>
        public long RaCustomerDocumentId { get; set; }

        /// <summary>
        /// Ra Customer Document Description
        /// </summary>
        public string RaCustomerDocumentDescription { get; set; }

        /// <summary>
        /// RA Main Id
        /// </summary>
        public long RaMainId { get; set; }

        /// <summary>
        /// Document Id
        /// </summary>
        public int DocumentId { get; set; }

        /// <summary>
        /// Document Code
        /// </summary>
        public string DocumentCode { get; set; }

        /// <summary>
        /// Document Name
        /// </summary>
        public string DocumentName { get; set; }
        
        #endregion

    }
}