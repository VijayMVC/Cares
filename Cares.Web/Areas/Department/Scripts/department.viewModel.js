/*
    Module with the view model for the Operation
*/
define("department/department.viewModel",
    ["jquery", "amplify", "ko", "department/department.dataservice", "department/department.model",
    "common/confirmation.viewModel", "common/pagination"],
    function($, amplify, ko, dataservice, model, confirmation, pagination) {
        var ist = window.ist || {};
        ist.Department = {
            viewModel: (function() { 
                var view,
                    operations = ko.observableArray([]),

                    baseDepartmentsList = ko.observableArray([]),
                    baseCompniesList = ko.observableArray([]),
                    baseDepartmentTypesList = ko.observableArray(["Sales","Support"]),

                    opperationCodeTextFilter = ko.observable(),
                    opperationNameTextFilter = ko.observable(),
                    companyFilter = ko.observable(),
                    departmentTypeFilter = ko.observable(),

                    //pager
                    pager = ko.observable(),
                    //sorting
                    sortOn = ko.observable(1),
                    //Assending  / Desending
                    sortIsAsc = ko.observable(true),
                    //to control the visibility of editor sec
                    isOperationEditorVisible = ko.observable(false),
                    //to control the visibility of filter ec
                    filterSectionVisilble = ko.observable(false),
                    //selected org group 
                    selectedOperation = ko.observable(),
                    //save button handler
                    onSaveOperation = function () {
                        if (dobeforeOperation())
                        saveOperation(selectedOperation());
                    },
                    //cancel button handler
                    onCancelSaveOperation = function () {
                        isOperationEditorVisible(false);
                    },
                    // create new org group handler
                    onCreateOperationForm = function () {
                        var operation = model.department();
                        selectedOperation(operation);
                        isOperationEditorVisible(true);
                    },
                    //reset butto handle 
                    onResetResuults = function () {
                        opperationCodeTextFilter(undefined);
                        opperationNameTextFilter(undefined);
                        departmentTypeFilter(undefined);
                        companyFilter(undefined);
                        getOperations();

                    },
                    //delete button handler
                    onDeleteOperation = function (item) {
                        if (!item.id()) {
                            fleetPools.remove(item);
                            return;
                        }
                        // Ask for confirmation
                        confirmation.afterProceed(function () {
                            deleteOperation(item);
                        });
                        confirmation.show();
                    },
                   
                    //edit button handler
                    onEditOperation = function (item) {
                        selectedOperation(item);
                        isOperationEditorVisible(true);
                    },
                     //validation check 
                    dobeforeOperation = function () {
                        if (!selectedOperation().isValid()) {
                            selectedOperation().errors.showAllMessages();
                            return false;
                        }
                        return true;
                    },
                    saveOperation = function (operation) {
                        dataservice.saveDepartment(operation.convertToServerData(), {
                            success: function (uodatedOperation) {
                                debugger;
                                var newItem = model.DepartmentServertoClientMapper(uodatedOperation);
                                if (selectedOperation().id() != undefined)
                                    operations.replace(selectedOperation(), newItem);
                                else
                                    operations.push(newItem);
                                isOperationEditorVisible(false);
                                toastr.success("Operation saved successfully");
                            },
                            error: function () {
                                toastr.error("Failed to save operation!");
                            }
                        });
                    },
                    //delete org group
                    deleteOperation = function (operation) {
                        dataservice.deleteDepartment(operation.convertToServerData(), {
                                success: function() {
                                    operations.remove(operation);
                                    toastr.success("Department removed successfully");
                                },
                                error: function() {
                                    toastr.error("Failed to remove Department!");
                                }
                            });
                    },
                    //search button handler in filter section
                    onSearch = function() {
                        getOperations();
                    },
                    //hide filte section
                    hideFilterSection = function() {
                        filterSectionVisilble(false);
                    },
                    //Show filter section
                    showFilterSection = function() {
                        filterSectionVisilble(true);
                            
                       },
                    //get org group list from Dataservice
                    getOperations = function() {
                        dataservice.getDepartments(
                        {
                            DepartmentCodeText: opperationCodeTextFilter(),
                            DepartmentNameText: opperationNameTextFilter(),
                            DepartmentTypeText: departmentTypeFilter(),
                            CompanyId: companyFilter(),
                            PageSize: pager().pageSize(),
                            PageNo: pager().currentPage(),
                            SortBy: sortOn(),
                            IsAsc: sortIsAsc()
                        },
                        {
                            success: function (data) {
                                debugger;
                                operations.removeAll();
                                pager().totalCount(data.TotalCount);
                                _.each(data.Departments, function (item) {
                                var obj=    model.DepartmentServertoClientMapper(item);
                                operations.push(obj);

                                });
                            },
                            error: function() {
                                isLoadingFleetPools(false);
                                toastr.error("Failed to load fleetPools!");
                            }
                        });
                    },
                    getOperationBaseData = function () {
                        dataservice.getDepartmentBaseData(null, {
                            success: function (baseDataFromServer) {
                                baseCompniesList.removeAll();
                                ko.utils.arrayPushAll(baseCompniesList(), baseDataFromServer.Companies);
                                baseCompniesList.valueHasMutated();
                            },
                            error: function (exceptionMessage, exceptionType) {
                                if (exceptionType === ist.exceptionType.CaresGeneralException) {
                                    toastr.error(exceptionMessage);
                                } else {
                                    toastr.error("Failed to load base data.");
                                }
                            }
                        });
                    },
                    // Initialize the view model
                    initialize = function (specifiedView) {
                        view = specifiedView;
                        ko.applyBindings(view.viewModel, view.bindingRoot);
                        pager(pagination.Pagination({ PageSize: 5}, operations, getOperations));
                         getOperationBaseData();
                        getOperations();
                       
                    };
                return {
                    opperationCodeTextFilter: opperationCodeTextFilter,
                    opperationNameTextFilter: opperationNameTextFilter,
                    departmentTypeFilter:departmentTypeFilter,
                    companyFilter: companyFilter,

                    baseDepartmentTypesList:baseDepartmentTypesList,
                    baseCompniesList:baseCompniesList,
                    baseDepartmentsList:baseDepartmentsList,
                    isOperationEditorVisible:isOperationEditorVisible,
                    initialize: initialize,
                    onCreateOperationForm:onCreateOperationForm,
                    sortOn: sortOn,
                    getOperations:getOperations,
                    sortIsAsc: sortIsAsc,
                    filterSectionVisilble: filterSectionVisilble,
                    hideFilterSection: hideFilterSection,
                    showFilterSection: showFilterSection,
                    pager: pager,
                    selectedOperation:selectedOperation,
                    onResetResuults: onResetResuults,
                    onEditOperation:onEditOperation,
                    onDeleteOperation:onDeleteOperation,
                    onSaveOperation: onSaveOperation,
                    onSearch: onSearch,
                    operations:operations,
                    onCancelSaveOperation: onCancelSaveOperation

                };
            })()
        };
        return ist.Department.viewModel;
    });
