/*
    View for the Company. Used to keep the viewmodel clear of UI related logic
*/
define("company/company.view",
    ["jquery", "company/company.viewModel"], function ($, companyViewModel) {
        var ist = window.ist || {};
        // View 
        ist.Company.view = (function (specifiedViewModel) {
            var
                // View model 
                viewModel = specifiedViewModel,
                // Binding root used with knockout
                bindingRoot = $("#companyBinding")[0],
                // Initialize
                initialize = function () {
                    if (!bindingRoot) {
                        return;
                    }
                    // Handle Sorting
                    handleSorting("CompanyTable", viewModel.sortOn, viewModel.sortIsAsc, viewModel.getCompanies);
                };
            initialize();
            return {
                bindingRoot: bindingRoot,
                viewModel: viewModel
            };
        })(companyViewModel);
        // Initialize the view model
        if (ist.Company.view.bindingRoot) {
            companyViewModel.initialize(ist.Company.view);
        }
        return ist.Company.view;
    });