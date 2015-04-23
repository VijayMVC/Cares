define(["ko", "underscore", "underscore-ko"], function (ko) {

    var

    // Vehicle entity
    // ReSharper disable InconsistentNaming
    Vehicle = function (specifiedId, specifiedName, specifiedCode, specifiedPlateNumber, specifiedCurrentOdometer, specifiedVehicleCategoryId,
        specifiedVehicleCategoryCodeName, specifiedVehicleMakeId, specifiedVehicleMakeCodeName, specifiedVehicleModelId, specifiedVehicleModelCodeName,
        specifiedVehicleStatusId, specifiedVehicleStatusCodeName, specifiedModelYear, specifiedImage, specifiedFuelLevel, specifiedTankSize, specifiedTransmission, specifiedFuelType) {
        // ReSharper restore InconsistentNaming

        var
            // Plate Number
            plateNumber = ko.observable(specifiedPlateNumber),
            vehicleMakeName = specifiedVehicleMakeCodeName ? specifiedVehicleMakeCodeName.split('-')[1] : "",
            vehicleModelName = specifiedVehicleModelCodeName ? specifiedVehicleModelCodeName.split('-')[1] : "";
        // Tank Size
        var tankSize = ko.observable(specifiedTankSize);

        return {
            id: specifiedId,
            name: specifiedName,
            code: specifiedCode,
            plateNumber: plateNumber,
            currentOdometer: specifiedCurrentOdometer,
            vehicleCategoryId: specifiedVehicleCategoryId,
            vehicleCategory: specifiedVehicleCategoryCodeName,
            vehicleMakeId: specifiedVehicleMakeId,
            vehicleMake: specifiedVehicleMakeCodeName,
            vehicleMakeModel: vehicleMakeName + " - " + vehicleModelName,
            vehicleModelId: specifiedVehicleModelId,
            vehicleModel: specifiedVehicleModelCodeName,
            vehicleModelName: vehicleModelName,
            vehicleStatusId: specifiedVehicleStatusId,
            vehicleStatus: specifiedVehicleStatusCodeName,
            modelYear: specifiedModelYear,
            image: specifiedImage,
            fuelLevel: specifiedFuelLevel,
            tankSize: tankSize,
            fuelType: specifiedFuelType,
            transmissionType: specifiedTransmission
        };
    },

    // Vehicle Movement entity
    // ReSharper disable InconsistentNaming
    VehicleMovement = function (specifiedId, specifiedRaHireGroupId, specifiedOperationsWorkPlaceId, specifiedVehicleStatusId,
        specifiedStatus, specifiedDtTime, specifiedOdometer, specifiedFuelLevel, specifiedVehicleCondition, specifiedVehicleConditionDescription) {
        // ReSharper restore InconsistentNaming
        var
            // unique key
            id = ko.observable(specifiedId || 0),
            // Ra HireGroup Id
            raHireGroupId = ko.observable(specifiedRaHireGroupId || 0),
            // Vehicle Status Id
            vehicleStatusId = ko.observable(specifiedVehicleStatusId),
            // Status
            status = ko.observable(specifiedStatus),
            // Odometer
            odometer = ko.observable(specifiedOdometer),
            // Fuel Level
            fuelLevel = ko.observable(specifiedFuelLevel),
            // Operations Workplace Id
            operationsWorkPlaceId = ko.observable(specifiedOperationsWorkPlaceId),
            // Vehicle Condition
            vehicleCondition = ko.observable(specifiedVehicleCondition || "000000000000000000000000000"),
            // Vehicle Condition Description
            vehicleConditionDescription = ko.observable(specifiedVehicleConditionDescription),
            // Start Date Time
            internalStartDateTime = ko.observable(specifiedDtTime || moment().toDate()),
            // Start Date
            start = ko.computed({
                read: function () {
                    return internalStartDateTime();
                },
                write: function (value) {
                    if (value === internalStartDateTime()) {
                        return;
                    }
                    if (!value) {
                        internalStartDateTime(undefined);
                    } else {
                        internalStartDateTime(value);
                    }
                }
            }),
            // Convert To Server Data
            convertToServerData = function () {
                return {
                    VehicleMovementId: id(),
                    RaHireGroupId: raHireGroupId(),
                    Status: status(),
                    Odometer: odometer(),
                    FuelLevel: fuelLevel(),
                    OperationsWorkPlaceId: operationsWorkPlaceId(),
                    VehicleCondition: vehicleCondition(),
                    DtTime: moment(start()).format(ist.utcFormat) + 'Z',
                    VehicleConditionDescription: vehicleConditionDescription(),
                    VehicleStatusId: vehicleStatusId()
                };
            };

        return {
            id: id,
            raHireGroupId: raHireGroupId,
            vehicleStatusId: vehicleStatusId,
            status: status,
            odometer: odometer,
            fuelLevel: fuelLevel,
            operationsWorkPlaceId: operationsWorkPlaceId,
            vehicleCondition: vehicleCondition,
            vehicleConditionDescription: vehicleConditionDescription,
            start: start,
            convertToServerData: convertToServerData
        };
    },

    // Payment Term entity
    // ReSharper disable InconsistentNaming
    PaymentTerm = function (specifiedId, specifiedCodeName) {
        // ReSharper restore InconsistentNaming
        return {
            id: specifiedId,
            codeName: specifiedCodeName
        };
    },

    // Operation entity
    // ReSharper disable InconsistentNaming
    Operation = function (specifiedId, specifiedCodeName) {
        // ReSharper restore InconsistentNaming
        return {
            id: specifiedId,
            codeName: specifiedCodeName
        };
    },

    // Operations WorkPlace entity
    // ReSharper disable InconsistentNaming
    OperationsWorkPlace = function (specifiedId, specifiedCode, specifiedOperationId) {
        // ReSharper restore InconsistentNaming
        return {
            id: specifiedId,
            code: specifiedCode,
            operationId: specifiedOperationId
        };
    },

    // Hire Group Detail entity
    // ReSharper disable InconsistentNaming
    HireGroupDetail = function (specifiedId, specifiedCode, specifiedCategory, specifiedMake, specifiedModel, specifiedModelYear, specifiedHireGroupId) {
        // ReSharper restore InconsistentNaming
        return {
            id: specifiedId,
            code: specifiedCode,
            vehicleCategory: specifiedCategory,
            vehicleMake: specifiedMake,
            vehicleModel: specifiedModel,
            vehicleModelYear: specifiedModelYear,
            hireGroupId: specifiedHireGroupId,
            hireGroup: specifiedCode + ' | ' + specifiedCategory + ' | ' + specifiedMake + ' | ' + specifiedModel + ' | ' + specifiedModelYear
        };
    },

    // Rental Agreement entity
    // ReSharper disable InconsistentNaming
    RentalAgreement = function (specifiedId, specifiedStartDate, specifiedEndDate, specifiedPaymentTermId, specifiedOperationId, specifiedOpenLocation,
        specifiedCloseLocation, specifiedBusinessPartner, specifiedRentersName, specifiedRentersLicenseNo, specifiedRentersLicenseExpiry, specifiedRecCreatedDt,
        specifiedRaStatusId, specifiedRaBookingId, callbacks) {
        // ReSharper restore InconsistentNaming
        var
            // unique key
            id = ko.observable(specifiedId || 0),
            // RA Hire Groups
            rentalAgreementHireGroups = ko.observableArray([]),
            // RA Service Items
            rentalAgreementServiceItems = ko.observableArray([]),
            // RA Drivers
            rentalAgreementDrivers = ko.observableArray([]),
            // RA Additional Charge
            rentalAgreementAdditionalCharges = ko.observableArray([]),
            // Business Partner
            businessPartner = ko.observable(BusinessPartner.Create(specifiedBusinessPartner || {}, callbacks)),
            // Billing
            billing = ko.observable(Billing.Create({})),
            // Ra Payments
            raPayments = ko.observableArray([]),
            // Start Date Time
            internalStartDateTime = ko.observable(specifiedStartDate || moment().toDate()),
            // End Date Time
            internalEndDateTime = ko.observable(specifiedEndDate || moment().add('days', 1).toDate()),
            // day
            internalDays = ko.observable(1),
            // hour
            internalHours = ko.observable(),
            // minutes
            internalMinutes = ko.observable(),
            // Start Date
            start = ko.computed({
                read: function () {
                    return internalStartDateTime();
                },
                write: function (value) {
                    if (value === internalStartDateTime()) {
                        return;
                    }
                    if (!value) {
                        internalStartDateTime(undefined);
                    } else {
                        internalStartDateTime(value);

                        var delta = moment.duration(end() - internalStartDateTime());

                        internalDays(!isNaN(delta.asDays()) ? Number(delta.asDays()).toFixed(0) : undefined);
                        internalHours(!isNaN(delta.asHours()) ? Number(delta.hours()).toFixed(0) : undefined);
                        internalMinutes(!isNaN(delta.asMinutes()) ? Number(delta.minutes()).toFixed(0) : undefined);
                        if (callbacks && callbacks.OnRentalDurationChange) {
                            callbacks.OnRentalDurationChange();
                        }
                    }
                }
            }),
            // End Date
            end = ko.computed({
                read: function () {
                    return internalEndDateTime();
                },
                write: function (value) {
                    if (value === internalEndDateTime()) {
                        return;
                    }
                    if (!value) {
                        internalEndDateTime(undefined);
                    } else {
                        internalEndDateTime(value);
                        var delta = moment.duration(internalEndDateTime() - start());

                        internalDays(!isNaN(delta.asDays()) ? Number(delta.asDays()).toFixed(0) : undefined);
                        internalHours(!isNaN(delta.asHours()) ? Number(delta.hours()).toFixed(0) : undefined);
                        internalMinutes(!isNaN(delta.asMinutes()) ? Number(delta.minutes()).toFixed(0) : undefined);
                        if (callbacks && callbacks.OnRentalDurationChange) {
                            callbacks.OnRentalDurationChange();
                        }
                    }
                }
            }),
            // Days
            days = ko.computed({
                read: function () {
                    return internalDays();
                },
                write: function (value) {
                    if (internalDays() === value) {
                        return;
                    }
                    if (!value) {
                        return;
                    }
                    else {
                        internalDays(value);
                        end(new Date(start().getFullYear(), start().getMonth(), start().getDate() + parseInt(value), start().getHours() + parseInt(hours() ? hours() : 0),
                            start().getMinutes() + parseInt(minutes() ? minutes() : 0)));
                    }
                }
            }),
            // Hours
            hours = ko.computed({
                read: function () {
                    return internalHours();
                },
                write: function (value) {
                    if (internalHours() === value) {
                        return;
                    }
                    if (!value) {
                        return;
                    }
                    else {
                        internalHours(value);
                        end(new Date(start().getFullYear(), start().getMonth(), start().getDate() + parseInt(days() ? days() : 0), start().getHours() + parseInt(value),
                            start().getMinutes() + parseInt(minutes() ? minutes() : 0)));
                    }
                }
            }),
            // Hours
            minutes = ko.computed({
                read: function () {
                    return internalMinutes();
                },
                write: function (value) {
                    if (internalMinutes() === value) {
                        return;
                    }
                    if (!value) {
                        return;
                    }
                    else {
                        internalMinutes(value);
                        end(new Date(start().getFullYear(), start().getMonth(), start().getDate() + parseInt(days() ? days() : 0),
                            start().getHours() + parseInt(hours() ? hours() : 0), start().getMinutes() + parseInt(value)));
                    }
                }
            }),
            // Payment Term
            paymentTermId = ko.observable(specifiedPaymentTermId || undefined).extend({
                required: true
            }),
            // Operation
            operationId = ko.observable(specifiedOperationId || undefined).extend({
                required: true
            }),
            // Open Location
            internalOpenLocation = ko.observable(specifiedOpenLocation || undefined).extend({
                required: true
            }),
            // Open Location
            openLocation = ko.computed({
                read: function () {
                    return internalOpenLocation();
                },
                write: function (value) {
                    if (!value || value === internalOpenLocation()) {
                        return;
                    }

                    internalOpenLocation(value);

                    if (callbacks && callbacks.OnOutLocationChange) {
                        callbacks.OnOutLocationChange();
                    }
                }
            }),
            // Close Location
            closeLocation = ko.observable(specifiedCloseLocation || undefined),
            // Remove Ra Service Item
            removeRaServiceItem = function (raServiceItem) {
                rentalAgreementServiceItems.remove(raServiceItem);
            },
            // Ra Chauffers
            raChauffers = ko.computed(function () {
                return rentalAgreementDrivers.filter(function (raDriver) {
                    return raDriver.isChauffer();
                });
            }),
            // Ra Drivers
            raDrivers = ko.computed(function () {
                return rentalAgreementDrivers.filter(function (raDriver) {
                    return !raDriver.isChauffer();
                });
            }),
            // Remove Ra Driver
            removeRaDriver = function (raDriver) {
                rentalAgreementDrivers.remove(raDriver);
            },
            // Remove Ra Additional Charge
            removeRaAdditionalCharge = function (raAdditionalCharge) {
                rentalAgreementAdditionalCharges.remove(raAdditionalCharge);
            },
            // Remove Ra Hire Group
            removeRaHireGroup = function (raHireGroup) {
                rentalAgreementHireGroups.remove(raHireGroup);
            },
            // Remove Ra Payment
            removeRaPayment = function (raPayment) {
                raPayments.remove(raPayment);
            },
            // Renters Name
            rentersName = ko.observable(specifiedRentersName),
            // Renters License No
            rentersLicenseNo = ko.observable(specifiedRentersLicenseNo),
            // Internal Renters License Expiry
            internalRentersLicenseExpiry = ko.observable(specifiedRentersLicenseExpiry),

            // Renters License Expiry
            rentersLicenseExpiry = ko.computed({

                read: function () {
                    return internalRentersLicenseExpiry();
                },
                write: function (value) {
                    if (!value || internalRentersLicenseExpiry() === value) {
                        return;
                    }
                    internalRentersLicenseExpiry(value);
                    if (callbacks && callbacks.OnRentersLicenseExpiryChanged && typeof callbacks.OnRentersLicenseExpiryChanged === "function" && !businessPartner().isIndividual()) {
                        callbacks.OnRentersLicenseExpiryChanged(value);
                    }
                }
            }),
            // Internal Renters License Expiry Hijri
            internalRentersLicenseExpiryHijri = ko.observable(specifiedRentersLicenseExpiry ? ConvertDates(moment(specifiedRentersLicenseExpiry).format(ist.customLongDateWithFullYearPattern),
            'gregorian', 'islamic') : undefined),
            // Renters License Expiry Hijri
            rentersLicenseExpiryHijri = ko.computed({
                read: function () {
                    return internalRentersLicenseExpiryHijri();
                },
                write: function (value) {
                    if (!value || internalRentersLicenseExpiryHijri() === value) {
                        return;
                    }

                    internalRentersLicenseExpiryHijri(value);
                    if (callbacks && callbacks.OnRentersLicenseExpiryHijriChanged && typeof callbacks.OnRentersLicenseExpiryHijriChanged === "function" && !businessPartner().isIndividual()) {
                        callbacks.OnRentersLicenseExpiryHijriChanged(value);
                    }
                }
            }),
            // RecCreated Dt
            recCreatedDt = ko.observable(specifiedRecCreatedDt || moment().toDate()),
            // RaStatus Id
            raStatusId = ko.observable(specifiedRaStatusId || undefined),
            // Internal Ra Booking Id
            internalRaBookingId = ko.observable(specifiedRaBookingId || undefined),
            // RaBooking Id
            raBookingId = ko.computed({
                read: function () {
                    return internalRaBookingId();
                },
                write: function (value) {
                    if (!value || internalRaBookingId() === value) {
                        return;
                    }

                    internalRaBookingId(value);
                    if (callbacks && callbacks.OnBookingNoChange) {
                        callbacks.OnBookingNoChange(value);
                    }
                }
            }),
            // Validation Errors
            errors = ko.validation.group({
                paymentTermId: paymentTermId,
                operationId: operationId,
                internalOpenLocation: internalOpenLocation
            }),
            // Is Invalid period
            isInvalidPeriod = ko.computed(function () {
                return end() < start();
            }),
            // Is License Expired
            isLicenseExpired = ko.computed(function () {
                if (!rentersLicenseExpiry()) {
                    return false;
                }

                return !businessPartner().isIndividual() && moment(rentersLicenseExpiry()).clone().hours(0).minutes(0).seconds(0).milliseconds(0) < moment().hours(0).minutes(0).seconds(0).milliseconds(0).toDate();
            }),
            isValid = ko.computed(function () {
                return errors().length === 0 && !isInvalidPeriod() && businessPartner().isValid() && !isLicenseExpired() &&
                    rentalAgreementServiceItems.filter(function (raServiceItem) {
                        return !raServiceItem.isValid();
                    }).length === 0 &&
                    rentalAgreementDrivers.filter(function (raDriver) {
                        return !raDriver.isValid();
                    }).length === 0 &&
                    rentalAgreementAdditionalCharges.filter(function (raAdditionalCharge) {
                        return !raAdditionalCharge.isValid();
                    }).length === 0 &&
                    rentalAgreementHireGroups.filter(function (raHireGroup) {
                        return !raHireGroup.isValid();
                    }).length === 0;
            }),
            // Is Header Valid - For Agreement Part
            isHeaderValid = ko.computed(function () {
                return errors().length === 0;
            }),
            // Convert To Server Data
            convertToServerData = function () {
                return {
                    RaMainId: id(),
                    PaymentTermId: paymentTermId(),
                    OpenLocation: openLocation(),
                    CloseLocation: closeLocation(),
                    StartDtTime: moment(start()).format(ist.utcFormat) + 'Z',
                    EndDtTime: moment(end()).format(ist.utcFormat) + 'Z',
                    OperationId: operationId(),
                    BusinessPartnerId: businessPartner().id(),
                    RecCreatedDt: moment(recCreatedDt()).format(ist.utcFormat) + 'Z',
                    AmountPaid: billing().amountPaid(),
                    Balance: billing().balance(),
                    TotalVehicleCharge: billing().vehicleCharge(),
                    TotalInsuranceCharge: billing().insuranceCharge(),
                    VoucherDiscount: billing().voucherDiscount(),
                    SeasonalDiscount: billing().seasonalDiscount(),
                    SpecialDiscount: billing().specialDiscount(),
                    IsSpecialDiscountPerc: billing().isSpecialDiscountPerc(),
                    NetBillAfterDiscount: billing().netBilling(),
                    TotalExcessMileageCharge: billing().excessMileage(),
                    TotalServiceCharge: billing().serviceCharge(),
                    TotalDriverCharge: billing().driverCharge(),
                    TotalAdditionalCharge: billing().additionalCharge(),
                    TotalOtherCharge: billing().totalCharges(),
                    TotalDropOffCharge: billing().totalDropOffCharge(),
                    SpecialDiscountPerc: billing().specialDiscountPerc(),
                    StandardDiscount: billing().standardDiscount(),
                    RentersName: rentersName(),
                    RentersLicenseNumber: rentersLicenseNo(),
                    RentersLicenseExpDt: rentersLicenseExpiry() ? moment(rentersLicenseExpiry()).format(ist.utcFormat) + 'Z' : undefined,
                    RaStatusId: raStatusId(),
                    RaBookingId: raBookingId(),
                    RaHireGroups: rentalAgreementHireGroups.map(function (raHireGroup) {
                        return raHireGroup.convertToServerData();
                    }),
                    BusinessPartner: businessPartner().convertToServerData(),
                    RaServiceItems: rentalAgreementServiceItems.map(function (raServiceItem) {
                        return raServiceItem.convertToServerData();
                    }),
                    RaDrivers: rentalAgreementDrivers.map(function (raDriver) {
                        return raDriver.convertToServerData();
                    }),
                    RaAdditionalCharges: rentalAgreementAdditionalCharges.map(function (raAdditionalCharge) {
                        return raAdditionalCharge.convertToServerData();
                    }),
                    RaPayments: raPayments.map(function (raPayment) {
                        return raPayment.convertToServerData();
                    })
                };
            };

        return {
            id: id,
            paymentTermId: paymentTermId,
            operationId: operationId,
            openLocation: openLocation,
            internalOpenLocation: internalOpenLocation,
            closeLocation: closeLocation,
            start: start,
            end: end,
            days: days,
            hours: hours,
            minutes: minutes,
            rentersName: rentersName,
            rentersLicenseNo: rentersLicenseNo,
            rentersLicenseExpiry: rentersLicenseExpiry,
            rentalAgreementHireGroups: rentalAgreementHireGroups,
            businessPartner: businessPartner,
            billing: billing,
            raStatusId: raStatusId,
            raBookingId: raBookingId,
            rentalAgreementServiceItems: rentalAgreementServiceItems,
            removeRaServiceItem: removeRaServiceItem,
            rentalAgreementDrivers: rentalAgreementDrivers,
            rentalAgreementAdditionalCharges: rentalAgreementAdditionalCharges,
            raPayments: raPayments,
            raChauffers: raChauffers,
            raDrivers: raDrivers,
            removeRaDriver: removeRaDriver,
            removeRaHireGroup: removeRaHireGroup,
            removeRaAdditionalCharge: removeRaAdditionalCharge,
            removeRaPayment: removeRaPayment,
            errors: errors,
            isValid: isValid,
            isInvalidPeriod: isInvalidPeriod,
            isLicenseExpired: isLicenseExpired,
            isHeaderValid: isHeaderValid,
            convertToServerData: convertToServerData,
            rentersLicenseExpiryHijri: rentersLicenseExpiryHijri
        };
    },

    // Vehicle Movement Enum
    vehicleMovementEnum = {
        outMovement: true,
        inMovement: false
    },

    // Rental Agreement Hire Group entity
    // ReSharper disable InconsistentNaming
    RentalAgreementHireGroup = function (specifiedId, specifiedHireGroupDetailId, specifiedVehicleId, specifiedRentalAgreementId, specifiedVehicle,
        specifiedVehicleMovements, specifiedRaHireGroupInsurances, specifiedAllocationStatusKey, specifiedAllocationStatusId, specifiedRaVehicleCheckLists,
        specifiedHirGroup, isExisting, specifiedAgreement) {
        // ReSharper restore InconsistentNaming
        var
            // unique key
            id = ko.observable(specifiedId || 0),
            // Hire Group Detail Id
            hireGroupDetailId = ko.observable(specifiedHireGroupDetailId),
            // Vehicle Id
            vehicleId = ko.observable(specifiedVehicleId),
            // Rental Agreement Id
            rentalAgreementId = ko.observable(specifiedRentalAgreementId),
            // Vehicle
            vehicle = ko.observable(specifiedVehicle || Vehicle.Create({})),
            // Ra HireGroup Insurances
            raHireGroupInsurances = ko.observableArray(specifiedRaHireGroupInsurances ? _.map(specifiedRaHireGroupInsurances, function (raHireGroupInsurance) {
                var raHireGroupInsuranceItem = RentalAgreementHireGroupInsurance.Create(raHireGroupInsurance, specifiedAgreement);

                if (isExisting) {
                    raHireGroupInsuranceItem.isSelected(true);
                }

                return raHireGroupInsuranceItem;
            }) : []),
            // Ra Vehicle CheckLists
            raVehicleCheckLists = ko.observableArray(specifiedRaVehicleCheckLists ? _.map(specifiedRaVehicleCheckLists, function (raVehicleCheckList) {
                return RentalAgreementVehicleCheckList.Create(raVehicleCheckList, isExisting);
            }) : []),
            // Vehicle CheckLists Out
            raVehicleCheckListsOut = ko.computed(function () {
                var outvehicleCheckLists = raVehicleCheckLists.filter(function (vehicleCheckList) {
                    return vehicleCheckList.status() === vehicleMovementEnum.outMovement;
                });
                return outvehicleCheckLists || [];
            }),
            // Vehicle CheckLists In
            raVehicleCheckListsIn = ko.computed(function () {
                var invehicleCheckLists = raVehicleCheckLists.filter(function (vehicleCheckList) {
                    return vehicleCheckList.status() === vehicleMovementEnum.inMovement;
                });
                return invehicleCheckLists || [];
            }),
            // Vehicle Movements
            vehicleMovements = ko.observableArray(specifiedVehicleMovements ? _.map(specifiedVehicleMovements, function (vehicleMovement) {
                return VehicleMovement.Create(vehicleMovement);
            }) : []),
            // Vehicle Movement Out
            vehicleMovementOut = ko.computed(function () {
                var outMovement = vehicleMovements.find(function (vehicleMovement) {
                    return vehicleMovement.status() === vehicleMovementEnum.outMovement;
                });
                return outMovement || VehicleMovement.Create({});
            }),
            // Vehicle Movement In
            vehicleMovementIn = ko.computed(function () {
                var inMovement = vehicleMovements.find(function (vehicleMovement) {
                    return vehicleMovement.status() === vehicleMovementEnum.inMovement;
                });
                return inMovement || VehicleMovement.Create({});
            }),
            // Allocation Status Key
            allocationStatusKey = ko.observable(specifiedAllocationStatusKey),
            // Allocation Status Id
            allocationStatusId = ko.observable(specifiedAllocationStatusId),
            // Can Remove
            canRemove = ko.computed(function () {
                return !id();
            }),
            // Errors
            errors = ko.validation.group({

            }),
            // Is Valid
            isValid = ko.computed(function () {
                return errors().length === 0 &&
                    raHireGroupInsurances.filter(function (raHireGroupInsurance) {
                        return raHireGroupInsurance.isSelected() && !raHireGroupInsurance.isValid();
                    }).length === 0;
            }),
            // Convert To Server Data
            convertToServerData = function () {
                return {
                    RaHireGroupId: id(),
                    HireGroupDetailId: hireGroupDetailId(),
                    VehicleId: vehicleId(),
                    RaMainId: rentalAgreementId(),
                    AllocationStatusKey: allocationStatusKey(),
                    AllocationStatusId: allocationStatusId(),
                    AllocationStatus: { AllocationStatusId: allocationStatusId(), AllocationStatusKey: allocationStatusKey() },
                    RaHireGroupInsurances: raHireGroupInsurances.filter(function (raHireGroupInsurance) {
                        return raHireGroupInsurance.isSelected();
                    }).map(function (raHireGroupInsurance) {
                        return raHireGroupInsurance.convertToServerData();
                    }),
                    VehicleMovements: vehicleMovements.map(function (vehicleMovement) {
                        return vehicleMovement.convertToServerData();
                    }),
                    RaVehicleCheckLists: raVehicleCheckLists.filter(function (raVehicleCheckList) {
                        return raVehicleCheckList.isSelected();
                    }).map(function (raVehicleCheckList) {
                        return raVehicleCheckList.convertToServerData();
                    })
                };
            };

        return {
            id: id,
            hireGroupDetailId: hireGroupDetailId,
            hireGroup: specifiedHirGroup,
            vehicleId: vehicleId,
            rentalAgreementId: rentalAgreementId,
            vehicle: vehicle,
            vehicleMovements: vehicleMovements,
            vehicleMovementOut: vehicleMovementOut,
            vehicleMovementIn: vehicleMovementIn,
            raHireGroupInsurances: raHireGroupInsurances,
            raVehicleCheckLists: raVehicleCheckLists,
            raVehicleCheckListsOut: raVehicleCheckListsOut,
            raVehicleCheckListsIn: raVehicleCheckListsIn,
            allocationStatusKey: allocationStatusKey,
            allocationStatusId: allocationStatusId,
            canRemove: canRemove,
            errors: errors,
            isValid: isValid,
            convertToServerData: convertToServerData
        };
    },

    // Phone Type entity
    // ReSharper disable InconsistentNaming
    PhoneType = function (specifiedId, specifiedKey) {
        // ReSharper restore InconsistentNaming

        return {
            id: specifiedId,
            key: specifiedKey
        };
    },

    // Phone entity
    // ReSharper disable InconsistentNaming
    Phone = function (specifiedId, specifiedIsDefault, specifiedBusinessPartnerId, specifiedType, specifiedPhoneNo) {
        // ReSharper restore InconsistentNaming
        var
            // Unique Id
            id = ko.observable(specifiedId || 0),
            // Is Default 
            isDefault = ko.observable(specifiedIsDefault || undefined),
            // Business Partner Id
            businessPartnerId = ko.observable(specifiedBusinessPartnerId || 0),
            // Phone Type
            type = ko.observable(specifiedType || undefined),
            // Phone No
            internalPhoneNo = ko.observable(specifiedPhoneNo || undefined),
            // Phone Number
            phoneNo = ko.computed({
                read: function () {
                    return internalPhoneNo();
                },
                write: function (value) {
                    if (internalPhoneNo() === value) {
                        return;
                    }

                    internalPhoneNo(value);
                }
            }),
            // Convert To Server Data
            convertToServerData = function () {
                return {
                    PhoneId: id(),
                    IsDefault: isDefault(),
                    BusinessPartnerId: businessPartnerId(),
                    PhoneNumber: phoneNo(),
                    PhoneTypeId: type() ? type().key : 0
                };
            };

        return {
            id: id,
            isDefault: isDefault,
            businessPartnerId: businessPartnerId,
            type: type,
            phoneNo: phoneNo,
            convertToServerData: convertToServerData
        };
    },

    // Business Partner Company entity
    // ReSharper disable InconsistentNaming
    BusinessPartnerCompany = function (specifiedId, specifiedName, specifiedCode) {
        // ReSharper restore InconsistentNaming
        var
            // Business Partner key
            id = ko.observable(specifiedId || 0),
            // name
            name = ko.observable(specifiedName || undefined),
            // Code
            code = ko.observable(specifiedCode || undefined),
            // Convert To Server Data
            convertToServerData = function () {
                return {
                    BusinessPartnerId: id(),
                    BusinessPartnerCompanyCode: code(),
                    BusinessPartnerCompanyName: name()
                };
            };

        return {
            id: id,
            code: code,
            name: name,
            convertToServerData: convertToServerData
        };
    },

    // Business Partner Individual entity
    // ReSharper disable InconsistentNaming
    BusinessPartnerIndividual = function (specifiedId, specifiedFirstName, specifiedLastName, specifiedDOB, specifiedNicNumber, specifiedNicExpiry, specifiedPassportNo,
    specifiedPassportExpiry, specifiedLicenseNo, specifiedLicenseExpiry, callbacks, businessPartner) {
        // ReSharper restore InconsistentNaming
        var
            // Business Partner key
            id = ko.observable(specifiedId || 0),
            // First Name
            firstName = ko.observable(specifiedFirstName || undefined).extend({
                required: {
                    onlyIf: function () {
                        return businessPartner.isIndividual();
                    }
                }
            }),
            // Last Name
            lastName = ko.observable(specifiedLastName || undefined).extend({
                required: {
                    onlyIf: function () {
                        return businessPartner.isIndividual();
                    }
                }
            }),
            // Date of Birth
            dateOfBirth = ko.observable(specifiedDOB ? moment(specifiedDOB).toDate() : undefined).extend({
                required: {
                    onlyIf: function () {
                        return businessPartner.isIndividual();
                    }
                }
            }),
            // Nic Expiry
            internalNicExpiry = ko.observable(specifiedNicExpiry ? moment(specifiedNicExpiry).toDate() : undefined),
            // Nic Expiry
            nicExpiry = ko.computed({
                read: function () {
                    return internalNicExpiry();
                },
                write: function (value) {
                    if (!value || internalNicExpiry() === value) {
                        return;
                    }

                    internalNicExpiry(value);
                    if (callbacks && callbacks.OnNicExpiryChanged && typeof callbacks.OnNicExpiryChanged === "function" && businessPartner.isIndividual()) {
                        callbacks.OnNicExpiryChanged(value);
                    }
                }
            }),
            // Internal Nic Expiry Hijri
            internalNicExpiryHijri = ko.observable(specifiedNicExpiry ? ConvertDates(moment(specifiedNicExpiry).format(ist.customLongDateWithFullYearPattern),
            'gregorian', 'islamic') : undefined),
            // Nic Expiry Hijri
            nicExpiryHijri = ko.computed({
                read: function () {
                    return internalNicExpiryHijri();
                },
                write: function (value) {
                    if (!value || internalNicExpiryHijri() === value) {
                        return;
                    }

                    internalNicExpiryHijri(value);
                    if (callbacks && callbacks.OnNicExpiryHijriChanged && typeof callbacks.OnNicExpiryHijriChanged === "function" && businessPartner.isIndividual()) {
                        callbacks.OnNicExpiryHijriChanged(value);
                    }
                }
            }),
            // Passport Expiry
            internalPassportExpiry = ko.observable(specifiedPassportExpiry ? moment(specifiedPassportExpiry).toDate() : undefined),
            passportExpiry = ko.computed({
                read: function () {
                    return internalPassportExpiry();
                },
                write: function (value) {
                    if (!value || internalPassportExpiry() === value) {
                        return;
                    }
                    internalPassportExpiry(value);
                    if (callbacks && callbacks.OnPassportExpiryChanged && typeof callbacks.OnPassportExpiryChanged === "function" && businessPartner.isIndividual()) {
                        callbacks.OnPassportExpiryChanged(value);
                    }
                }
            }),
            // Internal Passport Expiry Hijri
            internalPassportExpiryHijri = ko.observable(specifiedPassportExpiry ? ConvertDates(moment(specifiedPassportExpiry).format(ist.customLongDateWithFullYearPattern),
            'gregorian', 'islamic') : undefined),
            // Passport Expiry Hijri
            passportExpiryHijri = ko.computed({
                read: function () {
                    return internalPassportExpiryHijri();
                },
                write: function (value) {
                    if (!value || internalPassportExpiryHijri() === value) {
                        return;
                    }

                    internalPassportExpiryHijri(value);
                    if (callbacks && callbacks.OnPassportExpiryHijriChanged && typeof callbacks.OnPassportExpiryHijriChanged === "function" && businessPartner.isIndividual()) {
                        callbacks.OnPassportExpiryHijriChanged(value);
                    }
                }
            }),
            // License Expiry
            licenseExpiry = ko.observable(specifiedLicenseExpiry ? moment(specifiedLicenseExpiry).toDate() : undefined),
            // Internal Nic Expiry Hijri
            internalLicenseExpiryHijri = ko.observable(specifiedLicenseExpiry ? ConvertDates(moment(specifiedLicenseExpiry).format(ist.customLongDateWithFullYearPattern),
            'gregorian', 'islamic') : undefined),
            // License Expiry Hijri
            licenseExpiryHijri = ko.computed({
                read: function () {
                    return internalLicenseExpiryHijri();
                },
                write: function (value) {
                    if (!value || internalLicenseExpiryHijri() === value) {
                        return;
                    }

                    internalLicenseExpiryHijri(value);
                    if (callbacks && callbacks.OnLicenseExpiryHijriChanged && typeof callbacks.OnLicenseExpiryHijriChanged === "function" && businessPartner.isIndividual()) {
                        callbacks.OnLicenseExpiryHijriChanged(value);
                    }
                }
            }),
            // Nic Number - Private
            internalNicNo = ko.observable(specifiedNicNumber || undefined),
            // Nic Number
            nicNo = ko.computed({
                read: function () {
                    return internalNicNo();
                },
                write: function (value) {
                    if (!value || internalNicNo() === value) {
                        return;
                    }

                    internalNicNo(value);
                    if (callbacks && callbacks.OnNicChanged && typeof callbacks.OnNicChanged === "function" && businessPartner.isIndividual()) {
                        callbacks.OnNicChanged(value);
                    }
                }
            }),
            // Passport Number
            internalPassportNo = ko.observable(specifiedPassportNo || undefined),
            // Passport Number
            passportNo = ko.computed({
                read: function () {
                    return internalPassportNo();
                },
                write: function (value) {
                    if (!value || internalPassportNo() === value) {
                        return;
                    }

                    internalPassportNo(value);
                    if (callbacks && callbacks.OnPassportChanged && typeof callbacks.OnPassportChanged === "function" && businessPartner.isIndividual()) {
                        callbacks.OnPassportChanged(value);
                    }
                }
            }),
            // License Number
            internalLicenseNo = ko.observable(specifiedLicenseNo || undefined),
            // License Number
            licenseNo = ko.computed({
                read: function () {
                    return internalLicenseNo();
                },
                write: function (value) {
                    if (!value || internalLicenseNo() === value) {
                        return;
                    }

                    internalLicenseNo(value);
                    if (callbacks && callbacks.OnLicenseChanged && typeof callbacks.OnLicenseChanged === "function" && businessPartner.isIndividual()) {
                        callbacks.OnLicenseChanged(value);
                    }
                }
            }),
            // Validation Errors
            errors = ko.validation.group({
                firstName: firstName,
                lastName: lastName,
                dateOfBirth: dateOfBirth
            }),
            // Is License Expired
            isLicenseExpired = ko.computed(function () {
                if (!licenseExpiry()) {
                    return false;
                }

                return businessPartner.isIndividual() && moment(licenseExpiry()).clone().hours(0).minutes(0).seconds(0).milliseconds(0) < moment().hours(0).minutes(0).seconds(0).milliseconds(0).toDate();
            }),
            // Is Age Valid
            isAgeValid = ko.computed(function () {
                return !dateOfBirth() || (businessPartner.isIndividual() && moment().add('years', -21).toDate() > dateOfBirth());
            }),
            isValid = ko.computed(function () {
                return errors().length === 0 && !isLicenseExpired() && isAgeValid();
            }),
            // Convert To Server Data
            convertToServerData = function () {
                return {
                    BusinessPartnerId: id(),
                    FirstName: firstName(),
                    LastName: lastName(),
                    DateOfBirth: moment(dateOfBirth()).format(ist.utcFormat) + 'Z',
                    NicExpiryDate: moment(nicExpiry()).format(ist.utcFormat) + 'Z',
                    LiscenseExpiryDate: moment(licenseExpiry()).format(ist.utcFormat) + 'Z',
                    PassportExpiryDate: moment(passportExpiry()).format(ist.utcFormat) + 'Z',
                    NicNumber: nicNo(),
                    LiscenseNumber: licenseNo(),
                    PassportNumber: passportNo()
                };
            };

        return {
            id: id,
            firstName: firstName,
            lastName: lastName,
            dateOfBirth: dateOfBirth,
            nicExpiry: nicExpiry,
            nicExpiryHijri: nicExpiryHijri,
            passportExpiry: passportExpiry,
            licenseExpiry: licenseExpiry,
            passportExpiryHijri: passportExpiryHijri,
            licenseExpiryHijri: licenseExpiryHijri,
            nicNo: nicNo,
            passportNo: passportNo,
            licenseNo: licenseNo,
            errors: errors,
            isValid: isValid,
            isLicenseExpired: isLicenseExpired,
            isAgeValid: isAgeValid,
            convertToServerData: convertToServerData
        };
    },

    // Business Partner entity
    // ReSharper disable InconsistentNaming
    BusinessPartner = function (specifiedId, specifiedIsIndividual, specifiedPaymentTerm, specifiedBusinessPartnerIndividual,
    specifiedCompany, specifiedEmail, callbacks) {
        // ReSharper restore InconsistentNaming
        var
            // unique key
            id = ko.observable(specifiedId || 0),
            // customer Number
            customerNo = ko.computed({
                read: function () {
                    return id();
                },
                write: function (value) {
                    if (!value || id() === value) {
                        return;
                    }

                    id(value);
                    if (callbacks && callbacks.OnCustomerNoChanged && typeof callbacks.OnCustomerNoChanged === "function") {
                        callbacks.OnCustomerNoChanged(value);
                    }
                }
            }),
            // Is Individual
            isIndividual = ko.observable(specifiedIsIndividual || true),
            // Email
            email = ko.observable(specifiedEmail || undefined).extend({
                email : true
            }),
            // Payment Term
            paymentTermId = ko.observable(specifiedPaymentTerm ? specifiedPaymentTerm.PaymentTermId : undefined).extend({ required: true }),
            // Company
            businessPartnerCompany = ko.observable(BusinessPartnerCompany.Create(specifiedCompany || {})),
            // Reference to this
            self = {
                isIndividual: isIndividual
            },
            // Individual
            businessPartnerIndividual = ko.observable(BusinessPartnerIndividual.Create(specifiedBusinessPartnerIndividual || {}, callbacks, self)),
            // Phones
            phones = ko.observableArray(_.map([
                { IsDefault: true, PhoneTypeKey: phoneTypes.HomePhone },
                { IsDefault: true, PhoneTypeKey: phoneTypes.CellularPone }
            ], function (phone) {
                return Phone.Create(phone);
            })),
            // Home Phone
            internalHomePhone = ko.observable(),
            // Home Phone
            homePhone = ko.computed({
                read: function () {
                    return internalHomePhone();
                },
                write: function (value) {
                    if (!value || internalHomePhone() === value) {
                        return;
                    }

                    internalHomePhone(value);
                    if (callbacks && callbacks.OnPhoneChanged && typeof callbacks.OnPhoneChanged === "function") {
                        callbacks.OnPhoneChanged(value, phoneTypes.HomePhone);
                    }
                }
            }),
            // Mobile Phone
            internalMobile = ko.observable(),
            // Mobile Phone
            mobile = ko.computed({
                read: function () {
                    return internalMobile();
                },
                write: function (value) {
                    if (!value || internalMobile() === value) {
                        return;
                    }

                    internalMobile(value);
                    if (callbacks && callbacks.OnPhoneChanged && typeof callbacks.OnPhoneChanged === "function") {
                        callbacks.OnPhoneChanged(value, phoneTypes.CellularPone);
                    }
                }
            }),
            // Validation Errors
            errors = ko.validation.group({
                paymentTermId: paymentTermId,
                email: email
            }),
            isValid = ko.computed(function () {
                return errors().length === 0 && (!isIndividual() || businessPartnerIndividual().isValid());
            }),
            // Convert To Server Data
            convertToServerData = function () {
                return {
                    BusinessPartnerId: id(),
                    IsIndividual: isIndividual(),
                    PaymentTermId: paymentTermId(),
                    BusinessPartnerEmailAddress: email(),
                    BusinessPartnerIndividual: businessPartnerIndividual().convertToServerData(),
                    BusinessPartnerCompany: businessPartnerCompany().convertToServerData(),
                    BusinessPartnerPhoneNumbers: phones.map(function (phone) {
                        var phoneItem = phone.convertToServerData();
                        phoneItem.PhoneNumber = phoneItem.PhoneTypeId === phoneTypes.HomePhone ? homePhone() : mobile();
                        return phoneItem;
                    })
                };
            };

        return {
            id: id,
            customerNo: customerNo,
            isIndividual: isIndividual,
            paymentTermId: paymentTermId,
            email: email,
            businessPartnerCompany: businessPartnerCompany,
            businessPartnerIndividual: businessPartnerIndividual,
            phones: phones,
            self: self,
            homePhone: homePhone,
            mobile: mobile,
            internalHomePhone: internalHomePhone,
            internalMobile: internalMobile,
            errors: errors,
            isValid: isValid,
            convertToServerData: convertToServerData
        };
    },

    // Billing entity
    // ReSharper disable InconsistentNaming
    Billing = function (specifiedVehicleCharge, specifiedStandardDiscount, specifiedSeasonalDiscount, specifiedVoucherDiscount, specifiedSpecialDiscount,
        specifiedExcessMileage, specifiedServiceCharge, specifiedInsuranceCharge, specifiedDriverCharge, specifiedAdditionalCharge, specifiedAmountPaid,
        specifiedNetBill, specifiedBalance, specifiedTotalCharges, specifiedSpecialDiscountPerc, specifiedTotalDropOffCharge, specifiedIsSpecialDiscountPerc) {
        // ReSharper restore InconsistentNaming
        var
            // Vehicle Charge
            vehicleCharge = ko.observable(specifiedVehicleCharge || 0),
            // total Drop Off Charge
            totalDropOffCharge = ko.observable(specifiedTotalDropOffCharge || 0),
            // Standard Discount
            standardDiscount = ko.observable(specifiedSeasonalDiscount || 0),
            // Seasonal Discount
            seasonalDiscount = ko.observable(specifiedSeasonalDiscount || 0),
            // Voucher Discount
            voucherDiscount = ko.observable(specifiedVoucherDiscount || 0),
            // Special Discount
            specialDiscount = ko.observable(specifiedSpecialDiscount || 0),
            // Special Discount Perc
            specialDiscountPerc = ko.observable(specifiedSpecialDiscountPerc || 0),
            // Is Special Discount Perc
            isSpecialDiscountPerc = ko.observable(specifiedIsSpecialDiscountPerc || false),
            // Excess Mileage
            excessMileage = ko.observable(specifiedExcessMileage || 0),
            // Service Charge
            serviceCharge = ko.observable(specifiedServiceCharge || 0),
            // Insurance Charge
            insuranceCharge = ko.observable(specifiedInsuranceCharge || 0),
            // Driver Charge
            driverCharge = ko.observable(specifiedDriverCharge || 0),
            // Additional Charge
            additionalCharge = ko.observable(specifiedAdditionalCharge || 0),
            // Net Billing
            netBilling = ko.observable(specifiedNetBill || 0),
            // Total Charges
            totalCharges = ko.observable(specifiedTotalCharges || 0),
            // Amount Paid
            amountPaid = ko.observable(specifiedAmountPaid || 0),
            // Balance
            balance = ko.observable(specifiedBalance || 0);

        return {
            vehicleCharge: vehicleCharge,
            standardDiscount: standardDiscount,
            seasonalDiscount: seasonalDiscount,
            voucherDiscount: voucherDiscount,
            specialDiscount: specialDiscount,
            excessMileage: excessMileage,
            serviceCharge: serviceCharge,
            insuranceCharge: insuranceCharge,
            driverCharge: driverCharge,
            additionalCharge: additionalCharge,
            netBilling: netBilling,
            totalCharges: totalCharges,
            amountPaid: amountPaid,
            specialDiscountPerc: specialDiscountPerc,
            isSpecialDiscountPerc: isSpecialDiscountPerc,
            totalDropOffCharge: totalDropOffCharge,
            balance: balance
        };
    },

    // Chauffer Entity
    // ReSharper disable InconsistentNaming
    Chauffer = function (specifiedId, specifiedCode, specifiedName, specifiedDesigGradeName, specifiedDesigGradeId, specifiedLicenseNo, specifiedLicenseExpDt) {
        // ReSharper restore InconsistentNaming
        var
            // Is Selected
            isSelected = ko.observable(),
            // Start Date Time
            internalStartDateTime = ko.observable(),
            // End Date Time
            internalEndDateTime = ko.observable(),
            // Start Date
            start = ko.computed({
                read: function () {
                    return internalStartDateTime();
                },
                write: function (value) {
                    if (value === internalStartDateTime()) {
                        return;
                    }
                    if (!value) {
                        internalStartDateTime(undefined);
                    } else {
                        internalStartDateTime(value);
                    }
                }
            }),
            // End Date
            end = ko.computed({
                read: function () {
                    return internalEndDateTime();
                },
                write: function (value) {
                    if (value === internalEndDateTime()) {
                        return;
                    }
                    if (!value) {
                        internalEndDateTime(undefined);
                    } else {
                        internalEndDateTime(value);
                    }
                }
            }),
            // Convert To Server Data
            convertToServerData = function () {
                return {
                    ChaufferId: specifiedId,
                    DriverName: specifiedName,
                    DesigGradeId: specifiedDesigGradeId,
                    LicenseNo: specifiedLicenseNo,
                    LicenseExpDt: moment(specifiedLicenseExpDt).toDate()
                };
            };

        return {
            id: specifiedId,
            code: specifiedCode,
            name: specifiedName,
            codeName: specifiedCode + '-' + specifiedName,
            desigGrade: specifiedDesigGradeName,
            desigGradeId: specifiedDesigGradeId,
            licenseNo: specifiedLicenseNo,
            licenseDt: moment(specifiedLicenseExpDt).toDate(),
            isSelected: isSelected,
            start: start,
            end: end,
            convertToServerData: convertToServerData
        };
    },

    // Service Item Entity
    // ReSharper disable InconsistentNaming
    ServiceItem = function (specifiedId, specifiedCode, specifiedName, specifiedServiceTypeName, specifiedServiceTypeCode) {
        // ReSharper restore InconsistentNaming
        // Is Selected
        var isSelected = ko.observable(false),
            // Convert To Server Data
            convertToServerData = function () {
                return {
                    ServiceItemId: specifiedId,
                    ServiceItemCode: specifiedCode,
                    ServiceItemName: specifiedName,
                    ServiceTypeCode: specifiedServiceTypeCode,
                    ServiceTypeName: specifiedServiceTypeName
                };
            };

        return {
            id: specifiedId,
            code: specifiedCode,
            name: specifiedName,
            serviceTypeName: specifiedServiceTypeName,
            serviceTypeCodeName: specifiedServiceTypeCode + '-' + specifiedServiceTypeName,
            serviceTypeCode: specifiedServiceTypeCode,
            isSelected: isSelected,
            convertToServerData: convertToServerData
        };
    },

    // Rental Agreement Service Item entity
    // ReSharper disable InconsistentNaming
    RentalAgreementServiceItem = function (specifiedId, specifiedServiceItemId, specifiedServiceItemCode, specifiedServiceItemName, specifiedServiceTypeCode,
        specifiedServiceTypeName, specifiedRentalAgreementId, specifiedQuantity, specifiedStartDtTime, specifiedEndDtTime, specifiedServiceRate,
        specifiedServiceCharge, specifiedAgreement) {
        // ReSharper restore InconsistentNaming
        var
            // unique key
            id = ko.observable(specifiedId || 0),
            // Service Item Id
            serviceItemId = ko.observable(specifiedServiceItemId),
            // Service Item Code
            serviceItemCode = ko.observable(specifiedServiceItemCode),
            // Service Item Name
            serviceItemName = ko.observable(specifiedServiceItemName),
            // Service Type Code
            serviceTypeCode = ko.observable(specifiedServiceTypeCode),
            // Service Type Name
            serviceTypeName = ko.observable(specifiedServiceTypeName),
            // Rental Agreement Id
            rentalAgreementId = ko.observable(specifiedRentalAgreementId),
            // Quantity
            quantity = ko.observable(specifiedQuantity || 1).extend({
                required: true
            }),
            // Service Rate
            serviceRate = ko.observable(specifiedServiceRate || 0),
            // Service Charge
            serviceCharge = ko.observable(specifiedServiceCharge || 0),
            // Start Date Time
            internalStartDateTime = ko.observable(specifiedStartDtTime || moment().toDate()).extend({
                required: true
            }),
            // End Date Time
            internalEndDateTime = ko.observable(specifiedEndDtTime || moment().add('days', 1).toDate()).extend({
                required: true
            }),
            // Start Date
            start = ko.computed({
                read: function () {
                    return internalStartDateTime();
                },
                write: function (value) {
                    if (value === internalStartDateTime()) {
                        return;
                    }
                    if (!value) {
                        internalStartDateTime(undefined);
                    } else {
                        internalStartDateTime(value);
                    }
                }
            }),
            // End Date
            end = ko.computed({
                read: function () {
                    return internalEndDateTime();
                },
                write: function (value) {
                    if (value === internalEndDateTime()) {
                        return;
                    }
                    if (!value) {
                        internalEndDateTime(undefined);
                    } else {
                        internalEndDateTime(value);
                    }
                }
            }),
            // Validation Errors
            errors = ko.validation.group({
                quantity: quantity,
                internalStartDateTime: internalStartDateTime,
                internalEndDateTime: internalEndDateTime
            }),
            // Is Invalid period
            isInvalidPeriod = ko.computed(function () {
                return (end() < start()) || (start() < specifiedAgreement.start() || end() > specifiedAgreement.end());
            }),
            isValid = ko.computed(function () {
                return errors().length === 0 && !isInvalidPeriod();
            }),
            // Convert To Server Data
            convertToServerData = function () {
                return {
                    RaServiceItemId: id(),
                    ServiceItemId: serviceItemId(),
                    ServiceItemCode: serviceItemCode(),
                    ServiceItemName: serviceItemName(),
                    ServiceTypeCode: serviceTypeCode(),
                    ServiceTypeName: serviceTypeName(),
                    RaMainId: rentalAgreementId(),
                    StartDtTime: moment(start()).format(ist.utcFormat) + 'Z',
                    EndDtTime: moment(end()).format(ist.utcFormat) + 'Z',
                    Quantity: quantity(),
                    ServiceRate: serviceRate(),
                    ServiceCharge: serviceCharge()
                };
            };

        return {
            id: id,
            serviceItemId: serviceItemId,
            serviceItemName: serviceItemName,
            serviceItemCode: serviceItemCode,
            serviceTypeCode: serviceTypeCode,
            serviceTypeName: serviceTypeName,
            serviceTypeCodeName: specifiedServiceTypeCode + '-' + specifiedServiceTypeName,
            serviceItemCodeName: specifiedServiceItemCode + '-' + specifiedServiceItemName,
            rentalAgreementId: rentalAgreementId,
            quantity: quantity,
            start: start,
            end: end,
            internalStartDateTime: internalStartDateTime,
            internalEndDateTime: internalEndDateTime,
            serviceRate: serviceRate,
            serviceCharge: serviceCharge,
            errors: errors,
            isInvalidPeriod: isInvalidPeriod,
            isValid: isValid,
            convertToServerData: convertToServerData
        };
    },

    // Rental Agreement Driver Item entity
    // ReSharper disable InconsistentNaming
    RentalAgreementDriver = function (specifiedId, specifiedChaufferId, specifiedDesigGradeId, specifiedStartDtTime, specifiedEndDtTime, specifiedLicenseExpDt,
        specifiedLicenseNo, specifiedDriverName, specifiedIsChauffer, specifiedTariffType, specifiedRate, specifiedTotalCharge, specifiedRentalAgreementId,
        specifiedAgreement) {
        // ReSharper restore InconsistentNaming
        var
            // unique key
            id = ko.observable(specifiedId || 0),
            // Chauffer Id
            chaufferId = ko.observable(specifiedChaufferId),
            // Desig Grade
            desigGradeId = ko.observable(specifiedDesigGradeId),
            // Rental Agreement Id
            rentalAgreementId = ko.observable(specifiedRentalAgreementId),
            // Start Date Time
            internalStartDateTime = ko.observable(specifiedStartDtTime || moment().toDate()).extend({
                required: true
            }),
            // End Date Time
            internalEndDateTime = ko.observable(specifiedEndDtTime || moment().add('days', 1).toDate()).extend({
                required: true
            }),
            // Start Date
            start = ko.computed({
                read: function () {
                    return internalStartDateTime();
                },
                write: function (value) {
                    if (value === internalStartDateTime()) {
                        return;
                    }
                    if (!value) {
                        internalStartDateTime(undefined);
                    } else {
                        internalStartDateTime(value);
                    }
                }
            }),
            // End Date
            end = ko.computed({
                read: function () {
                    return internalEndDateTime();
                },
                write: function (value) {
                    if (value === internalEndDateTime()) {
                        return;
                    }
                    if (!value) {
                        internalEndDateTime(undefined);
                    } else {
                        internalEndDateTime(value);
                    }
                }
            }),
            // License Exp Dt
            internalLicenseExpDateTime = ko.observable(specifiedLicenseExpDt || moment().toDate()).extend({
                required: true
            }),
            // License Exp Dt
            licenseExpDt = ko.computed({
                read: function () {
                    return internalLicenseExpDateTime();
                },
                write: function (value) {
                    if (value === internalLicenseExpDateTime()) {
                        return;
                    }
                    if (!value) {
                        internalLicenseExpDateTime(undefined);
                    } else {
                        internalLicenseExpDateTime(value);
                    }
                }
            }),
            // License No
            licenseNo = ko.observable(specifiedLicenseNo).extend({
                required: true
            }),
            // Driver Name
            driverName = ko.observable(specifiedDriverName).extend({
                required: true
            }),
            // Is Chauffer
            isChauffer = ko.observable(specifiedIsChauffer),
            // Tariff Type
            tariffType = ko.observable(specifiedTariffType),
            // Rate
            rate = ko.observable(specifiedRate),
            // Total Charge
            totalCharge = ko.observable(specifiedTotalCharge),
            // Validation Errors
            errors = ko.validation.group({
                internalStartDateTime: internalStartDateTime,
                internalEndDateTime: internalEndDateTime,
                driverName: driverName,
                licenseNo: licenseNo,
                licenseExpDt: licenseExpDt
            }),
            // Is Invalid period
            isInvalidPeriod = ko.computed(function () {
                return (end() < start()) || (start() < specifiedAgreement.start() || end() > specifiedAgreement.end());
            }),
            // Is License Expired
            isLicenseExpired = ko.computed(function () {
                if (!licenseExpDt()) {
                    return false;
                }

                return moment(licenseExpDt()).clone().hours(0).minutes(0).seconds(0).milliseconds(0) < moment().hours(0).minutes(0).seconds(0).milliseconds(0).toDate();
            }),
            isValid = ko.computed(function () {
                return errors().length === 0 && !isInvalidPeriod() && !isLicenseExpired();
            }),
            // Convert To Server Data
            convertToServerData = function () {
                return {
                    RaDriverId: id(),
                    ChaufferId: chaufferId(),
                    DesigGradeId: desigGradeId(),
                    LicenseNo: licenseNo(),
                    LicenseExpDt: moment(licenseExpDt()).format(ist.utcFormat) + 'Z',
                    Rate: rate(),
                    TotalCharge: totalCharge(),
                    DriverName: driverName(),
                    IsChauffer: isChauffer(),
                    TariffType: tariffType(),
                    RaMainId: rentalAgreementId(),
                    StartDtTime: moment(start()).format(ist.utcFormat) + 'Z',
                    EndDtTime: moment(end()).format(ist.utcFormat) + 'Z'
                };
            };

        return {
            id: id,
            chaufferId: chaufferId,
            desigGradeId: desigGradeId,
            rentalAgreementId: rentalAgreementId,
            start: start,
            end: end,
            internalStartDateTime: internalStartDateTime,
            internalEndDateTime: internalEndDateTime,
            licenseNo: licenseNo,
            licenseExpDt: licenseExpDt,
            internalLicenseExpDateTime: internalLicenseExpDateTime,
            rate: rate,
            totalCharge: totalCharge,
            driverName: driverName,
            isChauffer: isChauffer,
            tariffType: tariffType,
            errors: errors,
            isValid: isValid,
            isInvalidPeriod: isInvalidPeriod,
            isLicenseExpired: isLicenseExpired,
            convertToServerData: convertToServerData
        };
    },

    // Insurance Rate Entity
    // ReSharper disable InconsistentNaming
    InsuranceType = function (specifiedId, specifiedTypeCodeName) {
        // ReSharper restore InconsistentNaming
        return {
            id: specifiedId,
            codeName: specifiedTypeCodeName
        };
    },

    // Allocation Status Entity
    // ReSharper disable InconsistentNaming
    AllocationStatus = function (specifiedId, specifiedTypeCodeName, specifiedKey) {
        // ReSharper restore InconsistentNaming

        return {
            id: specifiedId,
            codeName: specifiedTypeCodeName,
            key: specifiedKey
        };
    },

    // Vehicle Status Entity
    // ReSharper disable InconsistentNaming
    VehicleStatus = function (specifiedId, specifiedTypeCodeName, specifiedKey) {
        // ReSharper restore InconsistentNaming

        return {
            id: specifiedId,
            codeName: specifiedTypeCodeName,
            key: specifiedKey
        };
    },

    // Payment Mode Entity
    // ReSharper disable InconsistentNaming
    PaymentMode = function (specifiedId, specifiedCodeName, specifiedKey) {
        // ReSharper restore InconsistentNaming

        return {
            id: specifiedId,
            codeName: specifiedCodeName,
            key: specifiedKey
        };
    },

    // Vehicle CheckList Entity
    // ReSharper disable InconsistentNaming
    VehicleCheckList = function (specifiedId, specifiedCodeName, specifiedKey, specifiedIsInterior, specifiedDescription) {
        // ReSharper restore InconsistentNaming

        return {
            id: specifiedId,
            codeName: specifiedCodeName,
            key: specifiedKey,
            isInterior: specifiedIsInterior,
            description: specifiedDescription
        };
    },

    // Rental Agreement Hire Group Insurance entity
    // ReSharper disable InconsistentNaming
    RentalAgreementHireGroupInsurance = function (specifiedId, specifiedRaHireGroupId, specifiedInsuranceTypeId, specifiedInsuranceTypeCodeName,
        specifiedStartDtTime, specifiedEndDtTime, specifiedInsuranceRate, specifiedInsuranceCharge, specifiedTariffType, specifiedAgreement) {
        // ReSharper restore InconsistentNaming
        var
            // Is Selected
            isSelected = ko.observable(false),
            // unique key
            id = ko.observable(specifiedId || 0),
            // Ra Hire Group Id
            raHireGroupId = ko.observable(specifiedRaHireGroupId),
            // InsuranceType Id
            insuranceTypeId = ko.observable(specifiedInsuranceTypeId),
            // Insurance Type Code Name
            insuranceTypeCodeName = ko.observable(specifiedInsuranceTypeCodeName),
            // insurance Rate
            insuranceRate = ko.observable(specifiedInsuranceRate || 0),
            // Insurance Charge
            insuranceCharge = ko.observable(specifiedInsuranceCharge || 0),
            // Tariff Type
            tariffType = ko.observable(specifiedTariffType),
            // Start Date Time
            internalStartDateTime = ko.observable(specifiedStartDtTime || moment().toDate()).extend({
                required: {
                    onlyIf: function () {
                        return isSelected();
                    }
                }
            }),
            // End Date Time
            internalEndDateTime = ko.observable(specifiedEndDtTime || moment().add('days', 1).toDate()).extend({
                required: {
                    onlyIf: function () {
                        return isSelected();
                    }
                }
            }),
            // Start Date
            start = ko.computed({
                read: function () {
                    return internalStartDateTime();
                },
                write: function (value) {
                    if (value === internalStartDateTime()) {
                        return;
                    }
                    if (!value) {
                        internalStartDateTime(undefined);
                    } else {
                        internalStartDateTime(value);
                    }
                }
            }),
            // End Date
            end = ko.computed({
                read: function () {
                    return internalEndDateTime();
                },
                write: function (value) {
                    if (value === internalEndDateTime()) {
                        return;
                    }
                    if (!value) {
                        internalEndDateTime(undefined);
                    } else {
                        internalEndDateTime(value);
                    }
                }
            }),
            // Validation Errors
            errors = ko.validation.group({
                internalStartDateTime: internalStartDateTime,
                internalEndDateTime: internalEndDateTime
            }),
            // Is Invalid period
            isInvalidPeriod = ko.computed(function () {
                return (end() < start()) || (start() < specifiedAgreement.start() || end() > specifiedAgreement.end());
            }),
            isValid = ko.computed(function () {
                return errors().length === 0 && !isInvalidPeriod();
            }),
            // Convert To Server Data
            convertToServerData = function () {
                return {
                    RaHireGroupInsuranceId: id(),
                    RaHireGroupId: raHireGroupId(),
                    InsuranceTypeId: insuranceTypeId(),
                    StartDtTime: moment(start()).format(ist.utcFormat) + 'Z',
                    EndDtTime: moment(end()).format(ist.utcFormat) + 'Z',
                    TariffType: tariffType(),
                    InsuranceRate: insuranceRate(),
                    InsuranceCharge: insuranceCharge()
                };
            };

        return {
            id: id,
            raHireGroupId: raHireGroupId,
            insuranceTypeId: insuranceTypeId,
            insuranceTypeCodeName: insuranceTypeCodeName,
            tariffType: tariffType,
            start: start,
            end: end,
            internalStartDateTime: internalStartDateTime,
            internalEndDateTime: internalEndDateTime,
            insuranceRate: insuranceRate,
            insuranceCharge: insuranceCharge,
            isSelected: isSelected,
            errors: errors,
            isInvalidPeriod: isInvalidPeriod,
            isValid: isValid,
            convertToServerData: convertToServerData
        };
    },

    // Additional Charge Entity
    // ReSharper disable InconsistentNaming
    AdditionalCharge = function (specifiedId, specifiedAdditionalChargeTypeId, specifiedAdditionalChargeTypeCodeName, specifiedRate,
        specifiedHireGroupDetailCodeName, specifiedHireGroupDetailId) {

        var // Is Selected
            isSelected = ko.observable(false),
            // Convert To Server Data
            convertToServerData = function () {
                return {
                    AdditionalChargeId: specifiedId,
                    AdditionalChargeTypeId: specifiedAdditionalChargeTypeId,
                    AdditionalChargeTypeCodeName: specifiedAdditionalChargeTypeCodeName,
                    AdditionalChargeRate: specifiedRate,
                    HireGroupDetailId: specifiedHireGroupDetailId,
                    HireGroupDetailCodeName: specifiedHireGroupDetailCodeName
                };
            };

        return {
            id: specifiedId,
            additionalChargeTypeId: specifiedAdditionalChargeTypeId,
            additionalChargeTypeCodeName: specifiedAdditionalChargeTypeCodeName,
            rate: specifiedRate,
            hireGroupDetailCodeName: specifiedHireGroupDetailCodeName,
            hireGroupDetailId: specifiedHireGroupDetailId,
            isSelected: isSelected,
            convertToServerData: convertToServerData
        };
    },

    // Rental Agreement Additional Charge entity
    // ReSharper disable InconsistentNaming
    RentalAgreementAdditionalCharge = function (specifiedId, specifiedRaMainId, specifiedAdditionalChargeTypeId, specifiedAdditionalChargeTypeCodeName,
        specifiedAdditionalChargeRate, specifiedPlateNumber, specifiedQuantity, specifiedHireGroupDetailId, specifiedHireGroupDetailCodeName) {
        // ReSharper restore InconsistentNaming
        var
            // unique key
            id = ko.observable(specifiedId || 0),
            // Ra Main Id
            raMainId = ko.observable(specifiedRaMainId),
            // Additional Charge Type Id
            additionalChargeTypeId = ko.observable(specifiedAdditionalChargeTypeId),
            // Additional Charge Rate
            additionalChargeRate = ko.observable(specifiedAdditionalChargeRate || 0).extend({
                required: true
            }),
            // Plate Number
            plateNumber = ko.observable(specifiedPlateNumber).extend({
                required: true
            }),
            // Quantity
            quantity = ko.observable(specifiedQuantity || 1).extend({
                required: true
            }),
            // Hire Group Detail Id
            hireGroupDetailId = ko.observable(specifiedHireGroupDetailId),
            // Validation Errors
            errors = ko.validation.group({
                plateNumber: plateNumber,
                quantity: quantity,
                additionalChargeRate: additionalChargeRate
            }),
            isValid = ko.computed(function () {
                return errors().length === 0;
            }),
            // Convert To Server Data
            convertToServerData = function () {
                return {
                    RaAdditionalChargeId: id(),
                    RaMainId: raMainId(),
                    AdditionalChargeTypeId: additionalChargeTypeId(),
                    AdditionalChargeRate: additionalChargeRate(),
                    Quantity: quantity(),
                    HireGroupDetailId: hireGroupDetailId(),
                    PlateNumber: plateNumber()
                };
            };

        return {
            id: id,
            raMainId: raMainId,
            additionalChargeTypeId: additionalChargeTypeId,
            additionalChargeRate: additionalChargeRate,
            additionalChargeTypeCodeName: specifiedAdditionalChargeTypeCodeName,
            quantity: quantity,
            plateNumber: plateNumber,
            hireGroupDetailId: hireGroupDetailId,
            hireGroupDetail: specifiedHireGroupDetailCodeName,
            errors: errors,
            isValid: isValid,
            convertToServerData: convertToServerData
        };
    },

    // Rental Agreement Payment entity
    // ReSharper disable InconsistentNaming
    RentalAgreementPayment = function (specifiedId, specifiedRaMainId, specifiedPaymentModeId, specifiedRaPaymentDt,
        specifiedPaymentAmount, specifiedCheckNumber, specifiedBank, specifiedPaidBy) {
        // ReSharper restore InconsistentNaming
        var
            // unique key
            id = ko.observable(specifiedId || 0),
            // Ra Main Id
            raMainId = ko.observable(specifiedRaMainId),
            // Payment Mode Id
            paymentModeId = ko.observable(specifiedPaymentModeId || 0),
            // Payment Amount
            paymentAmount = ko.observable(specifiedPaymentAmount || 0),
            // Check Number
            checkNumber = ko.observable(specifiedCheckNumber),
            // Bank
            bank = ko.observable(specifiedBank || undefined),
            // Paid By
            paidBy = ko.observable(specifiedPaidBy || undefined),
            // Payment Dt
            internalPaymentDt = ko.observable(specifiedRaPaymentDt || moment().toDate()),
            // Payment Dt
            paymentDt = ko.computed({
                read: function () {
                    return internalPaymentDt();
                },
                write: function (value) {
                    if (value === internalPaymentDt()) {
                        return;
                    }
                    if (!value) {
                        internalPaymentDt(undefined);
                    } else {
                        internalPaymentDt(value);
                    }
                }
            }),
            // Convert To Server Data
            convertToServerData = function () {
                return {
                    RaPaymentId: id(),
                    RaMainId: raMainId(),
                    PaymentModeId: paymentModeId(),
                    CheckNumber: checkNumber(),
                    Bank: bank(),
                    RaPaymentDt: paymentDt(),
                    RaPaymentAmount: paymentAmount(),
                    PaidBy: paidBy()
                };
            };

        return {
            id: id,
            raMainId: raMainId,
            paymentModeId: paymentModeId,
            checkNumber: checkNumber,
            bank: bank,
            paymentAmount: paymentAmount,
            paidBy: paidBy,
            paymentDt: paymentDt,
            convertToServerData: convertToServerData
        };
    },

    // Rental Agreement Vehicle CheckList entity
    // ReSharper disable InconsistentNaming
    RentalAgreementVehicleCheckList = function (specifiedId, specifiedRaHireGroupId, specifiedVehicleCheckListId, specifiedStatus,
        specifiedVehicleCheckListKey, specifiedVehicleCheckListCodeName, specifiedIsInterior, specifiedComments) {
        // ReSharper restore InconsistentNaming
        var
            // Is Selected
            isSelected = ko.observable(false),
            // unique key
            id = ko.observable(specifiedId || 0),
            // Ra Hire Group Id
            raHireGroupId = ko.observable(specifiedRaHireGroupId),
            // Vehicle CheckList Id
            vehicleCheckListId = ko.observable(specifiedVehicleCheckListId),
            // Vehicle CheckList Code Name
            vehicleCheckListCodeName = ko.observable(specifiedVehicleCheckListCodeName),
            // status
            status = ko.observable(specifiedStatus),
            // Is Interior
            isInterior = ko.observable(specifiedIsInterior),
            // vehicle CheckList Key
            vehicleCheckListKey = ko.observable(specifiedVehicleCheckListKey),
            // Comments
            comments = ko.observable(specifiedComments),
            // Convert To Server Data
            convertToServerData = function () {
                return {
                    RaVehicleCheckListId: id(),
                    RaHireGroupId: raHireGroupId(),
                    VehicleCheckListId: vehicleCheckListId(),
                    Status: status(),
                    IsInterior: isInterior(),
                    RaVehicleCheckListDescription: comments()
                };
            };

        return {
            id: id,
            raHireGroupId: raHireGroupId,
            vehicleCheckListId: vehicleCheckListId,
            vehicleCheckListCodeName: vehicleCheckListCodeName,
            status: status,
            isInterior: isInterior,
            vehicleCheckListKey: vehicleCheckListKey,
            isSelected: isSelected,
            comments: comments,
            convertToServerData: convertToServerData
        };
    };

    // Vehicle Factory
    Vehicle.Create = function (source) {
        return new Vehicle(source.VehicleId, source.VehicleName, source.VehicleCode, source.PlateNumber, source.CurrentOdometer, source.VehicleCategoryId,
        source.VehicleCategory ? source.VehicleCategory.VehicleCategoryCodeName : undefined, source.VehicleMakeId,
        source.VehicleMake ? source.VehicleMake.VehicleMakeCodeName : undefined, source.VehicleModelId,
        source.VehicleModel ? source.VehicleModel.VehicleModelCodeName : undefined, source.VehicleStatusId, source.VehicleStatusCodeName, source.ModelYear,
        source.ImageSource, source.FuelLevel, source.TankSize, source.TransmissionType ? source.TransmissionType.TransmissionTypeName : null, source.FuelType ? source.FuelType.FuelTypeName : null);
    };

    // Payment Term Factory
    PaymentTerm.Create = function (source) {
        return new PaymentTerm(source.PaymentTermId, source.PaymentTermCodeName);
    };

    // Operation Factory
    Operation.Create = function (source) {
        return new Operation(source.OperationId, source.OperationCodeName);
    };

    // Operations WorkPlace Factory
    OperationsWorkPlace.Create = function (source) {
        return new OperationsWorkPlace(source.OperationsWorkPlaceId, source.LocationCode, source.OperationId);
    };

    // HireGroup Detail Factory
    HireGroupDetail.Create = function (source) {
        return new HireGroupDetail(source.HireGroupDetailId, source.HireGroup, source.VehicleCategory, source.VehicleMake, source.VehicleModel, source.ModelYear,
            source.HireGroupId);
    };

    // Rental Agreement Hire Group Factory
    RentalAgreementHireGroup.Create = function (source, isExisting, agreement) {
        return new RentalAgreementHireGroup(source.RaHireGroupId, source.HireGroupDetailId, source.VehicleId,
            source.RaMainId, source.Vehicle && isExisting ? Vehicle.Create(source.Vehicle) : source.Vehicle, source.VehicleMovements, source.RaHireGroupInsurances,
            source.AllocationStatusKey, source.AllocationStatusId, source.RaVehicleCheckLists, source.HireGroupDetail ? source.HireGroupDetail.HireGroup : undefined,
            isExisting, agreement);
    };

    // Phone Type Enums
    var phoneTypes = {
        // ReSharper restore InconsistentNaming
        CellularPone: 1,
        HomePhone: 2,
        BusinessPhone: 3,
        AssistancePhone: 4,
        OtherPhone: 5,
        Fax: 6
    };

    // Phone Type Factory
    PhoneType.Create = function (source) {
        return new PhoneType(source.PhoneTypeId, source.PhoneTypeKey);
    };

    // Phone Factory
    Phone.Create = function (source, callbacks) {
        return new Phone(source.PhoneId, source.IsDefault, source.BusinessPartnerId,
            PhoneType.Create({ PhoneTypeId: source.PhoneTypeId, PhoneTypeKey: source.PhoneTypeKey }), source.PhoneNo,
        callbacks);
    };

    // Business Partner Company Factory
    BusinessPartnerCompany.Create = function (source) {
        return new BusinessPartnerCompany(source.BusinessPartnerId, source.BusinessPartnerCompanyCode, source.BusinessPartnerCompanyName);
    };

    // Business Partner Individual Factory
    BusinessPartnerIndividual.Create = function (source, callbacks, businessPartner) {
        return new BusinessPartnerIndividual(source.BusinessPartnerId, source.FirstName, source.LastName, source.DateOfBirth, source.NicNumber, source.NicExpiryDate,
        source.PassportNumber, source.PassportExpiryDate, source.LiscenseNumber, source.LiscenseExpiryDate, callbacks, businessPartner);
    };

    // Business Partner Factory
    BusinessPartner.Create = function (source, callbacks) {
        var businessPartner = new BusinessPartner(source.BusinessPartnerId, source.IsIndividual, source.PaymentTerm,
            source.BusinessPartnerIndividual, source.BusinessPartnerCompany, source.BusinessPartnerEmailAddress, callbacks);

        // Update Phone Numbers
        _.each(source.BusinessPartnerPhoneNumbers, function (phone) {
            //var phoneItem = businessPartner.phones.find(function (bpPhone) {
            //    return bpPhone.type().key === phone.PhoneTypeKey;
            //});
            //if (phoneItem) {
            //    phoneItem.businessPartnerId(phone.BusinessPartnerId);
            //    phoneItem.id(phone.PhoneId);
            //    phoneItem.isDefault(phone.IsDefault);
            //    if (phone.PhoneTypeKey === phoneTypes.HomePhone) {
            //        businessPartner.internalHomePhone(phone.PhoneNumber);
            //    }
            //    else {
            //        businessPartner.internalMobile(phone.PhoneNumber);
            //    }
            //}
            if (phone.PhoneTypeName === "2 - Mobile") {
                businessPartner.internalHomePhone(phone.PhoneNumber);
            }
            else {
                businessPartner.internalMobile(phone.PhoneNumber);
            }

        });

        return businessPartner;
    };

    // Rental Agreement Factory
    RentalAgreement.Create = function (source, callbacks, isExisting) {
        var rentalAgreement = new RentalAgreement(source.RaMainId, source.StartDtTime ? moment(source.StartDtTime).toDate() : undefined,
            source.EndDtTime ? moment(source.EndDtTime).toDate() : undefined, source.PaymentTermId, source.OperationId, source.OpenLocation, source.CloseLocation,
            source.BusinessPartner || {}, source.RentersName, source.RentersLicenseNumber, source.RentersLicenseExpDt ? moment(source.RentersLicenseExpDt).toDate() : undefined,
            source.RecCreatedDt ? moment(source.RecCreatedDt).toDate() : undefined, source.RaStatusId, source.RaBookingId, callbacks);

        // Add Ra Hire Groups if Any
        if (source.RaHireGroups) {
            var raHireGroups = _.map(source.RaHireGroups, function (raHireGroup) {
                return RentalAgreementHireGroup.Create(raHireGroup, isExisting, rentalAgreement);
            });

            ko.utils.arrayPushAll(rentalAgreement.rentalAgreementHireGroups(), raHireGroups);
            rentalAgreement.rentalAgreementHireGroups.valueHasMutated();
        }

        // Add Ra Service Items if Any
        if (source.RaServiceItems) {
            var raServiceItems = _.map(source.RaServiceItems, function (raServiceItem) {
                return RentalAgreementServiceItem.Create(raServiceItem, rentalAgreement);
            });

            ko.utils.arrayPushAll(rentalAgreement.rentalAgreementServiceItems(), raServiceItems);
            rentalAgreement.rentalAgreementServiceItems.valueHasMutated();
        }

        // Add Ra Drivers if Any
        if (source.RaDrivers) {
            var raDrivers = _.map(source.RaDrivers, function (raDriver) {
                return RentalAgreementDriver.Create(raDriver, rentalAgreement);
            });

            ko.utils.arrayPushAll(rentalAgreement.rentalAgreementDrivers(), raDrivers);
            rentalAgreement.rentalAgreementDrivers.valueHasMutated();
        }

        // Add Ra Additional Charges if Any
        if (source.RaAdditionalCharges) {
            var raAdditionalCharges = _.map(source.RaAdditionalCharges, function (raAddCharge) {
                return RentalAgreementAdditionalCharge.Create(raAddCharge);
            });

            ko.utils.arrayPushAll(rentalAgreement.rentalAgreementAdditionalCharges(), raAdditionalCharges);
            rentalAgreement.rentalAgreementAdditionalCharges.valueHasMutated();
        }

        // Add Ra Payments if Any
        if (source.RaPayments) {
            var raPayments = _.map(source.RaPayments, function (raPayment) {
                return RentalAgreementPayment.Create(raPayment);
            });

            ko.utils.arrayPushAll(rentalAgreement.raPayments(), raPayments);
            rentalAgreement.raPayments.valueHasMutated();
        }

        rentalAgreement.billing(Billing.Create(source));

        return rentalAgreement;
    };

    // Billing Factory
    Billing.Create = function (source) {
        return new Billing(source.TotalVehicleCharge, source.StandardDiscount, source.SeasonalDiscount, source.VoucherDiscount, source.SpecialDiscount,
            source.TotalExcessMileageCharge, source.TotalServiceCharge, source.TotalInsuranceCharge, source.TotalDriverCharge, source.TotalAdditionalCharge,
            source.AmountPaid, source.NetBillAfterDiscount, source.Balance, source.TotalOtherCharge);
    };

    // Service Item Factory
    ServiceItem.Create = function (source) {
        return new ServiceItem(source.ServiceItemId, source.ServiceItemCode, source.ServiceItemName, source.ServiceTypeName, source.ServiceTypeCode,
            source.ServiceTypeCodeName);
    };

    // Chauffer Factory
    Chauffer.Create = function (source) {
        return new Chauffer(source.ChaufferId, source.ChaufferCode, source.ChaufferName, source.DesigGradeCodeName, source.DesigGradeId, source.LicenseNo,
            source.LicenseExpDt);
    };

    // Rental Agreement Service Item Factory
    RentalAgreementServiceItem.Create = function (source, agreement) {
        return new RentalAgreementServiceItem(source.RaServiceItemId, source.ServiceItemId, source.ServiceItemCode, source.ServiceItemName, source.ServiceTypeCode,
            source.ServiceTypeName, source.RaMainId, source.Quantity, source.StartDtTime ? moment(source.StartDtTime).toDate() : undefined,
            source.EndDtTime ? moment(source.EndDtTime).toDate() : undefined, source.ServiceRate, source.ServiceCharge, agreement);
    };

    // Rental Agreement Driver Factory
    RentalAgreementDriver.Create = function (source, agreement) {
        return new RentalAgreementDriver(source.RaDriverId, source.ChaufferId, source.DesigGradeId, source.StartDtTime ? moment(source.StartDtTime).toDate() : undefined,
            source.EndDtTime ? moment(source.EndDtTime).toDate() : undefined, source.LicenseExpDt ? moment(source.LicenseExpDt).toDate() : undefined, source.LicenseNo,
            source.DriverName, source.IsChauffer, source.TariffType, source.Rate, source.TotalCharge, source.RaMainId, agreement);
    };

    // Rental Agreement HireGroup Insurance Factory
    RentalAgreementHireGroupInsurance.Create = function (source, agreement) {
        return new RentalAgreementHireGroupInsurance(source.RaHireGroupInsuranceId, source.RaHireGroupId, source.InsuranceTypeId, source.InsuranceTypeCodeName,
            source.StartDtTime ? moment(source.StartDtTime).toDate() : undefined, source.EndDtTime ? moment(source.EndDtTime).toDate() : undefined, source.InsuranceRate,
            source.InsuranceCharge, source.TariffType, agreement);
    };

    // Insurance Type Factory
    InsuranceType.Create = function (source) {
        return new InsuranceType(source.InsuranceTypeId, source.InsuranceTypeCodeName);
    };

    // Additional Charge Factory
    AdditionalCharge.Create = function (source) {
        return new AdditionalCharge(source.AdditionalChargeId, source.AdditionalChargeTypeId, source.AdditionalChargeTypeCodeName, source.AdditionalChargeRate,
            source.HireGroupDetailCodeName);
    };

    // Ra Additional Charge Factory
    RentalAgreementAdditionalCharge.Create = function (source) {
        return new RentalAgreementAdditionalCharge(source.RaAdditionalChargeId, source.RaMainId, source.AdditionalChargeTypeId, source.AdditionalChargeTypeCodeName,
            source.AdditionalChargeRate, source.PlateNumber, source.Quantity, source.HireGroupDetailId, source.HireGroupDetailCodeName);
    };

    // Vehicle Movement Factory
    VehicleMovement.Create = function (source) {
        return new VehicleMovement(source.VehicleMovementId, source.RaHireGroupId, source.OperationsWorkPlaceId, source.VehicleStatusId,
            source.Status, source.DtTime ? moment(source.DtTime).toDate() : undefined, source.Odometer, source.FuelLevel, source.VehicleCondition,
            source.VehicleConditionDescription);
    };

    // Allocation Status Factory
    AllocationStatus.Create = function (source) {
        return new AllocationStatus(source.AllocationStatusId, source.AllocationStatusCodeName, source.AllocationStatusKey);
    };

    // Vehicle Status Factory
    VehicleStatus.Create = function (source) {
        return new VehicleStatus(source.VehicleStatusId, source.VehicleStatusCodeName, source.VehicleStatusKey);
    };

    // Payment Mode Factory
    PaymentMode.Create = function (source) {
        return new PaymentMode(source.PaymentModeId, source.PaymentModeCodeName, source.PaymentModeKey);
    };

    // Rental Agreement Payment Factory
    RentalAgreementPayment.Create = function (source) {
        return new RentalAgreementPayment(source.RaPaymentId, source.RaMainId, source.PaymentModeId,
            source.RaPaymentDt ? moment(source.RaPaymentDt).toDate() : undefined, source.RaPaymentAmount,
            source.CheckNumber, source.Bank, source.PaidBy);
    };

    // Rental Agreement Vehicle CheckList Factory
    RentalAgreementVehicleCheckList.Create = function (source, isExisting) {
        var raVehicleCheckList = new RentalAgreementVehicleCheckList(source.RaVehicleCheckListId, source.RaHireGroupId, source.VehicleCheckListId,
            source.Status, source.VehicleCheckListKey, source.VehicleCheckListCodeName, source.IsInterior, source.RaVehicleCheckListDescription);

        if (isExisting) {
            raVehicleCheckList.isSelected(true);
        }

        return raVehicleCheckList;
    };

    // Vehicle CheckList Factory
    VehicleCheckList.Create = function (source) {
        return new VehicleCheckList(source.VehicleCheckListId, source.VehicleCheckListCodeName, source.VehicleCheckListKey, source.IsInterior,
            source.VehicleCheckListDescription);
    };

    return {
        // Vehicle Constructor
        Vehicle: Vehicle,
        // Payment term Constructor
        PaymentTerm: PaymentTerm,
        // Operation Constructor
        Operation: Operation,
        // OperationsWorkPlace Constructor
        OperationsWorkPlace: OperationsWorkPlace,
        // HireGroupDetail Constructor
        HireGroupDetail: HireGroupDetail,
        // Rental Agreement Constructor
        RentalAgreement: RentalAgreement,
        // Rental Agreement HireGroup Constructor
        RentalAgreementHireGroup: RentalAgreementHireGroup,
        // Business Partner Constructor
        BusinessPartner: BusinessPartner,
        // Billing Constructor
        Billing: Billing,
        // Service Item Constructor
        ServiceItem: ServiceItem,
        // Chauffer Constructor
        Chauffer: Chauffer,
        // Ra Service Item Constructor
        RentalAgreementServiceItem: RentalAgreementServiceItem,
        // Ra Driver Constructor
        RentalAgreementDriver: RentalAgreementDriver,
        // Ra HireGroup Insurance Constructor
        RentalAgreementHireGroupInsurance: RentalAgreementHireGroupInsurance,
        // Insurance Type Constructor
        InsuranceType: InsuranceType,
        // Additional Charge Constructor
        AdditionalCharge: AdditionalCharge,
        // Ra Additional Charge Constructor
        RentalAgreementAdditionalCharge: RentalAgreementAdditionalCharge,
        // Vehicle Movement Constructor
        VehicleMovement: VehicleMovement,
        // Vehicle Movement Enum
        vehicleMovementEnum: vehicleMovementEnum,
        // Allocation Status Constructor
        AllocationStatus: AllocationStatus,
        // Vehicle Status Constructor
        VehicleStatus: VehicleStatus,
        // Payment Mode Constructor
        PaymentMode: PaymentMode,
        // RaPayment Constructor
        RentalAgreementPayment: RentalAgreementPayment,
        // Ra Vehicle CheckList Constructor
        RentalAgreementVehicleCheckList: RentalAgreementVehicleCheckList,
        // Vehicle CheckList Constructor
        VehicleCheckList: VehicleCheckList
    };
});