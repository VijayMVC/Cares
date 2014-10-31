using System.Collections.Generic;
namespace Cares.Web.Models.ReportModels

{
    /// <summary>
    /// Rental Agreement Detail Response Model contain lists for data sets 
    /// </summary>
    public class RentalAgreementDetailResponse
    {
       

        /// <summary>
        /// List of Rental Agreement Detail
        /// </summary>
        public IEnumerable<RentalAgreementDetail> RentalAgreementDetail { get; set; }

        /// <summary>
        /// List of customer info
        /// </summary>
        public IEnumerable<RaCustomerInfo> RaCustomerInfo { get; set; }

        /// <summary>
        /// List of Vehicles and their detail
        /// </summary>
        public IEnumerable<RaVehicleInfo> RaVehicleInfos { get; set; }

        /// <summary>
        /// List of service items
        /// </summary>
        public IEnumerable<RaAdditionaItemInfo> RaAdditionaItemInfos { get; set; }

        /// <summary>
        /// List of Driver info
        /// </summary>
        public IEnumerable<RaDriver> RaDriverInfo { get; set; }

        /// <summary>
        /// List of Additional charges 
        /// </summary>
        public IEnumerable<RaAdditionalChargeInfo> RaAdditionalChargeInfos { get; set; }

        /// <summary>
        /// List of Rental Agreement Insurances
        /// </summary>
        public IEnumerable<RaHireGroupInsurance> RaHireGroupInsuranceInfos { get; set; }

    }
}
