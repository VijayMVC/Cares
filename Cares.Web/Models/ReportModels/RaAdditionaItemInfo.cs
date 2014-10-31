using System;

namespace Cares.Web.Models.ReportModels
{
    public class RaAdditionaItemInfo
    {

        public string ChargedType { get; set; }
        public string ItemName { get; set; }
        public DateTime ServiceStartDateTime { get; set; }
        public DateTime ServiceEndDateTime { get; set; }
        public long ServiceChargedDays { get; set; }
        public long ServiceChargedHours { get; set; }
        public long ServiceChargedMinutes { get; set; }
        public string ServiceTarrifApplied { get; set; }
        public double Rate { get; set; }
        public double ServiceTotal { get; set; }
        public string ServicePlateNumber { get; set; }


    }
}
