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
                // Show the dialog
                show = function () {
                    $("#hiregroupInsuranceDialog").modal("show");
                },
                // Hide the dialog
                hide = function () {
                    $("#hiregroupInsuranceDialog").modal("hide");
                },
                // Show the dialog
                showRaVehicleCheckListDialog = function (status) {
                    if (status) {
                        $("#raVehicleCheckListOutDialog").modal("show");
                    }
                    else {
                        $("#raVehicleCheckListInDialog").modal("show");
                    }
                },
                // Hide the dialog
                hideRaVehicleCheckListDialog = function (status) {
                    if (status) {
                        $("#raVehicleCheckListOutDialog").modal("hide");
                    }
                    else {
                        $("#raVehicleCheckListInDialog").modal("hide");
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

                    // Damages Popover shows - Clear Selection
                    $('#addDamagesPopoverLink').on('show.bs.popover', function () {
                        viewModel.resetAdditionalChargesSelection();
                    });

                    // Add Vehicle Popover shows - Clear Selection
                    $('#addVehiclesPopoverLink').on('show.bs.popover', function () {
                        viewModel.setVehicleFilters();
                    });

                };

            initialize();
           
            return {
                bindingRoot: bindingRoot,
                closePopover: closePopover,
                viewModel: viewModel,
                show: show,
                hide: hide,
                showRaVehicleCheckListDialog: showRaVehicleCheckListDialog,
                hideRaVehicleCheckListDialog: hideRaVehicleCheckListDialog
            };
        })(rentalAgreementViewModel);

        // Initialize the view model
        if (ist.rentalAgreement.view.bindingRoot) {
            rentalAgreementViewModel.initialize(ist.rentalAgreement.view);
        }

        return ist.rentalAgreement.view;
    });