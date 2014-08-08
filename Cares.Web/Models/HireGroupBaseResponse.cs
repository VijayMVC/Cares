using System.Collections.Generic;

namespace Cares.Web.Models
{
    /// <summary>
    /// Hire Group Web Base Response
    /// </summary>
    public class HireGroupBaseResponse
    {
        #region Constructors
        /// <summary>
        /// Constructor
        /// </summary>
        public HireGroupBaseResponse()
        {
            Companies = new List<Company>();
            ParentHireGroups = new List<HireGroup>();
        }
        #endregion

        #region Public
        /// <summary>
        /// Companies
        /// </summary>
        public IEnumerable<Company> Companies { get; set; }
        /// <summary>
        /// Hire Group 
        /// </summary>
        public IEnumerable<HireGroup> ParentHireGroups { get; set; }
        #endregion
    }
}