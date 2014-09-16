/*
    Module with the view model for the Sub Region
*/
define("subRegion/subRegion.viewModel",
    ["jquery", "amplify", "ko", "subRegion/subRegion.dataservice", "subRegion/subRegion.model",
    "common/confirmation.viewModel", "common/pagination"],
    function($, amplify, ko, dataservice, model, confirmation, pagination) {
        var ist = window.ist || {};
        ist.SubRegion = {
            viewModel: (function() { 
                var view,
                    //array to save Sub Regions
                    subRegions = ko.observableArray([]),

                    //array to save basa data country list
                    baseRegionList = ko.observableArray([]),

                    //pager%
                    pager = ko.observable(),
                    //org code filter in filter sec
                    searchFilter = ko.observable(),
                    baseRegionFilter = ko.observable(),

                    //sorting
                    sortOn = ko.observable(1),
                    //Assending  / Desending
                    sortIsAsc = ko.observable(true),
                    //to control the visibility of editor sec
                    isSubRegionEditorVisible = ko.observable(false),
                    //to control the visibility of filter ec
                    filterSectionVisilble = ko.observable(false),


                     // Editor View Model
                    editorViewModel = new ist.ViewModel(model.subRegionDetail),
                    // Selected Business Segment
                    selectedSubRegion = editorViewModel.itemForEditing,

                    //save button handler
                    onSavebtn = function() {
                    if (dobeforeSubRegion())
                        saveSubRegion(selectedSubRegion());
                },
                //Save sub  Region
                    saveSubRegion = function(item) {
                        dataservice.saveSubRegion(item.convertToServerData(), {
                        success: function(dataFromServer) {
                            var newItem = model.regionServertoClinetMapper(dataFromServer);
                            if (item.id() !== undefined) {
                                var newObjtodelete = subRegions.find(function(temp) {
                                    return temp.id() == newItem.id();
                                });
                                subRegions.remove(newObjtodelete);
                                subRegions.push(newItem);
                            } else
                                subRegions.push(newItem);
                            isSubRegionEditorVisible(false);
                            toastr.success(ist.resourceText.SubRegionSaveSuccessMessage);
                        },
                        error: function(exceptionMessage, exceptionType) {
                            if (exceptionType === ist.exceptionType.CaresGeneralException)
                                toastr.error(exceptionMessage);
                            else
                                toastr.error(ist.resourceText.SubRegionSaveFailError);
                        }
                    });
                },
                //validation check 
                    dobeforeSubRegion = function() {
                    if (!selectedSubRegion().isValid()) {
                        selectedSubRegion().errors.showAllMessages();
                        return false;
                    }
                    return true;
                },
                //cancel button handler
                    onCancelbtn = function() {
                    editorViewModel.revertItem();
                    isSubRegionEditorVisible(false);
                },
                // create new Sub Region
                    onCreateForm = function () {
                        var region = new model.subRegionDetail();
                    editorViewModel.selectItem(region);
                    isSubRegionEditorVisible(true);
                },
                //reset butto handle 
                    resetResuults = function() {
                        searchFilter(undefined);
                        baseRegionFilter(undefined);
                    getSubRegions();
                },
                //delete button handler
                    onDeleteItem = function(item) {
                    if (!item.id()) {
                        subRegions.remove(item);
                        return;
                    }
                    // Ask for confirmation
                    confirmation.afterProceed(function() {
                        deleteSubRegion(item);
                    });
                    confirmation.show();
                },
                //edit button handler
                    onEditItem = function(item) {
                    editorViewModel.selectItem(item);
                    isSubRegionEditorVisible(true);
                },
                //delete Sub Region
                    deleteSubRegion = function(region) {
                        dataservice.deleteSubRegion(region.convertToServerData(), {
                        success: function() {
                            subRegions.remove(region);
                            toastr.success(ist.resourceText.SubRegionDeleteSuccessMessage);
                        },
                        error: function(exceptionMessage, exceptionType) {
                            if (exceptionType === ist.exceptionType.CaresGeneralException)
                                toastr.error(exceptionMessage);
                            else
                                toastr.error(ist.resourceText.SubRegionDeleteFailError);
                        }
                    });
                },
                //search button handler in filter section
                    search = function() {
                    pager().reset();
                    getSubRegions();
                },
                //hide filte section
                    hideFilterSection = function() {
                    filterSectionVisilble(false);
                },
                //Show filter section
                    showFilterSection = function() {
                        filterSectionVisilble(true);
                    },
                    //get Sub Regions list from Dataservice
                    getSubRegions = function() {
                        dataservice.getSubRegions(
                        {
                            SubRegionFilterText: searchFilter(),
                            RegionId: baseRegionFilter(),
                            PageSize: pager().pageSize(),
                            PageNo: pager().currentPage(),
                            SortBy: sortOn(),
                            IsAsc: sortIsAsc()
                    },
                    {
                        success: function (data) {
                            debugger;
                            subRegions.removeAll();
                            pager().totalCount(data.TotalCount);
                            _.each(data.SubRegions, function (item) {
                                subRegions.push(model.regionServertoClinetMapper(item));
                            });
                        },
                        error: function() {
                            isLoadingFleetPools(false);
                            toastr.error(ist.resourceText.SubRegionLoadFailError);
                        }
                    });
                    },
                     //get Sub Region base data
                    getBaseData = function () {
                        dataservice.getSubRegionBaseData(null, {
                            success: function (data) {

                                baseRegionList.removeAll();
                                ko.utils.arrayPushAll(baseRegionList(), data.RegionsDropDowns);
                                baseRegionList.valueHasMutated();
                            },
                            error: function (exceptionMessage, exceptionType) {
                                if (exceptionType === ist.exceptionType.CaresGeneralException) {
                                    toastr.error(exceptionMessage);
                                } else {
                                    toastr.error(ist.resourceText.SubRegionBaseDataLoadFailError);
                                }
                            }
                        });
                    },
                // Initialize the view model
                    initialize = function(specifiedView) {
                        view = specifiedView;
                        ko.applyBindings(view.viewModel, view.bindingRoot);
                        pager(pagination.Pagination({ PageSize: 10 }, subRegions, getSubRegions));
                        getBaseData();
                        getSubRegions();
                    };
                return {
                    subRegions: subRegions,
                    initialize: initialize,
                    search: search,
                    searchFilter: searchFilter,
                    sortOn: sortOn,
                    sortIsAsc: sortIsAsc,
                    onCreateForm: onCreateForm,
                    filterSectionVisilble: filterSectionVisilble,
                    isSubRegionEditorVisible: isSubRegionEditorVisible,
                    hideFilterSection: hideFilterSection,
                    showFilterSection: showFilterSection,
                    pager: pager,
                    resetResuults: resetResuults,
                    onDeleteItem: onDeleteItem,
                    onEditItem: onEditItem,
                    onCancelbtn: onCancelbtn,
                    selectedSubRegion: selectedSubRegion,
                    onSavebtn: onSavebtn,
                    getSubRegions: getSubRegions,

                    getBaseData: getBaseData,
                    baseRegionList: baseRegionList,
                    baseRegionFilter: baseRegionFilter

                };
            })()
        };
        return ist.SubRegion.viewModel;
    });
