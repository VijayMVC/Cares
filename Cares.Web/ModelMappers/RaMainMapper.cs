using System.Collections.Generic;
using System.Linq;
using Cares.Web.Models;
using DomainModels = Cares.Models.DomainModels;

namespace Cares.Web.ModelMappers
{
    /// <summary>
    /// RaMain Mapper
    /// </summary>
    public static class RaMainMapper
    {
        #region Public

        /// <summary>
        ///  Create web model from entity
        /// </summary>
        public static RaMain CreateFrom(this DomainModels.RaMain source)
        {
            return new RaMain
            {
                RaMainId = source.RaMainId,
                RaHireGroups = source.RaHireGroups != null ? source.RaHireGroups.Select(vm => vm.CreateFrom()) : new List<RaHireGroup>(),
                RaAdditionalCharges = source.RaAdditionalCharges != null ? source.RaAdditionalCharges.Select(hgi => hgi.CreateFrom()) : new List<RaAdditionalCharge>(),
                RaCustomerDocuments = source.RaCustomerDocuments != null ? source.RaCustomerDocuments.Select(cd => cd.CreateFrom()) : new List<RaCustomerDocument>(),
                RaDrivers = source.RaDrivers != null ? source.RaDrivers.Select(cd => cd.CreateFrom()) : new List<RaDriver>(),
                RaPayments = source.RaPayments != null ? source.RaPayments.Select(cd => cd.CreateFrom()) : new List<RaPayment>(),
                RaServiceItems = source.RaServiceItems != null ? source.RaServiceItems.Select(cd => cd.CreateFrom()) : new List<RaServiceItem>(),
                AmountPaid = source.AmountPaid,
                EndDtTime = source.EndDtTime,
                StartDtTime = source.StartDtTime,
                BusinessPartner = source.BusinessPartner != null ? source.BusinessPartner.CreateFromForRa() : new BusinessPartnerDetail(),
                RecCreatedDt = source.RecCreatedDt,
                SeasonalDiscount = source.SeasonalDiscount,
                SpecialDiscount = source.SpecialDiscount,
                Balance = source.Balance,
                BusinessPartnerId = source.BusinessPartnerId,
                CloseLocation = source.CloseLocation,
                IsSpecialDiscountPerc = source.IsSpecialDiscountPerc,
                NetBillAfterDiscount = source.NetBillAfterDiscount,
                OpenLocation = source.OpenLocation,
                OperationId = source.OperationId,
                PaymentTermId = source.PaymentTermId,
                RaBookingId = source.RaBookingId,
                RaMainDescription = source.RaMainDescription,
                RaStatusId = source.RaStatusId,
                RentersLicenseExpDt = source.RentersLicenseExpDt,
                RentersLicenseNumber = source.RentersLicenseNumber,
                RentersName = source.RentersName,
                SpecialDiscountPerc = source.SpecialDiscountPerc,
                StandardDiscount = source.StandardDiscount,
                TotalAdditionalCharge = source.TotalAdditionalCharge,
                TotalDriverCharge = source.TotalDriverCharge,
                TotalDropOffCharge = source.TotalDropOffCharge,
                TotalExcessMileageCharge = source.TotalExcessMileageCharge,
                TotalInsuranceCharge = source.TotalInsuranceCharge,
                TotalOtherCharge = source.TotalOtherCharge,
                TotalServiceCharge = source.TotalServiceCharge,
                TotalVehicleCharge = source.TotalVehicleCharge,
                VoucherDiscount = source.VoucherDiscount
            };
           
        }

        /// <summary>
        ///  Create web model from entity
        /// </summary>
        public static DomainModels.RaMain CreateFrom(this RaMain source)
        {
            DomainModels.RaMain raMain = new DomainModels.RaMain
            {
                RaMainId = source.RaMainId,
                RaHireGroups = source.RaHireGroups != null ? source.RaHireGroups.Select(vm => vm.CreateFrom()).ToList() : new List<DomainModels.RaHireGroup>(),
                RaAdditionalCharges = source.RaAdditionalCharges != null ? source.RaAdditionalCharges.Select(hgi => hgi.CreateFrom()).ToList() : 
                new List<DomainModels.RaAdditionalCharge>(),
                RaCustomerDocuments = source.RaCustomerDocuments != null ? source.RaCustomerDocuments.Select(cd => cd.CreateFrom()).ToList() :
                new List<DomainModels.RaCustomerDocument>(),
                RaDrivers = source.RaDrivers != null ? source.RaDrivers.Select(cd => cd.CreateFrom()).ToList() : new List<DomainModels.RaDriver>(),
                RaPayments = source.RaPayments != null ? source.RaPayments.Select(cd => cd.CreateFrom()).ToList() : new List<DomainModels.RaPayment>(),
                RaServiceItems = source.RaServiceItems != null ? source.RaServiceItems.Select(cd => cd.CreateFrom()).ToList() : new List<DomainModels.RaServiceItem>(),
                AmountPaid = source.AmountPaid,
                EndDtTime = source.EndDtTime,
                StartDtTime = source.StartDtTime,
                RecCreatedDt = source.RecCreatedDt,
                SeasonalDiscount = source.SeasonalDiscount,
                SpecialDiscount = source.SpecialDiscount,
                Balance = source.Balance,
                BusinessPartnerId = source.BusinessPartnerId,
                CloseLocation = source.CloseLocation,
                IsSpecialDiscountPerc = source.IsSpecialDiscountPerc,
                NetBillAfterDiscount = source.NetBillAfterDiscount,
                OpenLocation = source.OpenLocation,
                OperationId = source.OperationId,
                PaymentTermId = source.PaymentTermId,
                RaBookingId = source.RaBookingId,
                RaMainDescription = source.RaMainDescription,
                RaStatusId = source.RaStatusId,
                RentersLicenseExpDt = source.RentersLicenseExpDt,
                RentersLicenseNumber = source.RentersLicenseNumber,
                RentersName = source.RentersName,
                SpecialDiscountPerc = source.SpecialDiscountPerc,
                StandardDiscount = source.StandardDiscount,
                TotalAdditionalCharge = source.TotalAdditionalCharge,
                TotalDriverCharge = source.TotalDriverCharge,
                TotalDropOffCharge = source.TotalDropOffCharge,
                TotalExcessMileageCharge = source.TotalExcessMileageCharge,
                TotalInsuranceCharge = source.TotalInsuranceCharge,
                TotalOtherCharge = source.TotalOtherCharge,
                TotalServiceCharge = source.TotalServiceCharge,
                TotalVehicleCharge = source.TotalVehicleCharge,
                VoucherDiscount = source.VoucherDiscount
            };

            if (source.BusinessPartner != null)
            {
                raMain.BusinessPartner = source.BusinessPartner.CreateFrom();
            }

            return raMain;
        }

        #endregion

    }
}
