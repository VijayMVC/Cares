/*
    View for the Insurance Types Used to keep the viewmodel clear of UI related logic
*/
define("insuranceType/insuranceType.view",
    ["jquery", "insuranceType/insuranceType.viewModel"], function ($, insuranceTypeViewModel) {
        var ist = window.ist || {};
        // View 
        ist.InsuranceType.view = (function (specifiedViewModel) {
            var
                // View model 
                viewModel = specifiedViewModel,
                // Binding root used with knockout
                bindingRoot = $("#InsuranceTypeBinding")[0],
                // Initialize
                initialize = function () {
                    if (!bindingRoot) {
                        return;
                    }
                    // Handle Sorting
                    handleSorting("InsuranceTypeTable", viewModel.sortOn, viewModel.sortIsAsc, viewModel.getInsuranceTypes);
                };
            initialize();
            return {
                bindingRoot: bindingRoot,
                viewModel: viewModel
            };
        })(insuranceTypeViewModel);
        // Initialize the view model
        if (ist.InsuranceType.view.bindingRoot) {
            insuranceTypeViewModel.initialize(ist.InsuranceType.view);
        }
        return ist.InsuranceType.view;
    });