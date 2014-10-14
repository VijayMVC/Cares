/*
    Module with the view model for the Maintenance Type Group
*/
define("maintenanceTypeGroup/maintenanceTypeGroup.viewModel",
    ["jquery", "amplify", "ko", "maintenanceTypeGroup/maintenanceTypeGroup.dataservice", "maintenanceTypeGroup/maintenanceTypeGroup.model",
    "common/confirmation.viewModel", "common/pagination"],
    function($, amplify, ko, dataservice, model, confirmation, pagination) {
        var ist = window.ist || {};
        ist.MaintenanceTypeGroup = {
            viewModel: (function() { 
                var view,
                    //array to save Maintenance Type Groups
                    maintenanceTypeGroups = ko.observableArray([]),
                    //pager%
                    pager = ko.observable(),
                    //org code filter in filter sec
                    searchFilter = ko.observable(),
                    //sorting
                    sortOn = ko.observable(1),
                    //Assending  / Desending
                    sortIsAsc = ko.observable(true),
                    //to control the visibility of editor sec
                    isMaintenanceTypeGroupEditorVisible = ko.observable(false),
                    //to control the visibility of filter ec
                    filterSectionVisilble = ko.observable(false),
                     // Editor View Model
                    editorViewModel = new ist.ViewModel(model.MaintenanceTypeGroupGroupDetail),
                    // Selected Maintenance Type Group
                    selectedMaintenanceTypeGroup = editorViewModel.itemForEditing,
                    //save button handler
                    onSavebtn = function() {
                        if (dobeforeMaintenanceTypeGroup())
                            saveMaintenanceTypeGroup(selectedMaintenanceTypeGroup());
                },
                //Save Maintenance Type Group
                    saveMaintenanceTypeGroup = function (item) {
                        dataservice.saveMainteneceTypeGroup(item.convertToServerData(), {
                        success: function(dataFromServer) {
                            var newItem = model.maintenanceTypeGroupServertoClinetMapper(dataFromServer);
                            if (item.id() !== undefined) {
                                var newObjtodelete = maintenanceTypeGroups.find(function(temp) {
                                    return temp.id() == newItem.id();
                                });
                                maintenanceTypeGroups.remove(newObjtodelete);
                                maintenanceTypeGroups.push(newItem);
                            } else
                                maintenanceTypeGroups.push(newItem);
                            isMaintenanceTypeGroupEditorVisible(false);
                            toastr.success(ist.resourceText.MaintenanceTypeGroupSuccessfullySavedMessage);
                        },
                        error: function(exceptionMessage, exceptionType) {
                            if (exceptionType === ist.exceptionType.CaresGeneralException)
                                toastr.error(exceptionMessage);
                            else
                                toastr.error(ist.resourceText.FailedToSaveMaintenanceTypeGroupError);
                        }
                    });
                },
                //validation check 
                    dobeforeMaintenanceTypeGroup = function () {
                    if (!selectedMaintenanceTypeGroup().isValid()) {
                        selectedMaintenanceTypeGroup().errors.showAllMessages();
                        return false;
                    }
                    return true;
                },
                //cancel button handler
                    onCancelbtn = function() {
                    editorViewModel.revertItem();
                    isMaintenanceTypeGroupEditorVisible(false);
                },
                // create new Maintenance Type Group
                    onCreateForm = function () {
                    var maintenanceTypeGroupGroupDetail = new model.MaintenanceTypeGroupGroupDetail();
                    editorViewModel.selectItem(maintenanceTypeGroupGroupDetail);
                    isMaintenanceTypeGroupEditorVisible(true);
                },
                //reset butto handle 
                    resetResuults = function() {
                    searchFilter(undefined);
                    getMaintenanceTypeGroups();
                },
                //delete button handler
                    onDeleteItem = function(item) {
                    if (!item.id()) {
                        maintenanceTypeGroups.remove(item);
                        return;
                    }
                    // Ask for confirmation
                    confirmation.afterProceed(function() {
                        deleteMaintenanceTypeGroup(item);
                    });
                    confirmation.show();
                },
                //edit button handler
                    onEditItem = function(item) {
                    editorViewModel.selectItem(item);
                    isMaintenanceTypeGroupEditorVisible(true);
                },
                //delete Maintenance Type Group
                    deleteMaintenanceTypeGroup = function (mainteneceTypeGroup) {
                        dataservice.deleteMainteneceTypeGroup(mainteneceTypeGroup.convertToServerData(), {
                        success: function() {
                            maintenanceTypeGroups.remove(mainteneceTypeGroup);
                            toastr.success(ist.resourceText.MaintenanceTypeGroupSuccessfullyDeletedMessage);
                        },
                        error: function(exceptionMessage, exceptionType) {
                            if (exceptionType === ist.exceptionType.CaresGeneralException)
                                toastr.error(exceptionMessage);
                            else
                                toastr.error(ist.resourceText.MaintenanceTypeGroupSuccessfullyDeletedMessage);
                        }
                    });
                },
                //search button handler in filter section
                    search = function() {
                    pager().reset();
                    getMaintenanceTypeGroups();
                },
                //hide filte section
                    hideFilterSection = function() {
                    filterSectionVisilble(false);
                },
                //Show filter section
                    showFilterSection = function() {
                        filterSectionVisilble(true);
                    },
                    //get Maintenance Type Group list from Dataservice
                    getMaintenanceTypeGroups = function () {
                        dataservice.getMainteneceTypeGroups(
                        {
                            MainteneceTypeGroupFilterText: searchFilter(),
                            PageSize: pager().pageSize(),
                            PageNo: pager().currentPage(),
                            SortBy: sortOn(),
                            IsAsc: sortIsAsc()
                    },
                    {
                        success: function (data) {
                            maintenanceTypeGroups.removeAll();
                            pager().totalCount(data.TotalCount);
                            _.each(data.MaintenanceTypeGroups, function (item) {
                                maintenanceTypeGroups.push(model.maintenanceTypeGroupServertoClinetMapper(item));
                            });
                        },
                        error: function() {
                            isLoadingFleetPools(false);
                            toastr.error(ist.resourceText.FailedToLoadMaintenanceTypeGroupsError);
                        }
                    });
                    },
                    
                // Initialize the view model
                    initialize = function(specifiedView) {
                        view = specifiedView;
                        ko.applyBindings(view.viewModel, view.bindingRoot);
                        pager(pagination.Pagination({ PageSize: 10 }, maintenanceTypeGroups, getMaintenanceTypeGroups));
                        getMaintenanceTypeGroups();
                    };
                return {
                    maintenanceTypeGroups: maintenanceTypeGroups,
                    initialize: initialize,
                    search: search,
                    searchFilter: searchFilter,
                    sortOn: sortOn,
                    sortIsAsc: sortIsAsc,
                    onCreateForm: onCreateForm,
                    filterSectionVisilble: filterSectionVisilble,
                    isMaintenanceTypeGroupEditorVisible: isMaintenanceTypeGroupEditorVisible,
                    hideFilterSection: hideFilterSection,
                    showFilterSection: showFilterSection,
                    pager: pager,
                    resetResuults: resetResuults,
                    onDeleteItem: onDeleteItem,
                    onEditItem: onEditItem,
                    onCancelbtn: onCancelbtn,
                    selectedMaintenanceTypeGroup: selectedMaintenanceTypeGroup,
                    onSavebtn: onSavebtn,
                    getMaintenanceTypeGroups: getMaintenanceTypeGroups,
                };
            })()
        };
        return ist.MaintenanceTypeGroup.viewModel;
    });
