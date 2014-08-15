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
                    selectedtariffType = ko.observable(),
                     //Add Or Edit Tariff Type
                    addtariffType = ko.observable(),
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
                    //Revision List
                    revisions = ko.observableArray([]),
                    //For Edit, Tariff Type Id
                    selectedTariffTypeId = ko.observable(),
                    // Operations
                    operations = ko.observableArray([]),
                    // #endregion Arrays
                    // #region Busy Indicators
                    isLoadingtariffTypes = ko.observable(false),
                    // #endregion Busy Indicators
                    // #region Observables
                    // Sort On
                    sortOn = ko.observable(1),
                    // Sort Order -  true means asc, false means desc
                    sortIsAsc = ko.observable(true),
                    // Is tariff Type Editor Visible
                    istariffTypeEditorVisible = ko.observable(false),
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
                        selectedtariffType(tariffType);
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
                                toastr.error("Failed to load base data");
                            }
                        });
                    },
                    // Search 
                    search = function () {
                        pager().reset();
                        getTariffType();
                    },
                    // Get tariff Types
                    getTariffType = function () {
                        isLoadingtariffTypes(true);
                        dataservice.getTariffType({
                            tariffTypeCode: tariffTypeCodeFilter(),
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
                                isLoadingtariffTypes(false);
                            },
                            error: function () {
                                isLoadingtariffTypes(false);
                                toastr.error("Failed to load tariff types!");
                            }
                        });
                    },
                     // Create Tariff Type
                    createTariffType = function () {
                        var tariffType = new model.TariffTypeDetail();
                        // Select the newly added tariffType
                            addtariffType(tariffType);
                    },
                     // Save Tariff Type
                    onSaveTariffType = function (tariffType) {
                        if (doBeforeSave()) {
                            if (addtariffType().tariffTypeId() > 0) {
                                var date = new Date();
                                if (addtariffType().effectiveDate() >= date) {
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
                        if (!addtariffType().tariffTypeId()) {
                            method = "createTariffType";
                        }

                        dataservice[method](model.TariffTypeServerMapper(tariffType), {
                            success: function (data) {
                                var tariffTypeResult = new model.TariffType(data);
                                if (addtariffType().tariffTypeId() > 0) {
                                    selectedtariffType().tariffTypeId(data.TariffTypeId);
                                    selectedtariffType().measurementUnit(data.MeasurementUnit),
                                    selectedtariffType().tariffTypeCode(data.TariffTypeCode),
                                    selectedtariffType().tariffTypeName(data.TariffTypeName),
                                    selectedtariffType().pricingScheme(data.PricingScheme),
                                    selectedtariffType().company(data.Company),
                                    selectedtariffType().operation(data.Operation),
                                    selectedtariffType().gracePeriod(data.GracePeriod),
                                    selectedtariffType().effectiveDate(moment(data.EffectiveDate).format(ist.datePattern)),
                                    selectedtariffType().durationFrom(data.DurationFrom),
                                    selectedtariffType().revisionNumber(data.RevisionNumber),
                                    selectedtariffType().durationTo(data.DurationTo),
                                    closeTariffTypeEditor();
                                } else {
                                    tariffTypes.splice(0, 0, tariffTypeResult);

                                }
                                // Reset Changes
                                //addtariffType().reset();
                                if (istariffTypeEditorVisible) {
                                    closeTariffTypeEditor();
                                }

                                toastr.success("Tariff Type saved successfully");
                            },
                            error: function () {
                                toastr.error('Failed to save Tariff Type!');
                            }
                        });
                    },
                    // Do Before Logic
                    doBeforeSave = function () {
                        var flag = true;
                        if (!addtariffType().isValid()) {
                            addtariffType().errors.showAllMessages();
                            flag = false;
                        }
                        return flag;
                    },
                    //Create Tariff Type In Form 
                    createTariffTypeInForm = function () {
                        createTariffType();
                        showTariffTypeEditor();
                    },
                     //Edit Tariff Type
                    onEditTariffType = function (tariffType, e) {
                        selectedTariffTypeId(tariffType.tariffTypeId());
                        selectedtariffType(tariffType);
                        getTariffTypeById();
                        showTariffTypeEditor();
                        e.stopImmediatePropagation();
                    },
                    //Get Tariff Type By Id
                    getTariffTypeById = function () {
                        isLoadingtariffTypes(true);
                        dataservice.getTariffTypeById({
                            id: selectedTariffTypeId()

                        }, {
                            success: function (data) {
                                addtariffType(model.TariffTypeClientMapper(data.TariffType));
                                revisions.removeAll();
                                _.each(data.TariffTypeRevisions, function (item) {
                                    revisions.push(new model.TariffTypeClientMapper(item));
                                });

                                isLoadingtariffTypes(false);
                            },
                            error: function () {
                                isLoadingtariffTypes(false);
                                toastr.error("Error!");
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
                        istariffTypeEditorVisible(false);
                    },
                    // Show Tariff Type Editor
                    showTariffTypeEditor = function () {
                        istariffTypeEditorVisible(true);
                    };
                // #endregion Service Calls

                return {
                    // Observables
                    selectedtariffType: selectedtariffType,
                    addtariffType: addtariffType,
                    selectedTariffTypeId: selectedTariffTypeId,
                    tariffTypes: tariffTypes,
                    companies: companies,
                    measurementUnits: measurementUnits,
                    departments: departments,
                    operations: operations,
                    revisions: revisions,
                    pricingStrategies: pricingStrategies,
                    isLoadingtariffTypes: isLoadingtariffTypes,
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
                    istariffTypeEditorVisible: istariffTypeEditorVisible,
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
                    showFilterSection: showFilterSection
                    // Utility Methods
                };
            })()
        };
        return ist.tariffType.viewModel;
    });
