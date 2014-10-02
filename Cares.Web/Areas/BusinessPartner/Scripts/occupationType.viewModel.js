/*
    Module with the view model for the Occupation Type
*/
define("occupationType/occupationType.viewModel",
    ["jquery", "amplify", "ko", "occupationType/occupationType.dataservice", "occupationType/occupationType.model",
    "common/confirmation.viewModel", "common/pagination"],
    function($, amplify, ko, dataservice, model, confirmation, pagination) {
        var ist = window.ist || {};
        ist.OccupationType = {
            viewModel: (function() { 
                var view,
                    //array to save Occupation Types
                    occupationTypes = ko.observableArray([]),
                    //pager%
                    pager = ko.observable(),
                    //org code filter in filter sec
                    searchFilter = ko.observable(),
                    //sorting
                    sortOn = ko.observable(1),
                    //Assending  / Desending
                    sortIsAsc = ko.observable(true),
                    //to control the visibility of editor sec
                    isOccupationTypeEditorVisible = ko.observable(false),
                    //to control the visibility of filter ec
                    filterSectionVisilble = ko.observable(false),
                     // Editor View Model
                    editorViewModel = new ist.ViewModel(model.OccupationTypeDetail),
                    // Selected  Occupation Type
                    selectedOccupationType = editorViewModel.itemForEditing,
                    //save button handler
                    onSavebtn = function() {
                        if (dobeforeOccupationType())
                            saveOccupationType(selectedOccupationType());
                },
                //Save Occupation Type
                    saveOccupationType = function (item) {
                        dataservice.saveOccupationType(item.convertToServerData(), {
                        success: function(dataFromServer) {
                            var newItem = model.occupationTypeServertoClinetMapper(dataFromServer);
                            if (item.id() !== undefined) {
                                var newObjtodelete = occupationTypes.find(function(temp) {
                                    return temp.id() == newItem.id();
                                });
                                occupationTypes.remove(newObjtodelete);
                                occupationTypes.push(newItem);
                            } else
                                occupationTypes.push(newItem);
                            isOccupationTypeEditorVisible(false);
                            toastr.success(ist.resourceText.OccupationTypeSuccessfullySavedMessage);
                        },
                        error: function(exceptionMessage, exceptionType) {
                            if (exceptionType === ist.exceptionType.CaresGeneralException)
                                toastr.error(exceptionMessage);
                            else
                                toastr.error(ist.resourceText.FailedToSaveOccupationTypeError);
                        }
                    });
                },
                //validation check 
                    dobeforeOccupationType = function () {
                    if (!selectedOccupationType().isValid()) {
                        selectedOccupationType().errors.showAllMessages();
                        return false;
                    }
                    return true;
                },
                //cancel button handler
                    onCancelbtn = function() {
                    editorViewModel.revertItem();
                    isOccupationTypeEditorVisible(false);
                },
                // create new Occupation Type
                    onCreateForm = function () {
                    var occupationTypeDetail = new model.OccupationTypeDetail();
                    editorViewModel.selectItem(occupationTypeDetail);
                    isOccupationTypeEditorVisible(true);
                },
                //reset butto handle 
                    resetResuults = function() {
                    searchFilter(undefined);
                    getOccupationTypes();
                },
                //delete button handler
                    onDeleteItem = function(item) {
                    if (!item.id()) {
                        occupationTypes.remove(item);
                        return;
                    }
                    // Ask for confirmation
                    confirmation.afterProceed(function() {
                        deleteOccupationType(item);
                    });
                    confirmation.show();
                },
                //edit button handler
                    onEditItem = function(item) {
                    editorViewModel.selectItem(item);
                    isOccupationTypeEditorVisible(true);
                },
                //Delete Occupation Type
                    deleteOccupationType = function (occupationType) {
                       dataservice.deleteOccupationType(occupationType.convertToServerData(), {
                        success: function() {
                            occupationTypes.remove(occupationType);
                            toastr.success(ist.resourceText.OccupationTypeSuccessfullyDeletedMessage);
                        },
                        error: function(exceptionMessage, exceptionType) {
                            if (exceptionType === ist.exceptionType.CaresGeneralException)
                                toastr.error(exceptionMessage);
                            else
                                toastr.error(ist.resourceText.FailedToDeleteOccupationTypeError);
                        }
                    });
                },
                //search button handler in filter section
                    search = function() {
                    pager().reset();
                    getOccupationTypes();
                },
                //hide filte section
                    hideFilterSection = function() {
                    filterSectionVisilble(false);
                },
                //Show filter section
                    showFilterSection = function() {
                        filterSectionVisilble(true);
                    },
                    //Get Occupation Types list from Dataservice
                    getOccupationTypes = function () {
                        dataservice.getOccupationTypes(
                        {
                            OccupationTypeCodeNameText: searchFilter(),
                            PageSize: pager().pageSize(),
                            PageNo: pager().currentPage(),
                            SortBy: sortOn(),
                            IsAsc: sortIsAsc()
                    },
                    {
                        success: function (data) {
                            occupationTypes.removeAll();
                            pager().totalCount(data.TotalCount);
                            _.each(data.OccupationTypes, function (item) {
                                occupationTypes.push(model.occupationTypeServertoClinetMapper(item));
                            });
                        },
                        error: function() {
                            isLoadingFleetPools(false);
                            toastr.error(ist.resourceText.FailedToLoadOccupationTypesError);
                        }
                    });
                    },
                    
                // Initialize the view model
                    initialize = function(specifiedView) {
                        view = specifiedView;
                        ko.applyBindings(view.viewModel, view.bindingRoot);
                        pager(pagination.Pagination({ PageSize: 10 }, occupationTypes, getOccupationTypes));
                        getOccupationTypes();
                    };
                return {
                    occupationTypes: occupationTypes,
                    initialize: initialize,
                    search: search,
                    searchFilter: searchFilter,
                    sortOn: sortOn,
                    sortIsAsc: sortIsAsc,
                    onCreateForm: onCreateForm,
                    filterSectionVisilble: filterSectionVisilble,
                    isOccupationTypeEditorVisible: isOccupationTypeEditorVisible,
                    hideFilterSection: hideFilterSection,
                    showFilterSection: showFilterSection,
                    pager: pager,
                    resetResuults: resetResuults,
                    onDeleteItem: onDeleteItem,
                    onEditItem: onEditItem,
                    onCancelbtn: onCancelbtn,
                    selectedOccupationType: selectedOccupationType,
                    onSavebtn: onSavebtn,
                    getOccupationTypes: getOccupationTypes,
                };
            })()
        };
        return ist.OccupationType.viewModel;
    });
