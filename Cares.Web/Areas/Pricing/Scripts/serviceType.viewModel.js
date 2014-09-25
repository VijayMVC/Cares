/*
    Module with the view model for the Service Type
*/
define("serviceType/serviceType.viewModel",
    ["jquery", "amplify", "ko", "serviceType/serviceType.dataservice", "serviceType/serviceType.model",
    "common/confirmation.viewModel", "common/pagination"],
    function($, amplify, ko, dataservice, model, confirmation, pagination) {
        var ist = window.ist || {};
        ist.ServiceType = {
            viewModel: (function() { 
                var view,
                    //array to save Service Types
                    serviceTypes = ko.observableArray([]),
                    //pager%
                    pager = ko.observable(),
                    //org code filter in filter sec
                    searchFilter = ko.observable(),
                    //sorting
                    sortOn = ko.observable(1),
                    //Assending  / Desending
                    sortIsAsc = ko.observable(true),
                    //to control the visibility of editor sec
                    isServiceTypeEditorVisible = ko.observable(false),
                    //to control the visibility of filter ec
                    filterSectionVisilble = ko.observable(false),
                     // Editor View Model
                    editorViewModel = new ist.ViewModel(model.ServiceTypeDetail),
                    // Selected Service Type
                    selectedServiceType = editorViewModel.itemForEditing,
                    //save button handler
                    onSavebtn = function() {
                    if (dobeforeServiceType())
                        saveServiceType(selectedServiceType());
                },
                //Save Service Type
                    saveServiceType = function (item) {
                        dataservice.saveServiceType(item.convertToServerData(), {
                        success: function(dataFromServer) {
                            var newItem = model.serviceTypeServertoClinetMapper(dataFromServer);
                            if (item.id() !== undefined) {
                                var newObjtodelete = serviceTypes.find(function(temp) {
                                    return temp.id() == newItem.id();
                                });
                                serviceTypes.remove(newObjtodelete);
                                serviceTypes.push(newItem);
                            } else
                                serviceTypes.push(newItem);
                            isServiceTypeEditorVisible(false);
                            toastr.success(ist.resourceText.ServiceTypeSavedSuccessfullyMessage);
                        },
                        error: function(exceptionMessage, exceptionType) {
                            if (exceptionType === ist.exceptionType.CaresGeneralException)
                                toastr.error(exceptionMessage);
                            else
                                toastr.error(ist.resourceText.ServiceTypeFailedToSaveError);
                        }
                    });
                },
                //validation check 
                    dobeforeServiceType = function () {
                    if (!selectedServiceType().isValid()) {
                        selectedServiceType().errors.showAllMessages();
                        return false;
                    }
                    return true;
                },
                //cancel button handler
                    onCancelbtn = function() {
                    editorViewModel.revertItem();
                    isServiceTypeEditorVisible(false);
                },
                // create new Service Type
                    onCreateForm = function () {
                    var serviceType = new model.ServiceTypeDetail();
                    editorViewModel.selectItem(serviceType);
                    isServiceTypeEditorVisible(true);
                },
                //reset butto handle 
                    resetResuults = function() {
                        searchFilter(undefined);
                        getServiceType();
                },
                //delete button handler
                    onDeleteItem = function(item) {
                    if (!item.id()) {
                        serviceTypes.remove(item);
                        return;
                    }
                    // Ask for confirmation
                    confirmation.afterProceed(function() {
                        deleteServiceType(item);
                    });
                    confirmation.show();
                },
                //edit button handler
                    onEditItem = function(item) {
                    editorViewModel.selectItem(item);
                    isServiceTypeEditorVisible(true);
                },
                //delete Service Type
                    deleteServiceType = function (region) {
                        dataservice.deleteServiceType(region.convertToServerData(), {
                        success: function() {
                            serviceTypes.remove(region);
                            toastr.success(ist.resourceText.ServiceTypeDeletedSuccessfullyMessage);
                        },
                        error: function(exceptionMessage, exceptionType) {
                            if (exceptionType === ist.exceptionType.CaresGeneralException)
                                toastr.error(exceptionMessage);
                            else
                                toastr.error(ist.resourceText.ServiceTypeFailedTodeleteError);
                        }
                    });
                },
                //search button handler in filter section
                    search = function() {
                    pager().reset();
                    getServiceType();
                },
                //hide filte section
                    hideFilterSection = function() {
                    filterSectionVisilble(false);
                },
                //Show filter section
                    showFilterSection = function() {
                        filterSectionVisilble(true);
                    },
                    //get Service Types list from Dataservice
                    getServiceType = function () {
                        dataservice.getServiceType(
                        {
                            ServiceTypeFilterText: searchFilter(),
                            PageSize: pager().pageSize(),
                            PageNo: pager().currentPage(),
                            SortBy: sortOn(),
                            IsAsc: sortIsAsc()
                    },
                    {
                        success: function (data) {
                            serviceTypes.removeAll();
                            pager().totalCount(data.TotalCount);
                            _.each(data.ServiceTypes, function (item) {
                                serviceTypes.push(model.serviceTypeServertoClinetMapper(item));
                            });
                        },
                        error: function() {
                            isLoadingFleetPools(false);
                            toastr.error(ist.resourceText.ServiceTypeFailedToLoadError);
                        }
                    });
                    },
                     
                // Initialize the view model
                    initialize = function(specifiedView) {
                        view = specifiedView;
                        ko.applyBindings(view.viewModel, view.bindingRoot);
                        pager(pagination.Pagination({ PageSize: 10 }, serviceTypes, getServiceType));
                        getServiceType();
                    };
                return {
                    serviceTypes: serviceTypes,
                    initialize: initialize,
                    search: search,
                    searchFilter: searchFilter,
                    sortOn: sortOn,
                    sortIsAsc: sortIsAsc,
                    onCreateForm: onCreateForm,
                    filterSectionVisilble: filterSectionVisilble,
                    isServiceTypeEditorVisible: isServiceTypeEditorVisible,
                    hideFilterSection: hideFilterSection,
                    showFilterSection: showFilterSection,
                    pager: pager,
                    resetResuults: resetResuults,
                    onDeleteItem: onDeleteItem,
                    onEditItem: onEditItem,
                    onCancelbtn: onCancelbtn,
                    selectedServiceType: selectedServiceType,
                    onSavebtn: onSavebtn,
                    getServiceType: getServiceType
                };
            })()
        };
        return ist.ServiceType.viewModel;
    });
