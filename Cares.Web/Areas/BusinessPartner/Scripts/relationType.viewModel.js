/*
    Module with the view model for the Business Partner Relationship Type
*/
define("relationType/relationType.viewModel",
    ["jquery", "amplify", "ko", "relationType/relationType.dataservice", "relationType/relationType.model",
    "common/confirmation.viewModel", "common/pagination"],
    function($, amplify, ko, dataservice, model, confirmation, pagination) {
        var ist = window.ist || {};
        ist.BusinessPartnerRelationshipType = {
            viewModel: (function() { 
                var view,
                    //array to save Business Partner Relationship Types
                    businessPartnerRelationshipTypes = ko.observableArray([]),
                    //pager%
                    pager = ko.observable(),
                    //org code filter in filter sec
                    searchFilter = ko.observable(),
                    //sorting
                    sortOn = ko.observable(1),
                    //Assending  / Desending
                    sortIsAsc = ko.observable(true),
                    //to control the visibility of editor sec
                    isBusinessPartnerRelationshipTypeEditorVisible = ko.observable(false),
                    //to control the visibility of filter ec
                    filterSectionVisilble = ko.observable(false),
                     // Editor View Model
                    editorViewModel = new ist.ViewModel(model.BusinessPartnerRelationshipTypeDetail),
                    // Selected Business Partner Relationship Type
                    selectedBusinessPartnerRelationshipType = editorViewModel.itemForEditing,
                    //save button handler
                    onSavebtn = function() {
                        if (dobeforeBusinessPartnerRelationshipType())
                            saveBusinessPartnerRelationshipType(selectedBusinessPartnerRelationshipType());
                },
                //Save Business Partner Relationship Type
                    saveBusinessPartnerRelationshipType = function (item) {
                        dataservice.saveBusinessPartnerRelationshipType(item.convertToServerData(), {
                        success: function(dataFromServer) {
                            var newItem = model.businessPartnerRelationshipTypeServertoClinetMapper(dataFromServer);
                            if (item.id() !== undefined) {
                                var newObjtodelete = businessPartnerRelationshipTypes.find(function(temp) {
                                    return temp.id() == newItem.id();
                                });
                                businessPartnerRelationshipTypes.remove(newObjtodelete);
                                businessPartnerRelationshipTypes.push(newItem);
                            } else
                                businessPartnerRelationshipTypes.push(newItem);
                            isBusinessPartnerRelationshipTypeEditorVisible(false);
                            toastr.success(ist.resourceText.BusinessPartnerRelationshipTypeSuccessfullySavedMessage);
                        },
                        error: function(exceptionMessage, exceptionType) {
                            if (exceptionType === ist.exceptionType.CaresGeneralException)
                                toastr.error(exceptionMessage);
                            else
                                toastr.error(ist.resourceText.FailedToSaveBusinessPartnerRelationshipTypeError);
                        }
                    });
                },
                //validation check 
                    dobeforeBusinessPartnerRelationshipType = function () {
                    if (!selectedBusinessPartnerRelationshipType().isValid()) {
                        selectedBusinessPartnerRelationshipType().errors.showAllMessages();
                        return false;
                    }
                    return true;
                },
                //cancel button handler
                    onCancelbtn = function() {
                    editorViewModel.revertItem();
                    isBusinessPartnerRelationshipTypeEditorVisible(false);
                },
                // create new Business Partner Relationship Type
                    onCreateForm = function () {
                    var businessPartnerRelationshipTypeDetail = new model.BusinessPartnerRelationshipTypeDetail();
                    editorViewModel.selectItem(businessPartnerRelationshipTypeDetail);
                    isBusinessPartnerRelationshipTypeEditorVisible(true);
                },
                //reset butto handle 
                    resetResuults = function() {
                    searchFilter(undefined);
                    getBusinessPartnerRelationshipTypes();
                },
                //delete button handler
                    onDeleteItem = function(item) {
                    if (!item.id()) {
                        businessPartnerRelationshipTypes.remove(item);
                        return;
                    }
                    // Ask for confirmation
                    confirmation.afterProceed(function() {
                        deleteBusinessPartnerRelationshipType(item);
                    });
                    confirmation.show();
                },
                //edit button handler
                    onEditItem = function(item) {
                    editorViewModel.selectItem(item);
                    isBusinessPartnerRelationshipTypeEditorVisible(true);
                },
                //DeleteBusiness Partner Relationship Type
                    deleteBusinessPartnerRelationshipType = function (businessPartnerRelationshipType) {
                       dataservice.deleteBusinessPartnerRelationshipType(businessPartnerRelationshipType.convertToServerData(), {
                        success: function() {
                            businessPartnerRelationshipTypes.remove(businessPartnerRelationshipType);
                            toastr.success(ist.resourceText.BusinessPartnerRelationshipTypeSuccessfullyDeletedMessage);
                        },
                        error: function(exceptionMessage, exceptionType) {
                            if (exceptionType === ist.exceptionType.CaresGeneralException)
                                toastr.error(exceptionMessage);
                            else
                                toastr.error(ist.resourceText.FailedToDeleteBusinessPartnerRelationshipTypeError);
                        }
                    });
                },
                //search button handler in filter section
                    search = function() {
                    pager().reset();
                    getBusinessPartnerRelationshipTypes();
                },
                //hide filte section
                    hideFilterSection = function() {
                    filterSectionVisilble(false);
                },
                //Show filter section
                    showFilterSection = function() {
                        filterSectionVisilble(true);
                    },
                    //GetBusiness Partner Relationship Types list from Dataservice
                    getBusinessPartnerRelationshipTypes = function () {
                        dataservice.getBusinessPartnerRelationshipType(
                        {
                            BusinessPartnerRelationTypeFilterText: searchFilter(),
                            PageSize: pager().pageSize(),
                            PageNo: pager().currentPage(),
                            SortBy: sortOn(),
                            IsAsc: sortIsAsc()
                    },
                    {
                        success: function (data) {
                            businessPartnerRelationshipTypes.removeAll();
                            pager().totalCount(data.TotalCount);
                            _.each(data.BusinessPartnerRelationshipTypes, function (item) {
                                businessPartnerRelationshipTypes.push(model.businessPartnerRelationshipTypeServertoClinetMapper(item));
                            });
                        },
                        error: function() {
                            toastr.error(ist.resourceText.FailedToLoadBusinessPartnerRelationshipTypesError);
                        }
                    });
                    },
                    
                // Initialize the view model
                    initialize = function(specifiedView) {
                        view = specifiedView;
                        ko.applyBindings(view.viewModel, view.bindingRoot);
                        pager(pagination.Pagination({ PageSize: 10 }, businessPartnerRelationshipTypes, getBusinessPartnerRelationshipTypes));
                        getBusinessPartnerRelationshipTypes();
                    };
                return {
                    businessPartnerRelationshipTypes: businessPartnerRelationshipTypes,
                    initialize: initialize,
                    search: search,
                    searchFilter: searchFilter,
                    sortOn: sortOn,
                    sortIsAsc: sortIsAsc,
                    onCreateForm: onCreateForm,
                    filterSectionVisilble: filterSectionVisilble,
                    isBusinessPartnerRelationshipTypeEditorVisible: isBusinessPartnerRelationshipTypeEditorVisible,
                    hideFilterSection: hideFilterSection,
                    showFilterSection: showFilterSection,
                    pager: pager,
                    resetResuults: resetResuults,
                    onDeleteItem: onDeleteItem,
                    onEditItem: onEditItem,
                    onCancelbtn: onCancelbtn,
                    selectedBusinessPartnerRelationshipType: selectedBusinessPartnerRelationshipType,
                    onSavebtn: onSavebtn,
                    getBusinessPartnerRelationshipTypes: getBusinessPartnerRelationshipTypes,
                };
            })()
        };
        return ist.BusinessPartnerRelationshipType.viewModel;
    });
