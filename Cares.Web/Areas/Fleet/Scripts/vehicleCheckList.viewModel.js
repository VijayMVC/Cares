/*
    Module with the view model for the Vehicle CheckList
*/
define("vehicleCheckList/vehicleCheckList.viewModel",
    ["jquery", "amplify", "ko", "vehicleCheckList/vehicleCheckList.dataservice", "vehicleCheckList/vehicleCheckList.model",
    "common/confirmation.viewModel", "common/pagination"],
    function($, amplify, ko, dataservice, model, confirmation, pagination) {
        var ist = window.ist || {};
        ist.VehicleCheckList = {
            viewModel: (function() { 
                var view,
                    //array to save Vehicle CheckLists
                    vehicleCheckLists = ko.observableArray([]),
                    //pager%
                    pager = ko.observable(),
                    //Area filter in filter sec
                    searchFilter = ko.observable(),                   
                    //sorting
                    sortOn = ko.observable(1),
                    //Assending  / Desending
                    sortIsAsc = ko.observable(true),
                    //to control the visibility of editor sec
                    isVehicleCheckListEditorVisible = ko.observable(false),
                    //to control the visibility of filter ec
                    filterSectionVisilble = ko.observable(false),
                     // Editor View Model
                    editorViewModel = new ist.ViewModel(model.vehicleCheckListDetail),
                    // Selected Vehicle CheckList
                    selectedVehicleCheckList = editorViewModel.itemForEditing,
                    //save button handler
                    onSavebtn = function() {
                    if (dobeforeVehicleCheckList())
                        saveVehicleCheckList(selectedVehicleCheckList());
                },
                //Save Vehicle CheckList
                    saveVehicleCheckList = function (item) {
                        dataservice.saveVehicleCheckList(item.convertToServerData(), {
                        success: function(dataFromServer) {
                            var newItem = model.vehicleCheckListServertoClinetMapper(dataFromServer);
                            if (item.id() !== undefined) {
                                var newObjtodelete = vehicleCheckLists.find(function(temp) {
                                    return temp.id() == newItem.id();
                                });
                                vehicleCheckLists.remove(newObjtodelete);
                                vehicleCheckLists.push(newItem);
                            } else
                                vehicleCheckLists.push(newItem);
                            isVehicleCheckListEditorVisible(false);
                            toastr.success(ist.resourceText.VehicleCheckListSuccessfullySavedMessage);
                        },
                        error: function(exceptionMessage, exceptionType) {
                            if (exceptionType === ist.exceptionType.CaresGeneralException)
                                toastr.error(exceptionMessage);
                            else
                                toastr.error(ist.resourceText.FailedToSaveVehicleCheckListError);
                        }
                    });
                },
                //validation check 
                    dobeforeVehicleCheckList = function () {
                    if (!selectedVehicleCheckList().isValid()) {
                        selectedVehicleCheckList().errors.showAllMessages();
                        return false;
                    }
                    return true;
                },
                //cancel button handler
                    onCancelbtn = function() {
                    editorViewModel.revertItem();
                    isVehicleCheckListEditorVisible(false);
                },
                // create new Vehicle CheckList
                    onCreateForm = function () {
                    var vehicleCheckListt = new model.CreateCustomVehicleCheckList();
                    editorViewModel.selectItem(vehicleCheckListt);
                    isVehicleCheckListEditorVisible(true);
                },
                //reset butto handle 
                    resetResuults = function() {
                    searchFilter(undefined);
                    getVehicleCheckLists();
                },
                //delete button handler
                    onDeleteItem = function(item) {
                    if (!item.id()) {
                        vehicleCheckLists.remove(item);
                        return;
                    }
                    // Ask for confirmation
                    confirmation.afterProceed(function() {
                        deleteVehicleCheckList(item);
                    });
                    confirmation.show();
                },
                //edit button handler
                    onEditItem = function (item) {
                    editorViewModel.selectItem(item);
                    isVehicleCheckListEditorVisible(true);
                },
                //delete Vehicle CheckList
                    deleteVehicleCheckList = function (region) {
                        dataservice.deleteVehicleCheckList(region.convertToServerData(), {
                        success: function() {
                            vehicleCheckLists.remove(region);
                            toastr.success(ist.resourceText.VehicleCheckListSuccesfullyDeleted);
                        },
                        error: function(exceptionMessage, exceptionType) {
                            if (exceptionType === ist.exceptionType.CaresGeneralException)
                                toastr.error(exceptionMessage);
                            else
                                toastr.error(ist.resourceText.FailedToDeleteVehicleCheckListError);
                        }
                    });
                },
                //search button handler in filter section
                    search = function() {
                    pager().reset();
                    getVehicleCheckLists();
                },
                //hide filte section
                    hideFilterSection = function() {
                    filterSectionVisilble(false);
                },
                //Show filter section
                    showFilterSection = function() {
                        filterSectionVisilble(true);
                    },
                    //get Vehicle CheckLists list from Dataservice
                    getVehicleCheckLists = function () {
                        dataservice.getVehicleCheckList(
                        {
                            VehicleCheckListFilterText: searchFilter(),
                            PageSize: pager().pageSize(),
                            PageNo: pager().currentPage(),
                            SortBy: sortOn(),
                            IsAsc: sortIsAsc()
                    },
                    {
                        success: function (data) {
                            vehicleCheckLists.removeAll();
                            pager().totalCount(data.TotalCount);
                            _.each(data.VehicleCheckLists, function (item) {
                                vehicleCheckLists.push(model.vehicleCheckListServertoClinetMapper(item));
                            });
                        },
                        error: function() {
                            isLoadingFleetPools(false);
                            toastr.error(ist.resourceText.FailedToLoadVehicleCheckListError);
                        }
                    });
                    },
                // Initialize the view model
                    initialize = function(specifiedView) {
                        view = specifiedView;
                        ko.applyBindings(view.viewModel, view.bindingRoot);
                        pager(pagination.Pagination({ PageSize:10 }, vehicleCheckLists, getVehicleCheckLists));
                        getVehicleCheckLists();
                    };
                return {
                    vehicleCheckLists: vehicleCheckLists,
                    initialize: initialize,
                    search: search,
                    searchFilter: searchFilter,
                    sortOn: sortOn,
                    sortIsAsc: sortIsAsc,
                    onCreateForm: onCreateForm,
                    filterSectionVisilble: filterSectionVisilble,
                    isVehicleCheckListEditorVisible: isVehicleCheckListEditorVisible,
                    hideFilterSection: hideFilterSection,
                    showFilterSection: showFilterSection,
                    pager: pager,
                    resetResuults: resetResuults,
                    onDeleteItem: onDeleteItem,
                    onEditItem: onEditItem,
                    onCancelbtn: onCancelbtn,
                    selectedVehicleCheckList: selectedVehicleCheckList,
                    onSavebtn: onSavebtn,
                    getVehicleCheckLists: getVehicleCheckLists
                };
            })()
        };
        return ist.VehicleCheckList.viewModel;
    });
