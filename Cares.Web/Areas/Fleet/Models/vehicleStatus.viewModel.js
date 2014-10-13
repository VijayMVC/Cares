/*
    Module with the view model for the Vehicle Status
*/
define("vehicleStatus/vehicleStatus.viewModel",
    ["jquery", "amplify", "ko", "vehicleStatus/vehicleStatus.dataservice", "vehicleStatus/vehicleStatus.model",
    "common/confirmation.viewModel", "common/pagination"],
    function($, amplify, ko, dataservice, model, confirmation, pagination) {
        var ist = window.ist || {};
        ist.VehicleStatus = {
            viewModel: (function() { 
                var view,
                    //array to save Vehicle Statuses
                    vehicleStatuses = ko.observableArray([]),
                    //pager%
                    pager = ko.observable(),
                    //org code filter in filter sec
                    searchFilter = ko.observable(),
                    //sorting
                    sortOn = ko.observable(1),
                    //Assending  / Desending
                    sortIsAsc = ko.observable(true),
                    //to control the visibility of editor sec
                    isVehicleStatusEditorVisible = ko.observable(false),
                    //to control the visibility of filter ec
                    filterSectionVisilble = ko.observable(false),
                     // Editor View Model
                    editorViewModel = new ist.ViewModel(model.VehicleStatusDetail),
                    // Selected Vehicle Status
                    selectedVehicleStatus = editorViewModel.itemForEditing,
                    //save button handler
                    onSavebtn = function() {
                        if (dobeforeVehicleStatus())
                            saveVehicleStatus(selectedVehicleStatus());
                },
                //Save Vehicle Status
                    saveVehicleStatus = function (item) {
                        dataservice.saveVehicleStatus(item.convertToServerData(), {
                        success: function(dataFromServer) {
                            var newItem = model.vehicleStatusServertoClinetMapper(dataFromServer);
                            if (item.id() !== undefined) {
                                var newObjtodelete = vehicleStatuses.find(function(temp) {
                                    return temp.id() == newItem.id();
                                });
                                vehicleStatuses.remove(newObjtodelete);
                                vehicleStatuses.push(newItem);
                            } else
                                vehicleStatuses.push(newItem);
                            isVehicleStatusEditorVisible(false);
                            toastr.success(ist.resourceText.VehicleStatusSuccessfullySavedMessage);
                        },
                        error: function(exceptionMessage, exceptionType) {
                            if (exceptionType === ist.exceptionType.CaresGeneralException)
                                toastr.error(exceptionMessage);
                            else
                                toastr.error(ist.resourceText.FailedToSaveVehicleStatusError);
                        }
                    });
                },
                //validation check 
                    dobeforeVehicleStatus = function () {
                    if (!selectedVehicleStatus().isValid()) {
                        selectedVehicleStatus().errors.showAllMessages();
                        return false;
                    }
                    return true;
                },
                //cancel button handler
                    onCancelbtn = function() {
                    editorViewModel.revertItem();
                    isVehicleStatusEditorVisible(false);
                },
                // create new Vehicle Status
                    onCreateForm = function () {
                    var vehicleStatusDetail = new model.VehicleStatusDetail();
                    editorViewModel.selectItem(vehicleStatusDetail);
                    isVehicleStatusEditorVisible(true);
                },
                //reset butto handle 
                    resetResuults = function() {
                    searchFilter(undefined);
                    getVehiclStatuses();
                },
                //delete button handler
                    onDeleteItem = function(item) {
                    if (!item.id()) {
                        vehicleStatuses.remove(item);
                        return;
                    }
                    // Ask for confirmation
                    confirmation.afterProceed(function() {
                        deleteVehicleStatus(item);
                    });
                    confirmation.show();
                },
                //edit button handler
                    onEditItem = function(item) {
                    editorViewModel.selectItem(item);
                    isVehicleStatusEditorVisible(true);
                },
                //delete Vehicle Status
                    deleteVehicleStatus = function (vehicleStatus) {
                        dataservice.deleteVehicleStatus(vehicleStatus.convertToServerData(), {
                        success: function() {
                            vehicleStatuses.remove(vehicleStatus);
                            toastr.success(ist.resourceText.VehicleStatusSuccesfullyDeleted);
                        },
                        error: function(exceptionMessage, exceptionType) {
                            if (exceptionType === ist.exceptionType.CaresGeneralException)
                                toastr.error(exceptionMessage);
                            else
                                toastr.error(ist.resourceText.FailedToDeleteVehicleStatusError);
                        }
                    });
                },
                //search button handler in filter section
                    search = function() {
                    pager().reset();
                    getVehiclStatuses();
                },
                //hide filte section
                    hideFilterSection = function() {
                    filterSectionVisilble(false);
                },
                //Show filter section
                    showFilterSection = function() {
                        filterSectionVisilble(true);
                    },
                    //get Vehicle Statuses list from Dataservice
                    getVehiclStatuses = function () {
                        dataservice.getVehicleStatuses(
                        {
                            VehicleStatusCodeNameFilterText: searchFilter(),
                            PageSize: pager().pageSize(),
                            PageNo: pager().currentPage(),
                            SortBy: sortOn(),
                            IsAsc: sortIsAsc()
                    },
                    {
                        success: function (data) {
                            vehicleStatuses.removeAll();
                            pager().totalCount(data.TotalCount);
                            _.each(data.VehicleStatuses, function (item) {
                                vehicleStatuses.push(model.vehicleStatusServertoClinetMapper(item));
                            });
                        },
                        error: function() {
                            toastr.error(ist.resourceText.FailedToLoadVehicleStatusError);
                        }
                    });
                    },
                    
                // Initialize the view model
                    initialize = function(specifiedView) {
                        view = specifiedView;
                        ko.applyBindings(view.viewModel, view.bindingRoot);
                        pager(pagination.Pagination({ PageSize: 10 }, vehicleStatuses, getVehiclStatuses));
                        getVehiclStatuses();
                    };
                return {
                    vehicleStatuses: vehicleStatuses,
                    initialize: initialize,
                    search: search,
                    searchFilter: searchFilter,
                    sortOn: sortOn,
                    sortIsAsc: sortIsAsc,
                    onCreateForm: onCreateForm,
                    filterSectionVisilble: filterSectionVisilble,
                    isVehicleStatusEditorVisible: isVehicleStatusEditorVisible,
                    hideFilterSection: hideFilterSection,
                    showFilterSection: showFilterSection,
                    pager: pager,
                    resetResuults: resetResuults,
                    onDeleteItem: onDeleteItem,
                    onEditItem: onEditItem,
                    onCancelbtn: onCancelbtn,
                    selectedVehicleStatus: selectedVehicleStatus,
                    onSavebtn: onSavebtn,
                    getVehiclStatuses: getVehiclStatuses,
                };
            })()
        };
        return ist.VehicleStatus.viewModel;
    });
