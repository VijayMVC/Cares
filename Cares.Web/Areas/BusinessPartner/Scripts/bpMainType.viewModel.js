/*
    Module with the view model for the Business Partner Main Type
*/
define("bpMainType/bpMainType.viewModel",
    ["jquery", "amplify", "ko", "bpMainType/bpMainType.dataservice", "bpMainType/bpMainType.model",
    "common/confirmation.viewModel", "common/pagination"],
    function($, amplify, ko, dataservice, model, confirmation, pagination) {
        var ist = window.ist || {};
        ist.BusinessPartnerMainType = {
            viewModel: (function() { 
                var view,
                    //array to save Business Partner Main Type
                    businessPartnerMainType = ko.observableArray([]),
                    //pager%
                    pager = ko.observable(),
                    //org code filter in filter sec
                    searchFilter = ko.observable(),
                    //sorting
                    sortOn = ko.observable(1),
                    //Assending  / Desending
                    sortIsAsc = ko.observable(true),
                    //to control the visibility of editor sec
                    isBusinessPartnerMainTypeEditorVisible = ko.observable(false),
                    //to control the visibility of filter ec
                    filterSectionVisilble = ko.observable(false),
                     // Editor View Model
                    editorViewModel = new ist.ViewModel(model.BpMainTypeDetail),
                    // Selected Business Partner Main Type
                    selectedBusinessPartnerMainType = editorViewModel.itemForEditing,
                    //save button handler
                    onSavebtn = function() {
                        if (dobeforeBusinessPartnerMainType())
                            saveBusinessPartnerMainType(selectedBusinessPartnerMainType());
                },
                //Save Business Partner Main Type
                    saveBusinessPartnerMainType = function (item) {
                        dataservice.saveBpMainType(item.convertToServerData(), {
                        success: function(dataFromServer) {
                            var newItem = model.bpMainTypeServertoClinetMapper(dataFromServer);
                            if (item.id() !== undefined) {
                                var newObjtodelete = businessPartnerMainType.find(function(temp) {
                                    return temp.id() == newItem.id();
                                });
                                businessPartnerMainType.remove(newObjtodelete);
                                businessPartnerMainType.push(newItem);
                            } else
                                businessPartnerMainType.push(newItem);
                            isBusinessPartnerMainTypeEditorVisible(false);
                            toastr.success(ist.resourceText.BusinessPartnerMainTypeSuccessfullySavedMessage);
                        },
                        error: function(exceptionMessage, exceptionType) {
                            if (exceptionType === ist.exceptionType.CaresGeneralException)
                                toastr.error(exceptionMessage);
                            else
                                toastr.error(ist.resourceText.FailedToSaveBusinessPartnerMainTypeError);
                        }
                    });
                },
                //validation check 
                    dobeforeBusinessPartnerMainType = function () {
                    if (!selectedBusinessPartnerMainType().isValid()) {
                        selectedBusinessPartnerMainType().errors.showAllMessages();
                        return false;
                    }
                    return true;
                },
                //cancel button handler
                    onCancelbtn = function() {
                    editorViewModel.revertItem();
                    isBusinessPartnerMainTypeEditorVisible(false);
                },
                // create new Business Partner Main Type
                    onCreateForm = function () {
                   var varBusinessPartnerMainType = new model.BpMainTypeDetail();
                    editorViewModel.selectItem(varBusinessPartnerMainType);
                    isBusinessPartnerMainTypeEditorVisible(true);
                },
                //reset butto handle 
                    resetResuults = function() {
                    searchFilter(undefined);
                    getBusinessPartnerMainTypes();
                },
                //delete button handler
                    onDeleteItem = function(item) {
                    if (!item.id()) {
                        businessPartnerMainType.remove(item);
                        return;
                    }
                    // Ask for confirmation
                    confirmation.afterProceed(function() {
                        deleteBusinessPartnerMainType(item);
                    });
                    confirmation.show();
                },
                //edit button handler
                    onEditItem = function(item) {
                    editorViewModel.selectItem(item);
                    isBusinessPartnerMainTypeEditorVisible(true);
                },
                //delete Business Partner Main Type
                    deleteBusinessPartnerMainType = function (region) {
                        dataservice.deleteBpMainType(region.convertToServerData(), {
                        success: function() {
                            businessPartnerMainType.remove(region);
                            toastr.success(ist.resourceText.BusinessPartnerMainTypeSuccessFullyDeletedMessage);
                        },
                        error: function(exceptionMessage, exceptionType) {
                            if (exceptionType === ist.exceptionType.CaresGeneralException)
                                toastr.error(exceptionMessage);
                            else
                                toastr.error(ist.resourceText.FailedToDeleteBusinessPartnerMainTypeError);
                        }
                    });
                },
                //search button handler in filter section
                    search = function() {
                    pager().reset();
                    getBusinessPartnerMainTypes();
                },
                //hide filte sectiong
                    hideFilterSection = function() {
                    filterSectionVisilble(false);
                },
                //Show filter section
                    showFilterSection = function() {
                        filterSectionVisilble(true);
                    },
                    //get Business Partner Main Types list from Dataservice
                    getBusinessPartnerMainTypes = function () {
                        dataservice.getBpMainTypes(
                        {
                            BpMainTypeFilterText: searchFilter(),
                            PageSize: pager().pageSize(),
                            PageNo: pager().currentPage(),
                            SortBy: sortOn(),
                            IsAsc: sortIsAsc()
                    },
                    {
                        success: function (data) {
                            businessPartnerMainType.removeAll();
                            pager().totalCount(data.TotalCount);
                            _.each(data.BpMainTypes, function (item) {
                                businessPartnerMainType.push(model.bpMainTypeServertoClinetMapper(item));
                            });
                        },
                        error: function() {
                            isLoadingFleetPools(false);
                            toastr.error(ist.resourceText.FailedToLoadBusinessPartnerMainTypeError);
                        }
                    });
                    },
                    
                // Initialize the view model
                    initialize = function(specifiedView) {
                        view = specifiedView;
                        ko.applyBindings(view.viewModel, view.bindingRoot);
                        pager(pagination.Pagination({ PageSize: 10 }, businessPartnerMainType, getBusinessPartnerMainTypes));
                        getBusinessPartnerMainTypes();
                    };
                return {
                    businessPartnerMainType: businessPartnerMainType,
                    initialize: initialize,
                    search: search,
                    searchFilter: searchFilter,
                    sortOn: sortOn,
                    sortIsAsc: sortIsAsc,
                    onCreateForm: onCreateForm,
                    filterSectionVisilble: filterSectionVisilble,
                    isBusinessPartnerMainTypeEditorVisible: isBusinessPartnerMainTypeEditorVisible,
                    hideFilterSection: hideFilterSection,
                    showFilterSection: showFilterSection,
                    pager: pager,
                    resetResuults: resetResuults,
                    onDeleteItem: onDeleteItem,
                    onEditItem: onEditItem,
                    onCancelbtn: onCancelbtn,
                    selectedBusinessPartnerMainType: selectedBusinessPartnerMainType,
                    onSavebtn: onSavebtn,
                    getBusinessPartnerMainTypes: getBusinessPartnerMainTypes,
                };
            })()
        };
        return ist.BusinessPartnerMainType.viewModel;
    });
