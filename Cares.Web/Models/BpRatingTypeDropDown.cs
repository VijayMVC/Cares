namespace Cares.Web.Models
{
    /// <summary>
    /// Business Partner Rating Type Dropdown Web Api model
    /// </summary>
    public class BpRatingTypeDropDown
    {
        #region Public Properties
        /// <summary>
        /// Business Partner Rating Type ID
        /// </summary>
        public short BpRatingTypeId { get; set; }
        /// <summary>
        /// Business Partner Rating Type Custom ID 
        /// </summary>
        public string BpRatingTypeCustomId { get; set; }
        /// <summary>
        /// Business Partner Rating Type Code and Name
        /// </summary>
        public string BpRatingTypeCodeName { get; set; }
        #endregion
    }
}
