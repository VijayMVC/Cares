﻿/*
    Module with the view model for the OrgGroup
*/
define("Organization/organizationGroup.viewModel",
    ["jquery", "amplify", "ko", "Organization/organizationGroup.dataservice", "Organization/organizationGroup.model",
    "common/confirmation.viewModel", "common/pagination"],
    function($, amplify, ko, dataservice, model, confirmation, pagination) {
        var ist = window.ist || {};
        ist.OrganizationGroup = {
            viewModel: (function() { 
                var view,
                     editorViewModel = new ist.ViewModel(model.organizationGroupDetail),
                    //array to save org groups
                    organizationGroups = ko.observableArray([]),
                    //pager%
                    pager = ko.observable(),
                    //org code filter in filter sec
                    orgGroupCodeFilter = ko.observable(),
                    //org name filter in filter sec
                    orgGroupNameFilter = ko.observable(),
                    //sorting
                    sortOn = ko.observable(1),
                    //Assending  / Desending
                    sortIsAsc = ko.observable(true),
                    //to control the visibility of editor sec
                    isOrgGroupEditorVisible = ko.observable(false),
                    //to control the visibility of filter ec
                    filterSectionVisilble = ko.observable(false),
                    //selected org group 
                    selectedOrgGroup = editorViewModel.itemForEditing,
                    //save button handler
                    onSaveOrgGroupbtn = function () {
                        if (dobeforeOrgGrop())
                        saveOrgGroup(selectedOrgGroup());
                    },
                    //save org group 
                    saveOrgGroup = function(item) {
                        dataservice.addOrganizationGroup(model.organizationGroupClienttoServerMapper(item), {
                            success: function(dataFromServer) {
                                var newItem = model.organizationGroupServertoClinetMapper(dataFromServer);
                                if (selectedOrgGroup().id() !== undefined)
                                    organizationGroups.replace(selectedOrgGroup(), newItem);
                                else
                                    organizationGroups.push(newItem);
                                isOrgGroupEditorVisible(false);
                                toastr.success("Operation successfuly performed!");
                            },
                            error: function (exceptionMessage, exceptionType) {
                                if (exceptionType === ist.exceptionType.CaresGeneralException)
                                    toastr.error(exceptionMessage);
                                else
                                    toastr.error("Failed to save Organization Group!");
                            }
                        });
                    }, 
                    //validation check 
                    dobeforeOrgGrop = function() {
                        if (!selectedOrgGroup().isValid()) {
                            selectedOrgGroup().errors.showAllMessages();
                            return false;
                        }
                        return true;
                    },
                    //cancel button handler
                    onCancelOrgGroupbtn = function() {
                        isOrgGroupEditorVisible(false);
                    },
                    // create new org group handler
                    onCreateOrgGroupForm = function() {
                        isOrgGroupEditorVisible(true);
                        var v = model.organizationGroupDetail();
                        selectedOrgGroup(v);
                    },
                    //reset butto handle 
                    resetResuults = function() {
                        orgGroupCodeFilter(undefined);
                        orgGroupNameFilter(undefined);
                        getOrganizationGroups();
                        pager.reset();
                    },
                    //delete button handler
                    onDeleteOrgGroup = function(item) {
                        if (!item.id()) {
                            organizationGroups.remove(item);
                            return;
                        }
                    // Ask for confirmation
                        confirmation.afterProceed(function() {
                            deleteOrgGroup(item);
                        });
                        confirmation.show();
                    },
                    //edit button handler
                    onEditFleetPool = function(item) {
                        selectedOrgGroup(item);
                        isOrgGroupEditorVisible(true);
                    },
                    //delete org group
                    deleteOrgGroup = function(orgGroup) {
                        dataservice.deleteOrganizationGroup(model.organizationGroupClienttoServerMapper(orgGroup), {
                            success: function() {
                                organizationGroups.remove(orgGroup);
                                toastr.success("Organizaiton Group removed successfully.");
                            },
                            error: function() {
                                toastr.error("Failed to remove Organization Group.");
                            }
                        });
                    },
                    //search button handler in filter section
                    search = function() {
                        pager().reset();
                        getOrganizationGroups();
                    },
                    //hide filte section
                    hideFilterSection = function() {
                        filterSectionVisilble(false);
                    },
                    //Show filter section
                    showFilterSection = function() {
                        filterSectionVisilble(true);
                    },
                    //get org group list from Dataservice
                    getOrganizationGroups = function() {
                        dataservice.getOrganizationGroups(
                        {
                            OrgGroupCode: orgGroupCodeFilter(),
                            OrgGroupName: orgGroupNameFilter(),
                            PageSize: pager().pageSize(),
                            PageNo: pager().currentPage(),
                            SortBy: sortOn(),
                            IsAsc: sortIsAsc()
                        },
                        {
                            success: function(data) {
                                organizationGroups.removeAll();
                                pager().totalCount(data.TotalCount);
                                _.each(data.OrgGroups, function(item) {
                                    organizationGroups.push(model.organizationGroupServertoClinetMapper(item));
                                });
                            },
                            error: function() {
                                isLoadingFleetPools(false);
                                toastr.error("Failed to load fleetPools!");
                            }
                        });
                    },
                    // Initialize the view model
                    initialize = function(specifiedView) {
                        view = specifiedView;
                        ko.applyBindings(view.viewModel, view.bindingRoot);
                        pager(pagination.Pagination({ PageSize: 10}, organizationGroups, getOrganizationGroups));
                        getOrganizationGroups();
                    };
                return {
                    organizationGroups: organizationGroups,
                    initialize: initialize,
                    search: search,
                    orgGroupCodeFilter: orgGroupCodeFilter,
                    orgGroupNameFilter: orgGroupNameFilter,
                    sortOn: sortOn,
                    sortIsAsc: sortIsAsc,
                    onCreateOrgGroupForm: onCreateOrgGroupForm,
                    filterSectionVisilble: filterSectionVisilble,
                    isOrgGroupEditorVisible: isOrgGroupEditorVisible,
                    hideFilterSection: hideFilterSection,
                    showFilterSection: showFilterSection,
                    pager: pager,
                    resetResuults: resetResuults,
                    onDeleteOrgGroup: onDeleteOrgGroup,
                    onEditFleetPool: onEditFleetPool,
                    onCancelOrgGroupbtn: onCancelOrgGroupbtn,
                    selectedOrgGroup: selectedOrgGroup,
                    onSaveOrgGroupbtn: onSaveOrgGroupbtn,
                    getOrganizationGroups: getOrganizationGroups
                };
            })()
        };
        return ist.OrganizationGroup.viewModel;
    });
