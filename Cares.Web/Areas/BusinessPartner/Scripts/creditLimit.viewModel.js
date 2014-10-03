/*
    Module with the view model for the Credit Limit
*/
define("creditLimit/creditLimit.viewModel",
    ["jquery", "amplify", "ko", "creditLimit/creditLimit.dataservice", "creditLimit/creditLimit.model",
    "common/confirmation.viewModel", "common/pagination"],
    function($, amplify, ko, dataservice, model, confirmation, pagination) {
        var ist = window.ist || {};
        ist.CreditLimit = {
            viewModel: (function() { 
                var view,
                    //array to save Credit Limits
                    creditLimits = ko.observableArray([]),
                    //array to save basa data BP Sub Types list
                    baseSubTypesList = ko.observableArray([]),
                   //array to save basa data BP Rating Types list
                    baseRatingTypesList = ko.observableArray([]),
                    //pager%
                    pager = ko.observable(),
                    //org code filter in filter sec
                    baseSubTypeFilter = ko.observable(),
                    baseRatingTypeFilter = ko.observable(),
                    //sorting
                    sortOn = ko.observable(1),
                    //Assending  / Desending
                    sortIsAsc = ko.observable(true),
                    //to control the visibility of editor sec
                    isCreditLimitEditorVisible = ko.observable(false),
                    //to control the visibility of filter ec
                    filterSectionVisilble = ko.observable(false),
                     // Editor View Model
                    editorViewModel = new ist.ViewModel(model.creditLimitDetail),
                    // Selected Credit Limit
                    selectedCreditLimit = editorViewModel.itemForEditing,
                    //save button handler
                    onSavebtn = function() {
                    if (dobeforeCreditLimit())
                        saveCreditLimit(selectedCreditLimit());
                },
                //Save Credit Limit
                    saveCreditLimit = function (item) {
                        dataservice.saveCreditLimit(item.convertToServerData(), {
                        success: function(dataFromServer) {
                            var newItem = model.creditLimitServertoClinetMapper(dataFromServer);
                            if (item.id() !== undefined) {
                                var newObjtodelete = creditLimits.find(function(temp) {
                                    return temp.id() == newItem.id();
                                });
                                creditLimits.remove(newObjtodelete);
                                creditLimits.push(newItem);
                            } else
                                creditLimits.push(newItem);
                            isCreditLimitEditorVisible(false);
                            toastr.success(ist.resourceText.CreditLimitSuccessfullySavedMessage);
                        },
                        error: function(exceptionMessage, exceptionType) {
                            if (exceptionType === ist.exceptionType.CaresGeneralException)
                                toastr.error(exceptionMessage);
                            else
                                toastr.error(ist.resourceText.FailedToSaveCreditLimitError);
                        }
                    });
                },
                //validation check 
                    dobeforeCreditLimit = function () {
                    if (!selectedCreditLimit().isValid()) {
                        selectedCreditLimit().errors.showAllMessages();
                        return false;
                    }
                    return true;
                },
                //cancel button handler
                    onCancelbtn = function() {
                    editorViewModel.revertItem();
                    isCreditLimitEditorVisible(false);
                },
                // create new CreditLimit
                    onCreateForm = function () {
                    var creditLimit = new model.CreateCreditLimit(false);
                    editorViewModel.selectItem(creditLimit);
                    isCreditLimitEditorVisible(true);
                },
                //reset butto handle 
                    resetResuults = function() {
                    baseSubTypeFilter(undefined);
                    baseRatingTypeFilter(undefined);
                    getCreditLimits();
                },
                //delete button handler
                    onDeleteItem = function(item) {
                    if (!item.id()) {
                        creditLimits.remove(item);
                        return;
                    }
                    // Ask for confirmation
                    confirmation.afterProceed(function() {
                        deleteCreditLimit(item);
                    });
                    confirmation.show();
                },
                //edit button handler
                    onEditItem = function(item) {
                    editorViewModel.selectItem(item);
                    isCreditLimitEditorVisible(true);
                },
                //Delete Credit Limit
                    deleteCreditLimit = function (creditLimit) {
                        dataservice.deleteCreditLimit(creditLimit.convertToServerData(), {
                        success: function() {
                            creditLimits.remove(creditLimit);
                            toastr.success(ist.resourceText.CreditLimitSuccessfullyDeletedMessage);
                        },
                        error: function(exceptionMessage, exceptionType) {
                            if (exceptionType === ist.exceptionType.CaresGeneralException)
                                toastr.error(exceptionMessage);
                            else
                                toastr.error(ist.resourceText.FailedToDeleteCreditLimitError);
                        }
                    });
                },
                //search button handler in filter section
                    search = function() {
                    pager().reset();
                    getCreditLimits();
                },
                //hide filte section
                    hideFilterSection = function() {
                    filterSectionVisilble(false);
                },
                //Show filter section
                    showFilterSection = function() {
                        filterSectionVisilble(true);
                    },
                    //Get Credit Limits list from Dataservice
                    getCreditLimits = function () {
                        dataservice.getCreditLimits(
                        {
                            BpSubTypeId: baseSubTypeFilter(),
                            RatingTypeId: baseRatingTypeFilter(),
                            PageSize: pager().pageSize(),
                            PageNo: pager().currentPage(),
                            SortBy: sortOn(),
                            IsAsc: sortIsAsc()
                    },
                    {
                        success: function (data) {
                            creditLimits.removeAll();
                            pager().totalCount(data.TotalCount);
                            _.each(data.CreditLimits, function (item) {
                                creditLimits.push(model.creditLimitServertoClinetMapper(item));
                            });
                        },
                        error: function() {
                            toastr.error(ist.resourceText.FailedToLoadCreditLimitsError);
                        }
                    });
                    },
                     //Get Credit Limit base data
                    getBaseData = function () {
                        dataservice.getCreditLimitBaseData(null, {
                            success: function (data) {
                                baseSubTypesList.removeAll();
                                ko.utils.arrayPushAll(baseSubTypesList(), data.BusinessPartnerSubTypes);
                                baseSubTypesList.valueHasMutated();
                                baseRatingTypesList.removeAll();
                                ko.utils.arrayPushAll(baseRatingTypesList(), data.BpRatingTypes);
                                baseRatingTypesList.valueHasMutated();
                            },
                            error: function (exceptionMessage, exceptionType) {
                                if (exceptionType === ist.exceptionType.CaresGeneralException) {
                                    toastr.error(exceptionMessage);
                                } else {
                                    toastr.error(ist.resourceText.FailedToloadBaseDataError);
                                }
                            }
                        });
                    },
                // Initialize the view model
                    initialize = function(specifiedView) {
                        view = specifiedView;
                        ko.applyBindings(view.viewModel, view.bindingRoot);
                        pager(pagination.Pagination({ PageSize: 10 }, creditLimits, getCreditLimits));
                        getBaseData();
                        getCreditLimits();
                    };
                return {
                    creditLimits: creditLimits,
                    initialize: initialize,
                    search: search,
                    sortOn: sortOn,
                    sortIsAsc: sortIsAsc,
                    onCreateForm: onCreateForm,
                    filterSectionVisilble: filterSectionVisilble,
                    isCreditLimitEditorVisible: isCreditLimitEditorVisible,
                    hideFilterSection: hideFilterSection,
                    showFilterSection: showFilterSection,
                    pager: pager,
                    resetResuults: resetResuults,
                    onDeleteItem: onDeleteItem,
                    onEditItem: onEditItem,
                    onCancelbtn: onCancelbtn,
                    selectedCreditLimit: selectedCreditLimit,
                    onSavebtn: onSavebtn,
                    getCreditLimits: getCreditLimits,
                    getBaseData: getBaseData,
                    baseSubTypesList: baseSubTypesList,
                    baseRatingTypesList:baseRatingTypesList,
                    baseSubTypeFilter: baseSubTypeFilter,
                    baseRatingTypeFilter: baseRatingTypeFilter
                };
            })()
        };
        return ist.CreditLimit.viewModel;
    });
