using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
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
        #region Private

        private readonly IPaymentTermRepository paymentTermRepository;
        private readonly IOperationRepository operationRepository;
        private readonly IOperationsWorkPlaceRepository operationsWorkPlaceRepository;
        private readonly ITariffTypeRepository tariffTypeRepository;
        private readonly IBill bill;
        private readonly IVehicleStatusRepository vehicleStatusRepository;
        private readonly IAlloactionStatusRepository alloactionStatusRepository;
        private readonly IRentalAgreementRepository rentalAgreementRepository;
        private readonly IBusinessPartnerRepository businessPartnerRepository;
        private readonly IPhoneRepository businessPartnerPhoneRepository;
        private readonly IAddressRepository businessPartnerAddressRepository;
        private readonly IVehicleRepository vehicleRepository;

        /// <summary>
        /// Add Vehicle Movements
        /// </summary>
        private void AddVehicleMovements(RaHireGroup raHireGroup)
        {
            foreach (VehicleMovement vehicleMovement in raHireGroup.VehicleMovements)
            {
                vehicleMovement.IsActive = true;
                vehicleMovement.RecCreatedBy =
                    vehicleMovement.RecLastUpdatedBy = rentalAgreementRepository.LoggedInUserIdentity;
                vehicleMovement.RecCreatedDt = vehicleMovement.RecLastUpdatedDt = DateTime.Now;
                vehicleMovement.RowVersion = 0;
                vehicleMovement.UserDomainKey = rentalAgreementRepository.UserDomainKey;
            }
        }

        /// <summary>
        /// Add Ra Vehicle Checklists
        /// </summary>
        private void AddRaVehicleCheckLists(RaHireGroup raHireGroup)
        {
            foreach (RaVehicleCheckList raVehicleCheckList in raHireGroup.RaVehicleCheckLists)
            {
                raVehicleCheckList.IsActive = true;
                raVehicleCheckList.RecCreatedBy =
                    raVehicleCheckList.RecLastUpdatedBy = rentalAgreementRepository.LoggedInUserIdentity;
                raVehicleCheckList.RecCreatedDt = raVehicleCheckList.RecLastUpdatedDt = DateTime.Now;
                raVehicleCheckList.RowVersion = 0;
                raVehicleCheckList.UserDomainKey = rentalAgreementRepository.UserDomainKey;
            }
        }

        /// <summary>
        /// Add Ra HireGroup Discounts
        /// </summary>
        private void AddRaHireGroupDiscounts(RaHireGroup raHireGroup)
        {
            foreach (RaHireGroupDiscount raHireGroupDiscount in raHireGroup.RaHireGroupDiscounts)
            {
                raHireGroupDiscount.IsActive = true;
                raHireGroupDiscount.RecCreatedBy =
                    raHireGroupDiscount.RecLastUpdatedBy = rentalAgreementRepository.LoggedInUserIdentity;
                raHireGroupDiscount.RecCreatedDt = raHireGroupDiscount.RecLastUpdatedDt = DateTime.Now;
                raHireGroupDiscount.RowVersion = 0;
                raHireGroupDiscount.UserDomainKey = rentalAgreementRepository.UserDomainKey;
            }
        }

        /// <summary>
        /// Add RaHireGroup Insurances
        /// </summary>
        private void AddRaHireGroupInsurances(IEnumerable<RaHireGroupInsurance> raHireGroupInsurances)
        {
            foreach (RaHireGroupInsurance raHireGroupInsurance in raHireGroupInsurances)
            {
                raHireGroupInsurance.IsActive = true;
                raHireGroupInsurance.RecCreatedBy =
                    raHireGroupInsurance.RecLastUpdatedBy = rentalAgreementRepository.LoggedInUserIdentity;
                raHireGroupInsurance.RecCreatedDt = raHireGroupInsurance.RecLastUpdatedDt = DateTime.Now;
                raHireGroupInsurance.RowVersion = 0;
                raHireGroupInsurance.UserDomainKey = rentalAgreementRepository.UserDomainKey;
            }
        }

        /// <summary>
        /// Add RaHireGroups
        /// </summary>
        private void AddRaHireGroups(IEnumerable<RaHireGroup> raHireGroups)
        {
            foreach (RaHireGroup raHireGroup in raHireGroups)
            {
                // Set Required Fields 
                raHireGroup.IsActive = true;
                raHireGroup.RecCreatedBy =
                    raHireGroup.RecLastUpdatedBy = rentalAgreementRepository.LoggedInUserIdentity;
                raHireGroup.RecCreatedDt = raHireGroup.RecLastUpdatedDt = DateTime.Now;
                raHireGroup.RowVersion = 0;
                raHireGroup.UserDomainKey = rentalAgreementRepository.UserDomainKey;

                // Ra Hire Group Insurances
                AddRaHireGroupInsurances(raHireGroup.RaHireGroupInsurances);

                // Ra Hire Group Discounts
                AddRaHireGroupDiscounts(raHireGroup);

                // Ra Vehicle Check Lists
                AddRaVehicleCheckLists(raHireGroup);

                // Vehicle Movements
                AddVehicleMovements(raHireGroup);

                // Find Vehicle By Id
                Vehicle vehicle = GetVehicle(raHireGroup);

                if (vehicle == null)
                {
                    return;
                }

                // Add Vehicle Reservations
                AddVehicleReservation(raHireGroup, vehicle);

                // Update Vehicle Status Out
                UpdateVehicleStatusOut(raHireGroup, vehicle);
            }
        }

        private Vehicle GetVehicle(RaHireGroup raHireGroup)
        {
            // Add Vehicle Reservation and Update Vehicle Status
            if (!raHireGroup.VehicleId.HasValue || raHireGroup.VehicleId.Value <= 0)
            {
                return null;
            }

            Vehicle vehicle = vehicleRepository.Find(raHireGroup.VehicleId.Value);

            if (vehicle == null)
            {
                throw new InvalidOperationException(string.Format(CultureInfo.InvariantCulture,
                    "Vehicle with Id {0} not found", raHireGroup.VehicleId.Value));
            }

            return vehicle;
        }

        /// <summary>
        /// Update Vehicle Status Out
        /// </summary>
        private void UpdateVehicleStatusOut(RaHireGroup raHireGroup, Vehicle vehicle)
        {
            VehicleMovement vehicleMovementOut =
                raHireGroup.VehicleMovements.FirstOrDefault(vm => vm.Status == Convert.ToBoolean(VehicleMovementEnum.Out));

            if (vehicleMovementOut == null || !vehicleMovementOut.VehicleStatusId.HasValue)
            {
                return;
            }

            UpdateVehicle(vehicle, vehicleMovementOut.VehicleStatusId.Value);
        }

        /// <summary>
        /// Update Vehicle
        /// </summary>
        private void UpdateVehicle(Vehicle vehicle, short vehicleStatusId)
        {
            vehicle.VehicleStatusId = vehicleStatusId;
            vehicle.RowVersion = vehicle.RowVersion + 1;
            vehicle.RecLastUpdatedBy = rentalAgreementRepository.LoggedInUserIdentity;
            vehicle.RecLastUpdatedDt = DateTime.Now;
        }

        /// <summary>
        /// Update Vehicle Status In
        /// </summary>
// ReSharper disable UnusedMember.Local
        private void UpdateVehicleStatusIn(RaHireGroup raHireGroup, Vehicle vehicle)
// ReSharper restore UnusedMember.Local
        {
            VehicleMovement vehicleMovementIn =
                raHireGroup.VehicleMovements.FirstOrDefault(vm => vm.Status == Convert.ToBoolean(VehicleMovementEnum.In));

            if (vehicleMovementIn == null || !vehicleMovementIn.VehicleStatusId.HasValue)
            {
                return;
            }

            UpdateVehicle(vehicle, vehicleMovementIn.VehicleStatusId.Value);
        }

        /// <summary>
        /// Adds Vehicle Reservation
        /// </summary>
        private void AddVehicleReservation(RaHireGroup raHireGroup, Vehicle vehicle)
        {

            // Check For Vehicle Reservations 
            if (vehicle.VehicleReservations == null)
            {
                vehicle.VehicleReservations = new List<VehicleReservation>();
            }

            // Get Vehicle Movements
            VehicleMovement vehicleMovementOut =
                raHireGroup.VehicleMovements.FirstOrDefault(vm => vm.Status == Convert.ToBoolean(VehicleMovementEnum.Out));
            VehicleMovement vehicleMovementIn =
                raHireGroup.VehicleMovements.FirstOrDefault(vm => vm.Status == Convert.ToBoolean(VehicleMovementEnum.In));

            if (vehicleMovementIn != null && vehicleMovementOut != null)
            {
                vehicle.VehicleReservations.Add(CreateVehicleReservation(raHireGroup.RaMainId, vehicleMovementOut.DtTime, vehicleMovementIn.DtTime, vehicle.VehicleId));
            }
        }

        /// <summary>
        /// Creates New Vehicle Reservation
        /// </summary>
        private VehicleReservation CreateVehicleReservation(long raMainId, DateTime startDt, DateTime endDt, long vehicleId)
        {
            return new VehicleReservation
            {
                StartDtTime = startDt,
                EndDtTime = endDt,
                VehicleId = vehicleId,
                RaMainId = raMainId,
                IsActive = true,
                RecCreatedBy = rentalAgreementRepository.LoggedInUserIdentity,
                RecLastUpdatedBy = rentalAgreementRepository.LoggedInUserIdentity,
                RecCreatedDt = DateTime.Now,
                RecLastUpdatedDt = DateTime.Now,
                RowVersion = 0,
                UserDomainKey = rentalAgreementRepository.UserDomainKey
            };
        }

        /// <summary>
        /// Add Ra Additional Charges
        /// </summary>
        private void AddRaAdditionalCharges(RaMain raMain)
        {
            foreach (RaAdditionalCharge raAdditionalCharge in raMain.RaAdditionalCharges)
            {
                // Set Required Fields 
                raAdditionalCharge.IsActive = true;
                raAdditionalCharge.RecCreatedBy =
                    raAdditionalCharge.RecLastUpdatedBy = rentalAgreementRepository.LoggedInUserIdentity;
                raAdditionalCharge.RecCreatedDt = raAdditionalCharge.RecLastUpdatedDt = DateTime.Now;
                raAdditionalCharge.RowVersion = 0;
                raAdditionalCharge.UserDomainKey = rentalAgreementRepository.UserDomainKey;
            }
        }

        /// <summary>
        /// Add Ra Service Items
        /// </summary>
        private void AddRaServiceItems(RaMain raMain)
        {
            foreach (RaServiceItem raServiceItem in raMain.RaServiceItems)
            {
                // Set Required Fields 
                raServiceItem.IsActive = true;
                raServiceItem.RecCreatedBy =
                    raServiceItem.RecLastUpdatedBy = rentalAgreementRepository.LoggedInUserIdentity;
                raServiceItem.RecCreatedDt = raServiceItem.RecLastUpdatedDt = DateTime.Now;
                raServiceItem.RowVersion = 0;
                raServiceItem.UserDomainKey = rentalAgreementRepository.UserDomainKey;
            }
        }

        /// <summary>
        /// Add Ra Drivers
        /// </summary>
        private void AddRaDrivers(RaMain raMain)
        {
            foreach (RaDriver raDriver in raMain.RaDrivers)
            {
                // Set Required Fields 
                raDriver.IsActive = true;
                raDriver.RecCreatedBy =
                    raDriver.RecLastUpdatedBy = rentalAgreementRepository.LoggedInUserIdentity;
                raDriver.RecCreatedDt = raDriver.RecLastUpdatedDt = DateTime.Now;
                raDriver.RowVersion = 0;
                raDriver.UserDomainKey = rentalAgreementRepository.UserDomainKey;
            }
        }

        /// <summary>
        /// Add Ra Payments
        /// </summary>
        private void AddRaPayments(RaMain raMain)
        {
            foreach (RaPayment raPayment in raMain.RaPayments)
            {
                // Set Required Fields 
                raPayment.IsActive = true;
                raPayment.RecCreatedBy =
                    raPayment.RecLastUpdatedBy = rentalAgreementRepository.LoggedInUserIdentity;
                raPayment.RecCreatedDt = raPayment.RecLastUpdatedDt = DateTime.Now;
                raPayment.RowVersion = 0;
                raPayment.UserDomainKey = rentalAgreementRepository.UserDomainKey;
            }
        }

        /// <summary>
        /// Add Ra Customer Documents
        /// </summary>
        private void AddRaCustomerDocuments(RaMain raMain)
        {
            foreach (RaCustomerDocument raCustomerDocument in raMain.RaCustomerDocuments)
            {
                // Set Required Fields 
                raCustomerDocument.IsActive = true;
                raCustomerDocument.RecCreatedBy =
                    raCustomerDocument.RecLastUpdatedBy = rentalAgreementRepository.LoggedInUserIdentity;
                raCustomerDocument.RecCreatedDt = raCustomerDocument.RecLastUpdatedDt = DateTime.Now;
                raCustomerDocument.RowVersion = 0;
                raCustomerDocument.UserDomainKey = rentalAgreementRepository.UserDomainKey;
            }
        }

        /// <summary>
        /// Update Ra Main Header
        /// </summary>
        private static void UpdateRaMainHeader(RaMain raMain, RaMain raMainDbVersion)
        {
            raMainDbVersion.StartDtTime = raMain.StartDtTime;
            raMainDbVersion.EndDtTime = raMain.EndDtTime;
            raMainDbVersion.OpenLocation = raMain.OpenLocation;
            raMainDbVersion.CloseLocation = raMain.CloseLocation;
            raMainDbVersion.AmountPaid = raMain.AmountPaid;
            raMainDbVersion.Balance = raMain.Balance;
            raMainDbVersion.IsSpecialDiscountPerc = raMain.IsSpecialDiscountPerc;
            raMainDbVersion.VoucherDiscount = raMain.VoucherDiscount;
            raMainDbVersion.TotalVehicleCharge = raMain.TotalVehicleCharge;
            raMainDbVersion.TotalServiceCharge = raMain.TotalServiceCharge;
            raMainDbVersion.TotalOtherCharge = raMain.TotalOtherCharge;
            raMainDbVersion.TotalInsuranceCharge = raMain.TotalInsuranceCharge;
            raMainDbVersion.TotalExcessMileageCharge = raMain.TotalExcessMileageCharge;
            raMainDbVersion.TotalDropOffCharge = raMain.TotalDropOffCharge;
            raMainDbVersion.TotalDriverCharge = raMain.TotalDriverCharge;
            raMainDbVersion.TotalAdditionalCharge = raMain.TotalAdditionalCharge;
            raMainDbVersion.StandardDiscount = raMain.SeasonalDiscount;
            raMainDbVersion.SpecialDiscount = raMain.SpecialDiscount;
            raMainDbVersion.SpecialDiscountPerc = raMain.SpecialDiscountPerc;
            raMainDbVersion.NetBillAfterDiscount = raMain.NetBillAfterDiscount;
            raMainDbVersion.PaymentTermId = raMain.PaymentTermId;
            raMainDbVersion.RaStatusId = raMain.RaStatusId;
        }

        /// <summary>
        /// Add Business Partner
        /// </summary>
        private void AddBusinessPartner(BusinessPartner businessPartner)
        {
            if (ValidateBusinessPartner(businessPartner))
            {
                //set master (business partner) properties
                #region Business Partner
                SetBusinessPartnerRequiredFields(businessPartner);
                #endregion

                //set child (business partner individual) properties
                #region Business Partner Individual

                AddBusinessPartnerIndividual(businessPartner);

                #endregion

                //set child (business partner company) properties
                #region Business Partner Company
                AddBusinessPartnerCompany(businessPartner);

                #endregion

                //set child (business partner phones) properties
                #region Business Partner Phones
                // set properties
                AddBusinessPartnerPhones(businessPartner);
                #endregion

                //set child (business partner address) properties
                #region Business Partner Address
                // set properties
                AddBusinessPartnerAddress(businessPartner);
                #endregion

            }
            else
            {
                throw new InvalidOperationException("Business Partner with this name already exists");
            }
        }

        /// <summary>
        /// Add Business Partner Address
        /// </summary>
        private void AddBusinessPartnerAddress(BusinessPartner businessPartner)
        {
            foreach (Address item in businessPartner.BusinessPartnerAddressList)
            {
                item.IsActive = true;
                item.RecCreatedDt = item.RecLastUpdatedDt = DateTime.Now;
                item.RecCreatedBy = item.RecLastUpdatedBy = businessPartnerRepository.LoggedInUserIdentity;
                item.RowVersion = 0;
                item.UserDomainKey = businessPartnerRepository.UserDomainKey;
            }
        }

        /// <summary>
        /// Add Business Partner Phones
        /// </summary>
        private void AddBusinessPartnerPhones(BusinessPartner businessPartner)
        {
            foreach (Phone item in businessPartner.BusinessPartnerPhoneNumbers)
            {
                item.IsActive = true;
                item.RecCreatedDt = item.RecLastUpdatedDt = DateTime.Now;
                item.RecCreatedBy = item.RecLastUpdatedBy = businessPartnerRepository.LoggedInUserIdentity;
                item.RowVersion = 0;
                item.UserDomainKey = businessPartnerRepository.UserDomainKey;
            }
        }

        /// <summary>
        /// Add Business Partner Company
        /// </summary>
        private void AddBusinessPartnerCompany(BusinessPartner businessPartner)
        {
            if (businessPartner.IsIndividual)
            {
                businessPartner.BusinessPartnerCompany.BusinessPartnerCompanyCode =
                    businessPartner.BusinessPartnerIndividual.FirstName;
            }

            businessPartner.BusinessPartnerCompany.RecCreatedBy =
                businessPartner.BusinessPartnerCompany.RecLastUpdatedBy =
                    businessPartnerRepository.LoggedInUserIdentity;
            businessPartner.BusinessPartnerCompany.RecCreatedDt =
                businessPartner.BusinessPartnerCompany.RecLastUpdatedDt =
                    DateTime.Now;
            businessPartner.BusinessPartnerCompany.RecLastUpdatedBy =
                businessPartner.BusinessPartnerCompany.RecCreatedBy =
                    businessPartnerRepository.LoggedInUserIdentity;
            businessPartner.BusinessPartnerCompany.UserDomainKey = businessPartnerRepository.UserDomainKey;
        }

        /// <summary>
        /// Add Business Partner Individual
        /// </summary>
        private void AddBusinessPartnerIndividual(BusinessPartner businessPartner)
        {
            if (businessPartner.BusinessPartnerIndividual.FirstName == null)
            {
                businessPartner.BusinessPartnerIndividual.FirstName = string.Empty;
            }

            if (businessPartner.BusinessPartnerIndividual.LastName == null)
            {
                businessPartner.BusinessPartnerIndividual.LastName = string.Empty;
            }
            
            businessPartner.BusinessPartnerIndividual.RecCreatedBy =
                businessPartner.BusinessPartnerIndividual.RecLastUpdatedBy =
                    businessPartnerRepository.LoggedInUserIdentity;
            businessPartner.BusinessPartnerIndividual.RecCreatedDt =
                businessPartner.BusinessPartnerIndividual.RecLastUpdatedDt = DateTime.Now;
            businessPartner.BusinessPartnerIndividual.UserDomainKey = businessPartnerRepository.UserDomainKey;
        }

        /// <summary>
        /// Set Business Partner Basic Fields
        /// </summary>
        private void SetBusinessPartnerRequiredFields(BusinessPartner businessPartner)
        {
            businessPartner.BusinessPartnerCode = "RA-Screen";
            businessPartner.CompanyId = 1; // Need to Set Company Id from db
            businessPartner.UserDomainKey = rentalAgreementRepository.UserDomainKey;
            businessPartner.IsActive = true;
            businessPartner.RecCreatedDt = businessPartner.RecLastUpdatedDt = DateTime.Now;
            businessPartner.RecCreatedBy = businessPartner.RecLastUpdatedBy = rentalAgreementRepository.LoggedInUserIdentity;
            businessPartner.RowVersion = 0;
        }

        /// <summary>
        /// Validate Business Partner
        /// </summary>
        private bool ValidateBusinessPartner(BusinessPartner businessPartner)
        {
            BusinessPartner businessPartnerDbVersion = businessPartnerRepository.GetBusinessPartnerByName(businessPartner.BusinessPartnerName,
                (int)businessPartner.BusinessPartnerId);
            return businessPartnerDbVersion == null;
        }

        /// <summary>
        /// Update Ra Hire Groups
        /// </summary>
        private void UpdateRaHireGroups(RaMain raMain, RaMain raMainDbVersion)
        {
            // Add New
            List<RaHireGroup> raHireGroups = raMain.RaHireGroups.Where(hg => hg.RaHireGroupId == 0).ToList();
            raHireGroups.ForEach(raHireGroup => raMainDbVersion.RaHireGroups.Add(raHireGroup));

            AddRaHireGroups(raHireGroups);

            // Remove 
            DeleteRaHireGroups(raMain, raMainDbVersion);

            // Update Existing
            UpdateRaHireGroupsExisting(raMain, raMainDbVersion);
        }

        /// <summary>
        /// Update Existing Ra Hire Groups
        /// </summary>
        private void UpdateRaHireGroupsExisting(RaMain raMain, RaMain raMainDbVersion)
        {
            List<RaHireGroup> raHireGroupsToUpdate = new List<RaHireGroup>();
            raHireGroupsToUpdate.AddRange(from raHireGroup in raMainDbVersion.RaHireGroups
                                          let @group = raHireGroup
                                          where
                                              raMain.RaHireGroups.All(hg => hg.RaHireGroupId == @group.RaHireGroupId)
                                          select raHireGroup);

            foreach (RaHireGroup raHireGroup in raHireGroupsToUpdate)
            {
                RaHireGroup raHireGroupDbVersion =
                    raMainDbVersion.RaHireGroups.FirstOrDefault(hg => hg.RaHireGroupId == raHireGroup.RaHireGroupId);

                if (raHireGroupDbVersion == null)
                {
                    throw new InvalidOperationException(string.Format(CultureInfo.InvariantCulture,
                        "RaHireGroup with Id {0} not found", raHireGroup.RaHireGroupId));
                }

                // Update Main
                UpdateRaHireGroupExistingHeader(raHireGroupDbVersion, raHireGroup);
                
                // Update Ra Hire Group Insurances
                UpdateRaHireGroupInsurances(raHireGroup, raHireGroupDbVersion);

                // Update Vehicle Movements
                UpdateVehicleMovementInDetails(raHireGroupDbVersion, raHireGroup);

                // Update Ra Hire Group Discounts
                
                // Update Ra Vehicle CheckLists

                // Update Vehicle Reservation and Vehicle Status In
            }
        }

        /// <summary>
        /// Update Vehicle Movement In Details
        /// </summary>
        private static void UpdateVehicleMovementInDetails(RaHireGroup raHireGroupDbVersion, RaHireGroup raHireGroup)
        {
            VehicleMovement vehicleMovementInDbVersion = raHireGroupDbVersion.VehicleMovements
                .FirstOrDefault(vm => vm.Status == Convert.ToBoolean(VehicleMovementEnum.In));
            VehicleMovement vehicleMovementIn = raHireGroup.VehicleMovements
                .FirstOrDefault(vm => vm.Status == Convert.ToBoolean(VehicleMovementEnum.In));
            if (vehicleMovementInDbVersion != null && vehicleMovementIn != null)
            {
                vehicleMovementInDbVersion.VehicleStatusId = vehicleMovementIn.VehicleStatusId;
                vehicleMovementInDbVersion.DtTime = vehicleMovementIn.DtTime;
                vehicleMovementInDbVersion.Odometer = vehicleMovementIn.Odometer;
                vehicleMovementInDbVersion.FuelLevel = vehicleMovementIn.FuelLevel;
                vehicleMovementInDbVersion.OperationsWorkPlaceId = vehicleMovementIn.OperationsWorkPlaceId;
                vehicleMovementInDbVersion.RowVersion = vehicleMovementInDbVersion.RowVersion + 1;
            }
        }

        /// <summary>
        /// Update Ra HireGroup Insurances
        /// </summary>
        private void UpdateRaHireGroupInsurances(RaHireGroup raHireGroup, RaHireGroup raHireGroupDbVersion)
        {
            // Add New
            List<RaHireGroupInsurance> raHireGroupInsurancesToAdd =
                raHireGroup.RaHireGroupInsurances.Where(ins => ins.RaHireGroupInsuranceId == 0).ToList();
            raHireGroupInsurancesToAdd.ForEach(ins => raHireGroupDbVersion.RaHireGroupInsurances.Add(ins));
            AddRaHireGroupInsurances(raHireGroupInsurancesToAdd);

            // Delete 
            DeleteRaHireGroupInsurances(raHireGroup, raHireGroupDbVersion);

            // Update Existing
            UpdateRaHireGroupInsurancesExisting(raHireGroup, raHireGroupDbVersion);
        }

        /// <summary>
        /// Update Ra HireGroup Insurances Existing
        /// </summary>
        private static void UpdateRaHireGroupInsurancesExisting(RaHireGroup raHireGroup, RaHireGroup raHireGroupDbVersion)
        {
            foreach (RaHireGroupInsurance raHireGroupInsurance in raHireGroup.RaHireGroupInsurances)
            {
                RaHireGroupInsurance raHireGroupInsuranceDbVersion =
                    raHireGroupDbVersion.RaHireGroupInsurances.FirstOrDefault(
                        ins => ins.RaHireGroupInsuranceId == raHireGroupInsurance.RaHireGroupInsuranceId);

                if (raHireGroupInsuranceDbVersion == null)
                {
                    throw new InvalidOperationException(string.Format(CultureInfo.InvariantCulture,
                        "RaHireGroupInsurance with Id {0} not found",
                        raHireGroupInsurance.RaHireGroupInsuranceId));
                }

                // Map Main
                raHireGroupInsuranceDbVersion.ChargedDay = raHireGroupInsurance.ChargedDay;
                raHireGroupInsuranceDbVersion.ChargedHour = raHireGroupInsurance.ChargedHour;
                raHireGroupInsuranceDbVersion.ChargedMinute = raHireGroupInsurance.ChargedMinute;
                raHireGroupInsuranceDbVersion.StartDtTime = raHireGroupInsurance.StartDtTime;
                raHireGroupInsuranceDbVersion.EndDtTime = raHireGroupInsurance.EndDtTime;
                raHireGroupInsuranceDbVersion.InsuranceCharge = raHireGroupInsurance.InsuranceCharge;
                raHireGroupInsuranceDbVersion.InsuranceRate = raHireGroupInsurance.InsuranceRate;
                raHireGroupInsuranceDbVersion.InsuranceTypeId = raHireGroupInsurance.InsuranceTypeId;
                raHireGroupInsuranceDbVersion.TariffType = raHireGroupInsurance.TariffType;
                raHireGroupInsuranceDbVersion.RowVersion = raHireGroupInsurance.RowVersion + 1;
            }
        }

        /// <summary>
        /// Delete RaHireGroup Insurances
        /// </summary>
        private static void DeleteRaHireGroupInsurances(RaHireGroup raHireGroup, RaHireGroup raHireGroupDbVersion)
        {
            List<RaHireGroupInsurance> raHireGroupInsurancesToDelete = raHireGroupDbVersion.RaHireGroupInsurances
                .Where(raHireGroupInsurance =>
                    raHireGroup.RaHireGroupInsurances.All(
                        raHgIns => raHgIns.RaHireGroupInsuranceId != raHireGroupInsurance.RaHireGroupInsuranceId)).ToList();
            raHireGroupInsurancesToDelete.ForEach(ins => raHireGroupDbVersion.RaHireGroupInsurances.Remove(ins));
        }

        /// <summary>
        /// Update RaHireGroup Existing Header Info
        /// </summary>
        private static void UpdateRaHireGroupExistingHeader(RaHireGroup raHireGroupDbVersion, RaHireGroup raHireGroup)
        {
            raHireGroupDbVersion.AllocationStatusId = raHireGroup.AllocationStatusId;
            raHireGroupDbVersion.VehicleId = raHireGroup.VehicleId;
            raHireGroupDbVersion.TotalExcMileage = raHireGroup.TotalExcMileage;
            raHireGroupDbVersion.AllowedMileage = raHireGroup.AllowedMileage;
            raHireGroupDbVersion.DropOffCharge = raHireGroup.DropOffCharge;
            raHireGroupDbVersion.ExcessMileageRt = raHireGroup.ExcessMileageRt;
            raHireGroupDbVersion.TotalExcMileageCharge = raHireGroup.TotalExcMileageCharge;
            raHireGroupDbVersion.ChargedDay = raHireGroup.ChargedDay;
            raHireGroupDbVersion.ChargedHour = raHireGroup.ChargedHour;
            raHireGroupDbVersion.ChargedMinute = raHireGroup.ChargedMinute;
            raHireGroupDbVersion.TotalStandardCharge = raHireGroup.TotalStandardCharge;
            raHireGroupDbVersion.TariffTypeCode = raHireGroup.TariffTypeCode;
            raHireGroupDbVersion.RentalChargeEndDate = raHireGroup.RentalChargeEndDate;
            raHireGroupDbVersion.StandardRate = raHireGroup.StandardRate;
            raHireGroupDbVersion.RentalChargeStartDate = raHireGroup.RentalChargeStartDate;
        }

        /// <summary>
        /// Delete Ra HireGroups
        /// </summary>
        private static void DeleteRaHireGroups(RaMain raMain, RaMain raMainDbVersion)
        {
            List<RaHireGroup> raHireGroupsToRemove = new List<RaHireGroup>();
            raHireGroupsToRemove.AddRange(from raHireGroup in raMainDbVersion.RaHireGroups
                                          let @group = raHireGroup
                                          where
                                              raMain.RaHireGroups.All(hg => hg.RaHireGroupId != @group.RaHireGroupId)
                                          select raHireGroup);
            raHireGroupsToRemove.ForEach(raHireGroup => raMainDbVersion.RaHireGroups.Remove(raHireGroup));
        }

        /// <summary>
        /// Update business partner
        /// </summary>
        private void UpdateBusinessPartner(BusinessPartner businessPartner)
        {
            BusinessPartner businessPartnerDbVersion = businessPartnerRepository.Find(businessPartner.BusinessPartnerId);

            if (businessPartnerDbVersion != null)
            {
                //set master(business partner) properties
                #region Business Partner
                businessPartnerDbVersion.BusinessPartnerName = businessPartner.BusinessPartnerName;
                businessPartnerDbVersion.BusinessPartnerDesciption = businessPartner.BusinessPartnerDesciption;
                businessPartnerDbVersion.IsSystemGuarantor = businessPartner.IsSystemGuarantor;
                businessPartnerDbVersion.NonSystemGuarantor = businessPartner.NonSystemGuarantor;
                businessPartnerDbVersion.IsIndividual = businessPartner.IsIndividual;
                businessPartnerDbVersion.BusinessPartnerEmailAddress = businessPartner.BusinessPartnerEmailAddress;
                businessPartnerDbVersion.CompanyId = businessPartner.CompanyId;
                businessPartnerDbVersion.SystemGuarantorId = businessPartner.SystemGuarantorId;
                businessPartnerDbVersion.BusinessLegalStatusId = businessPartner.BusinessLegalStatusId;
                businessPartnerDbVersion.DealingEmployeeId = businessPartner.DealingEmployeeId;
                businessPartnerDbVersion.PaymentTermId = businessPartner.PaymentTermId;
                businessPartnerDbVersion.BPRatingTypeId = businessPartner.BPRatingTypeId;

                businessPartnerDbVersion.RecLastUpdatedDt = DateTime.Now;
                businessPartnerDbVersion.RecCreatedBy = businessPartnerRepository.LoggedInUserIdentity;
                businessPartnerDbVersion.RowVersion = businessPartnerDbVersion.RowVersion + 1;
                #endregion

                //set child (buiness partner individual properties)
                #region Business Partner Individual
                businessPartnerDbVersion.BusinessPartnerIndividual.BusinessPartnerId = businessPartner.BusinessPartnerIndividual.BusinessPartnerId;
                businessPartnerDbVersion.BusinessPartnerIndividual.FirstName = businessPartner.BusinessPartnerIndividual.FirstName;
                businessPartnerDbVersion.BusinessPartnerIndividual.MiddleName = businessPartner.BusinessPartnerIndividual.MiddleName;
                businessPartnerDbVersion.BusinessPartnerIndividual.LastName = businessPartner.BusinessPartnerIndividual.LastName;
                businessPartnerDbVersion.BusinessPartnerIndividual.Initials = businessPartner.BusinessPartnerIndividual.Initials;
                businessPartnerDbVersion.BusinessPartnerIndividual.GenderStatus = businessPartner.BusinessPartnerIndividual.GenderStatus;
                businessPartnerDbVersion.BusinessPartnerIndividual.MaritalStatusCode = businessPartner.BusinessPartnerIndividual.MaritalStatusCode;
                businessPartnerDbVersion.BusinessPartnerIndividual.OccupationTypeId = businessPartner.BusinessPartnerIndividual.OccupationTypeId;
                businessPartnerDbVersion.BusinessPartnerIndividual.LastName = businessPartner.BusinessPartnerIndividual.LastName;
                businessPartnerDbVersion.BusinessPartnerIndividual.DateOfBirth = businessPartner.BusinessPartnerIndividual.DateOfBirth;
                businessPartnerDbVersion.BusinessPartnerIndividual.NicNumber = businessPartner.BusinessPartnerIndividual.NicNumber;
                businessPartnerDbVersion.BusinessPartnerIndividual.NicExpiryDate = businessPartner.BusinessPartnerIndividual.NicExpiryDate;
                businessPartnerDbVersion.BusinessPartnerIndividual.IqamaNo = businessPartner.BusinessPartnerIndividual.IqamaNo;
                businessPartnerDbVersion.BusinessPartnerIndividual.IqamaExpiryDate = businessPartner.BusinessPartnerIndividual.IqamaExpiryDate;
                businessPartnerDbVersion.BusinessPartnerIndividual.PassportNumber = businessPartner.BusinessPartnerIndividual.PassportNumber;
                businessPartnerDbVersion.BusinessPartnerIndividual.PassportExpiryDate = businessPartner.BusinessPartnerIndividual.PassportExpiryDate;
                businessPartnerDbVersion.BusinessPartnerIndividual.PassportCountryId = businessPartner.BusinessPartnerIndividual.PassportCountryId;
                businessPartnerDbVersion.BusinessPartnerIndividual.LiscenseNumber = businessPartner.BusinessPartnerIndividual.LiscenseNumber;
                businessPartnerDbVersion.BusinessPartnerIndividual.LiscenseExpiryDate = businessPartner.BusinessPartnerIndividual.LiscenseExpiryDate;
                businessPartnerDbVersion.BusinessPartnerIndividual.TaxRegisterationCode = businessPartner.BusinessPartnerIndividual.TaxRegisterationCode;
                businessPartnerDbVersion.BusinessPartnerIndividual.TaxNumber = businessPartner.BusinessPartnerIndividual.TaxNumber;
                businessPartnerDbVersion.BusinessPartnerIndividual.IsCompanyExternal = businessPartner.BusinessPartnerIndividual.IsCompanyExternal;
                businessPartnerDbVersion.BusinessPartnerIndividual.BusinessPartnerCompanyId = businessPartner.BusinessPartnerIndividual.BusinessPartnerCompanyId;
                businessPartnerDbVersion.BusinessPartnerIndividual.CompanyName = businessPartner.BusinessPartnerIndividual.CompanyName;
                businessPartnerDbVersion.BusinessPartnerIndividual.CompanyPhone = businessPartner.BusinessPartnerIndividual.CompanyPhone;
                businessPartnerDbVersion.BusinessPartnerIndividual.CompanyAddress = businessPartner.BusinessPartnerIndividual.CompanyAddress;

                businessPartnerDbVersion.BusinessPartnerIndividual.RowVersion = businessPartnerDbVersion.BusinessPartnerIndividual.RowVersion + 1;
                businessPartnerDbVersion.BusinessPartnerIndividual.RecLastUpdatedDt = DateTime.Now;
                businessPartnerDbVersion.BusinessPartnerIndividual.RecLastUpdatedBy = businessPartnerRepository.LoggedInUserIdentity;
                #endregion

                //set child (buiness partner company properties)
                #region Business Partner Company
                businessPartnerDbVersion.BusinessPartnerCompany.BusinessPartnerId = businessPartner.BusinessPartnerId;
                businessPartnerDbVersion.BusinessPartnerCompany.BusinessPartnerCompanyCode =
                    businessPartner.BusinessPartnerCompany.BusinessPartnerCompanyCode;
                businessPartnerDbVersion.BusinessPartnerCompany.BusinessPartnerCompanyName =
                    businessPartner.BusinessPartnerCompany.BusinessPartnerCompanyName;
                businessPartnerDbVersion.BusinessPartnerCompany.BusinessSegmentId =
                    businessPartner.BusinessPartnerCompany.BusinessSegmentId;
                businessPartnerDbVersion.BusinessPartnerCompany.AccountNumber =
                    businessPartner.BusinessPartnerCompany.AccountNumber;
                businessPartnerDbVersion.BusinessPartnerCompany.EstablishedSince =
                    businessPartner.BusinessPartnerCompany.EstablishedSince;
                businessPartnerDbVersion.BusinessPartnerCompany.SwiftCode =
                    businessPartner.BusinessPartnerCompany.SwiftCode;

                businessPartnerDbVersion.BusinessPartnerCompany.RowVersion =
                    businessPartnerDbVersion.BusinessPartnerCompany.RowVersion + 1;
                businessPartnerDbVersion.BusinessPartnerCompany.RecLastUpdatedDt = DateTime.Now;
                businessPartnerDbVersion.BusinessPartnerCompany.RecLastUpdatedBy = businessPartnerRepository.LoggedInUserIdentity;
                #endregion

                //set child (business partner phones)
                #region Business Partner Phones
                //add new phone items
                foreach (Phone phone in businessPartner.BusinessPartnerPhoneNumbers)
                {
                    if (businessPartnerDbVersion.BusinessPartnerPhoneNumbers.All(x => x.PhoneId != phone.PhoneId) || phone.PhoneId == 0)
                    {
                        // set properties
                        phone.IsActive = true;
                        phone.RecCreatedDt = DateTime.Now;
                        phone.RecLastUpdatedDt = DateTime.Now;
                        phone.RecCreatedBy = businessPartnerRepository.LoggedInUserIdentity;
                        phone.RecLastUpdatedBy = businessPartnerRepository.LoggedInUserIdentity;
                        phone.RowVersion = 0;
                        phone.UserDomainKey = businessPartnerRepository.UserDomainKey;
                        businessPartnerDbVersion.BusinessPartnerPhoneNumbers.Add(phone);
                    }
                }
                //find missing phone items
                List<Phone> missingPhoneItems = businessPartnerDbVersion.BusinessPartnerPhoneNumbers.Where(phone => phone.IsDefault).Where(dbversionPhoneItem => businessPartner.BusinessPartnerPhoneNumbers.All(x => x.PhoneId != dbversionPhoneItem.PhoneId)).ToList();
                //remove missing phone items
                foreach (Phone missingBusinessPartnerPhone in missingPhoneItems)
                {
                    Phone dbVersionMissingPhoneItem = businessPartnerDbVersion.BusinessPartnerPhoneNumbers.First(x => x.PhoneId == missingBusinessPartnerPhone.PhoneId);
                    if (dbVersionMissingPhoneItem.PhoneId > 0)
                    {
                        businessPartnerDbVersion.BusinessPartnerPhoneNumbers.Remove(dbVersionMissingPhoneItem);
                        businessPartnerPhoneRepository.Delete(dbVersionMissingPhoneItem);
                    }
                }
                #endregion

                //set child (business partner address list)
                #region Business Partner Address List
                //add new address items
                foreach (Address address in businessPartner.BusinessPartnerAddressList)
                {
                    if (businessPartnerDbVersion.BusinessPartnerAddressList.All(x => x.AddressId != address.AddressId) || address.AddressId == 0)
                    {
                        // set properties
                        address.IsActive = true;
                        address.RecCreatedDt = DateTime.Now;
                        address.RecLastUpdatedDt = DateTime.Now;
                        address.RecCreatedBy = businessPartnerRepository.LoggedInUserIdentity;
                        address.RecLastUpdatedBy = businessPartnerRepository.LoggedInUserIdentity;
                        address.RowVersion = 0;
                        address.UserDomainKey = businessPartnerRepository.UserDomainKey;
                        businessPartnerDbVersion.BusinessPartnerAddressList.Add(address);
                    }
                }
                //find missing address items
                List<Address> missingAddressItems = businessPartnerDbVersion.BusinessPartnerAddressList.Where(dbversionAddressItem => businessPartner.BusinessPartnerAddressList.All(x => x.AddressId != dbversionAddressItem.AddressId)).ToList();
                //remove missing address items
                foreach (Address missingBusinessPartnerAddress in missingAddressItems)
                {
                    Address dbVersionMissingAddressItem = businessPartnerDbVersion.BusinessPartnerAddressList.First(x => x.AddressId == missingBusinessPartnerAddress.AddressId);
                    if (dbVersionMissingAddressItem.AddressId > 0)
                    {
                        businessPartnerDbVersion.BusinessPartnerAddressList.Remove(dbVersionMissingAddressItem);
                        businessPartnerAddressRepository.Delete(dbVersionMissingAddressItem);
                    }
                }
                #endregion
            }

        }

        /// <summary>
        /// Map RaMain Header
        /// </summary>
        private void MapRaHeader(RaMain raMain)
        {
            raMain.RaStatusId = (short)RaStatusEnum.Open;
            raMain.RecCreatedBy = raMain.RecLastUpdatedBy = rentalAgreementRepository.LoggedInUserIdentity;
            raMain.RecLastUpdatedDt = raMain.RecCreatedDt;
            raMain.UserDomainKey = rentalAgreementRepository.UserDomainKey;
            raMain.IsActive = true;
            raMain.RowVersion = 0;
        }

        /// <summary>
        /// Save Chauffer Reservations
        /// </summary>
        private void SaveChaufferReservation(RaMain raMain)
        {
            List<RaDriver> chauffers =
                raMain.RaDrivers.Where(driver => driver.IsChauffer && driver.ChaufferId.HasValue).ToList();

            // Check for Chauffer Reservation
            if (raMain.ChaufferReservations == null)
            {
                raMain.ChaufferReservations = new List<ChaufferReservation>();
            }

            foreach (RaDriver chauffer in chauffers)
            {
                raMain.ChaufferReservations.Add(CreateChaufferReservation(raMain, chauffer));
            }
        }

        /// <summary>
        /// Create Chauffer Reservation
        /// </summary>
        private ChaufferReservation CreateChaufferReservation(RaMain raMain, RaDriver chauffer)
        {
            return new ChaufferReservation
            {
                IsActive = true,
                RecCreatedDt = DateTime.Now,
                RecLastUpdatedDt = DateTime.Now,
                RecLastUpdatedBy = rentalAgreementRepository.LoggedInUserIdentity,
                RecCreatedBy = rentalAgreementRepository.LoggedInUserIdentity,
                RaMainId = raMain.RaMainId,
                ChaufferId = chauffer.ChaufferId ?? 0,
                StartDtTime = chauffer.StartDtTime,
                EndDtTime = chauffer.EndDtTime,
                UserDomainKey = rentalAgreementRepository.UserDomainKey
            };
        }

        #endregion

        #region Constructors

        /// <summary>
        /// Constructor
        /// </summary>
        public RentalAgreementService(IPaymentTermRepository paymentTermRepository, IOperationRepository operationRepository,
            IOperationsWorkPlaceRepository operationsWorkPlaceRepository, ITariffTypeRepository tariffTypeRepository, IBill bill,
            IVehicleStatusRepository vehicleStatusRepository, IAlloactionStatusRepository alloactionStatusRepository, IRentalAgreementRepository rentalAgreementRepository,
            IBusinessPartnerRepository businessPartnerRepository, IPhoneRepository businessPartnerPhoneRepository, IAddressRepository businessPartnerAddressRepository,
            IVehicleRepository vehicleRepository)
        {
            if (paymentTermRepository == null)
            {
                throw new ArgumentNullException("paymentTermRepository");
            }

            if (operationRepository == null)
            {
                throw new ArgumentNullException("operationRepository");
            }
            if (operationsWorkPlaceRepository == null)
            {
                throw new ArgumentNullException("operationsWorkPlaceRepository");
            }
            if (tariffTypeRepository == null) throw new ArgumentNullException("tariffTypeRepository");
            if (bill == null) throw new ArgumentNullException("bill");
            if (vehicleStatusRepository == null) throw new ArgumentNullException("vehicleStatusRepository");
            if (alloactionStatusRepository == null) throw new ArgumentNullException("alloactionStatusRepository");
            if (rentalAgreementRepository == null) throw new ArgumentNullException("rentalAgreementRepository");
            if (businessPartnerRepository == null) throw new ArgumentNullException("businessPartnerRepository");
            if (businessPartnerPhoneRepository == null)
                throw new ArgumentNullException("businessPartnerPhoneRepository");
            if (businessPartnerAddressRepository == null)
                throw new ArgumentNullException("businessPartnerAddressRepository");
            if (vehicleRepository == null) throw new ArgumentNullException("vehicleRepository");

            this.paymentTermRepository = paymentTermRepository;
            this.operationRepository = operationRepository;
            this.operationsWorkPlaceRepository = operationsWorkPlaceRepository;
            this.tariffTypeRepository = tariffTypeRepository;
            this.bill = bill;
            this.vehicleStatusRepository = vehicleStatusRepository;
            this.alloactionStatusRepository = alloactionStatusRepository;
            this.rentalAgreementRepository = rentalAgreementRepository;
            this.businessPartnerRepository = businessPartnerRepository;
            this.businessPartnerPhoneRepository = businessPartnerPhoneRepository;
            this.businessPartnerAddressRepository = businessPartnerAddressRepository;
            this.vehicleRepository = vehicleRepository;
        }

        #endregion

        #region Public

        /// <summary>
        /// Get Base Data
        /// </summary>
        public RentalAgreementBaseDataResponse GetBaseData()
        {
            return new RentalAgreementBaseDataResponse
            {
                PaymentTerms = paymentTermRepository.GetAll(),
                Operations = operationRepository.GetSalesOperation(),
                OperationsWorkPlaces = operationsWorkPlaceRepository.GetSalesOperationsWorkPlace(),
                AllocationStatuses = alloactionStatusRepository.GetAll(),
                VehicleStatuses = vehicleStatusRepository.GetAll()
            };
        }

        /// <summary>
        /// Generates Bill For RA
        /// </summary>
        public RaMain GenerateBill(RaMain request)
        {
            List<TariffType> tariffTypes = tariffTypeRepository.GetAll().ToList();
            RaMain raMain = request;

            bill.CalculateBill(ref raMain, tariffTypes);

            return raMain;
        }

        /// <summary>
        /// Saves Rental Agreement
        /// </summary>
        public RaMain SaveRentalAgreement(RaMain raMain)
        {
            // Generate Bill
            raMain = GenerateBill(raMain);

            // Add Rental Agreement
            if (raMain.RaMainId == 0)
            {
                // Add To Repository
                rentalAgreementRepository.Add(raMain);

                // Map Main
                MapRaHeader(raMain);

                // Ra Hire Groups
                AddRaHireGroups(raMain.RaHireGroups);

                // Ra Additional Charges
                AddRaAdditionalCharges(raMain);

                // Ra Service Items
                AddRaServiceItems(raMain);

                // Ra Drivers
                AddRaDrivers(raMain);

                // Ra Payments
                AddRaPayments(raMain);

                // Ra Customer Documents
                AddRaCustomerDocuments(raMain);

                // Update / Add Business Partner
                if (raMain.BusinessPartnerId == 0)
                {
                    AddBusinessPartner(raMain.BusinessPartner);
                }
                else
                {
                    UpdateBusinessPartner(raMain.BusinessPartner);
                }

                // Save Chauffer Reservations
                SaveChaufferReservation(raMain);
            }
            // Update Rental Agreement
            else
            {
                // Find Db Version
                RaMain raMainDbVersion = rentalAgreementRepository.Find(raMain.RaMainId);

                // Assert
                if (raMainDbVersion == null)
                {
                    throw new InvalidOperationException(string.Format(CultureInfo.InvariantCulture,
                        "Rental Agreement with id {0} not found", raMain.RaMainId));
                }

                // Map Main 
                UpdateRaMainHeader(raMain, raMainDbVersion);

                // Update / Add Ra Hire Groups
                UpdateRaHireGroups(raMain, raMainDbVersion);

                // Update / Add Ra Additional Charges

                // Update / Add Ra Service Items

                // Update / Add Ra Drivers

                // Update / Add Ra Payments

                // Update / Add Ra Customer Documents

                // Update Business Partner
                UpdateBusinessPartner(raMain.BusinessPartner);

                // Update Chauffer Reservations
            }


            // Save Changes
            rentalAgreementRepository.SaveChanges();

            // Load Properties
            rentalAgreementRepository.LoadDependencies(raMain);

            return raMain;
        }

        #endregion
    }
}
