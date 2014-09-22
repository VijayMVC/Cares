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
                    //Add/Edit Additional Driver Charge 
                   addEditAdditionalDriverChrg = ko.observable(),
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
                    //Additional Driver Charge Revisions
                    revisions = ko.observableArray([]),
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
                    //Get Additional Driver Charge By Id
                    getAdditionalDriverChrgsById = function (addDriverChrg) {
                        isLoadingAdditionalDriverChrg(true);
                        dataservice.getAdditionalDriverChrgDetail(model.AdditionalDriverChrgServerMapperForId(addDriverChrg), {
                            success: function (data) {
                                revisions.removeAll();
                                _.each(data, function (item) {
                                    var revision = new model.AdditionalDriverChargeRevisionClientMapper(item);
                                    revisions.push(revision);
                                });
                                isLoadingAdditionalDriverChrg(false);
                            },
                            error: function () {
                                isLoadingAdditionalDriverChrg(false);
                                toastr.error(ist.resourceText.loadAddDriverChargeDetailFailedMsg);
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
                        revisions.removeAll();
                        filteredDepartments.removeAll();
                        filteredOperations.removeAll();
                        filteredTariffTypes.removeAll();
                        var addDrvierChrg = new model.AdditionalDriverCharge();
                        // Select the newly added Additional Driver Charge
                        selectedAdditionalDriverChrg(addDrvierChrg);
                        addEditAdditionalDriverChrg(addDrvierChrg);
                        showAdditionalDriverChrgEditor();
                    },
                    // Save Additional Driver Charge
                    onSaveAdditionalDriverChrg = function (addDriverChrg) {
                        if (doBeforeSave()) {
                            saveAdditionalDriverChrg(addDriverChrg);
                        }
                    },
                    // Do Before Logic
                    doBeforeSave = function () {
                        var flag = true;
                        if (!addEditAdditionalDriverChrg().isValid()) {
                            selectedAdditionalDriverChrg().errors.showAllMessages();
                            flag = false;
                        }
                        return flag;
                    },
                    // Save Additional Driver Charge Main
                    saveAdditionalDriverChrg = function (addDriverChrg) {
                        dataservice.saveAdditionalDriverChrg(model.AdditionalDriverChrgServerMapper(addDriverChrg), {
                            success: function (data) {
                                var additionalDriverCharge = model.AdditionalDriverChargeClientMapper(data);
                                if (selectedAdditionalDriverChrg().id() > 0) {
                                    selectedAdditionalDriverChrg().id(additionalDriverCharge.id()),
                                    selectedAdditionalDriverChrg().companyId(additionalDriverCharge.companyId()),
                                    selectedAdditionalDriverChrg().companyCodeName(additionalDriverCharge.companyCodeName()),
                                    selectedAdditionalDriverChrg().depId(additionalDriverCharge.depId()),
                                    selectedAdditionalDriverChrg().operationId(additionalDriverCharge.operationId()),
                                    selectedAdditionalDriverChrg().operationCodeName(additionalDriverCharge.operationCodeName()),
                                    selectedAdditionalDriverChrg().tariffTypeId(additionalDriverCharge.tariffTypeId()),
                                    selectedAdditionalDriverChrg().tariffTypeCode(additionalDriverCharge.tariffTypeCode()),
                                    selectedAdditionalDriverChrg().tariffTypeCodeName(additionalDriverCharge.tariffTypeCodeName()),
                                    selectedAdditionalDriverChrg().effectiveStartDate(additionalDriverCharge.effectiveStartDate()),
                                    selectedAdditionalDriverChrg().rate(additionalDriverCharge.rate()),
                                    selectedAdditionalDriverChrg().revisionNumber(additionalDriverCharge.revisionNumber()),
                                    closeAdditionalDriverChrgEditor();
                                } else {
                                    addDriverChrgs.splice(0, 0, additionalDriverCharge);
                                    closeAdditionalDriverChrgEditor();
                                }
                                toastr.success(ist.resourceText.additionalDriverChargeAddSuccessMsg);
                            },
                            error: function (exceptionMessage, exceptionType) {

                                if (exceptionType === ist.exceptionType.CaresGeneralException) {

                                    toastr.error(exceptionMessage);

                                } else {

                                    toastr.error(ist.resourceText.ist.resourceText.additionalDriverChargeAddFailedMsg);

                                }

                            }
                        });
                    },

                companyId = ko.computed(function () {
                    if (addEditAdditionalDriverChrg() !== undefined) {
                        filteredDepartments.removeAll();
                        _.each(departments(), function (item) {
                            if (item.CompanyId === addEditAdditionalDriverChrg().companyId())
                                filteredDepartments.push(item);
                        });
                    }
                }, this),
                   depId = ko.computed(function () {
                       if (addEditAdditionalDriverChrg() !== undefined) {
                           filteredOperations.removeAll();
                           _.each(operations(), function (item) {
                               if (item.DepartmentId === addEditAdditionalDriverChrg().depId())
                                   filteredOperations.push(item);
                           });
                       }
                   }, this),
                    operationId = ko.computed(function () {
                        if (addEditAdditionalDriverChrg() !== undefined) {
                            //tariffTypes.removeAll();
                            _.each(tariffTypes(), function (item) {
                                if (item.OperationId === addEditAdditionalDriverChrg().operationId())
                                    filteredTariffTypes.push(item);
                            });
                        }
                    }, this),
                    //Edit Additional Driver Charge
                    onEditAddDriverChrg = function (addDriverChrg, e) {
                        revisions.removeAll();
                        selectedAdditionalDriverChrg(addDriverChrg);
                        addEditAdditionalDriverChrg(addDriverChrg);
                        //addEditAdditionalDriverChrg().depId(addDriverChrg.depId());
                        //addEditAdditionalDriverChrg().tariffTypeId(addDriverChrg.tariffTypeId());
                        getAdditionalDriverChrgsById(addDriverChrg);
                        showAdditionalDriverChrgEditor();
                        e.stopImmediatePropagation();
                    },
                    // Delete a Additional Driver Charge
                    onDeleteAddDriverChrg = function (addDriverChrg) {
                        if (!addDriverChrg.id()) {
                            addDriverChrgs.remove(addDriverChrg);
                            return;
                        }
                        // Ask for confirmation
                        confirmation.afterProceed(function () {
                            deleteAdditionalDriverChrg(addDriverChrg);
                        });
                        confirmation.show();
                    },
                    // Delete Additional Driver Charge
                    deleteAdditionalDriverChrg = function (addDriverChrg) {
                        dataservice.deleteAdditionalDriverChrg(model.AdditionalDriverChrgServerMapperForId(addDriverChrg), {
                            success: function () {
                                addDriverChrgs.remove(addDriverChrg);
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
                                toastr.error(ist.resourceText.additionalDriverChargeLoadFailedMsg);
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
                    addEditAdditionalDriverChrg: addEditAdditionalDriverChrg,
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
                    revisions: revisions,
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
