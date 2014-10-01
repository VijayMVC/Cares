/*
    Module with the view model for the Document
*/
define("document/document.viewModel",
    ["jquery", "amplify", "ko", "document/document.dataservice", "document/document.model",
    "common/confirmation.viewModel", "common/pagination"],
    function($, amplify, ko, dataservice, model, confirmation, pagination) {
        var ist = window.ist || {};
        ist.Document = {
            viewModel: (function() { 
                var view,
                    //array to save Documents
                    documents = ko.observableArray([]),
                    //array to save basa data Document group list
                    baseDocumentGroupsList = ko.observableArray([]),
                    //pager%
                    pager = ko.observable(),
                    //org code filter in filter sec
                    searchFilter = ko.observable(),
                    baseDocumentGroupFilter = ko.observable(),
                    //sorting
                    sortOn = ko.observable(1),
                    //Assending  / Desending
                    sortIsAsc = ko.observable(true),
                    //to control the visibility of editor sec
                    isDocumentEditorVisible = ko.observable(false),
                    //to control the visibility of filter ec
                    filterSectionVisilble = ko.observable(false),
                     // Editor View Model
                    editorViewModel = new ist.ViewModel(model.DocumentDetail),
                    // Selected Document
                    selectedDocument = editorViewModel.itemForEditing,
                    //save button handler
                    onSavebtn = function() {
                    if (dobeforedocument())
                        savedocument(selectedDocument());
                },
                //Save Documents
                    savedocument = function(item) {
                        dataservice.saveDocument(item.convertToServerData(), {
                        success: function(dataFromServer) {
                            var newItem = model.DocumentServertoClinetMapper(dataFromServer);
                            if (item.id() !== undefined) {
                                var newObjtodelete = documents.find(function(temp) {
                                    return temp.id() == newItem.id();
                                });
                                documents.remove(newObjtodelete);
                                documents.push(newItem);
                            } else
                                documents.push(newItem);
                            isDocumentEditorVisible(false);
                            toastr.success(ist.resourceText.DocumentSuccessfullySavedMessage);
                        },
                        error: function(exceptionMessage, exceptionType) {
                            if (exceptionType === ist.exceptionType.CaresGeneralException)
                                toastr.error(exceptionMessage);
                            else
                                toastr.error(ist.resourceText.FailedToSaveDocumentError);
                        }
                    });
                },
                //validation check 
                    dobeforedocument = function() {
                    if (!selectedDocument().isValid()) {
                        selectedDocument().errors.showAllMessages();
                        return false;
                    }
                    return true;
                },
                //cancel button handler
                    onCancelbtn = function() {
                    editorViewModel.revertItem();
                    isDocumentEditorVisible(false);
                },
                // create new Document
                    onCreateForm = function () {
                    var document = new model.DocumentDetail();
                    editorViewModel.selectItem(document);
                    isDocumentEditorVisible(true);
                },
                //reset butto handle 
                    resetResuults = function() {
                    searchFilter(undefined);
                    baseDocumentGroupFilter(undefined);
                    getDocuments();
                },
                //delete button handler
                    onDeleteItem = function(item) {
                    if (!item.id()) {
                        documents.remove(item);
                        return;
                    }
                    // Ask for confirmation
                    confirmation.afterProceed(function() {
                        deleteDocument(item);
                    });
                    confirmation.show();
                },
                //edit button handler
                    onEditItem = function(item) {
                    editorViewModel.selectItem(item);
                    isDocumentEditorVisible(true);
                },
                //Delete Document
                    deleteDocument = function(document) {
                       dataservice.deleteDocument(document.convertToServerData(), {
                        success: function() {
                            documents.remove(document);
                            toastr.success(ist.resourceText.DocumentSuccessfullyDeletedMessage);
                        },
                        error: function(exceptionMessage, exceptionType) {
                            if (exceptionType === ist.exceptionType.CaresGeneralException)
                                toastr.error(exceptionMessage);
                            else
                                toastr.error(ist.resourceText.FailedToDeleteDocumentError);
                        }
                    });
                },
                //search button handler in filter section
                    search = function() {
                    pager().reset();
                    getDocuments();
                },
                //hide filte section
                    hideFilterSection = function() {
                    filterSectionVisilble(false);
                },
                //Show filter section
                    showFilterSection = function() {
                        filterSectionVisilble(true);
                    },
                    //Get Documents list from Dataservice
                    getDocuments = function() {
                        dataservice.getDocuments(
                        {
                            DocumentCodeNameText: searchFilter(),
                            DocumentGroypId: baseDocumentGroupFilter(),
                            PageSize: pager().pageSize(),
                            PageNo: pager().currentPage(),
                            SortBy: sortOn(),
                            IsAsc: sortIsAsc()
                    },
                    {
                        success: function (data) {
                            documents.removeAll();
                            pager().totalCount(data.TotalCount);
                            _.each(data.Documents, function (item) {
                                documents.push(model.DocumentServertoClinetMapper(item));
                            });
                        },
                        error: function() {
                            isLoadingFleetPools(false);
                            toastr.error(ist.resourceText.FailedToLoadDocumentsError);
                        }
                    });
                    },
                     //Get Document base data
                    getBaseData = function () {
                        dataservice.getDocumentBaseData(null, {
                            success: function (data) {
                                baseDocumentGroupsList.removeAll();
                                ko.utils.arrayPushAll(baseDocumentGroupsList(), data.DocumentGroupDropDown);
                                baseDocumentGroupsList.valueHasMutated();
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
                        pager(pagination.Pagination({ PageSize: 10 }, documents, getDocuments));
                        getBaseData();
                        getDocuments();
                    };
                return {
                    documents: documents,
                    initialize: initialize,
                    search: search,
                    searchFilter: searchFilter,
                    sortOn: sortOn,
                    sortIsAsc: sortIsAsc,
                    onCreateForm: onCreateForm,
                    filterSectionVisilble: filterSectionVisilble,
                    isDocumentEditorVisible: isDocumentEditorVisible,
                    hideFilterSection: hideFilterSection,
                    showFilterSection: showFilterSection,
                    pager: pager,
                    resetResuults: resetResuults,
                    onDeleteItem: onDeleteItem,
                    onEditItem: onEditItem,
                    onCancelbtn: onCancelbtn,
                    selectedDocument: selectedDocument,
                    onSavebtn: onSavebtn,
                    getDocuments: getDocuments,
                    getBaseData: getBaseData,
                    baseDocumentGroupsList: baseDocumentGroupsList,
                    baseDocumentGroupFilter: baseDocumentGroupFilter
                };
            })()
        };
        return ist.Document.viewModel;
    });
