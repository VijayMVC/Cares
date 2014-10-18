/*
    Module with the view model for the NRT Queue
*/
define("nRTQueue/nRTQueue.viewModel",
    ["jquery", "amplify", "ko", "nRTQueue/nRTQueue.dataservice", "nRTQueue/nRTQueue.model", "common/confirmation.viewModel", "common/pagination"],
    function ($, amplify, ko, dataservice, model, confirmation, pagination) {
        var ist = window.ist || {};
        ist.nRTQueue = {
            viewModel: (function () {
                var // the view 
                    view,
                    // Show Filter Section
                    filterSectionVisilble = ko.observable(false),
                    // #region Arrays
                    //Operation Work Places
                    operationWorkPlaces = ko.observableArray([]),
                    //Ra Statuses
                    raStatuses = ko.observableArray([]),
                    //NRT Types
                    nrtTypes = ko.observableArray([]),
                    //NRT Main Array
                    nrtMains = ko.observableArray([]),
                     // #endregion Arrays
                    // #region Busy Indicators
                    isLoadingNrtQueues = ko.observable(false),
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
                        // Pagination
                    pager = ko.observable(),
                      //Ra Status Filter
                    raStatusFilter = ko.observable(),
                     //Open Location Filter
                     openLocFilter = ko.observable(),
                     //Close Location Filter
                    closeLocFilter = ko.observable(),
                    //NRT Type Filter
                    nrtTypeFilter = ko.observable(),
                    //Start Date
                    startDt = ko.observable(),
                    //End Date
                    endDt = ko.observable(),
                    //NRT Number
                    nrtNumberFilter = ko.observable(),
                          // #region Utility Functions
                    // Initialize the view model
                    initialize = function (specifiedView) {
                        view = specifiedView;
                        ko.applyBindings(view.viewModel, view.bindingRoot);
                        getBase();
                        // Set Pager
                        pager(new pagination.Pagination({}, nrtMains, getNrtMains));
                        getNrtMains();

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
                        dataservice.getNrtQueueBaseData({
                            success: function (data) {
                                //operation WorkPlaces Array
                                operationWorkPlaces.removeAll();
                                ko.utils.arrayPushAll(operationWorkPlaces(), data.OperationWorkPlaces);
                                operationWorkPlaces.valueHasMutated();
                                //RA Statuses Array
                                raStatuses.removeAll();
                                ko.utils.arrayPushAll(raStatuses(), data.RaStatuses);
                                raStatuses.valueHasMutated();
                                //NRT Type Array
                                nrtTypes.removeAll();
                                ko.utils.arrayPushAll(nrtTypes(), data.NrtTypes);
                                nrtTypes.valueHasMutated();

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
                        getNrtMains();
                    },
                    //Reset
                      reset = function () {
                          nrtNumberFilter(undefined);
                          raStatusFilter(undefined);
                          openLocFilter(undefined);
                          closeLocFilter(undefined);
                          startDt(undefined);
                          endDt(undefined);
                          nrtTypeFilter(undefined);
                          search();
                      },
                    // Map NRT Mains - Server to Client
                    mapNrtMains = function (data) {
                        var nrtMainsList = [];
                        _.each(data.NrtMains, function (item) {
                            var raMain = new model.NrtMainClientMapper(item);
                            nrtMainsList.push(raMain);
                        });
                        ko.utils.arrayPushAll(nrtMains(), nrtMainsList);
                        nrtMains.valueHasMutated();
                    },
                    //Edit NRT Main
                    onEditNrtMain = function (nrtMain) {
                        view.gotoNrt(nrtMain.nRtMainId());
                    },
                    // Get NRT Main
                    getNrtMains = function () {
                        isLoadingNrtQueues(true);
                        dataservice.getNrtMains({
                            NrtNumber: nrtNumberFilter(),
                            NrtStatusId: raStatusFilter(),
                            OpenLocationId: openLocFilter(),
                            CloseLocationId: closeLocFilter(),
                            NrtTypeId: nrtTypeFilter(),
                            StartDate: (startDt() === undefined ? null : moment(startDt()).format(ist.utcFormat)),
                            EndDate: (endDt() === undefined ? null : moment(endDt()).format(ist.utcFormat)),
                            PageSize: pager().pageSize(),
                            PageNo: pager().currentPage(),
                            SortBy: sortOn(),
                            IsAsc: sortIsAsc()
                        }, {
                            success: function (data) {
                                pager().totalCount(data.TotalCount);
                                nrtMains.removeAll();
                                mapNrtMains(data);
                                isLoadingNrtQueues(false);
                            },
                            error: function () {
                                isLoadingNrtQueues(false);
                                toastr.error(ist.resourceText.insuranceRatesLoadFailedMsg);
                            }
                        });
                    };
                // #endregion Service Calls

                return {
                    // Observables
                    isLoadingNrtQueues: isLoadingNrtQueues,
                    sortOn: sortOn,
                    sortIsAsc: sortIsAsc,
                    sortOnHg: sortOnHg,
                    sortIsAscHg: sortIsAscHg,
                    filterSectionVisilble: filterSectionVisilble,
                    //Arrays
                    nrtMains: nrtMains,
                    operationWorkPlaces: operationWorkPlaces,
                    raStatuses: raStatuses,
                    nrtTypes: nrtTypes,
                    //Filters
                    raStatusFilter: raStatusFilter,
                    openLocFilter: openLocFilter,
                    closeLocFilter: closeLocFilter,
                    startDt: startDt,
                    nrtTypeFilter: nrtTypeFilter,
                    endDt: endDt,
                    nrtNumberFilter: nrtNumberFilter,
                    // Utility Methods
                    initialize: initialize,
                    search: search,
                    pager: pager,
                    collapseFilterSection: collapseFilterSection,
                    showFilterSection: showFilterSection,
                    getNrtMains: getNrtMains,
                    reset: reset,
                    onEditNrtMain: onEditNrtMain
                    // Utility Methods

                };
            })()
        };
        return ist.nRTQueue.viewModel;
    });
