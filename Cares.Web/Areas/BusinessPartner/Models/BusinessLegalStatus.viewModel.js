/*
    Module with the view model for the Business Legal Status
*/
define("businessLegalStatus/businessLegalStatus.viewModel",
    ["jquery", "amplify", "ko", "businessLegalStatus/businessLegalStatus.dataservice", "businessLegalStatus/businessLegalStatus.model",
    "common/confirmation.viewModel", "common/pagination"],
    function($, amplify, ko, dataservice, model, confirmation, pagination) {
        var ist = window.ist || {};
        ist.BusinessLegalStatus = {
            viewModel: (function() { 
                var view,
                    //array to save Business Legal Statuses
                    businessLegalStatuses = ko.observableArray([]),
                    //pager%
                    pager = ko.observable(),
                    //org code filter in filter sec
                    searchFilter = ko.observable(),
                    //sorting
                    sortOn = ko.observable(1),
                    //Assending  / Desending
                    sortIsAsc = ko.observable(true),
                    //to control the visibility of editor sec
                    isBusinessLegalStatusEditorVisible = ko.observable(false),
                    //to control the visibility of filter ec
                    filterSectionVisilble = ko.observable(false),
                     // Editor View Model
                    editorViewModel = new ist.ViewModel(model.BusinessLegalStatusDetail),
                    // Selected  Business Legal Status
                    selectedBusinessLegalStatus = editorViewModel.itemForEditing,
                    //save button handler
                    onSavebtn = function() {
                        if (dobeforeBusinessLegalStatus())
                            saveBusinessLegalStatus(selectedBusinessLegalStatus());
                },
                //Save Business Legal Statuses
                    saveBusinessLegalStatus = function (item) {
                        dataservice.saveBusinessLegalStatus(item.convertToServerData(), {
                        success: function(dataFromServer) {
                            var newItem = model.businessLegalStatusServertoClinetMapper(dataFromServer);
                            if (item.id() !== undefined) {
                                var newObjtodelete = businessLegalStatuses.find(function(temp) {
                                    return temp.id() == newItem.id();
                                });
                                businessLegalStatuses.remove(newObjtodelete);
                                businessLegalStatuses.push(newItem);
                            } else
                                businessLegalStatuses.push(newItem);
                            isBusinessLegalStatusEditorVisible(false);
                            toastr.success(ist.resourceText.BusinessLegalStatusSuccessfullySavedMessage);
                        },
                        error: function(exceptionMessage, exceptionType) {
                            if (exceptionType === ist.exceptionType.CaresGeneralException)
                                toastr.error(exceptionMessage);
                            else
                                toastr.error(ist.resourceText.FailedToSaveBusinessLegalStatusError);
                        }
                    });
                },
                //validation check 
                    dobeforeBusinessLegalStatus = function () {
                    if (!selectedBusinessLegalStatus().isValid()) {
                        selectedBusinessLegalStatus().errors.showAllMessages();
                        return false;
                    }
                    return true;
                },
                //cancel button handler
                    onCancelbtn = function() {
                    editorViewModel.revertItem();
                    isBusinessLegalStatusEditorVisible(false);
                },
                // create new Business Legal Status
                    onCreateForm = function () {
                    var businessLegalStatusDetail = new model.BusinessLegalStatusDetail();
                   editorViewModel.selectItem(businessLegalStatusDetail);
                    isBusinessLegalStatusEditorVisible(true);
                },
                //reset butto handle 
                    resetResuults = function() {
                    searchFilter(undefined);
                    getbusinessLegalStatuses();
                },
                //delete button handler
                    onDeleteItem = function(item) {
                    if (!item.id()) {
                        businessLegalStatuses.remove(item);
                        return;
                    }
                    // Ask for confirmation
                    confirmation.afterProceed(function() {
                        deleteBusinessLegalStatus(item);
                    });
                    confirmation.show();
                },
                //edit button handler
                    onEditItem = function(item) {
                    editorViewModel.selectItem(item);
                    isBusinessLegalStatusEditorVisible(true);
                },
                //Delete Business Legal Status
                    deleteBusinessLegalStatus = function (businessLegalStatus) {
                       dataservice.deleteBusinessLegalStatus(businessLegalStatus.convertToServerData(), {
                        success: function() {
                            businessLegalStatuses.remove(businessLegalStatus);
                            toastr.success(ist.resourceText.BusinessLegalStatusSuccessfullyDeletedMessage);
                        },
                        error: function(exceptionMessage, exceptionType) {
                            if (exceptionType === ist.exceptionType.CaresGeneralException)
                                toastr.error(exceptionMessage);
                            else
                                toastr.error(ist.resourceText.FailedToDeleteBusinessLegalStatusError);
                        }
                    });
                },
                //search button handler in filter section
                    search = function() {
                    pager().reset();
                    getbusinessLegalStatuses();
                },
                //hide filte section
                    hideFilterSection = function() {
                    filterSectionVisilble(false);
                },
                //Show filter section
                    showFilterSection = function() {
                        filterSectionVisilble(true);
                    },
                    //Get Business Legal Status list from Dataservice
                    getbusinessLegalStatuses = function () {
                        dataservice.getBusinessLegalStatuses(
                        {
                            BusinessLegalStatusSearchText: searchFilter(),
                            PageSize: pager().pageSize(),
                            PageNo: pager().currentPage(),
                            SortBy: sortOn(),
                            IsAsc: sortIsAsc()
                    },
                    {
                        success: function (data) {
                            businessLegalStatuses.removeAll();
                            pager().totalCount(data.TotalCount);
                            _.each(data.BusinessLegalStatuses, function (item) {
                                businessLegalStatuses.push(model.businessLegalStatusServertoClinetMapper(item));
                            });
                        },
                        error: function() {
                            isLoadingFleetPools(false);
                            toastr.error(ist.resourceText.FailedToLoadBusinessLegalStatusesError);
                        }
                    });
                    },
                    
                // Initialize the view model
                    initialize = function(specifiedView) {
                        view = specifiedView;
                        ko.applyBindings(view.viewModel, view.bindingRoot);
                        pager(pagination.Pagination({ PageSize: 10 }, businessLegalStatuses, getbusinessLegalStatuses));
                        getbusinessLegalStatuses();
                    };
                return {
                    businessLegalStatuses: businessLegalStatuses,
                    initialize: initialize,
                    search: search,
                    searchFilter: searchFilter,
                    sortOn: sortOn,
                    sortIsAsc: sortIsAsc,
                    onCreateForm: onCreateForm,
                    filterSectionVisilble: filterSectionVisilble,
                    isBusinessLegalStatusEditorVisible: isBusinessLegalStatusEditorVisible,
                    hideFilterSection: hideFilterSection,
                    showFilterSection: showFilterSection,
                    pager: pager,
                    resetResuults: resetResuults,
                    onDeleteItem: onDeleteItem,
                    onEditItem: onEditItem,
                    onCancelbtn: onCancelbtn,
                    selectedBusinessLegalStatus: selectedBusinessLegalStatus,
                    onSavebtn: onSavebtn,
                    getbusinessLegalStatuses: getbusinessLegalStatuses,
                };
            })()
        };
        return ist.BusinessLegalStatus.viewModel;
    });
