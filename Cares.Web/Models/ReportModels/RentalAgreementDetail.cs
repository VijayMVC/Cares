using System;

namespace Cares.Web.Models.ReportModels
{
    /// <summary>
    /// Contains Rental Agreement Details and Billing info
    /// </summary>
    public class RentalAgreementDetail
    {
        #region Public
        public string RenterName { get; set; }
        public long RentalAgreementId { get; set; }
        public string Status { get; set; }
        public long RaOpenLocatoin { get; set; }
        public string StartDateTime { get; set; }
        public string ReturnDateTime { get; set; }
        public long RaCloseLocation { get; set; }      
        public double TotalVehicleCharge { get; set; }
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
