/*
    Module with the view model for the Operation
*/
define("workplace/workplace.viewModel",
    ["jquery", "amplify", "ko", "workplace/workplace.dataservice", "workplace/workplace.model",
    "common/confirmation.viewModel", "common/pagination"],
    function($, amplify, ko, dataservice, model, confirmation, pagination) {
        var ist = window.ist || {};
        ist.Operation = {
            viewModel: (function() { 
                var view,
                    //operations list
                    operations = ko.observableArray([]),

                    //departments list for base data
                    baseWorkplaceTypeList = ko.observableArray([]),
                    //Compnies list for base data
                    baseCompniesList = ko.observableArray([]),
                    //Department list for base data
                    baseWorkLocationsList = ko.observableArray([]),

                    //filters
                    workplaceCodeTextFilter = ko.observable(),
                    workplaceNameTextFilter = ko.observable(),
                    companyFilter = ko.observable(),
                    workplaceTypeFilter = ko.observable(),
                    //pager
                    pager = ko.observable(),
                    //sorting
                    sortOn = ko.observable(1),
                    //Assending  / Desending
                    sortIsAsc = ko.observable(true),
                    //to control the visibility of editor sec
                    isOperationEditorVisible = ko.observable(false),
                    //to control the visibility of filter ec
                    filterSectionVisilble = ko.observable(false),
                     // Editor View Model
                    editorViewModel = new ist.ViewModel(model.operation),
                  
                    //selected operation
                    selectedOperation = editorViewModel.itemForEditing,
                    //save button handler
                    onSaveOperation = function () {
                        if (dobeforeOperation())
                        saveOperation(selectedOperation());
                    },
                    //cancel button handler
                    onCancelSaveOperation = function () {
                        editorViewModel.revertItem();
                        isOperationEditorVisible(false);
                    },
                    // create new org group handler
                    onCreateOperationForm = function () {
                        var operation =new model.operation();
                        editorViewModel.selectItem(operation);
                        isOperationEditorVisible(true);
                    },
                    //reset butto handle 
                    onResetResuults = function () {
                        workplaceCodeTextFilter(undefined);
                        workplaceNameTextFilter(undefined);
                        workplaceTypeFilter(undefined);
                        companyFilter(undefined);
                        getOperations();

                    },
                    //delete button handler
                    onDeleteOperation = function (item) {
                        if (!item.id()) {
                            fleetPools.remove(item);
                            return;
                        }
                        // Ask for confirmation
                        confirmation.afterProceed(function () {
                            deleteOperation(item);
                        });
                        confirmation.show();
                    },
                   
                    //edit button handler
                    onEditOperation = function (item) {
                        editorViewModel.selectItem(item);
                        isOperationEditorVisible(true);
                    },
                     //validation check 
                    dobeforeOperation = function () {
                        if (!selectedOperation().isValid()) {
                            selectedOperation().errors.showAllMessages();
                            return false;
                        }
                        return true;
                    },
                    //save operation
                    saveOperation = function (operation) {
                        dataservice.saveWorkplace(operation.convertToServerData(), {
                            success: function (uodatedOperation) {
                                var newItem = model.OperationServertoClientMapper(uodatedOperation);
                                if (selectedOperation().id() != undefined)
                                {
                                    var newObjtodelete = operations.find(function (temp) {
                                        return temp.id() == newItem.id();
                                    });
                                    operations.remove(newObjtodelete);
                                    operations.push(newItem);
                                }
                                else
                                operations.push(newItem);
                                isOperationEditorVisible(false);
                                toastr.success(ist.resourceText.OperationSaveSuccessMessage);
                            },
                            error: function (exceptionMessage, exceptionType) {
                                if (exceptionType === ist.exceptionType.CaresGeneralException)
                                    toastr.error(exceptionMessage);
                                else
                                    toastr.error(ist.resourceText.OperationSaveFailError);
                            }
                        });
                    },
                    //delete operation
                    deleteOperation = function (operation) {
                        dataservice.deleteOperation(operation.convertToServerData(), {
                                success: function() {
                                    operations.remove(operation);
                                    toastr.success(ist.resourceText.OperationDeleteSuccessMessage);
                                },
                                error: function (exceptionMessage, exceptionType) {
                                    if (exceptionType === ist.exceptionType.CaresGeneralException)
                                        toastr.error(exceptionMessage);
                                    else
                                        toastr.error(ist.resourceText.OperationDeleteFailError);
                                }
                            });
                    },
                    //search button handler in filter section
                    onSearch = function() {
                        getOperations();
                    },
                    //hide filte section
                    hideFilterSection = function() {
                        filterSectionVisilble(false);
                    },
                    //Show filter section
                    showFilterSection = function() {
                        filterSectionVisilble(true);
                    },
                    //get operations
                    getOperations = function() {
                        dataservice.getWorkplaces(
                        {
                            WorkplaceCodeText: workplaceCodeTextFilter(),
                            WorkplaceNameText: workplaceNameTextFilter(),
                            WorkplaceTypeId: workplaceTypeFilter(),
                            CompanyId: companyFilter(),
                            PageSize: pager().pageSize(),
                            PageNo: pager().currentPage(),
                            SortBy: sortOn(),
                            IsAsc: sortIsAsc()
                        },
                        {
                            success: function (data) {
                                operations.removeAll();
                                pager().totalCount(data.TotalCount);
                                _.each(data.WorkPlaces, function (item) {
                                    operations.push(model.OperationServertoClientMapper(item));
                                });
                            },
                            error: function() {
                                toastr.error(ist.resourceText.OperationLoadFailError);
                            }
                        });
                    },
                    //get operation base data
                    getOperationBaseData = function () {
                        dataservice.getWorkplaceBaseData(null, {
                            success: function (baseDataFromServer) {
                                baseCompniesList.removeAll();
                                baseWorkplaceTypeList.removeAll();
                                baseWorkLocationsList.removeAll();
                                ko.utils.arrayPushAll(baseCompniesList(), baseDataFromServer.Companies);
                                baseCompniesList.valueHasMutated();
                                ko.utils.arrayPushAll(baseWorkplaceTypeList(), baseDataFromServer.WorkPlaceTypes);
                                baseWorkplaceTypeList.valueHasMutated();
                                ko.utils.arrayPushAll(baseWorkLocationsList(), baseDataFromServer.WorkLocations);
                                baseWorkLocationsList.valueHasMutated();
                            },
                            error: function (exceptionMessage, exceptionType) {
                                if (exceptionType === ist.exceptionType.CaresGeneralException) {
                                    toastr.error(exceptionMessage);
                                } else {
                                    toastr.error(ist.resourceText.OperationBaseLoadFailError);
                                }
                            }
                        });
                    },
                    // Initialize the view model
                    initialize = function (specifiedView) {
                        view = specifiedView;
                        ko.applyBindings(view.viewModel, view.bindingRoot);
                        pager(pagination.Pagination({ PageSize: 5}, operations, getOperations));
                        getOperationBaseData();
                        getOperations();
                       
                    };
                return {
                    workplaceCodeTextFilter: workplaceCodeTextFilter,
                    workplaceNameTextFilter: workplaceNameTextFilter,
                    workplaceTypeFilter: workplaceTypeFilter,
                    companyFilter: companyFilter,
                    baseCompniesList:baseCompniesList,
                    baseWorkplaceTypeList: baseWorkplaceTypeList,
                    baseWorkLocationsList:baseWorkLocationsList,
                    isOperationEditorVisible:isOperationEditorVisible,
                    initialize: initialize,
                    onCreateOperationForm:onCreateOperationForm,
                    sortOn: sortOn,
                    getOperations:getOperations,
                    sortIsAsc: sortIsAsc,
                    filterSectionVisilble: filterSectionVisilble,
                    hideFilterSection: hideFilterSection,
                    showFilterSection: showFilterSection,
                    pager: pager,
                    selectedOperation:selectedOperation,
                    onResetResuults: onResetResuults,
                    onEditOperation:onEditOperation,
                    onDeleteOperation:onDeleteOperation,
                    onSaveOperation: onSaveOperation,
                    onSearch: onSearch,
                    operations:operations,
                    onCancelSaveOperation: onCancelSaveOperation
                };
            })()
        };
        return ist.Operation.viewModel;
    });
