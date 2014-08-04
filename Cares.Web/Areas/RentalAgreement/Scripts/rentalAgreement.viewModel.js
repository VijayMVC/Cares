/*
    Module with the view model for the rentalAgreement
*/
define("rentalAgreement/rentalAgreement.viewModel",
    ["jquery", "amplify", "ko", "rentalAgreement/rentalAgreement.dataservice"],
    function ($, amplify, ko, dataservice) {

        var ist = window.ist || {};
        ist.rentalAgreement = {
            viewModel: (function () {
                var// the view 
                    view,
                    // #region Arrays
                    // Operations
                    operations = ko.observableArray([]),
                    // Locations
                    locations = ko.observableArray([]),
                    // payment terms
                    paymentTerms = ko.observableArray([]),
                    // Vehicles
                    vehicles = ko.observableArray([]),
                    // #endregion Arrays
                    // #region Observables
                    // Initialize the view model
                    initialize = function(specifiedView) {
                        view = specifiedView;

                        ko.applyBindings(view.viewModel, view.bindingRoot);

                        getBase();

                        getVehicles();

                    },
                    // Get Base
                    getBase = function() {
                        dataservice.getBase({
                            success: function(data) {
                                ko.utils.arrayPushAll(operations(), data.Operations);
                                operations.valueHasMutated();
                                ko.utils.arrayPushAll(locations(), data.Locations);
                                locations.valueHasMutated();
                                ko.utils.arrayPushAll(paymentTerms(), data.PaymentTerms);
                                paymentTerms.valueHasMutated();
                            },
                            error: function(response) {
                                toastr.error("Failed to load base data. Error: " + response);
                            }
                        });
                    },
                    // Get Vehicles
                    getVehicles = function () {
                        dataservice.getVehicles({
                            success: function (data) {
                                ko.utils.arrayPushAll(vehicles(), data.Vehicles);
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
                    locations: locations,
                    vehicles: vehicles,
                    paymentTerms: paymentTerms,
                    // Observables
                    // Utility Methods
                    initialize: initialize
                    // Utility Methods
                };
            })()
        };
        return ist.rentalAgreement.viewModel;
    });
