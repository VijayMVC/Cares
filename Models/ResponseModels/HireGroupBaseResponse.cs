using System.Collections.Generic;
using Cares.Models.DomainModels;

namespace Cares.Models.ResponseModels
{
    /// <summary>
    /// Hire Group base Response
    /// </summary>
    public sealed class HireGroupBaseResponse
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
