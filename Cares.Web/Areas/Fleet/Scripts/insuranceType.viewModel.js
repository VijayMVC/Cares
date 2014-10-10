/*
    Module with the view model for the Insurance Type 
*/
define("insuranceType/insuranceType.viewModel",
    ["jquery", "amplify", "ko", "insuranceType/insuranceType.dataservice", "insuranceType/insuranceType.model",
    "common/confirmation.viewModel", "common/pagination"],
    function($, amplify, ko, dataservice, model, confirmation, pagination) {
        var ist = window.ist || {};
        ist.InsuranceType = {
            viewModel: (function() { 
                var view,
                    //array to save Insurance Types
                    insuranceTypes = ko.observableArray([]),
                    //pager%
                    pager = ko.observable(),
                    //org code filter in filter sec
                    searchFilter = ko.observable(),
                    //sorting
                    sortOn = ko.observable(1),
                    //Assending  / Desending
                    sortIsAsc = ko.observable(true),
                    //to control the visibility of editor sec
                    isInsuranceTypeEditorVisible = ko.observable(false),
                    //to control the visibility of filter ec
                    filterSectionVisilble = ko.observable(false),
                     // Editor View Model
                    editorViewModel = new ist.ViewModel(model.InsuranceTypeDetail),
                    // Selected Insurance Type
                    selectedInsuranceType = editorViewModel.itemForEditing,
                    //save button handler
                    onSavebtn = function() {
                    if (dobeforeInsuranceType())
                        saveInsuranceType(selectedInsuranceType());
                },
                //Save Insurance Types
                    saveInsuranceType = function (item) {
                        dataservice.saveInsuranceType(item.convertToServerData(), {
                        success: function(dataFromServer) {
                            var newItem = model.insuranceTypeServertoClinetMapper(dataFromServer);
                            if (item.id() !== undefined) {
                                var newObjtodelete = insuranceTypes.find(function(temp) {
                                    return temp.id() == newItem.id();
                                });
                                insuranceTypes.remove(newObjtodelete);
                                insuranceTypes.push(newItem);
                            } else
                                insuranceTypes.push(newItem);
                            isInsuranceTypeEditorVisible(false);
                            toastr.success(ist.resourceText.InsuranceTypeSuccessfullySavedMessage);
                        },
                        error: function(exceptionMessage, exceptionType) {
                            if (exceptionType === ist.exceptionType.CaresGeneralException)
                                toastr.error(exceptionMessage);
                            else
                                toastr.error(ist.resourceText.FailedToSaveInsuranceTypeError);
                        }
                    });
                },
                //validation check 
                    dobeforeInsuranceType = function () {
                    if (!selectedInsuranceType().isValid()) {
                        selectedInsuranceType().errors.showAllMessages();
                        return false;
                    }
                    return true;
                },
                //cancel button handler
                    onCancelbtn = function() {
                    editorViewModel.revertItem();
                    isInsuranceTypeEditorVisible(false);
                },
                // create new Insurance Type
                    onCreateForm = function() {
                    var insuranceTypeDetail = new model.InsuranceTypeDetail();
                    editorViewModel.selectItem(insuranceTypeDetail);
                    isInsuranceTypeEditorVisible(true);
                },
                //reset butto handle 
                    resetResuults = function() {
                    searchFilter(undefined);
                    getInsuranceTypes();
                },
                //delete button handler
                    onDeleteItem = function(item) {
                    if (!item.id()) {
                        insuranceTypes.remove(item);
                        return;
                    }
                    // Ask for confirmation
                    confirmation.afterProceed(function() {
                        deleteInsuranceType(item);
                    });
                    confirmation.show();
                },
                //edit button handler
                    onEditItem = function(item) {
                    editorViewModel.selectItem(item);
                    isInsuranceTypeEditorVisible(true);
                },
                //Delete Insurance Type
                    deleteInsuranceType = function (insuranceType) {
                        dataservice.deleteInsuranceType(insuranceType.convertToServerData(), {
                        success: function() {
                            insuranceTypes.remove(insuranceType);
                            toastr.success(ist.resourceText.InsuranceTypeSuccessfullyDeletedMessage);
                        },
                        error: function(exceptionMessage, exceptionType) {
                            if (exceptionType === ist.exceptionType.CaresGeneralException)
                                toastr.error(exceptionMessage);
                            else
                                toastr.error(ist.resourceText.FailedToDeleteInsuranceTypeError);
                        }
                    });
                },
                //search button handler in filter section
                    search = function() {
                    pager().reset();
                    getInsuranceTypes();
                },
                //hide filte section
                    hideFilterSection = function() {
                    filterSectionVisilble(false);
                },
                //Show filter section
                    showFilterSection = function() {
                        filterSectionVisilble(true);
                    },
                    //Get Insurance Types list from Dataservice
                    getInsuranceTypes = function() {
                        dataservice.getInsuranceTypes(
                        {
                            InsuranceTypeCodeNameText: searchFilter(),
                            PageSize: pager().pageSize(),
                            PageNo: pager().currentPage(),
                            SortBy: sortOn(),
                            IsAsc: sortIsAsc()
                    },
                    {
                        success: function (data) {
                            insuranceTypes.removeAll();
                            pager().totalCount(data.TotalCount);
                            _.each(data.InsuranceTypes, function (item) {
                                insuranceTypes.push(model.insuranceTypeServertoClinetMapper(item));
                            });
                        },
                        error: function() {
                            isLoadingFleetPools(false);
                            toastr.error(ist.resourceText.FailedToLoadInsuranceTypesError);
                        }
                    });
                    },
                   
                // Initialize the view model
                    initialize = function (specifiedView) {

                        view = specifiedView;
                        ko.applyBindings(view.viewModel, view.bindingRoot);
                        pager(pagination.Pagination({ PageSize: 5 }, insuranceTypes, getInsuranceTypes));
                        getInsuranceTypes();
                    };
                return {
                    insuranceTypes: insuranceTypes,
                    initialize: initialize,
                    search: search,
                    searchFilter: searchFilter,
                    sortOn: sortOn,
                    sortIsAsc: sortIsAsc,
                    onCreateForm: onCreateForm,
                    filterSectionVisilble: filterSectionVisilble,
                    isInsuranceTypeEditorVisible: isInsuranceTypeEditorVisible,
                    hideFilterSection: hideFilterSection,
                    showFilterSection: showFilterSection,
                    pager: pager,
                    resetResuults: resetResuults,
                    onDeleteItem: onDeleteItem,
                    onEditItem: onEditItem,
                    onCancelbtn: onCancelbtn,
                    selectedInsuranceType: selectedInsuranceType,
                    onSavebtn: onSavebtn,
                    getInsuranceTypes: getInsuranceTypes
                };
            })()
        };
        return ist.InsuranceType.viewModel;
    });
