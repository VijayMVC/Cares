/*
    Module with the view model for the rentalAgreement
*/
define("rentalAgreement/rentalAgreement.viewModel",
    ["jquery", "amplify", "ko", "rentalAgreement/rentalAgreement.dataservice", "rentalAgreement/rentalAgreement.model", "common/pagination"],
    function ($, amplify, ko, dataservice, model, pagination) {

        var ist = window.ist || {};
        ist.rentalAgreement = {
            viewModel: (function () {
                var// the view 
                    view,
                    // Callbacks
                    rentalAgreementModelCallbacks = {
                        OnCustomerNoChanged: function(value) {
                            getCustomerByNo(value);
                        },
                        OnNicChanged: function (value) {
                            getCustomerByNicNo(value);
                        },
                        OnPassportChanged: function (value) {
                            getCustomerByPassportNo(value);
                        },
                        OnLicenseChanged: function (value) {
                            getCustomerByLicenseNo(value);
                        },
                        OnPhoneChanged: function (value, type) {
                            getCustomerByPhoneNo(value, type);
                        },
                        OnRentalDurationChange: function() {
                            resetHireGroups();
                        },
                        OnOutLocationChange: function() {
                            resetHireGroups();
                        }
                    },
                    // Allocation Status Enums
                    allocationStatus = {
                        desired: 1,
                        upgraded: 2,
                        replaced: 3
                    },
                    // Main RA
                    rentalAgreement = ko.observable(model.RentalAgreement.Create({}, rentalAgreementModelCallbacks)),
                    // #region Arrays
                    // Operations
                    operations = ko.observableArray([]),
                    // Locations
                    locations = ko.observableArray([]),
                    // payment terms
                    paymentTerms = ko.observableArray([]),
                    // Vehicles
                    vehicles = ko.observableArray([]),
                    // Pagination
                    vehiclePager = ko.observable(),
                    // Service Items
                    serviceItems = ko.observableArray([]),
                    // Discounts
                    raDiscounts = ko.observableArray([]),
                    // Chauffers
                    chauffers = ko.observableArray([]),
                    // additional Charges
                    additionalCharges = ko.observableArray([]),
                    // Insurance Rates
                    insuranceRates = ko.observableArray([]),
                    // Chauffer Filter
                    chaufferFilter = ko.observable(model.Chauffer.Create({})),
                    // Can search hire group
                    canLookForHireGroups = ko.computed(function() {
                        return rentalAgreement().start() && rentalAgreement().end() && rentalAgreement().openLocation();
                    }),
                    // selected Hire Group 
                    selectedHireGroup = ko.observable(),
                    // hireGroup Text
                    hireGroupText = ko.computed(function() {
                        return selectedHireGroup() ? selectedHireGroup().hireGroup : undefined;
                    }),
                    // select Hire Group
                    selectHireGroup = function (hireGroup) {
                        if (selectedHireGroup() !== hireGroup) {
                            selectedHireGroup(hireGroup);
                            vehiclePager().reset();
                            getVehicles(hireGroup.id);
                        }
                    },
                    // Selected Vehicle
                    selectedVehicle = ko.observable(model.Vehicle.Create({})),
                    // #endregion Arrays
                    // #region Utility Functions
                    selectVehicle = function(vehicle) {
                        if (selectedVehicle() !== vehicle) {
                            rentalAgreement().rentalAgreementHireGroups.push(model.RentalAgreementHireGroup.Create({
                                VehicleId: vehicle.id, HireGroupDetailId: selectedHireGroup().id,
                                AllocationStatusKey: allocationStatus.desired, RaMainId: rentalAgreement().id(),
                                Vehicle: vehicle,
                                VehicleMovements: [
                                    {
                                        OperationsWorkPlaceId: rentalAgreement().openLocation(), Odometer: vehicle.currentOdometer,
                                        VehicleStatusId: vehicle.vehicleStatusId, DtTime: moment(rentalAgreement().start()).toDate(),
                                        FuelLevel: vehicle.fuelLevel, Status: model.vehicleMovementEnum.outMovement
                                    },
                                    {
                                        OperationsWorkPlaceId: rentalAgreement().openLocation(),
                                        DtTime: moment(rentalAgreement().end()).toDate(),
                                        FuelLevel: vehicle.fuelLevel, Status: model.vehicleMovementEnum.inMovement
                                    }
                                ]
                            }));
                            //selectedVehicle(vehicle);
                            calculateBill();
                        }    
                    },
                    // Vehicle Image
                    vehicleImage = ko.computed(function() {
                        var id = selectedVehicle().id;
                        return id ? "/VehicleImage/Index?id=" + id : "";
                    }),
                    // Stop Event Bubbling
                    stopEventBubbling = function(data, e) {
                        e.stopImmediatePropagation();
                    },
                    // Add Selected Extras to Rental Agreement
                    addExtrasToRentalAgreement = function(data, popoverId) {
                        serviceItems.each(function(serviceItem) {
                            if (serviceItem.isSelected()) {
                                rentalAgreement().rentalAgreementServiceItems.push(model.RentalAgreementServiceItem.Create(serviceItem.convertToServerData()));
                            }
                        });
                        // Close Popover
                        view.closePopover(popoverId);
                    },
                    // Reset Service Items Selection
                    resetServiceItemsSelection = function() {
                        serviceItems.each(function(serviceItem) {
                            serviceItem.isSelected(false);
                        });
                    },
                    // Set Chauffer Popover
                    setChaufferPopover = function() {
                        chaufferFilter().start(moment(rentalAgreement().start()).toDate());
                        chaufferFilter().end(moment(rentalAgreement().end()).toDate());
                        // Reset Chauffers Selection
                        resetChauffersSelection();
                    },
                    // Can Search Chauffers
                    canSearchChauffers = ko.computed(function() {
                        return rentalAgreement().openLocation() && chaufferFilter().start() && chaufferFilter().end();
                    }),
                    // Search Chauffers
                    searchChauffers = function() {
                        getChauffers();
                    },
                    // Add Selected Chauffers to Rental Agreement
                    addChauffersToRentalAgreement = function (data, popoverId) {
                        chauffers.each(function (chauffer) {
                            if (chauffer.isSelected()) {
                                var driver = chauffer.convertToServerData();
                                driver.IsChauffer = true;
                                driver.StartDtTime = moment(rentalAgreement().start()).toDate();
                                driver.EndDtTime = moment(rentalAgreement().end()).toDate();
                                rentalAgreement().rentalAgreementDrivers.push(model.RentalAgreementDriver.Create(driver));
                            }
                        });
                        // Close Popover
                        view.closePopover(popoverId);
                    },
                    // Reset Chauffers Selection
                    resetChauffersSelection = function () {
                        chauffers.each(function (chauffer) {
                            chauffer.isSelected(false);
                        });
                    },
                    // Add Driver To Rental Agreement
                    addDriverToRentalAgreement = function () {
                        var driver = model.RentalAgreementDriver.Create({
                            IsChauffer: false, StartDtTime: moment(rentalAgreement().start()).toDate() ,
                            EndDtTime: moment(rentalAgreement().end()).toDate()
                        });
                        rentalAgreement().rentalAgreementDrivers.push(driver);
                    },
                    // Add Additional Charges to Rental Agreement
                    addAdditionalChargesToRentalAgreement = function (data, popoverId) {
                        additionalCharges.each(function (additionalCharge) {
                            if (additionalCharge.isSelected()) {
                                rentalAgreement().raAdditionalCharges.push(model.RentalAgreementAdditionalCharge.Create(additionalCharge.convertToServerData()));
                            }
                        });
                        // Close Popover
                        view.closePopover(popoverId);
                    },
                    // Reset Additional Charges Selection
                    resetAdditionalChargesSelection = function () {
                        additionalCharges.each(function (additionalCharge) {
                            additionalCharge.isSelected(false);
                        });
                    },
                    // #endregion Utility Functions
                    // #region Observables
                    // Initialize the view model
                    initialize = function(specifiedView) {
                        view = specifiedView;

                        ko.applyBindings(view.viewModel, view.bindingRoot);

                        getBase();

                        // Set Pager
                        vehiclePager(pagination.Pagination({}, vehicles, getVehicles));

                        // Get Service Items
                        getServiceItems();

                        // Get Additional Charges
                        getAdditionalCharges();
                    },
                    // Get Base
                    getBase = function() {
                        dataservice.getBase({
                            success: function (data) {
                                var operationItems = [], locationItems = [], paymentTermItems = [];
                                // Operations
                                _.each(data.Operations, function (operation) {
                                    operationItems.push(model.Operation.Create(operation));
                                });
                                ko.utils.arrayPushAll(operations(), operationItems);
                                operations.valueHasMutated();
                                
                                // Locations
                                _.each(data.OperationsWorkPlaces, function (operationWorkPlace) {
                                    locationItems.push(model.OperationsWorkPlace.Create(operationWorkPlace));
                                });
                                ko.utils.arrayPushAll(locations(), locationItems);
                                locations.valueHasMutated();
                                
                                // Payment Terms
                                _.each(data.PaymentTerms, function (paymentTerm) {
                                    paymentTermItems.push(model.PaymentTerm.Create(paymentTerm));
                                });
                                ko.utils.arrayPushAll(paymentTerms(), paymentTermItems);
                                paymentTerms.valueHasMutated();
                                
                                // Assign Locations to Rental Agreement
                                rentalAgreement().locations(locationItems);
                            },
                            error: function(response) {
                                toastr.error("Failed to load base data. Error: " + response);
                            }
                        });
                    },
                    // Reset Hire Groups
                    resetHireGroups = function() {
                        selectedHireGroup(undefined);
                        vehicles.removeAll();
                        if (!rentalAgreement().id()) {
                            selectedVehicle(model.Vehicle.Create({}));
                        }
                    },
                    // Get Chauffers
                    getChauffers = function () {
                        dataservice.getChauffers({
                            OperationsWorkPlaceId: rentalAgreement().openLocation(),
                            StartDtTime: moment(chaufferFilter().start()).format(ist.utcFormat) + 'Z',
                            EndDtTime: moment(chaufferFilter().end()).format(ist.utcFormat) + 'Z',
                        }, {
                            success: function (data) {
                                var chauffersItems = [];

                                _.each(data, function (chauffer) {
                                    chauffersItems.push(model.Chauffer.Create(chauffer));
                                });

                                ko.utils.arrayPushAll(chauffers(), chauffersItems);
                                chauffers.valueHasMutated();
                            },
                            error: function (response) {
                                toastr.error("Failed to load Chauffers. Error: " + response);
                            }
                        });
                    },
                    // Get ServiceItems
                    getServiceItems = function () {
                        dataservice.getServiceItems({
                            success: function (data) {
                                var services = [];

                                _.each(data, function (serviceItem) {
                                    services.push(model.ServiceItem.Create(serviceItem));
                                });

                                ko.utils.arrayPushAll(serviceItems(), services);
                                serviceItems.valueHasMutated();
                            },
                            error: function (response) {
                                toastr.error("Failed to load Service Items. Error: " + response);
                            }
                        });
                    },
                    // Get Additional Charges
                    getAdditionalCharges = function () {
                        dataservice.getAdditionalCharges({
                            success: function (data) {
                                var additionalChargeItems = [];

                                _.each(data, function (additionalCharge) {
                                    additionalChargeItems.push(model.AdditionalCharge.Create(additionalCharge));
                                });

                                ko.utils.arrayPushAll(additionalCharges(), additionalChargeItems);
                                additionalCharges.valueHasMutated();
                            },
                            error: function (response) {
                                toastr.error("Failed to load Additional Charges. Error: " + response);
                            }
                        });
                    },
                    // Get Insurance Rates
                    getInsuranceRates = function () {
                        dataservice.getInsuranceRts({
                            success: function (data) {
                                var services = [];

                                _.each(data, function (serviceItem) {
                                    services.push(model.ServiceItem.Create(serviceItem));
                                });

                                ko.utils.arrayPushAll(serviceItems(), services);
                                serviceItems.valueHasMutated();
                            },
                            error: function (response) {
                                toastr.error("Failed to load Service Items. Error: " + response);
                            }
                        });
                    },
                    // Can Search Vehicles
                    canSearchVehicles = ko.computed(function () {
                        return selectedHireGroup();
                    }),
                    // Search Vehicles
                    searchVehicles = function () {
                        getVehicles();
                    },
                    // Get Vehicles
                    getVehicles = function (hireGroup) {
                        dataservice.getVehiclesByHireGroup({
                            HireGroupId: hireGroup, PageSize: vehiclePager().pageSize(),
                            PageNo: vehiclePager().currentPage()
                        }, {
                            success: function (data) {
                                var vehicleItems = [];

                                _.each(data.Vehicles, function(vehicle) {
                                    vehicleItems.push(model.Vehicle.Create(vehicle));
                                });
                                
                                vehiclePager().totalCount(data.TotalCount);
                                ko.utils.arrayPushAll(vehicles(), vehicleItems);
                                vehicles.valueHasMutated();
                            },
                            error: function (response) {
                                toastr.error("Failed to load vehicles. Error: " + response);
                            }
                        });
                    },
                    // Calculate Bill
                    calculateBill = function () {
                        var rentalBillRequest = rentalAgreement().convertToServerData();
                        dataservice.calculateBill(rentalBillRequest, {
                            success: function (data) {
                                rentalAgreement().billing(model.Billing.Create(data));
                            },
                            error: function (response) {
                                toastr.error("Failed to calculate bill. Error: " + response);
                            }
                        });
                    },
                    // Get Customer Call back Handler
                    getCustomerCallbackHandler = {
                        success: function (data) {
                            if (!data) {
                                return;
                            }
                            rentalAgreement().businessPartner(model.BusinessPartner.Create(data, rentalAgreementModelCallbacks));
                        },
                        error: function (response) {
                            toastr.error("Failed to load customer. Error: " + response);
                        }
                    },
                    // Get Customer By Customer No
                    getCustomerByNo = function (customerNo) {
                        dataservice.getCustomerByNo({
                            BusinessPartnerId: customerNo
                        }, getCustomerCallbackHandler);
                    },
                    // Get Customer By Nic No
                    getCustomerByNicNo = function (nicNo) {
                        dataservice.getCustomerByNicNo({
                            NicNo: nicNo
                        }, getCustomerCallbackHandler);
                    },
                    // Get Customer By Passport No
                    getCustomerByPassportNo = function (passportNo) {
                        dataservice.getCustomerByPassportNo({
                            PassportNo: passportNo
                        }, getCustomerCallbackHandler);
                    },
                    // Get Customer By License No
                    getCustomerByLicenseNo = function (licenseNo) {
                        dataservice.getCustomerByLicenseNo({
                            LicenseNo: licenseNo
                        }, getCustomerCallbackHandler);
                    },
                    // Get Customer By Phone No
                    getCustomerByPhoneNo = function (phoneNo, type) {
                        dataservice.getCustomerByPhoneNo({
                            PhoneNo: phoneNo,
                            PhoneType: type
                        }, getCustomerCallbackHandler);
                    };
                    // #endregion Service Calls

                return {
                    // Observables
                    operations: operations,
                    vehicles: vehicles,
                    paymentTerms: paymentTerms,
                    selectedVehicle: selectedVehicle,
                    selectHireGroup: selectHireGroup,
                    vehicleImage: vehicleImage,
                    rentalAgreement: rentalAgreement,
                    model: model,
                    canLookForHireGroups: canLookForHireGroups,
                    serviceItems: serviceItems,
                    chauffers: chauffers,
                    raDiscounts: raDiscounts,
                    chaufferFilter: chaufferFilter,
                    canSearchChauffers: canSearchChauffers,
                    canSearchVehicles: canSearchVehicles,
                    hireGroupText: hireGroupText,
                    additionalCharges: additionalCharges,
                    insuranceRates: insuranceRates,
                    // Observables
                    // Utility Methods
                    initialize: initialize,
                    selectVehicle: selectVehicle,
                    stopEventBubbling: stopEventBubbling,
                    calculateBill: calculateBill,
                    getChauffers: getChauffers,
                    getServiceItems: getServiceItems,
                    addExtrasToRentalAgreement: addExtrasToRentalAgreement,
                    resetServiceItemsSelection: resetServiceItemsSelection,
                    addChauffersToRentalAgreement: addChauffersToRentalAgreement,
                    resetChauffersSelection: resetChauffersSelection,
                    addDriverToRentalAgreement: addDriverToRentalAgreement,
                    setChaufferPopover: setChaufferPopover,
                    searchChauffers: searchChauffers,
                    searchVehicles: searchVehicles,
                    addAdditionalChargesToRentalAgreement: addAdditionalChargesToRentalAgreement,
                    resetAdditionalChargesSelection: resetAdditionalChargesSelection,
                    getInsuranceRates: getInsuranceRates
                    // Utility Methods
                };
            })()
        };
        return ist.rentalAgreement.viewModel;
    });
