using System;
using System.Collections.Generic;
using Cares.Models.DomainModels;
using Cares.Models.ReportModels;
using System.Linq;

namespace Cares.Web.ModelMappers
{
    public static class RentalAgreementReportMapper
    {
        public static RentalAgreementInfo CreateVehicleInfoFromRa(this RaMain rentalAgreement)
        {
            RaHireGroup hireGroup = rentalAgreement.RaHireGroups.FirstOrDefault();
            if (hireGroup != null)
            {
                RaHireGroupDiscount raHireGroupDiscount = hireGroup.RaHireGroupDiscounts.FirstOrDefault();
               
               
                    return new RentalAgreementInfo
                    {
                        RentalAgreementId = rentalAgreement.RaMainId,
                        Status = rentalAgreement.RaStatus.RaStatusCode,
                        RaOpenLocatoin = rentalAgreement.OpenLocation,
                        StartDateTime = rentalAgreement.StartDtTime,
                        ReturnDateTime = rentalAgreement.EndDtTime,
                        RaCloseLocation = rentalAgreement.CloseLocation,
                        
                       

                        RaVehicleInfos = rentalAgreement.RaHireGroups.Select(abc => abc.CreateVehicelDetail()).ToList(),

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
            return new RentalAgreementInfo();
        }

        public static RaCustomerInfo CreateCustomerInfoFromRa(this RaMain rentalAgreement)
        {
            RaHireGroup hireGroup = rentalAgreement.RaHireGroups.FirstOrDefault();
            if (hireGroup != null)
            {
                RaDriver firstOrDefault = rentalAgreement.RaDrivers.FirstOrDefault();
                if (firstOrDefault != null)
                {
                    Address address = rentalAgreement.BusinessPartner.BusinessPartnerAddressList.FirstOrDefault();
                    RaHireGroup raHireGroup = rentalAgreement.RaHireGroups.FirstOrDefault();
                    return new RaCustomerInfo
                    {
                        RenterName = rentalAgreement.RentersName,
                        Driver = firstOrDefault.DriverName,
                        LicenceNumber = rentalAgreement.RentersLicenseNumber,
                        LicenceDOE = rentalAgreement.RentersLicenseExpDt,
                        ContactPerson = rentalAgreement.BusinessPartner != null ? address.ContactPerson : string.Empty,
                        City = rentalAgreement.BusinessPartner != null ? address.City.CityName : string.Empty,
                        Country = rentalAgreement.BusinessPartner != null ? address.Country.CountryName : string.Empty,
                        Region = rentalAgreement.BusinessPartner != null ? address.Region.RegionName : string.Empty,
                        StreetAddress = rentalAgreement.BusinessPartner != null ? address.StreetAddress : string.Empty,

                       
                        //TariffType = rentalAgreement.RaHireGroups != null ? raHireGroup.TariffTypeCode : string.Empty,
                        //StandardRate = rentalAgreement.RaHireGroups != null ? raHireGroup.StandardRate : 0,
                        //ExcessMileageCharges = raHireGroup.TotalExcMileageCharge,
                        //VehicleCharges= rentalAgreement.TotalVehicleCharge,
                        //DicountPercentage=rentalAgreement.SpecialDiscountPerc,

                       
                        

                    };
                }
            }
            return new RaCustomerInfo();
        }
        
        /// <summary>
        /// Crete From Rental Agreement Response List
        /// </summary>
        public static RentalAgreementDetailResponse CreteFrom(this  List<RaMain> rentalAgreement)
        {
            return new RentalAgreementDetailResponse
            {
                RentalAgreementInfos = rentalAgreement.Select(abc => abc.CreateVehicleInfoFromRa()),
                RaCustomerInfo = rentalAgreement.Select(abc => abc.CreateCustomerInfoFromRa())
            };
        }


        public static RaVehicleInfo CreateVehicelDetail(this RaHireGroup raHireGroup)
        {
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
                GraceHour = raHireGroup.GraceMinute,
                GraceMint = raHireGroup.GraceMinute,
                VehicelOutDateTime = raHireGroup.VehicleMovements.Where(vehiclemovement => vehiclemovement.Status).Select(vehicle=>vehicle.DtTime).First(),
                VehicelInDateTime = raHireGroup.VehicleMovements.Where(vehiclemovement => vehiclemovement.Status == false).Select(vehicle => vehicle.DtTime).First(),

                TariffType = raHireGroup.TariffTypeCode,
                StandardRate = raHireGroup.StandardRate,
                ExcessMileageCharges = raHireGroup.ExcessMileageRt * raHireGroup.TotalExcMileage,
                DiscoutAmount = raHireGroup.RaHireGroupDiscounts.First().DiscountAmount,
                DicountPercentage = raHireGroup.RaHireGroupDiscounts.First().DiscountPerc,
                DicountType = "Set Type",
                TotalChargeVehicle = 1001




            };
        }
    }
}