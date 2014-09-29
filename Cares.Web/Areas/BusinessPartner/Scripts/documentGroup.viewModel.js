/*
    Module with the view model for the Document Group
*/
define("documentGroup/documentGroup.viewModel",
    ["jquery", "amplify", "ko", "documentGroup/documentGroup.dataservice", "documentGroup/documentGroup.model",
    "common/confirmation.viewModel", "common/pagination"],
    function($, amplify, ko, dataservice, model, confirmation, pagination) {
        var ist = window.ist || {};
        ist.DocumentGroup = {
            viewModel: (function() { 
                var view,
                    //array to save Document Groups
                    documentGroups = ko.observableArray([]),
                    //pager%
                    pager = ko.observable(),
                    //org code filter in filter sec
                    searchFilter = ko.observable(),
                    //sorting
                    sortOn = ko.observable(1),
                    //Assending  / Desending
                    sortIsAsc = ko.observable(true),
                    //to control the visibility of editor sec
                    isDocumentGroupEditorVisible = ko.observable(false),
                    //to control the visibility of filter ec
                    filterSectionVisilble = ko.observable(false),
                     // Editor View Model
                    editorViewModel = new ist.ViewModel(model.DocumentGroupDetail),
                    // Selected Document Group
                    selectedDocumentGroup = editorViewModel.itemForEditing,
                    //save button handler
                    onSavebtn = function() {
                        if (dobeforeDocumentGroup())
                            saveDocumentGroup(selectedDocumentGroup());
                },
                //Save Document Group
                    saveDocumentGroup = function (item) {
                        dataservice.saveDocumentGroup(item.convertToServerData(), {
                        success: function(dataFromServer) {
                            var newItem = model.documentGroupServertoClinetMapper(dataFromServer);
                            if (item.id() !== undefined) {
                                var newObjtodelete = documentGroups.find(function(temp) {
                                    return temp.id() == newItem.id();
                                });
                                documentGroups.remove(newObjtodelete);
                                documentGroups.push(newItem);
                            } else
                                documentGroups.push(newItem);
                            isDocumentGroupEditorVisible(false);
                            toastr.success(ist.resourceText.DocumentGroupSuccessfullySavedMessage);
                        },
                        error: function(exceptionMessage, exceptionType) {
                            if (exceptionType === ist.exceptionType.CaresGeneralException)
                                toastr.error(exceptionMessage);
                            else
                                toastr.error(ist.resourceText.FailedToSaveDocumentGroupError);
                        }
                    });
                },
                //validation check 
                    dobeforeDocumentGroup = function () {
                    if (!selectedDocumentGroup().isValid()) {
                        selectedDocumentGroup().errors.showAllMessages();
                        return false;
                    }
                    return true;
                },
                //cancel button handler
                    onCancelbtn = function() {
                    editorViewModel.revertItem();
                    isDocumentGroupEditorVisible(false);
                },
                // create new Document Group
                    onCreateForm = function () {
                    var documentGroup = new model.DocumentGroupDetail();
                    editorViewModel.selectItem(documentGroup);
                    isDocumentGroupEditorVisible(true);
                },
                //reset butto handle 
                    resetResuults = function() {
                    searchFilter(undefined);
                    getDocumentGroups();
                },
                //delete button handler
                    onDeleteItem = function(item) {
                    if (!item.id()) {
                        documentGroups.remove(item);
                        return;
                    }
                    // Ask for confirmation
                    confirmation.afterProceed(function() {
                        deleteDocumentGroup(item);
                    });
                    confirmation.show();
                },
                //edit button handler
                    onEditItem = function(item) {
                    editorViewModel.selectItem(item);
                    isDocumentGroupEditorVisible(true);
                },
                //delete Document Group
                    deleteDocumentGroup = function (region) {
                        dataservice.deleteDocumentGroup(region.convertToServerData(), {
                        success: function() {
                            documentGroups.remove(region);
                            toastr.success(ist.resourceText.DocumentGroupSuccessfullyDeletedMessage);
                        },
                        error: function(exceptionMessage, exceptionType) {
                            if (exceptionType === ist.exceptionType.CaresGeneralException)
                                toastr.error(exceptionMessage);
                            else
                                toastr.error(ist.resourceText.FailedToDeleteDocumentGroupError);
                        }
                    });
                },
                //search button handler in filter section
                    search = function() {
                    pager().reset();
                    getDocumentGroups();
                },
                //hide filte section
                    hideFilterSection = function() {
                    filterSectionVisilble(false);
                },
                //Show filter section
                    showFilterSection = function() {
                        filterSectionVisilble(true);
                    },
                    //get Document Group list from Dataservice
                    getDocumentGroups = function () {
                        dataservice.getDocumentGroups(
                        {
                            DocumentGroupFilterText: searchFilter(),
                            PageSize: pager().pageSize(),
                            PageNo: pager().currentPage(),
                            SortBy: sortOn(),
                            IsAsc: sortIsAsc()
                    },
                    {
                        success: function (data) {
                            documentGroups.removeAll();
                            pager().totalCount(data.TotalCount);
                            _.each(data.DocumentGroups, function (item) {
                                documentGroups.push(model.documentGroupServertoClinetMapper(item));
                            });
                        },
                        error: function() {
                            isLoadingFleetPools(false);
                            toastr.error(ist.resourceText.FailedToLoadDocumentGroupsError);
                        }
                    });
                    },
                    
                // Initialize the view model
                    initialize = function(specifiedView) {
                        view = specifiedView;
                        ko.applyBindings(view.viewModel, view.bindingRoot);
                        pager(pagination.Pagination({ PageSize: 10 }, documentGroups, getDocumentGroups));
                        getDocumentGroups();
                    };
                return {
                    documentGroups: documentGroups,
                    initialize: initialize,
                    search: search,
                    searchFilter: searchFilter,
                    sortOn: sortOn,
                    sortIsAsc: sortIsAsc,
                    onCreateForm: onCreateForm,
                    filterSectionVisilble: filterSectionVisilble,
                    isDocumentGroupEditorVisible: isDocumentGroupEditorVisible,
                    hideFilterSection: hideFilterSection,
                    showFilterSection: showFilterSection,
                    pager: pager,
                    resetResuults: resetResuults,
                    onDeleteItem: onDeleteItem,
                    onEditItem: onEditItem,
                    onCancelbtn: onCancelbtn,
                    selectedDocumentGroup: selectedDocumentGroup,
                    onSavebtn: onSavebtn,
                    getDocumentGroups: getDocumentGroups,
                };
            })()
        };
        return ist.DocumentGroup.viewModel;
    });
