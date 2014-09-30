
namespace Cares.Web.Models
{
    /// <summary>
    /// drop down model for document group
    /// </summary>
    public class DocumentGroupDropDown
    {
        #region Persisted Properties
        /// <summary>
        /// Document Group ID
        /// </summary>
        public int DocumentGroupId { get; set; }

        /// <summary>
        /// Document Group Code and  Name
        /// </summary>
        public string DocumentGroupCodeName { get; set; }
        #endregion
    }
}