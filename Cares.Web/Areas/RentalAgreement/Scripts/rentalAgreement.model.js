define(["ko", "underscore", "underscore-ko"], function (ko) {

    var

    // Vehicle entity
    // ReSharper disable InconsistentNaming
    Vehicle = function (specifiedId, specifiedName, specifiedCode, specifiedPlateNumber, specifiedCurrentOdometer, specifiedVehicleCategoryId,
        specifiedVehicleCategoryCodeName, specifiedVehicleMakeId, specifiedVehicleMakeCodeName, specifiedVehicleModelId, specifiedVehicleModelCodeName,
        specifiedVehicleStatusId, specifiedVehicleStatusCodeName, specifiedModelYear, specifiedImage, specifiedFuelLevel, specifiedTankSize) {
        // ReSharper restore InconsistentNaming
        return {
            id: specifiedId,
            name: specifiedName,
            code: specifiedCode,
            plateNumber: specifiedPlateNumber,
            currentOdometer: specifiedCurrentOdometer,
            vehicleCategoryId: specifiedVehicleCategoryId,
            vehicleCategory: specifiedVehicleCategoryCodeName,
            vehicleMakeId: specifiedVehicleMakeId,
            vehicleMake: specifiedVehicleMakeCodeName,
            vehicleModelId: specifiedVehicleModelId,
            vehicleModel: specifiedVehicleModelCodeName,
            vehicleStatusId: specifiedVehicleStatusId,
            vehicleStatus: specifiedVehicleStatusCodeName,
            modelYear: specifiedModelYear,
            image: specifiedImage,
            fuelLevel: specifiedFuelLevel,
            tankSize: specifiedTankSize
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
    HireGroupDetail = function (specifiedId, specifiedCode, specifiedCategory, specifiedMake, specifiedModel, specifiedModelYear) {
        // ReSharper restore InconsistentNaming
        return {
            id: specifiedId,
            code: specifiedCode,
            vehicleCategory: specifiedCategory,
            vehicleMake: specifiedMake,
            vehicleModel: specifiedModel,
            vehicleModelYear: specifiedModelYear,
            hireGroup: specifiedCode + ' | ' + specifiedCategory + ' | ' + specifiedMake + ' | ' + specifiedModel + ' | ' + specifiedModelYear
        };
    },

    // Rental Agreement entity
    // ReSharper disable InconsistentNaming
    RentalAgreement = function (specifiedId, specifiedStartDate, specifiedEndDate, specifiedPaymentTermId, specifiedOperationId, specifiedOpenLocation,
        specifiedCloseLocation, specifiedBusinessPartner, callbacks) {
        // ReSharper restore InconsistentNaming
        var
            // unique key
            id = ko.observable(specifiedId || 0),
            // RA Hire Groups
            rentalAgreementHireGroups = ko.observableArray([]),
            // Business Partner
            businessPartner = ko.observable(BusinessPartner.Create(specifiedBusinessPartner || {}, callbacks)),
            // Billing
            billing = ko.observable(Billing.Create({})),
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
                        if (callbacks && callbacks.OnRentalDurationChange) {
                            callbacks.OnRentalDurationChange();
                        }
                    }
                }
            }),
            // Time part of From
            startTime = ko.computed({
                read: function () {
                    if (!start()) {
                        return "";
                    }
                    return moment(start()).format(ist.timePattern);
                },
                write: function (value) {
                    if (!value) {
                        return;
                    }
                    var time = moment(value, ist.timePattern);
                    start(new Date(start().getFullYear(), start().getMonth(), start().getDate(), time.hours(), time.minutes()));
                    endDate(new Date(end().getFullYear(), end().getMonth(), end().getDate(), 0, 0));
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
                        if (callbacks && callbacks.OnRentalDurationChange) {
                            callbacks.OnRentalDurationChange();
                        }
                    }
                }
            }),
            // Date part of from
            startDate = ko.computed({
                read: function () {
                    return start();
                },
                write: function (value) {
                    if (!value) {
                        return;
                    }
                    start(new Date(value.getFullYear(), value.getMonth(), value.getDate(), start().getHours(), start().getMinutes()));
                    endDate(new Date(value.getFullYear(), value.getMonth(), value.getDate(), start().getHours(), start().getMinutes()));
                }
            }),
            // Time part of From
            endTime = ko.computed({
                read: function () {
                    if (!end()) {
                        return "";
                    }
                    return moment(end()).format(ist.timePattern);
                },
                write: function (value) {
                    if (!value) {
                        return;
                    }

                    var time = moment(value, ist.timePattern);
                    end(new Date(end().getFullYear(), end().getMonth(), end().getDate(), time.hours(), time.minutes()));
                    endDate(new Date(end().getFullYear(), end().getMonth(), end().getDate(), 0, 0));
                }
            }),
            // Date part of from
            endDate = ko.computed({
                read: function () {
                    return end();
                },
                write: function (value) {
                    if (!value) {
                        return;
                    }

                    end(new Date(value.getFullYear(), value.getMonth(), value.getDate(), end().getHours(), end().getMinutes()));
                    var delta = moment.duration(end() - start());

                    internalDays(!isNaN(delta.asDays()) ? Number(delta.asDays()).toFixed(0) : undefined);
                    internalHours(!isNaN(delta.asHours()) ? Number(delta.hours()).toFixed(0) : undefined);
                    internalMinutes(!isNaN(delta.asMinutes()) ? Number(delta.minutes()).toFixed(0) : undefined);
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
                        end(new Date(start().getFullYear(), start().getMonth(), start().getDate() + parseInt(value), start().getHours(), start().getMinutes()));
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
                        end(new Date(start().getFullYear(), start().getMonth(), start().getDate(), start().getHours() + parseInt(value), start().getMinutes()));
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
                        end(new Date(start().getFullYear(), start().getMonth(), start().getDate(), start().getHours(), start().getMinutes() + parseInt(value)));
                    }
                }
            }),
            // Payment Term
            paymentTermId = ko.observable(specifiedPaymentTermId || undefined),
            // Operation
            operationId = ko.observable(specifiedOperationId || undefined),
            // Open Location
            internalOpenLocation = ko.observable(specifiedOpenLocation || undefined),
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
            // Locations
            locations = ko.observableArray([]),
            // available locations
            availableLocations = ko.computed(function () {
                if (!operationId()) {
                    return [];
                }

                return locations.filter(function (location) {
                    return location.operationId === operationId();
                });
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
                    RecCreatedDt: moment().format(ist.utcFormat) + 'Z',
                    RaHireGroups: rentalAgreementHireGroups.map(function (raHireGroup) {
                        return raHireGroup.convertToServerData();
                    }),
                    BusinessPartner: businessPartner().convertToServerData()
                };
            };

        return {
            id: id,
            paymentTermId: paymentTermId,
            operationId: operationId,
            openLocation: openLocation,
            closeLocation: closeLocation,
            startDate: startDate,
            endDate: endDate,
            startTime: startTime,
            endTime: endTime,
            start: start,
            end: end,
            days: days,
            hours: hours,
            minutes: minutes,
            rentalAgreementHireGroups: rentalAgreementHireGroups,
            locations: locations,
            availableLocations: availableLocations,
            businessPartner: businessPartner,
            billing: billing,
            convertToServerData: convertToServerData
        };
    },

    // Rental Agreement Hire Group entity
    // ReSharper disable InconsistentNaming
    RentalAgreementHireGroup = function (specifiedId, specifiedHireGroupDetailId, specifiedVehicleId, specifiedRentalAgreementId) {
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
            // Convert To Server Data
            convertToServerData = function() {
                return {
                    RaHireGroupId: id(),
                    HireGroupDetailId: hireGroupDetailId(),
                    VehicleId: vehicleId(),
                    RaMainId: rentalAgreementId()
                };
            };

        return {
            id: id,
            hireGroupDetailId: hireGroupDetailId,
            vehicleId: vehicleId,
            rentalAgreementId: rentalAgreementId,
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
            });

        return {
            id: id,
            isDefault: isDefault,
            businessPartnerId: businessPartnerId,
            type: type,
            phoneNo: phoneNo
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
            firstName = ko.observable(specifiedFirstName || undefined),
            // Last Name
            lastName = ko.observable(specifiedLastName || undefined),
            // Date of Birth
            dateOfBirth = ko.observable(specifiedDOB ? moment(specifiedDOB).toDate() : undefined),
            // Nic Expiry
            nicExpiry = ko.observable(specifiedNicExpiry ? moment(specifiedNicExpiry).toDate() : undefined),
            // Passport Expiry
            passportExpiry = ko.observable(specifiedPassportExpiry ? moment(specifiedPassportExpiry).toDate() : undefined),
            // License Expiry
            licenseExpiry = ko.observable(specifiedLicenseExpiry ? moment(specifiedLicenseExpiry).toDate() : undefined),
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
            // Convert To Server Data
            convertToServerData = function() {
                return {
                    BusinessPartnerId: id(),
                    FirstName: firstName(),
                    LastName: lastName(),
                    DateOfBirth: moment(dateOfBirth()).format(ist.utcFormat) + 'Z',
                    NicExpiryDate: moment(nicExpiry()).format(ist.utcFormat) + 'Z',
                    LicenseExpiryDate: moment(licenseExpiry()).format(ist.utcFormat) + 'Z',
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
            passportExpiry: passportExpiry,
            licenseExpiry: licenseExpiry,
            nicNo: nicNo,
            passportNo: passportNo,
            licenseNo: licenseNo,
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
            email = ko.observable(specifiedEmail || undefined),
            // Payment Term
            paymentTermId = ko.observable(specifiedPaymentTerm ? specifiedPaymentTerm.PaymentTermId : undefined),
            // Company
            businessPartnerCompany = ko.observable(BusinessPartnerCompany.Create(specifiedCompany || {})),
            // Reference to this
            self = {
                isIndividual: isIndividual
            },
            // Individual
            businessPartnerIndividual = ko.observable(BusinessPartnerIndividual.Create(specifiedBusinessPartnerIndividual || {}, callbacks, self)),
            // Phones
            phones = ko.observableArray([]),
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
            // Convert To Server Data
            convertToServerData = function () {
                return {
                    BusinessPartnerId: id(),
                    IsIndividual: isIndividual(),
                    PaymentTermId: paymentTermId(),
                    BusinessPartnerEmailAddress: email(),
                    BusinessPartnerIndividual: businessPartnerIndividual().convertToServerData(),
                    BusinessPartnerCompany: businessPartnerCompany().convertToServerData()
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
            convertToServerData: convertToServerData
        };
    },

    // Billing entity
    // ReSharper disable InconsistentNaming
    Billing = function (specifiedVehicleCharge, specifiedStandardDiscount, specifiedSeasonalDiscount, specifiedVoucherDiscount, specifiedSpecialDiscount,
        specifiedExcessMileage, specifiedServiceCharge, specifiedInsuranceCharge, specifiedDriverCharge, specifiedAdditionalCharge, specifiedAmountPaid,
        specifiedNetBill, specifiedBalance, specifiedTotalCharges) {
        // ReSharper restore InconsistentNaming
        var
            // Vehicle Charge
            vehicleCharge = ko.observable(specifiedVehicleCharge || 0),
            // Standard Discount
            standardDiscount = ko.observable(specifiedSeasonalDiscount || 0),
            // Seasonal Discount
            seasonalDiscount = ko.observable(specifiedSeasonalDiscount || 0),
            // Voucher Discount
            voucherDiscount = ko.observable(specifiedVoucherDiscount || 0),
            // Special Discount
            specialDiscount = ko.observable(specifiedSpecialDiscount || 0),
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
            balance: balance
        };
    },
    
    // Chauffer Entity
    // ReSharper disable InconsistentNaming
    Chauffer = function (specifiedId, specifiedCode, specifiedName, specifiedDesigGradeName, specifiedDesigGradeId, specifiedLicenseNo, specifiedLicenseExpDt) {
        // ReSharper restore InconsistentNaming
        
        return {
            id: specifiedId,
            code: specifiedCode,
            name: specifiedName,
            desigGrade: specifiedDesigGradeName,
            desigGradeId: specifiedDesigGradeId,
            licenseNo: specifiedLicenseNo,
            licenseDt: moment(specifiedLicenseExpDt).toDate()
        };
    },

    // Service Item Entity
    // ReSharper disable InconsistentNaming
    ServiceItem = function (specifiedId, specifiedCode, specifiedName, specifiedServiceTypeName, specifiedServiceTypeCode, specifiedServiceTypeCodeName) {
        // ReSharper restore InconsistentNaming

        return {
            id: specifiedId,
            code: specifiedCode,
            name: specifiedName,
            serviceTypeName: specifiedServiceTypeName,
            serviceTypeCodeName: specifiedServiceTypeCodeName,
            serviceTypeCode: specifiedServiceTypeCode
        };
    };

    // Vehicle Factory
    Vehicle.Create = function (source) {
        return new Vehicle(source.VehicleId, source.VehicleName, source.VehicleCode, source.PlateNumber, source.CurrentOdometer, source.VehicleCategoryId,
        source.VehicleCategory ? source.VehicleCategory.VehicleCategoryCodeName : undefined, source.VehicleMakeId, 
        source.VehicleMake ? source.VehicleMake.VehicleMakeCodeName : undefined, source.VehicleModelId,
        source.VehicleModel ? source.VehicleModel.VehicleModelCodeName : undefined, source.VehicleStatusId, source.VehicleStatusCodeName, source.ModelYear,
        source.ImageSource, source.FuelLevel, source.TankSize);
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
        return new HireGroupDetail(source.HireGroupId, source.HireGroup, source.VehicleCategory, source.VehicleMake, source.VehicleModel, source.ModelYear);
    };

    // Rental Agreement Hire Group Factory
    RentalAgreementHireGroup.Create = function (source) {
        return new RentalAgreementHireGroup(source.RentalAgreementHireGroupId, source.HireGroupDetailId, source.VehicleId,
            source.RentalAgreementId);
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
        return new Phone(source.PhoneId, source.IsDefault, source.BusinessPartnerId, source.PhoneTypeId ?
            PhoneType.Create({ PhoneTypeId: source.PhoneTypeId, PhoneTypeKey: source.PhoneTypeKey }) : undefined, source.PhoneNo,
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

        // Add Phones
        if (!source.BusinessPartnerPhoneNumbers) {
            source.BusinessPartnerPhoneNumbers = [
                { IsDefault: true, PhoneTypeKey: phoneTypes.HomePhone },
                { IsDefault: true, PhoneTypeKey: phoneTypes.CellularPone }
            ];
        }

        _.each(source.BusinessPartnerPhoneNumbers, function (phone) {
            businessPartner.phones.push(Phone.Create(phone));
            if (phone.PhoneTypeKey === phoneTypes.HomePhone) {
                businessPartner.internalHomePhone(phone.PhoneNumber);
            }
            else {
                businessPartner.internalMobile(phone.PhoneNumber);
            }
        });

        return businessPartner;
    };

    // Rental Agreement Factory
    RentalAgreement.Create = function (source, callbacks) {
        return new RentalAgreement(source.RentalAgreementId, source.StartDateTime ? moment(source.StartDateTime).toDate() : undefined,
            source.EndDateTime ? moment(source.EndDateTime).toDate() : undefined, source.PaymentTermId, source.OperationId, source.OpenLocation, source.CloseLocation,
        source.BusinessPartner || {}, callbacks);
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
        return new Chauffer(source.ChaufferId, source.ChaufferCode, source.DesigGradeCodeName, source.DesigGradeId, source.LicenseNo,
            source.LicenseExpDt);
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
        Chauffer: Chauffer
    };
});