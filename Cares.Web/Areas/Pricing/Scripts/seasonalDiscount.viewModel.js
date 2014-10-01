/*
    Module with the view model for the Seasonal Discount
*/
define("seasonalDiscount/seasonalDiscount.viewModel",
    ["jquery", "amplify", "ko", "seasonalDiscount/seasonalDiscount.dataservice", "seasonalDiscount/seasonalDiscount.model", "common/confirmation.viewModel", "common/pagination"],
    function ($, amplify, ko, dataservice, model, confirmation, pagination) {
        var ist = window.ist || {};
        ist.seasonalDiscount = {
            viewModel: (function () {
                var // the view 
                    view,
                    // Active Seasonal Discount Main
                    selectedSeasonalDiscountMain = ko.observable(),
                    // Active Seasonal Discount
                    selectedSeasonalDiscount = ko.observable(),
                    //Add/Edit Seasonal Discount MAin 
                    addEditSeasonalDiscountMain = ko.observable(),
                    // Show Filter Section
                    filterSectionVisilble = ko.observable(false),
                    //Show Update and Cancel button For Update Seasonal Discount 
                    showUpdateCancelBtn = ko.observable(false),
                // #region Arrays
                    //Seasonal Discounts 
                    seasonalDiscounts = ko.observableArray([]),
                    //Seasonal Discount Main Array
                    seasonalDiscountMains = ko.observableArray([]),
                    //Companies
                    companies = ko.observableArray([]),
                    //Departments
                    departments = ko.observableArray([]),
                    //filtered Departments
                    filteredDepartments = ko.observableArray([]),
                    //Operations
                    operations = ko.observableArray([]),
                    //Filtered Operations
                    filteredOperations = ko.observableArray([]),
                    //Tariff Types
                    tariffTypes = ko.observableArray([]),
                    //filter Tariff Types
                    filteredTariffTypes = ko.observableArray([]),
                    //operations Work Places
                    operationsWorkPlaces = ko.observableArray([]),
                    //Hire Groups
                    hireGroups = ko.observableArray([]),
                    //Vehicle Categories
                    vehicleCategories = ko.observableArray([]),
                    //Vehicle Makes
                    vehicleMakes = ko.observableArray([]),
                    //vehicle Models
                    vehicleModels = ko.observableArray([]),
                    //Rating Types
                    ratingTypes = ko.observableArray([]),
                    //Model Years
                    modelYears = ko.observableArray([]),
                    //Customer Types
                    customerTypes = [{ Id: 0, Text: 'Both' },
                                    { Id: 1, Text: 'Individual' },
                                    { Id: 2, Text: 'Corporate' }],
                // #endregion Arrays
                // #region Busy Indicators
                isLoadingSeasonalDiscount = ko.observable(false),
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
                // Is Seasonal Discount  Editor Visible
                isSeasonalDiscountEditorVisible = ko.observable(false),
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
                    //Model Years 
                    modelYears.removeAll();
                    ko.utils.arrayPushAll(modelYears(), modelYearsGlobal);
                    modelYears.valueHasMutated();

                    view = specifiedView;
                    ko.applyBindings(view.viewModel, view.bindingRoot);
                    getBase();
                    // Set Pager
                    pager(new pagination.Pagination({}, seasonalDiscountMains, getSeasonalDiscounts));
                    getSeasonalDiscounts();

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
                    dataservice.getSeasonalDiscountBase({
                        success: function (data) {
                            //companies 
                            companies.removeAll();
                            ko.utils.arrayPushAll(companies(), data.Companies);
                            companies.valueHasMutated();
                            //Departments
                            departments.removeAll();
                            ko.utils.arrayPushAll(departments(), data.Departments);
                            departments.valueHasMutated();
                            //Operations
                            operations.removeAll();
                            ko.utils.arrayPushAll(operations(), data.Operations);
                            operations.valueHasMutated();
                            //Tariff types
                            tariffTypes.removeAll();
                            ko.utils.arrayPushAll(tariffTypes(), data.TariffTypes);
                            tariffTypes.valueHasMutated();
                            //Operations WorkPlaces
                            operationsWorkPlaces.removeAll();
                            ko.utils.arrayPushAll(operationsWorkPlaces(), data.OperationsWorkPlaces);
                            operationsWorkPlaces.valueHasMutated();
                            //Hire Groups
                            hireGroups.removeAll();
                            ko.utils.arrayPushAll(hireGroups(), data.HireGroups);
                            hireGroups.valueHasMutated();
                            //Vehicle Categories
                            vehicleCategories.removeAll();
                            ko.utils.arrayPushAll(vehicleCategories(), data.VehicleCategories);
                            vehicleCategories.valueHasMutated();
                            //Vehicle Makes
                            vehicleMakes.removeAll();
                            ko.utils.arrayPushAll(vehicleMakes(), data.VehicleMakes);
                            vehicleMakes.valueHasMutated();
                            //Vehicle Models
                            vehicleModels.removeAll();
                            ko.utils.arrayPushAll(vehicleModels(), data.VehicleModels);
                            vehicleModels.valueHasMutated();
                            //Rating Types
                            ratingTypes.removeAll();
                            ko.utils.arrayPushAll(ratingTypes(), data.BpRatingTypes);
                            ratingTypes.valueHasMutated();
                            if (callBack && typeof callBack === 'function') {
                                callBack();
                            }
                        },
                        error: function () {
                            toastr.error(ist.resourceText.loadBaseDataFailedMsg);
                        }
                    });
                },
                //Get Seasonal Discount By Id
                getSeasonalDiscountById = function (seasonalDiscount) {
                    isLoadingSeasonalDiscount(true);
                    dataservice.getSeasonalDiscountDetail(model.SeasonalDiscountServerMapperForId(seasonalDiscount), {
                        success: function (data) {
                            seasonalDiscounts.removeAll();
                            _.each(data, function (item) {
                                var sDiscount = new model.SeasonalDiscountClientMapper(item);
                                seasonalDiscounts.push(sDiscount);
                            });
                            isLoadingSeasonalDiscount(false);
                        },
                        error: function () {
                            isLoadingSeasonalDiscount(false);
                            toastr.error(ist.resourceText.loadSeasonalDiscountDetailFailedMsg);
                        }
                    });
                },
                // Search 
                search = function () {
                    pager().reset();
                    getSeasonalDiscounts();
                },
                //Reset
                reset = function () {
                    searchFilter(undefined);
                    operationFilter(undefined);
                    tariffTypeFilter(undefined);
                    search();
                },
                // Map Seasonal Discount Main - Server to Client
                mapSeasonalDiscountMain = function (data) {
                    var seasonalDiscountMainList = [];
                    _.each(data.SeasonalDiscountMains, function (item) {
                        var seasonalDiscount = new model.SeasonalDiscountMainClientMapper(item);
                        seasonalDiscountMainList.push(seasonalDiscount);
                    });
                    ko.utils.arrayPushAll(seasonalDiscountMains(), seasonalDiscountMainList);
                    seasonalDiscountMains.valueHasMutated();
                },
                //Create Seasonal Discount
                createSeasonalDiscount = function () {
                    var seasonalDiscountMain = new model.SeasonalDiscountMain();
                    seasonalDiscounts.removeAll();
                    // Select the newly added Seasonal Discount MAin
                    selectedSeasonalDiscountMain(seasonalDiscountMain);
                    addEditSeasonalDiscountMain(seasonalDiscountMain);
                    showSeasonalDiscountEditor();
                },
                // Save Seasonal Discount Main
                onSaveSeasonalDiscountMainCharge = function (seasonalDiscnt) {
                    if (doBeforeSave()) {
                        //if (seasonalDiscnt.seasonalDiscountsList().length != 0) {
                        //    seasonalDiscnt.seasonalDiscountsList.removeAll();
                        //}
                        ko.utils.arrayPushAll(seasonalDiscnt.seasonalDiscountsList(), seasonalDiscounts());
                        saveSeasonalDiscountMain(seasonalDiscnt);
                    }
                },
                // Do Before Logic
                doBeforeSave = function () {
                    var flag = true;
                    if (!addEditSeasonalDiscountMain().isValid()) {
                        addEditSeasonalDiscountMain().errors.showAllMessages();
                        flag = false;
                    }
                    return flag;
                },
                //Add Seasonal Discount
                onAddSeasonalDiscount = function (seasonalDiscount) {
                    if (doBeforeSeasonalDiscount()) {
                        //Operations Work Places
                        _.each(operationsWorkPlaces(), function (item) {
                            if (item.OperationsWorkPlaceId === seasonalDiscount.opWorkplaceId())
                                seasonalDiscount.opWorkplaceCodeName(item.OperationsWorkPlaceCodeName);
                        });
                        //Customer Types
                        _.each(customerTypes, function (item) {
                            if (item.Id === seasonalDiscount.customerTypeId())
                                seasonalDiscount.customerTypeCodeName(item.Text);
                        });
                        //Rating Types
                        _.each(ratingTypes, function (item) {
                            if (item.BpRatingTypeId === seasonalDiscount.ratingId())
                                seasonalDiscount.ratingCodeName(item.BpRatingTypeCodeName);
                        });
                        //Hire Groups
                        _.each(hireGroups(), function (item) {
                            if (item.HireGroupId === seasonalDiscount.hireGroupId())
                                seasonalDiscount.hireGroupCodeName(item.HireGroupCodeName);
                        });
                        //Vehicle make
                        _.each(vehicleMakes(), function (item) {
                            if (item.VehicleMakeId === seasonalDiscount.vMakeId())
                                seasonalDiscount.vMakeCodeName(item.VehicleMakeCodeName);
                        });
                        //Vehicle Model
                        _.each(vehicleModels(), function (item) {
                            if (item.VehicleModeld === seasonalDiscount.vModelId())
                                seasonalDiscount.vModelCodeName(item.VehicleModelCodeName);
                        });
                        //Vehicle Category
                        _.each(vehicleCategories(), function (item) {
                            if (item.VehicleCategoryId === seasonalDiscount.vCategoryId())
                                seasonalDiscount.vCategoryCodeName(item.VehicleCategoryCodeName);
                        });
                        //Vehicle Category
                        _.each(modelYears(), function (item) {
                            if (item.Id === seasonalDiscount.modelYear())
                                seasonalDiscount.modelYearCode(item.Text);
                        });
                        if (selectedSeasonalDiscount() !== undefined) {
                            selectedSeasonalDiscount().opWorkplaceId(seasonalDiscount.opWorkplaceId());
                            selectedSeasonalDiscount().opWorkplaceCodeName(seasonalDiscount.opWorkplaceCodeName());
                            selectedSeasonalDiscount().hireGroupId(seasonalDiscount.hireGroupId());
                            selectedSeasonalDiscount().hireGroupCodeName(seasonalDiscount.hireGroupCodeName());
                            selectedSeasonalDiscount().vMakeId(seasonalDiscount.vMakeId());
                            selectedSeasonalDiscount().vMakeCodeName(seasonalDiscount.vMakeCodeName());
                            selectedSeasonalDiscount().vCategoryId(seasonalDiscount.vCategoryId());
                            selectedSeasonalDiscount().vCategoryCodeName(seasonalDiscount.vCategoryCodeName());
                            selectedSeasonalDiscount().vModelId(seasonalDiscount.vModelId());
                            selectedSeasonalDiscount().vModelCodeName(seasonalDiscount.vModelCodeName());
                            selectedSeasonalDiscount().customerTypeId(seasonalDiscount.customerTypeId());
                            selectedSeasonalDiscount().customerTypeCodeName(seasonalDiscount.customerTypeCodeName());
                            selectedSeasonalDiscount().modelYear(seasonalDiscount.modelYear());
                            selectedSeasonalDiscount().modelYearCode(seasonalDiscount.modelYearCode());
                            selectedSeasonalDiscount().ratingId(seasonalDiscount.ratingId());
                            selectedSeasonalDiscount().ratingCodeName(seasonalDiscount.ratingCodeName());
                            selectedSeasonalDiscount().discount(seasonalDiscount.discount());
                            selectedSeasonalDiscount().revisionNumber(seasonalDiscount.revisionNumber());
                            selectedSeasonalDiscount().fromDate(seasonalDiscount.fromDate());
                            selectedSeasonalDiscount().toDate(seasonalDiscount.toDate());
                            selectedSeasonalDiscount(undefined);
                            showUpdateCancelBtn(false);
                        } else {
                            seasonalDiscounts.push(seasonalDiscount);
                        }

                        addEditSeasonalDiscountMain().seasonalDiscount(new model.SeasonalDiscount());
                    }
                },
                // Do Before Logic
               doBeforeSeasonalDiscount = function () {
                   var flag = true;
                   if (!addEditSeasonalDiscountMain().seasonalDiscount().isValid()) {
                       addEditSeasonalDiscountMain().seasonalDiscount().errors.showAllMessages();
                       flag = false;
                   }
                   return flag;
               },
                // Save Seasonal Discount Main
               saveSeasonalDiscountMain = function (seasonalDiscnt) {
                   dataservice.saveSeasonalDiscount(model.SeasonalDiscountMainServerMapper(seasonalDiscnt), {
                       success: function (data) {
                           var seasonalMain = model.SeasonalDiscountMainClientMapper(data);
                           if (selectedSeasonalDiscountMain().id() > 0) {
                               closeSeasonalDiscountEditor();
                           } else {
                               seasonalDiscountMains.splice(0, 0, seasonalMain);
                               closeSeasonalDiscountEditor();
                           }
                           toastr.success(ist.resourceText.seasonalDiscountAddSuccessMsg);
                       },
                       error: function (exceptionMessage, exceptionType) {

                           if (exceptionType === ist.exceptionType.CaresGeneralException) {

                               toastr.error(exceptionMessage);

                           } else {

                               toastr.error(ist.resourceText.ist.resourceText.seasonalDiscountAddFailedMsg);

                           }

                       }
                   });
               },
                //Edit Seasonal Discount Main
               onEditSeasonalDiscountMain = function (seasoanlDiscountMain, e) {
                   seasonalDiscounts.removeAll();
                   selectedSeasonalDiscountMain(seasoanlDiscountMain);
                   var slDiscountMain = new model.SeasonalDiscountMain();
                   slDiscountMain.id(seasoanlDiscountMain.id());
                   slDiscountMain.code(seasoanlDiscountMain.code());
                   slDiscountMain.name(seasoanlDiscountMain.name());
                   slDiscountMain.companyId(seasoanlDiscountMain.companyId());
                   slDiscountMain.departmentId(seasoanlDiscountMain.departmentId());
                   slDiscountMain.operationId(seasoanlDiscountMain.operationId());
                   slDiscountMain.tariffTypeId(seasoanlDiscountMain.tariffTypeId());
                   slDiscountMain.description(seasoanlDiscountMain.description());
                   slDiscountMain.startDate(seasoanlDiscountMain.startDate());
                   slDiscountMain.endDate(seasoanlDiscountMain.endDate());
                   addEditSeasonalDiscountMain(slDiscountMain);
                   getSeasonalDiscountById(seasoanlDiscountMain);
                   showSeasonalDiscountEditor();
                   e.stopImmediatePropagation();
               },
               //Edit Seasonal Discount
               onEditSeasonalDiscount = function (sDiscountt) {
                   selectedSeasonalDiscount(sDiscountt);
                   var seasonalDiscount = new model.SeasonalDiscount();
                   seasonalDiscount.id(sDiscountt.id());
                   seasonalDiscount.opWorkplaceId(sDiscountt.opWorkplaceId());
                   seasonalDiscount.opWorkplaceId(sDiscountt.opWorkplaceId());
                   seasonalDiscount.customerTypeId(sDiscountt.customerTypeId());
                   seasonalDiscount.ratingId(sDiscountt.ratingId());
                   seasonalDiscount.hireGroupId(sDiscountt.hireGroupId());
                   seasonalDiscount.vMakeId(sDiscountt.vMakeId());
                   seasonalDiscount.vModelId(sDiscountt.vModelId());
                   seasonalDiscount.vCategoryId(sDiscountt.vCategoryId());
                   seasonalDiscount.modelYear(sDiscountt.modelYear());
                   seasonalDiscount.fromDate(sDiscountt.fromDate());
                   seasonalDiscount.toDate(sDiscountt.toDate());
                   seasonalDiscount.discount(sDiscountt.discount());
                   addEditSeasonalDiscountMain().seasonalDiscount(seasonalDiscount);
                   showUpdateCancelBtn(true);
               },
               //Delete Seasonal Discount
                deleteSeasonalDiscount = function (sDiscount) {
                    seasonalDiscounts.remove(sDiscount);
                },
               //Filtered Departments
                departmentId = ko.computed(function () {
                    if (addEditSeasonalDiscountMain() != undefined) {
                        filteredDepartments.removeAll();
                        _.each(departments(), function (item) {
                            if (item.CompanyId === addEditSeasonalDiscountMain().companyId())
                                filteredDepartments.push(item);
                        });
                        filteredDepartments.valueHasMutated();
                    }
                }, this),
                //Filtered Operations
                operationId = ko.computed(function () {
                    if (addEditSeasonalDiscountMain() != undefined) {
                        filteredOperations.removeAll();
                        _.each(operations(), function (item) {
                            if (item.DepartmentId === addEditSeasonalDiscountMain().departmentId())
                                filteredOperations.push(item);
                        });
                        filteredOperations.valueHasMutated();
                    }
                }, this),
                //Filteres tariff Types
                tariffTypeId = ko.computed(function () {
                    if (addEditSeasonalDiscountMain() != undefined) {
                        filteredTariffTypes.removeAll();
                        _.each(tariffTypes(), function (item) {
                            if (item.OperationId === addEditSeasonalDiscountMain().operationId())
                                filteredTariffTypes.push(item);
                        });
                        filteredTariffTypes.valueHasMutated();
                    }
                }, this),
                //Hide Update and cancel Button
                hideUpdateCancelBtn = function () {
                    showUpdateCancelBtn(false);
                    selectedSeasonalDiscount(undefined);
                    addEditSeasonalDiscountMain().seasonalDiscount(new model.SeasonalDiscount());
                },
                // Delete Seasonal Discount
               onDeleteSeasonalDiscountMain = function (seasonalDiscount) {
                   if (!seasonalDiscount.id()) {
                       seasonalDiscountMains.remove(seasonalDiscount);
                       return;
                   }
                   // Ask for confirmation
                   confirmation.afterProceed(function () {
                       deleteSeasonalDiscountMain(seasonalDiscount);
                   });
                   confirmation.show();
               },
                // Delete Seasonal Discount Main
               deleteSeasonalDiscountMain = function (seasonalDiscount) {
                   dataservice.deleteSeasonalDiscount(model.SeasonalDiscountServerMapperForId(seasonalDiscount), {
                       success: function () {
                           seasonalDiscountMains.remove(seasonalDiscount);
                           toastr.success(ist.resourceText.seasonalDiscountDeleteSuccessMsg);
                       },
                       error: function () {
                           toastr.error(ist.resourceText.seasonalDiscountDeleteFailedMsg);
                       }
                   });
               },
                // Show Seasonal Discount  Editor
               showSeasonalDiscountEditor = function () {
                   isSeasonalDiscountEditorVisible(true);
               },
                //close Seasonal Discount  Editor
               closeSeasonalDiscountEditor = function () {
                   isSeasonalDiscountEditorVisible(false);
               },
                //Get Seasonal Discounts
               getSeasonalDiscounts = function () {
                   isLoadingSeasonalDiscount(true);
                   dataservice.getSeasonalDiscounts({
                       SearchString: searchFilter(),
                       OperationId: operationFilter(),
                       TariffTypeId: tariffTypeFilter(),
                       PageSize: pager().pageSize(),
                       PageNo: pager().currentPage(),
                       SortBy: sortOn(),
                       IsAsc: sortIsAsc()
                   }, {
                       success: function (data) {
                           pager().totalCount(data.TotalCount);
                           seasonalDiscountMains.removeAll();
                           mapSeasonalDiscountMain(data);
                           isLoadingSeasonalDiscount(false);
                       },
                       error: function () {
                           isLoadingSeasonalDiscount(false);
                           toastr.error(ist.resourceText.seasonalDiscountLoadFailedMsg);
                       }
                   });
               };
                // #endregion Service Calls
                return {
                    // Observables
                    selectedSeasonalDiscountMain: selectedSeasonalDiscountMain,
                    selectedSeasonalDiscount: selectedSeasonalDiscount,
                    addEditSeasonalDiscountMain: addEditSeasonalDiscountMain,
                    isSeasonalDiscountEditorVisible: isSeasonalDiscountEditorVisible,
                    sortOn: sortOn,
                    sortIsAsc: sortIsAsc,
                    sortOnHg: sortOnHg,
                    sortIsAscHg: sortIsAscHg,
                    filterSectionVisilble: filterSectionVisilble,
                    showUpdateCancelBtn: showUpdateCancelBtn,
                    //Arrays
                    seasonalDiscounts: seasonalDiscounts,
                    seasonalDiscountMains: seasonalDiscountMains,
                    companies: companies,
                    departments: departments,
                    operations: operations,
                    tariffTypes: tariffTypes,
                    filteredDepartments: filteredDepartments,
                    filteredOperations: filteredOperations,
                    filteredTariffTypes: filteredTariffTypes,
                    operationsWorkPlaces: operationsWorkPlaces,
                    hireGroups: hireGroups,
                    vehicleCategories: vehicleCategories,
                    vehicleMakes: vehicleMakes,
                    vehicleModels: vehicleModels,
                    ratingTypes: ratingTypes,
                    customerTypes: customerTypes,
                    modelYears: modelYears,
                    //Filters
                    searchFilter: searchFilter,
                    operationFilter: operationFilter,
                    tariffTypeFilter: tariffTypeFilter,
                    // Utility Methods
                    initialize: initialize,
                    search: search,
                    pager: pager,
                    collapseFilterSection: collapseFilterSection,
                    showFilterSection: showFilterSection,
                    closeSeasonalDiscountEditor: closeSeasonalDiscountEditor,
                    showSeasonalDiscountEditor: showSeasonalDiscountEditor,
                    onSaveSeasonalDiscountMainCharge: onSaveSeasonalDiscountMainCharge,
                    reset: reset,
                    onEditSeasonalDiscountMain: onEditSeasonalDiscountMain,
                    onDeleteSeasonalDiscountMain: onDeleteSeasonalDiscountMain,
                    createSeasonalDiscount: createSeasonalDiscount,
                    onAddSeasonalDiscount: onAddSeasonalDiscount,
                    onEditSeasonalDiscount: onEditSeasonalDiscount,
                    hideUpdateCancelBtn: hideUpdateCancelBtn,
                    getSeasonalDiscounts: getSeasonalDiscounts,
                    deleteSeasonalDiscount: deleteSeasonalDiscount,
                    // Utility Methods

                };
            })()
        };
        return ist.seasonalDiscount.viewModel;
    });
