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
                    view,
                    // Active FleetPool
                    selectedFleetPool = ko.observable(),
                    // #region Arrays
                    // fleetPools
                    fleetPools = ko.observableArray([]),
                    // #endregion Arrays
                    // Regions
                    regionsList = ko.observableArray([]),
                    // Operations
                    operationsList = ko.observableArray([]),
                    // FleetPool Code
                    fleetPoolSeachFilter = ko.observable(),
                    //Operation Filter
                    operationFilter = ko.observable(),
                    // region Filter
                    regionFilter = ko.observable(),
                    // #region Busy Indicators
                    isLoadingFleetPools = ko.observable(false),
                    //Is Edit visible
                    isFleetPoolEditorVisible = ko.observable(false),
                    // Sort On
                    sortOn = ko.observable(1),
                    // Sort Order -  true means asc, false means desc
                    sortIsAsc = ko.observable(true),
                    // Pagination
                    pager = ko.observable(),
                    // Get Fleet Pool Base Data
                    getFleetPoolBaseData = function(callBack) {
                        dataservice.getFleetPoolBasedata(null, {
                            success: function(data) {
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
                    },
                    //search Fleet Pools
                    search = function () {
                        pager().reset();
                        getFleetPools();
                    },
                    reset=function() {
                        fleetPoolSeachFilter(undefined);
                        regionFilter(undefined);
                        operationFilter(undefined);
                        search();   
                    },
                    onDeleteFleetPool = function (item) {
                        if (!item.id()) {
                            fleetPools.remove(item);
                            return;
                        }

                        // Ask for confirmation
                        confirmation.afterProceed(function () {
                            deleteAsset(item.id());
                        });
                        confirmation.show();
                    },
                    deleteAsset = function (asset) {
                        dataservice.deleteFleetPool(asset, {
                            success: function () {
                                toastr.success("Asset removed successfully");
                            },
                            error: function () {
                                toastr.error("Failed to remove asset!");
                            }
                        });
                    },
                    onEditFleetPool = function() {
                    },
                    // Map Tarrif Types - Server to Client
                    mapFleetPools = function (data) {
                        var fleetPoolList = [];
                        _.each(data.FleetPools, function (item) {
                            var fleetPool = model.FleetPool.Create(item);
                            fleetPoolList.push(fleetPool);

                        });

                        ko.utils.arrayPushAll(fleetPools(), fleetPoolList);
                        fleetPools.valueHasMutated();
                    },
                    // Get FleetPools 
                    getFleetPools = function() {
                        isLoadingFleetPools(true);
                        dataservice.getFleetPools({
                            FleetPoolCode: fleetPoolSeachFilter(), RegionId: regionFilter(), OperationId: operationFilter(), PageSize: pager().pageSize(),
                            PageNo: pager().currentPage(), SortBy: sortOn(), IsAsc: sortIsAsc()
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
                    },
                    
                    // Initialize the view model
                    initialize = function(specifiedView) {
                        view = specifiedView;
                        ko.applyBindings(view.viewModel, view.bindingRoot);
                        getFleetPoolBaseData(getFleetPools);
                        // Set Pager
                        pager(pagination.Pagination({}, fleetPools, getFleetPools));
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

                    onDeleteFleetPool: onDeleteFleetPool,
                    onEditFleetPool: onEditFleetPool
                };
            })()
        };
        return ist.fleetPool.viewModel;
    });
