/*
    Module with the view model for the Insurance Rate
*/
define("insuranceRate/insuranceRate.viewModel",
    ["jquery", "amplify", "ko", "insuranceRate/insuranceRate.dataservice", "insuranceRate/insuranceRate.model", "common/confirmation.viewModel", "common/pagination", "common/clientSidePagination"],
    function ($, amplify, ko, dataservice, model, confirmation, pagination,clientPagination) {
        var ist = window.ist || {};
        ist.insuranceRate = {
            viewModel: (function () {
                var // the view 
                    view,
                     // Active Insurance Rate Main
                    selectedInsuranceRtMain = ko.observable(),
                    //Active Insurance Rate Main Copy 
                    selectedInsuranceRtMainCopy = ko.observable(),
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
                     //Filtered Tariff Types
                    filteredTariffTypes = ko.observableArray([]),
                    //Insurance Rate Main Array
                    insuranceRtMains = ko.observableArray([]),
                     //Insurance Rates
                    insuranceRts = ko.observableArray([]),
                    //Insurance Type Rates
                    insuranceTypeRts = ko.observableArray([]),
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
                    // Is Insurance Rate Editor Visible
                    isInsuranceRtEditorVisible = ko.observable(false),
                    // Is Editable
                    isEditable = ko.observable(false),
                    // Pagination
                    pager = ko.observable(),
                    //Client Side Pagination
                    clientPager = ko.observable(),
                    //List Of Records 
                    clientPagerRecords = ko.computed(function () {
                        if (clientPager() !== undefined) {
                            return clientPager().pagedRecords();
                        }
                        return [];
                    }),
                    // Search Filter
                    searchFilter = ko.observable(),
                    //Operation Filter
                    operationFilter = ko.observable(),
                    //Tariff Type Filter
                    tariffTypeFilter = ko.observable(),
                   //Insurance Rate Detail Is Valid
                   insuranceRtDetailIsValid = ko.observable(true),
                     // #region Utility Functions
                    // Initialize the view model
                    initialize = function (specifiedView) {
                        view = specifiedView;
                        ko.applyBindings(view.viewModel, view.bindingRoot);
                        getBase();
                        // Set Pager
                        pager(new pagination.Pagination({}, insuranceRtMains, getInsuranceRates));
                        //Set Client Side Pager
                        clientPager(new clientPagination.Pagination({}, insuranceTypeRts, null));
                        getInsuranceRates();

                    },
                     //Filtered Tariff Types
                     tariffTypeId = ko.computed(function () {
                         if (selectedInsuranceRtMain() != undefined) {
                             filteredTariffTypes.removeAll();
                             _.each(tariffTypes(), function (item) {
                                 if (item.OperationId === selectedInsuranceRtMain().operationId())
                                     filteredTariffTypes.push(item);
                             });
                             filteredTariffTypes.valueHasMutated();
                         }
                     }, this),
                      // Template Chooser
                    templateToUse = function (hireGroup) {
                        return (hireGroup === selectedInsuranceRt() ? 'editInsuranceTypeRtTemplate' : 'itemInsuranceTypeRtTemplate');
                    },
                      // Select a Insurance Type Rate
                    selectInsuranceRt = function (insuranceRt) {
                        if (selectedInsuranceRt() !== insuranceRt) {
                            selectedInsuranceRt(insuranceRt);
                        }
                        isEditable(true);
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
                                toastr.error(ist.resourceText.loadBaseDataFailedMsg);
                            }
                        });
                    },
                      //Get Insurance Type Rates
                    getInsuranceTypeRate = function (insuranceRt) {
                        isLoadingInsuranceRt(true);
                        dataservice.getInsuranceRateDetail(insuranceRt.convertToServerData(), {
                            success: function (data) {
                                insuranceTypeRts.removeAll();
                                _.each(data.InsuranceRateDetails, function (item) {
                                    var insuranceTypeRt = new model.InsuranceTypeRtClientMapper(item);
                                    insuranceTypeRts.push(insuranceTypeRt);
                                });
                                isLoadingInsuranceRt(false);
                            },
                            error: function () {
                                isLoadingInsuranceRt(false);
                                toastr.error(ist.resourceText.loadInsuranceTypeRatesFailedMsg);
                            }
                        });
                    },
                    // Search 
                    search = function () {
                        pager().reset();
                        getInsuranceRates();
                    },
                    //Reset
                      reset = function () {
                          tariffTypeFilter(undefined);
                          operationFilter(undefined);
                          searchFilter(undefined);
                          search();
                      },
                    // Map Insurance Rates - Server to Client
                    mapInsuranceRates = function (data) {
                        var insuranceRateList = [];
                        _.each(data.InsuranceRtMains, function (item) {
                            var insuranceRtMain = new model.InsuranceRtMainClientMapper(item);
                            insuranceRateList.push(insuranceRtMain);
                        });
                        ko.utils.arrayPushAll(insuranceRtMains(), insuranceRateList);
                        insuranceRtMains.valueHasMutated();
                    },
                      //Create Insurance Rate
                    createInsuranceRate = function () {
                        //hireGroupDetails.removeAll();
                        var insuranceRtMain = new model.InsuranceRtMain();
                        // Select the newly added Insurance Rate
                        selectedInsuranceRtMain(insuranceRtMain);
                        getInsuranceTypeRate(insuranceRtMain);
                        showInsuranceRateEditor();
                    },
                     // Save Insurance Rate
                    onSaveInsuranceRate = function (insuranceRt) {
                        if (doBeforeSave()) {
                            insuranceRt.insuranceRts.removeAll();
                            _.each(insuranceTypeRts(), function (item) {
                                if (item.isChecked() === true && doBeforeSaveForInsuranceRtDetail(item)) {
                                    insuranceRt.insuranceRts.push(item);
                                }
                            });
                            if (insuranceRtDetailIsValid()) {
                                saveTariffRate(insuranceRt);
                            }
                        }
                        insuranceRtDetailIsValid(true);

                    },
                     // Do Before Logic
                    doBeforeSaveForInsuranceRtDetail = function (item) {
                        var flag = true;
                        if (!item.isValid() || !insuranceRtDetailIsValid()) {
                            item.errors.showAllMessages();
                            flag = false;
                            insuranceRtDetailIsValid(false);
                        }
                        return flag;
                    },
                      // Do Before Logic
                    doBeforeSave = function () {
                        var flag = true;
                        if (!selectedInsuranceRtMain().isValid()) {
                            selectedInsuranceRtMain().errors.showAllMessages();
                            flag = false;
                        }
                        return flag;
                    },
                    // Save Insurance Rate Rate
                    saveTariffRate = function (insuranceRt) {
                        dataservice.saveInsuranceRate(model.InsuranceRtServerMapper(insuranceRt), {
                            success: function (data) {
                                var insuranceRtResult = new model.InsuranceRtMainClientMapper(data);
                                if (selectedInsuranceRtMain().insuranceRtMainId() > 0) {
                                    selectedInsuranceRtMainCopy(undefined);
                                    selectedInsuranceRtMain().startDt(insuranceRtResult.startDt()),
                                    closeInsuranceRateEditor();
                                } else {
                                    insuranceRtMains.splice(0, 0, insuranceRtResult);
                                    closeInsuranceRateEditor();
                                }
                                toastr.success(ist.resourceText.insuranceRateAddSuccessMsg);
                            },
                            error: function (exceptionMessage, exceptionType) {

                                if (exceptionType === ist.exceptionType.CaresGeneralException) {

                                    toastr.error(exceptionMessage);

                                } else {

                                    toastr.error(ist.resourceText.insuranceRateAddFailedMsg);

                                }

                            }
                        });
                    },
                      //Edit Insurance Rate
                    onEditInsuranceRate = function (insuranceRt, e) {
                        selectedInsuranceRtMain(insuranceRt);
                        selectedInsuranceRtMainCopy(model.InsuranceRtMainCopier(insuranceRt));
                        getInsuranceTypeRate(insuranceRt);
                        showInsuranceRateEditor();
                        e.stopImmediatePropagation();
                    },
                      // Delete a Insurance Rate
                    onDeleteInsuranceRate = function (insuranceRt) {
                        if (!insuranceRt.insuranceRtMainId()) {
                            insuranceRtMains.remove(insuranceRt);
                            return;
                        }
                        // Ask for confirmation
                        confirmation.afterProceed(function () {
                            deleteInsuranceRate(insuranceRt);
                        });
                        confirmation.show();
                    },
                     // Delete Insurance Rate
                    deleteInsuranceRate = function (insuranceRt) {
                        dataservice.deleteInsuranceRate(insuranceRt.convertToServerData(), {
                            success: function () {
                                insuranceRtMains.remove(insuranceRt);
                                toastr.success(ist.resourceText.insuranceRateDeleteSuccessMsg);
                            },
                            error: function () {
                                toastr.error(ist.resourceText.insuranceRateDeleteFailedMsg);
                            }
                        });
                    },
                     // Show Insurance Rate Editor
                    showInsuranceRateEditor = function () {
                        isInsuranceRtEditorVisible(true);
                    },
                    closeInsuranceRateEditor = function () {
                        if (selectedInsuranceRtMainCopy() !== undefined) {
                            selectedInsuranceRtMain().startDt(selectedInsuranceRtMainCopy().startDt());
                        }
                        isInsuranceRtEditorVisible(false);
                    },
                    // Get Insurance Rates
                    getInsuranceRates = function () {
                        isLoadingInsuranceRt(true);
                        dataservice.getInsuranceRate({
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
                                insuranceRtMains.removeAll();
                                mapInsuranceRates(data);
                                isLoadingInsuranceRt(false);
                            },
                            error: function () {
                                isLoadingInsuranceRt(false);
                                toastr.error(ist.resourceText.insuranceRatesLoadFailedMsg);
                            }
                        });
                    };
                // #endregion Service Calls

                return {
                    // Observables
                    selectedInsuranceRtMain: selectedInsuranceRtMain,
                    selectedInsuranceRtMainCopy: selectedInsuranceRtMainCopy,
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
                    operations: operations,
                    tariffTypes: tariffTypes,
                    insuranceTypeRts: insuranceTypeRts,
                    filteredTariffTypes: filteredTariffTypes,
                    //Filters
                    operationFilter: operationFilter,
                    tariffTypeFilter: tariffTypeFilter,
                    searchFilter: searchFilter,
                    // Utility Methods
                    initialize: initialize,
                    search: search,
                    pager: pager,
                    clientPager:clientPager,
                    collapseFilterSection: collapseFilterSection,
                    showFilterSection: showFilterSection,
                    closeInsuranceRateEditor: closeInsuranceRateEditor,
                    showInsuranceRateEditor: showInsuranceRateEditor,
                    createInsuranceRate: createInsuranceRate,
                    onEditInsuranceRate: onEditInsuranceRate,
                    onDeleteInsuranceRate: onDeleteInsuranceRate,
                    onSaveInsuranceRate: onSaveInsuranceRate,
                    templateToUse: templateToUse,
                    selectInsuranceRt: selectInsuranceRt,
                    getInsuranceRates: getInsuranceRates,
                    clientPagerRecords: clientPagerRecords,
                    reset: reset
                    // Utility Methods

                };
            })()
        };
        return ist.insuranceRate.viewModel;
    });
