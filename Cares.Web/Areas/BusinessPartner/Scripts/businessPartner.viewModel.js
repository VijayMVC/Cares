﻿/*
    Module with the view model for the businessPartner
*/
define("businessPartner/businessPartner.viewModel",
    ["jquery", "amplify", "ko", "businessPartner/businessPartner.dataservice", "businessPartner/businessPartnerWithKoMapping.model", "common/confirmation.viewModel", "common/pagination"],
    function ($, amplify, ko, dataservice, model, confirmation, pagination) {

        var ist = window.ist || {};
        ist.businessPartner = {
            viewModel: (function () {
                var// the view 
                    view,
                    // Active BusinessPartner
                    selectedBusinessPartner = ko.observable(),
                     // listview selected BusinessPartner
                    listSelectedBusinessPartner = ko.observable(),
                    // #region Arrays
                    // BusinessPartners
                    businessPartners = ko.observableArray([]),
                    //categories = ko.observableArray([]),
                    // #endregion Arrays
                    // #region Busy Indicators
                    isLoadingBusinessPartners = ko.observable(false),
                    // #endregion Busy Indicators


                    // #region Observables
                     // Companies Array
                    companies = ko.observableArray([]),
                     // Payment Terms Array 
                    paymentTerms = ko.observableArray([]),
                     // Business Partners Rating Types Array
                    bpRatingTypes = ko.observableArray([]),
                      // Business Legal Statuses Array
                    businessLegalStatuses = ko.observableArray([]),
                      // Response Business  Partners Array
                    respBusinessPartners = ko.observableArray([]),
                      // Business Legal Statuses Array
                    dealingEmployees = ko.observableArray([]),

                    // Sort On
                    sortOn = ko.observable(1),
                    // Sort Order -  true means asc, false means desc
                    sortIsAsc = ko.observable(true),
                    // Is Business Partner Editor Visible
                    isBusinessPartnerEditorVisible = ko.observable(false),
                    // Is Editable
                    isEditable = ko.observable(false),
                    // Pagination
                    pager = ko.observable(),
                    // search filter
                    searchFilter = ko.observable(),
                    // select Filter
                    selectFilter = ko.observable(),
                   // #region Utility Functions
                    // Select filter option Individual or Company
                    optionIndividualOrCompany = [{ Id: true, Name: 'Individual' },{Id : false, Name :  'Company'}],
                    selectBusinessPartner = function (businessPartner) {
                        //if (selectedBusinessPartner()) {
                        //    onSaveBusinessPartner(businessPartner);
                        //    return;
                        //}
                        if (selectedBusinessPartner() !== businessPartner) {
                            selectedBusinessPartner(businessPartner);
                        }
                        //isEditable(false);
                    },
                     //For Edit, Tariff Type Id
                    selectedBusinessPartnerId = ko.observable(),
                    // Edit a Business Partner - In a Form
                    onEditBusinessPartner = function (businessPartner, e) {
                        selectedBusinessPartnerId(businessPartner.businessPartnerId().split('-')[1]);
                        getBusinessPartnerById(selectedBusinessPartnerId());

                        showBusinessPartnerEditor();
                        e.stopImmediatePropagation();
                    },
                    getBusinessPartnerById = function (businessPartnerId) {
                        isLoadingBusinessPartners(true);
                        dataservice.getBusinessPartnerById({
                            id: businessPartnerId
                        }, {
                            success: function (data) {
                                selectedBusinessPartner(model.BusinessPartnerClientMapper(data));
                                isLoadingBusinessPartners(false);
                            },
                            error: function () {
                                isLoadingBusinessPartners(false);
                                toastr.error("Error!");
                            }
                        });
                    },
                    // Show BusinessPartner Editor
                    showBusinessPartnerEditor = function () {
                        isBusinessPartnerEditorVisible(true);
                    },
                    // close BusinessPartner Editor
                    onCloseBusinessPartnerEditor = function () {
                        if (selectedBusinessPartner().hasChanges()) {
                            confirmation.messageText("Do you want to save changes?");
                            confirmation.afterProceed(onSaveBusinessPartner);
                            confirmation.afterCancel(function() {
                                selectedBusinessPartner().reset();
                                closeBusinessPartnerEditor();
                            });
                            confirmation.show();
                            return;
                        }
                        closeBusinessPartnerEditor();
                    },
                    // close Business Partner Editor
                    closeBusinessPartnerEditor = function () {
                        isBusinessPartnerEditorVisible(false);
                    },
                    // Delete a BusinessPartner
                    onDeleteBusinessPartner = function (businessPartner) {
                        if (!businessPartner.id()) {
                            businessPartners.remove(businessPartner);
                            return;
                        }

                        // Ask for confirmation
                        confirmation.afterProceed(function() {
                            deleteBusinessPartner(businessPartner);
                        });
                        confirmation.show();
                    },
                    // Create Business Partner
                    createBusinessPartner = function () {
                        var businessPartner = new model.BusinessPartnerDetail.Create();

                        //businessPartner.assignCategories(categories());
                        //businessPartners.splice(0, 0, businessPartner);
                        // Select the newly added businessPartner
                        selectedBusinessPartner(businessPartner);
                    },
                    // Create BusinessPartner - In Form
                    createBusinessPartnerInForm = function () {
                        createBusinessPartner();
                        showBusinessPartnerEditor();
                    },
                    // Save BusinessPartner
                    onSaveBusinessPartner = function (businessPartner) {
                        if (doBeforeSelect()) {
                            // Commits and Selects the Row
                            saveBusinessPartner(businessPartner);
                        }
                    },
                    // Do Before Logic
                    doBeforeSelect = function() {
                        var flag = true;
                        if (!selectedBusinessPartner().isValid()) {
                            selectedBusinessPartner().errors.showAllMessages();
                            flag = false;
                        }
                        return flag;
                    },
                    // Initialize the view model
                    initialize = function(specifiedView) {
                        view = specifiedView;

                        ko.applyBindings(view.viewModel, view.bindingRoot);

                        getBase();

                        // Set Pager
                        pager(pagination.Pagination({}, businessPartners, getBusinessPartners));

                        getBusinessPartners();
                    },
                    // Template Chooser
                    templateToUse = function (businessPartner) {
                        return (businessPartner === selectedBusinessPartner() ? 'editBusinessPartnerTemplate' : 'itemBusinessPartnerTemplate');
                    },
                    // Map BusinessPartners - Server to Client
                    mapBusinessPartners = function (data) {
                        var businessPartnerList = [];
                        _.each(data.BusinessPartners, function (item) {
                            var businessPartner = new model.BusinessPartner(item);
                            //product.assignCategories(categories());
                            businessPartnerList.push(businessPartner);
                        });
                        
                        ko.utils.arrayPushAll(businessPartners(), businessPartnerList);
                        businessPartners.valueHasMutated();
                    },
                    // Get Base
                    getBase = function () {
                        dataservice.getBusinessPartnerBase({
                            success: function (data) {
                                //Company array
                                companies.removeAll();
                                ko.utils.arrayPushAll(companies(), data.ResponseCompanies);
                                companies.valueHasMutated();
                                
                                // Payment Terms array
                                paymentTerms.removeAll();
                                ko.utils.arrayPushAll(paymentTerms(), data.ResponsePaymentTerms);
                                paymentTerms.valueHasMutated();
                                
                                // Business Partner Rating Types array
                                bpRatingTypes.removeAll();
                                ko.utils.arrayPushAll(bpRatingTypes(), data.ResponseBPRatingTypes);
                                bpRatingTypes.valueHasMutated();

                                // Business Legal Statuses array
                                businessLegalStatuses.removeAll();
                                ko.utils.arrayPushAll(businessLegalStatuses(), data.ResponseBusinessLegalStatuses);
                                businessLegalStatuses.valueHasMutated();
                                
                                // Business Legal Statuses array
                                respBusinessPartners.removeAll();
                                ko.utils.arrayPushAll(respBusinessPartners(), data.ResponseBusinessPartners);
                                respBusinessPartners.valueHasMutated();

                                // Business Legal Statuses array
                                dealingEmployees.removeAll();
                                ko.utils.arrayPushAll(dealingEmployees(), data.ResponseDealingEmployees);
                                dealingEmployees.valueHasMutated();
                                
                            },
                            error: function () {
                                toastr.error("Failed to load base data");
                            }
                        });
                    },
                    // Search 
                    search = function () {
                        pager().reset();
                        getBusinessPartners();
                    },
                    // Get businessPartners
                    getBusinessPartners = function () {
                        isLoadingBusinessPartners(true);
                        dataservice.getBusinessPartners({
                            SearchString: searchFilter(),
                            SelectOption: selectFilter(),  // 1 for Individual , 2 for Company
                            PageNo: pager().currentPage(), SortBy: sortOn(), IsAsc: sortIsAsc() 
                        }, {
                            success: function(data) {
                                pager().totalCount(data.TotalCount);
                                businessPartners.removeAll();
                                mapBusinessPartners(data);
                                isLoadingBusinessPartners(false);
                            },
                            error: function() {
                                isLoadingBusinessPartners(false);
                                toastr.error("Failed to load businessPartners!");
                            }
                        });
                    },
                    // Delete BusinessPartner
                    deleteBusinessPartner = function (businessPartner) {
                        dataservice.deleteBusinessPartner(businessPartner.convertToServerData(), {
                            success: function () {
                                businessPartners.remove(businessPartner);
                                toastr.success("Business Partner removed successfully");
                            },
                            error: function () {
                                toastr.error("Failed to remove Business Partner!");
                            }
                        });
                    },
                    // Save Business Partner
                    saveBusinessPartner = function (businessPartner) {
                        var method = "updateBusinessPartner";
                        if (!selectedBusinessPartner().businessPartnerId()) {
                            method = "createBusinessPartner";
                        }
                        dataservice[method](model.BusinessPartnerServerMapper(selectedBusinessPartner()), {
                            success: function () {
                                // Reset Changes
                                selectedBusinessPartner().reset();
                                // If BusinessPartner is specified then select it
                                if (businessPartner) {
                                    selectBusinessPartner(businessPartner);
                                }
                                if (isBusinessPartnerEditorVisible) {
                                    closeBusinessPartnerEditor();
                                }
                                getBusinessPartners();
                                toastr.success("Business Partner saved successfully");
                            },
                            error: function () {
                                toastr.error('Failed to save business Partner!');
                            }
                        });
                    };
                // #endregion Service Calls

                return {
                    // Observables
                    selectedBusinessPartner: selectedBusinessPartner,
                    isLoadingBusinessPartners: isLoadingBusinessPartners,
                    //categories: categories,
                    businessPartners: businessPartners,
                    //totalPrice: totalPrice,
                    searchFilter: searchFilter,
                    selectFilter: selectFilter,
                    sortOn: sortOn,
                    sortIsAsc: sortIsAsc,
                    // Observables
                    companies: companies,
                    paymentTerms: paymentTerms,
                    bpRatingTypes: bpRatingTypes,
                    businessLegalStatuses: businessLegalStatuses,
                    respBusinessPartners: respBusinessPartners,
                    dealingEmployees:dealingEmployees,
                    // Utility Methods
                    onSaveBusinessPartner: onSaveBusinessPartner,
                    createBusinessPartner: createBusinessPartner,
                    onDeleteBusinessPartner: onDeleteBusinessPartner,
                    initialize: initialize,
                    templateToUse: templateToUse,
                    selectBusinessPartner: selectBusinessPartner,
                    search: search,
                    getBusinessPartners: getBusinessPartners,
                    pager: pager,
                    //onEditBusinessPartnerInline: onEditBusinessPartnerInline,
                    onEditBusinessPartner: onEditBusinessPartner,
                    showBusinessPartnerEditor: showBusinessPartnerEditor,
                    onCloseBusinessPartnerEditor: onCloseBusinessPartnerEditor,
                    isBusinessPartnerEditorVisible: isBusinessPartnerEditorVisible,
                    createBusinessPartnerInForm: createBusinessPartnerInForm,
                    optionIndividualOrCompany: optionIndividualOrCompany,
                    listSelectedBusinessPartner: listSelectedBusinessPartner
                    // Utility Methods
                };
            })()
        };
        return ist.businessPartner.viewModel;
    });
