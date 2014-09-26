using Cares.Web.Models;
using DomainModels = Cares.Models.DomainModels;

namespace Cares.Web.ModelMappers
{
    /// <summary>
    /// RaCustomer Document Mapper
    /// </summary>
    public static class RaCustomerDocumentMapper
    {
        #region Public

        /// <summary>
        ///  Create web model from entity
        /// </summary>
        public static RaCustomerDocument CreateFrom(this DomainModels.RaCustomerDocument source)
        {
            return new RaCustomerDocument
            {
                RaCustomerDocumentId = source.RaCustomerDocumentId,
                RaMainId = source.RaMainId,
                DocumentCode = source.Document.DocumentCode,
                DocumentId = source.DocumentId,
                DocumentName = source.Document.DocumentName,
                RaCustomerDocumentDescription = source.RaCustomerDocumentDescription
            };
           
        }

        /// <summary>
        ///  Create web model from entity
        /// </summary>
        public static DomainModels.RaCustomerDocument CreateFrom(this RaCustomerDocument source)
        {
            return new DomainModels.RaCustomerDocument
            {
                RaCustomerDocumentId = source.RaCustomerDocumentId,
                RaMainId = source.RaMainId,
                DocumentId = source.DocumentId
            };

        }

        #endregion

    }
}
