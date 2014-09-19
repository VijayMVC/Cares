/*
    Module with the view model for the Company
*/
define("company/company.viewModel",
    ["jquery", "amplify", "ko", "company/company.dataservice", "company/company.model",
    "common/confirmation.viewModel", "common/pagination"],
    function($, amplify, ko, dataservice, model, confirmation, pagination) {
        var ist = window.ist || {};
        ist.Company = {
            viewModel: (function() {
                var view,
                    //pager
                    pager = ko.observable(),
                    //sorting order
                    sortIsAsc = ko.observable(true),
                    //sorting
                    sortOn = ko.observable(1),
                    // company editor visibility
                    isCompanyEditorVisible = ko.observable(false),
                    // Business Segment Filter
                    busiNessSegmentFilter = ko.observable(undefined),
                    // Parent Company Filter
                    parentCompanyFilter = ko.observable(undefined),
                    // Org Group Filter
                    orgGroupFilter = ko.observable(undefined),
                    // Company Code Filter
                    companyFilter = ko.observable(undefined),
                   
                    // Filter section visibility
                    filterSectionVisilble = ko.observable(false),
                    // Parent Company List
                    parentCompanyList = ko.observableArray([]),
                    // Filtered Parent Company List for edit mode
                    filteredCompanyList = ko.observableArray([]),
                    // Org Group List
                    orgGroupList = ko.observableArray([]),
                    // Buseness Segment List
                    businessSegList = ko.observableArray([]),
                    // Compnies list
                    companies = ko.observableArray([]),
                    // Editor View Model
                    editorViewModel = new ist.ViewModel(model.CompanyDetail),
                    // Selected company
                    selectedCompany = editorViewModel.itemForEditing,
                    // EVENT HANDLERS

                    // Collapase filter section
                    collapseFilterSection = function() {
                        filterSectionVisilble(false);
                    },
                    //Show filter section
                    showFilterSection = function() {
                        filterSectionVisilble(true);
                    },
                    //search event handler
                    onSearch = function() {
                        getCompanies();
                    },
                    //create new compnay event handler
                    onCreateCompany = function() {
                        filteredCompanyList.removeAll();
                        ko.utils.arrayPushAll(filteredCompanyList(), parentCompanyList());
                        filteredCompanyList.valueHasMutated();
                        var company = new model.CompanyDetail();
                        editorViewModel.selectItem(company);
                        isCompanyEditorVisible(true);
                    },
                    // reset event hander
                    onReset = function() {
                        companyFilter(undefined);
                        busiNessSegmentFilter(undefined);
                        orgGroupFilter(undefined);
                        getCompanies();
                    },
                    //edit event handler
                    onEditCompany = function (item) {
                        filteredCompanyList(_.filter(parentCompanyList(), function(company) {
                            return company.CompanyId !== item.companyId();
                        }));
                        editorViewModel.selectItem(item);
                        isCompanyEditorVisible(true);
                    },
                    //cancel event handler
                    onCancelCompanySave = function() {
                        editorViewModel.revertItem();
                        isCompanyEditorVisible(false);
                    },
                    // delete event handler
                    onDeleteCompany = function(item) {
                        if (!item.companyId()) {
                            organizationGroups.remove(item);
                            return;
                        }
                        // Ask for confirmation
                        confirmation.afterProceed(function() {
                            deleteCompany(item);
                        });
                        confirmation.show();
                    },
                    //validation check 
                    dobeforeCompany = function() {
                        if (!selectedCompany().isValid()) {
                            selectedCompany().errors.showAllMessages();
                            return false;
                        }
                        return true;
                    },
                    //sace event handler
                    onSaveCompany = function() {
                        if (dobeforeCompany())
                            saveCompany(selectedCompany());
                    },
                    //save compnay 
                    saveCompany = function (item) {
                        dataservice.saveCompany(model.CompanyClienttoServerMapper(item), {
                            success: function (dataFromServer) {
                                if (item.companyId() === undefined)
                                    addCompanyToBaseDataCompanyList(dataFromServer);             // updating base company dropdown
                                getCompanies();
                                isCompanyEditorVisible(false);
                                toastr.success(ist.resourceText.CompanySaveSuccessMessage);
                            },
                            error: function(exceptionMessage, exceptionType) {
                                if (exceptionType === ist.exceptionType.CaresGeneralException)
                                    toastr.error(exceptionMessage);
                                else
                                    toastr.error(ist.resourceText.CompanySaveFailError);
                            }
                        });
                    },
                    // delete company
                    deleteCompany = function(company) {
                        dataservice.deleteCompany(model.CompanyClienttoServerMapper(company), {
                            success: function() {
                                companies.remove(company);
                                var obj = parentCompanyList.find(function(item) {
                                    return item.CompanyId === company.companyId();
                                });
                                debugger;
                                removeCompanyFromBaseDataCompanyList(obj);
                                toastr.success(ist.resourceText.CompanyDeleteSuccessMessage);
                            },
                            error: function (exceptionMessage, exceptionType) {
                                if (exceptionType === ist.exceptionType.CaresGeneralException)
                                    toastr.error(exceptionMessage);
                                else
                                    toastr.error(ist.resourceText.CompanyDeleteFailError);
                            }
                        });
                    },
                    //get companies
                    getCompanies = function() {
                        dataservice.getCompanies(
                        {
                            CompanyText: companyFilter(),
                            OrganizationGroupId: orgGroupFilter(),
                            BusinessSegmentId: busiNessSegmentFilter(),
                            PageSize: pager().pageSize(),
                            PageNo: pager().currentPage(),
                            SortBy: sortOn(),
                            IsAsc: sortIsAsc()
                        },
                        {
                            success: function(data) {
                                companies.removeAll();
                                pager().totalCount(data.TotalCount);
                                _.each(data.Companies, function(item) {
                                    companies.push(model.CompanyServertoClinetMapper(item));
                                });
                            },
                            error: function() {
                                isLoadingFleetPools(false);
                                toastr.error(ist.resourceText.CompanyLoadFailError);
                            }
                        });
                    },
                    // Adding company to base data
                   addCompanyToBaseDataCompanyList = function(company) {
                        var codeName = company.CompanyCode + "-" + company.CompanyName;
                        var obj = {
                            CompanyCodeName: codeName,
                            CompanyId: company.CompanyId,
                            OrgGroupId: company.OrgGroupId,
                        };
                        parentCompanyList.push(obj);
                   },
                    // Removing company from base data
                   removeCompanyFromBaseDataCompanyList = function (company) {
                       parentCompanyList.remove(company);
                   },
                    //get compnies base data
                    getCompaniesBaseData = function() {
                        dataservice.getCompaniesBasedata(null, {
                            success: function(data) {
                                parentCompanyList.removeAll();
                                orgGroupList.removeAll();
                                businessSegList.removeAll();
                                ko.utils.arrayPushAll(parentCompanyList(), data.ParrentCompanies);
                                parentCompanyList.valueHasMutated();
                                ko.utils.arrayPushAll(orgGroupList(), data.OrgGroups);
                                orgGroupList.valueHasMutated();
                                ko.utils.arrayPushAll(businessSegList(), data.BusinessSegments);
                                businessSegList.valueHasMutated();
                            },
                            error: function(exceptionMessage, exceptionType) {
                                if (exceptionType === ist.exceptionType.CaresGeneralException) {
                                    toastr.error(exceptionMessage);
                                } else {
                                    toastr.error(ist.resourceText.CompanyBaseLoadFailError);
                                }
                            }
                        });
                    },
                    // Initialize the view model
                    initialize = function(specifiedView) {
                        view = specifiedView;
                        ko.applyBindings(view.viewModel, view.bindingRoot);
                        getCompaniesBaseData();
                        pager(pagination.Pagination({ PageSize: 5 }, companies, getCompanies));
                        getCompanies();
                    };
                return {
                    companyFilter: companyFilter,
                    parentCompanyList: parentCompanyList,
                    onCancelCompanySave: onCancelCompanySave,
                    orgGroupList: orgGroupList,
                    onCreateCompany: onCreateCompany,
                    onSaveCompany: onSaveCompany,
                    getCompanies: getCompanies,
                    onDeleteCompany: onDeleteCompany,
                    businessSegList: businessSegList,
                    onReset: onReset,
                    sortOn: sortOn,
                    sortIsAsc: sortIsAsc,
                    collapseFilterSection: collapseFilterSection,
                    initialize: initialize,
                    filteredCompanyList:filteredCompanyList,
                    onSearch: onSearch,
                    isCompanyEditorVisible: isCompanyEditorVisible,
                    filterSectionVisilble: filterSectionVisilble,
                    showFilterSection: showFilterSection,
                    busiNessSegmentFilter: busiNessSegmentFilter,
                    parentCompanyFilter: parentCompanyFilter,
                    orgGroupFilter: orgGroupFilter,
                    companies: companies,
                    pager: pager,
                    onEditCompany: onEditCompany,
                    selectedCompany: selectedCompany
                };
            })()
        };
        return ist.Company.viewModel;
    });
