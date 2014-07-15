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
                    // #region Arrays
                    //Tarrif Types
                    tarrifTypes = ko.observableArray([]),
                    // Companies
                    companies = ko.observableArray([]),
                    // Measurement units
                    measurementUnits = ko.observableArray([]),
                    // Departments
                    departments = ko.observableArray([]),
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
                    // Select a tarrif Type
                    selectTarrifType = function (tarrifType) {
                        if (selectedTarrifType() && selectedTarrifType().hasChanges()) {
                            //onSaveProduct(tarrifType);
                            return;
                        }
                        if (selectedTarrifType() !== tarrifType) {
                            selectedTarrifType(tarrifType);
                        }
                        isEditable(false);
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
                            TarrifTypeCode: tarrifTypeCodeFilter(), CompanyId: companyFilter(), MeasurementUnitId: measurementUnitFilter(),
                            TarrifTypeName: tarrifTypeNameFilter(),DepartmentId:departmentFilter(),OperationId:operationFilter(), PageSize: pager().pageSize(),
                            PageNo: pager().currentPage(), SortBy: sortOn(), IsAsc: sortIsAsc()
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
                    };
               
                // #endregion Service Calls

                return {
                    // Observables
                    selectedTarrifType: selectedTarrifType,
                    tarrifTypes: tarrifTypes,
                    companies: companies,
                    measurementUnits: measurementUnits,
                    departments: departments,
                    operations: operations,
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
                    selectTarrifType: selectTarrifType,
                    search: search,
                    getTarrifType: getTarrifType,
                    getBase: getBase,
                    pager: pager,
                    isTarrifTypeEditorVisible: isTarrifTypeEditorVisible,
                    // Utility Methods
                };
            })()
        };
        return ist.tarrifType.viewModel;
    });
