/*
    Module with the view model for the Employee Status
*/
define("empStatus/empStatus.viewModel",
    ["jquery", "amplify", "ko", "empStatus/empStatus.dataservice", "empStatus/empStatus.model",
    "common/confirmation.viewModel", "common/pagination"],
    function($, amplify, ko, dataservice, model, confirmation, pagination) {
        var ist = window.ist || {};
        ist.EmployeeStatus = {
            viewModel: (function() { 
                var view,
                    //array to save Employee Statuses
                    employeeStatuses = ko.observableArray([]),

                    //pager%
                    pager = ko.observable(),
                    //org code filter in filter sec
                    searchFilter = ko.observable(),

                    //sorting
                    sortOn = ko.observable(1),
                    //Assending  / Desending
                    sortIsAsc = ko.observable(true),
                    //to control the visibility of editor sec
                    isEmployeeStatusesEditorVisible = ko.observable(false),
                    //to control the visibility of filter ec
                    filterSectionVisilble = ko.observable(false),


                     // Editor View Model
                    editorViewModel = new ist.ViewModel(model.EmployeeStatusDetail),
                    // Selected Employee Status
                    selectedEmployeeStatus = editorViewModel.itemForEditing,

                    //save button handler
                    onSavebtn = function() {
                    if (dobeforeEmployeeStatus())
                        saveEmployeeStatus(selectedEmployeeStatus());
                },
                //Save Employee Status
                    saveEmployeeStatus = function (item) {
                        dataservice.saveEmpStatus(item.convertToServerData(), {
                        success: function(dataFromServer) {
                            var newItem = model.empStatusServertoClinetMapper(dataFromServer);
                            if (item.id() !== undefined) {
                                var newObjtodelete = employeeStatuses.find(function(temp) {
                                    return temp.id() == newItem.id();
                                });
                                employeeStatuses.remove(newObjtodelete);
                                employeeStatuses.push(newItem);
                            } else
                                employeeStatuses.push(newItem);
                            isEmployeeStatusesEditorVisible(false);
                            toastr.success(ist.resourceText.EmployeeStatusSaveSuccessMessage);
                        },
                        error: function(exceptionMessage, exceptionType) {
                            if (exceptionType === ist.exceptionType.CaresGeneralException)
                                toastr.error(exceptionMessage);
                            else
                                toastr.error(ist.resourceText.EmployeeStatusSaveFailError);
                        }
                    });
                },
                //validation check 
                    dobeforeEmployeeStatus = function() {
                    if (!selectedEmployeeStatus().isValid()) {
                        selectedEmployeeStatus().errors.showAllMessages();
                        return false;
                    }
                    return true;
                },
                //cancel button handler
                    onCancelbtn = function() {
                    editorViewModel.revertItem();
                    isEmployeeStatusesEditorVisible(false);
                },
                // create new Employee Status
                    onCreateForm = function () {
                    editorViewModel.selectItem(new model.CreateEmployeeStatusDetail(false));
                    isEmployeeStatusesEditorVisible(true);
                },
                //reset butto handle 
                    resetResuults = function() {
                    searchFilter(undefined);
                    getEmployeeStatuses();
                },
                //delete button handler
                    onDeleteItem = function(item) {
                    if (!item.id()) {
                        employeeStatuses.remove(item);
                        return;
                    }
                    // Ask for confirmation
                    confirmation.afterProceed(function() {
                        deleteEmployeeStatuses(item);
                    });
                    confirmation.show();
                },
                //edit button handler
                    onEditItem = function(item) {
                    editorViewModel.selectItem(item);
                    isEmployeeStatusesEditorVisible(true);
                },
                //delete Employee Status
                    deleteEmployeeStatuses = function (region) {
                        dataservice.deleteEmpStatus(region.convertToServerData(), {
                        success: function() {
                            employeeStatuses.remove(region);
                            toastr.success(ist.resourceText.EmployeeStatusDeleteSuccessMessage);
                        },
                        error: function(exceptionMessage, exceptionType) {
                            if (exceptionType === ist.exceptionType.CaresGeneralException)
                                toastr.error(exceptionMessage);
                            else
                                toastr.error(ist.resourceText.EmployeeStatusDeleteFailError);
                        }
                    });
                },
                //search button handler in filter section
                    search = function() {
                    pager().reset();
                    getEmployeeStatuses();
                },
                //hide filte section
                    hideFilterSection = function() {
                    filterSectionVisilble(false);
                },
                //Show filter section
                    showFilterSection = function() {
                        filterSectionVisilble(true);
                    },
                    //get Employee Status list from Dataservice
                    getEmployeeStatuses = function() {
                    dataservice.getEmpStatus(
                    {
                        EmpFilterText: searchFilter(),
                        PageSize: pager().pageSize(),
                        PageNo: pager().currentPage(),
                        SortBy: sortOn(),
                        IsAsc: sortIsAsc()
                    },
                    {
                        success: function(data) {
                            debugger;
                            employeeStatuses.removeAll();
                            pager().totalCount(data.TotalCount);
                            _.each(data.EmployeeStatuses, function(item) {
                                employeeStatuses.push(model.empStatusServertoClinetMapper(item));
                            });
                        },
                        error: function() {
                            isLoadingFleetPools(false);
                            toastr.error(ist.resourceText.EmployeeStatusLoadFailError);
                        }
                    });
                },

                // Initialize the view model
                    initialize = function(specifiedView) {
                        view = specifiedView;
                        ko.applyBindings(view.viewModel, view.bindingRoot);
                        pager(pagination.Pagination({ PageSize: 10 }, employeeStatuses, getEmployeeStatuses));
                        getEmployeeStatuses();
                    };
                return {
                    employeeStatuses: employeeStatuses,
                    initialize: initialize,
                    search: search,
                    searchFilter: searchFilter,
                    sortOn: sortOn,
                    sortIsAsc: sortIsAsc,
                    onCreateForm: onCreateForm,
                    filterSectionVisilble: filterSectionVisilble,
                    isEmployeeStatusesEditorVisible: isEmployeeStatusesEditorVisible,
                    hideFilterSection: hideFilterSection,
                    showFilterSection: showFilterSection,
                    pager: pager,
                    resetResuults: resetResuults,
                    onDeleteItem: onDeleteItem,
                    onEditItem: onEditItem,
                    onCancelbtn: onCancelbtn,
                    selectedEmployeeStatus: selectedEmployeeStatus,
                    onSavebtn: onSavebtn,
                    getEmployeeStatuses: getEmployeeStatuses,
                };
            })()
        };
        return ist.EmployeeStatus.viewModel;
    });
