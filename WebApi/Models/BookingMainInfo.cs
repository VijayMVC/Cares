using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cares.WebApi.Models
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