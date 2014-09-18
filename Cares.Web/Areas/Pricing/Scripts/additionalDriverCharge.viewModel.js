/*
    Module with the view model for the Additional Driver Charge
*/
define("additionalDriverCharge/additionalDriverCharge.viewModel",
    ["jquery", "amplify", "ko", "additionalDriverCharge/additionalDriverCharge.dataservice", "additionalDriverCharge/additionalDriverCharge.model", "common/confirmation.viewModel", "common/pagination", "common/clientSidePagination"],
    function ($, amplify, ko, dataservice, model, confirmation, pagination) {
        var ist = window.ist || {};
        ist.additionalDriverCharge = {
            viewModel: (function () {
                var // the view 
                    view,
                    // Active Additional Driver Charge 
                    selectedAdditionalDriverChrg = ko.observable(),
                    // Show Filter Section
                    filterSectionVisilble = ko.observable(false),
                    // #region Arrays
                    //Compnaies
                    companies = ko.observableArray([]),
                    //Departments
                    departments = ko.observableArray([]),
                    // Operations
                    operations = ko.observableArray([]),
                    //Tariff Types
                    tariffTypes = ko.observableArray([]),
                    //additional Driver Charges
                    addDriverChrgs = ko.observableArray([]),
                    //filtered Departments
                     filteredDepartments = ko.observableArray([]),
                    //filtered Operations
                    filteredOperations = ko.observableArray([]),
                    //filtered Tariff Types
                    filteredTariffTypes = ko.observableArray([]),
                    // #endregion Arrays
                    // #region Busy Indicators
                    isLoadingAdditionalDriverChrg = ko.observable(false),
                    // #endregion Busy Indicators
                    // #region Observables
                    // Sort On
                    sortOn = ko.observable(1),
                    // Sort Order -  true means asc, false means desc
                    sortIsAsc = ko.observable(true),
                    // Sort On Hiregroup
                    sortOnHg = ko.observable(1),
                    // Sort Order -  true means asc, false means desc
                    sortIsAscHg = ko.observable(true),
                    // Is Additional Driver Charge Editor Visible
                    isAdditionalDriverChrgEditorVisible = ko.observable(false),
                    // Is Editable
                    isEditable = ko.observable(false),
                    // Pagination
                    pager = ko.observable(),
                    // Search Filter
                    searchFilter = ko.observable(),
                    //Operation Filter
                    operationFilter = ko.observable(),
                    //Tariff Type Filter
                    tariffTypeFilter = ko.observable(),
                    // #region Utility Functions
                    // Initialize the view model
                    initialize = function (specifiedView) {
                        view = specifiedView;
                        ko.applyBindings(view.viewModel, view.bindingRoot);
                        getBase();
                        // Set Pager
                        pager(new pagination.Pagination({}, addDriverChrgs, getAddDriverChrgs));
                        getAddDriverChrgs();

                    },

                    // Collapase filter section
                    collapseFilterSection = function () {
                        filterSectionVisilble(false);
                    },
                    //Show filter section
                    showFilterSection = function () {
                        filterSectionVisilble(true);
                    },
                    // Get Base
                    getBase = function (callBack) {
                        dataservice.getAdditionalDriverChrgBase({
                            success: function (data) {
                                //Companies Array
                                companies.removeAll();
                                ko.utils.arrayPushAll(companies(), data.Companies);
                                companies.valueHasMutated();
                                //Departments Array
                                departments.removeAll();
                                ko.utils.arrayPushAll(departments(), data.Departments);
                                departments.valueHasMutated();
                                //Operations Array
                                operations.removeAll();
                                ko.utils.arrayPushAll(operations(), data.Operations);
                                operations.valueHasMutated();
                                //Tariff Types
                                tariffTypes.removeAll();
                                ko.utils.arrayPushAll(tariffTypes(), data.TariffTypes);
                                tariffTypes.valueHasMutated();

                                if (callBack && typeof callBack === 'function') {
                                    callBack();
                                }
                            },
                            error: function () {
                                toastr.error(ist.resourceText.loadBaseDataFailedMsg);
                            }
                        });
                    },
                    //Get Additional Driver Charge Items
                    getAdditionalDriverChrgItems = function (serviceRt) {
                        isLoadingAdditionalDriverChrg(true);
                        dataservice.getAdditionalDriverChrgDetail(serviceRt.convertToServerData(), {
                            success: function (data) {
                                serviceRtItems.removeAll();
                                _.each(data.AdditionalDriverChrgDetails, function (item) {
                                    var serviceRtItem = new model.ServiceItemRtClientMapper(item);
                                    serviceRtItems.push(serviceRtItem);
                                });
                                isLoadingAdditionalDriverChrg(false);
                            },
                            error: function () {
                                isLoadingAdditionalDriverChrg(false);
                                toastr.error(ist.resourceText.serviceItemRatesFailedMsg);
                            }
                        });
                    },
                    // Search 
                    search = function () {
                        pager().reset();
                        getAddDriverChrgs();
                    },
                    //Reset
                    reset = function () {
                        searchFilter(undefined);
                        tariffTypeFilter(undefined);
                        operationFilter(undefined);
                        search();
                    },
                    // Map Additional Driver Charges - Server to Client
                    mapAddDriverChrgs = function (data) {
                        var addDriverChrgList = [];
                        _.each(data.AdditionalDriverCharges, function (item) {
                            var addDriverChrg = new model.AdditionalDriverChargeClientMapper(item);
                            addDriverChrgList.push(addDriverChrg);
                        });
                        ko.utils.arrayPushAll(addDriverChrgs(), addDriverChrgList);
                        addDriverChrgs.valueHasMutated();
                    },
                    //Create Additional Driver Charge
                    createAddDriverChrg = function () {
                        var addDrvierChrg = new model.AdditionalDriverCharge();
                        // Select the newly added Additional Driver Charge
                        selectedAdditionalDriverChrg(addDrvierChrg);
                        //getAdditionalDriverChrgItems(serviceRtMain);
                        showAdditionalDriverChrgEditor();
                    },
                    // Save Additional Driver Charge
                    onSaveAdditionalDriverChrg = function (serviceRt) {
                        if (doBeforeSave()) {
                            serviceRt.serviceItemRts.removeAll();
                            _.each(serviceRtItems(), function (item) {
                                if (item.isChecked() === true && doBeforeSaveForAdditionalDriverChrgItem(item)) {
                                    serviceRt.serviceItemRts.push(item);
                                }
                            });
                            if (serviceRtDetailIsValid()) {
                                saveAdditionalDriverChrg(serviceRt);
                            }
                        }
                        serviceRtDetailIsValid(true);

                    },
                    // Do Before Logic
                    doBeforeSave = function () {
                        var flag = true;
                        if (!selectedAdditionalDriverChrgMain().isValid()) {
                            selectedAdditionalDriverChrgMain().errors.showAllMessages();
                            flag = false;
                        }
                        return flag;
                    },
                    // Save Additional Driver Charge Main
                    saveAdditionalDriverChrg = function (serviceRtMain) {
                        dataservice.saveAdditionalDriverChrg(model.AdditionalDriverChrgMainServerMapper(serviceRtMain), {
                            success: function (data) {
                                var serviceRtResult = new model.AdditionalDriverChrgMainClientMapper(data);
                                if (selectedAdditionalDriverChrgMain().serviceRtMainId() > 0) {
                                    selectedAdditionalDriverChrgMainCopy(undefined);
                                    selectedAdditionalDriverChrgMain().startDt(serviceRtResult.startDt()),
                                        closeAdditionalDriverChrgEditor();
                                } else {
                                    serviceRtMains.splice(0, 0, serviceRtResult);
                                    closeAdditionalDriverChrgEditor();
                                }
                                toastr.success(ist.resourceText.serviceRateAddSuccessMsg);
                            },
                            error: function (exceptionMessage, exceptionType) {

                                if (exceptionType === ist.exceptionType.CaresGeneralException) {

                                    toastr.error(exceptionMessage);

                                } else {

                                    toastr.error(ist.resourceText.serviceRateAddFailedMsg);

                                }

                            }
                        });
                    },
                    //Edit Additional Driver Charge
                    onEditAddDriverChrg = function (serviceRt, e) {
                        //selectedAdditionalDriverChrgMain(serviceRt);
                        //selectedAdditionalDriverChrgMainCopy(model.InsuranceRtMainCopier(serviceRt));
                        //getAdditionalDriverChrgItems(serviceRt);
                        showAdditionalDriverChrgEditor();
                        e.stopImmediatePropagation();
                    },
                    // Delete a Additional Driver Charge
                    onDeleteAddDriverChrg = function (serviceRt) {
                        //if (!serviceRt.serviceRtMainId()) {
                        //    serviceRtMains.remove(serviceRt);
                        //    return;
                        //}
                        //// Ask for confirmation
                        //confirmation.afterProceed(function () {
                        //    deleteAdditionalDriverChrg(serviceRt);
                        //});
                        //confirmation.show();
                    },
                    // Delete Additional Driver Charge
                    deleteAdditionalDriverChrg = function (serviceRt) {
                        dataservice.deleteAdditionalDriverChrg(serviceRt.convertToServerData(), {
                            success: function () {
                                serviceRtMains.remove(serviceRt);
                                toastr.success(ist.resourceText.serviceRateDeleteSuccessMsg);
                            },
                            error: function () {
                                toastr.error(ist.resourceText.serviceRateDeleteFailedMsg);
                            }
                        });
                    },
                    // Show Additional Driver Charge Editor
                    showAdditionalDriverChrgEditor = function () {
                        isAdditionalDriverChrgEditorVisible(true);
                    },
                    closeAdditionalDriverChrgEditor = function () {
                        isAdditionalDriverChrgEditorVisible(false);
                    },
                    // Get Additional Driver Charges
                    getAddDriverChrgs = function () {
                        isLoadingAdditionalDriverChrg(true);
                        dataservice.getAddDriverChrgs({
                            TariffTypeId: tariffTypeFilter(),
                            OperationId: operationFilter(),
                            PageSize: pager().pageSize(),
                            PageNo: pager().currentPage(),
                            SortBy: sortOn(),
                            IsAsc: sortIsAsc()
                        }, {
                            success: function (data) {
                                pager().totalCount(data.TotalCount);
                                addDriverChrgs.removeAll();
                                mapAddDriverChrgs(data);
                                isLoadingAdditionalDriverChrg(false);
                            },
                            error: function () {
                                isLoadingAdditionalDriverChrg(false);
                                toastr.error(ist.resourceText.serviceRatesLoadFailedMsg);
                            }
                        });
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
                        if (department.depId() != undefined) {
                            _.each(operations(), function (item) {
                                if (item.DepartmentId === department.depId())
                                    filteredOperations.push(item);
                            });
                            filteredOperations.valueHasMutated();
                        }
                    },
                    //on selected Operation 
                    onSelectedOperation = function (operation) {
                        filteredTariffTypes.removeAll();
                        if (operation.operationId() != undefined) {
                            _.each(tariffTypes(), function (item) {
                                if (item.OperationId === operation.operationId())
                                    filteredTariffTypes.push(item);
                            });
                            filteredTariffTypes.valueHasMutated();
                        }
                    };
                // #endregion Service Calls

                return {
                    // Observables
                    selectedAdditionalDriverChrg: selectedAdditionalDriverChrg,
                    isLoadingAdditionalDriverChrg: isLoadingAdditionalDriverChrg,
                    isAdditionalDriverChrgEditorVisible: isAdditionalDriverChrgEditorVisible,
                    sortOn: sortOn,
                    sortIsAsc: sortIsAsc,
                    sortOnHg: sortOnHg,
                    sortIsAscHg: sortIsAscHg,
                    isEditable: isEditable,
                    filterSectionVisilble: filterSectionVisilble,
                    //Arrays
                    companies: companies,
                    departments: departments,
                    addDriverChrgs: addDriverChrgs,
                    operations: operations,
                    tariffTypes: tariffTypes,
                    filteredDepartments: filteredDepartments,
                    filteredOperations: filteredOperations,
                    filteredTariffTypes: filteredTariffTypes,
                    //Filters
                    operationFilter: operationFilter,
                    tariffTypeFilter: tariffTypeFilter,
                    searchFilter: searchFilter,
                    // Utility Methods
                    initialize: initialize,
                    search: search,
                    pager: pager,
                    collapseFilterSection: collapseFilterSection,
                    showFilterSection: showFilterSection,
                    closeAdditionalDriverChrgEditor: closeAdditionalDriverChrgEditor,
                    showAdditionalDriverChrgEditor: showAdditionalDriverChrgEditor,
                    onSaveAdditionalDriverChrg: onSaveAdditionalDriverChrg,
                    reset: reset,
                    onEditAddDriverChrg: onEditAddDriverChrg,
                    onDeleteAddDriverChrg: onDeleteAddDriverChrg,
                    createAddDriverChrg: createAddDriverChrg,
                    getAddDriverChrgs: getAddDriverChrgs,
                    onSelectedCompany: onSelectedCompany,
                    onSelectedDepartemnt: onSelectedDepartemnt,
                    onSelectedOperation: onSelectedOperation,

                    // Utility Methods

                };
            })()
        };
        return ist.additionalDriverCharge.viewModel;
    });
