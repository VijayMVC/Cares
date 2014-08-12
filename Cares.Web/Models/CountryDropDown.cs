namespace Cares.Web.Models
{
    /// <summary>
    /// Country Dropdown Web Api Model
    /// </summary>
    public class CountryDropDown
    {
        #region Persisted Properties
        /// <summary>
        /// Country ID
        /// </summary>
        public short CountryId { get; set; }
        /// <summary>
        /// Country Code and  Name
        /// </summary>
        public string CountryCodeName { get; set; }
        #endregion
    }
}