/*
    Module with the view model for the Tarrif Rate
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
                    //Active Tarrif Rate Copy 
                    selectedTarrifRateCopy = ko.observable(),
                    //For Edit, Tariff Rate Id
                    selectedTariffRateId = ko.observable(),
                     //Selected Hire Group
                    selectedHireGroup = ko.observable(),
                    // Add Or Edit Tariff Rate
                    addTariffRate = ko.observable(),
                     // Show Filter Section
                    filterSectionVisilble = ko.observable(false),
                    // #region Arrays
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
                     //Hire Group Deatil
                    hireGroupDetails = ko.observableArray([]),
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
                    //Selected Hire Group Array
                    selectedHireGroupList = ko.observableArray(),
                    // #endregion Arrays
                    // #region Busy Indicators
                    isLoadingTariffRates = ko.observable(false),
                    // #endregion Busy Indicators
                    // #region Observables
                    // Sort On
                    sortOn = ko.observable(1),
                    // Sort Order -  true means asc, false means desc
                    sortIsAsc = ko.observable(true),
                    // Sort On Hiregroup
                    sortOnHg = ko.observable(1),
                    // Sort Order -  true means asc, false means desc
                    sortIsAscHg = ko.observable(true),
                    // Is Tariff Rate Editor Visible
                    isTariffRateEditorVisible = ko.observable(false),
                    // Is Editable
                    isEditable = ko.observable(false),
                    // Pagination
                    pager = ko.observable(),
                    // Pagination For Hire Group
                    editorPager = ko.observable(),
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
                    //Hire Group Filter
                    hireGroupFilter = ko.observable(null),
                    //Vehicle Make Filter
                    vehicleMakeFilter = ko.observable(),
                    //Vehicle Model Filter
                    vehicleModelFilter = ko.observable(),
                    //Vehicle Category Filter
                    vehicleCategoryFilter = ko.observable(),
                    //Model Year Filter
                    modelYearFilter = ko.observable(),
                    //Hire Group Detail Is Valid
                    hireGroupDetailIsValid = ko.observable(true),
                     // #region Utility Functions
                    // Initialize the view model
                    initialize = function (specifiedView) {
                        view = specifiedView;
                        ko.applyBindings(view.viewModel, view.bindingRoot);
                        getBase();
                        // Set Pager
                        pager(new pagination.Pagination({}, tariffRates, getTariffRates));

                        // Set Pager
                        editorPager(new pagination.Pagination({}, hireGroupDetails, getHireGroupDetails));

                        getTariffRates();

                    },
                     // Collapase filter section
                    collapseFilterSection = function () {
                        filterSectionVisilble(false);
                    },
                    //Show filter section
                    showFilterSection = function () {
                        filterSectionVisilble(true);
                    },
                    // Get Base
                    getBase = function (callBack) {
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

                                if (callBack && typeof callBack === 'function') {
                                    callBack();
                                }
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
                    //Search Hire Group
                    searchHireGroups = function () {
                        editorPager().reset();
                        //getHireGroupDetails(tariffRate);
                    },
                    //Get Hire Group
                    getHireGroupDetails = function (tariffRate) {
                        isLoadingTariffRates(true);
                        dataservice.getHireGroupDetails(tariffRate.convertToServerData(), {
                            success: function (data) {
                                hireGroupDetails.removeAll();
                                _.each(data.HireGroupDetails, function (item) {
                                    var hireGroupDet = new model.HireGroupClientMapper(item);
                                    hireGroupDetails.push(hireGroupDet);
                                });
                                isLoadingTariffRates(false);
                            },
                            error: function () {
                                isLoadingTariffRates(false);
                                toastr.error("Failed to load Hire Group Rates!");
                            }
                        });
                    },
                    // Template Chooser
                    templateToUse = function (hireGroup) {
                        return (hireGroup === selectedHireGroup() ? 'editHireGroupTemplate' : 'itemHireGroupTemplate');
                    },
                    // Select a Hire Group
                    selectHireGroup = function (hireGroup) {
                        if (selectedHireGroup() !== hireGroup) {
                            selectedHireGroup(hireGroup);
                        }
                        isEditable(true);
                    },
                     // close Tariff Rate Editor
                    closeTariffRateEditor = function () {
                        if (selectedTarrifRateCopy() !== undefined) {
                            selectedTarrifRate().tariffRateCode(selectedTarrifRateCopy().tariffRateCode());
                            selectedTarrifRate().tariffRateName(selectedTarrifRateCopy().tariffRateName());
                            selectedTarrifRate().tariffRateDescription(selectedTarrifRateCopy().tariffRateDescription());
                            selectedTarrifRate().tariffRateCode(selectedTarrifRateCopy().tariffRateCode());
                            selectedTarrifRate().startEffectiveDate(selectedTarrifRateCopy().startEffectiveDate());
                            selectedTarrifRate().endEffectiveDate(selectedTarrifRateCopy().endEffectiveDate());
                            selectedTarrifRate().tariffTypeCodeName(selectedTarrifRateCopy().tariffTypeCodeName());
                            selectedTarrifRate().tariffTypeId(selectedTarrifRateCopy().tariffTypeId());
                            selectedTarrifRate().operationCodeName(selectedTarrifRateCopy().operationCodeName());
                            selectedTarrifRate().operationId(selectedTarrifRateCopy().operationId());
                        }
                        isTariffRateEditorVisible(false);
                    },
                    // Show Tariff Type Editor
                    showTariffRateEditor = function () {
                        isTariffRateEditorVisible(true);
                    },
                     //Create Tariff Type Rate
                    createTariffRate = function () {
                        hireGroupDetails.removeAll();
                        var tariffRate = new model.TariffRate();
                        // Select the newly added Tariff Rate
                        selectedTarrifRate(tariffRate);
                        // addTariffRate(tariffRate);
                        getHireGroupDetails(tariffRate);
                        showTariffRateEditor();
                    },
                     // Save Tariff Rate
                    onSaveTariffRate = function (tariffRate) {
                        if (doBeforeSave()) {
                            tariffRate.hireGroupDetailsInStandardRtMain.removeAll();
                            _.each(hireGroupDetails(), function (item) {
                                if (item.isChecked() === true && doBeforeSaveForHireGroupDetail(item)) {
                                    tariffRate.hireGroupDetailsInStandardRtMain.push(item);
                                }
                            });
                            if (hireGroupDetailIsValid()) {
                                saveTariffRate(tariffRate);
                            }
                        }
                        hireGroupDetailIsValid(true);
                    },
                    // Save Tariff Rate
                    saveTariffRate = function (tariffRate) {
                        var method = "updateTariffRate";
                        if (!tariffRate.tariffRateId()) {
                            method = "createTariffRate";
                        }

                        dataservice[method](model.TariffRateServerMapper(tariffRate), {
                            success: function (data) {
                                var tariffRateData = new model.TariffRateClientMapper(data);
                                if (selectedTarrifRate().tariffRateId() > 0) {
                                    selectedTarrifRateCopy(undefined);
                                    selectedTarrifRate().startEffectiveDate(tariffRateData.startEffectiveDate()),
                                    selectedTarrifRate().endEffectiveDate(tariffRateData.endEffectiveDate()),
                                    //selectedTarrifRate().tariffTypeCodeName(data.TariffTypeCodeName),
                                    //selectedTarrifRate().tariffTypeId(data.TariffTypeId),
                                    //selectedTarrifRate().operationCodeName(data.OperationCodeName),
                                    //selectedTarrifRate().operationId(data.OperationId),
                                    closeTariffRateEditor();
                                } else {
                                    tariffRates.splice(0, 0, tariffRateData);
                                    closeTariffRateEditor();
                                }
                                toastr.success("Tariff Rate saved successfully");
                            },
                            error: function () {
                                toastr.error('Failed to save Tariff Rate!');
                            }
                        });
                    },
                      // Do Before Logic
                    doBeforeSave = function () {
                        var flag = true;
                        if (!selectedTarrifRate().isValid()) {
                            selectedTarrifRate().errors.showAllMessages();
                            flag = false;
                        }
                        return flag;
                    },
                     // Do Before Logic
                    doBeforeSaveForHireGroupDetail = function (item) {
                        var flag = true;
                        if (!item.isValid() || !hireGroupDetailIsValid()) {
                            item.errors.showAllMessages();
                            flag = false;
                            hireGroupDetailIsValid(false);
                        }
                        return flag;
                    },
                     // Delete a Tariff Rate
                    onDeleteTariffRate = function (tariffRate) {
                        if (!tariffRate.tariffRateId()) {
                            tariffRates.remove(tariffRate);
                            return;
                        }
                        // Ask for confirmation
                        confirmation.afterProceed(function () {
                            deleteTariffRate(tariffRate);
                        });
                        confirmation.show();
                    },
                    // Delete Tariff Rate
                    deleteTariffRate = function (tariffRate) {
                        dataservice.deleteTariffRate(tariffRate.convertToServerData(), {
                            success: function () {
                                tariffRates.remove(tariffRate);
                                toastr.success("Tariff Rate removed successfully");
                            },
                            error: function () {
                                toastr.error("Failed to remove Tariff Rate!");
                            }
                        });
                    },
                     //Edit Tariff Rate
                    onEditTariffRate = function (tariffRate, e) {
                        selectedTariffRateId(tariffRate.tariffRateId());
                        selectedTarrifRate(tariffRate);
                        selectedTarrifRateCopy(model.TariffRateCoppier(selectedTarrifRate()));
                        getHireGroupDetails(tariffRate);
                        showTariffRateEditor();
                        e.stopImmediatePropagation();
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
                    selectedTarrifRateCopy: selectedTarrifRateCopy,
                    addTariffRate: addTariffRate,
                    selectedTariffRateId: selectedTariffRateId,
                    isLoadingTariffRates: isLoadingTariffRates,
                    sortOn: sortOn,
                    sortIsAsc: sortIsAsc,
                    sortOnHg: sortOnHg,
                    sortIsAscHg: sortIsAscHg,
                    isEditable: isEditable,
                    isTariffRateEditorVisible: isTariffRateEditorVisible,
                    selectedHireGroup: selectedHireGroup,
                    filterSectionVisilble: filterSectionVisilble,
                    //Arrays
                    tariffTypes: tariffTypes,
                    companies: companies,
                    departments: departments,
                    operations: operations,
                    hireGroups: hireGroups,
                    hireGroupDetails: hireGroupDetails,
                    vehicleMakes: vehicleMakes,
                    vehicleModels: vehicleModels,
                    vehicleCategories: vehicleCategories,
                    modelYears: modelYears,
                    tariffRates: tariffRates,
                    selectedHireGroupList: selectedHireGroupList,
                    //Filters
                    tariffRateCodeFilter: tariffRateCodeFilter,
                    companyFilter: companyFilter,
                    departmentFilter: departmentFilter,
                    operationFilter: operationFilter,
                    tariffRateNameFilter: tariffRateNameFilter,
                    tariffTypeFilter: tariffTypeFilter,
                    searchFilter: searchFilter,
                    hireGroupFilter: hireGroupFilter,
                    vehicleMakeFilter: vehicleMakeFilter,
                    vehicleModelFilter: vehicleModelFilter,
                    vehicleCategoryFilter: vehicleCategoryFilter,
                    modelYearFilter: modelYearFilter,
                    // Utility Methods
                    initialize: initialize,
                    search: search,
                    getTariffRates: getTariffRates,
                    mapTarrifRates: mapTarrifRates,
                    getBase: getBase,
                    pager: pager,
                    editorPager: editorPager,
                    closeTariffRateEditor: closeTariffRateEditor,
                    showTariffRateEditor: showTariffRateEditor,
                    createTariffRate: createTariffRate,
                    onSaveTariffRate: onSaveTariffRate,
                    onDeleteTariffRate: onDeleteTariffRate,
                    onEditTariffRate: onEditTariffRate,
                    templateToUse: templateToUse,
                    selectHireGroup: selectHireGroup,
                    collapseFilterSection: collapseFilterSection,
                    showFilterSection: showFilterSection,
                    saveTariffRate: saveTariffRate,
                    searchHireGroups: searchHireGroups,
                    getHireGroupDetails: getHireGroupDetails
                    // Utility Methods

                };
            })()
        };
        return ist.tariffRate.viewModel;
    });
