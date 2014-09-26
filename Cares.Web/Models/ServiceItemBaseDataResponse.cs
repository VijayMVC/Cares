using System.Collections.Generic;

namespace Cares.Web.Models
{
    /// <summary>
    /// Service Item Base Data Response Web model
    /// </summary>
    public class ServiceItemBaseDataResponse
    {
        #region Public
        /// <summary>
        /// List of Service Types
        /// </summary>
        public IEnumerable<ServiceTypeDropDown> ServiceTypes { get; set; }
        #endregion
    }
}