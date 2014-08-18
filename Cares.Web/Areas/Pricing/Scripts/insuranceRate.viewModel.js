/*
    Module with the view model for the Insurance Rate
*/
define("insuranceRate/insuranceRate.viewModel",
    ["jquery", "amplify", "ko", "insuranceRate/insuranceRate.dataservice","insuranceRate/insuranceRate.model", "common/confirmation.viewModel", "common/pagination"],
    function ($, amplify, ko,dataservice, model, confirmation, pagination) {
        var ist = window.ist || {};
        ist.insuranceRate = {
            viewModel: (function () {
                var // the view 
                    view,
                     // Active Insurance Rate Main
                    selectedInsuranceRtMain = ko.observable(),
                    //Active Insurance Rate Main Copy 
                    selectedInsuranceRtCopy = ko.observable(),
                    //For Edit, Insurance Rate Main Id
                    selectedInsuranceRtMainId = ko.observable(),
                     //Selected Insurance Rate 
                    selectedInsuranceRt = ko.observable(),
                    // Show Filter Section
                    filterSectionVisilble = ko.observable(false),
                    // #region Arrays
                    // Operations
                    operations = ko.observableArray([]),
                    //Tariff Types
                    tariffTypes = ko.observableArray([]),
                    //Insurance Rate Main Array
                    insuranceRtMains = ko.observableArray([]),
                     //Insurance Rates
                    insuranceRts = ko.observableArray([]),
                    //Selected Insurance Rate List
                    selectedInsuranceRtList = ko.observableArray(),
                    // #endregion Arrays
                    // #region Busy Indicators
                    isLoadingInsuranceRt = ko.observable(false),
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
                    isInsuranceRtEditorVisible = ko.observable(false),
                    // Is Editable
                    isEditable = ko.observable(false),
                    // Pagination
                    pager = ko.observable(),
                    // Search Filter
                    searchFilter = ko.observable(),
                    //Operation Filter
                    operationFilter = ko.observable(),
                    //Tariff Type Filter
                    tariffTypeFilter = ko.observable(),
                   //Hire Group Detail Is Valid
                   // hireGroupDetailIsValid = ko.observable(true),
                     // #region Utility Functions
                    // Initialize the view model
                    initialize = function (specifiedView) {
                        view = specifiedView;
                        ko.applyBindings(view.viewModel, view.bindingRoot);
                        getBase();
                        // Set Pager
                        pager(new pagination.Pagination({}, insuranceRtMains, getInsuranceRates));
                        getInsuranceRates();

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
                        dataservice.getInsuranceRateBase({
                            success: function (data) {
                                //Operations Array
                                operations.removeAll();
                                ko.utils.arrayPushAll(operations(), data.Operations);
                                operations.valueHasMutated();
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
                        getInsuranceRates();
                    },
                    // Map Insurance Rates - Server to Client
                    mapInsuranceRates = function (data) {
                        var tariffRateList = [];
                        _.each(data.TariffRates, function (item) {
                            var tariffRate = new model.TariffRateClientMapper(item);
                            tariffRateList.push(tariffRate);
                        });
                        ko.utils.arrayPushAll(tariffRates(), tariffRateList);
                        tariffRates.valueHasMutated();
                    },

                    // Get Insurance Rates
                    getInsuranceRates = function () {
                        //isLoadingTariffRates(true);
                        //dataservice.getTariffRate({
                        //    SearchString: searchFilter(),
                        //    TariffTypeId: tariffTypeFilter,
                        //    OperationId: operationFilter(),
                        //    PageSize: pager().pageSize(),
                        //    PageNo: pager().currentPage(),
                        //    SortBy: sortOn(),
                        //    IsAsc: sortIsAsc()
                        //}, {
                        //    success: function (data) {
                        //        pager().totalCount(data.TotalCount);
                        //        insuranceRtMains.removeAll();
                        //        mapInsuranceRates(data);
                        //        isLoadingInsuranceRt(false);
                        //    },
                        //    error: function () {
                        //        isLoadingTariffRates(false);
                        //        toastr.error("Failed to load Tariff rates!");
                        //    }
                        //});
                    };
                // #endregion Service Calls

                return {
                    // Observables
                    selectedInsuranceRtMain: selectedInsuranceRtMain,
                    selectedInsuranceRtCopy: selectedInsuranceRtCopy,
                    selectedInsuranceRtMainId: selectedInsuranceRtMainId,
                    selectedInsuranceRt: selectedInsuranceRt,
                    isLoadingInsuranceRt: isLoadingInsuranceRt,
                    isInsuranceRtEditorVisible: isInsuranceRtEditorVisible,
                    sortOn: sortOn,
                    sortIsAsc: sortIsAsc,
                    sortOnHg: sortOnHg,
                    sortIsAscHg: sortIsAscHg,
                    isEditable: isEditable,
                    filterSectionVisilble: filterSectionVisilble,
                    //Arrays
                    insuranceRtMains: insuranceRtMains,
                    insuranceRts: insuranceRts,
                    selectedInsuranceRtList: selectedInsuranceRtList,
                    operations:operations,
                    tariffTypes: tariffTypes,
                    //Filters
                    operationFilter: operationFilter,
                    tariffTypeFilter: tariffTypeFilter,
                    searchFilter: searchFilter,
                    // Utility Methods
                    initialize: initialize,
                    search: search,
                    pager: pager,
                    collapseFilterSection: collapseFilterSection,
                    showFilterSection: showFilterSection,
                    // Utility Methods

                };
            })()
        };
        return ist.insuranceRate.viewModel;
    });
