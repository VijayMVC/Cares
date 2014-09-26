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
                    // Can search hire group
                    canLookForHireGroups = ko.computed(function() {
                        return rentalAgreement().start() && rentalAgreement().end() && rentalAgreement().openLocation();
                    }),
                    // selected Hire Group 
                    selectedHireGroup = ko.observable(),
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
                            selectedVehicle(vehicle);
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
                    // #endregion Utility Functions
                    // #region Observables
                    // Initialize the view model
                    initialize = function(specifiedView) {
                        view = specifiedView;

                        ko.applyBindings(view.viewModel, view.bindingRoot);

                        getBase();

                        // Set Pager
                        vehiclePager(pagination.Pagination({}, vehicles, getVehicles));

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
                        if (!rentalAgreement().id()) {
                            rentalBillRequest.RaHireGroups.push({ VehicleId: selectedVehicle().id, HireGroupDetailId: selectedHireGroup().id, 
                                AllocationStatusKey: allocationStatus.desired, RaMainId: rentalAgreement().id(),
                                VehicleMovements: [
                                    {
                                        OperationsWorkPlaceId: rentalAgreement().openLocation(), Odometer: selectedVehicle().currentOdemeter,
                                        VehicleStatusId: selectedVehicle().vehicleStatusId, DtTime: moment(rentalAgreement().start()).format(ist.utcFormat) + 'Z',
                                        FuelLevel: selectedVehicle().fuelLevel, Status: true
                                    },
                                    {
                                        OperationsWorkPlaceId: rentalAgreement().openLocation(),
                                        DtTime: moment(rentalAgreement().start()).format(ist.utcFormat) + 'Z',
                                        FuelLevel: selectedVehicle().fuelLevel
                                    }
                                ]
                            });
                        }
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
                    // Observables
                    // Utility Methods
                    initialize: initialize,
                    selectVehicle: selectVehicle,
                    stopEventBubbling: stopEventBubbling,
                    calculateBill: calculateBill
                    // Utility Methods
                };
            })()
        };
        return ist.rentalAgreement.viewModel;
    });
