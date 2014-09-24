/*
    Module with the view model for the Discount Type
*/
define("discountType/discountType.viewModel",
    ["jquery", "amplify", "ko", "discountType/discountType.dataservice", "discountType/discountType.model",
    "common/confirmation.viewModel", "common/pagination"],
    function($, amplify, ko, dataservice, model, confirmation, pagination) {
        var ist = window.ist || {};
        ist.DiscountType = {
            viewModel: (function() { 
                var view,
                    //array to save Discount Types
                    discountTypes = ko.observableArray([]),
                    //pager%
                    pager = ko.observable(),
                    //org code filter in filter sec
                    searchFilter = ko.observable(),
                    //sorting
                    sortOn = ko.observable(1),
                    //Assending  / Desending
                    sortIsAsc = ko.observable(true),
                    //to control the visibility of editor sec
                    isDiscountTypeEditorVisible = ko.observable(false),
                    //to control the visibility of filter ec
                    filterSectionVisilble = ko.observable(false),
                     // Editor View Model
                    editorViewModel = new ist.ViewModel(model.DiscountTypeDetail),
                    // Selected Discount Type
                    selectedDiscountType = editorViewModel.itemForEditing,
                    //save button handler
                    onSavebtn = function() {
                    if (dobeforeDiscountType())
                        saveDiscountType(selectedDiscountType());
                },
                //Save Discount Type
                    saveDiscountType = function (item) {
                        dataservice.saveDiscountType(item.convertToServerData(), {
                        success: function(dataFromServer) {
                            var newItem = model.discountTypeServertoClinetMapper(dataFromServer);
                            if (item.id() !== undefined) {
                                var newObjtodelete = discountTypes.find(function(temp) {
                                    return temp.id() == newItem.id();
                                });
                                discountTypes.remove(newObjtodelete);
                                discountTypes.push(newItem);
                            } else
                                discountTypes.push(newItem);
                            isDiscountTypeEditorVisible(false);
                            toastr.success(ist.resourceText.DiscountTypeSuccessfullySavedMessage);
                        },
                        error: function(exceptionMessage, exceptionType) {
                            if (exceptionType === ist.exceptionType.CaresGeneralException)
                                toastr.error(exceptionMessage);
                            else
                                toastr.error(ist.resourceText.FailedToSaveDiscountTypeError);
                        }
                    });
                },
                //validation check 
                    dobeforeDiscountType = function () {
                    if (!selectedDiscountType().isValid()) {
                        selectedDiscountType().errors.showAllMessages();
                        return false;
                    }
                    return true;
                },
                //cancel button handler
                    onCancelbtn = function() {
                    editorViewModel.revertItem();
                    isDiscountTypeEditorVisible(false);
                },
                // create new Discount Type
                    onCreateForm = function () {
                        var discountType = new model.DiscountTypeDetail();
                    editorViewModel.selectItem(discountType);
                    isDiscountTypeEditorVisible(true);
                },
                //reset butto handle 
                    resetResuults = function() {
                        searchFilter(undefined);
                        getDiscountType();
                },
                //delete button handler
                    onDeleteItem = function(item) {
                    if (!item.id()) {
                        discountTypes.remove(item);
                        return;
                    }
                    // Ask for confirmation
                    confirmation.afterProceed(function() {
                        deleteDiscountType(item);
                    });
                    confirmation.show();
                },
                //edit button handler
                    onEditItem = function(item) {
                    editorViewModel.selectItem(item);
                    isDiscountTypeEditorVisible(true);
                },
                //delete Discount Type
                    deleteDiscountType = function (region) {
                        dataservice.deleteDiscountType(region.convertToServerData(), {
                        success: function() {
                            discountTypes.remove(region);
                            toastr.success(ist.resourceText.DiscountTypeSuccessfullyDeletedMessage);
                        },
                        error: function(exceptionMessage, exceptionType) {
                            if (exceptionType === ist.exceptionType.CaresGeneralException)
                                toastr.error(exceptionMessage);
                            else
                                toastr.error(ist.resourceText.FailedToDeleteDiscountTypeError);
                        }
                    });
                },
                //search button handler in filter section
                    search = function() {
                    pager().reset();
                    getDiscountType();
                },
                //hide filte section
                    hideFilterSection = function() {
                    filterSectionVisilble(false);
                },
                //Show filter section
                    showFilterSection = function() {
                        filterSectionVisilble(true);
                    },
                    //get Discount Types list from Dataservice
                    getDiscountType = function () {
                        dataservice.getDiscountType(
                        {
                            DiscountTypeFilterText: searchFilter(),
                            PageSize: pager().pageSize(),
                            PageNo: pager().currentPage(),
                            SortBy: sortOn(),
                            IsAsc: sortIsAsc()
                    },
                    {
                        success: function (data) {
                            discountTypes.removeAll();
                            pager().totalCount(data.TotalCount);
                            _.each(data.DiscountTypes, function (item) {
                                discountTypes.push(model.discountTypeServertoClinetMapper(item));
                            });
                        },
                        error: function() {
                            isLoadingFleetPools(false);
                            toastr.error(ist.resourceText.FailedToLoadDiscountTypesError);
                        }
                    });
                    },
                     
                // Initialize the view model
                    initialize = function(specifiedView) {
                        view = specifiedView;
                        ko.applyBindings(view.viewModel, view.bindingRoot);
                        pager(pagination.Pagination({ PageSize: 10 }, discountTypes, getDiscountType));
                        getDiscountType();
                    };
                return {
                    discountTypes: discountTypes,
                    initialize: initialize,
                    search: search,
                    searchFilter: searchFilter,
                    sortOn: sortOn,
                    sortIsAsc: sortIsAsc,
                    onCreateForm: onCreateForm,
                    filterSectionVisilble: filterSectionVisilble,
                    isDiscountTypeEditorVisible: isDiscountTypeEditorVisible,
                    hideFilterSection: hideFilterSection,
                    showFilterSection: showFilterSection,
                    pager: pager,
                    resetResuults: resetResuults,
                    onDeleteItem: onDeleteItem,
                    onEditItem: onEditItem,
                    onCancelbtn: onCancelbtn,
                    selectedDiscountType: selectedDiscountType,
                    onSavebtn: onSavebtn,
                    getDiscountType: getDiscountType
                };
            })()
        };
        return ist.DiscountType.viewModel;
    });
