/*
    Module with the view model for the Chauffer Charge
*/
define("chaufferCharge/chaufferCharge.viewModel",
    ["jquery", "amplify", "ko", "chaufferCharge/chaufferCharge.dataservice", "chaufferCharge/chaufferCharge.model", "common/confirmation.viewModel", "common/pagination"],
    function ($, amplify, ko, dataservice, model, confirmation, pagination) {
        var ist = window.ist || {};
        ist.chaufferCharge = {
            viewModel: (function () {
                var // the view 
                    view,
                    // Active Additional Charge Type
                    selectedChaufferChargeMain = ko.observable(),
                    // Active Additional Charge
                    selectedChaufferCharge = ko.observable(),
                    //Add/Edit Additional Charge 
                    addEditChaufferChargeMain = ko.observable(),
                    // Show Filter Section
                    filterSectionVisilble = ko.observable(false),
                    //Show Update and Cancel button For Update Additional Charge
                    showUpdateCancelBtn = ko.observable(false),
                    // #region Arrays
                    //additional Charges
                    chaufferCharges = ko.observableArray([]),
                    //Additional Type Charges
                    chaufferChargeMains = ko.observableArray([]),
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
                    //Designation Grades
                    desigGrades = ko.observableArray([]),
                    // #endregion Arrays
                    // #region Busy Indicators
                    isLoadingChaufferCharge = ko.observable(false),
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
                    isChaufferChargeEditorVisible = ko.observable(false),
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
                        pager(new pagination.Pagination({}, chaufferChargeMains, getChaufferCharges));
                        getChaufferCharges();

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
                        dataservice.getChaufferChargeBase({
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
                                //Tariff types
                                desigGrades.removeAll();
                                ko.utils.arrayPushAll(desigGrades(), data.DesigGrades);
                                desigGrades.valueHasMutated();

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
                        isLoadingChaufferCharge(true);
                        dataservice.getChaufferChargeDetail(model.ChaufferChargeServerMapperForId(chaufferChrg), {
                            success: function (data) {
                                //chaufferCharges.removeAll();
                                //_.each(data, function (item) {
                                //    var sddCharge = new model.AdditionalChargeClientMapper(item);
                                //    chaufferCharges.push(sddCharge);
                                //});
                                isLoadingChaufferCharge(false);
                            },
                            error: function () {
                                isLoadingChaufferCharge(false);
                                toastr.error(ist.resourceText.loadAddChargeDetailFailedMsg);
                            }
                        });
                    },

                    // Search 
                    search = function () {
                        pager().reset();
                        getChaufferCharges();
                    },
                    //Reset
                    reset = function () {
                        searchFilter(undefined);
                        operationFilter(undefined);
                        tariffTypeFilter(undefined);
                        search();
                    },
                    // Map Chauffer Charge Main - Server to Client
                    mapChaufferChargeMain = function (data) {
                        var chaufferChargeMainList = [];
                        _.each(data.ChaufferChargeMains, function (item) {
                            var addChrgType = new model.ChaufferChargeMainClientMapper(item);
                            chaufferChargeMainList.push(addChrgType);
                        });
                        ko.utils.arrayPushAll(chaufferChargeMains(), chaufferChargeMainList);
                        chaufferChargeMains.valueHasMutated();
                    },
                    //Create Chauffer Charge
                    createChaufferCharge = function () {
                        var chaufferChargeMain = new model.ChaufferChargeMain();
                        chaufferCharges.removeAll();
                        // Select the newly added Additional Charge
                        selectedChaufferChargeMain(chaufferChargeMain);
                        addEditChaufferChargeMain(chaufferChargeMain);
                        showAdditionalChargeEditor();
                    },
                    // Save Chauffer Charge
                    onSaveChaufferChargeMainCharge = function (addCharge) {
                        if (doBeforeSave()) {

                            addCharge.chaufferChargesList.removeAll();
                            ko.utils.arrayPushAll(addCharge.chaufferChargesList(), chaufferCharges());
                            saveAdditionalCharge(addCharge);
                        }
                    },
                    // Do Before Logic
                    doBeforeSave = function () {
                        var flag = true;
                        if (!addEditChaufferChargeMain().isValid()) {
                            selectedChaufferChargeMain().errors.showAllMessages();
                            flag = false;
                        }
                        return flag;
                    },
                    //Add Chauffer Charge
                    onAddChaufferCharge = function (chaufferCharge) {
                        if (doBeforeChaufferCharge()) {
                            var flag = true;
                            //In case of New
                            _.each(chaufferCharges(), function (item) {
                                if (item.desigGradeId() === chaufferCharge.desigGradeId()) {
                                    toastr.error("Chauffer Charge with the given parameters [DesigGrade] are already defined.");
                                    flag = false;
                                }
                            });
                            if (flag) {
                                chaufferCharges.push(chaufferCharge);
                                addEditChaufferChargeMain().chaufferCharge(new model.ChaufferCharge());
                            }
                        }
                    },
                      onUpdateChaufferCharge = function (chaufferChrg) {
                          if (doBeforeChaufferCharge()) {

                              if (selectedChaufferCharge() !== undefined) {
                                  selectedChaufferCharge().desigGradeId(chaufferChrg.desigGradeId());
                                  selectedChaufferCharge().startDate(chaufferChrg.startDate());
                                  selectedChaufferCharge().rate(chaufferChrg.rate());
                                  selectedChaufferCharge().desigGradeCodeName(chaufferChrg.desigGradeCodeName());
                                  selectedChaufferCharge(undefined);
                                  addEditChaufferChargeMain().chaufferCharge(new model.ChaufferCharge());
                                  showUpdateCancelBtn(false);
                              }
                          }
                      },
                        // Do Before Logic
                   doBeforeChaufferCharge = function () {
                       var flag = true;
                       if (!addEditChaufferChargeMain().chaufferCharge().isValid()) {
                           addEditChaufferChargeMain().chaufferCharge().errors.showAllMessages();
                           flag = false;
                       }
                       return flag;
                   },

                        // Save Additional Charge Main
                   saveAdditionalCharge = function (addCharge) {
                       dataservice.saveAdditionalCharge(model.AdditionalChargeTypeServerMapper(addCharge), {
                           success: function (data) {
                               var additionalCharge = model.AdditionalChargeTypeClientMapper(data);
                               if (selectedChaufferChargeMain().id() > 0) {
                                   selectedChaufferChargeMain().isEditable(additionalCharge.isEditable()),
                                   closeAdditionalChargeEditor();
                               } else {
                                   chaufferChargeMains.splice(0, 0, additionalCharge);
                                   closeAdditionalChargeEditor();
                               }
                               toastr.success(ist.resourceText.additionalChargeAddSuccessMsg);
                           },
                           error: function (exceptionMessage, exceptionType) {

                               if (exceptionType === ist.exceptionType.CaresGeneralException) {

                                   toastr.error(exceptionMessage);

                               } else {

                                   toastr.error(ist.resourceText.ist.resourceText.additionalChargeAddFailedMsg);

                               }

                           }
                       });
                   },
                        //Edit Additional Charge
                   onEditChaufferChargeMain = function (chaufferChrg, e) {
                       //chaufferCharges.removeAll();
                       selectedChaufferChargeMain(chaufferChrg);
                       addEditChaufferChargeMain(chaufferChrg);
                       getChaufferChargeById(chaufferChrg);
                       showAdditionalChargeEditor();
                       e.stopImmediatePropagation();
                   },
                   onEditChaufferCharge = function (chaufferChrg) {
                       selectedChaufferCharge(chaufferChrg);
                       var chaufferCharge = new model.ChaufferCharge();
                       chaufferCharge.id(chaufferChrg.id());
                       chaufferCharge.desigGradeId(chaufferChrg.desigGradeId());
                       chaufferCharge.startDate(chaufferChrg.startDate());
                       chaufferCharge.rate(chaufferChrg.rate());
                       addEditChaufferChargeMain().chaufferCharge(chaufferCharge);
                       showUpdateCancelBtn(true);
                   },
              departmentId = ko.computed(function () {
                  if (addEditChaufferChargeMain() != undefined) {
                      filteredDepartments.removeAll();
                      _.each(departments(), function (item) {
                          if (item.CompanyId === addEditChaufferChargeMain().companyId())
                              filteredDepartments.push(item);
                      });
                      filteredDepartments.valueHasMutated();
                  }
              }, this),

              operationId = ko.computed(function () {
                  if (addEditChaufferChargeMain() != undefined) {
                      filteredOperations.removeAll();
                      _.each(operations(), function (item) {
                          if (item.DepartmentId === addEditChaufferChargeMain().departmentId())
                              filteredOperations.push(item);
                      });
                      filteredOperations.valueHasMutated();
                  }
              }, this),
                tariffTypeId = ko.computed(function () {
                    if (addEditChaufferChargeMain() != undefined) {
                        filteredTariffTypes.removeAll();
                        _.each(tariffTypes(), function (item) {
                            if (item.OperationId === addEditChaufferChargeMain().operationId())
                                filteredTariffTypes.push(item);
                        });
                        filteredTariffTypes.valueHasMutated();
                    }
                }, this),
                        //Hide Update and cancel Button
               hideUpdateCancelBtn = function () {
                   showUpdateCancelBtn(false);
                   selectedChaufferCharge(undefined);
                   addEditChaufferChargeMain().chaufferCharge(new model.ChaufferCharge());
               },
                   onDeleteAdditionalCharge = function (addCharge) {
                       chaufferCharges.remove(addCharge);
                   },
                        // Delete a Additional Charge
                   onDeleteAdditionalChargeType = function (addChrg) {
                       if (!addChrg.id()) {
                           chaufferChargeMains.remove(addChrg);
                           return;
                       }
                       // Ask for confirmation
                       confirmation.afterProceed(function () {
                           deleteAdditionalCharge(addChrg);
                       });
                       confirmation.show();
                   },
                        // Delete Additional Charge
                   deleteAdditionalCharge = function (addChrg) {
                       dataservice.deleteAdditionalCharge(model.AdditionalChrgServerMapperForId(addChrg), {
                           success: function () {
                               chaufferChargeMains.remove(addChrg);
                               toastr.success(ist.resourceText.additionalChargeDeleteSuccessMsg);
                           },
                           error: function () {
                               toastr.error(ist.resourceText.additionalChargeDeleteFailedMsg);
                           }
                       });
                   },
                       onSelectedDesigGrade = function (desigGrade) {
                           if (desigGrade.desigGradeId() != undefined) {
                               _.each(desigGrades(), function (item) {
                                   if (item.DesigGradeId === desigGrade.desigGradeId()) {
                                       addEditChaufferChargeMain().chaufferCharge().desigGradeCodeName(item.DesigGradeCodeName);
                                       addEditChaufferChargeMain().chaufferCharge().desigGradeId(desigGrade.desigGradeId());
                                   }
                               });
                           }
                       },
                        // Show Additional Charge Editor
                   showAdditionalChargeEditor = function () {
                       isChaufferChargeEditorVisible(true);
                   },
                        //close Additional Charge Editor
                   closeAdditionalChargeEditor = function () {
                       isChaufferChargeEditorVisible(false);
                   },
                        // Get Additional Charges
                   getChaufferCharges = function () {
                       isLoadingChaufferCharge(true);
                       dataservice.getChaufferCharges({
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
                               chaufferChargeMains.removeAll();
                               mapChaufferChargeMain(data);
                               isLoadingChaufferCharge(false);
                           },
                           error: function () {
                               isLoadingChaufferCharge(false);
                               toastr.error(ist.resourceText.additionalChargeLoadFailedMsg);
                           }
                       });
                   };
                // #endregion Service Calls

                return {
                    // Observables
                    selectedChaufferChargeMain: selectedChaufferChargeMain,
                    selectedChaufferCharge: selectedChaufferCharge,
                    addEditChaufferChargeMain: addEditChaufferChargeMain,
                    isChaufferChargeEditorVisible: isChaufferChargeEditorVisible,
                    sortOn: sortOn,
                    sortIsAsc: sortIsAsc,
                    sortOnHg: sortOnHg,
                    sortIsAscHg: sortIsAscHg,
                    filterSectionVisilble: filterSectionVisilble,
                    showUpdateCancelBtn: showUpdateCancelBtn,
                    //Arrays
                    chaufferCharges: chaufferCharges,
                    chaufferChargeMains: chaufferChargeMains,
                    companies: companies,
                    departments: departments,
                    operations: operations,
                    tariffTypes: tariffTypes,
                    desigGrades: desigGrades,
                    filteredDepartments: filteredDepartments,
                    filteredOperations: filteredOperations,
                    filteredTariffTypes: filteredTariffTypes,
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
                    onSaveChaufferChargeMainCharge: onSaveChaufferChargeMainCharge,
                    reset: reset,
                    onEditChaufferChargeMain: onEditChaufferChargeMain,
                    onDeleteAdditionalChargeType: onDeleteAdditionalChargeType,
                    createChaufferCharge: createChaufferCharge,
                    onAddChaufferCharge: onAddChaufferCharge,
                    onSelectedDesigGrade: onSelectedDesigGrade,
                    onDeleteAdditionalCharge: onDeleteAdditionalCharge,
                    onEditChaufferCharge: onEditChaufferCharge,
                    hideUpdateCancelBtn: hideUpdateCancelBtn,
                    onUpdateChaufferCharge: onUpdateChaufferCharge,
                    getChaufferCharges: getChaufferCharges,
                    // Utility Methods

                };
            })()
        };
        return ist.chaufferCharge.viewModel;
    });
