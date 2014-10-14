/*
    Module with the view model for the Vehicle Model
*/
define("vehicleModel/vehicleModel.viewModel",
    ["jquery", "amplify", "ko", "vehicleModel/vehicleModel.dataservice", "vehicleModel/vehicleModel.model",
    "common/confirmation.viewModel", "common/pagination"],
    function($, amplify, ko, dataservice, model, confirmation, pagination) {
        var ist = window.ist || {};
        ist.VehicleModel = {
            viewModel: (function() { 
                var view,
                    //array to save Vehicle Model
                    vehicleModels = ko.observableArray([]),
                    //pager%
                    pager = ko.observable(),
                    //org code filter in filter sec
                    searchFilter = ko.observable(),
                    //sorting
                    sortOn = ko.observable(1),
                    //Assending  / Desending
                    sortIsAsc = ko.observable(true),
                    //to control the visibility of editor sec
                    isVehicleModelEditorVisible = ko.observable(false),
                    //to control the visibility of filter ec
                    filterSectionVisilble = ko.observable(false),
                     // Editor View Model
                    editorViewModel = new ist.ViewModel(model.VehicleModelDetail),
                    // Selected Vehicle Model
                    selectedVehicleModel = editorViewModel.itemForEditing,
                    //save button handler
                    onSavebtn = function() {
                        if (dobeforeVehicleModel())
                            saveVehicleModel(selectedVehicleModel());
                },
                //Save Vehicle Model
                    saveVehicleModel = function (item) {
                        dataservice.saveVehicleModel(item.convertToServerData(), {
                        success: function(dataFromServer) {
                            var newItem = model.vehicleModelServertoClinetMapper(dataFromServer);
                            if (item.id() !== undefined) {
                                var newObjtodelete = vehicleModels.find(function(temp) {
                                    return temp.id() == newItem.id();
                                });
                                vehicleModels.remove(newObjtodelete);
                                vehicleModels.push(newItem);
                            } else
                                vehicleModels.push(newItem);
                            isVehicleModelEditorVisible(false);
                            toastr.success(ist.resourceText.VehicleModelSuccessfullySavedMessage);
                        },
                        error: function(exceptionMessage, exceptionType) {
                            if (exceptionType === ist.exceptionType.CaresGeneralException)
                                toastr.error(exceptionMessage);
                            else
                                toastr.error(ist.resourceText.FailedToSaveVehicleModelError);
                        }
                    });
                },
                //validation check 
                    dobeforeVehicleModel = function () {
                    if (!selectedVehicleModel().isValid()) {
                        selectedVehicleModel().errors.showAllMessages();
                        return false;
                    }
                    return true;
                },
                //cancel button handler
                    onCancelbtn = function() {
                    editorViewModel.revertItem();
                    isVehicleModelEditorVisible(false);
                },
                // create new Vehicle Model
                    onCreateForm = function () {
                    var vehicleModelDetail = new model.VehicleModelDetail();
                    editorViewModel.selectItem(vehicleModelDetail);
                    isVehicleModelEditorVisible(true);
                },
                //reset butto handle 
                    resetResuults = function() {
                    searchFilter(undefined);
                    getVehicleModels();
                },
                //delete button handler
                    onDeleteItem = function(item) {
                    if (!item.id()) {
                        vehicleModels.remove(item);
                        return;
                    }
                    // Ask for confirmation
                    confirmation.afterProceed(function() {
                        deleteVehicleModel(item);
                    });
                    confirmation.show();
                },
                //edit button handler
                    onEditItem = function(item) {
                    editorViewModel.selectItem(item);
                    isVehicleModelEditorVisible(true);
                },
                //delete Vehicle Model
                    deleteVehicleModel = function (vehicleModel) {
                        dataservice.deleteVehicleModel(vehicleModel.convertToServerData(), {
                        success: function() {
                            vehicleModels.remove(vehicleModel);
                            toastr.success(ist.resourceText.VehicleModelSuccesfullyDeleted);
                        },
                        error: function(exceptionMessage, exceptionType) {
                            if (exceptionType === ist.exceptionType.CaresGeneralException)
                                toastr.error(exceptionMessage);
                            else
                                toastr.error(ist.resourceText.FailedToDeleteVehicleModelError);
                        }
                    });
                },
                //search button handler in filter section
                    search = function() {
                    pager().reset();
                    getVehicleModels();
                },
                //hide filte section
                    hideFilterSection = function() {
                    filterSectionVisilble(false);
                },
                //Show filter section
                    showFilterSection = function() {
                        filterSectionVisilble(true);
                    },
                    //get Vehicle Models list from Dataservice
                    getVehicleModels = function () {
                        dataservice.getVehicleModels(
                        {
                            VehicleModelCodeNameFilterText: searchFilter(),
                            PageSize: pager().pageSize(),
                            PageNo: pager().currentPage(),
                            SortBy: sortOn(),
                            IsAsc: sortIsAsc()
                    },
                    {
                        success: function (data) {
                            vehicleModels.removeAll();
                            pager().totalCount(data.TotalCount);
                            _.each(data.VehicleModels, function (item) {
                                vehicleModels.push(model.vehicleModelServertoClinetMapper(item));
                            });
                        },
                        error: function() {
                            toastr.error(ist.resourceText.FailedToLoadVehicleModelError);
                        }
                    });
                    },
                    
                // Initialize the view model
                    initialize = function(specifiedView) {
                        view = specifiedView;
                        ko.applyBindings(view.viewModel, view.bindingRoot);
                        pager(pagination.Pagination({ PageSize: 10 }, vehicleModels, getVehicleModels));
                        getVehicleModels();
                    };
                return {
                    vehicleModels: vehicleModels,
                    initialize: initialize,
                    search: search,
                    searchFilter: searchFilter,
                    sortOn: sortOn,
                    sortIsAsc: sortIsAsc,
                    onCreateForm: onCreateForm,
                    filterSectionVisilble: filterSectionVisilble,
                    isVehicleModelEditorVisible: isVehicleModelEditorVisible,
                    hideFilterSection: hideFilterSection,
                    showFilterSection: showFilterSection,
                    pager: pager,
                    resetResuults: resetResuults,
                    onDeleteItem: onDeleteItem,
                    onEditItem: onEditItem,
                    onCancelbtn: onCancelbtn,
                    selectedVehicleModel: selectedVehicleModel,
                    onSavebtn: onSavebtn,
                    getVehicleModels: getVehicleModels,
                };
            })()
        };
        return ist.VehicleModel.viewModel;
    });
