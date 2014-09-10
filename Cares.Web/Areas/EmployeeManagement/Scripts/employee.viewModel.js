/*
    Module with the view model for the Employee
*/
define("employee/employee.viewModel",
    ["jquery", "amplify", "ko", "employee/employee.dataservice", "employee/employee.model", "common/confirmation.viewModel", "common/pagination"],
    function ($, amplify, ko, dataservice, model, confirmation, pagination) {
        var ist = window.ist || {};
        ist.employee = {
            viewModel: (function () {
                var // the view 
                    view,
                     // Active Employee
                   selectedEmployee = ko.observable(),
                    //Active Employee 
                    selectedEmployeeId = ko.observable(),
                    //Add/Edit Employee Item
                     addEmployeeItem = ko.observable(),
                    // Show Filter Section
                    filterSectionVisilble = ko.observable(false),
                    // #region Arrays
                      //Employees
                    employees = ko.observableArray([]),
                    //Employee Statuses
                    employeeStatuses = ko.observableArray([]),
                     //Companies
                    companies = ko.observableArray([]),
                    //Gender
                    gender = ko.observableArray([]),
                    //Nationalitiies
                    nationalities = ko.observableArray([]),
                    //Job Types
                    jobTypes = ko.observableArray([]),
                    //Designations
                    designations = ko.observableArray([]),
                    //Designation Grades
                    designationGrades = ko.observableArray([]),
                     //Departments
                    departments = ko.observableArray([]),
                    //Work Places
                    workPlaces = ko.observableArray([]),
                    //Supervisiors
                    supervisiors = ko.observableArray([]),
                    //Countries
                    countries = ko.observableArray([]),
                      //Regions
                    regions = ko.observableArray([]),
                    //Sub Regions
                    subRegions = ko.observableArray([]),
                    //Cities
                    cites = ko.observableArray([]),
                    //Areas
                    areas = ko.observableArray([]),
                    //Phone Types
                    phoneTypes = ko.observableArray([]),
                    //Passport Countries
                    passportCountries = ko.observableArray([]),
                    //Visa Issue Countries
                    visaIssueCountries = ko.observableArray([]),
                    //License Types
                    licenseTypes = ko.observableArray([]),
                    //Operations
                    operations = ko.observableArray([]),
                    //operation Wor kPlaces
                    operationWorkPlaces = ko.observableArray([]),

                    // #endregion Arrays

                    // #region Busy Indicators
                    isLoadingEmployees = ko.observable(false),
                    // #endregion Busy Indicators
                    // #region Observables
                    // Sort On
                    sortOn = ko.observable(1),
                    // Sort Order -  true means asc, false means desc
                    sortIsAsc = ko.observable(true),
                    // Sort On Employee
                    sortOnHg = ko.observable(1),
                    // Sort Order -  true means asc, false means desc
                    sortIsAscHg = ko.observable(true),
                    // Is Employee Editor Visible
                    isEmployeeEditorVisible = ko.observable(false),
                    // Pagination
                    pager = ko.observable(),
                     //Search filter
                    searchFilter = ko.observable(),
                    //Employee Status Filter
                    employeeStatusFilter = ko.observable(),
                       //Company Filter
                    companyFilter = ko.observable(),
                    // #region Utility Functions
                    // Initialize the view model
                    initialize = function (specifiedView) {
                        view = specifiedView;
                        ko.applyBindings(view.viewModel, view.bindingRoot);
                        //getBaseData();
                        // Set Pager
                        //pager(new pagination.Pagination({}, employees, getEmployees));
                        // getEmployees();

                    },
                     // Collapase filter section
                    collapseFilterSection = function () {
                        filterSectionVisilble(false);
                    },
                    //Show filter section
                    showFilterSection = function () {
                        filterSectionVisilble(true);
                    },
                    //close Employee Editor
                    closeEmployeeEditor = function () {
                        isEmployeeEditorVisible(false);
                    },
                    //Show Employee Editor
                    showEmployeeEditor = function () {
                        isEmployeeEditorVisible(true);
                    },
                     //Create Employee Rate
                    createEmployee = function () {
                        //var employee = new model.EmployeeDetail.Create();
                        //checkListItemList.removeAll();
                        //maintenanceScheduleList.removeAll();
                        ////Select the newly added Employee
                        //addEmployeeItem(employee);
                        showEmployeeEditor();
                    },
                      //Edit Employee
                    onEditEmployee = function (employee, e) {
                        //checkListItemList.removeAll();
                        //maintenanceScheduleList.removeAll();
                        //selectedEmployee(employee);
                        //getEmployeeById(employee);
                        showEmployeeEditor();
                        e.stopImmediatePropagation();
                    },
                      //Get Employee data By Id
                    getEmployeeById = function (employee) {
                        isLoadingEmployees(true);
                        dataservice.getEmployeeDetailById(model.EmployeeDetailServerMappeForDelete(employee), {
                            success: function (data) {
                                var employeeDetail = model.EmployeeDetailClientMapper(data);
                                addEmployeeItem(employeeDetail);
                                _.each(data.EmployeeCheckListItems, function (item) {
                                    var checkListItem = model.CheckListItemClientMapper(item);
                                    checkListItemList.push(checkListItem);
                                });
                                _.each(data.EmployeeMaintenanceTypeFrequency, function (item) {
                                    var maintenanceScheduleItem = model.MaintenanceScheduleClientMapper(item);
                                    maintenanceScheduleList.push(maintenanceScheduleItem);
                                });
                                isLoadingEmployees(false);
                            },
                            error: function () {
                                isLoadingEmployees(false);
                                toastr.error(ist.resourceText.employeeDetailFailedMsg);
                            }
                        });
                    },
                    // Delete a Employee
                    onDeleteEmployee = function (employee) {
                        //if (!employee.employeeId()) {
                        //    employees.remove(employee);
                        //    return;
                        //}
                        //// Ask for confirmation
                        //confirmation.afterProceed(function () {
                        //    deleteEmployee(employee);
                        //});
                        //confirmation.show();
                    },
                    // Delete Employee
                    deleteEmployee = function (employee) {
                        dataservice.deleteEmployee(model.EmployeeDetailServerMappeForDelete(employee), {
                            success: function () {
                                employees.remove(employee);
                                toastr.success(ist.resourceText.employeeDeleteSuccessMsg);
                            },
                            error: function () {
                                toastr.error(ist.resourceText.employeeDeleteErrorMsg);
                            }
                        });
                    },
                   // Save Employee
                    onSaveEmployee = function (employee) {
                        if (doBeforeSave()) {
                            //if (employee.maintenanceScheduleListInEmployee().length !== 0) {
                            //    employee.maintenanceScheduleListInEmployee.removeAll();
                            //}
                            //if (employee.checkListItemListInEmployee().length !== 0) {
                            //    employee.checkListItemListInEmployee.removeAll();
                            //}
                            //ko.utils.arrayPushAll(employee.maintenanceScheduleListInEmployee(), maintenanceScheduleList());
                            //ko.utils.arrayPushAll(employee.checkListItemListInEmployee(), checkListItemList());
                            //saveEmployee(employee);
                        }
                    },
                    // Do Before Logic
                    doBeforeSave = function () {
                        var flag = true;
                        //if (!addEmployeeItem().isValid() || !addEmployeeItem().otherEmployeeDetail().isValid() || !addEmployeeItem().employeePurchaseInfo().isValid() ||
                        //!addEmployeeItem().employeeLeasedInfo().isValid() || !addEmployeeItem().employeeInsuranceInfo().isValid() ||
                        //!addEmployeeItem().employeeDepreciation().isValid() || !addEmployeeItem().employeeDisposalInfo().isValid()) {
                        //    addEmployeeItem().errors.showAllMessages();
                        //    addEmployeeItem().otherEmployeeDetail().errors.showAllMessages();
                        //    addEmployeeItem().employeePurchaseInfo().errors.showAllMessages();
                        //    addEmployeeItem().employeeLeasedInfo().errors.showAllMessages();
                        //    addEmployeeItem().employeeInsuranceInfo().errors.showAllMessages();
                        //    addEmployeeItem().employeeDepreciation().errors.showAllMessages();
                        //    addEmployeeItem().employeeDisposalInfo().errors.showAllMessages();
                        //    flag = false;
                        //}
                        return flag;
                    },
                    // Save Employee
                    saveEmployee = function (employee) {
                        dataservice.saveEmployee(model.EmployeeDetailServerMapper(employee), {
                            success: function (data) {
                                var employeeResult = new model.EmployeeClientMapper(data);
                                if ((addEmployeeItem().employeeId() === undefined) || (addEmployeeItem().employeeId() === 0)) {
                                    employees.splice(0, 0, employeeResult);
                                } else {
                                    selectedEmployee().employeeName(employeeResult.employeeName());
                                    selectedEmployee().modelYear(employeeResult.modelYear());
                                    selectedEmployee().fuelLevel(employeeResult.fuelLevel());
                                }
                                closeEmployeeEditor();
                                toastr.success(ist.resourceText.employeeSaveSuccessMsg);
                            },
                            error: function (exceptionMessage, exceptionType) {

                                if (exceptionType === ist.exceptionType.CaresGeneralException) {

                                    toastr.error(exceptionMessage);

                                } else {

                                    toastr.error(ist.resourceText.employeeSaveErrorMsg);

                                }

                            }
                        });
                    },
                    // //Get Base Data
                    getBaseData = function (callBack) {
                        dataservice.getEmployeeBase({
                            success: function (data) {
                                //Operations 
                                operations.removeAll();
                                ko.utils.arrayPushAll(operations(), data.Operations);
                                operations.valueHasMutated();


                                if (callBack && typeof callBack === 'function') {
                                    callBack();
                                }
                            },
                            error: function () {
                                toastr.error(ist.resourceText.loadBaseDataFailedMsg);
                            }
                        });
                    },
                    // Search 
                    search = function () {
                        pager().reset();
                        //getEmployees();
                    },
                    //Add Maintenance Schedule Item To Maintennace Schedule List
                     onAddMaintenanceSchedule = function (maintenanceSchedule) {
                         if (doBeforeSaveMaintenanceSchedule()) {
                             _.each(maintenanceTypes(), function (item) {
                                 if (item.MaintenanceTypeId === maintenanceSchedule.maintenanceTypeId())
                                     maintenanceSchedule.maintenanceTypCodeName(item.MaintenanceTypeCodeName);
                             });

                             maintenanceScheduleList.splice(0, 0, maintenanceSchedule);
                             addEmployeeItem().maintenanceSchedule(new model.MaintenanceSchedule());
                         }
                     },
                    // Do Before Logic
                    doBeforeSaveMaintenanceSchedule = function () {
                        var flag = true;
                        if (!addEmployeeItem().maintenanceSchedule().isValid()) {
                            addEmployeeItem().maintenanceSchedule().errors.showAllMessages();
                            flag = false;
                        }
                        return flag;
                    },
                    //Delete Maintenance Schedule Item
                    deleteMaintenanceSchedule = function (maintenanceSchedule) {
                        maintenanceScheduleList.remove(maintenanceSchedule);
                    },
                    //Add Maintenance Schedule Item To Maintennace Schedule List
                    onAddCheckListItem = function (checkListItem) {
                        if (doBeforeSaveCheckListItem()) {
                            _.each(employeeCheckList(), function (item) {
                                if (item.EmployeeCheckListId === checkListItem.employeeCheckListId())
                                    checkListItem.employeeCheckListCodeName(item.EmployeeCheckListCodeName);
                            });

                            checkListItemList.splice(0, 0, checkListItem);
                            addEmployeeItem().checkListItem(new model.CheckListItem());
                        }
                    },
                    // Do Before Logic
                    doBeforeSaveCheckListItem = function () {
                        var flag = true;
                        if (!addEmployeeItem().checkListItem().isValid()) {
                            addEmployeeItem().checkListItem().errors.showAllMessages();
                            flag = false;
                        }
                        return flag;
                    },
                    //Delete Maintenance Schedule Item
                    deleteCheckListItem = function (checkListItem) {
                        checkListItemList.remove(checkListItem);
                    },
                    mapEmployees = function (data) {
                        var employeeList = [];
                        _.each(data.Employees, function (item) {
                            var employee = new model.EmployeeClientMapper(item);
                            employeeList.push(employee);
                        });
                        ko.utils.arrayPushAll(employees(), employeeList);
                        employees.valueHasMutated();
                    },
                      //on selected company
                    onSelectedCompany = function (company) {
                        filteredDepartments.removeAll();
                        filteredOperations.removeAll();
                        if (company.companyId() != undefined) {
                            _.each(departments(), function (item) {
                                if (item.CompanyId === company.companyId())
                                    filteredDepartments.push(item);
                            });
                            filteredDepartments.valueHasMutated();
                        }

                    },
                      //on selected Department 
                    onSelectedDepartemnt = function (department) {
                        filteredOperations.removeAll();
                        if (department.departmentId() != undefined) {
                            _.each(operations(), function (item) {
                                if (item.DepartmentId === department.departmentId())
                                    filteredOperations.push(item);
                            });
                            filteredOperations.valueHasMutated();
                        }
                    },
                    modelYears = [{ Id: 2001, Text: '2001' },
                        { Id: 2002, Text: '2002' },
                        { Id: 2003, Text: '2003' },
                         { Id: 2004, Text: '2004' },
                        { Id: 2005, Text: '2005' },
                        { Id: 2006, Text: '2006' },
                        { Id: 2007, Text: '2007' }
                    ],
                    // Get Employees
                    getEmployees = function () {
                        isLoadingEmployees(true);
                        dataservice.getEmployees({
                            SearchString: searchFilter(),
                            HireGroupString: hireGroupFilter(),
                            OperationId: operationFilter(),
                            FleetPoolId: fleetPoolFilter(),
                            PageSize: pager().pageSize(),
                            PageNo: pager().currentPage(),
                            SortBy: sortOn(),
                            IsAsc: sortIsAsc()
                        }, {
                            success: function (data) {
                                pager().totalCount(data.TotalCount);
                                employees.removeAll();
                                mapEmployees(data);
                                isLoadingEmployees(false);
                            },
                            error: function () {
                                isLoadingEmployees(false);
                                toastr.error(ist.resourceText.employeeLoadFailedMsg);
                            }
                        });
                    };
                // #endregion Service Calls

                return {
                    // Observables
                    selectedEmployee: selectedEmployee,
                    isLoadingEmployees: isLoadingEmployees,
                    sortOn: sortOn,
                    sortIsAsc: sortIsAsc,
                    isEmployeeEditorVisible: isEmployeeEditorVisible,
                    filterSectionVisilble: filterSectionVisilble,
                    addEmployeeItem: addEmployeeItem,
                    //Arrays
                    employees: employees,
                    operations: operations,
                    companies: companies,
                    regions: regions,

                    //Filters
                    searchFilter: searchFilter,
                    // Utility Methods
                    initialize: initialize,
                    search: search,
                    getEmployees: getEmployees,
                    mapEmployees: mapEmployees,
                    getBaseData: getBaseData,
                    pager: pager,
                    createEmployee :createEmployee,
                    closeEmployeeEditor: closeEmployeeEditor,
                    showEmployeeEditor: showEmployeeEditor,
                    collapseFilterSection: collapseFilterSection,
                    showFilterSection: showFilterSection,
                    // Utility Methods

                };
            })()
        };
        return ist.employee.viewModel;
    });
