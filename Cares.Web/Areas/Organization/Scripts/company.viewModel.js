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
                    companyCodeTextFilter = ko.observable(undefined),
                    // Company name Filter
                    companyNameTextFilter = ko.observable(undefined),
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
                    onCreateCompany = function () {
                        filteredCompanyList.removeAll();
                        ko.utils.arrayPushAll(filteredCompanyList(), parentCompanyList());
                        filteredCompanyList.valueHasMutated();
                        var company = new model.CompanyDetail();
                        editorViewModel.selectItem(company);
                        isCompanyEditorVisible(true);
                    },
                    // reset event hander
                    onReset = function() {
                        companyCodeTextFilter(undefined);
                        companyNameTextFilter(undefined);
                        busiNessSegmentFilter(undefined);
                        orgGroupFilter(undefined);
                        getCompanies();
                    },
                    //edit event handler
                    onEditCompany = function (item) {
                        filteredCompanyList();
                        filteredCompanyList(_.filter(parentCompanyList(), function (company) {
                            return company.CompanyId !== item.companyId();
                        }));
                        editorViewModel.selectItem(item);
                        isCompanyEditorVisible(true);
                    },
                    //cancel event handler
                    onCancelCompanySave = function () {
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
                    dobeforeCompany = function () {
                        if (!selectedCompany().isValid()) {
                            selectedCompany().errors.showAllMessages();
                            return false;
                        }
                        return true;
                    },
                    //sace event handler
                    onSaveCompany = function () {
                        if (dobeforeCompany())
                        saveCompany(selectedCompany());
                    },
                    //save compnay 
                    saveCompany = function (item) {
                        dataservice.saveCompany(model.CompanyClienttoServerMapper(item), {
                            success: function (dataFromServer) {
                                var newItem = model.CompanyServertoClinetMapper(dataFromServer);
                                if (selectedCompany().companyId() !== undefined) {
                                    var newObjtodelete = companies.find(function (temp) {
                                        return temp.companyId() == newItem.companyId();
                                    });
                                    companies.remove(newObjtodelete);
                                    companies.push(newItem);
                                    // deleting existing company from basecompany
                                    var newObj = parentCompanyList.find(function (temp) {
                                        return temp.CompanyId === newItem.companyId();
                                    });
                                    parentCompanyList.remove(newObj);
                                    // updating
                                    updateBaseCompany(dataFromServer);
                                }
                                else
                                {
                                    updateBaseCompany(dataFromServer);
                                    companies.push(newItem);
                                }
                                isCompanyEditorVisible(false);
                                toastr.success("Operation successfuly performed!");
                            },
                            error: function (exceptionMessage, exceptionType) {
                                if (exceptionType === ist.exceptionType.CaresGeneralException)
                                    toastr.error(exceptionMessage);
                                else
                                    toastr.error("Failed to save Company!");
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
                                parentCompanyList.remove(obj);
                                toastr.success("Company removed successfully.");
                            },
                            error: function() {
                                toastr.error("Failed to remove Company.");
                            }
                        });
                    },
                    //get companies
                    getCompanies = function() {
                        dataservice.getCompanies(
                        {
                            CompanyCodeText: companyCodeTextFilter(),
                            CompanyNameText: companyNameTextFilter(),
                            OrganizationGroupId: orgGroupFilter(),
                            BusinessSegmentId: busiNessSegmentFilter(),
                            PageSize: pager().pageSize(),
                            PageNo: pager().currentPage(),
                            SortBy: sortOn(),
                            IsAsc: sortIsAsc()

                        },
                        {
                            success: function (data) {
                                companies.removeAll();
                                pager().totalCount(data.TotalCount);
                                _.each(data.Companies, function(item) {
                                    companies.push(model.CompanyServertoClinetMapper(item));
                                });
                            },
                            error: function() {
                                isLoadingFleetPools(false);
                                toastr.error("Failed to load fleetPools!");
                            }
                        });
                    },
                    // update company base data
                    updateBaseCompany = function (dataFromServer) {
                        var codeNamee = dataFromServer.CompanyCode + "-" + dataFromServer.CompanyName;
                        var obej = {
                            CompanyCodeName: codeNamee,
                            CompanyId: dataFromServer.CompanyId,
                            OrgGroupId: dataFromServer.OrgGroupId,
                        };
                        parentCompanyList.push(obej);
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
                                    toastr.error("Failed to load base data.");
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
                    companyCodeTextFilter: companyCodeTextFilter,
                    companyNameTextFilter: companyNameTextFilter,
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
