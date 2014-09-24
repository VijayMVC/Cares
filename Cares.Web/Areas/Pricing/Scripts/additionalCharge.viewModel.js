/*
    Module with the view model for the Additional Charge
*/
define("additionalCharge/additionalCharge.viewModel",
    ["jquery", "amplify", "ko", "additionalCharge/additionalCharge.dataservice", "additionalCharge/additionalCharge.model", "common/confirmation.viewModel", "common/pagination"],
    function ($, amplify, ko, dataservice, model, confirmation, pagination) {
        var ist = window.ist || {};
        ist.additionalCharge = {
            viewModel: (function () {
                var // the view 
                    view,
                    // Active Additional Charge Type
                    selectedAdditionalChargeType = ko.observable(),
                    // Active Additional Charge
                    selectedAdditionalCharge = ko.observable(),
                    //Add/Edit Additional Charge 
                    addEditAdditionalCharge = ko.observable(),
                    // Show Filter Section
                    filterSectionVisilble = ko.observable(false),
                    // #region Arrays
                    //additional Charges
                    additionalCharges = ko.observableArray([]),
                    //Additional Type Charges
                    additionalTypeCharges = ko.observableArray([]),
                    //Hire Group Detail List
                    hireGroupDetails = ko.observableArray([]),
                    // #endregion Arrays
                    // #region Busy Indicators
                    isLoadingAdditionalCharge = ko.observable(false),
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
                    isAdditionalChargeEditorVisible = ko.observable(false),
                    // Pagination
                    pager = ko.observable(),
                    // Search Filter
                    searchFilter = ko.observable(),
                    // #region Utility Functions
                    // Initialize the view model
                    initialize = function (specifiedView) {
                        view = specifiedView;
                        ko.applyBindings(view.viewModel, view.bindingRoot);
                        getBase();
                        // Set Pager
                        pager(new pagination.Pagination({}, additionalTypeCharges, getAdditionalCharges));
                        getAdditionalCharges();

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
                        dataservice.getAdditionalChargeBase({
                            success: function (data) {
                                //Hire group Details
                                hireGroupDetails.removeAll();
                                ko.utils.arrayPushAll(hireGroupDetails(), data.HireGroupDetails);
                                hireGroupDetails.valueHasMutated();
                                if (callBack && typeof callBack === 'function') {
                                    callBack();
                                }
                            },
                            error: function () {
                                toastr.error(ist.resourceText.loadBaseDataFailedMsg);
                            }
                        });
                    },
                    //Get Additional Charge By Id
                    getAdditionalChargeById = function (addChrg) {
                        isLoadingAdditionalCharge(true);
                        dataservice.getAdditionalChargeDetail(model.AdditionalChrgServerMapperForId(addChrg), {
                            success: function (data) {
                                additionalCharges.removeAll();
                                _.each(data, function (item) {
                                    var sddCharge = new model.AdditionalChargeClientMapper(item);
                                    additionalCharges.push(sddCharge);
                                });
                                isLoadingAdditionalCharge(false);
                            },
                            error: function () {
                                isLoadingAdditionalCharge(false);
                                toastr.error(ist.resourceText.loadAddDriverChargeDetailFailedMsg);
                            }
                        });
                    },
                    // Search 
                    search = function () {
                        pager().reset();
                        getAdditionalCharges();
                    },
                    //Reset
                    reset = function () {
                        searchFilter(undefined);
                        search();
                    },
                    // Map Additional type Charges - Server to Client
                    mapAdditionalTypeCharges = function (data) {
                        var additionalTypeChargeList = [];
                        _.each(data.AdditionalChargeTypes, function (item) {
                            var addChrgType = new model.AdditionalChargeTypeClientMapper(item);
                            additionalTypeChargeList.push(addChrgType);
                        });
                        ko.utils.arrayPushAll(additionalTypeCharges(), additionalTypeChargeList);
                        additionalTypeCharges.valueHasMutated();
                    },
                    //Create Additional Charge
                    createAdditionalCharge = function () {
                        var additionalChrg = new model.AdditionalChargeType();
                        additionalCharges.removeAll();
                        // Select the newly added Additional Charge
                        selectedAdditionalChargeType(additionalChrg);
                        addEditAdditionalCharge(additionalChrg);
                        showAdditionalChargeEditor();
                    },
                    // Save Additional Charge
                    onSaveAdditionalCharge = function (addCharge) {
                        if (doBeforeSave()) {

                            addCharge.additionalChargesList.removeAll();
                            ko.utils.arrayPushAll(addCharge.additionalChargesList(), additionalCharges());
                            saveAdditionalCharge(addCharge);
                        }
                    },
                    // Do Before Logic
                    doBeforeSave = function () {
                        var flag = true;
                        if (!addEditAdditionalCharge().isValid()) {
                            selectedAdditionalChargeType().errors.showAllMessages();
                            flag = false;
                        }
                        return flag;
                    },
                    //Add Additional Charge
                    onAddAdditionalCharge = function (addCharge) {
                        if (doBeforeAddAddionalCharge()) {
                            var flag = true;
                            if (selectedAdditionalCharge() !== undefined) {
                                //In case Of edit
                                _.each(additionalCharges(), function (item) {
                                    if (item.hireGroupDetailId() === addCharge.hireGroupDetailId() && addCharge.hireGroupDetailId() !== selectedAdditionalCharge().hireGroupDetailId()) {
                                        toastr.error("Additional Charge with the given parameters [HireGroupDetail] are already defined.");
                                        flag = false;
                                    }
                                });
                            } else {
                                //In case of New
                                _.each(additionalCharges(), function (item) {
                                    if (item.hireGroupDetailId() === addCharge.hireGroupDetailId()) {
                                        toastr.error("Additional Charge with the given parameters [HireGroupDetail] are already defined.");
                                        flag = false;
                                    }
                                });
                            }


                            if (flag) {
                                //edit
                                if (selectedAdditionalCharge() !== undefined) {
                                    selectedAdditionalCharge().hireGroupDetailId(addCharge.hireGroupDetailId());
                                    selectedAdditionalCharge().startDate(addCharge.startDate());
                                    selectedAdditionalCharge().rate(addCharge.rate());
                                    selectedAdditionalCharge(undefined);
                                } else {
                                    //New Add
                                    additionalCharges.push(addCharge);
                                }
                                addEditAdditionalCharge().additionalCharge(new model.AdditionalCharge());
                            }
                        }
                    },
                       // Do Before Logic
                    doBeforeAddAddionalCharge = function () {
                        var flag = true;
                        if (!addEditAdditionalCharge().additionalCharge().isValid()) {
                            addEditAdditionalCharge().additionalCharge().errors.showAllMessages();
                            flag = false;
                        }
                        return flag;
                    },

                    // Save Additional Charge Main
                    saveAdditionalCharge = function (addCharge) {
                        dataservice.saveAdditionalCharge(model.AdditionalChargeTypeServerMapper(addCharge), {
                            success: function (data) {
                                var additionalCharge = model.AdditionalChargeTypeClientMapper(data);
                                if (selectedAdditionalChargeType().id() > 0) {
                                    selectedAdditionalChargeType().isEditable(additionalCharge.isEditable()),
                                    closeAdditionalChargeEditor();
                                } else {
                                    additionalTypeCharges.splice(0, 0, additionalCharge);
                                    closeAdditionalChargeEditor();
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
                     //Edit Additional Charge
                    onEditAdditionalChargeType = function (addChrg, e) {
                        additionalCharges.removeAll();
                        selectedAdditionalChargeType(addChrg);
                        addEditAdditionalCharge(addChrg);
                        getAdditionalChargeById(addChrg);
                        showAdditionalChargeEditor();
                        e.stopImmediatePropagation();
                    },
                    onEditAdditionalCharge = function (addCharge) {
                        selectedAdditionalCharge(addCharge);
                        var additionalCharge = new model.AdditionalCharge();
                        additionalCharge.id(addCharge.id());
                        additionalCharge.hireGroupDetailId(addCharge.hireGroupDetailId());
                        additionalCharge.startDate(addCharge.startDate());
                        additionalCharge.rate(addCharge.rate());
                        addEditAdditionalCharge().additionalCharge(additionalCharge);
                    },
                    onDeleteAdditionalCharge = function (addCharge) {
                        additionalCharges.remove(addCharge);
                    },
                    // Delete a Additional Charge
                    onDeleteAdditionalChargeType = function (addChrg) {
                        if (!addChrg.id()) {
                            additionalTypeCharges.remove(addChrg);
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
                                additionalTypeCharges.remove(addChrg);
                                toastr.success(ist.resourceText.serviceRateDeleteSuccessMsg);
                            },
                            error: function () {
                                toastr.error(ist.resourceText.serviceRateDeleteFailedMsg);
                            }
                        });
                    },
                        onSelectedHireGroupDetail = function (hireGroupDetail) {
                            if (hireGroupDetail.hireGroupDetailId() != undefined) {
                                _.each(hireGroupDetails(), function (item) {
                                    if (item.HireGroupDetailId === hireGroupDetail.hireGroupDetailId()) {
                                        addEditAdditionalCharge().additionalCharge().hireGroupDetailCodeName(item.HireGroupDetailCodeName);
                                        addEditAdditionalCharge().additionalCharge().hireGroupDetailId(hireGroupDetail.hireGroupDetailId());
                                    }
                                });
                            }
                        },
                    // Show Additional Charge Editor
                    showAdditionalChargeEditor = function () {
                        isAdditionalChargeEditorVisible(true);
                    },
                    //close Additional Charge Editor
                    closeAdditionalChargeEditor = function () {
                        isAdditionalChargeEditorVisible(false);
                    },
                    // Get Additional Charges
                    getAdditionalCharges = function () {
                        isLoadingAdditionalCharge(true);
                        dataservice.getAdditionalCharges({
                            SearchString: searchFilter(),
                            PageSize: pager().pageSize(),
                            PageNo: pager().currentPage(),
                            SortBy: sortOn(),
                            IsAsc: sortIsAsc()
                        }, {
                            success: function (data) {
                                pager().totalCount(data.TotalCount);
                                additionalTypeCharges.removeAll();
                                mapAdditionalTypeCharges(data);
                                isLoadingAdditionalCharge(false);
                            },
                            error: function () {
                                isLoadingAdditionalCharge(false);
                                toastr.error(ist.resourceText.additionalDriverChargeLoadFailedMsg);
                            }
                        });
                    };
                // #endregion Service Calls

                return {
                    // Observables
                    selectedAdditionalChargeType: selectedAdditionalChargeType,
                    selectedAdditionalCharge: selectedAdditionalCharge,
                    addEditAdditionalCharge: addEditAdditionalCharge,
                    isAdditionalChargeEditorVisible: isAdditionalChargeEditorVisible,
                    sortOn: sortOn,
                    sortIsAsc: sortIsAsc,
                    sortOnHg: sortOnHg,
                    sortIsAscHg: sortIsAscHg,
                    filterSectionVisilble: filterSectionVisilble,
                    //Arrays
                    additionalCharges: additionalCharges,
                    additionalTypeCharges: additionalTypeCharges,
                    hireGroupDetails: hireGroupDetails,
                    //Filters
                    searchFilter: searchFilter,
                    // Utility Methods
                    initialize: initialize,
                    search: search,
                    pager: pager,
                    collapseFilterSection: collapseFilterSection,
                    showFilterSection: showFilterSection,
                    closeAdditionalChargeEditor: closeAdditionalChargeEditor,
                    showAdditionalChargeEditor: showAdditionalChargeEditor,
                    onSaveAdditionalCharge: onSaveAdditionalCharge,
                    reset: reset,
                    onEditAdditionalChargeType: onEditAdditionalChargeType,
                    onDeleteAdditionalChargeType: onDeleteAdditionalChargeType,
                    createAdditionalCharge: createAdditionalCharge,
                    onAddAdditionalCharge: onAddAdditionalCharge,
                    onSelectedHireGroupDetail: onSelectedHireGroupDetail,
                    onDeleteAdditionalCharge: onDeleteAdditionalCharge,
                    onEditAdditionalCharge: onEditAdditionalCharge
                    // Utility Methods

                };
            })()
        };
        return ist.additionalCharge.viewModel;
    });
