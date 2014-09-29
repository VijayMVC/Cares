/*
    Module with the view model for the Region
*/
define("documentGroup/documentGroup.viewModel",
    ["jquery", "amplify", "ko", "documentGroup/documentGroup.dataservice", "documentGroup/documentGroup.model",
    "common/confirmation.viewModel", "common/pagination"],
    function($, amplify, ko, dataservice, model, confirmation, pagination) {
        var ist = window.ist || {};
        ist.Region = {
            viewModel: (function() { 
                var view,
                    //array to save Regions
                    regions = ko.observableArray([]),

                    //array to save basa data country list
                    baseCountriesList = ko.observableArray([]),

                    //pager%
                    pager = ko.observable(),
                    //org code filter in filter sec
                    searchFilter = ko.observable(),
                    baseCountryFilter = ko.observable(),

                    //sorting
                    sortOn = ko.observable(1),
                    //Assending  / Desending
                    sortIsAsc = ko.observable(true),
                    //to control the visibility of editor sec
                    isRegionEditorVisible = ko.observable(false),
                    //to control the visibility of filter ec
                    filterSectionVisilble = ko.observable(false),


                     // Editor View Model
                    editorViewModel = new ist.ViewModel(model.regionDetail),
                    // Selected Business Segment
                    selectedRegion = editorViewModel.itemForEditing,

                    //save button handler
                    onSavebtn = function() {
                    if (dobeforeRegion())
                        saveRegion(selectedRegion());
                },
                //Save Regions
                    saveRegion = function(item) {
                        dataservice.saveRegion(item.convertToServerData(), {
                        success: function(dataFromServer) {
                            var newItem = model.regionServertoClinetMapper(dataFromServer);
                            if (item.id() !== undefined) {
                                var newObjtodelete = regions.find(function(temp) {
                                    return temp.id() == newItem.id();
                                });
                                regions.remove(newObjtodelete);
                                regions.push(newItem);
                            } else
                                regions.push(newItem);
                            isRegionEditorVisible(false);
                            toastr.success(ist.resourceText.RegionSaveSuccessMessage);
                        },
                        error: function(exceptionMessage, exceptionType) {
                            if (exceptionType === ist.exceptionType.CaresGeneralException)
                                toastr.error(exceptionMessage);
                            else
                                toastr.error(ist.resourceText.RegionSaveFailError);
                        }
                    });
                },
                //validation check 
                    dobeforeRegion = function() {
                    if (!selectedRegion().isValid()) {
                        selectedRegion().errors.showAllMessages();
                        return false;
                    }
                    return true;
                },
                //cancel button handler
                    onCancelbtn = function() {
                    editorViewModel.revertItem();
                    isRegionEditorVisible(false);
                },
                // create new Region
                    onCreateForm = function () {
                    var region = new model.regionDetail();
                    editorViewModel.selectItem(region);
                    isRegionEditorVisible(true);
                },
                //reset butto handle 
                    resetResuults = function() {
                    searchFilter(undefined);
                    baseCountryFilter(undefined);
                    getRegions();
                },
                //delete button handler
                    onDeleteItem = function(item) {
                    if (!item.id()) {
                        regions.remove(item);
                        return;
                    }
                    // Ask for confirmation
                    confirmation.afterProceed(function() {
                        deleteRegion(item);
                    });
                    confirmation.show();
                },
                //edit button handler
                    onEditItem = function(item) {
                    editorViewModel.selectItem(item);
                    isRegionEditorVisible(true);
                },
                //delete Region
                    deleteRegion = function(region) {
                       dataservice.deleteRegion(region.convertToServerData(), {
                        success: function() {
                            regions.remove(region);
                            toastr.success(ist.resourceText.RegionDeleteSuccessMessage);
                        },
                        error: function(exceptionMessage, exceptionType) {
                            if (exceptionType === ist.exceptionType.CaresGeneralException)
                                toastr.error(exceptionMessage);
                            else
                                toastr.error(ist.resourceText.RegionDeleteFailError);
                        }
                    });
                },
                //search button handler in filter section
                    search = function() {
                    pager().reset();
                    getRegions();
                },
                //hide filte section
                    hideFilterSection = function() {
                    filterSectionVisilble(false);
                },
                //Show filter section
                    showFilterSection = function() {
                        filterSectionVisilble(true);
                    },
                    //get Regions list from Dataservice
                    getRegions = function() {
                        dataservice.getRegions(
                        {
                            RegionFilterText: searchFilter(),
                            CountryId: baseCountryFilter(),
                            PageSize: pager().pageSize(),
                            PageNo: pager().currentPage(),
                            SortBy: sortOn(),
                            IsAsc: sortIsAsc()
                    },
                    {
                        success: function (data) {
                            debugger;
                            regions.removeAll();
                            pager().totalCount(data.TotalCount);
                            _.each(data.Regions, function (item) {
                                regions.push(model.regionServertoClinetMapper(item));
                            });
                        },
                        error: function() {
                            isLoadingFleetPools(false);
                            toastr.error(ist.resourceText.RegionLoadFailError);
                        }
                    });
                    },
                     //get Region base data
                    getBaseData = function () {
                        dataservice.getRegionBaseData(null, {
                            success: function (data) {

                                baseCountriesList.removeAll();
                                ko.utils.arrayPushAll(baseCountriesList(), data.Countries);
                                baseCountriesList.valueHasMutated();
                            },
                            error: function (exceptionMessage, exceptionType) {
                                if (exceptionType === ist.exceptionType.CaresGeneralException) {
                                    toastr.error(exceptionMessage);
                                } else {
                                    toastr.error(ist.resourceText.RegionBaseDataLoadFailError);
                                }
                            }
                        });
                    },
                // Initialize the view model
                    initialize = function(specifiedView) {
                        view = specifiedView;
                        ko.applyBindings(view.viewModel, view.bindingRoot);
                        pager(pagination.Pagination({ PageSize: 10 }, regions, getRegions));
                        getBaseData();
                        getRegions();
                    };
                return {
                    regions: regions,
                    initialize: initialize,
                    search: search,
                    searchFilter: searchFilter,
                    sortOn: sortOn,
                    sortIsAsc: sortIsAsc,
                    onCreateForm: onCreateForm,
                    filterSectionVisilble: filterSectionVisilble,
                    isRegionEditorVisible: isRegionEditorVisible,
                    hideFilterSection: hideFilterSection,
                    showFilterSection: showFilterSection,
                    pager: pager,
                    resetResuults: resetResuults,
                    onDeleteItem: onDeleteItem,
                    onEditItem: onEditItem,
                    onCancelbtn: onCancelbtn,
                    selectedRegion: selectedRegion,
                    onSavebtn: onSavebtn,
                    getRegions: getRegions,
                    getBaseData: getBaseData,
                    baseCountriesList: baseCountriesList,
                    baseCountryFilter: baseCountryFilter
                };
            })()
        };
        return ist.Region.viewModel;
    });
