using System;

namespace Cares.Models.ReportModels
{
    public class RaCustomerInfo
    {
        public string RenterName { get; set; }
        public string Driver { get; set; }

        public string ContactPerson { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string Telephone { get; set; }
        public string Region { get; set; }
        public string StreetAddress { get; set; }

        public string Identification { get; set; }
        public string LicenceNumber { get; set; }
        public string PassportNumber { get; set; }
        public string DOB { get; set; }
        public string NID_DOE { get; set; }
        public DateTime? LicenceDOE { get; set; }
        public DateTime PassportDOE { get; set; }

        public string TariffType { get; set; }
        public double StandardRate { get; set; }
        public double? ExcessMileageCharges { get; set; }
        public double? VehicleCharges { get; set; }
        public double? DicountPercentage { get; set; }
    }
}
