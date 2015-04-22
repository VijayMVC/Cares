/*
    Module with the view model for the RA Report
*/
define("common/raReport.viewModel",
    ["jquery", "ko"],
    function ($, ko) {
        var ist = window.ist || {};
        ist.raReport = {
            viewModel: (function () {
                var // the view 
                    view,
                    //Ra Report Id Filter
                    raRentalAgreementId = ko.observable(),
                    //report source
                    reportSrc = ko.observable(),
                    // Initialize the view model
                    initialize = function(specifiedView) {
                        view = specifiedView;
                        ko.applyBindings(view.viewModel, view.bindingRoot);
                        reportSrc(undefined);
                    },
                    // Search 
                    search= function() {
                        reportSrc(ist.siteUrl + '/Reports/RentalAgreementReport.aspx?id=' + raRentalAgreementId());
                    },
                    //show rental agreement report from external view model
                    showRentalAgreement = function (raId) {
                        reportSrc(ist.siteUrl + '/Reports/RentalAgreementReport.aspx?id=' + raId());
                    };
                    
                return {
                    // Observables
                    raRentalAgreementId: raRentalAgreementId,
                    // Utility Methods
                    initialize: initialize,
                    search: search,
                    reportSrc: reportSrc,
                    showRentalAgreement: showRentalAgreement
                };
            })()
        };
        return ist.raReport.viewModel;
    });
