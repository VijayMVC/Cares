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
                        //local: [
                        //  { val: 'Alabama' },
                        //  { val: 'Alaska' },
                        //  { val: 'Arizona' },
                        //  { val: 'Arkansas' },
                        //  { val: 'California' },
                        //  { val: 'Colorado' },
                        //  { val: 'Connecticut' },
                        //  { val: 'Delaware' },
                        //  { val: 'Florida' },
                        //  { val: 'Georgia' },
                        //  { val: 'Hawaii' },
                        //  { val: 'Idaho' },
                        //  { val: 'Illinois' },
                        //  { val: 'Indiana' },
                        //  { val: 'Iowa' },
                        //  { val: 'Kansas' },
                        //  { val: 'Kentucky' },
                        //  { val: 'Louisiana' },
                        //  { val: 'Maine' },
                        //  { val: 'Maryland' },
                        //  { val: 'Massachusetts' },
                        //  { val: 'Michigan' },
                        //  { val: 'Minnesota' },
                        //  { val: 'Mississippi' },
                        //  { val: 'Missouri' },
                        //  { val: 'Montana' },
                        //  { val: 'Nebraska' },
                        //  { val: 'Nevada', id: 1 },
                        //  { val: 'New Hampshire' },
                        //  { val: 'New Jersey' },
                        //  { val: 'New Mexico' },
                        //  { val: 'New York' },
                        //  { val: 'North Carolina' },
                        //  { val: 'North Dakota' },
                        //  { val: 'Ohio' },
                        //  { val: 'Oklahoma' },
                        //  { val: 'Oregon' },
                        //  { val: 'Pennsylvania' },
                        //  { val: 'Rhode Island' },
                        //  { val: 'South Carolina' },
                        //  { val: 'South Dakota' },
                        //  { val: 'Tennessee' },
                        //  { val: 'Texas' },
                        //  { val: 'Utah' },
                        //  { val: 'Vermont' },
                        //  { val: 'Virginia' },
                        //  { val: 'Washington' },
                        //  { val: 'West Virginia' },
                        //  { val: 'Wisconsin' },
                        //  { val: 'Wyoming' }
                        //]
                        remote: {
                            rateLimitWait: 1000,
                            url: '/Api/RentalAgreementHireGroups?searchText=%QUERY&operationWorkPlaceId=%operation&startDtTime=%stdt&endDtTime=%enddt',
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
                    
                };

            initialize();

           
            return {
                bindingRoot: bindingRoot,
                viewModel: viewModel
            };
        })(rentalAgreementViewModel);

        // Initialize the view model
        if (ist.rentalAgreement.view.bindingRoot) {
            rentalAgreementViewModel.initialize(ist.rentalAgreement.view);
        }

        return ist.rentalAgreement.view;
    });