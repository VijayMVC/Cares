﻿using System;

namespace Cares.Models.ResponseModels
{
    /// <summary>
    /// cares model
    /// </summary>
    public class WebApiBookingMainInfo
    {
        public long OperationWorkPlaceId { get; set; }
        public DateTime StartDateTime { get; set; }
        public DateTime EndtDateTime { get; set; }
        public string TariffTypeCode { get; set; }
        public long HireGroupDetailId { get; set; }
    }
}