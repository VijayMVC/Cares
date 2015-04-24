using System;
using System.Globalization;
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

            RentalAgreementDetail retVal = new RentalAgreementDetail();
            if (rentalAgreement.BusinessPartner.IsIndividual)
            {
                BusinessPartnerIndividual bP = rentalAgreement.BusinessPartner.BusinessPartnerIndividual;
                retVal.RenterName = bP != null ? bP.FirstName + " " + bP.LastName : string.Empty;
            }
            else
            {
                retVal.RenterName = rentalAgreement.RentersName;
            }
            retVal.RentalAgreementId = rentalAgreement.RaMainId;
            retVal.Status = rentalAgreement.RaStatus.RaStatusCode;
            retVal.RaOpenLocatoin = rentalAgreement.OperationsWorkPlaceOpen.LocationCode;
            retVal.StartDateTime = rentalAgreement.StartDtTime.ToString("dd-MMM-yy HH:mm");
            retVal.ReturnDateTime = rentalAgreement.EndDtTime.ToString("dd-MMM-yy HH:mm");
            retVal.RaCloseLocation = rentalAgreement.OperationsWorkPlaceClose.LocationCode;
            retVal.TotalVehicleCharge = rentalAgreement.TotalVehicleCharge;
            retVal.StandardDiscount = rentalAgreement.StandardDiscount;
            retVal.SessionalDiscount = rentalAgreement.SeasonalDiscount;
            retVal.VoucherDiscount = rentalAgreement.VoucherDiscount;
            retVal.SpecialDiscount = rentalAgreement.SpecialDiscount;
            retVal.NetBillAfterDiscount = rentalAgreement.NetBillAfterDiscount;
            retVal.TotalExcessNileageCharges = rentalAgreement.TotalExcessMileageCharge;
            retVal.TotalServiceCharges = rentalAgreement.TotalServiceCharge;
            retVal.TotalInsurenceCharges = rentalAgreement.TotalInsuranceCharge;
            retVal.TotalDriverChufferCharges = rentalAgreement.TotalDriverCharge;
            retVal.TotalAdditionalCharges = rentalAgreement.TotalAdditionalCharge;
            retVal.TotalOtherCharges = rentalAgreement.TotalOtherCharge;
            retVal.AmountPaid = rentalAgreement.AmountPaid;
            retVal.Balance = rentalAgreement.Balance;
            return retVal;
        }

        /// <summary>
        /// Rental Agreement Customer 
        /// </summary>
        private static RaCustomerInfo CreateCustomerInfo(this RaMain rentalAgreement)
        {
            RaCustomerInfo retVal = new RaCustomerInfo();
            if (rentalAgreement.BusinessPartner.IsIndividual)
            {
                BusinessPartnerIndividual customerInfo = rentalAgreement.BusinessPartner.BusinessPartnerIndividual;
                retVal.RenterName = customerInfo.FirstName + " " + customerInfo.LastName;
                retVal.LicenceNumber = customerInfo.LiscenseNumber;
                retVal.LicenceDOE = customerInfo.LiscenseExpiryDate;
                retVal.Identification = customerInfo.NicNumber;
                retVal.NID_DOE = Convert.ToDateTime(customerInfo.NicExpiryDate).ToString("dd/MM/yyyy", new CultureInfo("en"));
                retVal.PassportNumber = customerInfo.PassportNumber;
                retVal.PassportDOE = customerInfo.PassportExpiryDate;
                retVal.DOB = Convert.ToDateTime(customerInfo.DateOfBirth).ToString("dd/MM/yyyy", new CultureInfo("en"));
                retVal.Country = customerInfo.PassportCountry != null ? customerInfo.PassportCountry.CountryName : string.Empty;
                var phones = rentalAgreement.BusinessPartner.BusinessPartnerPhoneNumbers;
                if (phones.Any())
                {
                    foreach (var phone in phones)
                    {
                        retVal.Telephone += phone.PhoneNumber + "\n";
                    }
                }
                return retVal;
            }
            Address address = rentalAgreement.BusinessPartner.BusinessPartnerAddressList.FirstOrDefault();
            RaCustomerInfo retVall = new RaCustomerInfo();
            retVall.RenterName = rentalAgreement.BusinessPartner.BusinessPartnerName;
            retVall.LicenceNumber = rentalAgreement.RentersLicenseNumber;
            retVall.LicenceDOE = rentalAgreement.RentersLicenseExpDt;
            retVall.ContactPerson = address != null ? address.ContactPerson : string.Empty;
            retVall.City = address != null ? address.City.CityName : string.Empty;
            retVall.Country = address != null ? address.Country.CountryName : string.Empty;
            retVall.Region = address != null ? address.Region.RegionName : string.Empty;
            retVall.StreetAddress = address != null ? address.StreetAddress : string.Empty;
            var phoness = rentalAgreement.BusinessPartner.BusinessPartnerPhoneNumbers;
            if (phoness.Any())
            {
                foreach (var phone in phoness)
                {
                    retVall.Telephone += phone.PhoneNumber + "\n";
                }
            }
            return retVall;
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
            RentalAgreementDetailResponse retVal = new RentalAgreementDetailResponse();
            retVal.RentalAgreementDetail = new List<RentalAgreementDetail>
            {
                rentalAgreement.CreateRentalAgreementDetail()
            };
            if (rentalAgreement.BusinessPartner.IsIndividual)
            {
                retVal.RaCustomerInfo = rentalAgreement.BusinessPartner.BusinessPartnerIndividual != null ? new List<RaCustomerInfo> { rentalAgreement.CreateCustomerInfo() } : new List<RaCustomerInfo> { new RaCustomerInfo() };
            }
            else
            {
                retVal.RaCustomerInfo = new List<RaCustomerInfo> { rentalAgreement.CreateCustomerInfo() } ;
            }
            retVal.RaVehicleInfos = rentalAgreement.RaHireGroups.Select(hireGroup => hireGroup.CreateVehicelDetail());
            retVal.RaAdditionaItemInfos =
                rentalAgreement.RaServiceItems.Select(serviceItem => serviceItem.CreateServiceItemDetail());
            retVal.RaDriverInfo = rentalAgreement.RaDrivers.Select(radriver => radriver.CreateFrom());
            retVal.RaAdditionalChargeInfos =
                rentalAgreement.RaAdditionalCharges.Select(
                    additionalCharge => additionalCharge.CreateAdditionalChargeDetail());
            retVal.RaHireGroupInsuranceInfos = (from raHireGroup in rentalAgreement.RaHireGroups
                from hireGroupInsurance in raHireGroup.RaHireGroupInsurances
                select hireGroupInsurance.CreateFrom()).ToList();
            return retVal;
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
        //private static RaCustomerInfo CreateCustomerInfo(renta businessPartner)
        //{
        //    return new RaCustomerInfo();
        //}
    }
}