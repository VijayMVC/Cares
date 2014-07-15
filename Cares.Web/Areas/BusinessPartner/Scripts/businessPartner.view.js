/*
    View for the Product. Used to keep the viewmodel clear of UI related logic
*/
define("product/businessPartner.view",
    ["jquery", "product/businessPartner.viewModel"], function ($, businessPartnerViewModel) {

        var ist = window.ist || {};
        
        // View 
        ist.businessPartner.view = (function (specifiedViewModel) {
            var
                // View model 
                viewModel = specifiedViewModel,
                // Binding root used with knockout
                bindingRoot = $("#businessPartnerBinding")[0],
                // Initialize
                initialize = function () {
                    if (!bindingRoot) {
                        return;
                    }
                    
                    // Handle Sorting
                    handleSorting("businessPartnerTable", viewModel.sortOn, viewModel.sortIsAsc, viewModel.getbusinessPartners);
                };

            initialize();

           
            return {
                bindingRoot: bindingRoot,
                viewModel: viewModel
            };
        })(businessPartnerViewModel);

        // Initialize the view model
        if (ist.businessPartner.view.bindingRoot) {
            businessPartnerViewModel.initialize(ist.businessPartner.view);
        }

        return ist.businessPartner.view;
    });