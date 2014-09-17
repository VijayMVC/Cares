/*
    Module with the view model for the Area
*/
define("area/area.viewModel",
    ["jquery", "amplify", "ko", "area/area.dataservice", "area/area.model",
    "common/confirmation.viewModel", "common/pagination"],
    function($, amplify, ko, dataservice, model, confirmation, pagination) {
        var ist = window.ist || {};
        ist.Area = {
            viewModel: (function() { 
                var view,
                    //array to save Area
                    areas = ko.observableArray([]),

                    //array to save basa data cities list
                    baseCitiesList = ko.observableArray([]),

                    //pager%
                    pager = ko.observable(),
                    //Area filter in filter sec
                    searchFilter = ko.observable(),
                    baseCityFilter = ko.observable(),

                    //sorting
                    sortOn = ko.observable(1),
                    //Assending  / Desending
                    sortIsAsc = ko.observable(true),
                    //to control the visibility of editor sec
                    isAreaEditorVisible = ko.observable(false),
                    //to control the visibility of filter ec
                    filterSectionVisilble = ko.observable(false),
                     // Editor View Model
                    editorViewModel = new ist.ViewModel(model.AreaDetail),
                    // Selected Area
                    selectedArea = editorViewModel.itemForEditing,
                    //save button handler
                    onSavebtn = function() {
                    if (dobeforeArea())
                        saveRegion(selectedArea());
                },
                //Save Area
                    saveRegion = function(item) {
                        dataservice.saveArea(item.convertToServerData(), {
                        success: function(dataFromServer) {
                            var newItem = model.areaServertoClinetMapper(dataFromServer);
                            if (item.id() !== undefined) {
                                var newObjtodelete = areas.find(function(temp) {
                                    return temp.id() == newItem.id();
                                });
                                areas.remove(newObjtodelete);
                                areas.push(newItem);
                            } else
                                areas.push(newItem);
                            isAreaEditorVisible(false);
                            toastr.success(ist.resourceText.AreaSaveSuccessMessage);
                        },
                        error: function(exceptionMessage, exceptionType) {
                            if (exceptionType === ist.exceptionType.CaresGeneralException)
                                toastr.error(exceptionMessage);
                            else
                                toastr.error(ist.resourceText.AreaSaveFailError);
                        }
                    });
                },
                //validation check 
                    dobeforeArea = function() {
                    if (!selectedArea().isValid()) {
                        selectedArea().errors.showAllMessages();
                        return false;
                    }
                    return true;
                },
                //cancel button handler
                    onCancelbtn = function() {
                    editorViewModel.revertItem();
                    isAreaEditorVisible(false);
                },
                // create new Area
                    onCreateForm = function () {
                        var area = new model.AreaDetail();
                    editorViewModel.selectItem(area);
                    isAreaEditorVisible(true);
                },
                //reset butto handle 
                    resetResuults = function() {
                    searchFilter(undefined);
                    baseCityFilter(undefined);
                    getArea();
                },
                //delete button handler
                    onDeleteItem = function(item) {
                    if (!item.id()) {
                        areas.remove(item);
                        return;
                    }
                    // Ask for confirmation
                    confirmation.afterProceed(function() {
                        deleteArea(item);
                    });
                    confirmation.show();
                },
                //edit button handler
                    onEditItem = function(item) {
                    editorViewModel.selectItem(item);
                    isAreaEditorVisible(true);
                },
                //delete Area
                    deleteArea = function(region) {
                        dataservice.deleteArea(region.convertToServerData(), {
                        success: function() {
                            areas.remove(region);
                            toastr.success(ist.resourceText.AreaDeleteSuccessMessage);
                        },
                        error: function(exceptionMessage, exceptionType) {
                            if (exceptionType === ist.exceptionType.CaresGeneralException)
                                toastr.error(exceptionMessage);
                            else
                                toastr.error(ist.resourceText.AreaDeleteFailError);
                        }
                    });
                },
                //search button handler in filter section
                    search = function() {
                    pager().reset();
                    getArea();
                },
                //hide filte section
                    hideFilterSection = function() {
                    filterSectionVisilble(false);
                },
                //Show filter section
                    showFilterSection = function() {
                        filterSectionVisilble(true);
                    },
                    //get Areas list from Dataservice
                    getArea = function() {
                        dataservice.getAreas(
                        {
                            AreaFilterText: searchFilter(),
                            CityId: baseCityFilter(),
                            PageSize: pager().pageSize(),
                            PageNo: pager().currentPage(),
                            SortBy: sortOn(),
                            IsAsc: sortIsAsc()
                    },
                    {
                        success: function (data) {
                            debugger;
                            areas.removeAll();
                            pager().totalCount(data.TotalCount);
                            _.each(data.Areas, function (item) {
                                areas.push(model.areaServertoClinetMapper(item));
                            });
                        },
                        error: function() {
                            isLoadingFleetPools(false);
                            toastr.error(ist.resourceText.AreaLoadFailError);
                        }
                    });
                    },
                     //get Areas base data
                    getBaseData = function () {
                        dataservice.getAreaBaseData(null, {
                            success: function (data) {

                                baseCitiesList.removeAll();
                                ko.utils.arrayPushAll(baseCitiesList(), data.Cities);
                                baseCitiesList.valueHasMutated();
                            },
                            error: function (exceptionMessage, exceptionType) {
                                if (exceptionType === ist.exceptionType.CaresGeneralException) {
                                    toastr.error(exceptionMessage);
                                } else {
                                    toastr.error(ist.resourceText.AreaBaseDataLoadFailError);
                                }
                            }
                        });
                    },
                // Initialize the view model
                    initialize = function(specifiedView) {
                        view = specifiedView;
                        ko.applyBindings(view.viewModel, view.bindingRoot);
                        pager(pagination.Pagination({ PageSize: 5}, areas, getArea));
                        getBaseData();
                        getArea();
                    };
                return {
                    areas: areas,
                    initialize: initialize,
                    search: search,
                    searchFilter: searchFilter,
                    sortOn: sortOn,
                    sortIsAsc: sortIsAsc,
                    onCreateForm: onCreateForm,
                    filterSectionVisilble: filterSectionVisilble,
                    isAreaEditorVisible: isAreaEditorVisible,
                    hideFilterSection: hideFilterSection,
                    showFilterSection: showFilterSection,
                    pager: pager,
                    resetResuults: resetResuults,
                    onDeleteItem: onDeleteItem,
                    onEditItem: onEditItem,
                    onCancelbtn: onCancelbtn,
                    selectedArea: selectedArea,
                    onSavebtn: onSavebtn,
                    getArea: getArea,
                    getBaseData: getBaseData,
                    baseCitiesList: baseCitiesList,
                    baseCityFilter: baseCityFilter

                };
            })()
        };
        return ist.Area.viewModel;
    });
