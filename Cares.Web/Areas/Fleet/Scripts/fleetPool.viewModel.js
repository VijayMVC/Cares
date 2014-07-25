/*
    Module with the view model for the FleetPool
*/
define("Fleet/fleetPool.viewModel",
    ["jquery", "amplify", "ko", "Fleet/fleetPool.dataservice", "Fleet/fleetPool.model", "common/confirmation.viewModel", "common/pagination"],
    function ($, amplify, ko, dataservice, model, confirmation, pagination) {

        var ist = window.ist || {};
        ist.fleetPool = {
            viewModel: (function () {
                var // the view 
                    view;
                //
              
                //add fleetpool
                var addFleetPoll = ko.observable();
                // Active FleetPool
                var selectedFleetPool = ko.observable();
                // #region Arrays
                // fleetPools
                var fleetPools = ko.observableArray([]);
                // #endregion Arrays
                // Regions
                var regionsList = ko.observableArray([]);
                // Operations
                var operationsList = ko.observableArray([]);
                // FleetPool Code
                var fleetPoolSeachFilter = ko.observable();
                //Operation Filter
                var operationFilter = ko.observable();

                // region Filter
                var regionFilter = ko.observable();
                // #region Busy Indicators
                var isLoadingFleetPools = ko.observable(false);
                //Is Edit visible
                var isFleetPoolEditorVisible = ko.observable(false);
                // Sort On
                var sortOn = ko.observable(1);
                // Sort Order -  true means asc, false means desc
                var sortIsAsc = ko.observable(true);
                // Pagination
                var pager = ko.observable();
                //counytr list
                var CountryList = ko.observableArray([]);
                // Get Fleet Pool Base Data
                var getFleetPoolBaseData = function(callBack) {
                    dataservice.getFleetPoolBasedata(null, {
                        success: function (data) {
                            operationsList.removeAll();
                            ko.utils.arrayPushAll(operationsList(), data.Operations);
                            operationsList.valueHasMutated();

                            regionsList.removeAll();
                            ko.utils.arrayPushAll(regionsList(), data.Regions);
                            regionsList.valueHasMutated();

                            if (callBack && callBack === 'function') {
                                callBack()();
                            };
                        },
                        error: function(data, error) {

                            toastr.error("Failed to load base data.");
                        }
                    });
                };
                //search Fleet Pools
                var search = function() {
                    pager().reset();
                    getFleetPools();
                };
                var reset = function() {
                    fleetPoolSeachFilter(undefined);
                    regionFilter(undefined);
                    operationFilter(undefined);
                    search();
                };
              
                var createFleetForm = function() { //parent
                    createPoolDetail();
                    showFleetPoolEditor();
                };

                //workingon it
                var createPoolDetail = function() {
                    var temp = new model.FleetPoolDetail();
                //    addFleetPoll(temp);

                };
                var showFleetPoolEditor = function () {
                       debugger;
                       isFleetPoolEditorVisible(true);
                  //     document.getElementById('fleetEditor').style.display = 'none';

                };

                var onDeleteFleetPool = function(item) {
                    if (!item.id()) {
                        fleetPools.remove(item);
                        return;
                    }

                    // Ask for confirmation
                    confirmation.afterProceed(function() {
                        deleteAsset(item.id());
                    });
                    confirmation.show();
                };
                var deleteAsset = function(asset) {
                    dataservice.deleteFleetPool(asset, {
                        success: function() {
                            toastr.success("Asset removed successfully");
                        },
                        error: function() {
                            toastr.error("Failed to remove asset!");
                        }
                    });
                };
                var onEditFleetPool = function() {
                };
                // Map Tarrif Types - Server to Client
                var mapFleetPools = function(data) {
                    var fleetPoolList = [];
                    _.each(data.FleetPools, function(item) {
                        var fleetPool = model.FleetPool.Create(item);
                        fleetPoolList.push(fleetPool);

                    });

                    ko.utils.arrayPushAll(fleetPools(), fleetPoolList);
                    fleetPools.valueHasMutated();
                };
                // Get FleetPools 
                var getFleetPools = function() {


                    isLoadingFleetPools(true);
                    dataservice.getFleetPools({
                        FleetPoolCode: fleetPoolSeachFilter(),
                        RegionId: regionFilter(),
                        OperationId: operationFilter(),
                        PageSize: pager().pageSize(),
                        PageNo: pager().currentPage(),
                        SortBy: sortOn(),
                        IsAsc: sortIsAsc()
                    }, {
                        success: function(data) {
                          
                            pager().totalCount(data.TotalCount);
                            fleetPools.removeAll();
                            mapFleetPools(data);
                            isLoadingFleetPools(false);
                        },
                        error: function() {
                            isLoadingFleetPools(false);
                            toastr.error("Failed to load fleetPools!");
                        }
                    });
                };

                // Initialize the view model
                var initialize = function(specifiedView) {
                    view = specifiedView;
                    ko.applyBindings(view.viewModel, view.bindingRoot);
                    getFleetPoolBaseData(getFleetPools);
                    // Set Pager
                    pager(pagination.Pagination({}, fleetPools, getFleetPools));
                    getFleetPools();
                };
                return {
                    isLoadingFleetPools: isLoadingFleetPools,
                    sortOn: sortOn,
                    sortIsAsc: sortIsAsc,
                    pager: pager,
                    initialize: initialize,
                    regionsList: regionsList,
                    operationsList: operationsList,
                    fleetPools: fleetPools,
                    selectedFleetPool: selectedFleetPool,
                    fleetPoolSeachFilter: fleetPoolSeachFilter,
                    operationFilter: operationFilter,
                    regionFilter: regionFilter,
                    search: search,
                    reset:reset,
                    isFleetPoolEditorVisible: isFleetPoolEditorVisible,

                    CountryList:CountryList,
                    onDeleteFleetPool: onDeleteFleetPool,
                    onEditFleetPool: onEditFleetPool,
                    createFleetForm: createFleetForm,
                    ccreatePoolDetail: createPoolDetail,
                    addFleetPoll: addFleetPoll,
                    showFleetPoolEditor: showFleetPoolEditor,
                   
                };
            })()
        };
        return ist.fleetPool.viewModel;
    });
