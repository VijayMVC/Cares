using Cares.Models.DomainModels;
using Cares.Models.RequestModels;
using System.Linq;

namespace Cares.Web.ModelMappers
{
    /// <summary>
    ///  Document Group Mapper 
    /// </summary>
    public static class DocumentGroupMapper
    {
        /// <summary>
        ///  Create web model [dropdown] from entity 
        /// </summary>
        public static Models.DocumentGroupDropDown CreateFromm(this DocumentGroup source)
        {
            return new Models.DocumentGroupDropDown
            {
                DocumentGroupId = source.DocumentGroupId,
                DocumentGroupCodeName = source.DocumentGroupCode+" - "+source.DocumentGroupName
            };
        }

        /// <summary>
        ///  Create web model from entity
        /// </summary>
        public static Models.DocumentGroup CreateFrom(this DocumentGroup source)
        {
            return new Models.DocumentGroup
            {
                DocumentGroupId = source.DocumentGroupId,
                DocumentGroupCode = source.DocumentGroupCode,
                DocumentGroupName = source.DocumentGroupName,
                DocumentGroupDescription = source.DocumentGroupDescription
            };
        }


        /// <summary>
        /// Create from search response domain model
        /// </summary>
        public static Models.DocumentGroupSearchRequestResponse CreateFrom(this DocumentGroupSearchRequestResponse source)
        {
            return new Models.DocumentGroupSearchRequestResponse
            {
                TotalCount = source.TotalCount,
                DocumentGroups = source.DocumentGroups.Select(documentGroup => documentGroup.CreateFrom())
            };
        }
        
        /// <summary>
        ///  Create domain model from web model
        /// </summary>
        public static DocumentGroup CreateFrom(this Models.DocumentGroup source)
        {
            return new DocumentGroup
            {
                DocumentGroupId = source.DocumentGroupId,
                DocumentGroupCode = source.DocumentGroupCode.Trim(),
                DocumentGroupName = source.DocumentGroupName,
                DocumentGroupDescription = source.DocumentGroupDescription
            };
        }
    }
}