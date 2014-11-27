using System;

namespace Cares.Models.ResponseModels
{
    public class WebApiAdditionalDriverInfo
    {
        public string Name { get; set; }
        public double Rate { get; set; }
        public string LicenseNumber { get; set; }
        public DateTime LicenseExpDate { get; set; }
    }
}
