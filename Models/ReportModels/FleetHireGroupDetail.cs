using System;

namespace Cares.Models.ReportModels
{
    /// <summary>
    /// Fleet Report Model For Reporting being used in DataSet
    /// </summary>
    public class RptFleetHireGroupDetail
    {
        
        #region Public
        
        public string HireGroupName { get; set; }
        public string ParentHireGroupName { get; set; }
        public string PlateNumber { get; set; }

        public string FleetPoolName { get; set; }
        public string VehicleMakeName { get; set; }
        public string VehicleModelName { get; set; }

        public string VehicleCategoryName { get; set; }
        public short ModelYear { get; set; }
        public string Color { get; set; }
        public long CurrentOdometer { get; set; }
        public string VehicleStatusName { get; set; }
        public int VehicleAge { get; set; }
        public string Location { get; set; }
        #endregion
    }
}
