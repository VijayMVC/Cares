/*
    Module with the view model for the Service Items
*/
define("serviceItem/serviceItem.viewModel",
    ["jquery", "amplify", "ko", "serviceItem/serviceItem.dataservice", "serviceItem/serviceItem.model",
    "common/confirmation.viewModel", "common/pagination"],
    function($, amplify, ko, dataservice, model, confirmation, pagination) {
        var ist = window.ist || {};
        ist.ServiceItem = {
            viewModel: (function() { 
                var view,
                    //array to save Service Items
                    serviceItems = ko.observableArray([]),
                    //array to save base data Service Types
                    baseServiceTypesList = ko.observableArray([]),
                    //pager%
                    pager = ko.observable(),
                    // Service Item code and name filter in filter sec
                    searchFilter = ko.observable(),
                    // Service Type filter in filter sec
                    serviceTypeFilter = ko.observable(),
                    //sorting
                    sortOn = ko.observable(1),
                    //Assending  / Desending
                    sortIsAsc = ko.observable(true),
                    //to control the visibility of editor sec
                    isServiceItemEditorVisible = ko.observable(false),
                    //to control the visibility of filter ec
                    filterSectionVisilble = ko.observable(false),
                     // Editor View Model
                    editorViewModel = new ist.ViewModel(model.ServiceItemDetail),
                    // Selected Service Item
                    selectedServiceItem = editorViewModel.itemForEditing,
                    //save button handler
                    onSavebtn = function() {
                    if (dobeforeServiceItem())
                        saveServiceItem(selectedServiceItem());
                },
                //Save Service Item
                    saveServiceItem = function(item) {
                    dataservice.saveServiceItem(item.convertToServerData(), {
                        success: function(dataFromServer) {
                            var newItem = model.serviceItemServertoClinetMapper(dataFromServer);
                            if (item.id() !== undefined) {
                                var newObjtodelete = serviceItems.find(function(temp) {
                                    return temp.id() == newItem.id();
                                });
                                serviceItems.remove(newObjtodelete);
                                serviceItems.push(newItem);
                            } else
                                serviceItems.push(newItem);
                            isServiceItemEditorVisible(false);
                            toastr.success(ist.resourceText.ServiceItemSuccessfullySaved);
                        },
                        error: function(exceptionMessage, exceptionType) {
                            if (exceptionType === ist.exceptionType.CaresGeneralException)
                                toastr.error(exceptionMessage);
                            else
                                toastr.error(ist.resourceText.FailedToSaveServiceItemError);
                        }
                    });
                },
                //validation check 
                    dobeforeServiceItem = function () {
                    if (!selectedServiceItem().isValid()) {
                        selectedServiceItem().errors.showAllMessages();
                        return false;
                    }
                    return true;
                },
                //cancel button handler
                    onCancelbtn = function() {
                    editorViewModel.revertItem();
                    isServiceItemEditorVisible(false);
                },
                // create new Service Item
                    onCreateForm = function () {
                    var serviceItem = new model.ServiceItemDetail();
                    editorViewModel.selectItem(serviceItem);
                    isServiceItemEditorVisible(true);
                },
                //reset butto handle 
                    resetResuults = function() {
                        searchFilter(undefined);
                        serviceTypeFilter(undefined);
                        getServiceItems();
                },
                //delete button handler
                    onDeleteItem = function(item) {
                    if (!item.id()) {
                        serviceItems.remove(item);
                        return;
                    }
                    // Ask for confirmation
                    confirmation.afterProceed(function() {
                        deleteServiceItem(item);
                    });
                    confirmation.show();
                },
                //edit button handler
                    onEditItem = function(item) {
                    editorViewModel.selectItem(item);
                    isServiceItemEditorVisible(true);
                },
                //delete Service Item
                    deleteServiceItem = function (region) {
                        dataservice.deleteServiceItem(region.convertToServerData(), {
                        success: function() {
                            serviceItems.remove(region);
                            toastr.success(ist.resourceText.ServiceItemSuccessfullyDeleted);
                        },
                        error: function(exceptionMessage, exceptionType) {
                            if (exceptionType === ist.exceptionType.CaresGeneralException)
                                toastr.error(exceptionMessage);
                            else
                                toastr.error(ist.resourceText.FailedToDeleteServiceItemError);
                        }
                    });
                },
                //search button handler in filter section
                    search = function() {
                    pager().reset();
                    getServiceItems();
                },
                //hide filte section
                    hideFilterSection = function() {
                    filterSectionVisilble(false);
                },
                //Show filter section
                    showFilterSection = function() {
                        filterSectionVisilble(true);
                    },
                    //get Service Items list from Dataservice
                    getServiceItems = function() {
                    dataservice.getServiceItem(
                    {
                        ServiceItemFilterText: searchFilter(),
                        ServiceTypeId: serviceTypeFilter(),
                        PageSize: pager().pageSize(),
                        PageNo: pager().currentPage(),
                        SortBy: sortOn(),
                        IsAsc: sortIsAsc()
                    },
                    {
                        success: function(data) {
                            serviceItems.removeAll();
                            pager().totalCount(data.TotalCount);
                            _.each(data.ServiceItems, function(item) {
                                serviceItems.push(model.serviceItemServertoClinetMapper(item));
                            });
                        },
                        error: function() {
                            isLoadingFleetPools(false);
                            toastr.error(ist.resourceText.FailedToLoadServiceItemsError);
                        }
                    });
                },
                //get Service Item base data
                    getServiceItemBaseData = function () {
                        dataservice.getServiceItemBaseData(null, {
                            success: function (data) {
                                baseServiceTypesList.removeAll();
                                ko.utils.arrayPushAll(baseServiceTypesList(), data.ServiceTypes);
                                baseServiceTypesList.valueHasMutated();
                            },
                            error: function (exceptionMessage, exceptionType) {
                                if (exceptionType === ist.exceptionType.CaresGeneralException) {
                                    toastr.error(exceptionMessage);
                                } else {
                                    toastr.error(ist.resourceText.FailedToLoadBaseData);
                                }
                            }
                        });
                    },
                // Initialize the view model
                    initialize = function(specifiedView) {
                        view = specifiedView;
                        ko.applyBindings(view.viewModel, view.bindingRoot);
                        pager(pagination.Pagination({ PageSize: 10 }, serviceItems, getServiceItems));
                        getServiceItemBaseData();
                        getServiceItems();
                    };
                return {
                    serviceItems: serviceItems,
                    initialize: initialize,
                    search: search,
                    searchFilter: searchFilter,
                    serviceTypeFilter:serviceTypeFilter,
                    sortOn: sortOn,
                    sortIsAsc: sortIsAsc,
                    onCreateForm: onCreateForm,
                    filterSectionVisilble: filterSectionVisilble,
                    isServiceItemEditorVisible: isServiceItemEditorVisible,
                    hideFilterSection: hideFilterSection,
                    showFilterSection: showFilterSection,
                    pager: pager,
                    resetResuults: resetResuults,
                    onDeleteItem: onDeleteItem,
                    onEditItem: onEditItem,
                    onCancelbtn: onCancelbtn,
                    selectedServiceItem: selectedServiceItem,
                    onSavebtn: onSavebtn,
                    getServiceItems: getServiceItems,
                    baseServiceTypesList: baseServiceTypesList
                };
            })()
        };
        return ist.ServiceItem.viewModel;
    });
