/*
    Module with the view model for the Tarrif type
*/
define("tariffRate/tariffRate.viewModel",
    ["jquery", "amplify", "ko", "tariffRate/tariffRate.dataservice", "tariffRate/tariffRate.model", "common/confirmation.viewModel", "common/pagination"],
    function ($, amplify, ko, dataservice, model, confirmation, pagination) {

        var ist = window.ist || {};
        ist.tariffRate = {
            viewModel: (function () {
                var // the view 
                    view,
                // Active Tarrif Rate
                selectedTarrifRate = ko.observable(),
                //For Edit, Tariff Rate Id
                    selectedTariffRateId = ko.observable(),
                // Add Or Edit Tariff Rate
                    addTarrifType = ko.observable(),
                // #region Arrays
                //Tarrif Rates
                    tarrifRates = ko.observableArray([]),
                // Companies
                    companies = ko.observableArray([]),
                // Departments
                    departments = ko.observableArray([]),
                // Operations
                    operations = ko.observableArray([]),
                //Tariff Types
                    tariffTypes = ko.observableArray([]),
                //Hire Groups
                    hireGroups = ko.observableArray([]),
                //Vehicle Make
                    vehicleMakes = ko.observableArray([]),
                //Vehicle Models
                    vehicleModels = ko.observableArray([]),
                //Vehicle Categories
                    vehicleCategories = ko.observableArray([]),
                //Model Years
                    modelYears = ko.observableArray([]),
                // #endregion Arrays
                // #region Busy Indicators
                    isLoadingTariffRates = ko.observable(false),
                // #endregion Busy Indicators
                // #region Observables
                // Sort On
                    sortOn = ko.observable(1),
                // Sort Order -  true means asc, false means desc
                    sortIsAsc = ko.observable(true),
                // Is Tarrif Rate Editor Visible
                    isTarrifRateEditorVisible = ko.observable(false),
                // Is Editable
                    isEditable = ko.observable(false),
                // Pagination
                    pager = ko.observable(),
                // Tarrif Rate Code filter
                    tarrifRateCodeFilter = ko.observable(),
                //Tarrif Rate Name  Filter
                    tarrifRateNameFilter = ko.observable(),
                // Company Filter
                    companyFilter = ko.observable(),
                //Department Filter
                    departmentFilter = ko.observable(),
                //Operation Filter
                    operationFilter = ko.observable(),
                //Tariff Type Filter
                    tariffTypeFilter = ko.observable(),
                // #region Utility Functions
                // Initialize the view model
                    initialize = function (specifiedView) {
                        view = specifiedView;
                        ko.applyBindings(view.viewModel, view.bindingRoot);
                        getBase();
                        // Set Pager
                        //pager(pagination.Pagination({}, tarrifTypes, getTarrifType));
                        //getTarrifType();
                    },
                // Get Base
                    getBase = function () {
                        dataservice.getTariffRateBase({
                            success: function (data) {
                                //Company array
                                companies.removeAll();
                                ko.utils.arrayPushAll(companies(), data.Companies);
                                companies.valueHasMutated();
                                //Departments array
                                departments.removeAll();
                                ko.utils.arrayPushAll(departments(), data.Departments);
                                departments.valueHasMutated();
                                //Operations Array
                                operations.removeAll();
                                ko.utils.arrayPushAll(operations(), data.Operations);
                                operations.valueHasMutated();
                                //Hire Groups
                                hireGroups.removeAll();
                                ko.utils.arrayPushAll(hireGroups(), data.HireGroups);
                                hireGroups.valueHasMutated();
                                //Vehicle Makes
                                vehicleMakes.removeAll();
                                ko.utils.arrayPushAll(vehicleMakes(), data.VehicleMakes);
                                vehicleMakes.valueHasMutated();
                                //Vehicle Categories
                                vehicleCategories.removeAll();
                                ko.utils.arrayPushAll(vehicleCategories(), data.VehicleCategories);
                                vehicleCategories.valueHasMutated();
                                //Vehicle Models
                                vehicleModels.removeAll();
                                ko.utils.arrayPushAll(vehicleModels(), data.VehicleModels);
                                vehicleModels.valueHasMutated();
                                //Tariff Types
                                tariffTypes.removeAll();
                                ko.utils.arrayPushAll(tariffTypes(), data.TariffTypes);
                                tariffTypes.valueHasMutated();

                            },
                            error: function () {
                                toastr.error("Failed to load base data");
                            }
                        });
                    },
                // Search 
                    search = function () {
                        pager().reset();
                        //getTarrifRate();
                    };
                // #endregion Service Calls

                return {
                    // Observables

                    selectedTarrifRate: selectedTarrifRate,
                    selectedTariffRateId: selectedTariffRateId,
                    addTarrifType: addTarrifType,
                    isLoadingTariffRates: isLoadingTariffRates,
                    sortOn: sortOn,
                    sortIsAsc: sortIsAsc,
                    isEditable: isEditable,
                    isTarrifRateEditorVisible: isTarrifRateEditorVisible,
                    //Arrays
                    tariffTypes: tariffTypes,
                    companies: companies,
                    departments: departments,
                    operations: operations,
                    tarrifRates: tarrifRates,
                    hireGroups: hireGroups,
                    vehicleMakes: vehicleMakes,
                    vehicleModels: vehicleModels,
                    vehicleCategories: vehicleCategories,
                    modelYears: modelYears,
                    //Filters
                    tarrifRateCodeFilter: tarrifRateCodeFilter,
                    companyFilter: companyFilter,
                    departmentFilter: departmentFilter,
                    operationFilter: operationFilter,
                    tarrifRateNameFilter: tarrifRateNameFilter,
                    tariffTypeFilter: tariffTypeFilter,
                    // Utility Methods
                    initialize: initialize,
                    search: search,
                    // getTarrifRate: getTarrifRate,
                    getBase: getBase,
                    pager: pager,
                    // Utility Methods

                };
            })()
        };
        return ist.tariffRate.viewModel;
    });
