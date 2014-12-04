/*
    Module with the view model for the RA Queue
*/
define("bookingMain/bookingMain.viewModel",
    ["jquery", "amplify", "ko", "bookingMain/bookingMain.dataservice", "bookingMain/bookingMain.model", "common/confirmation.viewModel", "common/pagination"],
    function ($, amplify, ko, dataservice, model, confirmation, pagination) {
        var ist = window.ist || {};
        ist.bookingMain = {
            viewModel: (function () {
                var // the view 
                    view,
                    // Show Filter Section
                    filterSectionVisilble = ko.observable(false),
                    // #region Busy Indicators
                    isLoadingBookingMain = ko.observable(false),
                    bookingMain = ko.observableArray([]),
                    //Operation Work Places
                    operationWorkPlaces = ko.observableArray([]),
                    test = ko.observable(true),
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
                        // Is Editable
                    isEditable = ko.observable(false),
                    // Pagination
                    pager = ko.observable(),
                    
                    //Open Location Filter
                     openLocFilter = ko.observable(),
                   
                    //booking Number
                    bookingNumber = ko.observable(),
                          // #region Utility Functions
                    // Initialize the view model
                    initialize = function (specifiedView) {
                        view = specifiedView;
                        ko.applyBindings(view.viewModel, view.bindingRoot);
                        getBase();
                        // Set Pager
                        pager(new pagination.Pagination({}, bookingMain, getBookingMain));
                        getBookingMain();

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
                        dataservice.getBookingMainBaseData({
                            success: function (data) {
                                //operation WorkPlaces Array
                                operationWorkPlaces.removeAll();
                                ko.utils.arrayPushAll(operationWorkPlaces(), data.OperationWorkPlaces);
                                operationWorkPlaces.valueHasMutated();
                               
                                if (callBack && typeof callBack === 'function') {
                                    callBack();
                                }
                            },
                            error: function () {
                                toastr.error(ist.resourceText.loadBaseDataFailedMsg);
                            }
                        });
                    },
                    // Search 
                    search = function () {
                        pager().reset();
                        getBookingMain();
                    },
                    //Reset
                      reset = function () {
                          bookingNumber(undefined);
                          openLocFilter(undefined);
                          search();
                      },
                    // Map RA Mains - Server to Client
                    mapBookingMain = function (data) {
                        var bookingMainList = [];
                        _.each(data.BookingMains, function (item) {
                            var bkMain = new model.BookingMainClientMapper(item);
                            bookingMainList.push(bkMain);
                        });
                        ko.utils.arrayPushAll(bookingMain(), bookingMainList);
                        bookingMain.valueHasMutated();
                    },
                    //Edit RA Main
                    onEditBookingMain = function (bkMain) {
                        view.gotoRentalAgreement(bkMain.bookingMainId());
                    },
                    // Get RA Main
                    getBookingMain = function () {
                        isLoadingBookingMain(true);
                        dataservice.getBookingMain({
                            BookingNumber: bookingNumber(),
                            OpenLocationId: openLocFilter(),
                            PageSize: pager().pageSize(),
                            PageNo: pager().currentPage(),
                            SortBy: sortOn(),
                            IsAsc: sortIsAsc()
                        }, {
                            success: function (data) {
                                pager().totalCount(data.TotalCount);
                                bookingMain.removeAll();
                                mapBookingMain(data);
                                isLoadingBookingMain(false);
                            },
                            error: function () {
                                isLoadingBookingMain(false);
                                toastr.error(ist.resourceText.insuranceRatesLoadFailedMsg);
                            }
                        });
                    };
                // #endregion Service Calls

                return {
                    // Observables

                    isLoadingBookingMain: isLoadingBookingMain,
                    sortOn: sortOn,
                    sortIsAsc: sortIsAsc,
                    sortOnHg: sortOnHg,
                    sortIsAscHg: sortIsAscHg,
                    isEditable: isEditable,
                    filterSectionVisilble: filterSectionVisilble,
                    //Arrays
                    bookingMain: bookingMain,
                    operationWorkPlaces: operationWorkPlaces,
                    //Filters
                    openLocFilter: openLocFilter,
                    bookingNumber: bookingNumber,
                    // Utility Methods
                    initialize: initialize,
                    search: search,
                    pager: pager,
                    collapseFilterSection: collapseFilterSection,
                    showFilterSection: showFilterSection,
                    getBookingMain: getBookingMain,
                    reset: reset,
                    onEditBookingMain: onEditBookingMain,
                    test: test
                    // Utility Methods

                };
            })()
        };
        return ist.bookingMain.viewModel;
    });
