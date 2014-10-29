using System;
using System.Collections.Generic;

namespace Cares.Models.ReportModels
{
    public class RentalAgreementInfo
    {
        #region Public
        public long RentalAgreementId { get; set; }
        public string Status { get; set; }
        public long RaOpenLocatoin { get; set; }
        public DateTime StartDateTime { get; set; }
        public DateTime ReturnDateTime { get; set; }
        public long RaCloseLocation { get; set; }

        public IList<RaVehicleInfo> RaVehicleInfos { get; set; } 


        public string ChargeType { get; set; }
        public string ItemName { get; set; }
        public DateTime ServiceStartDateTime { get; set; }
        public DateTime ServiceEndDateTime { get; set; }
        public long ChargedDays { get; set; }
        public long ChargedHours { get; set; }
        public long ChargedMinutes { get; set; }

        public string Rate { get; set; }
        public long TotalCharge { get; set; }
        public string VehicleCheckList { get; set; }

        public double TotalVehicleCharges { get; set; }
        public double StandardDiscount { get; set; }
        public double SessionalDiscount { get; set; }
        public double VoucherDiscount { get; set; }
        public double SpecialDiscount { get; set; }
        public double NetBillAfterDiscount { get; set; }
        public double TotalExcessNileageCharges { get; set; }
        public double TotalServiceCharges { get; set; }
        public double TotalInsurenceCharges { get; set; }
        public double TotalDriverChufferCharges { get; set; }
        public double TotalAdditionalCharges { get; set; }
        public double? TotalOtherCharges { get; set; }
        public double AmountPaid { get; set; }
        public double Balance { get; set; }





        #endregion
    }
}
