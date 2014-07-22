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
                    test = ko.observable("test"),
                    // Active Tarrif Rate
                    selectedTarrifRate = ko.observable(),
                    //For Edit, Tariff Rate Id
                    selectedTariffRateId = ko.observable(),
                    // Add Or Edit Tariff Rate
                    addTariffRate = ko.observable(),
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
                    //Tariff Rates
                    tariffRates = ko.observableArray([]),

                    // #endregion Arrays
                    // #region Busy Indicators
                    isLoadingTariffRates = ko.observable(false),
                    // #endregion Busy Indicators
                    // #region Observables
                    // Sort On
                    sortOn = ko.observable(1),
                    // Sort Order -  true means asc, false means desc
                    sortIsAsc = ko.observable(true),
                    // Is Tariff Rate Editor Visible
                    isTariffRateEditorVisible = ko.observable(false),
                    // Is Editable
                    isEditable = ko.observable(false),
                    // Pagination
                    pager = ko.observable(),
                    // Tariff Rate Code filter
                    tariffRateCodeFilter = ko.observable(),
                    //Tariff Rate Name  Filter
                    tariffRateNameFilter = ko.observable(),
                    // Company Filter
                    companyFilter = ko.observable(),
                    //Department Filter
                    departmentFilter = ko.observable(),
                    //Operation Filter
                    operationFilter = ko.observable(),
                    //Tariff Type Filter
                    tariffTypeFilter = ko.observable(),
                    //Search String
                    searchFilter = ko.observable(),
                    // #region Utility Functions
                    // Initialize the view model
                    initialize = function (specifiedView) {
                        view = specifiedView;
                        ko.applyBindings(view.viewModel, view.bindingRoot);
                        getBase();
                        // Set Pager
                        pager(pagination.Pagination({}, tariffRates, getTariffRates));
                        getTariffRates();
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
                        getTariffRates();
                    },
                     // close Tariff Rate Editor
                    closeTariffRateEditor = function () {
                        isTariffRateEditorVisible(false);
                    },
                    // Show Tariff Type Editor
                    showTariffRateEditor = function () {
                        isTariffRateEditorVisible(true);
                    },
                     //Create Tariff Type Rate
                    createTariffRate = function () {
                        var tariffRate = new model.TariffRateDetail();
                        // Select the newly added Tariff Rate
                        addTariffRate(tariffRate);
                        showTariffRateEditor();
                    },
                     // Save Tariff Rate
                    onSaveTariffRate = function (tariffType) {
                        //if (doBeforeSelect()) {
                        //    if (addTarrifType().tarrifTypeId() > 0) {
                        //        var date = new Date();
                        //        if (addTarrifType().effectiveDate() >= date) {
                        //            // Commits and Selects the Row
                        //            saveTariffType(tariffType);
                        //        } else {
                        //            toastr.error('Effective Date must be a current or future date.');
                        //        }
                        //    } else {
                        //        // Commits and Selects the Row
                        //        saveTariffType(tariffType);
                        //    }

                        //}

                    },
                     // Delete a product
                    onDeleteTariffRate = function (tariffRate) {
                        if (!tariffRate.tariffRateId()) {
                            //products.remove(product);
                            return;
                        }

                        // Ask for confirmation
                        confirmation.afterProceed(function () {
                           // deleteProduct(product);
                        });
                        confirmation.show();
                    },
                    hireGroupRate = function (tariffRate) {
                        //Ask for hire Group Dialog 
                        hireGroupDialogVm.afterProceed(function () {
                            
                         });
                        hireGroupDialogVm.show();
                     },

                    // Map Tariff Rates - Server to Client
                    mapTarrifRates = function (data) {
                    var tariffRateList = [];
                    _.each(data.TariffRates, function (item) {
                        var tariffRate = new model.TariffRateClientMapper(item);
                        tariffRateList.push(tariffRate);
                    });
                    ko.utils.arrayPushAll(tariffRates(), tariffRateList);
                    tariffRates.valueHasMutated();
                },
                    // Get Tariff Rates
                    getTariffRates = function () {
                        isLoadingTariffRates(true);
                        dataservice.getTariffRate({
                            SearchString: searchFilter(),
                            TariffTypeId: tariffTypeFilter,
                            OperationId: operationFilter(),
                            PageSize: pager().pageSize(),
                            PageNo: pager().currentPage(),
                            SortBy: sortOn(),
                            IsAsc: sortIsAsc()
                        }, {
                            success: function (data) {
                                pager().totalCount(data.TotalCount);
                                tariffRates.removeAll();
                                mapTarrifRates(data);
                                isLoadingTariffRates(false);
                            },
                            error: function () {
                                isLoadingTariffRates(false);
                                toastr.error("Failed to load Tariff rates!");
                            }
                        });
                    };
                // #endregion Service Calls

                return {
                    // Observables

                    selectedTarrifRate: selectedTarrifRate,
                    addTariffRate: addTariffRate,
                    selectedTariffRateId: selectedTariffRateId,
                    isLoadingTariffRates: isLoadingTariffRates,
                    sortOn: sortOn,
                    sortIsAsc: sortIsAsc,
                    isEditable: isEditable,
                    isTariffRateEditorVisible: isTariffRateEditorVisible,
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
                    tariffRates: tariffRates,
                    //Filters
                    tariffRateCodeFilter: tariffRateCodeFilter,
                    companyFilter: companyFilter,
                    departmentFilter: departmentFilter,
                    operationFilter: operationFilter,
                    tariffRateNameFilter: tariffRateNameFilter,
                    tariffTypeFilter: tariffTypeFilter,
                    searchFilter: searchFilter,
                    // Utility Methods
                    initialize: initialize,
                    search: search,
                    getTariffRates: getTariffRates,
                    mapTarrifRates: mapTarrifRates,
                    getBase: getBase,
                    pager: pager,
                    closeTariffRateEditor: closeTariffRateEditor,
                    showTariffRateEditor: showTariffRateEditor,
                    createTariffRate: createTariffRate,
                    onSaveTariffRate: onSaveTariffRate,
                    onDeleteTariffRate: onDeleteTariffRate,
                    hireGroupRate: hireGroupRate,
                    test: test
                    // Utility Methods

                };
            })()
        };
        return ist.tariffRate.viewModel;
    });
