
using System;

namespace Cares.Models.ReportModels
{
    /// <summary>
    /// Daily Action Report Response Model
    /// </summary>
    public class DailyActionReportResponse
    {
        #region Public
        public long RaNumber { get; set; }
        public string RAStutus { get; set; }
        public string CustomerName { get; set; }
        public string Nationality { get; set; }
        public string Mobile { get; set; }
        public string OfficePhone { get; set; }
        public string HireGroup { get; set; }
        public string PlateNumber { get; set; }
        public string FleetPool { get; set; }
        public string VehicleMake { get; set; }
        public string VehicleModel { get; set; }
        public long ModelYear { get; set; }
        public long Mileage { get; set; }

        public string VehicleStatus { get; set; }
        public string CurrentLocation { get; set; }

        public double AmountBalance { get; set; }
        public double AmountPaid { get; set; }
        public string InDate { get; set; }
        public string OutDate { get; set; }

        #endregion
    }
}
