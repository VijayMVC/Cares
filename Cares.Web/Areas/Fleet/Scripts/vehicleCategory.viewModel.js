/*
    Module with the view model for the Vehicle Category
*/
define("vehicleCategory/vehicleCategory.viewModel",
    ["jquery", "amplify", "ko", "vehicleCategory/vehicleCategory.dataservice", "vehicleCategory/vehicleCategory.model",
    "common/confirmation.viewModel", "common/pagination"],
    function($, amplify, ko, dataservice, model, confirmation, pagination) {
        var ist = window.ist || {};
        ist.VehicleCategory = {
            viewModel: (function() { 
                var view,
                    //array to save Vehicle Categories
                    vehicleCategories = ko.observableArray([]),
                    //pager%
                    pager = ko.observable(),
                    //org code filter in filter sec
                    searchFilter = ko.observable(),
                    //sorting
                    sortOn = ko.observable(1),
                    //Assending  / Desending
                    sortIsAsc = ko.observable(true),
                    //to control the visibility of editor sec
                    isVehicleCategoryEditorVisible = ko.observable(false),
                    //to control the visibility of filter ec
                    filterSectionVisilble = ko.observable(false),
                     // Editor View Model
                    editorViewModel = new ist.ViewModel(model.VehicleCategoryDetail),
                    // Selected Vehicle Category
                    selectedVehicleCategory = editorViewModel.itemForEditing,
                    //save button handler
                    onSavebtn = function() {
                    if (dobeforeVehicleCategory())
                        saveVehicleCategory(selectedVehicleCategory());
                },
                //Save Vehicle Categories
                    saveVehicleCategory = function (item) {
                        dataservice.saveVehicleCategory(item.convertToServerData(), {
                        success: function(dataFromServer) {
                            var newItem = model.vehicleCategoryServertoClinetMapper(dataFromServer);
                            if (item.id() !== undefined) {
                                var newObjtodelete = vehicleCategories.find(function(temp) {
                                    return temp.id() == newItem.id();
                                });
                                vehicleCategories.remove(newObjtodelete);
                                vehicleCategories.push(newItem);
                            } else
                                vehicleCategories.push(newItem);
                            isVehicleCategoryEditorVisible(false);
                            toastr.success(ist.resourceText.VehicleCategorySuccessfullySavedMessage);
                        },
                        error: function(exceptionMessage, exceptionType) {
                            if (exceptionType === ist.exceptionType.CaresGeneralException)
                                toastr.error(exceptionMessage);
                            else
                                toastr.error(ist.resourceText.FailedToSaveCategoryError);
                        }
                    });
                },
                //validation check 
                    dobeforeVehicleCategory = function () {
                    if (!selectedVehicleCategory().isValid()) {
                        selectedVehicleCategory().errors.showAllMessages();
                        return false;
                    }
                    return true;
                },
                //cancel button handler
                    onCancelbtn = function() {
                    editorViewModel.revertItem();
                    isVehicleCategoryEditorVisible(false);
                },
                // create new Vehicle Category
                    onCreateForm = function() {
                    var vehicleCategoryDetail = new model.VehicleCategoryDetail();
                    editorViewModel.selectItem(vehicleCategoryDetail);
                    isVehicleCategoryEditorVisible(true);
                },
                //reset butto handle 
                    resetResuults = function() {
                    searchFilter(undefined);
                    getVehicleCategories();
                },
                //delete button handler
                    onDeleteItem = function(item) {
                    if (!item.id()) {
                        vehicleCategories.remove(item);
                        return;
                    }
                    // Ask for confirmation
                    confirmation.afterProceed(function() {
                        deleteVehicleCategory(item);
                    });
                    confirmation.show();
                },
                //edit button handler
                    onEditItem = function(item) {
                    editorViewModel.selectItem(item);
                    isVehicleCategoryEditorVisible(true);
                },
                //Delete Vehicle Category
                    deleteVehicleCategory = function (maintenanceType) {
                       dataservice.deleteVehicleCategory(maintenanceType.convertToServerData(), {
                        success: function() {
                            vehicleCategories.remove(maintenanceType);
                            toastr.success(ist.resourceText.VehicleCategorySuccessfullyDeletedMessage);
                        },
                        error: function(exceptionMessage, exceptionType) {
                            if (exceptionType === ist.exceptionType.CaresGeneralException)
                                toastr.error(exceptionMessage);
                            else
                                toastr.error(ist.resourceText.FailedToDeleteVehicleCategoryError);
                        }
                    });
                },
                //search button handler in filter section
                    search = function() {
                    pager().reset();
                    getVehicleCategories();
                },
                //hide filte section
                    hideFilterSection = function() {
                    filterSectionVisilble(false);
                },
                //Show filter section
                    showFilterSection = function() {
                        filterSectionVisilble(true);
                    },
                    //Get Vehicle Category list from Dataservice
                    getVehicleCategories = function() {
                        dataservice.getVehicleCategories(
                        {
                            VehicleCategoryFilterText: searchFilter(),
                            PageSize: pager().pageSize(),
                            PageNo: pager().currentPage(),
                            SortBy: sortOn(),
                            IsAsc: sortIsAsc()
                    },
                    {
                        success: function (data) {
                            vehicleCategories.removeAll();
                            pager().totalCount(data.TotalCount);
                            _.each(data.VehicleCategories, function (item) {
                                vehicleCategories.push(model.vehicleCategoryServertoClinetMapper(item));
                            });
                        },
                        error: function() {
                            isLoadingFleetPools(false);
                            toastr.error(ist.resourceText.FailedToLoadVehicleCategoriesError);
                        }
                    });
                    },
                // Initialize the view model
                    initialize = function(specifiedView) {
                        view = specifiedView;
                        ko.applyBindings(view.viewModel, view.bindingRoot);
                        pager(pagination.Pagination({ PageSize: 5 }, vehicleCategories, getVehicleCategories));
                        getVehicleCategories();
                    };
                return {
                    vehicleCategories: vehicleCategories,
                    initialize: initialize,
                    search: search,
                    searchFilter: searchFilter,
                    sortOn: sortOn,
                    sortIsAsc: sortIsAsc,
                    onCreateForm: onCreateForm,
                    filterSectionVisilble: filterSectionVisilble,
                    isVehicleCategoryEditorVisible: isVehicleCategoryEditorVisible,
                    hideFilterSection: hideFilterSection,
                    showFilterSection: showFilterSection,
                    pager: pager,
                    resetResuults: resetResuults,
                    onDeleteItem: onDeleteItem,
                    onEditItem: onEditItem,
                    onCancelbtn: onCancelbtn,
                    selectedVehicleCategory: selectedVehicleCategory,
                    onSavebtn: onSavebtn,
                    getVehicleCategories: getVehicleCategories
                };
            })()
        };
        return ist.VehicleCategory.viewModel;
    });
