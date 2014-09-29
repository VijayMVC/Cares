﻿/*
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
                    // Active Additional Charge Type
                    selectedSeasonalDiscountMain = ko.observable(),
                    // Active Additional Charge
                    selectedSeasonalDiscount = ko.observable(),
                    //Add/Edit Additional Charge 
                    addEditSeasonalDiscountMain = ko.observable(),
                    // Show Filter Section
                    filterSectionVisilble = ko.observable(false),
                    //Show Update and Cancel button For Update Additional Charge
                    showUpdateCancelBtn = ko.observable(false),
                    // #region Arrays
                    //additional Charges
                    seasonalDiscounts = ko.observableArray([]),
                    //Additional Type Charges
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
                                    {  Id: 1, Text: 'Individual' },
                                    { Id: 2, Text: 'Corporat' } ],
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
                // Is Additional Charge Editor Visible
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
                //Get Chauffer Charge By Id
                getChaufferChargeById = function (chaufferChrg) {
                    isLoadingSeasonalDiscount(true);
                    dataservice.getChaufferChargeDetail(model.ChaufferChargeServerMapperForId(chaufferChrg), {
                        success: function (data) {
                            seasonalDiscounts.removeAll();
                            _.each(data, function (item) {
                                var chaferCharge = new model.ChaufferChargeClientMapper(item);
                                seasonalDiscounts.push(chaferCharge);
                            });
                            isLoadingSeasonalDiscount(false);
                        },
                        error: function () {
                            isLoadingSeasonalDiscount(false);
                            toastr.error(ist.resourceText.loadChaufferChargeDetailFailedMsg);
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
                    // Select the newly added Additional Charge
                    selectedSeasonalDiscountMain(seasonalDiscountMain);
                    addEditSeasonalDiscountMain(seasonalDiscountMain);
                    showAdditionalChargeEditor();
                },
                // Save Seasonal Discount Main
                onSaveSeasonalDiscountMainCharge = function (seasonalDiscnt) {
                    if (doBeforeSave()) {
                        //if (seasonalDiscnt.chaufferChargeList().length != 0) {
                        //    seasonalDiscnt.chaufferChargeList().removeAll();
                        //}
                        //ko.utils.arrayPushAll(chaufferCharge.chaufferChargeList(), seasonalDiscounts());
                        saveSeasonalDiscountMain(seasonalDiscnt);
                    }
                },
                // Do Before Logic
                doBeforeSave = function () {
                    var flag = true;
                    if (!addEditSeasonalDiscountMain().isValid()) {
                        selectedSeasonalDiscountMain().errors.showAllMessages();
                        flag = false;
                    }
                    return flag;
                },
                //Add Chauffer Charge
                onAddChaufferCharge = function (chaufferCharge) {
                    if (doBeforeChaufferCharge()) {
                        var flag = true;
                        //In case of New
                        _.each(seasonalDiscounts(), function (item) {
                            if (item.desigGradeId() === chaufferCharge.desigGradeId()) {
                                toastr.error(ist.resourceText.chaufferChargeDuplicated);
                                flag = false;
                            }
                        });
                        if (flag) {
                            seasonalDiscounts.push(chaufferCharge);
                            addEditSeasonalDiscountMain().chaufferCharge(new model.ChaufferCharge());
                        }
                    }
                },
                //Update Chauffer Charge
                onUpdateChaufferCharge = function (chaufferChrg) {
                    if (doBeforeChaufferCharge()) {
                        var flag = true;
                        if (selectedSeasonalDiscount() !== undefined) {
                            //In case Of edit
                            _.each(seasonalDiscounts(), function (item) {
                                if (item.desigGradeId() === chaufferChrg.desigGradeId() && chaufferChrg.desigGradeId() !== selectedSeasonalDiscount().desigGradeId()) {
                                    toastr.error(ist.resourceText.chaufferChargeDuplicated);
                                    flag = false;
                                }
                            });
                        }
                        if (flag && selectedSeasonalDiscount() !== undefined) {
                            selectedSeasonalDiscount().desigGradeId(chaufferChrg.desigGradeId());
                            selectedSeasonalDiscount().startDate(chaufferChrg.startDate());
                            selectedSeasonalDiscount().rate(chaufferChrg.rate());
                            selectedSeasonalDiscount().desigGradeCodeName(chaufferChrg.desigGradeCodeName());
                            selectedSeasonalDiscount(undefined);
                            addEditSeasonalDiscountMain().chaufferCharge(new model.ChaufferCharge());
                            showUpdateCancelBtn(false);
                        }
                    }
                },
                // Do Before Logic
               doBeforeChaufferCharge = function () {
                   var flag = true;
                   if (!addEditSeasonalDiscountMain().chaufferCharge().isValid()) {
                       addEditSeasonalDiscountMain().chaufferCharge().errors.showAllMessages();
                       flag = false;
                   }
                   return flag;
               },
                // Save Seasonal Discount Main
               saveSeasonalDiscountMain = function (seasonalDiscnt) {
                   dataservice.saveSeasonalDiscount(model.SeasonalDiscountMainServerMapper(seasonalDiscnt), {
                       success: function (data) {
                           var chaufferChargeMain = model.ChaufferChargeMainClientMapper(data);
                           if (selectedSeasonalDiscountMain().id() > 0) {
                               // selectedSeasonalDiscountMain().isEditable(additionalCharge.isEditable()),
                               closeAdditionalChargeEditor();
                           } else {
                               seasonalDiscountMains.splice(0, 0, chaufferChargeMain);
                               closeAdditionalChargeEditor();
                           }
                           toastr.success(ist.resourceText.chaufferChargeAddSuccessMsg);
                       },
                       error: function (exceptionMessage, exceptionType) {

                           if (exceptionType === ist.exceptionType.CaresGeneralException) {

                               toastr.error(exceptionMessage);

                           } else {

                               toastr.error(ist.resourceText.ist.resourceText.chaufferChargeAddFailedMsg);

                           }

                       }
                   });
               },
                //Edit Additional Charge
               onEditChaufferChargeMain = function (chaufferChrg, e) {
                   //seasonalDiscounts.removeAll();
                   selectedSeasonalDiscountMain(chaufferChrg);
                   addEditSeasonalDiscountMain(chaufferChrg);
                   getChaufferChargeById(chaufferChrg);
                   showAdditionalChargeEditor();
                   e.stopImmediatePropagation();
               },
               onEditChaufferCharge = function (chaufferChrg) {
                   selectedSeasonalDiscount(chaufferChrg);
                   var chaufferCharge = new model.ChaufferCharge();
                   chaufferCharge.id(chaufferChrg.id());
                   chaufferCharge.desigGradeId(chaufferChrg.desigGradeId());
                   chaufferCharge.startDate(chaufferChrg.startDate());
                   chaufferCharge.rate(chaufferChrg.rate());
                   addEditSeasonalDiscountMain().chaufferCharge(chaufferCharge);
                   showUpdateCancelBtn(true);
               },
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
               addEditSeasonalDiscountMain().chaufferCharge(new model.ChaufferCharge());
           },
                // Delete a Chauffer Charge
               onDeleteChaufferChargeMain = function (chaufferChrg) {
                   if (!chaufferChrg.id()) {
                       seasonalDiscountMains.remove(chaufferChrg);
                       return;
                   }
                   // Ask for confirmation
                   confirmation.afterProceed(function () {
                       deleteChaufferCharge(chaufferChrg);
                   });
                   confirmation.show();
               },
                // Delete Additional Charge
               deleteChaufferCharge = function (chaufferChrg) {
                   dataservice.deleteChaufferCharge(model.ChaufferChargeServerMapperForId(chaufferChrg), {
                       success: function () {
                           seasonalDiscountMains.remove(chaufferChrg);
                           toastr.success(ist.resourceText.chaufferChargeDeleteSuccessMsg);
                       },
                       error: function () {
                           toastr.error(ist.resourceText.chaufferChargeDeleteFailedMsg);
                       }
                   });
               },
                // Show Additional Charge Editor
               showAdditionalChargeEditor = function () {
                   isSeasonalDiscountEditorVisible(true);
               },
                //close Additional Charge Editor
               closeAdditionalChargeEditor = function () {
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
                           toastr.error(ist.resourceText.additionalChargeLoadFailedMsg);
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
                    closeAdditionalChargeEditor: closeAdditionalChargeEditor,
                    showAdditionalChargeEditor: showAdditionalChargeEditor,
                    onSaveSeasonalDiscountMainCharge: onSaveSeasonalDiscountMainCharge,
                    reset: reset,
                    onEditChaufferChargeMain: onEditChaufferChargeMain,
                    onDeleteChaufferChargeMain: onDeleteChaufferChargeMain,
                    createSeasonalDiscount: createSeasonalDiscount,
                    onAddChaufferCharge: onAddChaufferCharge,
                    onEditChaufferCharge: onEditChaufferCharge,
                    hideUpdateCancelBtn: hideUpdateCancelBtn,
                    onUpdateChaufferCharge: onUpdateChaufferCharge,
                    getSeasonalDiscounts: getSeasonalDiscounts,
                    // Utility Methods

                };
            })()
        };
        return ist.seasonalDiscount.viewModel;
    });
