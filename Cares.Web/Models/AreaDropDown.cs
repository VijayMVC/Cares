namespace Cares.Web.Models
{
    /// <summary>
    /// Area Dropdown Web Api Model
    /// </summary>
    public class AreaDropDown
    {
       /// <summary>
        /// Area ID
        /// </summary>
        public short AreaId { get; set; }
        /// <summary>
        /// Area Code and Name
        /// </summary>
        public string AreaCodeName { get; set; }
        /// <summary>
        /// City ID
        /// </summary>
        public short CityId { get; set; }
    }
}