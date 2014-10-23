using Cares.Models.DomainModels;
using Cares.Models.ResponseModels;
using System.Linq;

namespace Cares.Web.ModelMappers
{
    /// <summary>
    /// Document Mapper
    /// </summary>
    public static class DocumentMapper
    {
        /// <summary>
        ///  Create web model from entity
        /// </summary>
        public static Models.Document CreateFrom(this Document source)
        {
            return new Models.Document
            {
                DocumentId = source.DocumentId,
                DocumentCode = source.DocumentCode,
                DocumentName = source.DocumentName,
                DocumentDescription = source.DocumentDescription,
                DocumentGroupId = source.DocumentGroupId,
                DocumentGroupName = source.DocumentGroup.DocumentGroupName

            };
        }

        /// <summary>
        /// create Base Data Response from doain model
        /// </summary>
        public static Models.DocumentBaseDataResponse CreateFrom(this DocumentBaseDataResponse source)
        {
            return new Models.DocumentBaseDataResponse
            {
                DocumentGroupDropDown = source.DocumentGroups.Select(docGroup => docGroup.CreateFromm())
            };
        }

        /// <summary>
        /// Create from search response domain model
        /// </summary>
        public static Models.DocumentSearchRequestResponse CreateFrom(this DocumentSearchRequestResponse source)
        {
            return new Models.DocumentSearchRequestResponse
            {
                TotalCount = source.TotalCount,
                Documents = source.Documents.Select(city => city.CreateFrom())
            };
        }

        /// <summary>
        ///  Create domain model from web model
        /// </summary>
        public static Document CreateFrom(this Models.Document source)
        {
            return new Document
            {
                DocumentId = source.DocumentId,
                DocumentCode = source.DocumentCode.Trim(),
                DocumentName = source.DocumentName,
                DocumentDescription = source.DocumentDescription,
                DocumentGroupId = source.DocumentGroupId,
            };
        }
    }
}