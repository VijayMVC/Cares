using Cares.Models.DomainModels;
using Cares.Web.Models.ReportModels;
using System.Collections.Generic;
using System.Linq;

namespace Cares.Web.ModelMappers
{
    public static class RentalAgreementReportMapper
    {

        private static RentalAgreementDetail CreateRentalAgreementDetail(this RaMain rentalAgreement)
        {

            return new RentalAgreementDetail
            {
                RenterName = rentalAgreement.RentersName,
                RentalAgreementId = rentalAgreement.RaMainId,
                Status = rentalAgreement.RaStatus.RaStatusCode,
                RaOpenLocatoin = rentalAgreement.OpenLocation,
                StartDateTime = rentalAgreement.StartDtTime.ToString("dd-MMM-yy HH:mm"),
                ReturnDateTime = rentalAgreement.EndDtTime.ToString("dd-MMM-yy HH:mm"),
                RaCloseLocation = rentalAgreement.CloseLocation,
                TotalVehicleCharge = rentalAgreement.TotalVehicleCharge,
                StandardDiscount = rentalAgreement.StandardDiscount,
                SessionalDiscount = rentalAgreement.SeasonalDiscount,
                VoucherDiscount = rentalAgreement.VoucherDiscount,
                SpecialDiscount = rentalAgreement.SpecialDiscount,
                NetBillAfterDiscount = rentalAgreement.NetBillAfterDiscount,
                TotalExcessNileageCharges = rentalAgreement.TotalExcessMileageCharge,
                TotalServiceCharges = rentalAgreement.TotalServiceCharge,
                TotalInsurenceCharges = rentalAgreement.TotalInsuranceCharge,
                TotalDriverChufferCharges = rentalAgreement.TotalDriverCharge,
                TotalAdditionalCharges = rentalAgreement.TotalAdditionalCharge,
                TotalOtherCharges = rentalAgreement.TotalOtherCharge,
                AmountPaid = rentalAgreement.AmountPaid,
                Balance = rentalAgreement.Balance,
            };
        }

        /// <summary>
        /// Rental Agreement Customer 
        /// </summary>
        private static RaCustomerInfo CreateCustomerInfo(this RaMain rentalAgreement)
        {
             Address address = rentalAgreement.BusinessPartner.BusinessPartnerAddressList.FirstOrDefault();
            return new RaCustomerInfo
            {
                RenterName = rentalAgreement.BusinessPartner.BusinessPartnerName,
                LicenceNumber = rentalAgreement.RentersLicenseNumber,
                LicenceDOE = rentalAgreement.RentersLicenseExpDt,
                ContactPerson = rentalAgreement.BusinessPartner != null ? address.ContactPerson : string.Empty,
                City = rentalAgreement.BusinessPartner != null ? address.City.CityName : string.Empty,
                Country = rentalAgreement.BusinessPartner != null ? address.Country.CountryName : string.Empty,
                Region = rentalAgreement.BusinessPartner != null ? address.Region.RegionName : string.Empty,
                StreetAddress = rentalAgreement.BusinessPartner != null ? address.StreetAddress : string.Empty,
            };

        }
        
        /// <summary>
        /// Vehicel Detail and Charges info
        /// </summary>
        private static RaVehicleInfo CreateVehicelDetail(this RaHireGroup raHireGroup)
        {
            long toalHours = 0;
            long totalDays =0;
           
            return new RaVehicleInfo
            {
                PlateNumber = raHireGroup.Vehicle.PlateNumber,
                VehicleModel = raHireGroup.Vehicle.VehicleModel.VehicleModelName,
                ModelYear = raHireGroup.Vehicle.ModelYear,
                Color = raHireGroup.Vehicle.Color,
                Category = raHireGroup.Vehicle.VehicleCategory.VehicleCategoryName,
                ChargedDay = raHireGroup.ChargedDay,
                ChargedHour = raHireGroup.ChargedHour,
                ChargedMint = raHireGroup.ChargedMinute,
                GraceDay = raHireGroup.GraceDay,
                GraceHour = raHireGroup.GraceHour,
                GraceMint = raHireGroup.GraceMinute,
                ConsumedMint = CalculateConsumedDaysHoursMints(raHireGroup.GraceMinute + raHireGroup.ChargedMinute ,60, ref toalHours),
                ConsumedHour = CalculateConsumedDaysHoursMints(raHireGroup.ChargedHour + raHireGroup.GraceHour+toalHours,24,ref totalDays),
                ConsumedDay =  raHireGroup.GraceDay + raHireGroup.ChargedDay+ totalDays ,
                VehicelOutDateTime =( raHireGroup.VehicleMovements.Where(vehiclemovement => vehiclemovement.Status).Select(vehicle=>vehicle.DtTime).FirstOrDefault()).ToString("dd-MMM-yy HH:mm"),
                VehicelInDateTime = (raHireGroup.VehicleMovements.Where(vehiclemovement => vehiclemovement.Status == false).Select(vehicle => vehicle.DtTime).FirstOrDefault()).ToString("dd-MMM-yy HH:mm"),
                TariffType = raHireGroup.TariffTypeCode,
                StandardRate = raHireGroup.StandardRate,
                ExcessMileageCharges = raHireGroup.ExcessMileageRt * raHireGroup.TotalExcMileage,
                DiscoutAmount = raHireGroup.RaHireGroupDiscounts!=null ? raHireGroup.RaHireGroupDiscounts.FirstOrDefault() !=null? raHireGroup.RaHireGroupDiscounts.FirstOrDefault().DiscountAmount:0 : 0,
                DicountPercentage = raHireGroup.RaHireGroupDiscounts!=null ? raHireGroup.RaHireGroupDiscounts.FirstOrDefault() !=null? raHireGroup.RaHireGroupDiscounts.FirstOrDefault().DiscountPerc:0 :0,
                DicountType = "Set The Type",
                TotalChargeVehicle = 1001,
            };
        }

        /// <summary>
        /// Service Item and Additional Charges
        /// </summary>
        private static RaAdditionaItemInfo CreateServiceItemDetail(this RaServiceItem raServiceItem)
        {
            return new RaAdditionaItemInfo
            {
                ServiceStartDateTime = raServiceItem.StartDtTime.ToString("dd-MMM-yy HH:mm"),
                ServiceEndDateTime = raServiceItem.EndDtTime.ToString("dd-MMM-yy HH:mm"),
                ServiceChargedDays = raServiceItem.ChargedDay,
                ServiceChargedHours = raServiceItem.ChargedHour,
                ServiceChargedMinutes = raServiceItem.ChargedMinute,
                ServiceTarrifApplied = raServiceItem.TariffType,
                Rate = raServiceItem.ServiceRate,
                ServiceTotal = 1001,
                ServicePlateNumber = "-",
               ItemName = raServiceItem.ServiceItem.ServiceItemName,
               ChargedType= raServiceItem.ServiceItem.ServiceType.ServiceTypeCode,
            };
        }


        private static RaAdditionalChargeInfo CreateAdditionalChargeDetail(this RaAdditionalCharge raAdditionalCharge)
        {
            return new RaAdditionalChargeInfo
            {
                ChargedType = raAdditionalCharge.AdditionalChargeType.AdditionalChargeTypeCode,
                PlateNumber = raAdditionalCharge.PlateNumber,
                Rate = raAdditionalCharge.AdditionalChargeRate
            };
        }

        /// <summary>
        /// Crete From Rental Agreement Response List  [Master]
        /// </summary>
        public static RentalAgreementDetailResponse CreteFrom(this  RaMain rentalAgreement)
        {
            return new RentalAgreementDetailResponse
            {
                RentalAgreementDetail = new List<RentalAgreementDetail> { rentalAgreement.CreateRentalAgreementDetail() },
                RaCustomerInfo = new List<RaCustomerInfo> { rentalAgreement.CreateCustomerInfo() },
                RaVehicleInfos = rentalAgreement.RaHireGroups.Select(hireGroup => hireGroup.CreateVehicelDetail()),
                RaAdditionaItemInfos = rentalAgreement.RaServiceItems.Select(serviceItem => serviceItem.CreateServiceItemDetail()),
                RaDriverInfo = rentalAgreement.RaDrivers.Select(radriver => radriver.CreateFrom()),
                RaAdditionalChargeInfos = rentalAgreement.RaAdditionalCharges.Select(additionalCharge => additionalCharge.CreateAdditionalChargeDetail()),
                RaHireGroupInsuranceInfos = (from raHireGroup in rentalAgreement.RaHireGroups from hireGroupInsurance in raHireGroup.RaHireGroupInsurances select hireGroupInsurance.CreateFrom()).ToList()
            };
        }

        /// <summary>
        /// Calculates Consumed Days,Hours and minutes 
        /// </summary>
        private static long CalculateConsumedDaysHoursMints(long sumOfValues, long maxValue, ref long valueToIncrement)
        {
            if (sumOfValues >= maxValue)
            {
                valueToIncrement = valueToIncrement + 1;
                return sumOfValues-maxValue;
            }
                return sumOfValues;
        }

    }
}