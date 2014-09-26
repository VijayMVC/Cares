using System;
using System.Collections.Generic;

namespace Cares.Web.Models
{
    /// <summary>
    /// Rental Agreement Web Model
    /// </summary>
    public class RaMain
    {
        #region Persisted Properties

        /// <summary>
        /// Ra Main ID
        /// </summary>
        public long RaMainId { get; set; }

        /// <summary>
        /// Open Location
        /// </summary>
        public long OpenLocation { get; set; }

        /// <summary>
        /// Close Location
        /// </summary>
        public long CloseLocation { get; set; }

        /// <summary>
        /// Ra Status Id
        /// </summary>
        public short RaStatusId { get; set; }

        /// <summary>
        /// Payment Term Id
        /// </summary>
        public short PaymentTermId { get; set; }

        /// <summary>
        /// Operation Id
        /// </summary>
        public long OperationId { get; set; }

        /// <summary>
        /// Bp Main Id
        /// </summary>
        public long BusinessPartnerId { get; set; }

        /// <summary>
        /// Ra Main Description
        /// </summary>
        public string RaMainDescription { get; set; }

        /// <summary>
        /// Start Date
        /// </summary>
        public DateTime StartDtTime { get; set; }

        /// <summary>
        /// End Date
        /// </summary>
        public DateTime EndDtTime { get; set; }

        /// <summary>
        /// Total Vehicle Charge
        /// </summary>
        public double TotalVehicleCharge { get; set; }

        /// <summary>
        /// Total Insurance Charge
        /// </summary>
        public double TotalInsuranceCharge { get; set; }

        /// <summary>
        /// Voucher Discount
        /// </summary>
        public double VoucherDiscount { get; set; }

        /// <summary>
        /// Seasonal Discount
        /// </summary>
        public double SeasonalDiscount { get; set; }

        /// <summary>
        /// Special Discount
        /// </summary>
        public double SpecialDiscount { get; set; }

        /// <summary>
        /// Total Drop off Charge
        /// </summary>
        public double TotalDropOffCharge { get; set; }

        /// <summary>
        /// Net Bill After Discount
        /// </summary>
        public double NetBillAfterDiscount { get; set; }

        /// <summary>
        /// Total Excess Mileage Charge
        /// </summary>
        public double TotalExcessMileageCharge { get; set; }

        /// <summary>
        /// Total Service Charge
        /// </summary>
        public double TotalServiceCharge { get; set; }

        /// <summary>
        /// Total Driver Charge
        /// </summary>
        public double TotalDriverCharge { get; set; }

        /// <summary>
        /// Total Additional Charge
        /// </summary>
        public double TotalAdditionalCharge { get; set; }

        /// <summary>
        /// Total Other Charge
        /// </summary>
        public double? TotalOtherCharge { get; set; }

        /// <summary>
        /// Amount Paid
        /// </summary>
        public double AmountPaid { get; set; }

        /// <summary>
        /// Balance
        /// </summary>
        public double Balance { get; set; }

        /// <summary>
        /// Special Discount Perc
        /// </summary>
        public double? SpecialDiscountPerc { get; set; }

        /// <summary>
        /// Standard Discount
        /// </summary>
        public double StandardDiscount { get; set; }

        /// <summary>
        /// Renter's Name
        /// </summary>
        public string RentersName { get; set; }

        /// <summary>
        /// Renters License Number
        /// </summary>
        public string RentersLicenseNumber { get; set; }

        /// <summary>
        /// Rentes License Exp Datetime
        /// </summary>
        public DateTime? RentersLicenseExpDt { get; set; }

        /// <summary>
        /// Is Special Discount Perc
        /// </summary>
        public bool IsSpecialDiscountPerc { get; set; }

        /// <summary>
        /// Ra Booking Id
        /// </summary>
        public long? RaBookingId { get; set; }

        /// <summary>
        /// Record Created Date
        /// </summary>
        public DateTime RecCreatedDt { get; set; }
        
        #endregion

        #region Reference Properties
        
        /// <summary>
        /// Business Partner
        /// </summary>
        public BusinessPartnerDetail BusinessPartner { get; set; }
        
        /// <summary>
        /// Ra Payments
        /// </summary>
        public IEnumerable<RaPayment> RaPayments { get; set; }

        /// <summary>
        /// Ra Service Items
        /// </summary>
        public IEnumerable<RaServiceItem> RaServiceItems { get; set; }

        /// <summary>
        /// Ra Additional Charges
        /// </summary>
        public IEnumerable<RaAdditionalCharge> RaAdditionalCharges { get; set; }

        /// <summary>
        /// Ra Drivers
        /// </summary>
        public IEnumerable<RaDriver> RaDrivers { get; set; }

        /// <summary>
        /// Ra Customer Documents
        /// </summary>
        public IEnumerable<RaCustomerDocument> RaCustomerDocuments { get; set; }

        /// <summary>
        /// Ra HireGroups
        /// </summary>
        public IEnumerable<RaHireGroup> RaHireGroups { get; set; }

        #endregion

        #region Constructor

        /// <summary>
        /// Constructor
        /// </summary>
        public RaMain()
        {
            BusinessPartner = new BusinessPartnerDetail();
            RaHireGroups = new List<RaHireGroup>();
            RaPayments = new List<RaPayment>();
            RaDrivers = new List<RaDriver>();
            RaAdditionalCharges = new List<RaAdditionalCharge>();
            RaServiceItems = new List<RaServiceItem>();
            RaCustomerDocuments = new List<RaCustomerDocument>();
        }

        #endregion
    }
}