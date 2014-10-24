using System.Collections.Generic;
using Cares.Models.DomainModels;
using Cares.Models.ReportModels;
using System.Linq;

namespace Cares.Web.ModelMappers
{
    public static class RentalAgreementReportMapper
    {
        public static RaVehicleInfo CreateVehicleInfoFromRa(this RaMain rentalAgreement)
        {
            RaHireGroup hireGroup = rentalAgreement.RaHireGroups.FirstOrDefault();
            if (hireGroup != null)
                return new RaVehicleInfo
                {
                    RentalAgreementId = rentalAgreement.RaMainId,
                    Status = rentalAgreement.RaStatus.RaStatusCode,
                    RaOpenLocatoin = rentalAgreement.OpenLocation,
                    StartDateTime = rentalAgreement.StartDtTime,
                    ReturnDateTime = rentalAgreement.EndDtTime,
                    RaCloseLocation = rentalAgreement.CloseLocation,
                    PlateNumber = hireGroup.Vehicle.PlateNumber,
                    VehicleModel = hireGroup.Vehicle.VehicleModel.VehicleModelName,
                    ModelYear = hireGroup.Vehicle.ModelYear,
                    Color = hireGroup.Vehicle.Color,
                    Category = hireGroup.Vehicle.VehicleCategory.VehicleCategoryName,
                    ChargedDay = hireGroup.ChargedDay,
                    ChargedHour = hireGroup.ChargedHour,
                    ChargedMint = hireGroup.ChargedMinute,
                    GraceDay = hireGroup.GraceDay,
                    GraceHour = hireGroup.GraceMinute,
                    GraceMint = hireGroup.GraceMinute,
                };
            return new RaVehicleInfo();
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
                        TariffType = rentalAgreement.RaHireGroups != null ? raHireGroup.TariffTypeCode : string.Empty,
                        StandardRate = rentalAgreement.RaHireGroups != null ? raHireGroup.StandardRate : 0,
                        ExcessMileageCharges = raHireGroup.TotalExcMileageCharge,
                        VehicleCharges= rentalAgreement.TotalVehicleCharge,
                        DicountPercentage=rentalAgreement.SpecialDiscountPerc
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
                RaVehicleInfo = rentalAgreement.Select(abc => abc.CreateVehicleInfoFromRa()),
                RaCustomerInfo = rentalAgreement.Select(abc => abc.CreateCustomerInfoFromRa())
            };
        }
    }
}