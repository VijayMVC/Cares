/*
    Module with the view model for the Tarrif type
*/
define("tarrifType/tarrifType.viewModel",
    ["jquery", "amplify", "ko", "tarrifType/tarrifType.dataservice", "tarrifType/tarrifTypeWithKoMapping.model", "common/confirmation.viewModel", "common/pagination"],
    function ($, amplify, ko, dataservice, model, confirmation, pagination) {

        var ist = window.ist || {};
        ist.tarrifType = {
            viewModel: (function () {
                var // the view 
                    view,
                    // Active Tarrif Type
                    selectedTarrifType = ko.observable(),
                     // Add Or Edit Tariff Type
                    addTarrifType = ko.observable(),
                    // #region Arrays
                    //Tarrif Types
                    tarrifTypes = ko.observableArray([]),
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
                    isLoadingTarrifTypes = ko.observable(false),
                    // #endregion Busy Indicators
                    // #region Observables
                    // Sort On
                    sortOn = ko.observable(1),
                    // Sort Order -  true means asc, false means desc
                    sortIsAsc = ko.observable(true),
                    // Is Tarrif Type Editor Visible
                    isTarrifTypeEditorVisible = ko.observable(false),
                    // Is Editable
                    isEditable = ko.observable(false),
                    // Pagination
                    pager = ko.observable(),
                    // Show Filter Section
                    filterSectionVisilble = ko.observable(false),
                    // Tarrif Type Code filter
                    tarrifTypeCodeFilter = ko.observable(),
                    // Company Filter
                    companyFilter = ko.observable(),
                    // Measurement Unit  Filter
                    measurementUnitFilter = ko.observable(),
                    //Tarrif Type Name  Filter
                    tarrifTypeNameFilter = ko.observable(),
                    //Department Filter
                    departmentFilter = ko.observable(),
                    //Operation Filter
                    operationFilter = ko.observable(),
                    // #region Utility Functions
                    //// Select a tarrif Type
                    selectTarrifType = function (tarrifType) {
                        selectedTarrifType(tarrifType);
                       //if (selectedTarrifType() && selectedTarrifType().hasChanges()) {
                       //     return;
                       // }
                       // if (selectedTarrifType() !== tarrifType) {
                       //     selectedTarrifType(tarrifType);
                       //}
                       // isEditable(false);
                    },
                    // Initialize the view model
                    initialize = function (specifiedView) {
                        view = specifiedView;
                        ko.applyBindings(view.viewModel, view.bindingRoot);
                        getBase();
                        // Set Pager
                        pager(pagination.Pagination({}, tarrifTypes, getTarrifType));
                        getTarrifType();
                    },
                    // Template Chooser
                    templateToUse = function (tarrifType) {
                        return (tarrifType === selectedTarrifType() ? '' : 'itemTarrifTypeTemplate');
                    },
                    templateToUseForRevision = function () {
                         return 'itemTarrifTypeRevisionTemplate';
                     },
                    // Map Tarrif Types - Server to Client
                    mapTarrifTypes = function (data) {
                        var tarrifTypeList = [];
                        _.each(data.ServerTarrifTypes, function (item) {
                            var tarrifType = new model.TarrifType(item);
                            tarrifTypeList.push(tarrifType);

                        });

                        ko.utils.arrayPushAll(tarrifTypes(), tarrifTypeList);
                        tarrifTypes.valueHasMutated();
                    },
                    // Get Base
                    getBase = function () {
                        dataservice.getTarrifTypeBase({
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
                        getTarrifType();
                    },
                    // Get Tarrif Types
                    getTarrifType = function () {
                        isLoadingTarrifTypes(true);
                        dataservice.getTarrifType({
                            TarrifTypeCode: tarrifTypeCodeFilter(),
                            CompanyId: companyFilter(),
                            MeasurementUnitId: measurementUnitFilter(),
                            TarrifTypeName: tarrifTypeNameFilter(),
                            DepartmentId: departmentFilter(),
                            OperationId: operationFilter(),
                            PageSize: pager().pageSize(),
                            PageNo: pager().currentPage(),
                            SortBy: sortOn(),
                            IsAsc: sortIsAsc()
                        }, {
                            success: function (data) {
                                pager().totalCount(data.TotalCount);
                                tarrifTypes.removeAll();
                                mapTarrifTypes(data);
                                isLoadingTarrifTypes(false);
                            },
                            error: function () {
                                isLoadingTarrifTypes(false);
                                toastr.error("Failed to load Tarrif types!");
                            }
                        });
                    },
                     // Create Tariff Type
                    createTariffType = function () {
                        var tariffType = new model.TarrifTypeDetail();
                          // Select the newly added tariffType
                        addTarrifType(tariffType);
                    },
                     // Save Tariff Type
                    onSaveTariffType = function (tariffType) {
                        if (doBeforeSelect()) {
                            if (addTarrifType().tarrifTypeId() > 0) {
                                var date = new Date();
                                if (addTarrifType().effectiveDate() >= date) {
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
                        var method = "updateTarrifType";
                        if (!addTarrifType().tarrifTypeId()) {
                            method = "createTarrifType";
                        }

                        dataservice[method](model.TariffTypeServerMapper(tariffType), {
                            success: function (data) {
                                var tarrifType = new model.TarrifType(data);
                                if (addTarrifType().tarrifTypeId() > 0) {
                                    selectedTarrifType().tariffTypeId(data.TariffTypeId);
                                    selectedTarrifType().measurementUnit(data.MeasurementUnit),
                                    selectedTarrifType().tariffTypeCode(data.TariffTypeCode),
                                    selectedTarrifType().tarrifTypeName(data.TariffTypeName),
                                    selectedTarrifType().pricingScheme(data.PricingScheme),
                                    selectedTarrifType().company(data.Company),
                                    selectedTarrifType().operation(data.Operation),
                                    selectedTarrifType().gracePeriod(data.GracePeriod),
                                    selectedTarrifType().effectiveDate(moment(data.EffectiveDate).format(ist.datePattern)),                                    
                                    selectedTarrifType().durationFrom(data.DurationFrom),
                                    selectedTarrifType().revisionNumber(data.RevisionNumber),
                                    selectedTarrifType().durationTo(data.DurationTo),
                                    closeTariffTypeEditor();
                                } else {
                                    tarrifTypes.splice(0, 0, tarrifType);

                                }
                                // Reset Changes
                                //addTarrifType().reset();
                                if (isTarrifTypeEditorVisible) {
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
                    doBeforeSelect = function () {
                        var flag = true;
                        if (!addTarrifType().isValid()) {
                            addTarrifType().errors.showAllMessages();
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
                        selectedTarrifType(tariffType);
                        getTarrifTypeById();
                        showTariffTypeEditor();
                        e.stopImmediatePropagation();
                    },
                    //Get Tariff Type By Id
                    getTarrifTypeById = function () {
                        isLoadingTarrifTypes(true);
                        dataservice.getTarrifTypeById({
                            id: selectedTariffTypeId()

                        }, {
                            success: function (data) {
                                addTarrifType(model.TariffTypeClientMapper(data.TarrifType));
                                revisions.removeAll();
                                _.each(data.TarrifTypeRevisions, function (item) {
                                    revisions.push(new model.TariffTypeClientMapper(item));
                                });
                                //ko.utils.arrayPushAll(revisions(), data.TarrifTypeRevisions);
                                //revisions.valueHasMutated();
                                isLoadingTarrifTypes(false);
                            },
                            error: function () {
                                isLoadingTarrifTypes(false);
                                toastr.error("Error!");
                            }
                        });
                    },
                    // Collapase filter section
                    collapseFilterSection = function() {
                        filterSectionVisilble(false);
                    },
                    //Show filter section
                    showFilterSection = function () {
                        filterSectionVisilble(true);
                    },
                     // close Product Editor
                    closeTariffTypeEditor = function () {
                        isTarrifTypeEditorVisible(false);
                    },
                    // Show Tariff Type Editor
                    showTariffTypeEditor = function () {
                        isTarrifTypeEditorVisible(true);
                    };
                // #endregion Service Calls

                return {
                    // Observables
                    selectedTarrifType: selectedTarrifType,
                    addTarrifType: addTarrifType,
                    selectedTariffTypeId: selectedTariffTypeId,
                    tarrifTypes: tarrifTypes,
                    companies: companies,
                    measurementUnits: measurementUnits,
                    departments: departments,
                    operations: operations,
                    revisions: revisions,
                    pricingStrategies: pricingStrategies,
                    isLoadingTarrifTypes: isLoadingTarrifTypes,
                    sortOn: sortOn,
                    sortIsAsc: sortIsAsc,
                    isEditable: isEditable,
                    tarrifTypeCodeFilter: tarrifTypeCodeFilter,
                    companyFilter: companyFilter,
                    measurementUnitFilter: measurementUnitFilter,
                    tarrifTypeNameFilter: tarrifTypeNameFilter,
                    departmentFilter: departmentFilter,
                    operationFilter: operationFilter,
                    // Observables
                    // Utility Methods
                    initialize: initialize,
                    templateToUse: templateToUse,
                    templateToUseForRevision: templateToUseForRevision,
                    selectTarrifType: selectTarrifType,
                    search: search,
                    getTarrifType: getTarrifType,
                    getBase: getBase,
                    pager: pager,
                    isTarrifTypeEditorVisible: isTarrifTypeEditorVisible,
                    onEditTariffType: onEditTariffType,
                    showTariffTypeEditor: showTariffTypeEditor,
                    createTariffTypeInForm: createTariffTypeInForm,
                    createTariffType: createTariffType,
                    onSaveTariffType: onSaveTariffType,
                    saveTariffType: saveTariffType,
                    getTarrifTypeById: getTarrifTypeById,
                    closeTariffTypeEditor: closeTariffTypeEditor,
                    filterSectionVisilble: filterSectionVisilble,
                    collapseFilterSection: collapseFilterSection,
                    showFilterSection: showFilterSection
                    // Utility Methods
                };
            })()
        };
        return ist.tarrifType.viewModel;
    });
