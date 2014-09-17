namespace Cares.Web.Models
{
    /// <summary>
    /// Occupation Type Dropdown Web Api Model
    /// </summary>
    public class OccupationTypeDropDown
    {
        #region Public Properties
        /// <summary>
        /// Occupation Type ID
        /// </summary>
        public short OccupationTypeId { get; set; }
        /// <summary>
        /// Occupation Code and Name
        /// </summary>        
        public string OccupationTypeCodeName { get; set; }
        #endregion
    }
}