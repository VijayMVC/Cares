using System;

namespace Cares.Models.ReportModels
{
    public class RaVehicleInfo
    {
        #region Public
        public long RentalAgreementId { get; set; }
        public string Status { get; set; }
        public long RaOpenLocatoin { get; set; }
        public DateTime StartDateTime { get; set; }
        public DateTime ReturnDateTime { get; set; }
        public long RaCloseLocation { get; set; }
        public string PlateNumber { get; set; }
        public string VehicleModel { get; set; }
        public string VehicleMake { get; set; }
        public string Color { get; set; }
        public long ModelYear { get; set; }
        public string Category { get; set; }

        public DateTime VehicelOutDateTime { get; set; }
        public DateTime VehicelInDateTime { get; set; }

        public long ChargedDay { get; set; }
        public long ChargedHour { get; set; }
        public long ChargedMint { get; set; }
        public long GraceDay { get; set; }
        public long GraceHour { get; set; }
        public long GraceMint { get; set; }

        #endregion
    }
}
