using System.Collections.Generic;

namespace Cares.Web.Models
{
    /// <summary>
    /// Maintenance Type Base Data Response Web model
    /// </summary>
    public class MaintenanceTypeBaseDataResponse
    {
        #region Public

       /// <summary>
        /// List of Maintenance Type Groups
        /// </summary>
        public IEnumerable<MaintenanceTypeGroupDropDown> MaintenanceTypeGroups { get; set; }
    
        #endregion
    }
}