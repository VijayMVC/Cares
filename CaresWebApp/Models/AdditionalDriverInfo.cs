using System;

namespace Cares.WebApp.Models
{
    public class AdditionalDriverInfo
    {
        public string Name { get; set; }
        public double Rate { get; set; }
        public string LicenseNumber { get; set; }
        public DateTime LicenseExpDate { get; set; }
    }
}