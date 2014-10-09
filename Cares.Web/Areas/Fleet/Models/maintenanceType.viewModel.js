/*
    Module with the view model for the Maintenance Type
*/
define("maintenanceType/maintenanceType.viewModel",
    ["jquery", "amplify", "ko", "maintenanceType/maintenanceType.dataservice", "maintenanceType/maintenanceType.model",
    "common/confirmation.viewModel", "common/pagination"],
    function($, amplify, ko, dataservice, model, confirmation, pagination) {
        var ist = window.ist || {};
        ist.MaintenanceType = {
            viewModel: (function() { 
                var view,
                    //array to save Maintenance Types
                    maintenanceTypes = ko.observableArray([]),
                    //array to save basa data Maintenance Type group list
                    baseMaintenanceTypeGroupsList = ko.observableArray([]),
                    //pager%
                    pager = ko.observable(),
                    //org code filter in filter sec
                    searchFilter = ko.observable(),
                    baseMaintenanceTypeGroupFilter = ko.observable(),
                    //sorting
                    sortOn = ko.observable(1),
                    //Assending  / Desending
                    sortIsAsc = ko.observable(true),
                    //to control the visibility of editor sec
                    isMaintenanceTypeEditorVisible = ko.observable(false),
                    //to control the visibility of filter ec
                    filterSectionVisilble = ko.observable(false),
                     // Editor View Model
                    editorViewModel = new ist.ViewModel(model.MaintenanceTypeDetail),
                    // Selected Maintenance Type
                    selectedMaintenanceType = editorViewModel.itemForEditing,
                    //save button handler
                    onSavebtn = function() {
                    if (dobeforeMaintenanceType())
                        saveMaintenanceType(selectedMaintenanceType());
                },
                //Save Maintenance Types
                    saveMaintenanceType = function (item) {
                        dataservice.saveMaintenanceType(item.convertToServerData(), {
                        success: function(dataFromServer) {
                            var newItem = model.maintenanceTypeServertoClinetMapper(dataFromServer);
                            if (item.id() !== undefined) {
                                var newObjtodelete = maintenanceTypes.find(function(temp) {
                                    return temp.id() == newItem.id();
                                });
                                maintenanceTypes.remove(newObjtodelete);
                                maintenanceTypes.push(newItem);
                            } else
                                maintenanceTypes.push(newItem);
                            isMaintenanceTypeEditorVisible(false);
                            toastr.success(ist.resourceText.MaintenanceTypeSuccessfullySavedMessage);
                        },
                        error: function(exceptionMessage, exceptionType) {
                            if (exceptionType === ist.exceptionType.CaresGeneralException)
                                toastr.error(exceptionMessage);
                            else
                                toastr.error(ist.resourceText.FailedToSaveMaintenanceTypeError);
                        }
                    });
                },
                //validation check 
                    dobeforeMaintenanceType = function () {
                    if (!selectedMaintenanceType().isValid()) {
                        selectedMaintenanceType().errors.showAllMessages();
                        return false;
                    }
                    return true;
                },
                //cancel button handler
                    onCancelbtn = function() {
                    editorViewModel.revertItem();
                    isMaintenanceTypeEditorVisible(false);
                },
                // create new Maintenance Type
                    onCreateForm = function() {
                    var maintenanceType = new model.MaintenanceTypeDetail();
                    editorViewModel.selectItem(maintenanceType);
                    isMaintenanceTypeEditorVisible(true);
                },
                //reset butto handle 
                    resetResuults = function() {
                    searchFilter(undefined);
                    baseMaintenanceTypeGroupFilter(undefined);
                    getMaintenanceTypes();
                },
                //delete button handler
                    onDeleteItem = function(item) {
                    if (!item.id()) {
                        maintenanceTypes.remove(item);
                        return;
                    }
                    // Ask for confirmation
                    confirmation.afterProceed(function() {
                        deleteMaintenanceType(item);
                    });
                    confirmation.show();
                },
                //edit button handler
                    onEditItem = function(item) {
                    editorViewModel.selectItem(item);
                    isMaintenanceTypeEditorVisible(true);
                },
                //Delete Maintenance Type
                    deleteMaintenanceType = function (maintenanceType) {
                       dataservice.deleteMaintenanceType(maintenanceType.convertToServerData(), {
                        success: function() {
                            maintenanceTypes.remove(maintenanceType);
                            toastr.success(ist.resourceText.MaintenanceTypeSuccessfullyDeletedMessage);
                        },
                        error: function(exceptionMessage, exceptionType) {
                            if (exceptionType === ist.exceptionType.CaresGeneralException)
                                toastr.error(exceptionMessage);
                            else
                                toastr.error(ist.resourceText.FailedToDeleteMaintenanceTypeError);
                        }
                    });
                },
                //search button handler in filter section
                    search = function() {
                    pager().reset();
                    getMaintenanceTypes();
                },
                //hide filte section
                    hideFilterSection = function() {
                    filterSectionVisilble(false);
                },
                //Show filter section
                    showFilterSection = function() {
                        filterSectionVisilble(true);
                    },
                    //Get Maintenance Types list from Dataservice
                    getMaintenanceTypes = function() {
                        dataservice.getMaintenanceTypes(
                        {
                            MaintenanceTypeCodeNameText: searchFilter(),
                            MaintenanceTypeGroypId: baseMaintenanceTypeGroupFilter(),
                            PageSize: pager().pageSize(),
                            PageNo: pager().currentPage(),
                            SortBy: sortOn(),
                            IsAsc: sortIsAsc()
                    },
                    {
                        success: function (data) {
                            maintenanceTypes.removeAll();
                            pager().totalCount(data.TotalCount);
                            _.each(data.MaintenanceTypes, function (item) {
                                maintenanceTypes.push(model.maintenanceTypeServertoClinetMapper(item));
                            });
                        },
                        error: function() {
                            isLoadingFleetPools(false);
                            toastr.error(ist.resourceText.FailedToLoadMaintenanceTypesError);
                        }
                    });
                    },
                     //Get Maintenance Type base data
                    getBaseData = function () {
                        dataservice.getMaintenanceTypeBaseData(null, {
                            success: function (data) {
                                baseMaintenanceTypeGroupsList.removeAll();
                                ko.utils.arrayPushAll(baseMaintenanceTypeGroupsList(), data.MaintenanceTypeGroups);
                                baseMaintenanceTypeGroupsList.valueHasMutated();
                            },
                            error: function (exceptionMessage, exceptionType) {
                                if (exceptionType === ist.exceptionType.CaresGeneralException) {
                                    toastr.error(exceptionMessage);
                                } else {
                                    toastr.error(ist.resourceText.FailedToLoadMaintenanceTypeBaseDataError);
                                }
                            }
                        });
                    },
                // Initialize the view model
                    initialize = function(specifiedView) {
                        view = specifiedView;
                        ko.applyBindings(view.viewModel, view.bindingRoot);
                        pager(pagination.Pagination({ PageSize: 10 }, maintenanceTypes, getMaintenanceTypes));
                        getBaseData();
                        getMaintenanceTypes();
                    };
                return {
                    maintenanceTypes: maintenanceTypes,
                    initialize: initialize,
                    search: search,
                    searchFilter: searchFilter,
                    sortOn: sortOn,
                    sortIsAsc: sortIsAsc,
                    onCreateForm: onCreateForm,
                    filterSectionVisilble: filterSectionVisilble,
                    isMaintenanceTypeEditorVisible: isMaintenanceTypeEditorVisible,
                    hideFilterSection: hideFilterSection,
                    showFilterSection: showFilterSection,
                    pager: pager,
                    resetResuults: resetResuults,
                    onDeleteItem: onDeleteItem,
                    onEditItem: onEditItem,
                    onCancelbtn: onCancelbtn,
                    selectedMaintenanceType: selectedMaintenanceType,
                    onSavebtn: onSavebtn,
                    getMaintenanceTypes: getMaintenanceTypes,
                    getBaseData: getBaseData,
                    baseMaintenanceTypeGroupsList: baseMaintenanceTypeGroupsList,
                    baseMaintenanceTypeGroupFilter: baseMaintenanceTypeGroupFilter
                };
            })()
        };
        return ist.MaintenanceType.viewModel;
    });
