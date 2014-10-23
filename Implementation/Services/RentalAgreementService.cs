using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Cares.ExceptionHandling;
using Cares.Interfaces.Helpers;
using Cares.Interfaces.IServices;
using Cares.Interfaces.Repository;
using Cares.Models.Common;
using Cares.Models.DomainModels;
using Cares.Models.ResponseModels;

namespace Cares.Implementation.Services
{
    /// <summary>
    /// Rental Agreement ervice
    /// </summary>
    public class RentalAgreementService : IRentalAgreementService
    {
        //#region Private

        //private readonly IPaymentTermRepository paymentTermRepository;
        //private readonly IOperationRepository operationRepository;
        //private readonly IOperationsWorkPlaceRepository operationsWorkPlaceRepository;
        //private readonly ITariffTypeRepository tariffTypeRepository;
        //private readonly IBill bill;
        //private readonly IVehicleStatusRepository vehicleStatusRepository;
        //private readonly IAlloactionStatusRepository alloactionStatusRepository;
        //private readonly IRentalAgreementRepository rentalAgreementRepository;
        //private readonly IBusinessPartnerRepository businessPartnerRepository;
        //private readonly IAddressRepository businessPartnerAddressRepository;
        //private readonly IVehicleRepository vehicleRepository;
        //private readonly IPaymentModeRepository paymentModeRepository;
        //private readonly IRaStatusRepository raStatusRepository;
        //private readonly IBookingMainRepository bookingMainRepository;

        ///// <summary>
        ///// Add Vehicle Movements
        ///// </summary>
        //private void AddVehicleMovements(RaHireGroup raHireGroup)
        //{
        //    foreach (VehicleMovement vehicleMovement in raHireGroup.VehicleMovements)
        //    {
        //        vehicleMovement.IsActive = true;
        //        vehicleMovement.RecCreatedBy =
        //            vehicleMovement.RecLastUpdatedBy = rentalAgreementRepository.LoggedInUserIdentity;
        //        vehicleMovement.RecCreatedDt = vehicleMovement.RecLastUpdatedDt = DateTime.Now;
        //        vehicleMovement.RowVersion = 0;
        //        vehicleMovement.UserDomainKey = rentalAgreementRepository.UserDomainKey;
        //    }
        //}

        ///// <summary>
        ///// Add Ra Vehicle Checklists
        ///// </summary>
        //private void AddRaVehicleCheckLists(IEnumerable<RaVehicleCheckList> raVehicleCheckLists)
        //{
        //    foreach (RaVehicleCheckList raVehicleCheckList in raVehicleCheckLists)
        //    {
        //        raVehicleCheckList.IsActive = true;
        //        raVehicleCheckList.RecCreatedBy =
        //            raVehicleCheckList.RecLastUpdatedBy = rentalAgreementRepository.LoggedInUserIdentity;
        //        raVehicleCheckList.RecCreatedDt = raVehicleCheckList.RecLastUpdatedDt = DateTime.Now;
        //        raVehicleCheckList.RowVersion = 0;
        //        raVehicleCheckList.UserDomainKey = rentalAgreementRepository.UserDomainKey;
        //    }
        //}

        ///// <summary>
        ///// Add Ra HireGroup Discounts
        ///// </summary>
        //private void AddRaHireGroupDiscounts(IEnumerable<RaHireGroupDiscount> raHireGroupDiscounts)
        //{
        //    foreach (RaHireGroupDiscount raHireGroupDiscount in raHireGroupDiscounts)
        //    {
        //        raHireGroupDiscount.IsActive = true;
        //        raHireGroupDiscount.RecCreatedBy =
        //            raHireGroupDiscount.RecLastUpdatedBy = rentalAgreementRepository.LoggedInUserIdentity;
        //        raHireGroupDiscount.RecCreatedDt = raHireGroupDiscount.RecLastUpdatedDt = DateTime.Now;
        //        raHireGroupDiscount.RowVersion = 0;
        //        raHireGroupDiscount.UserDomainKey = rentalAgreementRepository.UserDomainKey;
        //    }
        //}

        ///// <summary>
        ///// Add RaHireGroup Insurances
        ///// </summary>
        //private void AddRaHireGroupInsurances(IEnumerable<RaHireGroupInsurance> raHireGroupInsurances)
        //{
        //    foreach (RaHireGroupInsurance raHireGroupInsurance in raHireGroupInsurances)
        //    {
        //        raHireGroupInsurance.IsActive = true;
        //        raHireGroupInsurance.RecCreatedBy =
        //            raHireGroupInsurance.RecLastUpdatedBy = rentalAgreementRepository.LoggedInUserIdentity;
        //        raHireGroupInsurance.RecCreatedDt = raHireGroupInsurance.RecLastUpdatedDt = DateTime.Now;
        //        raHireGroupInsurance.RowVersion = 0;
        //        raHireGroupInsurance.UserDomainKey = rentalAgreementRepository.UserDomainKey;
        //    }
        //}

        ///// <summary>
        ///// Add RaHireGroups
        ///// </summary>
        //private void AddRaHireGroups(IEnumerable<RaHireGroup> raHireGroups)
        //{
        //    foreach (RaHireGroup raHireGroup in raHireGroups)
        //    {
        //        // Set Required Fields 
        //        raHireGroup.IsActive = true;
        //        raHireGroup.RecCreatedBy =
        //            raHireGroup.RecLastUpdatedBy = rentalAgreementRepository.LoggedInUserIdentity;
        //        raHireGroup.RecCreatedDt = raHireGroup.RecLastUpdatedDt = DateTime.Now;
        //        raHireGroup.RowVersion = 0;
        //        raHireGroup.UserDomainKey = rentalAgreementRepository.UserDomainKey;

        //        // Ra Hire Group Insurances
        //        AddRaHireGroupInsurances(raHireGroup.RaHireGroupInsurances);

        //        // Ra Hire Group Discounts
        //        AddRaHireGroupDiscounts(raHireGroup.RaHireGroupDiscounts);

        //        // Ra Vehicle Check Lists
        //        AddRaVehicleCheckLists(raHireGroup.RaVehicleCheckLists);

        //        // Vehicle Movements
        //        AddVehicleMovements(raHireGroup);

        //        // Find Vehicle By Id
        //        Vehicle vehicle = GetVehicle(raHireGroup);

        //        if (vehicle == null)
        //        {
        //            return;
        //        }

        //        // Add Vehicle Reservations
        //        AddVehicleReservation(raHireGroup, vehicle);

        //        // Update Vehicle Status Out
        //        UpdateVehicleStatusOut(raHireGroup, vehicle);
        //    }
        //}

        ///// <summary>
        ///// Get Vehicle
        ///// </summary>
        //private Vehicle GetVehicle(RaHireGroup raHireGroup)
        //{
        //    // Add Vehicle Reservation and Update Vehicle Status
        //    if (!raHireGroup.VehicleId.HasValue || raHireGroup.VehicleId.Value <= 0)
        //    {
        //        return null;
        //    }

        //    Vehicle vehicle = vehicleRepository.Find(raHireGroup.VehicleId.Value);

        //    if (vehicle == null)
        //    {
        //        throw new CaresException(string.Format(CultureInfo.InvariantCulture,
        //            Resources.RentalAgreement.RentalAgreement.VehicleNotFound, raHireGroup.VehicleId.Value));
        //    }

        //    return vehicle;
        //}

        ///// <summary>
        ///// Update Vehicle Status Out
        ///// </summary>
        //private void UpdateVehicleStatusOut(RaHireGroup raHireGroup, Vehicle vehicle)
        //{
        //    VehicleMovement vehicleMovementOut =
        //        raHireGroup.VehicleMovements.FirstOrDefault(vm => vm.Status == Convert.ToBoolean(VehicleMovementEnum.Out));

        //    if (vehicleMovementOut == null || !vehicleMovementOut.VehicleStatusId.HasValue)
        //    {
        //        return;
        //    }

        //    UpdateVehicle(vehicle, vehicleMovementOut.VehicleStatusId.Value);
        //}

        ///// <summary>
        ///// Update Vehicle
        ///// </summary>
        //private void UpdateVehicle(Vehicle vehicle, short vehicleStatusId)
        //{
        //    vehicle.VehicleStatusId = vehicleStatusId;
        //    vehicle.RowVersion = vehicle.RowVersion + 1;
        //    vehicle.RecLastUpdatedBy = rentalAgreementRepository.LoggedInUserIdentity;
        //    vehicle.RecLastUpdatedDt = DateTime.Now;
        //}

        ///// <summary>
        ///// Update Vehicle Status In
        ///// </summary>
        //private void UpdateVehicleStatusIn(Vehicle vehicle, VehicleMovement vehicleMovementIn)
        //{

        //    if (vehicleMovementIn == null || !vehicleMovementIn.VehicleStatusId.HasValue)
        //    {
        //        return;
        //    }

        //    UpdateVehicle(vehicle, vehicleMovementIn.VehicleStatusId.Value);
        //}

        ///// <summary>
        ///// Adds Vehicle Reservation
        ///// </summary>
        //private void AddVehicleReservation(RaHireGroup raHireGroup, Vehicle vehicle)
        //{

        //    // Check For Vehicle Reservations 
        //    if (vehicle.VehicleReservations == null)
        //    {
        //        vehicle.VehicleReservations = new List<VehicleReservation>();
        //    }

        //    // Get Vehicle Movements
        //    VehicleMovement vehicleMovementOut =
        //        raHireGroup.VehicleMovements.FirstOrDefault(vm => vm.Status == Convert.ToBoolean(VehicleMovementEnum.Out));
        //    VehicleMovement vehicleMovementIn =
        //        raHireGroup.VehicleMovements.FirstOrDefault(vm => vm.Status == Convert.ToBoolean(VehicleMovementEnum.In));

        //    if (vehicleMovementIn != null && vehicleMovementOut != null)
        //    {
        //        vehicle.VehicleReservations.Add(CreateVehicleReservation(raHireGroup.RaMainId, vehicleMovementOut.DtTime, vehicleMovementIn.DtTime, vehicle.VehicleId));
        //    }
        //}

        ///// <summary>
        ///// Creates New Vehicle Reservation
        ///// </summary>
        //private VehicleReservation CreateVehicleReservation(long raMainId, DateTime startDt, DateTime endDt, long vehicleId)
        //{
        //    return new VehicleReservation
        //    {
        //        StartDtTime = startDt,
        //        EndDtTime = endDt,
        //        VehicleId = vehicleId,
        //        RaMainId = raMainId,
        //        IsActive = true,
        //        RecCreatedBy = rentalAgreementRepository.LoggedInUserIdentity,
        //        RecLastUpdatedBy = rentalAgreementRepository.LoggedInUserIdentity,
        //        RecCreatedDt = DateTime.Now,
        //        RecLastUpdatedDt = DateTime.Now,
        //        RowVersion = 0,
        //        UserDomainKey = rentalAgreementRepository.UserDomainKey
        //    };
        //}

        ///// <summary>
        ///// Add Ra Additional Charges
        ///// </summary>
        //private void AddRaAdditionalCharges(IEnumerable<RaAdditionalCharge> raAdditionalCharges)
        //{
        //    foreach (RaAdditionalCharge raAdditionalCharge in raAdditionalCharges)
        //    {
        //        // Set Required Fields 
        //        raAdditionalCharge.IsActive = true;
        //        raAdditionalCharge.RecCreatedBy =
        //            raAdditionalCharge.RecLastUpdatedBy = rentalAgreementRepository.LoggedInUserIdentity;
        //        raAdditionalCharge.RecCreatedDt = raAdditionalCharge.RecLastUpdatedDt = DateTime.Now;
        //        raAdditionalCharge.RowVersion = 0;
        //        raAdditionalCharge.UserDomainKey = rentalAgreementRepository.UserDomainKey;
        //    }
        //}

        ///// <summary>
        ///// Add Ra Service Items
        ///// </summary>
        //private void AddRaServiceItems(IEnumerable<RaServiceItem> raServiceItems)
        //{
        //    foreach (RaServiceItem raServiceItem in raServiceItems)
        //    {
        //        // Set Required Fields 
        //        raServiceItem.IsActive = true;
        //        raServiceItem.RecCreatedBy =
        //            raServiceItem.RecLastUpdatedBy = rentalAgreementRepository.LoggedInUserIdentity;
        //        raServiceItem.RecCreatedDt = raServiceItem.RecLastUpdatedDt = DateTime.Now;
        //        raServiceItem.RowVersion = 0;
        //        raServiceItem.UserDomainKey = rentalAgreementRepository.UserDomainKey;
        //    }
        //}

        ///// <summary>
        ///// Add Ra Drivers
        ///// </summary>
        //private void AddRaDrivers(IEnumerable<RaDriver> raDrivers)
        //{
        //    foreach (RaDriver raDriver in raDrivers)
        //    {
        //        // Set Required Fields 
        //        raDriver.IsActive = true;
        //        raDriver.RecCreatedBy =
        //            raDriver.RecLastUpdatedBy = rentalAgreementRepository.LoggedInUserIdentity;
        //        raDriver.RecCreatedDt = raDriver.RecLastUpdatedDt = DateTime.Now;
        //        raDriver.RowVersion = 0;
        //        raDriver.UserDomainKey = rentalAgreementRepository.UserDomainKey;
        //    }
        //}

        ///// <summary>
        ///// Add Ra Payments
        ///// </summary>
        //private void AddRaPayments(IEnumerable<RaPayment> raPayments)
        //{
        //    foreach (RaPayment raPayment in raPayments)
        //    {
        //        // Set Required Fields 
        //        raPayment.IsActive = true;
        //        raPayment.RecCreatedBy =
        //            raPayment.RecLastUpdatedBy = rentalAgreementRepository.LoggedInUserIdentity;
        //        raPayment.RecCreatedDt = raPayment.RecLastUpdatedDt = DateTime.Now;
        //        raPayment.RowVersion = 0;
        //        raPayment.UserDomainKey = rentalAgreementRepository.UserDomainKey;
        //    }
        //}

        ///// <summary>
        ///// Add Ra Customer Documents
        ///// </summary>
        //private void AddRaCustomerDocuments(IEnumerable<RaCustomerDocument> raCustomerDocuments)
        //{
        //    foreach (RaCustomerDocument raCustomerDocument in raCustomerDocuments)
        //    {
        //        // Set Required Fields 
        //        raCustomerDocument.IsActive = true;
        //        raCustomerDocument.RecCreatedBy =
        //            raCustomerDocument.RecLastUpdatedBy = rentalAgreementRepository.LoggedInUserIdentity;
        //        raCustomerDocument.RecCreatedDt = raCustomerDocument.RecLastUpdatedDt = DateTime.Now;
        //        raCustomerDocument.RowVersion = 0;
        //        raCustomerDocument.UserDomainKey = rentalAgreementRepository.UserDomainKey;
        //    }
        //}

        ///// <summary>
        ///// Update Ra Main Header
        ///// </summary>
        //private void UpdateRaMainHeader(RaMain raMain, RaMain raMainDbVersion)
        //{
        //    raMainDbVersion.StartDtTime = raMain.StartDtTime;
        //    raMainDbVersion.EndDtTime = raMain.EndDtTime;
        //    raMainDbVersion.OpenLocation = raMain.OpenLocation;
        //    raMainDbVersion.CloseLocation = raMain.CloseLocation;
        //    raMainDbVersion.AmountPaid = raMain.AmountPaid;
        //    raMainDbVersion.Balance = raMain.Balance;
        //    raMainDbVersion.IsSpecialDiscountPerc = raMain.IsSpecialDiscountPerc;
        //    raMainDbVersion.VoucherDiscount = raMain.VoucherDiscount;
        //    raMainDbVersion.TotalVehicleCharge = raMain.TotalVehicleCharge;
        //    raMainDbVersion.TotalServiceCharge = raMain.TotalServiceCharge;
        //    raMainDbVersion.TotalOtherCharge = raMain.TotalOtherCharge;
        //    raMainDbVersion.TotalInsuranceCharge = raMain.TotalInsuranceCharge;
        //    raMainDbVersion.TotalExcessMileageCharge = raMain.TotalExcessMileageCharge;
        //    raMainDbVersion.TotalDropOffCharge = raMain.TotalDropOffCharge;
        //    raMainDbVersion.TotalDriverCharge = raMain.TotalDriverCharge;
        //    raMainDbVersion.TotalAdditionalCharge = raMain.TotalAdditionalCharge;
        //    raMainDbVersion.StandardDiscount = raMain.SeasonalDiscount;
        //    raMainDbVersion.SpecialDiscount = raMain.SpecialDiscount;
        //    raMainDbVersion.SpecialDiscountPerc = raMain.SpecialDiscountPerc;
        //    raMainDbVersion.NetBillAfterDiscount = raMain.NetBillAfterDiscount;
        //    raMainDbVersion.PaymentTermId = raMain.PaymentTermId;

        //    short statusId = raMainDbVersion.Balance > 0 ? (short) RaStatusEnum.PaymentPending : raMain.RaStatusId;
        //    RaStatus status = raStatusRepository.FindByStatusKey(statusId);

        //    if (status == null)
        //    {
        //        throw new CaresException(string.Format(CultureInfo.InvariantCulture, 
        //            Resources.RentalAgreement.RentalAgreement.RentalAgreementService_RaStatusNotFound,
        //           (short)RaStatusEnum.PaymentPending));
        //    }

        //    raMainDbVersion.RaStatusId = raMain.RaStatusId;
        //}

        ///// <summary>
        ///// Add Business Partner
        ///// </summary>
        //private void AddBusinessPartner(BusinessPartner businessPartner)
        //{
        //    if (ValidateBusinessPartner(businessPartner))
        //    {
        //        //set master (business partner) properties
        //        #region Business Partner
        //        SetBusinessPartnerRequiredFields(businessPartner);
        //        #endregion

        //        //set child (business partner individual) properties
        //        #region Business Partner Individual

        //        AddBusinessPartnerIndividual(businessPartner);

        //        #endregion

        //        //set child (business partner company) properties
        //        #region Business Partner Company
        //        AddBusinessPartnerCompany(businessPartner);

        //        #endregion

        //        //set child (business partner phones) properties
        //        #region Business Partner Phones
        //        // set properties
        //        AddBusinessPartnerPhones(businessPartner);
        //        #endregion

        //        //set child (business partner address) properties
        //        #region Business Partner Address
        //        // set properties
        //        AddBusinessPartnerAddress(businessPartner);
        //        #endregion

        //    }
        //    else
        //    {
        //        throw new InvalidOperationException("Business Partner with this name already exists");
        //    }
        //}

        ///// <summary>
        ///// Add Business Partner Address
        ///// </summary>
        //private void AddBusinessPartnerAddress(BusinessPartner businessPartner)
        //{
        //    foreach (Address item in businessPartner.BusinessPartnerAddressList)
        //    {
        //        item.IsActive = true;
        //        item.RecCreatedDt = item.RecLastUpdatedDt = DateTime.Now;
        //        item.RecCreatedBy = item.RecLastUpdatedBy = businessPartnerRepository.LoggedInUserIdentity;
        //        item.RowVersion = 0;
        //        item.UserDomainKey = businessPartnerRepository.UserDomainKey;
        //    }
        //}

        ///// <summary>
        ///// Add Business Partner Phones
        ///// </summary>
        //private void AddBusinessPartnerPhones(BusinessPartner businessPartner)
        //{
        //    foreach (Phone item in businessPartner.BusinessPartnerPhoneNumbers)
        //    {
        //        item.IsActive = true;
        //        item.RecCreatedDt = item.RecLastUpdatedDt = DateTime.Now;
        //        item.RecCreatedBy = item.RecLastUpdatedBy = businessPartnerRepository.LoggedInUserIdentity;
        //        item.RowVersion = 0;
        //        item.UserDomainKey = businessPartnerRepository.UserDomainKey;
        //    }
        //}

        ///// <summary>
        ///// Add Business Partner Company
        ///// </summary>
        //private void AddBusinessPartnerCompany(BusinessPartner businessPartner)
        //{
        //    if (businessPartner.IsIndividual)
        //    {
        //        businessPartner.BusinessPartnerCompany.BusinessPartnerCompanyCode =
        //            businessPartner.BusinessPartnerIndividual.FirstName;
        //    }

        //    businessPartner.BusinessPartnerCompany.RecCreatedBy =
        //        businessPartner.BusinessPartnerCompany.RecLastUpdatedBy =
        //            businessPartnerRepository.LoggedInUserIdentity;
        //    businessPartner.BusinessPartnerCompany.RecCreatedDt =
        //        businessPartner.BusinessPartnerCompany.RecLastUpdatedDt =
        //            DateTime.Now;
        //    businessPartner.BusinessPartnerCompany.RecLastUpdatedBy =
        //        businessPartner.BusinessPartnerCompany.RecCreatedBy =
        //            businessPartnerRepository.LoggedInUserIdentity;
        //    businessPartner.BusinessPartnerCompany.UserDomainKey = businessPartnerRepository.UserDomainKey;
        //}

        ///// <summary>
        ///// Add Business Partner Individual
        ///// </summary>
        //private void AddBusinessPartnerIndividual(BusinessPartner businessPartner)
        //{
        //    if (businessPartner.BusinessPartnerIndividual.FirstName == null)
        //    {
        //        businessPartner.BusinessPartnerIndividual.FirstName = string.Empty;
        //    }

        //    if (businessPartner.BusinessPartnerIndividual.LastName == null)
        //    {
        //        businessPartner.BusinessPartnerIndividual.LastName = string.Empty;
        //    }

        //    businessPartner.BusinessPartnerIndividual.RecCreatedBy =
        //        businessPartner.BusinessPartnerIndividual.RecLastUpdatedBy =
        //            businessPartnerRepository.LoggedInUserIdentity;
        //    businessPartner.BusinessPartnerIndividual.RecCreatedDt =
        //        businessPartner.BusinessPartnerIndividual.RecLastUpdatedDt = DateTime.Now;
        //    businessPartner.BusinessPartnerIndividual.UserDomainKey = businessPartnerRepository.UserDomainKey;
        //}

        ///// <summary>
        ///// Set Business Partner Basic Fields
        ///// </summary>
        //private void SetBusinessPartnerRequiredFields(BusinessPartner businessPartner)
        //{
        //    businessPartner.BusinessPartnerCode = "RA-Screen";
        //    businessPartner.CompanyId = 1; // Need to Set Company Id from db
        //    businessPartner.UserDomainKey = rentalAgreementRepository.UserDomainKey;
        //    businessPartner.IsActive = true;
        //    businessPartner.RecCreatedDt = businessPartner.RecLastUpdatedDt = DateTime.Now;
        //    businessPartner.RecCreatedBy = businessPartner.RecLastUpdatedBy = rentalAgreementRepository.LoggedInUserIdentity;
        //    businessPartner.RowVersion = 0;
        //}

        ///// <summary>
        ///// Validate Business Partner
        ///// </summary>
        //private bool ValidateBusinessPartner(BusinessPartner businessPartner)
        //{
        //    BusinessPartner businessPartnerDbVersion = businessPartnerRepository.GetBusinessPartnerByName(businessPartner.BusinessPartnerName,
        //        (int)businessPartner.BusinessPartnerId);
        //    return businessPartnerDbVersion == null;
        //}

        ///// <summary>
        ///// Update Ra Hire Groups
        ///// </summary>
        //private void UpdateRaHireGroups(RaMain raMain, RaMain raMainDbVersion)
        //{
        //    // Add New
        //    List<RaHireGroup> raHireGroups = raMain.RaHireGroups.Where(hg => hg.RaHireGroupId == 0).ToList();
        //    raHireGroups.ForEach(raHireGroup => raMainDbVersion.RaHireGroups.Add(raHireGroup));

        //    AddRaHireGroups(raHireGroups);

        //    // Remove 
        //    DeleteRaHireGroups(raMain, raMainDbVersion);

        //    // Update Existing
        //    UpdateRaHireGroupsExisting(raMain, raMainDbVersion);
        //}

        ///// <summary>
        ///// Update Existing Ra Hire Groups
        ///// </summary>
        //private void UpdateRaHireGroupsExisting(RaMain raMain, RaMain raMainDbVersion)
        //{
        //    foreach (RaHireGroup raHireGroup in raMain.RaHireGroups)
        //    {
        //        RaHireGroup raHireGroupDbVersion =
        //            raMainDbVersion.RaHireGroups.FirstOrDefault(hg => hg.RaHireGroupId == raHireGroup.RaHireGroupId && hg.RaHireGroupId > 0);

        //        VehicleMovement vehicleMovementIn = raHireGroup.VehicleMovements.FirstOrDefault(vm => vm.Status == Convert.ToBoolean(VehicleMovementEnum.In));

        //        if (raHireGroupDbVersion == null)
        //        {
        //            throw new CaresException(string.Format(CultureInfo.InvariantCulture,
        //                Resources.RentalAgreement.RentalAgreement.RaHireGroupNotFound, raHireGroup.RaHireGroupId));
        //        }

        //        // Update Main
        //        UpdateRaHireGroupExistingHeader(raHireGroupDbVersion, raHireGroup);

        //        // Update Ra Hire Group Insurances
        //        UpdateRaHireGroupInsurances(raHireGroup, raHireGroupDbVersion);

        //        // Update Vehicle Movements
        //        UpdateVehicleMovementInDetails(raHireGroupDbVersion, vehicleMovementIn);

        //        // Update Ra Hire Group Discounts
        //        UpdateRaHireGroupDiscounts(raHireGroup, raHireGroupDbVersion);

        //        // Update Ra Vehicle CheckLists
        //        UpdateRaVehicleCheckLists(raHireGroup, raHireGroupDbVersion);

        //        // Update Vehicle Reservation
        //        UpdateVehicleReservation(raHireGroupDbVersion, vehicleMovementIn);

        //        // Update Vehicle Status
        //        UpdateVehicleStatusIn(raHireGroupDbVersion.Vehicle, vehicleMovementIn);
        //    }
        //}

        ///// <summary>
        ///// Update Ra Vehicle CheckLists
        ///// </summary>
        //private void UpdateRaVehicleCheckLists(RaHireGroup raHireGroup, RaHireGroup raHireGroupDbVersion)
        //{
        //    // Add
        //    AddRaVehicleCheckListToExistingRaHireGroup(raHireGroup, raHireGroupDbVersion);

        //    // Delete 
        //    DeleteRaVehicleCheckLists(raHireGroup, raHireGroupDbVersion);
        //}

        ///// <summary>
        ///// Delete Ra Vehicle Checklists
        ///// </summary>
        //private static void DeleteRaVehicleCheckLists(RaHireGroup raHireGroup, RaHireGroup raHireGroupDbVersion)
        //{
        //    List<RaVehicleCheckList> vehicleCheckListsToDelete =
        //        raHireGroupDbVersion.RaVehicleCheckLists.Where(
        //            chk =>
        //                raHireGroup.RaVehicleCheckLists.All(
        //                    vch => vch.RaVehicleCheckListId != chk.RaVehicleCheckListId)).ToList();
        //    vehicleCheckListsToDelete.ForEach(vch => raHireGroupDbVersion.RaVehicleCheckLists.Remove(vch));
        //}

        ///// <summary>
        ///// Add Vehicle CheckList To Existing RaHireGroup
        ///// </summary>
        //private void AddRaVehicleCheckListToExistingRaHireGroup(RaHireGroup raHireGroup, RaHireGroup raHireGroupDbVersion)
        //{
        //    List<RaVehicleCheckList> vehicleCheckListsToAdd =
        //        raHireGroup.RaVehicleCheckLists.Where(ch => ch.RaVehicleCheckListId == 0).ToList();

        //    vehicleCheckListsToAdd.ForEach(vch => raHireGroupDbVersion.RaVehicleCheckLists.Add(vch));

        //    AddRaVehicleCheckLists(vehicleCheckListsToAdd);
        //}

        ///// <summary>
        ///// Update Ra Hire Group Discounts
        ///// </summary>
        //private void UpdateRaHireGroupDiscounts(RaHireGroup raHireGroup, RaHireGroup raHireGroupDbVersion)
        //{
        //    // Update Ra Hire Group Discounts
        //    // Add Discounts
        //    AddRaHireGroupDiscountForExistingRaHireGroup(raHireGroup, raHireGroupDbVersion);

        //    // Delete Discounts
        //    DeleteRaHireGroupDiscounts(raHireGroup, raHireGroupDbVersion);
        //}

        ///// <summary>
        ///// Delete HireGroup Discounts
        ///// </summary>
        //private static void DeleteRaHireGroupDiscounts(RaHireGroup raHireGroup, RaHireGroup raHireGroupDbVersion)
        //{
        //    List<RaHireGroupDiscount> discountsToDelete =
        //        raHireGroupDbVersion.RaHireGroupDiscounts.Where(
        //            discount =>
        //                raHireGroup.RaHireGroupDiscounts.All(
        //                    hg => hg.RaHireGroupDiscountId != discount.RaHireGroupDiscountId)).ToList();
        //    discountsToDelete.ForEach(discount => raHireGroupDbVersion.RaHireGroupDiscounts.Remove(discount));
        //}

        ///// <summary>
        ///// Add Discounts To Existing Ra HireGroup
        ///// </summary>
        //private void AddRaHireGroupDiscountForExistingRaHireGroup(RaHireGroup raHireGroup, RaHireGroup raHireGroupDbVersion)
        //{
        //    List<RaHireGroupDiscount> discountsToAdd =
        //        raHireGroup.RaHireGroupDiscounts.Where(discount => discount.RaHireGroupDiscountId == 0).ToList();

        //    // Check For Null
        //    if (raHireGroupDbVersion.RaHireGroupDiscounts == null)
        //    {
        //        raHireGroupDbVersion.RaHireGroupDiscounts = new List<RaHireGroupDiscount>();
        //    }

        //    discountsToAdd.ForEach(discount => raHireGroupDbVersion.RaHireGroupDiscounts.Add(discount));

        //    AddRaHireGroupDiscounts(discountsToAdd);
        //}

        ///// <summary>
        ///// Updates Vehicle Reservation
        ///// </summary>
        //private void UpdateVehicleReservation(RaHireGroup raHireGroupDbVersion, VehicleMovement vehicleMovementIn)
        //{
        //    if (raHireGroupDbVersion.Vehicle.VehicleReservations.Any())
        //    {
        //        if (vehicleMovementIn != null)
        //        {
        //            foreach (VehicleReservation vehicleReservation in raHireGroupDbVersion.Vehicle.VehicleReservations)
        //            {
        //                vehicleReservation.EndDtTime = vehicleMovementIn.DtTime;
        //                vehicleReservation.RecLastUpdatedBy = rentalAgreementRepository.LoggedInUserIdentity;
        //                vehicleReservation.RecLastUpdatedDt = DateTime.Now;
        //                vehicleReservation.RowVersion = vehicleReservation.RowVersion + 1;
        //            }
        //        }
        //    }
        //}

        ///// <summary>
        ///// Update Vehicle Movement In Details
        ///// </summary>
        //private void UpdateVehicleMovementInDetails(RaHireGroup raHireGroupDbVersion, VehicleMovement vehicleMovementIn)
        //{
        //    VehicleMovement vehicleMovementInDbVersion = raHireGroupDbVersion.VehicleMovements
        //        .FirstOrDefault(vm => vm.Status == Convert.ToBoolean(VehicleMovementEnum.In));

        //    if (vehicleMovementInDbVersion != null && vehicleMovementIn != null)
        //    {
        //        vehicleMovementInDbVersion.VehicleStatusId = vehicleMovementIn.VehicleStatusId;
        //        vehicleMovementInDbVersion.DtTime = vehicleMovementIn.DtTime;
        //        vehicleMovementInDbVersion.Odometer = vehicleMovementIn.Odometer;
        //        vehicleMovementInDbVersion.FuelLevel = vehicleMovementIn.FuelLevel;
        //        vehicleMovementInDbVersion.OperationsWorkPlaceId = vehicleMovementIn.OperationsWorkPlaceId;
        //        vehicleMovementInDbVersion.RowVersion = vehicleMovementInDbVersion.RowVersion + 1;
        //        vehicleMovementInDbVersion.RecLastUpdatedBy = rentalAgreementRepository.LoggedInUserIdentity;
        //        vehicleMovementInDbVersion.RecLastUpdatedDt = DateTime.Now;
        //    }
        //}

        ///// <summary>
        ///// Update Ra HireGroup Insurances
        ///// </summary>
        //private void UpdateRaHireGroupInsurances(RaHireGroup raHireGroup, RaHireGroup raHireGroupDbVersion)
        //{
        //    // Add New
        //    List<RaHireGroupInsurance> raHireGroupInsurancesToAdd =
        //        raHireGroup.RaHireGroupInsurances.Where(ins => ins.RaHireGroupInsuranceId == 0).ToList();
        //    raHireGroupInsurancesToAdd.ForEach(ins => raHireGroupDbVersion.RaHireGroupInsurances.Add(ins));
        //    AddRaHireGroupInsurances(raHireGroupInsurancesToAdd);

        //    // Delete 
        //    DeleteRaHireGroupInsurances(raHireGroup, raHireGroupDbVersion);

        //    // Update Existing
        //    UpdateRaHireGroupInsurancesExisting(raHireGroup, raHireGroupDbVersion);
        //}

        ///// <summary>
        ///// Update Ra HireGroup Insurances Existing
        ///// </summary>
        //private void UpdateRaHireGroupInsurancesExisting(RaHireGroup raHireGroup, RaHireGroup raHireGroupDbVersion)
        //{
        //    foreach (RaHireGroupInsurance raHireGroupInsurance in raHireGroup.RaHireGroupInsurances)
        //    {
        //        if (raHireGroupInsurance.RaHireGroupInsuranceId == 0)
        //        {
        //            continue;
        //        }

        //        RaHireGroupInsurance raHireGroupInsuranceDbVersion =
        //            raHireGroupDbVersion.RaHireGroupInsurances.FirstOrDefault(
        //                ins => ins.RaHireGroupInsuranceId == raHireGroupInsurance.RaHireGroupInsuranceId);

        //        if (raHireGroupInsuranceDbVersion == null)
        //        {
        //            throw new CaresException(string.Format(CultureInfo.InvariantCulture,
        //                Resources.RentalAgreement.RentalAgreement.RaHireGroupInsuranceNotFound,
        //                raHireGroupInsurance.RaHireGroupInsuranceId));
        //        }

        //        // Map Main
        //        raHireGroupInsuranceDbVersion.ChargedDay = raHireGroupInsurance.ChargedDay;
        //        raHireGroupInsuranceDbVersion.ChargedHour = raHireGroupInsurance.ChargedHour;
        //        raHireGroupInsuranceDbVersion.ChargedMinute = raHireGroupInsurance.ChargedMinute;
        //        raHireGroupInsuranceDbVersion.StartDtTime = raHireGroupInsurance.StartDtTime;
        //        raHireGroupInsuranceDbVersion.EndDtTime = raHireGroupInsurance.EndDtTime;
        //        raHireGroupInsuranceDbVersion.InsuranceCharge = raHireGroupInsurance.InsuranceCharge;
        //        raHireGroupInsuranceDbVersion.InsuranceRate = raHireGroupInsurance.InsuranceRate;
        //        raHireGroupInsuranceDbVersion.InsuranceTypeId = raHireGroupInsurance.InsuranceTypeId;
        //        raHireGroupInsuranceDbVersion.TariffType = raHireGroupInsurance.TariffType;
        //        raHireGroupInsuranceDbVersion.RowVersion = raHireGroupInsurance.RowVersion + 1;
        //        raHireGroupInsuranceDbVersion.RecLastUpdatedBy = rentalAgreementRepository.LoggedInUserIdentity;
        //        raHireGroupInsuranceDbVersion.RecLastUpdatedDt = DateTime.Now;
        //    }
        //}

        ///// <summary>
        ///// Delete RaHireGroup Insurances
        ///// </summary>
        //private static void DeleteRaHireGroupInsurances(RaHireGroup raHireGroup, RaHireGroup raHireGroupDbVersion)
        //{
        //    List<RaHireGroupInsurance> raHireGroupInsurancesToDelete = raHireGroupDbVersion.RaHireGroupInsurances
        //        .Where(raHireGroupInsurance =>
        //            raHireGroup.RaHireGroupInsurances.All(
        //                raHgIns => raHgIns.RaHireGroupInsuranceId != raHireGroupInsurance.RaHireGroupInsuranceId)).ToList();
        //    raHireGroupInsurancesToDelete.ForEach(ins => raHireGroupDbVersion.RaHireGroupInsurances.Remove(ins));
        //}

        ///// <summary>
        ///// Update RaHireGroup Existing Header Info
        ///// </summary>
        //private void UpdateRaHireGroupExistingHeader(RaHireGroup raHireGroupDbVersion, RaHireGroup raHireGroup)
        //{
        //    raHireGroupDbVersion.AllocationStatusId = raHireGroup.AllocationStatusId;
        //    raHireGroupDbVersion.VehicleId = raHireGroup.VehicleId;
        //    raHireGroupDbVersion.TotalExcMileage = raHireGroup.TotalExcMileage;
        //    raHireGroupDbVersion.AllowedMileage = raHireGroup.AllowedMileage;
        //    raHireGroupDbVersion.DropOffCharge = raHireGroup.DropOffCharge;
        //    raHireGroupDbVersion.ExcessMileageRt = raHireGroup.ExcessMileageRt;
        //    raHireGroupDbVersion.TotalExcMileageCharge = raHireGroup.TotalExcMileageCharge;
        //    raHireGroupDbVersion.ChargedDay = raHireGroup.ChargedDay;
        //    raHireGroupDbVersion.ChargedHour = raHireGroup.ChargedHour;
        //    raHireGroupDbVersion.ChargedMinute = raHireGroup.ChargedMinute;
        //    raHireGroupDbVersion.TotalStandardCharge = raHireGroup.TotalStandardCharge;
        //    raHireGroupDbVersion.TariffTypeCode = raHireGroup.TariffTypeCode;
        //    raHireGroupDbVersion.RentalChargeEndDate = raHireGroup.RentalChargeEndDate;
        //    raHireGroupDbVersion.StandardRate = raHireGroup.StandardRate;
        //    raHireGroupDbVersion.RentalChargeStartDate = raHireGroup.RentalChargeStartDate;
        //    raHireGroupDbVersion.RecLastUpdatedBy = rentalAgreementRepository.LoggedInUserIdentity;
        //    raHireGroupDbVersion.RecLastUpdatedDt = DateTime.Now;
        //    raHireGroupDbVersion.RowVersion = raHireGroupDbVersion.RowVersion + 1;
        //}

        ///// <summary>
        ///// Delete Ra HireGroups
        ///// </summary>
        //private static void DeleteRaHireGroups(RaMain raMain, RaMain raMainDbVersion)
        //{
        //    List<RaHireGroup> raHireGroupsToRemove = new List<RaHireGroup>();
        //    raHireGroupsToRemove.AddRange(from raHireGroup in raMainDbVersion.RaHireGroups
        //                                  let @group = raHireGroup
        //                                  where
        //                                      raMain.RaHireGroups.All(hg => hg.RaHireGroupId != @group.RaHireGroupId)
        //                                  select raHireGroup);
        //    raHireGroupsToRemove.ForEach(raHireGroup => raMainDbVersion.RaHireGroups.Remove(raHireGroup));
        //}

        ///// <summary>
        ///// Update business partner
        ///// </summary>
        //private void UpdateBusinessPartner(BusinessPartner businessPartner)
        //{
        //    BusinessPartner businessPartnerDbVersion = businessPartnerRepository.Find(businessPartner.BusinessPartnerId);

        //    if (businessPartnerDbVersion == null)
        //    {
        //        throw new CaresException(string.Format(CultureInfo.InvariantCulture, Resources.RentalAgreement.RentalAgreement.BusinessPartnerNotFound,
        //            businessPartner.BusinessPartnerId));
        //    }

        //    //set master(business partner) properties
        //    #region Business Partner
        //    businessPartnerDbVersion.BusinessPartnerName = businessPartner.BusinessPartnerName;
        //    businessPartnerDbVersion.IsIndividual = businessPartner.IsIndividual;
        //    businessPartnerDbVersion.BusinessPartnerEmailAddress = businessPartner.BusinessPartnerEmailAddress;
        //    businessPartnerDbVersion.PaymentTermId = businessPartner.PaymentTermId;

        //    businessPartnerDbVersion.RecLastUpdatedDt = DateTime.Now;
        //    businessPartnerDbVersion.RecLastUpdatedBy = businessPartnerRepository.LoggedInUserIdentity;
        //    businessPartnerDbVersion.RowVersion = businessPartnerDbVersion.RowVersion + 1;
        //    #endregion

        //    //set child (buiness partner individual properties)
        //    #region Business Partner Individual
        //    businessPartnerDbVersion.BusinessPartnerIndividual.FirstName = businessPartner.BusinessPartnerIndividual.FirstName ?? string.Empty;
        //    businessPartnerDbVersion.BusinessPartnerIndividual.LastName = businessPartner.BusinessPartnerIndividual.LastName ?? string.Empty;
        //    businessPartnerDbVersion.BusinessPartnerIndividual.DateOfBirth = businessPartner.BusinessPartnerIndividual.DateOfBirth;
        //    businessPartnerDbVersion.BusinessPartnerIndividual.NicNumber = businessPartner.BusinessPartnerIndividual.NicNumber;
        //    businessPartnerDbVersion.BusinessPartnerIndividual.NicExpiryDate = businessPartner.BusinessPartnerIndividual.NicExpiryDate;
        //    businessPartnerDbVersion.BusinessPartnerIndividual.PassportNumber = businessPartner.BusinessPartnerIndividual.PassportNumber;
        //    businessPartnerDbVersion.BusinessPartnerIndividual.PassportExpiryDate = businessPartner.BusinessPartnerIndividual.PassportExpiryDate;
        //    businessPartnerDbVersion.BusinessPartnerIndividual.PassportCountryId = businessPartner.BusinessPartnerIndividual.PassportCountryId;
        //    businessPartnerDbVersion.BusinessPartnerIndividual.LiscenseNumber = businessPartner.BusinessPartnerIndividual.LiscenseNumber;
        //    businessPartnerDbVersion.BusinessPartnerIndividual.LiscenseExpiryDate = businessPartner.BusinessPartnerIndividual.LiscenseExpiryDate;
        //    businessPartnerDbVersion.BusinessPartnerIndividual.RowVersion = businessPartnerDbVersion.BusinessPartnerIndividual.RowVersion + 1;
        //    businessPartnerDbVersion.BusinessPartnerIndividual.RecLastUpdatedDt = DateTime.Now;
        //    businessPartnerDbVersion.BusinessPartnerIndividual.RecLastUpdatedBy = businessPartnerRepository.LoggedInUserIdentity;
        //    #endregion

        //    //set child (buiness partner company properties)
        //    #region Business Partner Company
        //    businessPartnerDbVersion.BusinessPartnerCompany.BusinessPartnerCompanyCode =
        //        businessPartner.BusinessPartnerCompany.BusinessPartnerCompanyCode ?? string.Empty;
        //    businessPartnerDbVersion.BusinessPartnerCompany.BusinessPartnerCompanyName =
        //        businessPartner.BusinessPartnerCompany.BusinessPartnerCompanyName;

        //    businessPartnerDbVersion.BusinessPartnerCompany.RowVersion =
        //        businessPartnerDbVersion.BusinessPartnerCompany.RowVersion + 1;
        //    businessPartnerDbVersion.BusinessPartnerCompany.RecLastUpdatedDt = DateTime.Now;
        //    businessPartnerDbVersion.BusinessPartnerCompany.RecLastUpdatedBy = businessPartnerRepository.LoggedInUserIdentity;
        //    #endregion

        //    //set child (business partner phones)
        //    #region Business Partner Phones
        //    //add new phone items
        //    AddBusinessPartnerPhone(businessPartner, businessPartnerDbVersion);

        //    // Find existing phone items
        //    List<Phone> phoneItems = businessPartnerDbVersion.BusinessPartnerPhoneNumbers.Where(dbversionPhoneItem => businessPartner.BusinessPartnerPhoneNumbers.All(x => x.PhoneId == dbversionPhoneItem.PhoneId)).ToList();
        //    // Update phone items
        //    UpdateBusinessPartnerPhone(phoneItems, businessPartnerDbVersion);

        //    #endregion

        //    //set child (business partner address list)
        //    #region Business Partner Address List
        //    //add new address items
        //    AddBusinessPartnerAddress(businessPartner, businessPartnerDbVersion);

        //    // Delete 
        //    DeleteBusinessPartnerAddress(businessPartner, businessPartnerDbVersion);

        //    #endregion
        //}

        ///// <summary>
        ///// Delete Business Partner Address
        ///// </summary>
        //private void DeleteBusinessPartnerAddress(BusinessPartner businessPartner, BusinessPartner businessPartnerDbVersion)
        //{
        //    // Find existing address items
        //    List<Address> missingAddressItems =
        //        businessPartnerDbVersion.BusinessPartnerAddressList.Where(
        //            dbversionAddressItem =>
        //                businessPartner.BusinessPartnerAddressList.All(x => x.AddressId != dbversionAddressItem.AddressId))
        //            .ToList();
        //    //remove missing address items
        //    foreach (Address missingBusinessPartnerAddress in missingAddressItems)
        //    {
        //        Address dbVersionMissingAddressItem =
        //            businessPartnerDbVersion.BusinessPartnerAddressList.First(
        //                x => x.AddressId == missingBusinessPartnerAddress.AddressId);
        //        if (dbVersionMissingAddressItem.AddressId > 0)
        //        {
        //            businessPartnerDbVersion.BusinessPartnerAddressList.Remove(dbVersionMissingAddressItem);
        //            businessPartnerAddressRepository.Delete(dbVersionMissingAddressItem);
        //        }
        //    }
        //}

        ///// <summary>
        ///// Add Business Partner Address
        ///// </summary>
        //private void AddBusinessPartnerAddress(BusinessPartner businessPartner, BusinessPartner businessPartnerDbVersion)
        //{
        //    foreach (Address address in businessPartner.BusinessPartnerAddressList)
        //    {
        //        if (businessPartnerDbVersion.BusinessPartnerAddressList.All(x => x.AddressId != address.AddressId) ||
        //            address.AddressId == 0)
        //        {
        //            // set properties
        //            address.IsActive = true;
        //            address.RecCreatedDt = DateTime.Now;
        //            address.RecLastUpdatedDt = DateTime.Now;
        //            address.RecCreatedBy = businessPartnerRepository.LoggedInUserIdentity;
        //            address.RecLastUpdatedBy = businessPartnerRepository.LoggedInUserIdentity;
        //            address.RowVersion = 0;
        //            address.UserDomainKey = businessPartnerRepository.UserDomainKey;
        //            businessPartnerDbVersion.BusinessPartnerAddressList.Add(address);
        //        }
        //    }
        //}

        ///// <summary>
        ///// Update BusinessPartner Phone
        ///// </summary>
        //private void UpdateBusinessPartnerPhone(IEnumerable<Phone> missingPhoneItems, BusinessPartner businessPartnerDbVersion)
        //{
        //    foreach (Phone phone in missingPhoneItems)
        //    {
        //        Phone phoneItem = businessPartnerDbVersion.BusinessPartnerPhoneNumbers.First(x => x.PhoneId == phone.PhoneId);

        //        if (phoneItem == null)
        //        {
        //            throw new CaresException(string.Format(Resources.RentalAgreement.RentalAgreement.PhoneNotFound,
        //                phone.PhoneId));
        //        }

        //        phoneItem.PhoneNumber = phone.PhoneNumber;
        //        phoneItem.RecLastUpdatedBy = rentalAgreementRepository.LoggedInUserIdentity;
        //        phoneItem.RecLastUpdatedDt = DateTime.Now;
        //        phoneItem.RowVersion = phoneItem.RowVersion + 1;
        //    }
        //}

        ///// <summary>
        ///// Add Business Partner Phone
        ///// </summary>
        //private void AddBusinessPartnerPhone(BusinessPartner businessPartner, BusinessPartner businessPartnerDbVersion)
        //{
        //    foreach (Phone phone in businessPartner.BusinessPartnerPhoneNumbers)
        //    {
        //        if (businessPartnerDbVersion.BusinessPartnerPhoneNumbers.All(x => x.PhoneId != phone.PhoneId) ||
        //            phone.PhoneId == 0)
        //        {
        //            // set properties
        //            phone.IsActive = true;
        //            phone.RecCreatedDt = phone.RecLastUpdatedDt = DateTime.Now;
        //            phone.RecCreatedBy = phone.RecLastUpdatedBy = businessPartnerRepository.LoggedInUserIdentity;
        //            phone.RowVersion = 0;
        //            phone.UserDomainKey = businessPartnerRepository.UserDomainKey;
        //            businessPartnerDbVersion.BusinessPartnerPhoneNumbers.Add(phone);
        //        }
        //    }
        //}

        ///// <summary>
        ///// Map RaMain Header
        ///// </summary>
        //private void MapRaHeader(RaMain raMain)
        //{
        //    // Find Status For Ra By Key
        //    RaStatus status = raStatusRepository.FindByStatusKey(raMain.RaStatusId);

        //    if (status == null)
        //    {
        //        throw new CaresException(string.Format(CultureInfo.InvariantCulture,
        //            Resources.RentalAgreement.RentalAgreement.RentalAgreementService_RaStatusNotFound,
        //           (short)RaStatusEnum.Open));
        //    }
            
        //    raMain.RaStatusId = status.RaStatusId;
        //    raMain.RecCreatedBy = raMain.RecLastUpdatedBy = rentalAgreementRepository.LoggedInUserIdentity;
        //    raMain.RecLastUpdatedDt = raMain.RecCreatedDt;
        //    raMain.UserDomainKey = rentalAgreementRepository.UserDomainKey;
        //    raMain.IsActive = true;
        //    raMain.RowVersion = 0;
        //}

        ///// <summary>
        ///// Save Chauffer Reservations
        ///// </summary>
        //private void SaveChaufferReservation(RaMain raMain)
        //{
        //    List<RaDriver> chauffers =
        //        raMain.RaDrivers.Where(driver => driver.IsChauffer && driver.ChaufferId.HasValue && driver.RaDriverId == 0).ToList();

        //    // Check for Chauffer Reservation
        //    if (raMain.ChaufferReservations == null)
        //    {
        //        raMain.ChaufferReservations = new List<ChaufferReservation>();
        //    }

        //    foreach (RaDriver chauffer in chauffers)
        //    {
        //        raMain.ChaufferReservations.Add(CreateChaufferReservation(raMain, chauffer));
        //    }
        //}

        ///// <summary>
        ///// Create Chauffer Reservation
        ///// </summary>
        //private ChaufferReservation CreateChaufferReservation(RaMain raMain, RaDriver chauffer)
        //{
        //    return new ChaufferReservation
        //    {
        //        IsActive = true,
        //        RecCreatedDt = DateTime.Now,
        //        RecLastUpdatedDt = DateTime.Now,
        //        RecLastUpdatedBy = rentalAgreementRepository.LoggedInUserIdentity,
        //        RecCreatedBy = rentalAgreementRepository.LoggedInUserIdentity,
        //        RaMainId = raMain.RaMainId,
        //        ChaufferId = chauffer.ChaufferId ?? 0,
        //        StartDtTime = chauffer.StartDtTime,
        //        EndDtTime = chauffer.EndDtTime,
        //        RowVersion = 0,
        //        UserDomainKey = rentalAgreementRepository.UserDomainKey
        //    };
        //}

        ///// <summary>
        ///// Updates Ra Service Items
        ///// </summary>
        //private void UpdateRaServiceItems(RaMain raMain, RaMain raMainDbVersion)
        //{
        //    // Check for RaService Items
        //    if (raMainDbVersion.RaServiceItems == null)
        //    {
        //        raMainDbVersion.RaServiceItems = new List<RaServiceItem>();
        //    }

        //    // Add New
        //    AddRaServiceItemForExistingRa(raMain, raMainDbVersion);

        //    // Delete
        //    DeleteRaServiceItem(raMain, raMainDbVersion);

        //    // Update Existing
        //    UpdateRaServiceItemsExisting(raMain, raMainDbVersion);
        //}

        ///// <summary>
        ///// Add RaService Item For Existing RA
        ///// </summary>
        //private void AddRaServiceItemForExistingRa(RaMain raMain, RaMain raMainDbVersion)
        //{
        //    List<RaServiceItem> raServiceItemsToAdd =
        //        raMain.RaServiceItems.Where(serItem => serItem.RaServiceItemId == 0).ToList();
        //    raServiceItemsToAdd.ForEach(serItem => raMainDbVersion.RaServiceItems.Add(serItem));
        //    AddRaServiceItems(raServiceItemsToAdd);
        //}

        ///// <summary>
        ///// Delete Ra Additional Charges
        ///// </summary>
        //private static void DeleteRaServiceItem(RaMain raMain, RaMain raMainDbVersion)
        //{
        //    List<RaServiceItem> raServiceItemsToDelete =
        //        raMainDbVersion.RaServiceItems.Where(
        //            raSerItem =>
        //                raMain.RaServiceItems.All(
        //                    raServItem => raServItem.RaServiceItemId != raSerItem.RaServiceItemId)).ToList();
        //    raServiceItemsToDelete.ForEach(addChg => raMainDbVersion.RaServiceItems.Remove(addChg));
        //}

        ///// <summary>
        ///// Update Ra Service Items Existing
        ///// </summary>
        //private void UpdateRaServiceItemsExisting(RaMain raMain, RaMain raMainDbVersion)
        //{
        //    foreach (RaServiceItem raServiceItem in raMain.RaServiceItems)
        //    {
        //        if (raServiceItem.RaServiceItemId == 0)
        //        {
        //            continue;
        //        }

        //        RaServiceItem raServiceItemDbVersion = raMainDbVersion.RaServiceItems.FirstOrDefault(addChg =>
        //            addChg.RaServiceItemId == raServiceItem.RaServiceItemId);

        //        if (raServiceItemDbVersion == null)
        //        {
        //            throw new CaresException(string.Format(CultureInfo.InvariantCulture,
        //                Resources.RentalAgreement.RentalAgreement.RentalAgreementService_RaServiceItemNotFound,
        //                raServiceItem.RaServiceItemId));
        //        }

        //        UpdateRaServiceItemHeader(raServiceItemDbVersion, raServiceItem);
        //    }
        //}

        ///// <summary>
        ///// Update Ra Service Item Header
        ///// </summary>
        //private void UpdateRaServiceItemHeader(RaServiceItem raServiceItemDbVersion, RaServiceItem raServiceItem)
        //{
        //    raServiceItemDbVersion.Quantity = raServiceItem.Quantity;
        //    raServiceItemDbVersion.ServiceRate = raServiceItem.ServiceRate;
        //    raServiceItemDbVersion.ServiceCharge = raServiceItem.ServiceCharge;
        //    raServiceItemDbVersion.ChargedDay = raServiceItem.ChargedDay;
        //    raServiceItemDbVersion.ChargedHour = raServiceItem.ChargedHour;
        //    raServiceItemDbVersion.ChargedMinute = raServiceItem.ChargedMinute;
        //    raServiceItemDbVersion.TariffType = raServiceItem.TariffType;
        //    raServiceItemDbVersion.StartDtTime = raServiceItem.StartDtTime;
        //    raServiceItemDbVersion.EndDtTime = raServiceItem.EndDtTime;
        //    raServiceItemDbVersion.RecLastUpdatedBy = rentalAgreementRepository.LoggedInUserIdentity;
        //    raServiceItemDbVersion.RecLastUpdatedDt = DateTime.Now;
        //    raServiceItemDbVersion.RowVersion = raServiceItemDbVersion.RowVersion + 1;
        //}

        ///// <summary>
        ///// Updates Ra Additional Charges
        ///// </summary>
        //private void UpdateRaAdditionalCharges(RaMain raMain, RaMain raMainDbVersion)
        //{
        //    // Check for RaAdditoinalCharges
        //    if (raMainDbVersion.RaAdditionalCharges == null)
        //    {
        //        raMainDbVersion.RaAdditionalCharges = new List<RaAdditionalCharge>();
        //    }

        //    // Add New
        //    AddRaAdditionalChargesForExistingRa(raMain, raMainDbVersion);

        //    // Delete
        //    DeleteRaAdditionalCharges(raMain, raMainDbVersion);

        //    // Update Existing
        //    UpdateRaAdditionalChargesExisting(raMain, raMainDbVersion);
        //}

        ///// <summary>
        ///// Update Ra Additional Charges Existing
        ///// </summary>
        //private void UpdateRaAdditionalChargesExisting(RaMain raMain, RaMain raMainDbVersion)
        //{
        //    foreach (RaAdditionalCharge raAdditionalCharge in raMain.RaAdditionalCharges)
        //    {
        //        if (raAdditionalCharge.RaAdditionalChargeId == 0)
        //        {
        //            continue;
        //        }

        //        RaAdditionalCharge raAdditionalChargeDbVersion = raMainDbVersion.RaAdditionalCharges.FirstOrDefault(addChg =>
        //            addChg.RaAdditionalChargeId == raAdditionalCharge.RaAdditionalChargeId);

        //        if (raAdditionalChargeDbVersion == null)
        //        {
        //            throw new CaresException(string.Format(CultureInfo.InvariantCulture,
        //                Resources.RentalAgreement.RentalAgreement.RentalAgreementService_RaAdditionalChargeNotFound,
        //                raAdditionalCharge.RaAdditionalChargeId));
        //        }

        //        raAdditionalChargeDbVersion.Quantity = raAdditionalCharge.Quantity;
        //        raAdditionalChargeDbVersion.PlateNumber = raAdditionalCharge.PlateNumber;
        //        raAdditionalChargeDbVersion.AdditionalChargeRate = raAdditionalCharge.AdditionalChargeRate;
        //        raAdditionalChargeDbVersion.RecLastUpdatedBy = rentalAgreementRepository.LoggedInUserIdentity;
        //        raAdditionalChargeDbVersion.RecLastUpdatedDt = DateTime.Now;
        //        raAdditionalChargeDbVersion.RowVersion = raAdditionalChargeDbVersion.RowVersion + 1;
        //    }
        //}

        ///// <summary>
        ///// Add RaAdditional Charges For Existing RA
        ///// </summary>
        //private void AddRaAdditionalChargesForExistingRa(RaMain raMain, RaMain raMainDbVersion)
        //{
        //    List<RaAdditionalCharge> raAdditionalChargesToAdd =
        //        raMain.RaAdditionalCharges.Where(addChg => addChg.RaAdditionalChargeId == 0).ToList();
        //    raAdditionalChargesToAdd.ForEach(addChg => raMainDbVersion.RaAdditionalCharges.Add(addChg));
        //    AddRaAdditionalCharges(raAdditionalChargesToAdd);
        //}

        ///// <summary>
        ///// Delete Ra Additional Charges
        ///// </summary>
        //private static void DeleteRaAdditionalCharges(RaMain raMain, RaMain raMainDbVersion)
        //{
        //    List<RaAdditionalCharge> raAdditionalChargesToDelete =
        //        raMainDbVersion.RaAdditionalCharges.Where(
        //            addCh =>
        //                raMain.RaAdditionalCharges.All(
        //                    addC => addCh.RaAdditionalChargeId != addC.RaAdditionalChargeId)).ToList();
        //    raAdditionalChargesToDelete.ForEach(addChg => raMainDbVersion.RaAdditionalCharges.Remove(addChg));
        //}

        ///// <summary>
        ///// Updates Ra Drivers
        ///// </summary>
        //private void UpdateRaDrivers(RaMain raMain, RaMain raMainDbVersion)
        //{
        //    // Check for RaService Items
        //    if (raMainDbVersion.RaDrivers == null)
        //    {
        //        raMainDbVersion.RaDrivers = new List<RaDriver>();
        //    }

        //    // Add New
        //    AddRaDriverForExistingRa(raMain, raMainDbVersion);

        //    // Delete
        //    DeleteRaDriver(raMain, raMainDbVersion);

        //    // Update Existing
        //    UpdateRaDriversExisting(raMain, raMainDbVersion);
        //}

        ///// <summary>
        ///// Add RaDriver For Existing RA
        ///// </summary>
        //private void AddRaDriverForExistingRa(RaMain raMain, RaMain raMainDbVersion)
        //{
        //    List<RaDriver> raDriversToAdd =
        //        raMain.RaDrivers.Where(serItem => serItem.RaDriverId == 0).ToList();
        //    raDriversToAdd.ForEach(serItem => raMainDbVersion.RaDrivers.Add(serItem));
        //    AddRaDrivers(raDriversToAdd);
        //}

        ///// <summary>
        ///// Delete Ra Drivers
        ///// </summary>
        //private static void DeleteRaDriver(RaMain raMain, RaMain raMainDbVersion)
        //{
        //    List<RaDriver> raDriversToDelete =
        //        raMainDbVersion.RaDrivers.Where(
        //            raSerItem =>
        //                raMain.RaDrivers.All(
        //                    raServItem => raServItem.RaDriverId != raSerItem.RaDriverId)).ToList();
        //    raDriversToDelete.ForEach(addChg => raMainDbVersion.RaDrivers.Remove(addChg));
        //}

        ///// <summary>
        ///// Update Ra Drivers Existing
        ///// </summary>
        //private void UpdateRaDriversExisting(RaMain raMain, RaMain raMainDbVersion)
        //{
        //    foreach (RaDriver raDriver in raMain.RaDrivers)
        //    {
        //        if (raDriver.RaDriverId == 0)
        //        {
        //            continue;
        //        }

        //        RaDriver raDriverDbVersion = raMainDbVersion.RaDrivers.FirstOrDefault(addChg =>
        //            addChg.RaDriverId == raDriver.RaDriverId);

        //        if (raDriverDbVersion == null)
        //        {
        //            throw new CaresException(string.Format(CultureInfo.InvariantCulture,
        //                Resources.RentalAgreement.RentalAgreement.RentalAgreementService_RaDriverNotFound,
        //                raDriver.RaDriverId));
        //        }

        //        UpdateRaDriverHeader(raDriverDbVersion, raDriver);
        //    }
        //}

        ///// <summary>
        ///// Update Ra Driver Header
        ///// </summary>
        //private void UpdateRaDriverHeader(RaDriver raDriverDbVersion, RaDriver raDriver)
        //{
        //    raDriverDbVersion.ChargedDay = raDriver.ChargedDay;
        //    raDriverDbVersion.ChargedHour = raDriver.ChargedHour;
        //    raDriverDbVersion.ChargedMinute = raDriver.ChargedMinute;
        //    raDriverDbVersion.TariffType = raDriver.TariffType;
        //    raDriverDbVersion.StartDtTime = raDriver.StartDtTime;
        //    raDriverDbVersion.EndDtTime = raDriver.EndDtTime;
        //    raDriverDbVersion.TotalCharge = raDriver.TotalCharge;
        //    raDriverDbVersion.Rate = raDriver.Rate;
        //    raDriverDbVersion.LicenseNo = raDriver.LicenseNo;
        //    raDriverDbVersion.LicenseExpDt = raDriver.LicenseExpDt;
        //    raDriverDbVersion.DriverName = raDriver.DriverName;
        //    raDriverDbVersion.RecLastUpdatedBy = rentalAgreementRepository.LoggedInUserIdentity;
        //    raDriverDbVersion.RecLastUpdatedDt = DateTime.Now;
        //    raDriverDbVersion.RowVersion = raDriverDbVersion.RowVersion + 1;
        //}

        ///// <summary>
        ///// Updates Ra Payments
        ///// </summary>
        //private void UpdateRaPayments(RaMain raMain, RaMain raMainDbVersion)
        //{
        //    // Check for RaService Items
        //    if (raMainDbVersion.RaPayments == null)
        //    {
        //        raMainDbVersion.RaPayments = new List<RaPayment>();
        //    }

        //    // Add New
        //    AddRaPaymentForExistingRa(raMain, raMainDbVersion);

        //    // Delete
        //    DeleteRaPayment(raMain, raMainDbVersion);

        //    // Update Existing
        //    UpdateRaPaymentsExisting(raMain, raMainDbVersion);
        //}

        ///// <summary>
        ///// Add RaPayment For Existing RA
        ///// </summary>
        //private void AddRaPaymentForExistingRa(RaMain raMain, RaMain raMainDbVersion)
        //{
        //    List<RaPayment> raPaymentsToAdd =
        //        raMain.RaPayments.Where(serItem => serItem.RaPaymentId == 0).ToList();
        //    raPaymentsToAdd.ForEach(serItem => raMainDbVersion.RaPayments.Add(serItem));
        //    AddRaPayments(raPaymentsToAdd);
        //}

        ///// <summary>
        ///// Delete Ra Payments
        ///// </summary>
        //private static void DeleteRaPayment(RaMain raMain, RaMain raMainDbVersion)
        //{
        //    List<RaPayment> raPaymentsToDelete =
        //        raMainDbVersion.RaPayments.Where(
        //            raSerItem =>
        //                raMain.RaPayments.All(
        //                    raServItem => raServItem.RaPaymentId != raSerItem.RaPaymentId)).ToList();
        //    raPaymentsToDelete.ForEach(addChg => raMainDbVersion.RaPayments.Remove(addChg));
        //}

        ///// <summary>
        ///// Update Ra Payments Existing
        ///// </summary>
        //private void UpdateRaPaymentsExisting(RaMain raMain, RaMain raMainDbVersion)
        //{
        //    foreach (RaPayment raPayment in raMain.RaPayments)
        //    {
        //        if (raPayment.RaPaymentId == 0)
        //        {
        //            continue;
        //        }

        //        RaPayment raPaymentDbVersion = raMainDbVersion.RaPayments.FirstOrDefault(addChg =>
        //            addChg.RaPaymentId == raPayment.RaPaymentId);

        //        if (raPaymentDbVersion == null)
        //        {
        //            throw new CaresException(string.Format(CultureInfo.InvariantCulture,
        //                Resources.RentalAgreement.RentalAgreement.RentalAgreementService_RaPaymentNotFound,
        //                raPayment.RaPaymentId));
        //        }

        //        UpdateRaPaymentHeader(raPaymentDbVersion, raPayment);
        //    }
        //}

        ///// <summary>
        ///// Update Ra Payment Header
        ///// </summary>
        //private void UpdateRaPaymentHeader(RaPayment raPaymentDbVersion, RaPayment raPayment)
        //{
        //    raPaymentDbVersion.Bank = raPayment.Bank;
        //    raPaymentDbVersion.ChequeNumber = raPayment.ChequeNumber;
        //    raPaymentDbVersion.PaymentModeId = raPayment.PaymentModeId;
        //    raPaymentDbVersion.RaPaymentAmount = raPayment.RaPaymentAmount;
        //    raPaymentDbVersion.RaPaymentDt = raPayment.RaPaymentDt;
        //    raPaymentDbVersion.PaidBy = raPayment.PaidBy;
        //    raPaymentDbVersion.RecLastUpdatedBy = rentalAgreementRepository.LoggedInUserIdentity;
        //    raPaymentDbVersion.RecLastUpdatedDt = DateTime.Now;
        //    raPaymentDbVersion.RowVersion = raPaymentDbVersion.RowVersion + 1;
        //}

        ///// <summary>
        ///// Updates Ra CustomerDocuments
        ///// </summary>
        //private void UpdateRaCustomerDocuments(RaMain raMain, RaMain raMainDbVersion)
        //{
        //    // Check for RaService Items
        //    if (raMainDbVersion.RaCustomerDocuments == null)
        //    {
        //        raMainDbVersion.RaCustomerDocuments = new List<RaCustomerDocument>();
        //    }

        //    // Add New
        //    AddRaCustomerDocumentForExistingRa(raMain, raMainDbVersion);

        //    // Delete
        //    DeleteRaCustomerDocument(raMain, raMainDbVersion);
        //}

        ///// <summary>
        ///// Add RaCustomerDocument For Existing RA
        ///// </summary>
        //private void AddRaCustomerDocumentForExistingRa(RaMain raMain, RaMain raMainDbVersion)
        //{
        //    List<RaCustomerDocument> raCustomerDocumentsToAdd =
        //        raMain.RaCustomerDocuments.Where(serItem => serItem.RaCustomerDocumentId == 0).ToList();
        //    raCustomerDocumentsToAdd.ForEach(serItem => raMainDbVersion.RaCustomerDocuments.Add(serItem));
        //    AddRaCustomerDocuments(raCustomerDocumentsToAdd);
        //}

        ///// <summary>
        ///// Delete Ra CustomerDocuments
        ///// </summary>
        //private static void DeleteRaCustomerDocument(RaMain raMain, RaMain raMainDbVersion)
        //{
        //    List<RaCustomerDocument> raCustomerDocumentsToDelete =
        //        raMainDbVersion.RaCustomerDocuments.Where(
        //            raSerItem =>
        //                raMain.RaCustomerDocuments.All(
        //                    raServItem => raServItem.RaCustomerDocumentId != raSerItem.RaCustomerDocumentId)).ToList();
        //    raCustomerDocumentsToDelete.ForEach(addChg => raMainDbVersion.RaCustomerDocuments.Remove(addChg));
        //}

        ///// <summary>
        ///// Update Chuaffer Reservations
        ///// </summary>
        //private void UpdateChaufferReservations(RaMain raMain, RaMain raMainDbVersion)
        //{
        //    // Update Chauffer Reservations
        //    SaveChaufferReservation(raMain);

        //    // Delete Reservations
        //    DeleteChaufferReservations(raMain, raMainDbVersion);

        //    // Update Existing Chauffer Reservations
        //    UpdateChaufferReservationsExisting(raMain, raMainDbVersion);
        //}

        ///// <summary>
        ///// Update Existing Chauffer Reservations
        ///// </summary>
        //private void UpdateChaufferReservationsExisting(RaMain raMain, RaMain raMainDbVersion)
        //{
        //    List<RaDriver> chauffersToUpdate =
        //        raMain.RaDrivers.Where(
        //            raDriver =>
        //                raMainDbVersion.RaDrivers.Select(driver => driver.RaDriverId).Contains(raDriver.RaDriverId) &&
        //                raDriver.IsChauffer && raDriver.ChaufferId.HasValue && raDriver.ChaufferId.Value > 0 && raDriver.RaDriverId > 0).ToList();

        //    if (raMainDbVersion.ChaufferReservations.Any())
        //    {
        //        foreach (RaDriver raDriver in chauffersToUpdate)
        //        {
        //            List<ChaufferReservation> chaufferReservationsToUpdate = raMainDbVersion.ChaufferReservations.Where(
        //                cr => chauffersToUpdate.Select(ch => ch.ChaufferId).Contains(cr.ChaufferId)).ToList();

        //            chaufferReservationsToUpdate.ForEach(cr =>
        //            {
        //                cr.StartDtTime = raDriver.StartDtTime;
        //                cr.EndDtTime = raDriver.EndDtTime;
        //                cr.RecLastUpdatedBy = rentalAgreementRepository.LoggedInUserIdentity;
        //                cr.RecLastUpdatedDt = DateTime.Now;
        //                cr.RowVersion = cr.RowVersion + 1;
        //            });
        //        }
        //    }
        //}

        ///// <summary>
        ///// Delete Chauffer Reservations
        ///// </summary>
        //private static void DeleteChaufferReservations(RaMain raMain, RaMain raMainDbVersion)
        //{
        //    List<RaDriver> chauffersToDelete =
        //        raMainDbVersion.RaDrivers.Where(
        //            raDriver =>
        //                raMain.RaDrivers.All(driver => driver.RaDriverId != raDriver.RaDriverId) &&
        //                raDriver.IsChauffer && raDriver.ChaufferId.HasValue && raDriver.ChaufferId.Value > 0).ToList();

        //    if (raMainDbVersion.ChaufferReservations.Any())
        //    {
        //        List<ChaufferReservation> chaufferReservationsToDelete = raMainDbVersion.ChaufferReservations.Where(
        //            cr => chauffersToDelete.Select(ch => ch.ChaufferId).Contains(cr.ChaufferId)).ToList();
        //        chaufferReservationsToDelete.ForEach(cr => raMainDbVersion.ChaufferReservations.Remove(cr));
        //    }
        //}

        ///// <summary>
        ///// Create Ra Header From Booking
        ///// </summary>
        //private static void CreateRaHeaderFromBooking(RaMain raMain, BookingMain bookingMain)
        //{
        //    raMain.StartDtTime = bookingMain.StartDtTime;
        //    raMain.EndDtTime = bookingMain.EndDtTime;
        //    raMain.PaymentTermId = bookingMain.PaymentTermId;
        //    raMain.RaBookingId = bookingMain.BookingMainId;
        //    raMain.OperationId = bookingMain.OperationId;
        //    raMain.OpenLocation = bookingMain.OpenLocation;
        //    raMain.CloseLocation = bookingMain.CloseLocation;
        //}

        ///// <summary>
        ///// Create Service Items From Booking
        ///// </summary>
        //private static void CreateRaServiceItemsFromBooking(RaMain raMain, BookingMain bookingMain)
        //{
        //    //if (raMain.RaServiceItems == null)
        //    //{
        //    //    raMain.RaServiceItems = new List<RaServiceItem>();
        //    //}

        //    //foreach (RaServiceItem serviceItem in bookingMain.BookingServiceItems)
        //    //{
        //    //    raMain.RaServiceItems.Add(new RaServiceItem
        //    //    {
        //    //        ServiceItemId = serviceItem.ServiceItemId,
        //    //        StartDtTime = serviceItem.StartDtTime,
        //    //        EndDtTime = serviceItem.EndDtTime,
        //    //        Quantity = serviceItem.Quantity,
        //    //        ServiceItem = serviceItem.ServiceItem
        //    //    });
        //    //}
        //}

        ///// <summary>
        ///// Create Insurances From Booking
        ///// </summary>
        //private static void CreateRaInsurancesFromBooking(RaMain raMain, BookingMain bookingMain)
        //{
        //    if (raMain.RaHireGroups == null)
        //    {
        //        raMain.RaHireGroups = new List<RaHireGroup>();
        //    }

        //    // Create RAHireGroup
        //    RaHireGroup raHireGroup = new RaHireGroup
        //    {
        //        RaHireGroupInsurances = new List<RaHireGroupInsurance>()
        //    };

        //    //// Add Insurances to RAHireGroup
        //    //foreach (RaHireGroupInsurance insurance in bookingMain.BookingInsurances)
        //    //{
        //    //    raHireGroup.RaHireGroupInsurances.Add(new RaHireGroupInsurance
        //    //    {
        //    //        InsuranceTypeId = insurance.InsuranceTypeId,
        //    //        StartDtTime = insurance.StartDtTime,
        //    //        EndDtTime = insurance.EndDtTime,
        //    //        InsuranceType = insurance.InsuranceType
        //    //    });
        //    //}

        //    // Add RaHireGroup to RaMain
        //    raMain.RaHireGroups.Add(raHireGroup);
        //}

        ///// <summary>
        ///// Create Drivers From Booking
        ///// </summary>
        //private static void CreateRaDriversFromBooking(RaMain raMain, BookingMain bookingMain)
        //{
        //    if (raMain.RaDrivers == null)
        //    {
        //        raMain.RaDrivers = new List<RaDriver>();
        //    }

        //    //// Add Drivers From Booking to RA
        //    //foreach (RaDriver driver in bookingMain.BookingDrivers)
        //    //{
        //    //    raMain.RaDrivers.Add(new RaDriver
        //    //    {
        //    //        IsChauffer = false,
        //    //        EndDtTime = driver.EndDtTime,
        //    //        StartDtTime = driver.StartDtTime,
        //    //        DriverName = driver.DriverName,
        //    //        DesigGradeId = driver.DesigGradeId,
        //    //        DesigGrade = driver.DesigGrade,
        //    //        LicenseExpDt = driver.LicenseExpDt,
        //    //        LicenseNo = driver.LicenseNo
        //    //    });
        //    }

        //    //// Add Chauffers from Booking to RA
        //    //foreach (RaDriver driver in bookingMain.BookingChauffers)
        //    //{
        //    //    raMain.RaDrivers.Add(new RaDriver
        //    //    {
        //    //        ChaufferId = driver.ChaufferId,
        //    //        IsChauffer = true,
        //    //        EndDtTime = driver.EndDtTime,
        //    //        StartDtTime = driver.StartDtTime,
        //    //        DriverName = driver.DriverName,
        //    //        DesigGradeId = driver.DesigGradeId,
        //    //        DesigGrade = driver.DesigGrade,
        //    //        Employee = driver.Employee,
        //    //        LicenseExpDt = driver.LicenseExpDt,
        //    //        LicenseNo = driver.LicenseNo
        //    //    });
        //    //}
        //}

        ///// <summary>
        ///// Create Payments From Booking
        ///// </summary>
        //private static void CreateRaPaymentsFromBooking(RaMain raMain, BookingMain bookingMain)
        //{
        //    //if (raMain.RaPayments == null)
        //    //{
        //    //    raMain.RaPayments = new List<RaPayment>();
        //    //}

        //    //foreach (RaPayment payment in bookingMain.BookingPayments)
        //    //{
        //    //    raMain.RaPayments.Add(new RaPayment
        //    //    {
        //    //        PaymentModeId = payment.PaymentModeId,
        //    //        Bank = payment.Bank,
        //    //        PaidBy = payment.PaidBy,
        //    //        ChequeNumber = payment.ChequeNumber,
        //    //        RaPaymentDt = payment.RaPaymentDt,
        //    //        RaPaymentAmount = payment.RaPaymentAmount
        //    //    });
        //    //}
        //}

        //#endregion

        //#region Constructors

        ///// <summary>
        ///// Constructor
        ///// </summary>
        //public RentalAgreementService(IPaymentTermRepository paymentTermRepository, IOperationRepository operationRepository,
        //    IOperationsWorkPlaceRepository operationsWorkPlaceRepository, ITariffTypeRepository tariffTypeRepository, IBill bill,
        //    IVehicleStatusRepository vehicleStatusRepository, IAlloactionStatusRepository alloactionStatusRepository, IRentalAgreementRepository rentalAgreementRepository,
        //    IBusinessPartnerRepository businessPartnerRepository, IPhoneRepository businessPartnerPhoneRepository, IAddressRepository businessPartnerAddressRepository,
        //    IVehicleRepository vehicleRepository, IPaymentModeRepository paymentModeRepository, IRaStatusRepository raStatusRepository, 
        //    IBookingMainRepository bookingMainRepository)
        //{
        //    if (paymentTermRepository == null)
        //    {
        //        throw new ArgumentNullException("paymentTermRepository");
        //    }

        //    if (operationRepository == null)
        //    {
        //        throw new ArgumentNullException("operationRepository");
        //    }
        //    if (operationsWorkPlaceRepository == null)
        //    {
        //        throw new ArgumentNullException("operationsWorkPlaceRepository");
        //    }
        //    if (tariffTypeRepository == null) throw new ArgumentNullException("tariffTypeRepository");
        //    if (bill == null) throw new ArgumentNullException("bill");
        //    if (vehicleStatusRepository == null) throw new ArgumentNullException("vehicleStatusRepository");
        //    if (alloactionStatusRepository == null) throw new ArgumentNullException("alloactionStatusRepository");
        //    if (rentalAgreementRepository == null) throw new ArgumentNullException("rentalAgreementRepository");
        //    if (businessPartnerRepository == null) throw new ArgumentNullException("businessPartnerRepository");
        //    if (businessPartnerPhoneRepository == null)
        //        throw new ArgumentNullException("businessPartnerPhoneRepository");
        //    if (businessPartnerAddressRepository == null)
        //        throw new ArgumentNullException("businessPartnerAddressRepository");
        //    if (vehicleRepository == null) throw new ArgumentNullException("vehicleRepository");
        //    if (paymentModeRepository == null) throw new ArgumentNullException("paymentModeRepository");
        //    if (raStatusRepository == null) throw new ArgumentNullException("raStatusRepository");
        //    if (bookingMainRepository == null) throw new ArgumentNullException("bookingMainRepository");

        //    this.paymentTermRepository = paymentTermRepository;
        //    this.operationRepository = operationRepository;
        //    this.operationsWorkPlaceRepository = operationsWorkPlaceRepository;
        //    this.tariffTypeRepository = tariffTypeRepository;
        //    this.bill = bill;
        //    this.vehicleStatusRepository = vehicleStatusRepository;
        //    this.alloactionStatusRepository = alloactionStatusRepository;
        //    this.rentalAgreementRepository = rentalAgreementRepository;
        //    this.businessPartnerRepository = businessPartnerRepository;
        //    this.businessPartnerAddressRepository = businessPartnerAddressRepository;
        //    this.vehicleRepository = vehicleRepository;
        //    this.paymentModeRepository = paymentModeRepository;
        //    this.raStatusRepository = raStatusRepository;
        //    this.bookingMainRepository = bookingMainRepository;
        //}

        //#endregion

        //#region Public

        ///// <summary>
        ///// Get Base Data
        ///// </summary>
        //public RentalAgreementBaseDataResponse GetBaseData()
        //{
        //    return new RentalAgreementBaseDataResponse
        //    {
        //        PaymentTerms = paymentTermRepository.GetAll(),
        //        Operations = operationRepository.GetSalesOperation(),
        //        OperationsWorkPlaces = operationsWorkPlaceRepository.GetSalesOperationsWorkPlace(),
        //        AllocationStatuses = alloactionStatusRepository.GetAll(),
        //        VehicleStatuses = vehicleStatusRepository.GetAll(),
        //        PaymentModes = paymentModeRepository.GetAll()
        //    };
        //}

        ///// <summary>
        ///// Generates Bill For RA
        ///// </summary>
        //public RaMain GenerateBill(RaMain request)
        //{
        //    List<TariffType> tariffTypes = tariffTypeRepository.GetAll().ToList();
        //    RaMain raMain = request;

        //    bill.CalculateBill(ref raMain, tariffTypes);

        //    return raMain;
        //}

        ///// <summary>
        ///// Saves Rental Agreement
        ///// </summary>
        //public RaMain SaveRentalAgreement(RaMain raMain)
        //{
        //    // Generate Bill
        //    raMain = GenerateBill(raMain);

        //    // Add Rental Agreement
        //    if (raMain.RaMainId == 0)
        //    {
        //        // Add To Repository
        //        rentalAgreementRepository.Add(raMain);

        //        // Map Main
        //        MapRaHeader(raMain);

        //        // Ra Hire Groups
        //        AddRaHireGroups(raMain.RaHireGroups);

        //        // Ra Additional Charges
        //        AddRaAdditionalCharges(raMain.RaAdditionalCharges);

        //        // Ra Service Items
        //        AddRaServiceItems(raMain.RaServiceItems);

        //        // Ra Drivers
        //        AddRaDrivers(raMain.RaDrivers);

        //        // Ra Payments
        //        AddRaPayments(raMain.RaPayments);

        //        // Ra Customer Documents
        //        AddRaCustomerDocuments(raMain.RaCustomerDocuments);

        //        // Update / Add Business Partner
        //        if (raMain.BusinessPartnerId == 0)
        //        {
        //            AddBusinessPartner(raMain.BusinessPartner);
        //        }
        //        else
        //        {
        //            UpdateBusinessPartner(raMain.BusinessPartner);
        //        }

        //        // Save Chauffer Reservations
        //        SaveChaufferReservation(raMain);
        //    }
        //    // Update Rental Agreement
        //    else
        //    {
        //        // Find Db Version
        //        RaMain raMainDbVersion = rentalAgreementRepository.Find(raMain.RaMainId);

        //        // Assert
        //        if (raMainDbVersion == null)
        //        {
        //            throw new CaresException(string.Format(CultureInfo.InvariantCulture, Resources.RentalAgreement.RentalAgreement.RentalAgreementNotFound,
        //                raMain.RaMainId));
        //        }

        //        // Map Main 
        //        UpdateRaMainHeader(raMain, raMainDbVersion);

        //        // Update / Add Ra Hire Groups
        //        UpdateRaHireGroups(raMain, raMainDbVersion);

        //        // Update / Add Ra Additional Charges
        //        UpdateRaAdditionalCharges(raMain, raMainDbVersion);

        //        // Update / Add Ra Service Items
        //        UpdateRaServiceItems(raMain, raMainDbVersion);

        //        // Update / Add Ra Drivers
        //        UpdateRaDrivers(raMain, raMainDbVersion);

        //        // Update / Add Ra Payments
        //        UpdateRaPayments(raMain, raMainDbVersion);

        //        // Update / Add Ra Customer Documents
        //        UpdateRaCustomerDocuments(raMain, raMainDbVersion);

        //        // Update Business Partner
        //        UpdateBusinessPartner(raMain.BusinessPartner);

        //        // Update Chauffer Reservations
        //        UpdateChaufferReservations(raMain, raMainDbVersion);
        //    }


        //    // Save Changes
        //    rentalAgreementRepository.SaveChanges();

        //    return raMain;
        //}

        ///// <summary>
        ///// Get Rental Agreement By Id
        ///// </summary>
        //public RaMain GetById(long id)
        //{
        //    RaMain raMain = rentalAgreementRepository.Find(id);

        //    if (raMain == null)
        //    {
        //        throw new CaresException(string.Format(CultureInfo.InvariantCulture, Resources.RentalAgreement.RentalAgreement.RentalAgreementNotFound, id));
        //    }

        //    return raMain;
        //}

        ///// <summary>
        ///// Get Rental Agreement By Id
        ///// </summary>
        //public RaMain GetByBooking(long bookingMainId)
        //{
        //    BookingMain bookingMain = bookingMainRepository.Find(bookingMainId);

        //    if (bookingMain == null)
        //    {
        //        throw new CaresException(string.Format(CultureInfo.InvariantCulture, Resources.RentalAgreement.RentalAgreement.BookingNotFound, bookingMainId));
        //    }

        //    // Create RA
        //    RaMain raMain = rentalAgreementRepository.Create();

        //    // Map Header
        //    CreateRaHeaderFromBooking(raMain, bookingMain);

        //    // Map Insurances
        //    CreateRaInsurancesFromBooking(raMain, bookingMain);

        //    // Map Services
        //    CreateRaServiceItemsFromBooking(raMain, bookingMain);

        //    // Map Drivers
        //    CreateRaDriversFromBooking(raMain, bookingMain);

        //    // Map Payments
        //    CreateRaPaymentsFromBooking(raMain, bookingMain);

        //    return raMain;
        //}

        //#endregion
    }
}
