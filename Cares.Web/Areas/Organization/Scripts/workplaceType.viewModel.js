/*
    Module with the view model for the workplaceType
*/
define("workplaceType/workplaceType.viewModel",
    ["jquery", "amplify", "ko", "workplaceType/workplaceType.dataservice", "workplaceType/workplaceType.model",
    "common/confirmation.viewModel", "common/pagination"],
    function($, amplify, ko, dataservice, model, confirmation, pagination) {
        var ist = window.ist || {};
        ist.WorkPlaceType = {
            viewModel: (function() { 
                var view,
                    //array to save org groups
                    workPlaceTypes = ko.observableArray([]),
                    //pager%
                    pager = ko.observable(),
                    //org code filter in filter sec
                    searchFilter = ko.observable(),
        
                   // pre-defined Department Types List
                    baseWorkplaceNatureList = ko.observableArray(["Sales", "Support"]),
                    //sorting
                    sortOn = ko.observable(1),
                    //Assending  / Desending
                    sortIsAsc = ko.observable(true),
                    //to control the visibility of editor sec
                    isWorkPlaceTypeEditorVisible = ko.observable(false),
                    //to control the visibility of filter ec
                    filterSectionVisilble = ko.observable(false),


                     // Editor View Model
                    editorViewModel = new ist.ViewModel(model.workPlaceTypeDetail),
                    // Selected company
                    selectedWorkPlaceType = editorViewModel.itemForEditing,

                    //save button handler
                    onSavebtn = function () {
                        if (dobeforeWorkPlapeceTy())
                        saveWorkPlaceType(selectedWorkPlaceType());
                    },
                    //save WorkPlace Type
                    saveWorkPlaceType = function(item) {
                        dataservice.saveWorkPlaceType(item.convertToServerData(), {
                            success: function (dataFromServer) {
                                debugger;
                                var newItem = model.workPlaceTypeServertoClinetMapper(dataFromServer);
                                if (item.id() !== undefined) {
                                    var newObjtodelete = workPlaceTypes.find(function(temp) {
                                        return temp.id() == newItem.id();
                                    });
                                    workPlaceTypes.remove(newObjtodelete);
                                    workPlaceTypes.push(newItem);
                                }
                                else
                                    workPlaceTypes.push(newItem);
                                isWorkPlaceTypeEditorVisible(false);
                                toastr.success(ist.resourceText.WorkPlaceTypeSaveSuccessMessage);
                            },
                            error: function (exceptionMessage, exceptionType) {
                                if (exceptionType === ist.exceptionType.CaresGeneralException)
                                    toastr.error(exceptionMessage);
                                else
                                    toastr.error(ist.resourceText.WorkPlaceTypeSaveFailError);
                            }
                        });
                    }, 
                    //validation check 
                    dobeforeWorkPlapeceTy = function() {
                        if (!selectedWorkPlaceType().isValid()) {
                            selectedWorkPlaceType().errors.showAllMessages();
                            return false;
                        }
                        return true;
                    },
                    //cancel button handler
                    onCancelbtn = function () {
                        editorViewModel.revertItem();
                        isWorkPlaceTypeEditorVisible(false);
                    },
                    // create new workplace type
                    onCreateForm = function () {
                        var workPlacetype = new model.workPlaceTypeDetail();
                        editorViewModel.selectItem(workPlacetype);
                        isWorkPlaceTypeEditorVisible(true);
                    },
                    //reset butto handle 
                    resetResuults = function() {
                        searchFilter(undefined);
                        getWorkPlaceType();
                    },
                    //delete button handler
                    onDeleteWorkPlaceType = function(item) {
                        if (!item.id()) {
                            workPlaceTypes.remove(item);
                            return;
                        }
                    // Ask for confirmation
                        confirmation.afterProceed(function() {
                            deleteWorkPlaceType(item);
                        });
                        confirmation.show();
                    },
                    //edit button handler
                    onEditWorkplaceType = function(item) {
                        editorViewModel.selectItem(item);
                        isWorkPlaceTypeEditorVisible(true);
                    },
                    //delete workplace
                    deleteWorkPlaceType = function(workPlaceType) {
                        dataservice.deleteWorkPlaceType(workPlaceType.convertToServerData(), {
                            success: function() {
                                workPlaceTypes.remove(workPlaceType);
                                toastr.success(ist.resourceText.WorkPlaceTypeDeleteSuccessMessage);
                            },
                            error: function (exceptionMessage, exceptionType) {
                                if (exceptionType === ist.exceptionType.CaresGeneralException)
                                    toastr.error(exceptionMessage);
                                else
                                    toastr.error(ist.resourceText.WorkPlaceTypeDeleteFailError);
                            }
                        });
                    },
                    //search button handler in filter section
                    search = function() {
                        pager().reset();
                        getWorkPlaceType();
                    },
                    //hide filte section
                    hideFilterSection = function() {
                        filterSectionVisilble(false);
                    },
                    //Show filter section
                    showFilterSection = function() {
                        filterSectionVisilble(true);
                    },
                    //get workplace list from Dataservice
                    getWorkPlaceType = function() {
                        dataservice.getWorkPlaceTypes(
                        {
                            WorkplaceTypeFilterText: searchFilter(),
                            PageSize: pager().pageSize(),
                            PageNo: pager().currentPage(),
                            SortBy: sortOn(),
                            IsAsc: sortIsAsc()
                        },
                        {
                            success: function(data) {
                                workPlaceTypes.removeAll();
                                debugger;
                                pager().totalCount(data.TotalCount);
                                _.each(data.WorkPlaceTypes, function (item) {
                                    workPlaceTypes.push(model.workPlaceTypeServertoClinetMapper(item));
                                });
                            },
                            error: function() {
                                isLoadingFleetPools(false);
                                toastr.error(ist.resourceText.WorkPlaceTypeLoadFailError);
                            }
                        });
                    },

                  
                    // Initialize the view model
                    initialize = function(specifiedView) {
                        view = specifiedView;
                        ko.applyBindings(view.viewModel, view.bindingRoot);
                        pager(pagination.Pagination({ PageSize: 10 }, workPlaceTypes, getWorkPlaceType));
                        getWorkPlaceType();
                    };
                return {
                    workPlaceTypes: workPlaceTypes,
                    initialize: initialize,
                    search: search,
                    searchFilter: searchFilter,
                    sortOn: sortOn,
                    sortIsAsc: sortIsAsc,
                    onCreateForm: onCreateForm,
                    filterSectionVisilble: filterSectionVisilble,
                    isWorkPlaceTypeEditorVisible: isWorkPlaceTypeEditorVisible,
                    hideFilterSection: hideFilterSection,
                    showFilterSection: showFilterSection,
                    pager: pager,
                    resetResuults: resetResuults,
                    onDeleteWorkPlaceType: onDeleteWorkPlaceType,
                    onEditWorkplaceType: onEditWorkplaceType,
                    onCancelbtn: onCancelbtn,
                    selectedWorkPlaceType: selectedWorkPlaceType,
                    onSavebtn: onSavebtn,
                    getWorkPlaceType: getWorkPlaceType,

                    baseWorkplaceNatureList: baseWorkplaceNatureList

                };
            })()
        };
        return ist.WorkPlaceType.viewModel;
    });
