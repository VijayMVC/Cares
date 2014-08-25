/*
    Module with the view model for the department
*/
define("department/department.viewModel",
    ["jquery", "amplify", "ko", "department/department.dataservice", "department/department.model",
    "common/confirmation.viewModel", "common/pagination"],
    function($, amplify, ko, dataservice, model, confirmation, pagination) {
        var ist = window.ist || {};
        ist.Department = {
            viewModel: (function() { 
                var view,
                    // depatment Array
                    departments = ko.observableArray([]),
                    // base CompniesList
                    baseCompniesList = ko.observableArray([]),
                    // pre-defined Department Types List
                    baseDepartmentTypesList = ko.observableArray(["Sales","Support"]),
                    // Filters
                    departmentCodeTextFilter = ko.observable(),
                    departmentNameTextFilter = ko.observable(),
                    companyFilter = ko.observable(),
                    departmentTypeFilter = ko.observable(),
                    //pager
                    pager = ko.observable(),
                    //sorting
                    sortOn = ko.observable(1),
                    //Assending  / Desending
                    sortIsAsc = ko.observable(true),
                    //to control the visibility of editor sec
                    isDepartmentEditorVisible = ko.observable(false),
                    //to control the visibility of filter sec
                    filterSectionVisilble = ko.observable(false),

                      // Editor View Model
                    editorViewModel = new ist.ViewModel(model.department),
                    //selected Department
                    selectedDepartment = editorViewModel.itemForEditing,

                    //save button handler
                    onSaveDepartment = function () {
                        if (dobeforeDepartment())
                            saveDepartment(selectedDepartment());
                    },
                    //cancel button handler
                    onCancelDepartment = function () {
                        editorViewModel.revertItem();
                        isDepartmentEditorVisible(false);
                    },
                    // create new org group handler
                    onCreateDepartment = function () {
                        var company = new model.department();
                        editorViewModel.selectItem(company);
                        isDepartmentEditorVisible(true);
                    },
                    //reset butto handle 
                    onResetResuults = function () {
                        departmentCodeTextFilter(undefined);
                        departmentNameTextFilter(undefined);
                        departmentTypeFilter(undefined);
                        companyFilter(undefined);
                        getDepartments();
                    },
                    //delete button handler
                    onDeleteDepartment = function (item) {
                        if (!item.id()) {
                            departments.remove(item);
                            return;
                        }
                        // Ask for confirmation
                        confirmation.afterProceed(function () {
                            deleteDepartment(item);
                        });
                        confirmation.show();
                    },
                    //edit button handler
                    onEditDepartment = function (item) {
                        editorViewModel.selectItem(item);
                        isDepartmentEditorVisible(true);
                    },
                     //validation check 
                    dobeforeDepartment = function () {
                        if (!selectedDepartment().isValid()) {
                            selectedDepartment().errors.showAllMessages();
                            return false;
                        }
                        return true;
                    },
                    saveDepartment = function (department) {
                        dataservice.saveDepartment(department.convertToServerData(), {
                            success: function (uodateddepartment) {
                                debugger;
                                var newItem = model.DepartmentServertoClientMapper(uodateddepartment);
                                if (selectedDepartment().id() != undefined) {

                                    var newObjtodelete = departments.find(function (temp) {
                                        return temp.id() == newItem.id();
                                    });
                                    departments.remove(newObjtodelete);
                                    departments.push(newItem);
                                }
                                else
                                    departments.push(newItem);
                                isDepartmentEditorVisible(false);
                                toastr.success("Department saved successfully");
                            },
                            error: function (exceptionMessage, exceptionType) {
                                if (exceptionType === ist.exceptionType.CaresGeneralException)
                                    toastr.error(exceptionMessage);
                                else
                                    toastr.error("Failed to save Department");
                            }
                        });
                    },
                    deleteDepartment = function (department) {
                        dataservice.deleteDepartment(department.convertToServerData(), {
                                success: function() {
                                    departments.remove(department);
                                    toastr.success("Department removed successfully");
                                },
                                error: function() {
                                    toastr.error("Failed to remove Department!");
                                }
                            });
                    },
                    //search button handler in filter section
                    onSearch = function() {
                        getDepartments();
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
                    getDepartments = function() {
                        dataservice.getDepartments(
                        {
                            DepartmentCodeText: departmentCodeTextFilter(),
                            DepartmentNameText: departmentNameTextFilter(),
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
                                departments.removeAll();
                                pager().totalCount(data.TotalCount);
                                _.each(data.Departments, function (item) {
                                var obj=    model.DepartmentServertoClientMapper(item);
                                departments.push(obj);

                                });
                            },
                            error: function() {
                                isLoadingFleetPools(false);
                                toastr.error("Failed to load fleetPools!");
                            }
                        });
                    },
                    getDepartmentBaseData = function () {
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
                        pager(pagination.Pagination({ PageSize: 5}, departments, getDepartments));
                        getDepartmentBaseData();
                        getDepartments();
                       
                    };
                return {
                    departmentCodeTextFilter: departmentCodeTextFilter,
                    departmentNameTextFilter: departmentNameTextFilter,
                    departmentTypeFilter:departmentTypeFilter,
                    companyFilter: companyFilter,
                    baseDepartmentTypesList:baseDepartmentTypesList,
                    baseCompniesList:baseCompniesList,
                    isDepartmentEditorVisible: isDepartmentEditorVisible,
                    initialize: initialize,
                    onCreateDepartment: onCreateDepartment,
                    sortOn: sortOn,
                    getDepartments: getDepartments,
                    sortIsAsc: sortIsAsc,
                    filterSectionVisilble: filterSectionVisilble,
                    hideFilterSection: hideFilterSection,
                    showFilterSection: showFilterSection,
                    pager: pager,
                    selectedDepartment: selectedDepartment,
                    onResetResuults: onResetResuults,
                    onEditDepartment: onEditDepartment,
                    onDeleteDepartment: onDeleteDepartment,
                    onSaveDepartment: onSaveDepartment,
                    onSearch: onSearch,
                    departments: departments,
                    onCancelDepartment: onCancelDepartment

                };
            })()
        };
        return ist.Department.viewModel;
    });
