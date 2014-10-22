
namespace Cares.Models.ReportModels
{
    /// <summary>
    /// Daily Action Report Response Model
    /// </summary>
    public class DailyActionReportResponse
    {
        #region Public
        public long Ra { get; set; }
        public string RaStatus { get; set; }
        public string CustomerName { get; set; }
        public string Nationality { get; set; }
        public string MobileNumber { get; set; }
        public string HireGroup { get; set; }
        public string PalteNumber { get; set; }
        public string FleetPool { get; set; }
        public string VehicleMake { get; set; }
        public string VehicleModel { get; set; }
        public long ModelYear { get; set; }
        public long Mileage { get; set; }
        #endregion
    }
}
