using System.Collections.Generic;
using System.Linq;
using Cares.Models.ReportModels;
using Cares.Web.Models;
using DomainModels = Cares.Models.DomainModels;

namespace Cares.Web.ModelMappers
{
    /// <summary>
    /// RaHireGroup Mapper
    /// </summary>
    public static class RaHireGroupMapper
    {
        #region Public

        /// <summary>
        ///  Create web model from entity
        /// </summary>
        public static RaHireGroup CreateFrom(this DomainModels.RaHireGroup source)
        {
            return new RaHireGroup
            {
                RaHireGroupId = source.RaHireGroupId,
                HireGroupDetailId = source.HireGroupDetailId,
                HireGroupDetail = source.HireGroupDetail != null ? source.HireGroupDetail.CreateFrom() : new HireGroupDetailContent(),
                RaMainId = source.RaMainId,
                VehicleId = source.VehicleId,
                RentalChargeStartDate = source.RentalChargeStartDate,
                RentalChargeEndDate = source.RentalChargeEndDate,
                AllocationStatusId = source.AllocationStatusId,
                AllocationStatusKey = source.AllocationStatus != null ? source.AllocationStatus.AllocationStatusKey : 0,
                AllowedMileage = source.AllowedMileage,
                ChargedDay = source.ChargedDay,
                ChargedHour = source.ChargedHour,
                ChargedMinute = source.ChargedMinute,
                DropOffCharge = source.DropOffCharge,
                ExcessMileageRt = source.ExcessMileageRt,
                GraceDay = source.GraceDay,
                GraceHour = source.GraceHour,
                GraceMinute = source.GraceMinute,
                StandardRate = source.StandardRate,
                TariffTypeCode = source.TariffTypeCode,
                TotalExcMileage = source.TotalExcMileage,
                TotalExcMileageCharge = source.TotalExcMileageCharge,
                TotalStandardCharge = source.TotalStandardCharge,
                Vehicle = source.Vehicle != null ? source.Vehicle.CreateFrom(false) : new Vehicle(),
                VehicleMovements = source.VehicleMovements != null ? source.VehicleMovements.Select(vm => vm.CreateFrom()) : new List<VehicleMovement>(),
                RaHireGroupInsurances = source.RaHireGroupInsurances != null ? source.RaHireGroupInsurances.Select(hgi => hgi.CreateFrom()) : 
                new List<RaHireGroupInsurance>(),
                RaHireGroupDiscounts = source.RaHireGroupDiscounts != null ? source.RaHireGroupDiscounts.Select(hgd => hgd.CreateFrom()) : 
                new List<RaHireGroupDiscount>(),
                RaVehicleCheckLists = source.RaVehicleCheckLists != null ? source.RaVehicleCheckLists.Select(vch => vch.CreateFrom()) : new List<RaVehicleCheckList>()
            };
           
        }

        /// <summary>
        ///  Create web model from entity
        /// </summary>
        public static DomainModels.RaHireGroup CreateFrom(this RaHireGroup source)
        {
            return new DomainModels.RaHireGroup
            {
                RaHireGroupId = source.RaHireGroupId,
                HireGroupDetailId = source.HireGroupDetailId,
                RaMainId = source.RaMainId,
                VehicleId = source.VehicleId,
                RentalChargeStartDate = source.RentalChargeStartDate,
                RentalChargeEndDate = source.RentalChargeEndDate,
                AllocationStatusId = source.AllocationStatusId,
                AllowedMileage = source.AllowedMileage,
                ChargedDay = source.ChargedDay,
                ChargedHour = source.ChargedHour,
                ChargedMinute = source.ChargedMinute,
                DropOffCharge = source.DropOffCharge,
                ExcessMileageRt = source.ExcessMileageRt,
                GraceDay = source.GraceDay,
                GraceHour = source.GraceHour,
                GraceMinute = source.GraceMinute,
                StandardRate = source.StandardRate,
                TariffTypeCode = source.TariffTypeCode,
                TotalExcMileage = source.TotalExcMileage,
                TotalExcMileageCharge = source.TotalExcMileageCharge,
                TotalStandardCharge = source.TotalStandardCharge,
                VehicleMovements = source.VehicleMovements != null ? source.VehicleMovements.Select(vm => vm.CreateFrom()).ToList() : 
                new List<DomainModels.VehicleMovement>(),
                RaHireGroupInsurances = source.RaHireGroupInsurances != null ? source.RaHireGroupInsurances.Select(hgi => hgi.CreateFrom()).ToList() : 
                new List<DomainModels.RaHireGroupInsurance>(),
                RaHireGroupDiscounts = source.RaHireGroupDiscounts != null ? source.RaHireGroupDiscounts.Select(hgd => hgd.CreateFrom()).ToList() : 
                new List<DomainModels.RaHireGroupDiscount>(),
                RaVehicleCheckLists = source.RaVehicleCheckLists != null ? source.RaVehicleCheckLists.Select(vch => vch.CreateFrom()).ToList() : 
                new List<DomainModels.RaVehicleCheckList>()
            };

        }

        public static DailyActionReportResponse CreateReportDataFrom(this DomainModels.RaHireGroup raHireGroup)
        {
            return new DailyActionReportResponse
            {
                RaNumber = raHireGroup.RaMain.RaMainId,
                RAStutus = raHireGroup.RaMain.RaStatus.RaStatusCode,
                CustomerName = raHireGroup.RaMain.BusinessPartner.BusinessPartnerName,
                Nationality = raHireGroup.RaMain.BusinessPartner.BusinessPartnerAddressList.Count != 0 ? raHireGroup.RaMain.BusinessPartner.BusinessPartnerAddressList.First().Country.CountryName : string.Empty,
                Mobile =raHireGroup.RaMain.BusinessPartner.BusinessPartnerPhoneNumbers.Count!=0 ? raHireGroup.RaMain.BusinessPartner.BusinessPartnerPhoneNumbers.First().PhoneNumber : string.Empty ,
                HireGroup = raHireGroup.RaMain.RaHireGroups.Count!=0 ? raHireGroup.RaMain.RaHireGroups.First().HireGroupDetail.HireGroup.HireGroupName: string.Empty,
                PlateNumber = raHireGroup.Vehicle.PlateNumber,
                FleetPool = raHireGroup.Vehicle.FleetPool !=null? raHireGroup.Vehicle.FleetPool.FleetPoolName : string.Empty,
                VehicleMake = raHireGroup.Vehicle.VehicleMake.VehicleMakeName,
                VehicleModel = raHireGroup.Vehicle.VehicleModel.VehicleModelName,
                Mileage = raHireGroup.Vehicle.InitialOdometer - raHireGroup.Vehicle.CurrentOdometer,
                ModelYear = raHireGroup.Vehicle.ModelYear,
                VehicleStatus = raHireGroup.Vehicle.VehicleStatus!=null ? raHireGroup.Vehicle.VehicleStatus.VehicleStatusName : string.Empty,
                CurrentLocation = raHireGroup.Vehicle.OperationsWorkPlace !=null ? raHireGroup.Vehicle.OperationsWorkPlace.LocationCode :string.Empty,
                AmountBalance = raHireGroup.RaMain.Balance,
                AmountPaid = raHireGroup.RaMain.AmountPaid,
                InDate = raHireGroup.RaMain.StartDtTime.ToString("dd-MMM-yy HH:mm"),
                OutDate = raHireGroup.RaMain.EndDtTime.ToString("dd-MMM-yy HH:mm"),
            };
        }

        #endregion

    }
}
