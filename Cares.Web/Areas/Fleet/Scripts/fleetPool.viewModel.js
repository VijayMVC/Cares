/*
    Module with the view model for the FleetPool
*/
define("Fleet/fleetPool.viewModel",
    ["jquery", "amplify", "ko", "Fleet/fleetPool.dataservice", "Fleet/fleetPool.model", "common/confirmation.viewModel", "common/pagination"],
    function($, amplify, ko, dataservice, model, confirmation, pagination) {

        var ist = window.ist || {};
        ist.fleetPool = {
            viewModel: (function() {
                // the view 
                var view,
                     // Show Filter Section
                    filterSectionVisilble = ko.observable(false),
                    //to check if edit mode 
                     isEditMode = ko.observable(false),
                    // Active FleetPool
                    selectedFleetPool = ko.observable(),
                    // fleetPools
                    fleetPools = ko.observableArray([]),
                    // Regions
                    regionsList = ko.observableArray([]),
                    //Country Base Region List
                    contryBaseRegionList = ko.observableArray([]),
                    // Operations
                    operationsList = ko.observableArray([]),
                    //counytr list
                    countryList = ko.observableArray([]),
                    // FleetPool Code
                    fleetPoolSeachFilter = ko.observable(),
                    //Operation Filter
                    fleetPoolOperationFilter = ko.observable(),
                    // region Filter
                    fleetPoolRegionFilter = ko.observable(),
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
                                contryBaseRegionList.removeAll();
                                ko.utils.arrayPushAll(contryBaseRegionList(), data.Regions);
                                contryBaseRegionList.valueHasMutated();
                                countryList.removeAll();
                                ko.utils.arrayPushAll(countryList(), data.Countries);
                                countryList.valueHasMutated();
                                if (callBack && typeof callBack === 'function') {
                                    callBack();
                                };
                            },
                            error: function(exceptionMessage, exceptionType) {
                                if (exceptionType === ist.exceptionType.CaresGeneralException) {
                                    toastr.error(exceptionMessage);
                                } else {
                                    toastr.error("Failed to load base data.");
                                }
                            }
                        });
                    },
                     // Collapase filter section
                    collapseFilterSection = function () {
                        filterSectionVisilble(false);
                    },
                    //Show filter section
                    showFilterSection = function () {
                        filterSectionVisilble(true);
                    },
                     // close Product Editor
                    closeFleetPoolEditor = function () {
                        isFleetPoolEditorVisible(false);
                    },
                    //country selected form dd
                    countrySelected = function() {
                        //getRegions(newCountryFilter());
                    },
                    onCancelSave = function() {
                        isFleetPoolEditorVisible(false);
                    },
                    //Validation Check function while saving Fleet Pool
                    doBeforeSaveFleetPool = function() {
                        return selectedFleetPool().isValid();
                    },
                    //event handler for Saving Fleet Pool
                    onSaveFleetPool = function() {
                        if (doBeforeSaveFleetPool()) {
                            saveFleetPool();
                        }
                    },
                    //add new fleetpool
                    saveFleetPool = function () {
                        if (isEditMode()) // to check if we are editing some record
                        {
                            dataservice.updateFleetPool(model.fleePoolClienttoServerMapper(selectedFleetPool()), {
                                success: function(dataFromServer) {
                                    fleetPools.replace(selectedFleetPool(), model.fleetPoolServertoClinetMapper(dataFromServer));
                                    isEditMode(false);
                                    toastr.success("Successfully upadted!");
                                },
                                error: function() {
                                    toastr.error("Failed to upadte!");
                                }
                            });
                        }
                        else    // adding new fleetpool
                        {
                            dataservice.saveFleetPool(model.fleePoolClienttoServerMapper(selectedFleetPool()), {
                                success: function (dataFromServer) {
                                    fleetPools.push(model.fleetPoolServertoClinetMapper(dataFromServer));
                                    isFleetPoolEditorVisible(false);
                                    toastr.success("Successfully Added!");
                                },
                                error: function () {
                                    toastr.error("Failed to Add!");
                                }
                            });
                        }
                    },
                    //search Fleet Pools
                    search = function() {
                        pager().reset();
                        getFleetPools();
                    },
                    reset = function() {
                        fleetPoolSeachFilter(undefined);
                        fleetPoolRegionFilter(undefined);

                        fleetPoolOperationFilter(undefined);
                        search();                        
                    },
                    createFleetForm = function() { //parent
                        var fleetPool = createPoolDetail();
                        selectedFleetPool(fleetPool);
                        showFleetPoolEditor();
                    },
                    //creating fleetpool details 
                    createPoolDetail = function () {
                        var fleetPool = model.FleetPoolDetail();
                        return new model.FleetPoolDetail.Create(fleetPool);
                    },
                    showFleetPoolEditor = function() {
                        isFleetPoolEditorVisible(true);
                    },
                    // delete fleetpool
                    onDeleteFleetPool = function(item) {
                        if (!item.id()) {
                            fleetPools.remove(item);
                            return;
                        }
                        // Ask for confirmation
                        confirmation.afterProceed(function() {
                            deleteFleetPool(item);
                        });
                        confirmation.show();
                    },
                    // Delete Fleetpool request to daraservice
                    deleteFleetPool = function(asset) {
                        dataservice.deleteFleetPool(asset.convertToServerData(), {
                            success: function() {
                                fleetPools.remove(asset);
                                toastr.success("FleetPool removed successfully");
                            },
                            error: function() {
                                toastr.error("Failed to remove product!");
                            }
                        });
                    },
                    // on edit the existing fleet pool
                    onEditFleetPool = function (item) {
                        isEditMode(true);
                        selectedFleetPool(item);
                        editFleetPool(item);                        
                    },
                    // Filter Regions
                    filterRegions = function (item, data) {
                        contryBaseRegionList(_.filter(regionsList(), function(region) {
                             return region.CountryId === item.countryId();
                        }));
                    },
                    // Map Tarrif Types - Server to Client
                    mapFleetPools = function(data) {
                        var fleetPoolList = [];
                        _.each(data.FleetPools, function(item) {
                            var fleetPool = model.fleetPoolServertoClinetMapper(item);
                            fleetPoolList.push(fleetPool);
                        });
                        ko.utils.arrayPushAll(fleetPools(), fleetPoolList);
                        fleetPools.valueHasMutated();
                    },
                    // Get FleetPools 
                    getFleetPools = function() {
                        isLoadingFleetPools(true);
                        dataservice.getFleetPools({
                            FleetPoolSearchText: fleetPoolSeachFilter(),
                            RegionId: fleetPoolRegionFilter(),
                            OperationId: fleetPoolOperationFilter(),
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
                    },
                    // Initialize the view model
                    initialize = function(specifiedView) {
                        view = specifiedView;
                        ko.applyBindings(view.viewModel, view.bindingRoot);
                        // Set Pager / page / paginition
                        pager(pagination.Pagination({ PageSize: 10 }, fleetPools, getFleetPools));
                        getFleetPoolBaseData(getFleetPools);
                    },
                    // function to edit fleet pool
                    editFleetPool = function(item) {
                        isFleetPoolEditorVisible(true);                        
                    };
                return {
                    isLoadingFleetPools: isLoadingFleetPools,
                    sortOn: sortOn,
                    sortIsAsc: sortIsAsc,
                    pager: pager,
                    initialize: initialize,
                    regionsList: regionsList,
                    contryBaseRegionList: contryBaseRegionList,
                    operationsList: operationsList,
                    fleetPools: fleetPools,
                    selectedFleetPool: selectedFleetPool,
                    fleetPoolSeachFilter: fleetPoolSeachFilter,
                    fleetPoolOperationFilter: fleetPoolOperationFilter,
                    fleetPoolRegionFilter: fleetPoolRegionFilter,
                    search: search,
                    reset: reset,
                    isEditMode:isEditMode,
                    isFleetPoolEditorVisible: isFleetPoolEditorVisible,
                    countrySelected: countrySelected,
                    countryList: countryList,
                    onDeleteFleetPool: onDeleteFleetPool,
                    onEditFleetPool: onEditFleetPool,
                    createFleetForm: createFleetForm,
                    ccreatePoolDetail: createPoolDetail,                    
                    showFleetPoolEditor: showFleetPoolEditor,                                        
                    onCancelSave: onCancelSave,
                    onSaveFleetPool: onSaveFleetPool,
                    filterRegions: filterRegions,
                    filterSectionVisilble: filterSectionVisilble,
                    collapseFilterSection: collapseFilterSection,
                    showFilterSection: showFilterSection,
                    closeFleetPoolEditor: closeFleetPoolEditor,
                    getFleetPools: getFleetPools
                };
            })()
        };
        return ist.fleetPool.viewModel;
    });
