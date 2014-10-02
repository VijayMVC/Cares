/*
    Module with the view model for the Business Partner Sub Type
*/
define("bpSubType/bpSubType.viewModel",
    ["jquery", "amplify", "ko", "bpSubType/bpSubType.dataservice", "bpSubType/bpSubType.model",
    "common/confirmation.viewModel", "common/pagination"],
    function ($, amplify, ko, dataservice, model, confirmation, pagination) {
        var ist = window.ist || {};
        ist.BusinessPartnerSubType = {
            viewModel: (function () {
                var view,
                    //array to save Business Partner Sub Types
                    businessPartnerSubTypes = ko.observableArray([]),
                    //array to save basa data Business Partner Main Type list
                    baseBusinessPartnerMainTypeList = ko.observableArray([]),
                    //pager%
                    pager = ko.observable(),
                    //org code filter in filter sec
                    searchFilter = ko.observable(),
                    businessPartnerMainTypeFilter = ko.observable(),
                    //sorting
                    sortOn = ko.observable(1),
                    //Assending  / Desending
                    sortIsAsc = ko.observable(true),
                    //to control the visibility of editor sec
                    isBusinessPartnerSubTypeVisible = ko.observable(false),
                    //to control the visibility of filter ec
                    filterSectionVisilble = ko.observable(false),
                     // Editor View Model
                    editorViewModel = new ist.ViewModel(model.BusinessPartnerSubTypeDetail),
                    // Selected Business Partner Sub Type
                    selectedBusinessPartnerSubType = editorViewModel.itemForEditing,
                    //save button handler
                    onSavebtn = function () {
                        if (dobeforeBusinessPartnerSubType())
                            saveBusinessPartnerSubType(selectedBusinessPartnerSubType());
                    },
                //Save Business Partner Sub Types
                    saveBusinessPartnerSubType = function (item) {
                        dataservice.saveBusinessPartnerSubType(item.convertToServerData(), {
                            success: function (dataFromServer) {
                                var newItem = model.businessPartnerSubTypeServertoClinetMapper(dataFromServer);
                                if (item.id() !== undefined) {
                                    var newObjtodelete = businessPartnerSubTypes.find(function (temp) {
                                        return temp.id() == newItem.id();
                                    });
                                    businessPartnerSubTypes.remove(newObjtodelete);
                                    businessPartnerSubTypes.push(newItem);
                                } else
                                    businessPartnerSubTypes.push(newItem);
                                isBusinessPartnerSubTypeVisible(false);
                                toastr.success(ist.resourceText.BusinessPartnerSubTypeSuccessfullySavedMessage);
                            },
                            error: function (exceptionMessage, exceptionType) {
                                if (exceptionType === ist.exceptionType.CaresGeneralException)
                                    toastr.error(exceptionMessage);
                                else
                                    toastr.error(ist.resourceText.FailedToSaveBusinessPartnerSubTypeError);
                            }
                        });
                    },
                //validation check 
                    dobeforeBusinessPartnerSubType = function () {
                        if (!selectedBusinessPartnerSubType().isValid()) {
                            selectedBusinessPartnerSubType().errors.showAllMessages();
                            return false;
                        }
                        return true;
                    },
                //cancel button handler
                    onCancelbtn = function () {
                        editorViewModel.revertItem();
                        isBusinessPartnerSubTypeVisible(false);
                    },
                // create new Business Partner Sub Type
                    onCreateForm = function () {
                        var businessPartnerSubType = new model.BusinessPartnerSubTypeDetail();
                        editorViewModel.selectItem(businessPartnerSubType);
                        isBusinessPartnerSubTypeVisible(true);
                    },
                //reset butto handle 
                    resetResuults = function () {
                        searchFilter(undefined);
                        businessPartnerMainTypeFilter(undefined);
                        getBusinessPartnerSubTypes();
                    },
                //delete button handler
                    onDeleteItem = function (item) {
                        if (!item.id()) {
                            businessPartnerSubTypes.remove(item);
                            return;
                        }
                        // Ask for confirmation
                        confirmation.afterProceed(function () {
                            deleteBusinessPartnerSubType(item);
                        });
                        confirmation.show();
                    },
                //edit button handler
                    onEditItem = function (item) {
                        editorViewModel.selectItem(item);
                        isBusinessPartnerSubTypeVisible(true);
                    },
                //Delete Business Partner Sub Type
                    deleteBusinessPartnerSubType = function (businessPartnerSubType) {
                        dataservice.deleteBusinessPartnerSubType(businessPartnerSubType.convertToServerData(), {
                            success: function () {
                                businessPartnerSubTypes.remove(businessPartnerSubType);
                                toastr.success(ist.resourceText.BusinessPartnerSubTypeSuccessfullyDeletedMessage);
                            },
                            error: function (exceptionMessage, exceptionType) {
                                if (exceptionType === ist.exceptionType.CaresGeneralException)
                                    toastr.error(exceptionMessage);
                                else
                                    toastr.error(ist.resourceText.FailedToDeleteBusinessPartnerSubTypeError);
                            }
                        });
                    },
                //search button handler in filter section
                    search = function () {
                        pager().reset();
                        getBusinessPartnerSubTypes();
                    },
                //hide filte section
                    hideFilterSection = function () {
                        filterSectionVisilble(false);
                    },
                //Show filter section
                    showFilterSection = function () {
                        filterSectionVisilble(true);
                    },
                    //Get Business Partner Sub Types list from Dataservice
                    getBusinessPartnerSubTypes = function () {
                        dataservice.getBusinessPartnerSubTypes(
                        {
                            BusinessPartnerSubTypeCodeNameText: searchFilter(),
                            BusinessPartnerMainTypeId: businessPartnerMainTypeFilter(),
                            PageSize: pager().pageSize(),
                            PageNo: pager().currentPage(),
                            SortBy: sortOn(),
                            IsAsc: sortIsAsc()
                        },
                    {
                        success: function (data) {
                            businessPartnerSubTypes.removeAll();
                            pager().totalCount(data.TotalCount);
                            _.each(data.BusinessPartnerSubTypes, function (item) {
                                businessPartnerSubTypes.push(model.businessPartnerSubTypeServertoClinetMapper(item));
                            });
                        },
                        error: function () {
                            isLoadingFleetPools(false);
                            toastr.error(ist.resourceText.FailedToLoadBusinessPartnerSubTypesError);
                        }
                    });
                    },
                     //Get Business Partner Sub Type base data
                    getBaseData = function () {
                        dataservice.getBusinessPartnerSubTypeBaseData(null, {
                            success: function (data) {
                                baseBusinessPartnerMainTypeList.removeAll();
                                ko.utils.arrayPushAll(baseBusinessPartnerMainTypeList(), data.BusinessPartnerMainTypeDropDown);
                                baseBusinessPartnerMainTypeList.valueHasMutated();
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
                    initialize = function (specifiedView) {
                        view = specifiedView;
                        ko.applyBindings(view.viewModel, view.bindingRoot);
                        pager(pagination.Pagination({ PageSize: 10 }, businessPartnerSubTypes, getBusinessPartnerSubTypes));
                        getBaseData();
                        getBusinessPartnerSubTypes();
                    };
                return {
                    businessPartnerSubTypes: businessPartnerSubTypes,
                    initialize: initialize,
                    search: search,
                    searchFilter: searchFilter,
                    sortOn: sortOn,
                    sortIsAsc: sortIsAsc,
                    onCreateForm: onCreateForm,
                    filterSectionVisilble: filterSectionVisilble,
                    isBusinessPartnerSubTypeVisible: isBusinessPartnerSubTypeVisible,
                    hideFilterSection: hideFilterSection,
                    showFilterSection: showFilterSection,
                    pager: pager,
                    resetResuults: resetResuults,
                    onDeleteItem: onDeleteItem,
                    onEditItem: onEditItem,
                    onCancelbtn: onCancelbtn,
                    selectedBusinessPartnerSubType: selectedBusinessPartnerSubType,
                    onSavebtn: onSavebtn,
                    getBusinessPartnerSubTypes: getBusinessPartnerSubTypes,
                    baseBusinessPartnerMainTypeList: baseBusinessPartnerMainTypeList,
                    businessPartnerMainTypeFilter: businessPartnerMainTypeFilter
                };
            })()
        };
        return ist.BusinessPartnerSubType.viewModel;
    });
