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
                    hiregroupDetails = ko.observableArray([]),
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
                                hiregroupDetails.removeAll();
                                ko.utils.arrayPushAll(hiregroupDetails(), data.HireGroupDetails);
                                hiregroupDetails.valueHasMutated();

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
                    getAdditionalChargesById = function (addDriverChrg) {
                        //isLoadingAdditionalCharge(true);
                        //dataservice.getAdditionalChargeDetail(model.AdditionalChargeServerMapperForId(addDriverChrg), {
                        //    success: function (data) {
                        //        revisions.removeAll();
                        //        _.each(data, function (item) {
                        //            var revision = new model.AdditionalDriverChargeRevisionClientMapper(item);
                        //            revisions.push(revision);
                        //        });
                        //        isLoadingAdditionalCharge(false);
                        //    },
                        //    error: function () {
                        //        isLoadingAdditionalCharge(false);
                        //        toastr.error(ist.resourceText.loadAddDriverChargeDetailFailedMsg);
                        //    }
                        //});
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
                        // Select the newly added Additional Charge
                        selectedAdditionalCharge(additionalChrg);
                        addEditAdditionalCharge(additionalChrg);
                        showAdditionalChargeEditor();
                    },
                    // Save Additional Charge
                    onSaveAdditionalCharge = function (addDriverChrg) {
                        if (doBeforeSave()) {
                            saveAdditionalCharge(addDriverChrg);
                        }
                    },
                    // Do Before Logic
                    doBeforeSave = function () {
                        var flag = true;
                        if (!addEditAdditionalCharge().isValid()) {
                            selectedAdditionalCharge().errors.showAllMessages();
                            flag = false;
                        }
                        return flag;
                    },
                    //Add Additional Charge
                    onAddAdditionalCharge=function(addCharge) {
                        if (doBeforeAddAddionalCharge()) {
                            additionalCharges.push(addCharge);
                        }
                    },
                       // Do Before Logic
                    doBeforeAddAddionalCharge = function () {
                        var flag = true;
                        if (!addEditAdditionalCharge().additionalCharge().isValid()) {
                            selectedAdditionalCharge().additionalCharge().errors.showAllMessages();
                            flag = false;
                        }
                        return flag;
                    },

                    // Save Additional Charge Main
                    saveAdditionalCharge = function (addDriverChrg) {
                        dataservice.saveAdditionalCharge(model.AdditionalChargeServerMapper(addDriverChrg), {
                            success: function (data) {
                                var additionalDriverCharge = model.AdditionalDriverChargeClientMapper(data);
                                if (selectedAdditionalCharge().id() > 0) {
                                    selectedAdditionalCharge().id(additionalDriverCharge.id()),
                                        selectedAdditionalCharge().companyId(additionalDriverCharge.companyId()),
                                        selectedAdditionalCharge().companyCodeName(additionalDriverCharge.companyCodeName()),
                                        selectedAdditionalCharge().depId(additionalDriverCharge.depId()),
                                        selectedAdditionalCharge().operationId(additionalDriverCharge.operationId()),
                                        selectedAdditionalCharge().operationCodeName(additionalDriverCharge.operationCodeName()),
                                        selectedAdditionalCharge().tariffTypeId(additionalDriverCharge.tariffTypeId()),
                                        selectedAdditionalCharge().tariffTypeCode(additionalDriverCharge.tariffTypeCode()),
                                        selectedAdditionalCharge().tariffTypeCodeName(additionalDriverCharge.tariffTypeCodeName()),
                                        selectedAdditionalCharge().effectiveStartDate(additionalDriverCharge.effectiveStartDate()),
                                        selectedAdditionalCharge().rate(additionalDriverCharge.rate()),
                                        selectedAdditionalCharge().revisionNumber(additionalDriverCharge.revisionNumber()),
                                        closeAdditionalChargeEditor();
                                } else {
                                    addDriverChrgs.splice(0, 0, additionalDriverCharge);
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
                    onEditAddDriverChrg = function (addDriverChrg, e) {
                        //selectedAdditionalCharge(addDriverChrg);
                        //addEditAdditionalCharge(addDriverChrg);
                        //getAdditionalChargesById(addDriverChrg);
                        showAdditionalChargeEditor();
                        e.stopImmediatePropagation();
                    },
                    // Delete a Additional Charge
                    onDeleteAddDriverChrg = function (addDriverChrg) {
                        if (!addDriverChrg.id()) {
                            addDriverChrgs.remove(addDriverChrg);
                            return;
                        }
                        // Ask for confirmation
                        confirmation.afterProceed(function () {
                            deleteAdditionalCharge(addDriverChrg);
                        });
                        confirmation.show();
                    },
                    // Delete Additional Charge
                    deleteAdditionalCharge = function (addDriverChrg) {
                        dataservice.deleteAdditionalCharge(model.AdditionalChargeServerMapperForId(addDriverChrg), {
                            success: function () {
                                addDriverChrgs.remove(addDriverChrg);
                                toastr.success(ist.resourceText.serviceRateDeleteSuccessMsg);
                            },
                            error: function () {
                                toastr.error(ist.resourceText.serviceRateDeleteFailedMsg);
                            }
                        });
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
                    hiregroupDetails: hiregroupDetails,
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
                    onEditAddDriverChrg: onEditAddDriverChrg,
                    onDeleteAddDriverChrg: onDeleteAddDriverChrg,
                    createAdditionalCharge: createAdditionalCharge,
                    onAddAdditionalCharge: onAddAdditionalCharge,
                    // Utility Methods

                };
            })()
        };
        return ist.additionalCharge.viewModel;
    });
