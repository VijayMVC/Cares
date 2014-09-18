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
                    workPlacesServer = ko.observableArray([]),
                    //Supervisors
                    supervisors = ko.observableArray([]),
                    //Countries
                    countries = ko.observableArray([]),
                    //Regions
                    regions = ko.observableArray([]),
                    //Sub Regions
                    subRegions = ko.observableArray([]),
                    //Cities
                    cities = ko.observableArray([]),
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
                    //Address Types
                    addressTypes = ko.observableArray([]),
                     //Filtered Departments
                    filteredDepartments = ko.observableArray([]),
                     //operation Wor kPlaces
                    filteredWorkplaces = ko.observableArray([]),
                    //Filtered Regions
                    filteredRegions = ko.observableArray([]),
                    //filtered Cities
                    filteredCities = ko.observableArray([]),
                    //filtered Areas
                    filteredAreas = ko.observableArray([]),
                    //Filtered Sub Regions
                    filteredSubRegions = ko.observableArray([]),
                    //Filtered Operations
                    filteredOperations = ko.observableArray([]),
                    //Filtered Operations Workplaces
                    filteredOperationsWorkplaces = ko.observableArray([]),
                      //Address List
                    addressList = ko.observableArray([]),
                    //Phone Number List
                    phoneNumbersList = ko.observableArray([]),
                    //Job Progress List
                    jobProgList = ko.observableArray([]),
                    //Authorized Locations List
                    authLocationsList = ko.observableArray([]),
                    // #endregion Arrays
                    // #region Busy Indicators
                    isLoadingEmployees = ko.observable(false),
                    // #endregion Busy Indicators
                    // #region Observables
                    // Sort On
                    sortOn = ko.observable(1),
                    // Sort Order -  true means asc, false means desc
                    sortIsAsc = ko.observable(true),
                         // Is Employee Editor Visible
                    isEmployeeEditorVisible = ko.observable(false),
                    // Pagination
                    pager = ko.observable(),
                    // #region Filters
                     //Search filter
                    searchFilter = ko.observable(),
                    //Employee Status Filter
                    employeeStatusFilter = ko.observable(),
                       //Company Filter
                    companyFilter = ko.observable(),
                    // #endregion
                    //#region  filter Arrays
                    //on selected company
                    onSelectedCompany = function (company) {
                        filteredDepartments.removeAll();
                        filteredWorkplaces.removeAll();
                        filteredOperations.removeAll();
                        if (company.companyId() != undefined) {
                            _.each(departments(), function (item) {
                                if (item.CompanyId === company.companyId())
                                    filteredDepartments.push(item);
                            });

                            _.each(workPlacesServer(), function (item) {
                                if (item.CompanyId === company.companyId())
                                    filteredWorkplaces.push(item);
                            });

                            _.each(operations(), function (item) {
                                filteredOperations.push(item);
                            });
                        }

                    },
                    //on selected Operation
                    onSelectedOperation = function (operation) {
                        filteredOperationsWorkplaces.removeAll();
                        if (operation.operationId() != undefined) {
                            _.each(operationWorkPlaces(), function (item) {
                                if (item.OperationId === operation.operationId().OperationId)
                                    filteredOperationsWorkplaces.push(item);
                            });
                        }
                    },
                    //country selection change event
                    onCountrySelectionChange = function (value) {
                        if (addEmployeeItem().address().countryId() !== undefined) {
                            getRegionsByCountry(addEmployeeItem().address().countryId());
                            _.each(countries(), function (item) {
                                if (item.CountryId === addEmployeeItem().address().countryId())
                                    addEmployeeItem().address().countryName(item.CountryCodeName);
                            });

                        }
                    },
                    //get regions by country          
                    getRegionsByCountry = function (countryId) {
                        //filter Regions by country
                        filteredRegions.removeAll();
                        _.each(regions(), function (item) {
                            if (item.CountryId === countryId)
                                filteredRegions.push(item);
                        });
                        filteredRegions.valueHasMutated();
                        //filter cities by country
                        filteredCities.removeAll();
                        _.each(cities(), function (item) {
                            if (item.CountryId === countryId)
                                filteredCities.push(item);
                        });
                        filteredCities.valueHasMutated();

                    },
                     //region selection change event
                    onRegionSelectionChange = function (value) {
                        if (addEmployeeItem().address().regionId() !== undefined) {
                            getSubRegionsByRegion(addEmployeeItem().address().regionId());
                            _.each(regions(), function (item) {
                                if (item.RegionId === addEmployeeItem().address().regionId())
                                    addEmployeeItem().address().regionName(item.RegionCodeName);
                            });
                        } else {
                            // empty sub regions
                            filteredSubRegions.removeAll();
                            filteredSubRegions.valueHasMutated();
                        }
                    },
                    //get sub regions by region          
                    getSubRegionsByRegion = function (regionId) {
                        // get filtered sub regions
                        filteredSubRegions.removeAll();
                        _.each(subRegions(), function (item) {
                            if (item.RegionId === regionId)
                                filteredSubRegions.push(item);
                        });
                        filteredSubRegions.valueHasMutated();
                        // get filtered cities
                        filteredCities.removeAll();
                        _.each(cities(), function (item) {
                            if (item.RegionId === regionId)
                                filteredCities.push(item);
                        });
                        filteredCities.valueHasMutated();
                    },
                      //sub region selection change event
                    onSubRegionSelectionChange = function (value) {
                        if (addEmployeeItem().address().subRegionId() !== undefined) {
                            getCitiesBySubRegion(addEmployeeItem().address().subRegionId());
                            _.each(subRegions(), function (item) {
                                if (item.SubRegionId === addEmployeeItem().address().subRegionId())
                                    addEmployeeItem().address().subRegionName(item.SubRegionCodeName);
                            });
                        }
                    },
                     //get cities by sub region          
                    getCitiesBySubRegion = function (subRegionId) {
                        // get filtered cities
                        filteredCities.removeAll();
                        _.each(cities(), function (item) {
                            if (item.SubRegionId === subRegionId)
                                filteredCities.push(item);
                        });
                        filteredCities.valueHasMutated();
                    },
                      //city selection change event
                    onCitySelectionChange = function (value) {
                        if (addEmployeeItem().address().cityId() !== undefined) {
                            getAreasByCity(addEmployeeItem().address().cityId());
                            _.each(cities(), function (item) {
                                if (item.CityId === addEmployeeItem().address().cityId())
                                    addEmployeeItem().address().cityName(item.CityCodeName);
                            });
                        } else {
                            // empty area list
                            filteredAreas.removeAll();
                            filteredAreas.valueHasMutated();
                        }
                    },
                    //get Areas by city          
                    getAreasByCity = function (cityId) {
                        // get areas by city
                        filteredAreas.removeAll();
                        _.each(areas(), function (item) {
                            if (item.CityId === cityId)
                                filteredAreas.push(item);
                        });
                        filteredAreas.valueHasMutated();
                    },
                      //sub Area selection change event
                    onAreaSelectionChange = function (value) {
                        if (addEmployeeItem().address().areaId() !== undefined) {
                            _.each(areas(), function (item) {
                                if (item.AreaId === addEmployeeItem().address().areaId())
                                    addEmployeeItem().address().areaName(item.AreaCodeName);
                            });
                        }
                    },
                      //sub Address Type selection change event
                    onAddressTypeSelectionChange = function (value) {
                        if (addEmployeeItem().address().addressTypeId() !== undefined) {
                            _.each(addressTypes(), function (item) {
                                if (item.AddressTypeId === addEmployeeItem().address().addressTypeId())
                                    addEmployeeItem().address().addressTypeName(item.AddressTypeCodeName);
                            });
                        }
                    },
                    // #endregion
                    // #region Utility Functions
                      // Add a Address
                    onAddAddress = function () {
                        // check validation error before add
                        if (doBeforeAddAddressItem()) {
                            var address = model.Address();
                            address.contactPerson(addEmployeeItem().address().contactPerson());
                            address.streetAddress(addEmployeeItem().address().streetAddress());
                            address.emailAddress(addEmployeeItem().address().emailAddress());
                            address.countryName(addEmployeeItem().address().countryName());
                            address.countryId(addEmployeeItem().address().countryId());
                            address.webPage(addEmployeeItem().address().webPage());
                            address.zipCode(addEmployeeItem().address().zipCode());
                            address.poBox(addEmployeeItem().address().poBox());
                            address.regionId(addEmployeeItem().address().regionId());
                            address.regionName(addEmployeeItem().address().regionName());
                            address.subRegionId(addEmployeeItem().address().subRegionId());
                            address.subRegionName(addEmployeeItem().address().subRegionName());
                            address.cityId(addEmployeeItem().address().cityId());
                            address.cityName(addEmployeeItem().address().cityName());
                            address.areaId(addEmployeeItem().address().areaId());
                            address.areaName(addEmployeeItem().address().areaName());
                            address.addressTypeId(addEmployeeItem().address().addressTypeId());
                            address.addressTypeName(addEmployeeItem().address().addressTypeName());
                            addressList.push(address);
                            // emplty input fields
                            addEmployeeItem().address(model.Address());
                        }
                    },
                     //Do Before Add Address Item
                    doBeforeAddAddressItem = function () {
                        var flag = true;
                        if (!addEmployeeItem().address().isValid()) {
                            addEmployeeItem().address().errors.showAllMessages();
                            flag = false;
                        }
                        return flag;
                    },
                    // Add a Employee Phone
                    onAddEmployeePhone = function () {
                        // check validation error before add
                        if (doBeforeAddPhoneItem()) {
                            var phoneItem = model.Phone();
                            phoneItem.isDefault(addEmployeeItem().phone().isDefault());
                            phoneItem.phoneNumber(addEmployeeItem().phone().phoneNumber());
                            phoneItem.phoneTypeId(addEmployeeItem().phone().phoneTypeId().PhoneTypeId);
                            phoneItem.phoneTypeName(addEmployeeItem().phone().phoneTypeId().PhoneTypeCodeName);
                            phoneNumbersList.push(phoneItem);

                            // emplty input fields
                            addEmployeeItem().phone(model.Phone());
                        }
                    },
                    //Do Before Add BusinessPartner Phone Item
                    doBeforeAddPhoneItem = function () {
                        var flag = true;
                        if (!addEmployeeItem().phone().isValid()) {
                            addEmployeeItem().phone().errors.showAllMessages();
                            flag = false;
                        } else {
                            // check if isdefault true entry already there
                            var isDefaultAlreadyThere = false;
                            _.each(phoneNumbersList(), function (item) {
                                if (item.isDefault() == true)
                                    isDefaultAlreadyThere = true;
                            });
                            if (isDefaultAlreadyThere && addEmployeeItem().phone().isDefault()) {
                                toastr.info("Default record already there!");
                                return false;
                            }
                        }
                        return flag;
                    },
                    //Add a Employee Job Progress
                     onAddJobProgress = function () {
                         // check validation error before add
                         if (doBeforeAddJobProgressItem()) {
                             var jobProgress = model.JobProgress();
                             jobProgress.empJobProgId(addEmployeeItem().jobProgress().empJobProgId());
                             jobProgress.designationId(addEmployeeItem().jobProgress().designationId().DesignationId);
                             jobProgress.desigName(addEmployeeItem().jobProgress().designationId().DesignationCodeName);
                             jobProgress.workplaceId(addEmployeeItem().jobProgress().workplaceId().WorkPlaceId);
                             jobProgress.workplaceName(addEmployeeItem().jobProgress().workplaceId().WorkPlaceCodeName);
                             jobProgress.desigStDt(addEmployeeItem().jobProgress().desigStDt());
                             jobProgress.desigEndDt(addEmployeeItem().jobProgress().desigEndDt());
                             jobProgList.push(jobProgress);

                             // emplty input fields
                             addEmployeeItem().jobProgress(model.JobProgress());
                         }
                     },
                    // Do Before Employee Job Progress Item
                    doBeforeAddJobProgressItem = function () {
                        var flag = true;
                        if (!addEmployeeItem().jobProgress().isValid()) {
                            addEmployeeItem().jobProgress().errors.showAllMessages();
                            flag = false;
                        }
                        return flag;
                    },
                    // Add a Employee Authorized Location 
                     onAddAuthorizedLocation = function () {
                         // check validation error before add
                         if (doBeforeAddAuthorizedLocationItem()) {
                             var authorizedLocation = model.AuthorizedLocation();
                             authorizedLocation.id(addEmployeeItem().authorizedLocation().id());
                             authorizedLocation.operationsWorkplaceId(addEmployeeItem().authorizedLocation().operationsWorkplaceId().OperationsWorkPlaceId);
                             authorizedLocation.operationsWorkplaceName(addEmployeeItem().authorizedLocation().operationsWorkplaceId().OperationsWorkPlaceCodeName);
                             authorizedLocation.operationId(addEmployeeItem().authorizedLocation().operationId().OperationId);
                             authorizedLocation.operationName(addEmployeeItem().authorizedLocation().operationId().OperationCodeName);
                             authorizedLocation.isDefault(addEmployeeItem().authorizedLocation().isDefault());
                             authorizedLocation.isOperationDefault(addEmployeeItem().authorizedLocation().isOperationDefault());
                             authLocationsList.push(authorizedLocation);

                             // emplty input fields
                             addEmployeeItem().authorizedLocation(model.AuthorizedLocation());
                         }
                     },
                     // Do Before Employee Authorized Location Item
                    doBeforeAddAuthorizedLocationItem = function () {
                        var flag = true;
                        if (!addEmployeeItem().authorizedLocation().isValid()) {
                            addEmployeeItem().authorizedLocation().errors.showAllMessages();
                            flag = false;
                        }
                        return flag;
                    },
                    // Initialize the view model
                    initialize = function (specifiedView) {
                        view = specifiedView;
                        ko.applyBindings(view.viewModel, view.bindingRoot);
                        getBaseData();
                        // Set Pager
                        pager(new pagination.Pagination({}, employees, getEmployees));
                        getEmployees();

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
                        var employee = new model.EmployeeDetail();
                        filteredDepartments.removeAll();
                        filteredWorkplaces.removeAll();
                        filteredCities.removeAll();
                        filteredRegions.removeAll();
                        filteredAreas.removeAll();
                        filteredSubRegions.removeAll();
                        addressList.removeAll();
                        phoneNumbersList.removeAll();
                        jobProgList.removeAll();
                        authLocationsList.removeAll();
                        //Select the newly added Employee
                        addEmployeeItem(employee);
                        showEmployeeEditor();
                    },
                      //Edit Employee
                    onEditEmployee = function (employee, e) {
                        addressList.removeAll();
                        phoneNumbersList.removeAll();
                        jobProgList.removeAll();
                        authLocationsList.removeAll();
                        selectedEmployee(employee);
                        getEmployeeById(employee);
                        showEmployeeEditor();
                        e.stopImmediatePropagation();
                    },
                      //Get Employee data By Id
                    getEmployeeById = function (employee) {
                        isLoadingEmployees(true);
                        dataservice.getEmployeeDetailById(model.EmployeeDetailServerMapperForId(employee), {
                            success: function (data) {
                                var employeeDetail = model.EmployeeDetailClientMapper(data);
                                addEmployeeItem(employeeDetail);
                                _.each(data.Addresses, function (item) {
                                    var address = model.AddressClientMapper(item);
                                    addressList.push(address);
                                });
                                _.each(data.PhoneNumbers, function (item) {
                                    var phone = model.PhoneClientMapper(item);
                                    phoneNumbersList.push(phone);
                                });
                                _.each(data.EmpJobProgs, function (item) {
                                    var jobProg = model.JobProgressClientMapper(item);
                                    jobProgList.push(jobProg);
                                });
                                _.each(data.AuthorizedLocations, function (item) {
                                    var location = model.AuthorizedLocationClientMapper(item);
                                    authLocationsList.push(location);
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
                        if (!employee.id()) {
                            employees.remove(employee);
                            return;
                        }
                        // Ask for confirmation
                        confirmation.afterProceed(function () {
                            deleteEmployee(employee);
                        });
                        confirmation.show();
                    },
                    // Delete Employee
                    deleteEmployee = function (employee) {
                        dataservice.deleteEmployee(model.EmployeeDetailServerMapperForId(employee), {
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
                            if (employee.employeeAddressList().length !== 0) {
                                employee.employeeAddressList.removeAll();
                            }
                            if (employee.phonesList().length !== 0) {
                                employee.phonesList.removeAll();
                            }
                            if (employee.jobProgressList().length !== 0) {
                                employee.jobProgressList.removeAll();
                            }
                            if (employee.authorizedLocationList().length !== 0) {
                                employee.authorizedLocationList.removeAll();
                            }
                            ko.utils.arrayPushAll(employee.phonesList(), phoneNumbersList());
                            ko.utils.arrayPushAll(employee.employeeAddressList(), addressList());
                            ko.utils.arrayPushAll(employee.jobProgressList(), jobProgList());
                            ko.utils.arrayPushAll(employee.authorizedLocationList(), authLocationsList());

                            saveEmployee(employee);
                        }
                    },
                    // Do Before Logic
                    doBeforeSave = function () {
                        var flag = true;
                        if (!addEmployeeItem().isValid() || !addEmployeeItem().jobInfo().isValid()) {
                            addEmployeeItem().errors.showAllMessages();
                            addEmployeeItem().jobInfo().errors.showAllMessages();
                            flag = false;
                        }
                        return flag;
                    },
                    // Save Employee
                    saveEmployee = function (employee) {
                        dataservice.saveEmployee(model.EmployeeDetailServerMapper(employee), {
                            success: function (data) {
                                var employeeResult = new model.EmployeeClientMapper(data);
                                if ((addEmployeeItem().empId() === undefined) || (addEmployeeItem().empId() === 0)) {
                                    employees.splice(0, 0, employeeResult);
                                } else {
                                    //selectedEmployee().employeeName(employeeResult.employeeName());
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
                        dataservice.getEmployeeBaseData({
                            success: function (data) {
                                //Operations 
                                operations.removeAll();
                                ko.utils.arrayPushAll(operations(), data.Operations);
                                operations.valueHasMutated();
                                //Address Types 
                                addressTypes.removeAll();
                                ko.utils.arrayPushAll(addressTypes(), data.AddressTypes);
                                addressTypes.valueHasMutated();
                                //departments
                                departments.removeAll();
                                ko.utils.arrayPushAll(departments(), data.Departments);
                                departments.valueHasMutated();
                                //Operations 
                                companies.removeAll();
                                ko.utils.arrayPushAll(companies(), data.Companies);
                                companies.valueHasMutated();
                                //Employee Statuses 
                                employeeStatuses.removeAll();
                                ko.utils.arrayPushAll(employeeStatuses(), data.EmpStatuses);
                                employeeStatuses.valueHasMutated();
                                //Regions
                                regions.removeAll();
                                ko.utils.arrayPushAll(regions(), data.Regions);
                                regions.valueHasMutated();
                                //Nationalities
                                nationalities.removeAll();
                                ko.utils.arrayPushAll(nationalities(), data.Countries);
                                nationalities.valueHasMutated();
                                //Job Types
                                jobTypes.removeAll();
                                ko.utils.arrayPushAll(jobTypes(), data.JobTypes);
                                jobTypes.valueHasMutated();
                                //Designations
                                designations.removeAll();
                                ko.utils.arrayPushAll(designations(), data.Designations);
                                designations.valueHasMutated();
                                //Designation Grades 
                                designationGrades.removeAll();
                                ko.utils.arrayPushAll(designationGrades(), data.DesigGrades);
                                designationGrades.valueHasMutated();
                                //Work Places
                                workPlacesServer.removeAll();
                                ko.utils.arrayPushAll(workPlacesServer(), data.WorkPlaces);
                                workPlacesServer.valueHasMutated();
                                //Supervisors
                                supervisors.removeAll();
                                ko.utils.arrayPushAll(supervisors(), data.Supervisors);
                                supervisors.valueHasMutated();
                                //Countries
                                countries.removeAll();
                                ko.utils.arrayPushAll(countries(), data.Countries);
                                countries.valueHasMutated();
                                //Sub Regions
                                subRegions.removeAll();
                                ko.utils.arrayPushAll(subRegions(), data.SubRegions);
                                subRegions.valueHasMutated();
                                //Cities
                                cities.removeAll();
                                ko.utils.arrayPushAll(cities(), data.Cities);
                                cities.valueHasMutated();
                                //Areas
                                areas.removeAll();
                                ko.utils.arrayPushAll(areas(), data.Areas);
                                areas.valueHasMutated();
                                //Phone Types
                                phoneTypes.removeAll();
                                ko.utils.arrayPushAll(phoneTypes(), data.PhoneTypes);
                                phoneTypes.valueHasMutated();
                                //Passport Countries
                                passportCountries.removeAll();
                                ko.utils.arrayPushAll(passportCountries(), data.Countries);
                                passportCountries.valueHasMutated();
                                //VisaIssue Countries
                                visaIssueCountries.removeAll();
                                ko.utils.arrayPushAll(visaIssueCountries(), data.Countries);
                                visaIssueCountries.valueHasMutated();
                                //License Types
                                licenseTypes.removeAll();
                                ko.utils.arrayPushAll(licenseTypes(), data.LicenseTypes);
                                licenseTypes.valueHasMutated();
                                //Operations Work Places
                                operationWorkPlaces.removeAll();
                                ko.utils.arrayPushAll(operationWorkPlaces(), data.OperationsWorkPlaces);
                                operationWorkPlaces.valueHasMutated();
                                //Employee Statuses
                                employeeStatuses.removeAll();
                                ko.utils.arrayPushAll(employeeStatuses(), data.EmpStatuses);
                                employeeStatuses.valueHasMutated();

                                if (callBack && typeof callBack === 'function') {
                                    callBack();
                                }
                            },
                            error: function () {
                                toastr.error("loadBaseDataFailedMsg");
                            }
                        });
                    },
                    // Search 
                    search = function () {
                        pager().reset();
                        getEmployees();
                    },
                    // Reset 
                    reset = function () {
                        searchFilter(undefined);
                        employeeStatusFilter(undefined);
                        companyFilter(undefined);
                        search();
                    },
                    //map Employees
                    mapEmployees = function (data) {
                        var employeeList = [];
                        _.each(data.Employees, function (item) {
                            var employee = new model.EmployeeClientMapper(item);
                            employeeList.push(employee);
                        });
                        ko.utils.arrayPushAll(employees(), employeeList);
                        employees.valueHasMutated();
                    },
                     //Gender
                    genders = [{ Id: 'M', Text: 'Male' },
                        { Id: 'F', Text: 'Female' }

                    ],
                     //Delete Address Item
                    deleteAddressItem = function (address) {
                        addressList.remove(address);
                    },
                     //Delete Phone Item
                    deletePhoneItem = function (phone) {
                        phoneNumbersList.remove(phone);
                    },
                       //Delete Job Progress. Item
                    deleteJobProgressItem = function (jobProgress) {
                        jobProgList.remove(jobProgress);
                    },
                    //Delete Authorized Location Item
                    deleteAuthLocationItem = function (jobProgress) {
                        authLocationsList.remove(jobProgress);
                    },
                    // Get Employees
                    getEmployees = function () {
                        isLoadingEmployees(true);
                        dataservice.getEmployees({
                            SearchString: searchFilter(),
                            EmployeeStatusId: employeeStatusFilter(),
                            CompanyId: companyFilter(),
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
                    genders: genders,
                    regions: regions,
                    nationalities: nationalities,
                    jobTypes: jobTypes,
                    designations: designations,
                    designationGrades: designationGrades,
                    workPlacesServer: workPlacesServer,
                    supervisors: supervisors,
                    countries: countries,
                    subRegions: subRegions,
                    cities: cities,
                    areas: areas,
                    phoneTypes: phoneTypes,
                    passportCountries: passportCountries,
                    visaIssueCountries: visaIssueCountries,
                    licenseTypes: licenseTypes,
                    operationWorkPlaces: operationWorkPlaces,
                    employeeStatuses: employeeStatuses,
                    filteredDepartments: filteredDepartments,
                    filteredWorkplaces: filteredWorkplaces,
                    addressTypes: addressTypes,
                    filteredCities: filteredCities,
                    filteredRegions: filteredRegions,
                    filteredAreas: filteredAreas,
                    filteredSubRegions: filteredSubRegions,
                    filteredOperations: filteredOperations,
                    filteredOperationsWorkplaces: filteredOperationsWorkplaces,
                    addressList: addressList,
                    phoneNumbersList: phoneNumbersList,
                    jobProgList: jobProgList,
                    authLocationsList: authLocationsList,
                    //Filters
                    searchFilter: searchFilter,
                    employeeStatusFilter: employeeStatusFilter,
                    companyFilter: companyFilter,
                    // Utility Methods
                    initialize: initialize,
                    search: search,
                    getEmployees: getEmployees,
                    mapEmployees: mapEmployees,
                    getBaseData: getBaseData,
                    pager: pager,
                    createEmployee: createEmployee,
                    closeEmployeeEditor: closeEmployeeEditor,
                    showEmployeeEditor: showEmployeeEditor,
                    collapseFilterSection: collapseFilterSection,
                    showFilterSection: showFilterSection,
                    reset: reset,
                    onEditEmployee: onEditEmployee,
                    onDeleteEmployee: onDeleteEmployee,
                    onSaveEmployee: onSaveEmployee,
                    onSelectedCompany: onSelectedCompany,
                    onCountrySelectionChange: onCountrySelectionChange,
                    onRegionSelectionChange: onRegionSelectionChange,
                    onSubRegionSelectionChange: onSubRegionSelectionChange,
                    onCitySelectionChange: onCitySelectionChange,
                    onAddAddress: onAddAddress,
                    onAreaSelectionChange: onAreaSelectionChange,
                    onAddressTypeSelectionChange: onAddressTypeSelectionChange,
                    onAddEmployeePhone: onAddEmployeePhone,
                    onAddJobProgress: onAddJobProgress,
                    onAddAuthorizedLocation: onAddAuthorizedLocation,
                    onSelectedOperation: onSelectedOperation,
                    deleteAddressItem: deleteAddressItem,
                    deletePhoneItem: deletePhoneItem,
                    deleteJobProgressItem: deleteJobProgressItem,
                    deleteAuthLocationItem: deleteAuthLocationItem,
                    // Utility Methods

                };
            })()
        };
        return ist.employee.viewModel;
    });
