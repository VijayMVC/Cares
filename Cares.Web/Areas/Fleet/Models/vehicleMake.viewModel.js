/*
    Module with the view model for the Vehicle Make
*/
define("vehicleMake/vehicleMake.viewModel",
    ["jquery", "amplify", "ko", "vehicleMake/vehicleMake.dataservice", "vehicleMake/vehicleMake.model",
    "common/confirmation.viewModel", "common/pagination"],
    function($, amplify, ko, dataservice, model, confirmation, pagination) {
        var ist = window.ist || {};
        ist.VehicleMake = {
            viewModel: (function() { 
                var view,
                    //array to save Vehicle Makes
                    vehicleMakes = ko.observableArray([]),
                    //pager%
                    pager = ko.observable(),
                    //org code filter in filter sec
                    searchFilter = ko.observable(),
                    //sorting
                    sortOn = ko.observable(1),
                    //Assending  / Desending
                    sortIsAsc = ko.observable(true),
                    //to control the visibility of editor sec
                    isVehicleMakeEditorVisible = ko.observable(false),
                    //to control the visibility of filter ec
                    filterSectionVisilble = ko.observable(false),
                     // Editor View Model
                    editorViewModel = new ist.ViewModel(model.VehicleMakeDetail),
                    // Selected Vehicle Make
                    selectedVehicleMake = editorViewModel.itemForEditing,
                    //save button handler
                    onSavebtn = function() {
                        if (dobeforeVehicleMake())
                            saveVehicleMake(selectedVehicleMake());
                },
                //Save Vehicle Make
                    saveVehicleMake = function (item) {
                        dataservice.saveVehicleMake(item.convertToServerData(), {
                        success: function(dataFromServer) {
                            var newItem = model.vehicleMakeServertoClinetMapper(dataFromServer);
                            if (item.id() !== undefined) {
                                var newObjtodelete = vehicleMakes.find(function (temp) {
                                    return temp.id() == newItem.id();
                                });
                                vehicleMakes.remove(newObjtodelete);
                                vehicleMakes.push(newItem);
                            } else
                                vehicleMakes.push(newItem);
                            isVehicleMakeEditorVisible(false);
                            toastr.success(ist.resourceText.VehicleMakeSuccessfullySavedMessage);
                        },
                        error: function(exceptionMessage, exceptionType) {
                            if (exceptionType === ist.exceptionType.CaresGeneralException)
                                toastr.error(exceptionMessage);
                            else
                                toastr.error(ist.resourceText.FailedToSaveVehicleMakeError);
                        }
                    });
                },
                //validation check 
                    dobeforeVehicleMake = function () {
                        if (!selectedVehicleMake().isValid()) {
                            selectedVehicleMake().errors.showAllMessages();
                        return false;
                    }
                    return true;
                },
                //cancel button handler
                    onCancelbtn = function() {
                    editorViewModel.revertItem();
                    isVehicleMakeEditorVisible(false);
                },
                // create new Vehicle Make
                    onCreateForm = function() {
                    var vehicleMakeDetail = new model.VehicleMakeDetail();
                    editorViewModel.selectItem(vehicleMakeDetail);
                    isVehicleMakeEditorVisible(true);
                },
                //reset butto handle 
                    resetResuults = function() {
                    searchFilter(undefined);
                    getvehicleMakes();
                },
                //delete button handler
                    onDeleteItem = function(item) {
                    if (!item.id()) {
                        vehicleMakes.remove(item);
                        return;
                    }
                    // Ask for confirmation
                    confirmation.afterProceed(function() {
                        deleteVehicleMake(item);
                    });
                    confirmation.show();
                },
                //edit button handler
                    onEditItem = function(item) {
                    editorViewModel.selectItem(item);
                    isVehicleMakeEditorVisible(true);
                },
                //delete Vehicle Make
                    deleteVehicleMake = function (vehicleMake) {
                        dataservice.deleteVehicleMake(vehicleMake.convertToServerData(), {
                        success: function() {
                            vehicleMakes.remove(vehicleMake);
                            toastr.success(ist.resourceText.VehicleMakeSuccessfullyDeletedMessage);
                        },
                        error: function(exceptionMessage, exceptionType) {
                            if (exceptionType === ist.exceptionType.CaresGeneralException)
                                toastr.error(exceptionMessage);
                            else
                                toastr.error(ist.resourceText.FailedToDeleteVehicleMakeError);
                        }
                    });
                },
                //search button handler in filter section
                    search = function() {
                    pager().reset();
                    getvehicleMakes();
                },
                //hide filte section
                    hideFilterSection = function() {
                    filterSectionVisilble(false);
                },
                //Show filter section
                    showFilterSection = function() {
                        filterSectionVisilble(true);
                    },
                    //get Vehicle Make list from Dataservice
                    getvehicleMakes = function () {
                        dataservice.getVehicleMakes(
                        {
                            VehicleMakeCodeNameText: searchFilter(),
                            PageSize: pager().pageSize(),
                            PageNo: pager().currentPage(),
                            SortBy: sortOn(),
                            IsAsc: sortIsAsc()
                    },
                    {
                        success: function (data) {
                            vehicleMakes.removeAll();
                            pager().totalCount(data.TotalCount);
                            _.each(data.VehicleMakes, function (item) {
                                vehicleMakes.push(model.vehicleMakeServertoClinetMapper(item));
                            });
                        },
                        error: function() {
                            isLoadingFleetPools(false);
                            toastr.error(ist.resourceText.FailedToLoadVehicleMakesError);
                        }
                    });
                    },
                    
                // Initialize the view model
                    initialize = function(specifiedView) {
                        view = specifiedView;
                        ko.applyBindings(view.viewModel, view.bindingRoot);
                        pager(pagination.Pagination({ PageSize: 10 }, vehicleMakes, getvehicleMakes));
                        getvehicleMakes();
                    };
                return {
                    vehicleMakes: vehicleMakes,
                    initialize: initialize,
                    search: search,
                    searchFilter: searchFilter,
                    sortOn: sortOn,
                    sortIsAsc: sortIsAsc,
                    onCreateForm: onCreateForm,
                    filterSectionVisilble: filterSectionVisilble,
                    isVehicleMakeEditorVisible: isVehicleMakeEditorVisible,
                    hideFilterSection: hideFilterSection,
                    showFilterSection: showFilterSection,
                    pager: pager,
                    resetResuults: resetResuults,
                    onDeleteItem: onDeleteItem,
                    onEditItem: onEditItem,
                    onCancelbtn: onCancelbtn,
                    selectedVehicleMake: selectedVehicleMake,
                    onSavebtn: onSavebtn,
                    getvehicleMakes: getvehicleMakes,
                };
            })()
        };
        return ist.VehicleMake.viewModel;
    });
