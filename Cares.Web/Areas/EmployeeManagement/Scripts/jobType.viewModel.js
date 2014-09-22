/*
    Module with the view model for the Job Type
*/
define("jobType/jobType.viewModel",
    ["jquery", "amplify", "ko", "jobType/jobType.dataservice", "jobType/jobType.model",
    "common/confirmation.viewModel", "common/pagination"],
    function($, amplify, ko, dataservice, model, confirmation, pagination) {
        var ist = window.ist || {};
        ist.JobType = {
            viewModel: (function() { 
                var view,
                    //array to save Job Types
                    jobTypes = ko.observableArray([]),
                    //pager%
                    pager = ko.observable(),
                    //org code filter in filter sec
                    searchFilter = ko.observable(),
                    //sorting
                    sortOn = ko.observable(1),
                    //Assending  / Desending
                    sortIsAsc = ko.observable(true),
                    //to control the visibility of editor sec
                    isCityEditorVisible = ko.observable(false),
                    //to control the visibility of filter ec
                    filterSectionVisilble = ko.observable(false),
                     // Editor View Model
                    editorViewModel = new ist.ViewModel(model.JobTypeDetail),
                    // Selected Job Type
                    selectedJobType = editorViewModel.itemForEditing,
                    //save button handler
                    onSavebtn = function() {
                        if (dobeforeJobType())
                            savejobType(selectedJobType());
                },
                //Save Job Type
                    savejobType = function (item) {
                        dataservice.saveJobType(item.convertToServerData(), {
                        success: function(dataFromServer) {
                            var newItem = model.jobTypeServertoClinetMapper(dataFromServer);
                            if (item.id() !== undefined) {
                                var newObjtodelete = jobTypes.find(function(temp) {
                                    return temp.id() == newItem.id();
                                });
                                jobTypes.remove(newObjtodelete);
                                jobTypes.push(newItem);
                            } else
                                jobTypes.push(newItem);
                            isCityEditorVisible(false);
                            toastr.success(ist.resourceText.JobTypeSuccessfullySavedMessage);
                        },
                        error: function(exceptionMessage, exceptionType) {
                            if (exceptionType === ist.exceptionType.CaresGeneralException)
                                toastr.error(exceptionMessage);
                            else
                                toastr.error(ist.resourceText.JobTypeFailedToSaveError);
                        }
                    });
                },
                //validation check 
                    dobeforeJobType = function () {
                    if (!selectedJobType().isValid()) {
                        selectedJobType().errors.showAllMessages();
                        return false;
                    }
                    return true;
                },
                //cancel button handler
                    onCancelbtn = function() {
                    editorViewModel.revertItem();
                    isCityEditorVisible(false);
                },
                // create new Job Type
                    onCreateForm = function() {
                    var jobtype = new model.JobTypeDetail();
                    editorViewModel.selectItem(jobtype);
                    isCityEditorVisible(true);
                },
                //reset butto handle 
                    resetResuults = function() {
                    searchFilter(undefined);
                    getCities();
                },
                //delete button handler
                    onDeleteItem = function(item) {
                    if (!item.id()) {
                        jobTypes.remove(item);
                        return;
                    }
                    // Ask for confirmation
                    confirmation.afterProceed(function() {
                        deleteJobType(item);
                    });
                    confirmation.show();
                },
                //edit button handler
                    onEditItem = function (item) {
                    editorViewModel.selectItem(item);
                    isCityEditorVisible(true);
                    },
                //delete Job Type
                    deleteJobType = function(region) {
                        dataservice.deleteJobType(region.convertToServerData(), {
                        success: function() {
                            jobTypes.remove(region);
                            toastr.success(ist.resourceText.JobTypeSuccessfullyDeletedMessage);
                        },
                        error: function(exceptionMessage, exceptionType) {
                            if (exceptionType === ist.exceptionType.CaresGeneralException)
                                toastr.error(exceptionMessage);
                            else
                                toastr.error(ist.resourceText.JobTypeFailedToDeleteError);
                        }
                    });
                },
                //search button handler in filter section
                    search = function() {
                    pager().reset();
                    getJobTypes();
                },
                //hide filte section
                    hideFilterSection = function() {
                    filterSectionVisilble(false);
                },
                //Show filter section
                    showFilterSection = function() {
                        filterSectionVisilble(true);
                    },
                    //Get Job Types list from Dataservice
                    getJobTypes = function() {
                    dataservice.getJobTypes(
                    {
                        JobTypeFilterText: searchFilter(),
                        PageSize: pager().pageSize(),
                        PageNo: pager().currentPage(),
                        SortBy: sortOn(),
                        IsAsc: sortIsAsc()
                    },
                    {
                        success: function(data) {
                            jobTypes.removeAll();
                            pager().totalCount(data.TotalCount);
                            _.each(data.JobTypes, function(item) {
                                jobTypes.push(model.jobTypeServertoClinetMapper(item));
                            });
                        },
                        error: function() {
                            isLoadingFleetPools(false);
                            toastr.error(ist.resourceText.JobTypeFailedToLoadError);
                        }
                    });
                },
                // Initialize the view model
                    initialize = function(specifiedView) {
                        view = specifiedView;
                        ko.applyBindings(view.viewModel, view.bindingRoot);
                        pager(pagination.Pagination({ PageSize: 5 }, jobTypes, getJobTypes));
                        getJobTypes();
                    };
                return {
                    jobTypes: jobTypes,
                    initialize: initialize,
                    search: search,
                    searchFilter: searchFilter,
                    sortOn: sortOn,
                    sortIsAsc: sortIsAsc,
                    onCreateForm: onCreateForm,
                    filterSectionVisilble: filterSectionVisilble,
                    isCityEditorVisible: isCityEditorVisible,
                    hideFilterSection: hideFilterSection,
                    showFilterSection: showFilterSection,
                    pager: pager,
                    resetResuults: resetResuults,
                    onDeleteItem: onDeleteItem,
                    onEditItem: onEditItem,
                    onCancelbtn: onCancelbtn,
                    selectedJobType: selectedJobType,
                    onSavebtn: onSavebtn,
                    getJobTypes: getJobTypes,
                };
            })()
        };
        return ist.JobType.viewModel;
    });
