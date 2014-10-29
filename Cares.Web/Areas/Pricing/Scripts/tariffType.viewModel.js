/*
    Module with the view model for the tariff type
*/
define("tariffType/tariffType.viewModel",
    ["jquery", "amplify", "ko", "tariffType/tariffType.dataservice", "tariffType/tariffType.model", "common/confirmation.viewModel", "common/pagination"],
    function ($, amplify, ko, dataservice, model, confirmation, pagination) {
        var ist = window.ist || {};
        ist.tariffType = {
            viewModel: (function () {
                var // the view 
                    view,
                    // Active tariff Type
                    selectedTariffType = ko.observable(),
                     //Add Or Edit Tariff Type
                    addTariffType = ko.observable(),
                    // #region Arrays
                    //tariff Types
                    tariffTypes = ko.observableArray([]),
                    // Companies
                    companies = ko.observableArray([]),
                     // Pricing Strategies
                    pricingStrategies = ko.observableArray([]),
                    // Measurement units
                    measurementUnits = ko.observableArray([]),
                    // Departments
                    departments = ko.observableArray([]),
                    //Filterd Departments
                     filteredDepartments = ko.observableArray([]),
                    //Revision List
                    revisions = ko.observableArray([]),
                    //For Edit, Tariff Type Id
                    selectedTariffTypeId = ko.observable(),
                    // Operations
                    operations = ko.observableArray([]),
                     // Filtered Operations
                    filteredOperations = ko.observableArray([]),
                     // #endregion Arrays
                    // #region Busy Indicators
                    isLoadingTariffTypes = ko.observable(false),
                    // #endregion Busy Indicators
                    // #region Observables
                    // Sort On
                    sortOn = ko.observable(1),
                    // Sort Order -  true means asc, false means desc
                    sortIsAsc = ko.observable(true),
                    // Is tariff Type Editor Visible
                    isTariffTypeEditorVisible = ko.observable(false),
                     // Pagination
                    pager = ko.observable(),
                    // Show Filter Section
                    filterSectionVisilble = ko.observable(false),
                    // tariff Type Code filter
                    tariffTypeCodeFilter = ko.observable(),
                    // Company Filter
                    companyFilter = ko.observable(),
                    // Measurement Unit  Filter
                    measurementUnitFilter = ko.observable(),
                    //tariff Type Name  Filter
                    tariffTypeNameFilter = ko.observable(),
                    //Department Filter
                    departmentFilter = ko.observable(),
                    //Operation Filter
                    operationFilter = ko.observable(),
                    // #region Utility Functions
                    // Select a tariff Type
                    selecttariffType = function (tariffType) {
                        selectedTariffType(tariffType);
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
                    // Initialize the view model
                    initialize = function (specifiedView) {
                        view = specifiedView;
                        ko.applyBindings(view.viewModel, view.bindingRoot);
                        getBase();
                        // Set Pager
                        pager(pagination.Pagination({}, tariffTypes, getTariffType));
                        getTariffType();
                    },
                    //Template For Revision List
                    templateToUseForRevision = function () {
                        return 'itemtariffTypeRevisionTemplate';
                    },
                    // Map tariff Types - Server to Client
                    maptariffTypes = function (data) {
                        var tariffTypeList = [];
                        _.each(data.ServertariffTypes, function (item) {
                            var tariffType = new model.TariffType(item);
                            tariffTypeList.push(tariffType);

                        });
                        ko.utils.arrayPushAll(tariffTypes(), tariffTypeList);
                        tariffTypes.valueHasMutated();
                    },
                    // Get Base
                    getBase = function () {
                        dataservice.getTariffTypeBase({
                            success: function (data) {
                                //Company array
                                companies.removeAll();
                                ko.utils.arrayPushAll(companies(), data.ResponseCompanies);
                                companies.valueHasMutated();
                                //Measurement Units array
                                measurementUnits.removeAll();
                                ko.utils.arrayPushAll(measurementUnits(), data.ResponseMeasurementUnits);
                                measurementUnits.valueHasMutated();
                                //Departments array
                                departments.removeAll();
                                ko.utils.arrayPushAll(departments(), data.ResponseDepartments);
                                departments.valueHasMutated();
                                //Operations Array
                                operations.removeAll();
                                ko.utils.arrayPushAll(operations(), data.ResponseOperations);
                                operations.valueHasMutated();
                                //Pricing Strategies
                                pricingStrategies.removeAll();
                                ko.utils.arrayPushAll(pricingStrategies(), data.ResponsePricingStrategies);
                                pricingStrategies.valueHasMutated();
                            },
                            error: function () {
                                toastr.error(ist.resourceText.loadBaseDataFailedMsg);
                            }
                        });
                    },
                    // Search 
                    search = function () {
                        pager().reset();
                        getTariffType();
                    },
                    //Reset
                      reset = function () {
                          tariffTypeCodeFilter(undefined);
                          operationFilter(undefined);
                          measurementUnitFilter(undefined);
                          search();
                      },
                    // Get tariff Types
                    getTariffType = function () {
                        isLoadingTariffTypes(true);
                        dataservice.getTariffType({
                            SearchString: tariffTypeCodeFilter(),
                            CompanyId: companyFilter(),
                            MeasurementUnitId: measurementUnitFilter(),
                            tariffTypeName: tariffTypeNameFilter(),
                            DepartmentId: departmentFilter(),
                            OperationId: operationFilter(),
                            PageSize: pager().pageSize(),
                            PageNo: pager().currentPage(),
                            SortBy: sortOn(),
                            IsAsc: sortIsAsc()
                        }, {
                            success: function (data) {
                                pager().totalCount(data.TotalCount);
                                tariffTypes.removeAll();
                                maptariffTypes(data);
                                isLoadingTariffTypes(false);
                            },
                            error: function () {
                                isLoadingTariffTypes(false);
                                toastr.error(ist.resourceText.loadTariffTypesFailedMsg);
                            }
                        });
                    },
                     // Create Tariff Type
                    createTariffType = function () {
                        revisions.removeAll();
                        var tariffType = new model.TariffTypeDetail();
                        // Select the newly added tariffType
                        addTariffType(tariffType);
                    },
                    // Do Before Logic
                    validation = function () {
                        var flag = true;
                        var measurementUnitKey;
                        _.each(measurementUnits(), function (item) {
                            if (item.MeasurementUnitId == addTariffType().measurementUnitId()) {
                                measurementUnitKey = item.MeasurementUnitKey;
                            }

                        });
                        //For Minute
                        if (measurementUnitKey === 1) {
                            if (addTariffType().durationFrom() <= 0 || addTariffType().durationFrom() > 59 || addTariffType().durationTo() <= 0 || addTariffType().durationTo() > 59
                                ) {
                                toastr.error("Start From and End To values always between 1 to 59.");
                                flag = false;
                            }
                            else if (addTariffType().durationTo() > addTariffType().durationFrom()) {
                                toastr.error("End To must greater than Start From.");
                                flag = false;
                            }

                        }
                        //For Hours
                        if (measurementUnitKey === 2) {
                            if (addTariffType().durationFrom() <= 0 || addTariffType().durationFrom() > 23 || addTariffType().durationTo() <= 0 || addTariffType().durationTo() > 23
                               ) {
                                toastr.error("Start From and End To values always between 1 to 23.");
                                flag = false;
                            }
                            else if (addTariffType().durationTo() > addTariffType().durationFrom()) {
                                toastr.error("End To must greater than Start From.");
                                flag = false;
                            }
                        }
                        return flag;
                    },
                     // Save Tariff Type
                    onSaveTariffType = function (tariffType) {
                        if (doBeforeSave() && validation()) {
                            if (addTariffType().tariffTypeId() > 0) {
                                var date = new Date();
                                date.setHours(0, 0, 0, 0);
                                if (addTariffType().effectiveDate() >= date) {

                                    // Commits and Selects the Row
                                    saveTariffType(tariffType);
                                } else {
                                    toastr.error('Effective Date must be a current or future date.');
                                }
                            } else {
                                // Commits and Selects the Row
                                saveTariffType(tariffType);
                            }

                        }

                    },
                       // Save Tariff Type
                    saveTariffType = function (tariffType) {
                        var method = "updateTariffType";
                        if (!addTariffType().tariffTypeId()) {
                            method = "createTariffType";
                        }

                        dataservice[method](model.TariffTypeServerMapper(tariffType), {
                            success: function (data) {
                                var tariffTypeResult = new model.TariffType(data);
                                if (addTariffType().tariffTypeId() > 0) {
                                    selectedTariffType().tariffTypeId(data.TariffTypeId);
                                    selectedTariffType().measurementUnit(data.MeasurementUnit),
                                    selectedTariffType().tariffTypeCode(data.TariffTypeCode),
                                    selectedTariffType().tariffTypeName(data.TariffTypeName),
                                    selectedTariffType().pricingScheme(data.PricingScheme),
                                    selectedTariffType().company(data.Company),
                                    selectedTariffType().operation(data.Operation),
                                    selectedTariffType().gracePeriod(data.GracePeriod),
                                    selectedTariffType().effectiveDate(moment(data.EffectiveDate).format(ist.datePattern)),
                                    selectedTariffType().durationFrom(data.DurationFrom),
                                    selectedTariffType().revisionNumber(data.RevisionNumber),
                                    selectedTariffType().durationTo(data.DurationTo),
                                    closeTariffTypeEditor();
                                } else {
                                    tariffTypes.splice(0, 0, tariffTypeResult);

                                }
                                // Reset Changes
                                //addTariffType().reset();
                                if (isTariffTypeEditorVisible) {
                                    closeTariffTypeEditor();
                                }

                                toastr.success(ist.resourceText.tariffTypeAddSuccess);
                            },
                            error: function (exceptionMessage, exceptionType) {

                                if (exceptionType === ist.exceptionType.CaresGeneralException) {

                                    toastr.error(exceptionMessage);

                                } else {

                                    toastr.error(ist.resourceText.tariffTypeSaveFailedMsg);

                                }

                            }
                        });
                    },
                    // Do Before Logic
                    doBeforeSave = function () {
                        var flag = true;
                        if (!addTariffType().isValid()) {
                            addTariffType().errors.showAllMessages();
                            flag = false;
                        }
                        return flag;
                    },


                    //Create Tariff Type In Form 
                    createTariffTypeInForm = function () {
                        createTariffType();
                        showTariffTypeEditor();
                    },
                     companyId = ko.computed(function () {
                         if (addTariffType() !== undefined) {
                             filteredDepartments.removeAll();
                             _.each(departments(), function (item) {
                                 if (item.CompanyId === addTariffType().companyId())
                                     filteredDepartments.push(item);
                             });
                         }
                     }, this),
                         depId = ko.computed(function () {
                             if (addTariffType() !== undefined) {
                                 filteredOperations.removeAll();
                                 _.each(operations(), function (item) {
                                     if (item.DepartmentId === addTariffType().departmentId())
                                         filteredOperations.push(item);
                                 });
                             }
                         }, this),

                     //Edit Tariff Type
                    onEditTariffType = function (tariffType, e) {
                        selectedTariffTypeId(tariffType.tariffTypeId());
                        selectedTariffType(tariffType);
                        getTariffTypeById();
                        showTariffTypeEditor();
                        e.stopImmediatePropagation();
                    },
                    //Get Tariff Type By Id
                    getTariffTypeById = function () {
                        isLoadingTariffTypes(true);
                        dataservice.getTariffTypeById({
                            id: selectedTariffTypeId()

                        }, {
                            success: function (data) {
                                addTariffType(model.TariffTypeClientMapper(data.TariffType));
                                revisions.removeAll();
                                _.each(data.TariffTypeRevisions, function (item) {
                                    revisions.push(new model.TariffTypeClientMapper(item));
                                });

                                isLoadingTariffTypes(false);
                            },
                            error: function () {
                                isLoadingTariffTypes(false);
                                toastr.error(ist.resourceText.tariffTypeDetailFailedMsg);
                            }
                        });
                    },
                    // Collapase filter section
                    collapseFilterSection = function () {
                        filterSectionVisilble(false);
                    },
                    //Show filter section
                    showFilterSection = function () {
                        filterSectionVisilble(true);
                    },
                     // close Product Editor
                    closeTariffTypeEditor = function () {
                        isTariffTypeEditorVisible(false);
                    },
                    // Show Tariff Type Editor
                    showTariffTypeEditor = function () {
                        isTariffTypeEditorVisible(true);
                    };
                // #endregion Service Calls

                return {
                    // Observables
                    selectedTariffType: selectedTariffType,
                    addTariffType: addTariffType,
                    selectedTariffTypeId: selectedTariffTypeId,
                    tariffTypes: tariffTypes,
                    companies: companies,
                    measurementUnits: measurementUnits,
                    departments: departments,
                    filteredDepartments: filteredDepartments,
                    operations: operations,
                    filteredOperations: filteredOperations,
                    revisions: revisions,
                    pricingStrategies: pricingStrategies,
                    isLoadingTariffTypes: isLoadingTariffTypes,
                    sortOn: sortOn,
                    sortIsAsc: sortIsAsc,
                    tariffTypeCodeFilter: tariffTypeCodeFilter,
                    companyFilter: companyFilter,
                    measurementUnitFilter: measurementUnitFilter,
                    tariffTypeNameFilter: tariffTypeNameFilter,
                    departmentFilter: departmentFilter,
                    operationFilter: operationFilter,
                    // Observables
                    // Utility Methods
                    initialize: initialize,
                    templateToUseForRevision: templateToUseForRevision,
                    selecttariffType: selecttariffType,
                    search: search,
                    getTariffType: getTariffType,
                    getBase: getBase,
                    pager: pager,
                    isTariffTypeEditorVisible: isTariffTypeEditorVisible,
                    onEditTariffType: onEditTariffType,
                    showTariffTypeEditor: showTariffTypeEditor,
                    createTariffTypeInForm: createTariffTypeInForm,
                    createTariffType: createTariffType,
                    onSaveTariffType: onSaveTariffType,
                    saveTariffType: saveTariffType,
                    getTariffTypeById: getTariffTypeById,
                    closeTariffTypeEditor: closeTariffTypeEditor,
                    filterSectionVisilble: filterSectionVisilble,
                    collapseFilterSection: collapseFilterSection,
                    showFilterSection: showFilterSection,
                    onSelectedCompany: onSelectedCompany,
                    onSelectedDepartemnt: onSelectedDepartemnt,
                    reset: reset
                    // Utility Methods
                };
            })()
        };
        return ist.tariffType.viewModel;
    });
