/*
    Module with the view model for the Discount Sub Type
*/
define("discountSubType/discountSubType.viewModel",
    ["jquery", "amplify", "ko", "discountSubType/discountSubType.dataservice", "discountSubType/discountSubType.model",
    "common/confirmation.viewModel", "common/pagination"],
    function($, amplify, ko, dataservice, model, confirmation, pagination) {
        var ist = window.ist || {};
        ist.DiscountSubType = {
            viewModel: (function() { 
                var view,
                    //array to save Discount Sub Types
                    discountSubTypes = ko.observableArray([]),
                    //array to save basa data Discount Type list
                    baseDiscountTypeList = ko.observableArray([]),
                    //pager%
                    pager = ko.observable(),
                    //DiscountType filter in filter sec
                    searchFilter = ko.observable(),
                    //Discount Type base data
                    baseDiscountTypeFilter = ko.observable(),
                    //sorting
                    sortOn = ko.observable(1),
                    //Assending  / Desending
                    sortIsAsc = ko.observable(true),
                    //to control the visibility of editor sec
                    isDiscountSubTypesEditorVisible = ko.observable(false),
                    //to control the visibility of filter ec
                    filterSectionVisilble = ko.observable(false),
                     // Editor View Model
                    editorViewModel = new ist.ViewModel(model.DiscountSubTypeDetail),
                    // Selected Discount Sub Type
                    selectedDiscountSubType = editorViewModel.itemForEditing,
                    //save button handler
                    onSavebtn = function() {
                    if (dobeforeDiscountSubType())
                        saveDiscountSubType(selectedDiscountSubType());
                },
                //Save Discount Sub Type
                    saveDiscountSubType = function (item) {
                        dataservice.saveDiscountSubType(item.convertToServerData(), {
                        success: function(dataFromServer) {
                            var newItem = model.DiscountSubTypeServertoClinetMapper(dataFromServer);
                            if (item.id() !== undefined) {
                                var newObjtodelete = discountSubTypes.find(function(temp) {
                                    return temp.id() == newItem.id();
                                });
                                discountSubTypes.remove(newObjtodelete);
                                discountSubTypes.push(newItem);
                            } else
                                discountSubTypes.push(newItem);
                            isDiscountSubTypesEditorVisible(false);
                            toastr.success(ist.resourceText.DiscountSubTypeSuccessfullySavedMessage);
                        },
                        error: function(exceptionMessage, exceptionType) {
                            if (exceptionType === ist.exceptionType.CaresGeneralException)
                                toastr.error(exceptionMessage);
                            else
                                toastr.error(ist.resourceText.DiscountSubTypeFailedToSaveError);
                        }
                    });
                },
                //validation check 
                    dobeforeDiscountSubType = function () {
                    if (!selectedDiscountSubType().isValid()) {
                        selectedDiscountSubType().errors.showAllMessages();
                        return false;
                    }
                    return true;
                },
                //cancel button handler
                    onCancelbtn = function() {
                    editorViewModel.revertItem();
                    isDiscountSubTypesEditorVisible(false);
                },
                // create new Discount Sub Type
                    onCreateForm = function () {
                    var discountSubType = new model.DiscountSubTypeDetail();
                    editorViewModel.selectItem(discountSubType);
                    isDiscountSubTypesEditorVisible(true);
                },
                //reset butto handle 
                    resetResuults = function() {
                    searchFilter(undefined);
                    baseDiscountTypeFilter(undefined);
                    getDiscountSubTypes();
                },
                //delete button handler
                    onDeleteItem = function(item) {
                    if (!item.id()) {
                        discountSubTypes.remove(item);
                        return;
                    }
                    // Ask for confirmation
                    confirmation.afterProceed(function() {
                        deleteDiscountSubType(item);
                    });
                    confirmation.show();
                },
                //edit button handler
                    onEditItem = function(item) {
                    editorViewModel.selectItem(item);
                    isDiscountSubTypesEditorVisible(true);
                },
                //Delete Discount  Sub  Type
                    deleteDiscountSubType = function (region) {
                        dataservice.deleteDiscountSubType(region.convertToServerData(), {
                        success: function() {
                            discountSubTypes.remove(region);
                            toastr.success(ist.resourceText.DiscountSubTypeSuccessfullyDeletedMessage);
                        },
                        error: function(exceptionMessage, exceptionType) {
                            if (exceptionType === ist.exceptionType.CaresGeneralException)
                                toastr.error(exceptionMessage);
                            else
                                toastr.error(ist.resourceText.DiscountSubTypeFailedToDeleteError);
                        }
                    });
                },
                //search button handler in filter section
                    search = function() {
                    pager().reset();
                    getDiscountSubTypes();
                },
                //hide filte section
                    hideFilterSection = function() {
                    filterSectionVisilble(false);
                },
                //Show filter section
                    showFilterSection = function() {
                    filterSectionVisilble(true);
                },
                //get Discount Sub Types list from Dataservice
                    getDiscountSubTypes = function() {
                    dataservice.getDiscountSubType(
                    {
                        DiscountSubTypeFilterText: searchFilter(),
                        DiscountTypeId: baseDiscountTypeFilter(),
                        PageSize: pager().pageSize(),
                        PageNo: pager().currentPage(),
                        SortBy: sortOn(),
                        IsAsc: sortIsAsc()
                    },
                    {
                        success: function(data) {
                            discountSubTypes.removeAll();
                            pager().totalCount(data.TotalCount);
                            _.each(data.DiscountSubTypes, function(item) {
                                discountSubTypes.push(model.DiscountSubTypeServertoClinetMapper(item));
                            });
                        },
                        error: function() {
                            isLoadingFleetPools(false);
                            toastr.error(ist.resourceText.FailedToLoadDiscountSubTypesError);
                        }
                    });
                },
                //get Discount Sub Type base data
                    getBaseData = function() {
                    dataservice.getDiscountSubTypeBaseData(null, {
                        success: function(data) {
                            baseDiscountTypeList.removeAll();
                            ko.utils.arrayPushAll(baseDiscountTypeList(), data.DiscountTypeDropDown);
                            baseDiscountTypeList.valueHasMutated();
                        },
                        error: function(exceptionMessage, exceptionType) {
                            if (exceptionType === ist.exceptionType.CaresGeneralException) {
                                toastr.error(exceptionMessage);
                            } else {
                                toastr.error(ist.resourceText.FailedToLoadBaseDataError);
                            }
                        }
                    });
                },
                // Initialize the view model
                    initialize = function(specifiedView) {
                        view = specifiedView;
                        ko.applyBindings(view.viewModel, view.bindingRoot);
                        pager(pagination.Pagination({ PageSize: 5 }, discountSubTypes, getDiscountSubTypes));
                        getBaseData();
                        getDiscountSubTypes();
                    };
                return {
                    discountSubTypes: discountSubTypes,
                    initialize: initialize,
                    search: search,
                    searchFilter: searchFilter,
                    sortOn: sortOn,
                    sortIsAsc: sortIsAsc,
                    onCreateForm: onCreateForm,
                    filterSectionVisilble: filterSectionVisilble,
                    isDiscountSubTypesEditorVisible: isDiscountSubTypesEditorVisible,
                    hideFilterSection: hideFilterSection,
                    showFilterSection: showFilterSection,
                    pager: pager,
                    resetResuults: resetResuults,
                    onDeleteItem: onDeleteItem,
                    onEditItem: onEditItem,
                    onCancelbtn: onCancelbtn,
                    selectedDiscountSubType: selectedDiscountSubType,
                    onSavebtn: onSavebtn,
                    getDiscountSubTypes: getDiscountSubTypes,
                    getBaseData: getBaseData,
                    baseDiscountTypeList: baseDiscountTypeList,
                    baseDiscountTypeFilter: baseDiscountTypeFilter

                };
            })()
        };
        return ist.DiscountSubType.viewModel;
    });
