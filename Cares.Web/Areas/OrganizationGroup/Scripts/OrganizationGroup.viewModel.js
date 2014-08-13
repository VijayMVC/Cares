/*
    Module with the view model for the FleetPool
*/
define("OrganizationGroup/OrganizationGroup.viewModel",
    ["jquery", "amplify", "ko", "OrganizationGroup/OrganizationGroup.dataservice", "OrganizationGroup/OrganizationGroup.model",
    "common/confirmation.viewModel", "common/pagination"],
    function($, amplify, ko, dataservice, model, confirmation, pagination) {
        var ist = window.ist || {};
        ist.OrganizationGroup = {
            viewModel: (function () {
                var view,
                    search = function() {
                        alert('dfd');
                    },
                    // Initialize the view model
                    initialize = function (specifiedView)
                    {
                        view = specifiedView;
                        ko.applyBindings(view.viewModel, view.bindingRoot);
                      //  pager(pagination.Pagination({ PageSize: 10 }, fleetPools, getFleetPools));
                    };
                return {
                    initialize:initialize,
                    search: search
                };
            })()
        };
        return ist.OrganizationGroup.viewModel;
    });
