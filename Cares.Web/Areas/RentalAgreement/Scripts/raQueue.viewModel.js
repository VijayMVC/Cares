/*
    Module with the view model for the RA Queue
*/
define("raQueue/raQueue.viewModel",
    ["jquery", "amplify", "ko", "raQueue/raQueue.dataservice", "raQueue/raQueue.model", "common/confirmation.viewModel", "common/pagination"],
    function ($, amplify, ko, dataservice, model, confirmation, pagination) {
        var ist = window.ist || {};
        ist.raQueue = {
            viewModel: (function () {
                var // the view 
                    view,
                     // Active Insurance Rate Main
                    selectedInsuranceRtMain = ko.observable(),
                      // Show Filter Section
                    filterSectionVisilble = ko.observable(false),
                    // #region Arrays
                    // Operations
                    operations = ko.observableArray([]),
                    //Operation Work Places
                    operationWorkPlaces = ko.observableArray([]),
                    //Ra Statuses
                    raStatuses = ko.observableArray([]),
                    //Payment Terms
                    paymentTerms = ko.observableArray([]),
                    //Rental Agreements
                    raMains = ko.observableArray([]),
                     // #endregion Arrays
                    // #region Busy Indicators
                    isLoadingRaQueues = ko.observable(false),
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
                        // Is Editable
                    isEditable = ko.observable(false),
                    // Pagination
                    pager = ko.observable(),
                      //Ra Status Filter
                    raStatusFilter = ko.observable(),
                    //payement Filter
                    paymentTermFilter = ko.observable(),
                    //Open Location Filter
                     openLocFilter = ko.observable(),
                     //Close Location Filter
                    closeLocFilter = ko.observable(),
                    //Operation Filter
                    operationFilter = ko.observable(),
                    //Start Date
                    startDt = ko.observable(),
                    //End Date
                    endDt = ko.observable(),
                    //RA Number
                    raNumber = ko.observable(),
                          // #region Utility Functions
                    // Initialize the view model
                    initialize = function (specifiedView) {
                        view = specifiedView;
                        ko.applyBindings(view.viewModel, view.bindingRoot);
                        getBase();
                        // Set Pager
                        pager(new pagination.Pagination({}, raMains, getRaMains));
                        getRaMains();

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
                        dataservice.getRaQueueBaseData({
                            success: function (data) {
                                //Operations Array
                                operations.removeAll();
                                ko.utils.arrayPushAll(operations(), data.Operations);
                                operations.valueHasMutated();
                                //operation WorkPlaces Array
                                operationWorkPlaces.removeAll();
                                ko.utils.arrayPushAll(operationWorkPlaces(), data.OperationWorkPlaces);
                                operationWorkPlaces.valueHasMutated();
                                //RA Statuses Array
                                raStatuses.removeAll();
                                ko.utils.arrayPushAll(raStatuses(), data.RaStatuses);
                                raStatuses.valueHasMutated();
                                //Payment Terms Array
                                paymentTerms.removeAll();
                                ko.utils.arrayPushAll(paymentTerms(), data.PaymentTerms);
                                paymentTerms.valueHasMutated();
                                if (callBack && typeof callBack === 'function') {
                                    callBack();
                                }
                            },
                            error: function () {
                                toastr.error(ist.resourceText.loadBaseDataFailedMsg);
                            }
                        });
                    },
                    // Search 
                    search = function () {
                        pager().reset();
                        getRaMains();
                    },
                    //Reset
                      reset = function () {
                          raNumber(undefined);
                          raStatusFilter(undefined);
                          openLocFilter(undefined);
                          closeLocFilter(undefined);
                          paymentTermFilter(undefined);
                          operationFilter(undefined);
                          startDt(undefined);
                          endDt(undefined);
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
                    // Get RA Main
                    getRaMains = function () {
                        isLoadingRaQueues(true);
                        dataservice.getRaMains({
                            RaNumber: raNumber(),
                            RaStatusId: raStatusFilter(),
                            OpenLocationId: openLocFilter(),
                            CloseLocationId: closeLocFilter(),
                            PaymentTermId: paymentTermFilter(),
                            OperationId: operationFilter(),
                            StartDate: (startDt() === undefined  ? null : moment(startDt()).format(ist.utcFormat)),
                            EndDate: (endDt() === undefined ? null : moment(endDt()).format(ist.utcFormat)),
                            PageSize: pager().pageSize(),
                            PageNo: pager().currentPage(),
                            SortBy: sortOn(),
                            IsAsc: sortIsAsc()
                        }, {
                            success: function (data) {
                                pager().totalCount(data.TotalCount);
                                insuranceRtMains.removeAll();
                                mapInsuranceRates(data);
                                isLoadingRaQueues(false);
                            },
                            error: function () {
                                isLoadingRaQueues(false);
                                toastr.error(ist.resourceText.insuranceRatesLoadFailedMsg);
                            }
                        });
                    };
                // #endregion Service Calls

                return {
                    // Observables
                    selectedInsuranceRtMain: selectedInsuranceRtMain,
                    isLoadingRaQueues: isLoadingRaQueues,
                    sortOn: sortOn,
                    sortIsAsc: sortIsAsc,
                    sortOnHg: sortOnHg,
                    sortIsAscHg: sortIsAscHg,
                    isEditable: isEditable,
                    filterSectionVisilble: filterSectionVisilble,
                    //Arrays
                    operations: operations,
                    raMains: raMains,
                    operationWorkPlaces: operationWorkPlaces,
                    raStatuses: raStatuses,
                    paymentTerms: paymentTerms,
                    //Filters
                    operationFilter: operationFilter,
                    raStatusFilter: raStatusFilter,
                    paymentTermFilter: paymentTermFilter,
                    openLocFilter: openLocFilter,
                    closeLocFilter: closeLocFilter,
                    startDt: startDt,
                    endDt: endDt,
                    raNumber: raNumber,
                    // Utility Methods
                    initialize: initialize,
                    search: search,
                    pager: pager,
                    collapseFilterSection: collapseFilterSection,
                    showFilterSection: showFilterSection,
                    getRaMains: getRaMains,
                    reset: reset
                    // Utility Methods

                };
            })()
        };
        return ist.raQueue.viewModel;
    });
