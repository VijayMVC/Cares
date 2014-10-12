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
                    //Selected Vehicle
                    selectedVehicle = ko.observable(),
                    //Selected Chauffer
                    selectedChauffer = ko.observable(),
                    //Selected Chauffer Item
                    selectedChaufferItem = ko.observable(),
                    //Selected Additional Charge Item
                    selectedAdditionalChargeItem = ko.observable(),
                    // Show Filter Secion
                    filterSectionVisilble = ko.observable(false),
                    //Show Update and Cancel button For Update Additional Charge
                    showUpdateCancelBtn = ko.observable(false),
                    //Show save cancel 
                    showSaveCancelBtn = ko.observable(false),
                    //Show edit Button for vehicle detail
                    showEditBtn = ko.observable(false),
                    //checked on dialog vehicle detail dialog
                    isVhicleChecked = ko.observable(false),
                    //checked on dialog chauffer dialog
                    isChaufferChecked = ko.observable(false),
                    // Is Editable
                    isEditable = ko.observable(false),
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
                    //Vehicle Details
                    vehicleDetails = ko.observableArray([]),
                    //Chauffers
                    chauffers = ko.observableArray([]),
                    //Additional Charges
                    additionalCharges = ko.observableArray([]),
                    //selected Chauffer List
                    selectedChaufferList = ko.observableArray([]),
                    //selected Additional Charge List
                    selectedAdditionalChargeList = ko.observableArray([]),
                    //Vehicles List For List View
                    vehiclesForListView = ko.observableArray([]),
                    // #endregion Arrays
                    // #region Busy Indicators
                    isLoadingNrt = ko.observable(false),
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
                    // On Proceed
                    afterProceed = ko.observable(),
                    // On Cancel
                    afterCancel = ko.observable(),

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
                    // Select a Vehicle from Dialog
                    selectVehicle = function (vehicle) {
                        selectedNrtMain().vehicleDetail().vehicleId(vehicle.vehicleId());
                        selectedNrtMain().vehicleDetail().plateNum(vehicle.plateNumber());
                        selectedNrtMain().vehicleDetail().outDtTime(moment(selectedNrtMain().startDate()).format(ist.utcFormat));
                        selectedNrtMain().vehicleDetail().inDtTime(moment(selectedNrtMain().endDate()).format(ist.utcFormat));
                        selectedNrtMain().vehicleDetail().fuelOut(vehicle.fuelLevel());
                        selectedNrtMain().vehicleDetail().outLocId(selectedNrtMain().outLocationId());
                        selectedNrtMain().vehicleDetail().inLocId(selectedNrtMain().retLocationId());
                        selectedNrtMain().vehicleDetail().outOdemeter(vehicle.currentOdometer());
                        showSaveCancelBtn(true);
                    },
                    //Add to list Selected Additional Charges from dialog
                    applyAdditionalCharges = function () {
                        _.each(additionalCharges(), function (item) {
                            if (item.isChecked()) {
                                var maintActivity = model.MaintenanceActivity();
                                maintActivity.additionalChargeTypeId(item.additionalChargeTypeId());
                                maintActivity.code(item.code());
                                maintActivity.name(item.name());
                                maintActivity.rate(item.rate());
                                selectedAdditionalChargeList.push(maintActivity);
                            }
                        });
                        view.hideActivityDialog();
                    },
                    // Select a Chauffer from Dialog
                    selectChauffer = function (chauffer) {
                        var chaufferInNrt = model.ChaufferInNrt();
                        chaufferInNrt.chaufferId(chauffer.id());
                        chaufferInNrt.desigGradeId(chauffer.desigGradeId());
                        chaufferInNrt.code(chauffer.code());
                        chaufferInNrt.name(chauffer.name());
                        chaufferInNrt.licenseNum(chauffer.licenseNum());
                        chaufferInNrt.licenseExpiryDt(chauffer.licenseExpiryDt());
                        chaufferInNrt.startDt(selectedNrtMain().startDate());
                        chaufferInNrt.endDt(selectedNrtMain().endDate());
                        chaufferInNrt.startHour(moment(selectedNrtMain().startDate()).format(ist.hourPattern));
                        chaufferInNrt.startMinute(moment(selectedNrtMain().startDate()).format(ist.minutePattern));
                        chaufferInNrt.endHour(moment(selectedNrtMain().endDate()).format(ist.hourPattern));
                        chaufferInNrt.endMinute(moment(selectedNrtMain().endDate()).format(ist.minutePattern));
                        selectedChaufferList.push(chaufferInNrt);
                        view.hideChaufferDialog();
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
                                ko.utils.arrayPushAll(vehicleStatuses(), data.VehicleStatuses);
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

                    //Edit Vehicle Detail
                    onEditVehicle = function () {
                        showEditBtn(false);
                        showSaveCancelBtn(false);
                        showUpdateCancelBtn(true);
                    },
                    //Update Vehicle Detail
                    onUpdateVehicle = function () {
                        showEditBtn(true);
                        showSaveCancelBtn(false);
                        showUpdateCancelBtn(false);
                    },

                    //delete Chauffer Item
                    deleteChaufferItem = function (chauffer) {
                        selectedChaufferList.remove(chauffer);
                    },
                    //Delete Additional Charge Item
                    deleteAdditionalChargeItem = function (addChrg) {
                        selectedAdditionalChargeList.remove(addChrg);
                    },
                    // Save NRT
                    onOpenTicket = function (nrtMain) {
                        if (doBeforeSave()) {
                            //Add Chauffers List
                            if (nrtMain.chauffersList().length != 0) {
                                nrtMain.chauffersList.removeAll();
                            }
                            ko.utils.arrayPushAll(nrtMain.chauffersList(), selectedChaufferList());
                            //Add NRT Charges
                            if (nrtMain.nrtChargesList().length != 0) {
                                nrtMain.nrtChargesList.removeAll();
                            }
                            ko.utils.arrayPushAll(nrtMain.nrtChargesList(), selectedAdditionalChargeList());
                            saveNrtMain(nrtMain);
                        }
                        //getNrtById(nrtMain);
                    },
                    // Do Before Logic
                    doBeforeSave = function () {
                        var flag = true;
                        if (!selectedNrtMain().isValid() || selectedNrtMain().vehicleDetail().vOutStatusId() === undefined) {
                            selectedNrtMain().errors.showAllMessages();
                            selectedNrtMain().vehicleDetail().errors.showAllMessages();
                            flag = false;
                        }
                        return flag;
                    },
                    onSaveVehicle = function () {
                        if (!selectedNrtMain().vehicleDetail().isReturnLoc()) {
                            showEditBtn(true);
                            showSaveCancelBtn(false);
                            _.each(vehicleDetails(), function (item) {
                                if (item.vehicleId() === selectedNrtMain().vehicleDetail().vehicleId()) {
                                    vehiclesForListView.push(model.VehicleForListViewClientMapper(item));
                                }
                            });
                        }
                    },


                    //Get NRT By Id
                    getNrtById = function (nrtMain) {
                        isLoadingNrt(true);
                        dataservice.getNrtDetail(model.NrtMainServerMapperForId(nrtMain), {
                            success: function (data) {
                                vehiclesForListView.removeAll();
                                selectedChaufferList.removeAll();
                                selectedAdditionalChargeList.removeAll();
                                selectedNrtMain(model.NrtMainClientMapper(data));
                                _.each(data.NrtVehicles, function (item) {
                                    var vehicle = new model.VehicleClientMapper(item.Vehicle);
                                    selectedNrtMain().vehicleDetail().vehicleId(item.Vehicle.VehicleId);
                                    selectedNrtMain().vehicleDetail().plateNum(item.Vehicle.PlateNumber);
                                    vehiclesForListView.push(model.VehicleForListViewClientMapper(vehicle));
                                    //Selected Chauffer
                                    _.each(item.NrtDrivers, function (driver) {
                                        var drvr = new model.ChaufferInNrtClientMapper(driver);
                                        selectedChaufferList.push(drvr);
                                    });
                                    //Selected Additiional Charge
                                    _.each(item.NrtCharges, function (charge) {
                                        var chrg = new model.MaintenanceActivityClientMapper(charge);
                                        selectedAdditionalChargeList.push(chrg);
                                    });
                                    //Selected vehicle Movement status
                                    _.each(item.NrtVehicleMovements, function (vhicle) {
                                        selectedNrtMain().vehicleDetail().id(vhicle.NrtVehicleMovementId);
                                        selectedNrtMain().vehicleDetail().isReturnLoc(vhicle.MovementStatus);
                                        if (vhicle.MovementStatus) {
                                            selectedNrtMain().vehicleDetail().inDtTime(moment(vhicle.DtTime, ist.utcFormat).toDate());
                                            selectedNrtMain().vehicleDetail().inLocId(vhicle.OperationsWorkPlaceId);
                                            selectedNrtMain().vehicleDetail().fuelIn(vhicle.FuelLevel);
                                            selectedNrtMain().vehicleDetail().inOdemeter(vhicle.Odometer);
                                            selectedNrtMain().vehicleDetail().vInStatusId(vhicle.VehicleStatusId);
                                        } else {
                                            selectedNrtMain().vehicleDetail().outDtTime(moment(vhicle.DtTime, ist.utcFormat).toDate());
                                            selectedNrtMain().vehicleDetail().outLocId(vhicle.OperationsWorkPlaceId);
                                            selectedNrtMain().vehicleDetail().fuelOut(vhicle.FuelLevel);
                                            selectedNrtMain().vehicleDetail().outOdemeter(vhicle.Odometer);
                                            selectedNrtMain().vehicleDetail().vOutStatusId(vhicle.VehicleStatusId);
                                        }
                                    });
                                });


                                showEditBtn(true);
                                isLoadingNrt(false);
                            },
                            error: function () {
                                isLoadingNrt(false);
                                toastr.error(ist.resourceText.loadAddChargeDetailFailedMsg);
                            }
                        });
                    },

                // Do Before Logic
                    doBeforeAddVehicleDetail = function () {
                        var flag = true;
                        if (selectedNrtMain().startDate() === undefined) {
                            toastr.error("Please select Ticket Start Date");
                            return flag = false;
                        } else if (selectedNrtMain().endDate() === undefined) {
                            toastr.error("Please select Ticket End Date");
                            return flag = false;
                        } else if (selectedNrtMain().startDate() > selectedNrtMain().endDate()) {
                            toastr.error("Start Date is greater than the End Date");
                            return flag = false;
                        } else if (selectedNrtMain().outLocationId() === undefined) {
                            toastr.error("Please select Ticket open location.");
                            return flag = false;
                        }
                        else if (selectedNrtMain().retLocationId() === undefined) {
                            toastr.error("Please select Return location.");
                            return flag = false;
                        } else {
                            return flag;
                        }

                    },
                    //Get vehicles
                   onAddVehicleDetail = function (nRtMain) {
                       if (doBeforeAddVehicleDetail()) {
                           isLoadingNrt(true);
                           dataservice.getVehiclesDetail({
                               OperationWorkPlaceId: selectedNrtMain().outLocationId(),
                               StartDtTime: moment(selectedNrtMain().startDate()).format(ist.utcFormat),
                               EndDtTime: moment(selectedNrtMain().endDate()).format(ist.utcFormat),
                           }, {
                               success: function (data) {
                                   isVhicleChecked(false);
                                   vehicleDetails.removeAll();
                                   var vehicleDetailList = [];
                                   _.each(data, function (item) {
                                       var vehicle = new model.VehicleClientMapper(item);
                                       vehicleDetailList.push(vehicle);
                                   });
                                   ko.utils.arrayPushAll(vehicleDetails(), vehicleDetailList);
                                   vehicleDetails.valueHasMutated();
                                   // Ask for confirmation
                                   afterProceed(function () {
                                       //deleteChaufferCharge(chaufferChrg);
                                   });
                                   //Show The Dialog
                                   view.show();
                                   isLoadingNrt(false);
                               },
                               error: function () {
                                   isLoadingNrt(false);
                                   toastr.error(ist.resourceText.additionalChargeLoadFailedMsg);
                               }
                           });

                       }

                   },
                    // Cancel 
                    cancel = function () {
                        if (typeof afterCancel() === "function") {
                            afterCancel()();
                        }
                        hide();
                    },
                    // Proceed with the request
                    proceed = function () {
                        if (typeof afterProceed() === "function") {
                            afterProceed()();
                        }
                        hide();
                    },
                    // Hide the dialog
                    hide = function () {
                        // Reset Call Backs
                        afterCancel(undefined);
                        afterProceed(undefined);

                        view.hide();
                    },
                    //On Add Maintenance Activity
                    onAddActivity = function (activity) {
                        if (true) {
                            isLoadingNrt(true);
                            dataservice.getAdditionlCharge({
                                StartDate: moment(selectedNrtMain().startDate()).format(ist.utcFormat),
                                VehicleId: selectedNrtMain().vehicleDetail().vehicleId(),
                            }, {
                                success: function (data) {
                                    additionalCharges.removeAll();
                                    var addChargeList = [];
                                    _.each(data, function (item) {
                                        var addChrg = new model.AdditionalChargeClientMapper(item);
                                        addChargeList.push(addChrg);
                                    });
                                    ko.utils.arrayPushAll(additionalCharges(), addChargeList);
                                    additionalCharges.valueHasMutated();
                                    //Show The Dialog
                                    view.showActivityDialog();
                                    isLoadingNrt(false);
                                },
                                error: function () {
                                    isLoadingNrt(false);
                                    toastr.error(ist.resourceText.additionalChargeLoadFailedMsg);
                                }
                            });

                        }
                    },
                    //On Add Chauffer 
                    onAddChauffer = function (chauffer) {
                        if (true) {
                            isLoadingNrt(true);
                            dataservice.getChauffers({
                                OperationsWorkPlaceId: selectedNrtMain().outLocationId(),
                                StartDtTime: moment(selectedNrtMain().startDate()).format(ist.utcFormat),
                                EndDtTime: moment(selectedNrtMain().endDate()).format(ist.utcFormat),
                            }, {
                                success: function (data) {
                                    isChaufferChecked(false);
                                    chauffers.removeAll();
                                    var chaufferList = [];
                                    _.each(data, function (item) {
                                        var chauffr = new model.ChaufferClientMapper(item);
                                        chaufferList.push(chauffr);
                                    });
                                    ko.utils.arrayPushAll(chauffers(), chaufferList);
                                    chauffers.valueHasMutated();
                                    //Show The Dialog
                                    view.showChaufferDialog();
                                    isLoadingNrt(false);
                                },
                                error: function () {
                                    isLoadingNrt(false);
                                    toastr.error(ist.resourceText.additionalChargeLoadFailedMsg);
                                }
                            });

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
                    // Save NRT Main
                    saveNrtMain = function (nrtMain) {
                        dataservice.saveNrt(model.NRTServerMapper(nrtMain), {
                            success: function (data) {
                                selectedNrtMain().id(data);
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
                    //On edit
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
                    //Hide Dialog on selection vehicle
                    isVhicleCheck = ko.computed(function () {
                        if (selectedNrtMain() != undefined) {
                            if (isVhicleChecked()) {
                                hide();
                            }
                        }
                    }, this),
                     //Calculate Total Rate for selected additional charge
                    totalRate = ko.computed(function () {
                        if (selectedAdditionalChargeItem() != undefined && selectedAdditionalChargeItem().qty() != undefined && selectedAdditionalChargeItem().rate() != undefined) {
                            var total = selectedAdditionalChargeItem().qty() * selectedAdditionalChargeItem().rate();
                            selectedAdditionalChargeItem().totalRate(total);
                        }
                    }, this),

                    //Calculate Fuel difference
                    fuelDiff = ko.computed(function () {
                        if (selectedNrtMain() != undefined && selectedNrtMain().vehicleDetail().fuelOut() != undefined && selectedNrtMain().vehicleDetail().fuelIn() != undefined) {
                            var diff = selectedNrtMain().vehicleDetail().fuelIn() - selectedNrtMain().vehicleDetail().fuelOut();
                            selectedNrtMain().vehicleDetail().fuelDiff(diff);
                        }
                    }, this),

                    // Template Chooser
                    templateToUse = function (chauffer) {
                        return (chauffer === selectedChaufferItem() ? 'editChaufferItemTemplate' : 'itemChaufferItemTemplate');
                    },
                    //template To Use For Maintenance Activity
                    templateToUseForMaintenaceActivity = function (addChrge) {
                        return (addChrge === selectedAdditionalChargeItem() ? 'editAdditionalChargeTemplate' : 'itemAdditionalChargeTemplate');
                    },
                    //Hide Update and cancel Button
                    hideUpdateCancelBtn = function () {

                    },
                    //Hide Save and cancel Button
                    hideSaveCancelBtn = function () {
                        selectedNrtMain().vehicleDetail(new model.VehicleDetail());
                        showSaveCancelBtn(false);
                    },


                    // Select a Chauffer
                    selectChaufferItem = function (chauffer) {
                        if (selectedChaufferItem() !== chauffer) {
                            selectedChaufferItem(chauffer);
                        }
                        isEditable(true);
                    },
                    selectAdditionalChargeItem = function (addChrg) {
                        if (selectedAdditionalChargeItem() !== addChrg) {
                            selectedAdditionalChargeItem(addChrg);
                        }
                        isEditable(true);
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
                    showEditBtn: showEditBtn,
                    showSaveCancelBtn: showSaveCancelBtn,
                    isVhicleChecked: isVhicleChecked,
                    selectVehicle: selectVehicle,
                    selectedVehicle: selectedVehicle,
                    selectedChauffer: selectedChauffer,
                    selectChauffer: selectChauffer,
                    isChaufferChecked: isChaufferChecked,
                    selectedChaufferItem: selectedChaufferItem,
                    templateToUse: templateToUse,
                    isEditable: isEditable,
                    selectedAdditionalChargeItem: selectedAdditionalChargeItem,
                    //Arrays
                    filteredLocations: filteredLocations,
                    locations: locations,
                    operations: operations,
                    nRTTypes: nRTTypes,
                    vehicleStatuses: vehicleStatuses,
                    vehicleDetails: vehicleDetails,
                    chauffers: chauffers,
                    selectedChaufferList: selectedChaufferList,
                    additionalCharges: additionalCharges,
                    selectedAdditionalChargeList: selectedAdditionalChargeList,
                    vehiclesForListView: vehiclesForListView,
                    // Utility Methods
                    initialize: initialize,
                    pager: pager,
                    collapseFilterSection: collapseFilterSection,
                    showFilterSection: showFilterSection,
                    onEditChaufferCharge: onEditChaufferCharge,
                    hideUpdateCancelBtn: hideUpdateCancelBtn,
                    onUpdateChaufferCharge: onUpdateChaufferCharge,
                    onAddVehicleDetail: onAddVehicleDetail,
                    onAddActivity: onAddActivity,
                    onAddChauffer: onAddChauffer,
                    cancel: cancel,
                    proceed: proceed,
                    selectChaufferItem: selectChaufferItem,
                    deleteChaufferItem: deleteChaufferItem,
                    onOpenTicket: onOpenTicket,
                    applyAdditionalCharges: applyAdditionalCharges,
                    templateToUseForMaintenaceActivity: templateToUseForMaintenaceActivity,
                    deleteAdditionalChargeItem: deleteAdditionalChargeItem,
                    selectAdditionalChargeItem: selectAdditionalChargeItem,
                    hideSaveCancelBtn: hideSaveCancelBtn,
                    onSaveVehicle: onSaveVehicle,
                    onEditVehicle: onEditVehicle,
                    onUpdateVehicle: onUpdateVehicle,
                    // Utility Methods

                };
            })()
        };
        return ist.nRT.viewModel;
    });
