/*
    Module with the view model for the Designations
*/
define("designation/designation.viewModel",
    ["jquery", "amplify", "ko", "designation/designation.dataservice", "designation/designation.model",
    "common/confirmation.viewModel", "common/pagination"],
    function($, amplify, ko, dataservice, model, confirmation, pagination) {
        var ist = window.ist || {};
        ist.Designation = {
            viewModel: (function() { 
                var view,
                    //array to save Regions
                    designations = ko.observableArray([]),
                    //pager%
                    pager = ko.observable(),
                    //org code filter in filter sec
                    searchFilter = ko.observable(),
                    //sorting
                    sortOn = ko.observable(1),
                    //Assending  / Desending
                    sortIsAsc = ko.observable(true),
                    //to control the visibility of editor sec
                    isdesignationEditorVisible = ko.observable(false),
                    //to control the visibility of filter ec
                    filterSectionVisilble = ko.observable(false),
                     // Editor View Model
                    editorViewModel = new ist.ViewModel(model.DesignationsDetail),
                    // Selected Business Segment
                    selectedDesignation = editorViewModel.itemForEditing,
                    //save button handler
                    onSavebtn = function() {
                        if (dobeforeDesignation())
                            saveDesignation(selectedDesignation());
                },
                //Save Designation
                    saveDesignation = function (item) {
                        dataservice.saveDesignation(item.convertToServerData(), {
                        success: function(dataFromServer) {
                            var newItem = model.designationServertoClinetMapper(dataFromServer);
                            if (item.id() !== undefined) {
                                var newObjtodelete = designations.find(function(temp) {
                                    return temp.id() == newItem.id();
                                });
                                designations.remove(newObjtodelete);
                                designations.push(newItem);
                            } else
                                designations.push(newItem);
                            isdesignationEditorVisible(false);
                            toastr.success(ist.resourceText.DesignationSaveSuccessMessage);
                        },
                        error: function(exceptionMessage, exceptionType) {
                            if (exceptionType === ist.exceptionType.CaresGeneralException)
                                toastr.error(exceptionMessage);
                            else
                                toastr.error(ist.resourceText.DesignationDeleteFailError);
                        }
                    });
                },
                //validation check 
                    dobeforeDesignation = function () {
                    if (!selectedDesignation().isValid()) {
                        selectedDesignation().errors.showAllMessages();
                        return false;
                    }
                    return true;
                },
                //cancel button handler
                    onCancelbtn = function() {
                    editorViewModel.revertItem();
                    isdesignationEditorVisible(false);
                },
                // create new Designation
                    onCreateForm = function () {
                    var designation = new model.DesignationsDetail();
                    editorViewModel.selectItem(designation);
                    isdesignationEditorVisible(true);
                },
                //reset butto handle 
                    resetResuults = function() {
                    searchFilter(undefined);
                    getDesignations();
                },
                //delete button handler
                    onDeleteItem = function(item) {
                    if (!item.id()) {
                        designations.remove(item);
                        return;
                    }
                    // Ask for confirmation
                    confirmation.afterProceed(function() {
                        deleteDesignation(item);
                    });
                    confirmation.show();
                },
                //edit button handler
                    onEditItem = function(item) {
                    editorViewModel.selectItem(item);
                    isdesignationEditorVisible(true);
                },
                //delete Designation
                    deleteDesignation = function(region) {
                        dataservice.deleteDesignation(region.convertToServerData(), {
                        success: function() {
                            designations.remove(region);
                            toastr.success(ist.resourceText.DesignationDeleteSuccessMessage);
                        },
                        error: function(exceptionMessage, exceptionType) {
                            if (exceptionType === ist.exceptionType.CaresGeneralException)
                                toastr.error(exceptionMessage);
                            else
                                toastr.error(ist.resourceText.DesignationDeleteFailError);
                        }
                    });
                },
                //search button handler in filter section
                    search = function() {
                    pager().reset();
                    getDesignations();
                },
                //hide filte section
                    hideFilterSection = function() {
                    filterSectionVisilble(false);
                },
                //Show filter section
                    showFilterSection = function() {
                        filterSectionVisilble(true);
                    },
                    //get Regions list from Dataservice
                    getDesignations = function() {
                        dataservice.getDesignations(
                        {
                            DesignationFilterText: searchFilter(),
                            PageSize: pager().pageSize(),
                            PageNo: pager().currentPage(),
                            SortBy: sortOn(),
                            IsAsc: sortIsAsc()
                    },
                    {
                        success: function (data) {
                            designations.removeAll();
                            pager().totalCount(data.TotalCount);
                            _.each(data.Designations, function (item) {
                                designations.push(model.designationServertoClinetMapper(item));
                            });
                        },
                        error: function() {
                            isLoadingFleetPools(false);
                            toastr.error(ist.resourceText.DesignationLoadFailError);
                        }
                    });
                    },
                    
                // Initialize the view model
                    initialize = function(specifiedView) {
                        view = specifiedView;
                        ko.applyBindings(view.viewModel, view.bindingRoot);
                        pager(pagination.Pagination({ PageSize: 10 }, designations, getDesignations));
                        getDesignations();
                    };
                return {
                    designations: designations,
                    initialize: initialize,
                    search: search,
                    searchFilter: searchFilter,
                    sortOn: sortOn,
                    sortIsAsc: sortIsAsc,
                    onCreateForm: onCreateForm,
                    filterSectionVisilble: filterSectionVisilble,
                    isdesignationEditorVisible: isdesignationEditorVisible,
                    hideFilterSection: hideFilterSection,
                    showFilterSection: showFilterSection,
                    pager: pager,
                    resetResuults: resetResuults,
                    onDeleteItem: onDeleteItem,
                    onEditItem: onEditItem,
                    onCancelbtn: onCancelbtn,
                    selectedDesignation: selectedDesignation,
                    onSavebtn: onSavebtn,
                    getDesignations: getDesignations,
                   
                };
            })()
        };
        return ist.Designation.viewModel;
    });
