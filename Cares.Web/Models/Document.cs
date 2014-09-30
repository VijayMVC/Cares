
namespace Cares.Web.Models
{
    /// <summary>
    /// web model
    /// </summary>
    public class Document
    {
        /// <summary>
        /// Document ID
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

        /// <summary>
        /// Document Description
        /// </summary>
        public string DocumentDescription { get; set; }

        /// <summary>
        /// Document Group ID
        /// </summary>
        public int DocumentGroupId { get; set; }

        /// <summary>
        /// Document Group Name
        /// </summary>
        public string DocumentGroupName { get; set; }
    }
}