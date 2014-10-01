/*
    Module with the view model for the  Rating Type
*/
define("ratingType/ratingType.viewModel",
    ["jquery", "amplify", "ko", "ratingType/ratingType.dataservice", "ratingType/ratingType.model",
    "common/confirmation.viewModel", "common/pagination"],
    function($, amplify, ko, dataservice, model, confirmation, pagination) {
        var ist = window.ist || {};
        ist.RatingType = {
            viewModel: (function() { 
                var view,
                    //array to save Rating Types
                    ratingTypes = ko.observableArray([]),                   
                    //pager%
                    pager = ko.observable(),
                    //org code filter in filter sec
                    searchFilter = ko.observable(),
                    //sorting
                    sortOn = ko.observable(1),
                    //Assending  / Desending
                    sortIsAsc = ko.observable(true),
                    //to control the visibility of editor sec
                    isRatingTypeEditorVisible = ko.observable(false),
                    //to control the visibility of filter ec
                    filterSectionVisilble = ko.observable(false),
                     // Editor View Model
                    editorViewModel = new ist.ViewModel(model.RatingTypeDetail),
                    // Selected  Rating Type
                    selectedRatingType = editorViewModel.itemForEditing,
                    //save button handler
                    onSavebtn = function() {
                    if (dobeforeratingDoc())
                        saveRatingType(selectedRatingType());
                },
                //Save  Rating Types
                    saveRatingType = function(item) {
                        dataservice.saveRatingType(item.convertToServerData(), {
                        success: function(dataFromServer) {
                            var newItem = model.ratingTypeServertoClinetMapper(dataFromServer);
                            if (item.id() !== undefined) {
                                var newObjtodelete = ratingTypes.find(function(temp) {
                                    return temp.id() == newItem.id();
                                });
                                ratingTypes.remove(newObjtodelete);
                                ratingTypes.push(newItem);
                            } else
                                ratingTypes.push(newItem);
                            isRatingTypeEditorVisible(false);
                            toastr.success(ist.resourceText.RatingTypeSuccessfullySavedMessage);
                        },
                        error: function(exceptionMessage, exceptionType) {
                            if (exceptionType === ist.exceptionType.CaresGeneralException)
                                toastr.error(exceptionMessage);
                            else
                                toastr.error(ist.resourceText.FailedToSaveRatingTypeError);
                        }
                    });
                },
                //validation check 
                    dobeforeratingDoc = function() {
                    if (!selectedRatingType().isValid()) {
                        selectedRatingType().errors.showAllMessages();
                        return false;
                    }
                    return true;
                },
                //cancel button handler
                    onCancelbtn = function() {
                    editorViewModel.revertItem();
                    isRatingTypeEditorVisible(false);
                },
                // create new  Rating Type
                    onCreateForm = function () {
                  var ratingType = new model.RatingTypeDetail();
                  editorViewModel.selectItem(ratingType);
                    isRatingTypeEditorVisible(true);
                },
                //reset butto handle 
                    resetResuults = function() {
                    searchFilter(undefined);
                    getRatingTypes();
                },
                //delete button handler
                    onDeleteItem = function(item) {
                    if (!item.id()) {
                        ratingTypes.remove(item);
                        return;
                    }
                    // Ask for confirmation
                    confirmation.afterProceed(function() {
                        deleteRatingType(item);
                    });
                    confirmation.show();
                },
                //edit button handler
                    onEditItem = function(item) {
                    editorViewModel.selectItem(item);
                    isRatingTypeEditorVisible(true);
                },
                //Delete  Rating Type
                    deleteRatingType = function (ratingType) {
                       dataservice.deleteRatingType(ratingType.convertToServerData(), {
                        success: function() {
                            ratingTypes.remove(ratingType);
                            toastr.success(ist.resourceText.RatingTypeSuccessfullyDeletedMessage);
                        },
                        error: function(exceptionMessage, exceptionType) {
                            if (exceptionType === ist.exceptionType.CaresGeneralException)
                                toastr.error(exceptionMessage);
                            else
                                toastr.error(ist.resourceText.FailedToDeleteRatingTypeError);
                        }
                    });
                },
                //search button handler in filter section
                    search = function() {
                    pager().reset();
                    getRatingTypes();
                },
                //hide filte section
                    hideFilterSection = function() {
                    filterSectionVisilble(false);
                },
                //Show filter section
                    showFilterSection = function() {
                        filterSectionVisilble(true);
                    },
                    //Get Rating Type list from Dataservice
                    getRatingTypes = function () {
                        dataservice.getRatingTypes(
                        {
                            RatingTypeFilterText: searchFilter(),
                            PageSize: pager().pageSize(),
                            PageNo: pager().currentPage(),
                            SortBy: sortOn(),
                            IsAsc: sortIsAsc()
                    },
                    {
                        success: function (data) {
                            ratingTypes.removeAll();
                            pager().totalCount(data.TotalCount);
                            _.each(data.RatingTypes, function (item) {
                                ratingTypes.push(model.ratingTypeServertoClinetMapper(item));
                            });
                        },
                        error: function() {
                            isLoadingFleetPools(false);
                            toastr.error(ist.resourceText.FailedToLoadRatingTypesError);
                        }
                    });
                    },
                    
                // Initialize the view model
                    initialize = function(specifiedView) {
                        view = specifiedView;
                        ko.applyBindings(view.viewModel, view.bindingRoot);
                        pager(pagination.Pagination({ PageSize: 10 }, ratingTypes, getRatingTypes));
                        getRatingTypes();
                    };
                return {
                    ratingTypes: ratingTypes,
                    initialize: initialize,
                    search: search,
                    searchFilter: searchFilter,
                    sortOn: sortOn,
                    sortIsAsc: sortIsAsc,
                    onCreateForm: onCreateForm,
                    filterSectionVisilble: filterSectionVisilble,
                    isRatingTypeEditorVisible: isRatingTypeEditorVisible,
                    hideFilterSection: hideFilterSection,
                    showFilterSection: showFilterSection,
                    pager: pager,
                    resetResuults: resetResuults,
                    onDeleteItem: onDeleteItem,
                    onEditItem: onEditItem,
                    onCancelbtn: onCancelbtn,
                    selectedRatingType: selectedRatingType,
                    onSavebtn: onSavebtn,
                    getRatingTypes: getRatingTypes,
                };
            })()
        };
        return ist.RatingType.viewModel;
    });
