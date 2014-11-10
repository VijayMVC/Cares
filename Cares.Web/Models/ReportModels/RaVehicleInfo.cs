using System;

namespace Cares.Web.Models.ReportModels
{
    public class RaVehicleInfo
    {
        public string PlateNumber { get; set; }
        public string VehicleModel { get; set; }
        public string VehicleMake { get; set; }
        public string Color { get; set; }
        public long ModelYear { get; set; }
        public string Category { get; set; }
        public string VehicelOutDateTime { get; set; }
        public string VehicelInDateTime { get; set; }
        public long ChargedDay { get; set; }
        public long ChargedHour { get; set; }
        public long ChargedMint { get; set; }
        public long ConsumedDay { get; set; }
        public long ConsumedHour { get; set; }
        public long ConsumedMint { get; set; }

        public long GraceDay { get; set; }
        public long GraceHour { get; set; }
        public long GraceMint { get; set; }
        public string TariffType { get; set; }
        public double StandardRate { get; set; }
        public double ExcessMileageCharges { get; set; }
        public double DiscoutAmount { get; set; }
        public double DicountPercentage { get; set; }
        public string DicountType { get; set; }
        public double TotalChargeVehicle { get; set; }

    }
}
