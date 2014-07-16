/*
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
                    // est price total
                    //totalPrice = ko.computed(function () {
                    //    if (products().length === 0) {
                    //        return 0;
                    //    }
                    //    var total = 0;
                    //    _.each(products(), function (product) {
                    //        total += product.price();S
                    //    });
                    //    return total;
                    //}),
                    // #region Utility Functions
                    // Select filter option Individual or Company
                    optionIndividualOrCompany = [{ Id: true, Name: 'Individual' },{Id : false, Name :  'Company'}],
                    selectBusinessPartner = function (businessPartner) {
                        if (selectedBusinessPartner() && selectedBusinessPartner().hasChanges()) {
                            onSaveBusinessPartner(businessPartner);
                            return;
                        }
                        if (selectedBusinessPartner() !== businessPartner) {
                            selectedBusinessPartner(businessPartner);
                        }
                        isEditable(false);
                    },
                    //// Edit a BusinessPartner
                    //onEditProductInline = function(product, e) {
                    //    selectProduct(product);
                    //    isEditable(true);
                    //    e.stopImmediatePropagation();
                    //},
                    // Edit a Business Partner - In a Form
                    onEditBusinessPartner = function (businessPartner, e) {
                        selectBusinessPartner(businessPartner);
                        showBusinessPartnerEditor();
                        e.stopImmediatePropagation();
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
                        var businessPartner = new model.BusinessPartner({ BusinessPartnerName: "", BusinessPartnerId: 0, Description: "" });
                        //businessPartner.assignCategories(categories());
                        businessPartners.splice(0, 0, businessPartner);
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
                        if (!selectedBusinessPartner().id()) {
                            method = "createBusinessPartner";
                        }
                        // Ignore additional properties
                        var mapping = {
                            'ignore': ["categories", "categoryName", "assignCategories", "dirtyFlag", "hasChanges", "errors", "isValid",
                                "reset"]
                        }; 
                        dataservice[method](ko.mapping.toJS(selectedBusinessPartner(), mapping), {
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
                    businessLegalStatuses:businessLegalStatuses,
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
                    optionIndividualOrCompany: optionIndividualOrCompany
                    // Utility Methods
                };
            })()
        };
        return ist.businessPartner.viewModel;
    });
