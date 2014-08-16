define(["ko", "underscore", "underscore-ko"], function (ko) {

    var

    // Vehicle entity
    // ReSharper disable InconsistentNaming
    Vehicle = function (specifiedId, specifiedName, specifiedCode, specifiedPlateNumber, specifiedCurrentOdometer, specifiedVehicleCategoryId, 
        specifiedVehicleCategoryCodeName, specifiedVehicleMakeId, specifiedVehicleMakeCodeName, specifiedVehicleModelId, specifiedVehicleModelCodeName,
        specifiedVehicleStatusId, specifiedVehicleStatusCodeName, specifiedModelYear, specifiedImage) {
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
                image: specifiedImage
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
        specifiedCloseLocation) {
        // ReSharper restore InconsistentNaming
        var
            // unique key
            id = ko.observable(specifiedId || 0),
            // RA Hire Groups
            rentalAgreementHireGroups = ko.observableArray([]),
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
               read: function() {
                   return internalStartDateTime();
               },
               write: function(value) {
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
                    internalHours(!isNaN(delta.asHours()) ? Number(delta.asHours()).toFixed(0) : undefined);
                    internalMinutes(!isNaN(delta.asMinutes()) ? Number(delta.asMinutes()).toFixed(0) : undefined);
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
            openLocation = ko.observable(specifiedOpenLocation || undefined),
            // Close Location
            closeLocation = ko.observable(specifiedCloseLocation || undefined),
            // Locations
            locations = ko.observableArray([]),
            // available locations
            availableLocations = ko.computed(function() {
                if (!operationId()) {
                    return [];
                }

                return locations.filter(function(location) {
                    return location.operationId === operationId();
                });
            });
        
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
            availableLocations: availableLocations
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
            rentalAgreementId = ko.observable(specifiedRentalAgreementId);

        return {
            id: id,
            hireGroupDetailId: hireGroupDetailId,
            vehicleId: vehicleId,
            rentalAgreementId: rentalAgreementId
        };
    };

    // Vehicle Factory
    Vehicle.Create = function (source) {
        return new Vehicle(source.VehicleId, source.VehicleName, source.VehicleCode, source.PlateNumber, source.CurrentOdometer, source.VehicleCategoryId,
        source.VehicleCategoryCodeName, source.VehicleMakeId, source.VehicleMakeCodeName, source.VehicleModelId, source.VehicleModelCodeName, source.VehicleStatusId,
        source.VehicleStatusCodeName, source.ModelYear, source.ImageSource);
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
    
    // Rental Agreement Factory
    RentalAgreement.Create = function (source) {
        return new RentalAgreement(source.RentalAgreementId, source.StartDateTime ? moment(source.StartDateTime).toDate() : undefined, 
            source.EndDateTime ? moment(source.EndDateTime).toDate() : undefined, source.PaymentTermId, source.OperationId, source.OpenLocation, source.CloseLocation);
    };
    
    // Rental Agreement Hire Group Factory
    RentalAgreementHireGroup.Create = function (source) {
        return new RentalAgreementHireGroup(source.RentalAgreementHireGroupId, source.HireGroupDetailId, source.VehicleId,
            source.RentalAgreementId);
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
        RentalAgreementHireGroup: RentalAgreementHireGroup
    };
});