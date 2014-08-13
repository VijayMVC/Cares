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
                    // Main RA
                    rentalAgreement = ko.observable(model.RentalAgreement.Create({})),
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
                    // Hire Groups 
                    hireGroups = ko.observableArray([]),
                    // selected Hire Group - // TODO: Need to shift to RA model
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
                        }    
                    },
                    // Vehicle Image
                    vehicleImage = ko.computed(function() {
                        var id = selectedVehicle().id;
                        return id ? "/VehicleImage/Index?id=" + id : "";
                    }),
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
                    // Internal search representation to search for a project
                    internalSearchForHireGroup = ko.observable(""),
                    // Search timer id
                    searchForHireGroupTextTimerId,
                    // Search for project
                    searchForHireGroupText = ko.computed({
                        read: function () { return internalSearchForHireGroup(); },
                        write: function (value) {
                            if (internalSearchForHireGroup() !== value) {
                                internalSearchForHireGroup(value);
                                if (searchForHireGroupTextTimerId) {
                                    clearTimeout(searchForHireGroupTextTimerId);
                                }
                                if (value.length >= 3) {
                                    searchForHireGroupTextTimerId = setTimeout(function () { getHireGroups(); }, 750);
                                }
                            }
                        }
                    }),
                    // Get Hire Groups
                    getHireGroups = function () {
                        dataservice.getHireGroupsByCodeAndVehicleInfo({ SearchText: searchForHireGroupText() }, {
                            success: function (data) {
                                hireGroups.removeAll();
                                var hireGroupList = [];
                                
                                _.each(data, function (hireGroup) {
                                    var hireGroupDetail = model.HireGroupDetail.Create(hireGroup);
                                    hireGroupList.push(hireGroupDetail);
                                });
                                
                                ko.utils.arrayPushAll(hireGroups(), hireGroupList);
                                hireGroups.valueHasMutated();
                            },
                            error: function () {
                                toastr.error("Failed to get Hire groups");
                            }
                        });
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
                    };
                    // #endregion Service Calls

                return {
                    // Observables
                    operations: operations,
                    vehicles: vehicles,
                    paymentTerms: paymentTerms,
                    selectedVehicle: selectedVehicle,
                    selectHireGroup: selectHireGroup,
                    searchForHireGroupText: searchForHireGroupText,
                    hireGroups: hireGroups,
                    vehicleImage: vehicleImage,
                    rentalAgreement: rentalAgreement,
                    // Observables
                    // Utility Methods
                    initialize: initialize,
                    selectVehicle: selectVehicle,
                    getHireGroups: getHireGroups
                    // Utility Methods
                };
            })()
        };
        return ist.rentalAgreement.viewModel;
    });
