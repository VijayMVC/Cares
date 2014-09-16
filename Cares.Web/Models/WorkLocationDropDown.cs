
namespace Cares.Web.Models
{
    /// <summary>
    /// Work Location DropDown
    /// </summary>
    public class WorkLocationDropDown
    {

        #region Public Properties
        /// <summary>
        ///  Work Location Type ID
        /// </summary>
        public long WorkLocationId { get; set; }


        /// <summary>
        /// Company Id
        /// </summary>
        public long CompanyId { get; set; }

        /// <summary>
        /// Work Location Code  Name
        /// </summary>
        public string WorkLocationCodeName { get; set; }
        #endregion
    }
}