/*
    Module with the view model for the Design.Grade
*/
define("designGrade/designGrade.viewModel",
    ["jquery", "amplify", "ko", "designGrade/designGrade.dataservice", "designGrade/designGrade.model",
    "common/confirmation.viewModel", "common/pagination"],
    function($, amplify, ko, dataservice, model, confirmation, pagination) {
        var ist = window.ist || {};
        ist.DesignGrade = {
            viewModel: (function() { 
                var view,
                    //array to save Design.Grades
                    designGrade = ko.observableArray([]),
                    //pager%
                    pager = ko.observable(),
                    //org code filter in filter sec
                    searchFilter = ko.observable(),

                    //sorting
                    sortOn = ko.observable(1),
                    //Assending  / Desending
                    sortIsAsc = ko.observable(true),
                    //to control the visibility of editor sec
                    isDesignGradeEditorVisible = ko.observable(false),
                    //to control the visibility of filter ec
                    filterSectionVisilble = ko.observable(false),


                     // Editor View Model
                    editorViewModel = new ist.ViewModel(model.DesignGrade),
                    // Selected Design.Grade
                    selectedDesignGrade = editorViewModel.itemForEditing,

                    //save button handler
                    onSavebtn = function() {
                    if (dobeforeDesignGrade())
                        saveDesignGrade(selectedDesignGrade());
                },
                //Save Design.Grade
                    saveDesignGrade = function(item) {
                        dataservice.saveDesignGrade(item.convertToServerData(), {
                        success: function(dataFromServer) {
                            var newItem = model.servertoClinetMapper(dataFromServer);
                            if (item.id() !== undefined) {
                                var newObjtodelete = designGrade.find(function(temp) {
                                    return temp.id() == newItem.id();
                                });
                                designGrade.remove(newObjtodelete);
                                designGrade.push(newItem);
                            } else
                                designGrade.push(newItem);
                            isDesignGradeEditorVisible(false);
                            toastr.success(ist.resourceText.DesignGradeSaveSuccessMessage);
                        },
                        error: function(exceptionMessage, exceptionType) {
                            if (exceptionType === ist.exceptionType.CaresGeneralException)
                                toastr.error(exceptionMessage);
                            else
                                toastr.error(ist.resourceText.DesignGradeSaveFailError);
                        }
                    });
                },
                //validation check 
                    dobeforeDesignGrade = function() {
                    if (!selectedDesignGrade().isValid()) {
                        selectedDesignGrade().errors.showAllMessages();
                        return false;
                    }
                    return true;
                },
                //cancel button handler
                    onCancelbtn = function() {
                    editorViewModel.revertItem();
                    isDesignGradeEditorVisible(false);
                },
                // create new Region
                    onCreateForm = function () {
                   var dGrade = new model.DesignGrade();
                   editorViewModel.selectItem(dGrade);
                    isDesignGradeEditorVisible(true);
                },
                //reset butto handle 
                    resetResuults = function() {
                    searchFilter(undefined);
                    getDesignGrades();
                },
                //delete button handler
                    onDeleteItem = function(item) {
                    if (!item.id()) {
                        designGrade.remove(item);
                        return;
                    }
                    // Ask for confirmation
                    confirmation.afterProceed(function() {
                        deleteDesignGrade(item);
                    });
                    confirmation.show();
                },
                //edit button handler
                    onEditItem = function(item) {
                    editorViewModel.selectItem(item);
                    isDesignGradeEditorVisible(true);
                },
                //delete Design.Grade
                    deleteDesignGrade = function (region) {
                        dataservice.deleteDesignGrade(region.convertToServerData(), {
                        success: function() {
                            designGrade.remove(region);
                            toastr.success(ist.resourceText.DesignGradeDeleteSuccessMessage);
                        },
                        error: function(exceptionMessage, exceptionType) {
                            if (exceptionType === ist.exceptionType.CaresGeneralException)
                                toastr.error(exceptionMessage);
                            else
                                toastr.error(ist.resourceText.DesignGradeDeleteFailError);
                        }
                    });
                },
                //search button handler in filter section
                    search = function() {
                    pager().reset();
                    getDesignGrades();
                },
                //hide filte section
                    hideFilterSection = function() {
                    filterSectionVisilble(false);
                },
                //Show filter section
                    showFilterSection = function() {
                    filterSectionVisilble(true);
                },
                //get Design.Grades list from Dataservice
                getDesignGrades = function() {
                    dataservice.getDesignGrades(
                    {
                        DesigGradeFilterText: searchFilter(),
                        PageSize: pager().pageSize(),
                        PageNo: pager().currentPage(),
                        SortBy: sortOn(),
                        IsAsc: sortIsAsc()
                    },
                    {
                        success: function(data) {
                            designGrade.removeAll();
                            pager().totalCount(data.TotalCount);
                            _.each(data.DesignGrades, function(item) {
                                designGrade.push(model.servertoClinetMapper(item));
                            });
                        },
                        error: function() {
                            isLoadingFleetPools(false);
                            toastr.error(ist.resourceText.DesignGradeLoadFailError);
                        }
                    });
                },
                // Initialize the view model
                    initialize = function(specifiedView) {
                        view = specifiedView;
                        ko.applyBindings(view.viewModel, view.bindingRoot);
                        pager(pagination.Pagination({ PageSize: 10 }, designGrade, getDesignGrades));
                        getDesignGrades();
                    };
                return {
                    designGrade: designGrade,
                    initialize: initialize,
                    search: search,
                    searchFilter: searchFilter,
                    sortOn: sortOn,
                    sortIsAsc: sortIsAsc,
                    onCreateForm: onCreateForm,
                    filterSectionVisilble: filterSectionVisilble,
                    isDesignGradeEditorVisible: isDesignGradeEditorVisible,
                    hideFilterSection: hideFilterSection,
                    showFilterSection: showFilterSection,
                    pager: pager,
                    resetResuults: resetResuults,
                    onDeleteItem: onDeleteItem,
                    onEditItem: onEditItem,
                    onCancelbtn: onCancelbtn,
                    selectedDesignGrade: selectedDesignGrade,
                    onSavebtn: onSavebtn,
                    getDesignGrades: getDesignGrades,
                };
            })()
        };
        return ist.DesignGrade.viewModel;
    });
