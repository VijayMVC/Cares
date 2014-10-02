/*
    Module with the view model for the Chauffer Charge
*/
define("nRT/nRT.viewModel",
    ["jquery", "amplify", "ko", "nRT/nRT.dataservice", "nRT/nRT.model", "common/confirmation.viewModel", "common/pagination"],
    function ($, amplify, ko, dataservice, model, confirmation, pagination) {
        var ist = window.ist || {};
        ist.nRT = {
            viewModel: (function () {
                var // the view 
                    view,
                    // Non Revenue Ticket Main
                    selectedNrtMain = ko.observable(),
                    // Show Filter Secion
                    filterSectionVisilble = ko.observable(false),
                    //Show Update and Cancel button For Update Additional Charge
                    showUpdateCancelBtn = ko.observable(false),
                    // #region Arrays
                    //Operations
                    operations = ko.observableArray([]),
                    //Locations
                    locations = ko.observableArray([]),
                    //Filtered Locations
                    filteredLocations = ko.observableArray([]),
                    //NRT Types
                   // ReSharper disable once InconsistentNaming
                    nRTTypes = ko.observableArray([]),
                    //Vehicle Statuses
                    vehicleStatuses = ko.observableArray([]),
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
                         // #region Utility Functions
                    // Initialize the view model
                    initialize = function (specifiedView) {
                        view = specifiedView;
                        ko.applyBindings(view.viewModel, view.bindingRoot);
                        getBase();
                        selectedNrtMain(model.NRTMain());
                        // Set Pager
                        // pager(new pagination.Pagination({}, chaufferChargeMains, getChaufferCharges));
                        // getChaufferCharges();

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
                        dataservice.getNRTBase({
                            success: function (data) {
                                //Operations 
                                operations.removeAll();
                                ko.utils.arrayPushAll(operations(), data.Operations);
                                operations.valueHasMutated();
                                //Locations
                                locations.removeAll();
                                ko.utils.arrayPushAll(locations(), data.Locations);
                                locations.valueHasMutated();
                                //NRT Types
                                nRTTypes.removeAll();
                                ko.utils.arrayPushAll(nRTTypes(), data.NRTTypes);
                                nRTTypes.valueHasMutated();
                                //Vehicle Statuses
                                vehicleStatuses.removeAll();
                                ko.utils.arrayPushAll(vehicleStatuses(), data.NRTTypes);
                                vehicleStatuses.valueHasMutated();
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
                        //isLoadingChaufferCharge(true);
                        //dataservice.getChaufferChargeDetail(model.ChaufferChargeServerMapperForId(chaufferChrg), {
                        //    success: function (data) {
                        //        chaufferCharges.removeAll();
                        //        _.each(data, function (item) {
                        //            var chaferCharge = new model.ChaufferChargeClientMapper(item);
                        //            chaufferCharges.push(chaferCharge);
                        //        });
                        //        isLoadingChaufferCharge(false);
                        //    },
                        //    error: function () {
                        //        isLoadingChaufferCharge(false);
                        //        toastr.error(ist.resourceText.loadChaufferChargeDetailFailedMsg);
                        //    }
                        //});
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
                    // Save Chauffer Charge Main
                    onSaveChaufferChargeMainCharge = function (chaufferCharge) {
                        if (doBeforeSave()) {
                            if (chaufferCharge.chaufferChargeList().length != 0) {
                                chaufferCharge.chaufferChargeList().removeAll();
                            }
                            ko.utils.arrayPushAll(chaufferCharge.chaufferChargeList(), chaufferCharges());
                            saveChaufferChargeMain(chaufferCharge);
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
                    // Do Before Logic
                    doBeforeAddVehicleDetail = function () {
                        var flag = true;
                        if (selectedNrtMain().startDate() === undefined) {
                            toastr.error("Please select Ticket Start Date");
                            return flag = false;
                        }
                        else if (selectedNrtMain().endDate() === undefined) {
                            toastr.error("Please select Ticket End Date");
                            return flag = false;
                        }
                        else if (selectedNrtMain().outLocationId() === undefined) {
                            toastr.error("Please select Ticket open location.");
                            return flag = false;
                        } else {
                            return flag;
                        }

                    },
                    onAddVehicleDetail = function (nRtMain) {
                        if (doBeforeAddVehicleDetail()) {
                            
                        }
                    },
                    //Add Chauffer Charge
                    onAddChaufferCharge = function (chaufferCharge) {
                        if (doBeforeChaufferCharge()) {
                            var flag = true;
                            //In case of New
                            _.each(chaufferCharges(), function (item) {
                                if (item.desigGradeId() === chaufferCharge.desigGradeId()) {
                                    toastr.error(ist.resourceText.chaufferChargeDuplicated);
                                    flag = false;
                                }
                            });
                            if (flag) {
                                chaufferCharges.push(chaufferCharge);
                                addEditChaufferChargeMain().chaufferCharge(new model.ChaufferCharge());
                            }
                        }
                    },
                    //Update Chauffer Charge
                    onUpdateChaufferCharge = function (chaufferChrg) {
                        if (doBeforeChaufferCharge()) {
                            var flag = true;
                            if (selectedChaufferCharge() !== undefined) {
                                //In case Of edit
                                _.each(chaufferCharges(), function (item) {
                                    if (item.desigGradeId() === chaufferChrg.desigGradeId() && chaufferChrg.desigGradeId() !== selectedChaufferCharge().desigGradeId()) {
                                        toastr.error(ist.resourceText.chaufferChargeDuplicated);
                                        flag = false;
                                    }
                                });
                            }
                            if (flag && selectedChaufferCharge() !== undefined) {
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
                   saveChaufferChargeMain = function (chaufferCharge) {
                       dataservice.saveChaufferCharge(model.CahufferChargeMainServerMapper(chaufferCharge), {
                           success: function (data) {
                               var chaufferChargeMain = model.ChaufferChargeMainClientMapper(data);
                               if (selectedChaufferChargeMain().id() > 0) {
                                   // selectedChaufferChargeMain().isEditable(additionalCharge.isEditable()),
                                   closeAdditionalChargeEditor();
                               } else {
                                   chaufferChargeMains.splice(0, 0, chaufferChargeMain);
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
                   //Filter Locations Based On Operation Id
                    filterLocations = ko.computed(function () {
                        if (selectedNrtMain() != undefined) {
                            filteredLocations.removeAll();
                            _.each(locations(), function (item) {
                                if (item.OperationId === selectedNrtMain().operationId())
                                    filteredLocations.push(item);
                            });
                            filteredLocations.valueHasMutated();
                        }
                    }, this),
                    //Hide Update and cancel Button
                        hideUpdateCancelBtn = function () {
                            showUpdateCancelBtn(false);
                            selectedChaufferCharge(undefined);
                            addEditChaufferChargeMain().chaufferCharge(new model.ChaufferCharge());
                        },
                     // Delete a Chauffer Charge
                   onDeleteChaufferChargeMain = function (chaufferChrg) {
                       if (!chaufferChrg.id()) {
                           chaufferChargeMains.remove(chaufferChrg);
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
                               chaufferChargeMains.remove(chaufferChrg);
                               toastr.success(ist.resourceText.chaufferChargeDeleteSuccessMsg);
                           },
                           error: function () {
                               toastr.error(ist.resourceText.chaufferChargeDeleteFailedMsg);
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
                    selectedNrtMain: selectedNrtMain,
                    isChaufferChargeEditorVisible: isChaufferChargeEditorVisible,
                    sortOn: sortOn,
                    sortIsAsc: sortIsAsc,
                    sortOnHg: sortOnHg,
                    sortIsAscHg: sortIsAscHg,
                    filterSectionVisilble: filterSectionVisilble,
                    showUpdateCancelBtn: showUpdateCancelBtn,
                    //Arrays
                    filteredLocations: filteredLocations,
                    locations: locations,
                    operations: operations,
                    nRTTypes: nRTTypes,
                    vehicleStatuses: vehicleStatuses,
                    // Utility Methods
                    initialize: initialize,
                    pager: pager,
                    collapseFilterSection: collapseFilterSection,
                    showFilterSection: showFilterSection,
                    closeAdditionalChargeEditor: closeAdditionalChargeEditor,
                    showAdditionalChargeEditor: showAdditionalChargeEditor,
                    onSaveChaufferChargeMainCharge: onSaveChaufferChargeMainCharge,
                    onEditChaufferChargeMain: onEditChaufferChargeMain,
                    onDeleteChaufferChargeMain: onDeleteChaufferChargeMain,
                    createChaufferCharge: createChaufferCharge,
                    onAddChaufferCharge: onAddChaufferCharge,
                    onSelectedDesigGrade: onSelectedDesigGrade,
                    onEditChaufferCharge: onEditChaufferCharge,
                    hideUpdateCancelBtn: hideUpdateCancelBtn,
                    onUpdateChaufferCharge: onUpdateChaufferCharge,
                    getChaufferCharges: getChaufferCharges,
                    onAddVehicleDetail: onAddVehicleDetail,
                    // Utility Methods

                };
            })()
        };
        return ist.nRT.viewModel;
    });
