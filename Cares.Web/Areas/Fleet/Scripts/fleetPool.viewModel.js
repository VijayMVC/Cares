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
                // selected country regions
                var selectedCountryRegions = ko.observableArray([]);
                var addUpdatelabel = ko.observable("hello");
                //fleet pool code
                var fleetPoolCode = ko.observable();
                //fleet pool Name
                var fleetPoolName = ko.observable();
                //fleet pool Vehicles
                var fleetPoolVehicles = ko.observable();
                //fleet pool Description
                var fleetPoolDescription = ko.observable();
                //new operation filter
                var newOperationFilter = ko.observable();
                //new country filter
                var newCountryFilter = ko.observable();
                //new region filter
                var newRegionFilter = ko.observable();
                // add fleetpool
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
                // country Filter
                var countryFilter = ko.observable();
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
                var countryList = ko.observableArray([]);
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


                            countryList.removeAll();
                            ko.utils.arrayPushAll(countryList(), data.Countries);
                            countryList.valueHasMutated();


                            if (callBack && callBack === 'function') {
                                callBack()();
                            };
                        },
                        error: function(data, error) {

                            toastr.error("Failed to load base data.");
                        }
                    });
                };
                //country selected form dd
                var countrySelected = function () {
                    getRegions(newCountryFilter());
                };

                function getRegions( _countryId) {

                    dataservice.getCountryRegions({
                        countryId: _countryId
                    }, {
                        success: function (data) {
                            //     toastr.success("successfully");
                            selectedCountryRegions.removeAll();
                            jQuery.each(data, function (index, value) {
                                debugger;
                                selectedCountryRegions.push(value);
                            });
                        },
                        error: function () {
                            toastr.error("Failed to load regions!");
                        }
                    });


                    
                }

                var cancelSave = function() {

                    isFleetPoolEditorVisible(false);
                };

                //add new fleetpool
                var saveFleetPool = function () {
                    dataservice.saveFleetPool({
                        CountryId: newCountryFilter(),
                        RegionId: newRegionFilter(),
                        OperationId: newOperationFilter(),
                        FleetPoolCode: fleetPoolCode(),
                        FleetPoolName: fleetPoolName(),
                        ApproximateVehiclesAsgnd: fleetPoolVehicles(),
                        FleetPoolDescription: fleetPoolDescription()

                    }, {
                        success: function (data) {
                            debugger;
                            reset();
                            toastr.success("Successfully added!");
                        },
                        error: function () {
                            toastr.error("Failed to add!");
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
                    countryFilter(undefined);
                    operationFilter(undefined);
                    search();
                    fleetPoolCode(undefined);
                    fleetPoolName(undefined);
                    fleetPoolVehicles(undefined);
                    fleetPoolDescription(undefined);
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
                    newCountryFilter(undefined);
                    newOperationFilter(undefined);
                    newRegionFilter(undefined);
                    fleetPoolCode(undefined);
                    fleetPoolName(undefined);
                    fleetPoolVehicles(undefined);
                    fleetPoolDescription(undefined);
                    addUpdatelabel("Add");
                    isFleetPoolEditorVisible(true);
                };
                // delete fleetpool
                var onDeleteFleetPool = function(item) {
                    if (!item.id()) {
                        fleetPools.remove(item);
                        return;
                    }
                    // Ask for confirmation
                    confirmation.afterProceed(function() {
                        deleteAsset(item);
                    });
                    confirmation.show();
                },
                // Delete Fleetpool request to daraservice
                deleteAsset = function (asset) {
                    dataservice.deleteFleetPool(asset.convertToServerData(), {
                        success: function() {
                            fleetPools.remove(asset);
                            toastr.success("FleetPool removed successfully");
                        },
                        error: function() {
                            toastr.error("Failed to remove product!");
                        }
                    });
                };
                // on edit the existing fleet pool
                var onEditFleetPool = function (item) {

                    addUpdatelabel("Update");
                    getRegions(item.countryId());
                    editFleetPool(item);
                    newRegionFilter(item.regionId());
                };
                function editFleetPool(item) {
                   
                    isFleetPoolEditorVisible(true);
                    newCountryFilter(item.countryId());
                    newOperationFilter(item.operationId());
                    fleetPoolCode(item.code());
                    fleetPoolName(item.name());
                    fleetPoolVehicles(item.vehiclesAssigned());
                    fleetPoolDescription(item.description());
                    debugger;
                }
                // Map Tarrif Types - Server to Client
                var mapFleetPools = function(data) {
                    var fleetPoolList = [];
                    _.each(data.FleetPools, function (item) {
                        var fleetPool = model.fleetPoolServertoClinetMapper(item);
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
                        CountryId:countryFilter(),
                        OperationId: operationFilter(),
                        PageSize: pager().pageSize(),
                        PageNo: pager().currentPage(),
                        SortBy: sortOn(),
                        IsAsc: sortIsAsc()
                    }, {
                        success: function (data) {

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
                    countryFilter:countryFilter,
                    search: search,
                    reset:reset,
                    isFleetPoolEditorVisible: isFleetPoolEditorVisible,
                    countrySelected :countrySelected ,
                    countryList: countryList,
                    onDeleteFleetPool: onDeleteFleetPool,
                    onEditFleetPool: onEditFleetPool,
                    createFleetForm: createFleetForm,
                    ccreatePoolDetail: createPoolDetail,
                    addFleetPoll: addFleetPoll,
                    showFleetPoolEditor: showFleetPoolEditor,
                    selectedCountryRegions: selectedCountryRegions,
                    fleetPoolCode: fleetPoolCode,
                    fleetPoolName: fleetPoolName,
                    fleetPoolVehicles: fleetPoolVehicles,
                    fleetPoolDescription: fleetPoolDescription,
                    saveFleetPool: saveFleetPool,
                    cancelSave: cancelSave,
                    newCountryFilter: newCountryFilter,
                    newRegionFilter: newRegionFilter,
                    newOperationFilter: newOperationFilter,
                    addUpdatelabel: addUpdatelabel
                };
            })()
        };
        return ist.fleetPool.viewModel;
    });
