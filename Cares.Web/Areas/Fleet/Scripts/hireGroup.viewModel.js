/*
    Module with the view model for the Tarrif Rate
*/
define("hireGroup/hireGroup.viewModel",
    ["jquery", "amplify", "ko", "hireGroup/hireGroup.dataservice", "hireGroup/hireGroup.model", "common/confirmation.viewModel", "common/pagination"],
    function ($, amplify, ko, dataservice, model, confirmation, pagination) {
        var ist = window.ist || {};
        ist.hireGroup = {
            viewModel: (function () {
                var // the view 
                    view,
                     // Active Hire Group
                    selectedHireGroup = ko.observable(),
                    //Active Hire Group Copy 
                   selectedHireGroupCopy = ko.observable(),
                   // Show Filter Section
                    filterSectionVisilble = ko.observable(false),
                    // #region Arrays
                    // Companies
                    companies = ko.observableArray([]),
                    //Hire Groups
                    hireGroups = ko.observableArray([]),
                    // Parent Hire Groups
                    parentHireGroups = ko.observableArray([]),
                    // #endregion Arrays
                    // #region Busy Indicators
                    isLoadingHireGroups = ko.observable(false),
                    // #endregion Busy Indicators
                    // #region Observables
                    // Sort On
                    sortOn = ko.observable(1),
                    // Sort Order -  true means asc, false means desc
                    sortIsAsc = ko.observable(true),
                    // Sort On Hiregroup
                    sortOnHg = ko.observable(1),
                    // Sort Order -  true means asc, false means desc
                    sortIsAscHg = ko.observable(true),
                    // Is Tariff Rate Editor Visible
                    isHireGroupEditorVisible = ko.observable(false),
                    // Pagination
                    pager = ko.observable(),
                     //Hire Group Code filter
                    hireGroupCodeFilter = ko.observable(),
                    //Hire Group Name  Filter
                    hireGroupNameFilter = ko.observable(),
                    // Company Filter
                    companyFilter = ko.observable(),
                    //Parent Hire Group Filter
                    parentHireGroupFilter = ko.observable(),

                     // #region Utility Functions
                    // Initialize the view model
                    initialize = function (specifiedView) {
                        view = specifiedView;
                        ko.applyBindings(view.viewModel, view.bindingRoot);
                        getBaseData();
                        // Set Pager
                        pager(new pagination.Pagination({}, hireGroups, getHireGroup));
                        getHireGroup();

                    },
                     // Collapase filter section
                    collapseFilterSection = function () {
                        filterSectionVisilble(false);
                    },
                    //Show filter section
                    showFilterSection = function () {
                        filterSectionVisilble(true);
                    },
                     //Get Base Data
                    getBaseData = function (callBack) {
                        dataservice.getHireGroupBase({
                            success: function (data) {
                                //Company array
                                companies.removeAll();
                                ko.utils.arrayPushAll(companies(), data.Companies);
                                companies.valueHasMutated();

                                parentHireGroups.removeAll();
                                ko.utils.arrayPushAll(parentHireGroups(), data.Companies);
                                parentHireGroups.valueHasMutated();
                                if (callBack && typeof callBack === 'function') {
                                    callBack();
                                }
                            },
                            error: function () {
                                toastr.error("Failed to load base data");
                            }
                        });
                    },
                    // Search 
                    search = function () {
                        pager().reset();
                        getHireGroup();
                    },
                   mapHireGroups = function (data) {
                       var hireGroupList = [];
                       _.each(data.HireGroups, function (item) {
                           var hireGroup = new model.HireGroupClientMapper(item);
                           hireGroupList.push(hireGroup);
                       });
                       ko.utils.arrayPushAll(hireGroups(), hireGroupList);
                       hireGroups.valueHasMutated();
                   },
                    // Get Hire Group
                    getHireGroup = function () {
                        isLoadingHireGroups(true);
                        dataservice.getHireGroup({
                            HireGroupCode: hireGroupCodeFilter(),
                            HireGroupName: hireGroupNameFilter,
                            CompanyId: companyFilter(),
                            ParentHireGroupId: parentHireGroupFilter(),
                            PageSize: pager().pageSize(),
                            PageNo: pager().currentPage(),
                            SortBy: sortOn(),
                            IsAsc: sortIsAsc()
                        }, {
                            success: function (data) {
                                pager().totalCount(data.TotalCount);
                                hireGroups.removeAll();
                                mapHireGroups(data);
                                isLoadingHireGroups(false);
                            },
                            error: function () {
                                isLoadingHireGroups(false);
                                toastr.error("Failed to load Hire Groups!");
                            }
                        });
                    };
                // #endregion Service Calls

                return {
                    // Observables
                    selectedHireGroup: selectedHireGroup,
                    selectedHireGroupCopy: selectedHireGroupCopy,
                    isLoadingHireGroups: isLoadingHireGroups,
                    sortOn: sortOn,
                    sortIsAsc: sortIsAsc,
                    sortOnHg: sortOnHg,
                    sortIsAscHg: sortIsAscHg,
                    isHireGroupEditorVisible: isHireGroupEditorVisible,
                    filterSectionVisilble: filterSectionVisilble,
                    //Arrays
                    companies: companies,
                    parentHireGroups: parentHireGroups,
                    hireGroups: hireGroups,
                    //Filters
                    hireGroupCodeFilter: hireGroupCodeFilter,
                    hireGroupNameFilter: hireGroupNameFilter,
                    companyFilter: companyFilter,
                    parentHireGroupFilter: parentHireGroupFilter,
                    // Utility Methods
                    initialize: initialize,
                    search: search,
                    getHireGroup: getHireGroup,
                    mapHireGroups: mapHireGroups,
                    getBaseData: getBaseData,
                    pager: pager,
                    //closeTariffRateEditor: closeTariffRateEditor,
                    //showTariffRateEditor: showTariffRateEditor,
                    //selectHireGroup: selectHireGroup,
                    collapseFilterSection: collapseFilterSection,
                    showFilterSection: showFilterSection,
                    // Utility Methods

                };
            })()
        };
        return ist.hireGroup.viewModel;
    });
