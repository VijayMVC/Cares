/*
    Module with the view model for the Service Rate
*/
define("serviceRate/serviceRate.viewModel",
    ["jquery", "amplify", "ko", "serviceRate/serviceRate.dataservice", "serviceRate/serviceRate.model", "common/confirmation.viewModel", "common/pagination", "common/clientSidePagination"],
    function ($, amplify, ko, dataservice, model, confirmation, pagination, clientPagination) {
        var ist = window.ist || {};
        ist.serviceRate = {
            viewModel: (function () {
                var // the view 
                    view,
                     // Active Service Rate Main
                    selectedServiceRtMain = ko.observable(),
                    //Active Service Rate Main Copy 
                    selectedServiceRtMainCopy = ko.observable(),
                    //Selected Service Rate Item
                    selectedServiceRtItem = ko.observable(),
                    // Show Filter Section
                    filterSectionVisilble = ko.observable(false),
                    // #region Arrays
                    // Operations
                    operations = ko.observableArray([]),
                    //Tariff Types
                    tariffTypes = ko.observableArray([]),
                    //Service Rate Main Array
                    serviceRtMains = ko.observableArray([]),
                     //Service Rates
                    serviceRtItems = ko.observableArray([]),
                    //Selected Service Rate List
                    selectedServiceRtItemList = ko.observableArray(),
                    // #endregion Arrays
                    // #region Busy Indicators
                    isLoadingServiceRt = ko.observable(false),
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
                    // Is Service Rate Editor Visible
                    isServiceRtEditorVisible = ko.observable(false),
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
                   //Service Rate Detail Is Valid
                    serviceRtDetailIsValid = ko.observable(true),
                     // #region Utility Functions
                    // Initialize the view model
                    initialize = function (specifiedView) {
                        view = specifiedView;
                        ko.applyBindings(view.viewModel, view.bindingRoot);
                        getBase();
                        // Set Pager
                       pager(new pagination.Pagination({}, serviceRtMains, getServiceRates));
                        //Set Client Side Pager
                        clientPager(new clientPagination.Pagination({}, serviceRtItems, null));
                        getServiceRates();

                    },
                      // Template Chooser
                    templateToUse = function (hireGroup) {
                        return (hireGroup === selectedServiceRtItem() ? 'editServiceRtItemTemplate' : 'itemServiceRtItemTemplate');
                    },
                      // Select a Service Type Rate
                    selectServiceRtItem = function (serviceRt) {
                        if (selectedServiceRtItem() !== serviceRt) {
                            selectedServiceRtItem(serviceRt);
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
                        dataservice.getServiceRateBase({
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
                      //Get Service Rate Items
                    getServiceRateItems = function (serviceRt) {
                        isLoadingServiceRt(true);
                        dataservice.getServiceRateDetail(serviceRt.convertToServerData(), {
                            success: function (data) {
                                serviceRtItems.removeAll();
                                _.each(data.ServiceRateDetails, function (item) {
                                    var serviceRtItem = new model.ServiceItemRtClientMapper(item);
                                    serviceRtItems.push(serviceRtItem);
                                });
                                isLoadingServiceRt(false);
                            },
                            error: function () {
                                isLoadingServiceRt(false);
                                toastr.error(ist.resourceText.serviceItemRatesFailedMsg);
                            }
                        });
                    },
                    // Search 
                    search = function () {
                        pager().reset();
                        getServiceRates();
                    },
                     //Reset
                    reset = function () {
                        searchFilter(undefined);
                        tariffTypeFilter(undefined);
                        operationFilter(undefined);
                        search();
                    },
                    // Map Service Rates - Server to Client
                    mapServiceRates = function (data) {
                        var serviceRateList = [];
                        _.each(data.ServiceRtMains, function (item) {
                            var serviceRtMain = new model.ServiceRtMainClientMapper(item);
                            serviceRateList.push(serviceRtMain);
                        });
                        ko.utils.arrayPushAll(serviceRtMains(), serviceRateList);
                        serviceRtMains.valueHasMutated();
                    },
                      //Create Service Rate
                    createServiceRate = function () {
                        var serviceRtMain = new model.ServiceRtMain();
                        // Select the newly added Service Rate
                        selectedServiceRtMain(serviceRtMain);
                        getServiceRateItems(serviceRtMain);
                        showServiceRateEditor();
                    },
                     // Save Service Rate
                    onSaveServiceRate = function (serviceRt) {
                        if (doBeforeSave()) {
                            serviceRt.serviceItemRts.removeAll();
                            _.each(serviceRtItems(), function (item) {
                                if (item.isChecked() === true && doBeforeSaveForServiceRtItem(item)) {
                                    serviceRt.serviceItemRts.push(item);
                                }
                            });
                            if (serviceRtDetailIsValid()) {
                                saveServiceRate(serviceRt);
                            }
                        }
                        serviceRtDetailIsValid(true);

                    },
                     // Do Before Logic
                    doBeforeSaveForServiceRtItem = function (item) {
                        var flag = true;
                        if (!item.isValid() || !serviceRtDetailIsValid()) {
                            item.errors.showAllMessages();
                            flag = false;
                            serviceRtDetailIsValid(false);
                        }
                        return flag;
                    },
                      // Do Before Logic
                    doBeforeSave = function () {
                        var flag = true;
                        if (!selectedServiceRtMain().isValid()) {
                            selectedServiceRtMain().errors.showAllMessages();
                            flag = false;
                        }
                        return flag;
                    },
                    // Save Service Rate Main
                    saveServiceRate = function (serviceRtMain) {
                        dataservice.saveServiceRate(model.ServiceRtMainServerMapper(serviceRtMain), {
                            success: function (data) {
                                var serviceRtResult = new model.ServiceRtMainClientMapper(data);
                                if (selectedServiceRtMain().serviceRtMainId() > 0) {
                                    selectedServiceRtMainCopy(undefined);
                                    selectedServiceRtMain().startDt(serviceRtResult.startDt()),
                                    closeServiceRateEditor();
                                } else {
                                    serviceRtMains.splice(0, 0, serviceRtResult);
                                    closeServiceRateEditor();
                                }
                                toastr.success(ist.resourceText.serviceRateAddSuccessMsg);
                            },
                            error: function (exceptionMessage, exceptionType) {

                                if (exceptionType === ist.exceptionType.CaresGeneralException) {

                                    toastr.error(exceptionMessage);

                                } else {

                                    toastr.error(ist.resourceText.serviceRateAddFailedMsg);

                                }

                            }
                        });
                    },
                      //Edit Service Rate
                    onEditServiceRate = function (serviceRt, e) {
                        selectedServiceRtMain(serviceRt);
                        //selectedServiceRtMainCopy(model.InsuranceRtMainCopier(serviceRt));
                        getServiceRateItems(serviceRt);
                        showServiceRateEditor();
                        e.stopImmediatePropagation();
                    },
                      // Delete a Service Rate
                    onDeleteServiceRate = function (serviceRt) {
                        if (!serviceRt.serviceRtMainId()) {
                            serviceRtMains.remove(serviceRt);
                            return;
                        }
                        // Ask for confirmation
                        confirmation.afterProceed(function () {
                            deleteServiceRate(serviceRt);
                        });
                        confirmation.show();
                    },
                     // Delete Service Rate
                    deleteServiceRate = function (serviceRt) {
                        dataservice.deleteServiceRate(serviceRt.convertToServerData(), {
                            success: function () {
                                serviceRtMains.remove(serviceRt);
                                toastr.success(ist.resourceText.serviceRateDeleteSuccessMsg);
                            },
                            error: function () {
                                toastr.error(ist.resourceText.serviceRateDeleteFailedMsg);
                            }
                        });
                    },
                     // Show Service Rate Editor
                    showServiceRateEditor = function () {
                        isServiceRtEditorVisible(true);
                    },
                    closeServiceRateEditor = function () {
                        if (selectedServiceRtMainCopy() !== undefined) {
                            selectedServiceRtMain().startDt(selectedServiceRtMainCopy().startDt());
                        }
                        isServiceRtEditorVisible(false);
                    },
                    // Get Service Rates
                    getServiceRates = function () {
                        isLoadingServiceRt(true);
                        dataservice.getServiceRates({
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
                                serviceRtMains.removeAll();
                                mapServiceRates(data);
                                isLoadingServiceRt(false);
                            },
                            error: function () {
                                isLoadingServiceRt(false);
                                toastr.error(ist.resourceText.serviceRatesLoadFailedMsg);
                            }
                        });
                    };
                // #endregion Service Calls

                return {
                    // Observables
                    selectedServiceRtMain: selectedServiceRtMain,
                    selectedServiceRtMainCopy: selectedServiceRtMainCopy,
                    selectedServiceRtItem: selectedServiceRtItem,
                    isLoadingServiceRt: isLoadingServiceRt,
                    isServiceRtEditorVisible: isServiceRtEditorVisible,
                    sortOn: sortOn,
                    sortIsAsc: sortIsAsc,
                    sortOnHg: sortOnHg,
                    sortIsAscHg: sortIsAscHg,
                    isEditable: isEditable,
                    filterSectionVisilble: filterSectionVisilble,
                    //Arrays
                    serviceRtMains: serviceRtMains,
                    serviceRtItems: serviceRtItems,
                    operations: operations,
                    tariffTypes: tariffTypes,
                    //Filters
                    operationFilter: operationFilter,
                    tariffTypeFilter: tariffTypeFilter,
                    searchFilter: searchFilter,
                    // Utility Methods
                    initialize: initialize,
                    search: search,
                    pager: pager,
                    clientPager: clientPager,
                    collapseFilterSection: collapseFilterSection,
                    showFilterSection: showFilterSection,
                    closeServiceRateEditor: closeServiceRateEditor,
                    showServiceRateEditor: showServiceRateEditor,
                    createServiceRate: createServiceRate,
                    onEditServiceRate: onEditServiceRate,
                    onDeleteServiceRate: onDeleteServiceRate,
                    onSaveServiceRate: onSaveServiceRate,
                    templateToUse: templateToUse,
                    selectServiceRtItem: selectServiceRtItem,
                    getServiceRates: getServiceRates,
                    clientPagerRecords: clientPagerRecords,
                    reset: reset
                    // Utility Methods

                };
            })()
        };
        return ist.serviceRate.viewModel;
    });
