/*
    View for the RA Queue. Used to keep the viewmodel clear of UI related logic
*/
define("bookingMain/bookingMain.view",
    ["jquery", "bookingMain/bookingMain.viewModel"], function ($, bookingMainViewModel) {

        var ist = window.ist || {};

        // View 
        ist.bookingMain.view = (function (specifiedViewModel) {
            var
                // View model 
                viewModel = specifiedViewModel,
                // Binding root used with knockout
                bindingRoot = $("#bookingMainBinding")[0],
                // Goto Rental Agreement
                gotoRentalAgreement = function (bookingMainId) {
                    openUrlInNewWindow("/RentalAgreement/Home/Index/#/byId/" + bookingMainId);
                },
                // Open url in new window
                openUrlInNewWindow = function (url) {
                    window.open(url, "_blank");
                },
                // Initialize
                initialize = function () {
                    if (!bindingRoot) {
                        return;
                    }
                    // Handle Sorting
                    handleSorting("bookingMainTable", viewModel.sortOn, viewModel.sortIsAsc, viewModel.getBookingMain);
                };
            initialize();
            return {
                bindingRoot: bindingRoot,
                viewModel: viewModel,
                gotoRentalAgreement: gotoRentalAgreement
            };
        })(bookingMainViewModel);

        // Initialize the view model
        if (ist.bookingMain.view.bindingRoot) {
            bookingMainViewModel.initialize(ist.bookingMain.view);
        }
        return ist.bookingMain.view;
    });