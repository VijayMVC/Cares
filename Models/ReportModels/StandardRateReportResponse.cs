
using System;

namespace Cares.Models.ReportModels
{
    public class StandardRateReportResponse
    {
        public string StandradRateType { get; set; }
        public string OperationName { get; set; }
        public string TarrifTypeName { get; set; }
        public string HireGroupName { get; set; }
        public string VehicleMake { get; set; }
        public string VehicleModel { get; set; }
        public string VehicleCategory { get; set; }
        public double ModelYear { get; set; }
        public double RevesionNumber { get; set; }
        public DateTime SRStartDate { get; set; }
        public DateTime SREndDate { get; set; }
        public double StandradRate { get; set; }
        public double AllowedMileage { get; set; }
        public double ExcessMileageCharges { get; set; }
    }
}
