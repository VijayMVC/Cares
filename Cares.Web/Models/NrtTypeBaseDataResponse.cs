using System.Collections.Generic;

namespace Cares.Web.Models
{
    /// <summary>
    /// Nrt Type Base Data Response Web model
    /// </summary>
    public class NrtTypeBaseDataResponse
    {
        #region Public
        //Lists of objects
        public IEnumerable<VehicleStatusDropDown> VehicleStatuses { get; set; }
        #endregion
    }
}