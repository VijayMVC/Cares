/*
    Module with the view model for the Nrt Type
*/
define("nRTType/nRTType.viewModel",
    ["jquery", "amplify", "ko", "nRTType/nRTType.dataservice", "nRTType/nRTType.model",
    "common/confirmation.viewModel", "common/pagination"],
    function($, amplify, ko, dataservice, model, confirmation, pagination) {
        var ist = window.ist || {};
        ist.NrtType = {
            viewModel: (function() { 
                var view,
                    //array to save nrt Types
                    nrtTypes = ko.observableArray([]),
                    //array to save basa data Vehicle Status list
                    baseVehicleStatusList = ko.observableArray([]),
                    //pager%
                    pager = ko.observable(),
                    //org code filter in filter sec
                    searchFilter = ko.observable(),
                    baseVehicleStatusFilter = ko.observable(),
                    //sorting
                    sortOn = ko.observable(1),
                    //Assending  / Desending
                    sortIsAsc = ko.observable(true),
                    //to control the visibility of editor sec
                    isNrtTypeEditorVisible = ko.observable(false),
                    //to control the visibility of filter ec
                    filterSectionVisilble = ko.observable(false),
                     // Editor View Model
                    editorViewModel = new ist.ViewModel(model.NrtTypeDetail),
                    // Selected Nrt Type
                    selectedNrtType = editorViewModel.itemForEditing,
                    //save button handler
                    onSavebtn = function() {
                    if (dobeforeNrtType())
                        saveNrtType(selectedNrtType());
                },
                //Save Nrt Type
                    saveNrtType = function (item) {
                        dataservice.saveNrtType(item.convertToServerData(), {
                        success: function(dataFromServer) {
                            var newItem = model.nRtTypeServertoClinetMapper(dataFromServer);
                            if (item.id() !== undefined) {
                                var newObjtodelete = nrtTypes.find(function(temp) {
                                    return temp.id() == newItem.id();
                                });
                                nrtTypes.remove(newObjtodelete);
                                nrtTypes.push(newItem);
                            } else
                                nrtTypes.push(newItem);
                            isNrtTypeEditorVisible(false);
                            toastr.success(ist.resourceText.NrtTypeSuccessFullySavedMessage);
                        },
                        error: function(exceptionMessage, exceptionType) {
                            if (exceptionType === ist.exceptionType.CaresGeneralException)
                                toastr.error(exceptionMessage);
                            else
                                toastr.error(ist.resourceText.FailedToSaveNrtTypeError);
                        }
                    });
                },
                //validation check 
                    dobeforeNrtType = function () {
                    if (!selectedNrtType().isValid()) {
                        selectedNrtType().errors.showAllMessages();
                        return false;
                    }
                    return true;
                },
                //cancel button handler
                    onCancelbtn = function() {
                    editorViewModel.revertItem();
                    isNrtTypeEditorVisible(false);
                },
                // create new nrt Type
                    onCreateForm = function () {
                    var nrtType = new model.NrtTypeDetail();
                    editorViewModel.selectItem(nrtType);
                    isNrtTypeEditorVisible(true);
                },
                //reset butto handle 
                    resetResuults = function() {
                        searchFilter(undefined);
                        baseVehicleStatusFilter(undefined);
                    getNrtTypes();
                },
                //delete button handler
                    onDeleteItem = function(item) {
                    if (!item.id()) {
                        nrtTypes.remove(item);
                        return;
                    }
                    // Ask for confirmation
                    confirmation.afterProceed(function() {
                        deleteNrtType(item);
                    });
                    confirmation.show();
                },
                //edit button handler
                    onEditItem = function(item) {
                    editorViewModel.selectItem(item);
                    isNrtTypeEditorVisible(true);
                },
                //delete nrt Type
                    deleteNrtType = function (region) {
                        dataservice.deleteNrtType(region.convertToServerData(), {
                        success: function() {
                            nrtTypes.remove(region);
                            toastr.success(ist.resourceText.NrtTypeSuccessfullyDeletedMessage);
                        },
                        error: function(exceptionMessage, exceptionType) {
                            if (exceptionType === ist.exceptionType.CaresGeneralException)
                                toastr.error(exceptionMessage);
                            else
                                toastr.error(ist.resourceText.FailedToDeleteNrtTypeError);
                        }
                    });
                },
                //search button handler in filter section
                    search = function() {
                    pager().reset();
                    getNrtTypes();
                },
                //hide filte section
                    hideFilterSection = function() {
                    filterSectionVisilble(false);
                },
                //Show filter section
                    showFilterSection = function() {
                        filterSectionVisilble(true);
                    },
                    //get Nrt Types list from Dataservice
                    getNrtTypes = function() {
                        dataservice.getNrtTypes(
                        {
                            NrtTypeFilterText: searchFilter(),
                            VehhicleStatusId: baseVehicleStatusFilter(),
                            PageSize: pager().pageSize(),
                            PageNo: pager().currentPage(),
                            SortBy: sortOn(),
                            IsAsc: sortIsAsc()
                    },
                    {
                        success: function (data) {
                            nrtTypes.removeAll();
                            pager().totalCount(data.TotalCount);
                            _.each(data.NrtTypes, function (item) {
                                nrtTypes.push(model.nRtTypeServertoClinetMapper(item));
                            });
                        },
                        error: function() {
                            isLoadingFleetPools(false);
                            toastr.error(ist.resourceText.FailedToLoadNrtTypesError);
                        }
                    });
                    },
                     //get Nrt Types base data
                    getBaseData = function () {
                        dataservice.getNrtTypeBaseData(null, {
                            success: function (data) {
                                baseVehicleStatusList.removeAll();
                                ko.utils.arrayPushAll(baseVehicleStatusList(), data.VehicleStatuses);
                                baseVehicleStatusList.valueHasMutated();
                            },
                            error: function (exceptionMessage, exceptionType) {
                                if (exceptionType === ist.exceptionType.CaresGeneralException) {
                                    toastr.error(exceptionMessage);
                                } else {
                                    toastr.error(ist.resourceText.FailedToloadBaseDataError);
                                }
                            }
                        });
                    },
                // Initialize the view model
                    initialize = function(specifiedView) {
                        view = specifiedView;
                        ko.applyBindings(view.viewModel, view.bindingRoot);
                        pager(pagination.Pagination({ PageSize: 10 }, nrtTypes, getNrtTypes));
                        getBaseData();
                        getNrtTypes();
                    };
                return {
                    nrtTypes: nrtTypes,
                    initialize: initialize,
                    search: search,
                    searchFilter: searchFilter,
                    sortOn: sortOn,
                    sortIsAsc: sortIsAsc,
                    onCreateForm: onCreateForm,
                    filterSectionVisilble: filterSectionVisilble,
                    isNrtTypeEditorVisible: isNrtTypeEditorVisible,
                    hideFilterSection: hideFilterSection,
                    showFilterSection: showFilterSection,
                    pager: pager,
                    resetResuults: resetResuults,
                    onDeleteItem: onDeleteItem,
                    onEditItem: onEditItem,
                    onCancelbtn: onCancelbtn,
                    selectedNrtType: selectedNrtType,
                    onSavebtn: onSavebtn,
                    getNrtTypes: getNrtTypes,
                    getBaseData: getBaseData,
                    baseVehicleStatusList: baseVehicleStatusList,
                    baseVehicleStatusFilter: baseVehicleStatusFilter

                };
            })()
        };
        return ist.NrtType.viewModel;
    });
