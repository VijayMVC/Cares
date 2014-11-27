using System;

namespace Cares.WebApp.Models
{
    public class BookingMainInfo
    {
        public long OperationWorkPlaceId { get; set; }
        public DateTime StartDateTime { get; set; }
        public DateTime EndtDateTime { get; set; }
        public string TariffTypeCode { get; set; }
        public long HireGroupDetailId { get; set; }
    }
}