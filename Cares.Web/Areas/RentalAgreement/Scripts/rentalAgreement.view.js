/*
    View for the Rental Agreement. Used to keep the viewmodel clear of UI related logic
*/
define("rentalAgreement/rentalAgreement.view",
    ["jquery", "rentalAgreement/rentalAgreement.viewModel"], function ($, rentalAgreementViewModel) {

        var ist = window.ist || {};
        
        // View 
        ist.rentalAgreement.view = (function (specifiedViewModel) {
            var
                // View model 
                viewModel = specifiedViewModel,
                // Binding root used with knockout
                bindingRoot = $("#rentalAgreementBinding")[0],
                // Close Popover
                closePopover = function(popoverId) {
                    var element = $("#" + popoverId);
                    if (element) {
                        element.popover('hide');
                    }
                },
                // Initialize
                initialize = function () {
                    if (!bindingRoot) {
                        return;
                    }

                    var hireGroups = new Bloodhound({
                        datumTokenizer: function (d) {
                            return Bloodhound.tokenizers.whitespace(d.hireGroup);
                        },
                        queryTokenizer: Bloodhound.tokenizers.whitespace,
                        remote: {
                            rateLimitWait: 1000,
                            url: ist.siteUrl + '/Api/RentalAgreementHireGroups?searchText=%QUERY&operationWorkPlaceId=%operation&startDtTime=%stdt&endDtTime=%enddt',
                            ajax: {
                               type: 'POST'
                            },
                            replace: function(url, query) {
                                return url.replace('%QUERY', query).replace('%operation', viewModel.rentalAgreement().openLocation())
                                .replace('%stdt', moment(viewModel.rentalAgreement().start()).format(ist.utcFormat) + 'Z')
                                .replace('%enddt', moment(viewModel.rentalAgreement().end()).format(ist.utcFormat) + 'Z');
                            },
                            filter: function (data) {
                                return _.map(data, function (hireGroup) {
                                    return viewModel.model.HireGroupDetail.Create(hireGroup);
                                });
                            }
                        }
                    });

                    hireGroups.initialize();

                    $('#rentalAgreementHireGroup').typeahead({
                        highlight: true
                    },
                    {
                        displayKey: 'hireGroup',
                        source: hireGroups.ttAdapter()
                    }).bind('typeahead:selected', function(obj, selected) {
                        if (selected) {
                            viewModel.selectHireGroup(selected);
                        }
                    });

                    // Extras Popover shows - Clear Selection
                    $('#addExtrasPopoverLink').on('show.bs.popover', function () {
                        viewModel.resetServiceItemsSelection();
                    });

                    // Chauffer Popover shows - Clear Selection
                    $('#addChauffersPopoverLink').on('show.bs.popover', function () {
                        viewModel.setChaufferPopover();
                    });

                    // Chauffer Popover shows - Clear Selection
                    $('#addDamagesPopoverLink').on('show.bs.popover', function () {
                        viewModel.resetAdditionalChargesSelection();
                    });

                };

            initialize();

           
            return {
                bindingRoot: bindingRoot,
                closePopover: closePopover,
                viewModel: viewModel
            };
        })(rentalAgreementViewModel);

        // Initialize the view model
        if (ist.rentalAgreement.view.bindingRoot) {
            rentalAgreementViewModel.initialize(ist.rentalAgreement.view);
        }

        return ist.rentalAgreement.view;
    });