/*
    Module with the view model for the Operation
*/
define("workplace/workplace.viewModel",
    ["jquery", "amplify", "ko", "workplace/workplace.dataservice", "workplace/workplace.model",
    "common/confirmation.viewModel", "common/pagination"],
    function($, amplify, ko, dataservice, model, confirmation, pagination) {
        var ist = window.ist || {};
        ist.WorkPlace = {
            viewModel: (function() {
                var view,
                    //workplaces list
                    workplaces = ko.observableArray([]),
                    //parent workplace list in base data
                    parentWorkPlaceList = ko.observableArray([]),
                    // filtered parent WP in editor
                    filteredParentWorkPlaceList = ko.observableArray([]),
                    // workplace operations list shows in editor
                    operationsTabList = ko.observableArray([]),
                    baseOperationsList = ko.observableArray([]),
                    // base operations list
                    baseFleetPoolList = ko.observableArray([]),
                    //departments list for base data
                    baseWorkplaceTypeList = ko.observableArray([]),
                    //Compnies list for base data
                    baseCompniesList = ko.observableArray([]),
                    //WorkLocations list for base data
                    baseWorkLocationsList = ko.observableArray([]),

                    //filters
                    workplaceCodeTextFilter = ko.observable(),
                    workplaceNameTextFilter = ko.observable(),
                    companyFilter = ko.observable(),
                    workplaceTypeFilter = ko.observable(),
                    operationString = ko.observable(),
                    fleelPoolString = ko.observable(),

                    //pager
                    pager = ko.observable(),
                    //sorting
                    sortOn = ko.observable(1),
                    //Assending  / Desending
                    sortIsAsc = ko.observable(true),
                    //to control the visibility of editor sec
                    isWorkPlaceEditorVisible = ko.observable(false),
                    //to control the visibility of filter ec
                    filterSectionVisilble = ko.observable(false),
                    //selected tab
                    selectedWorkPlace = ko.observable(),
                    // Editor View Model
                    editorViewModel = new ist.ViewModel(model.workPlace),

                //save button handler
                onSaveWorkPlace = function () {
                    debugger;
                        if (dobeforeworkplace())
                            saveWorkplace(selectedWorkPlace());
                    },
                //cancel button handler
                onCancelSaveWorkPlace = function() {
                        //    editorViewModel.revertItem();
                        isWorkPlaceEditorVisible(false);
                    },
                // create new org group handler
                onCreateWorkPlaceForm = function() {
                        //  var operation =new model.operation();
                        //   editorViewModel.selectItem(operation);
                        operationsTabList.removeAll();
                        var workPlace = new model.workPlace();
                        // Select the newly added Hire Group
                        selectedWorkPlace(workPlace);
                        selectedWorkPlace().tabDetail(new model.operationWorkplace());
//                        selectedTab().tabDetail().parentWorkPlaceId('undefined');
                        filteredParentWorkPlaceList(_.filter(parentWorkPlaceList(), function(workplace) {
                            return workplace;
                        }));

                        isWorkPlaceEditorVisible(true);
                    },
                //reset butto handle 
                onResetResuults = function() {
                        workplaceCodeTextFilter(undefined);
                        workplaceNameTextFilter(undefined);
                        workplaceTypeFilter(undefined);
                        companyFilter(undefined);
                        getWorkPlaces();
                    },
                 //delete button handler
                onDeleteWorkplace = function(item) {
                        if (!item.id()) {
                            fleetPools.remove(item);
                            return;
                        }
                        // Ask for confirmation
                        confirmation.afterProceed(function() {
                            deleteWorkPlace(item);
                        });
                        confirmation.show();
                    },
                //edit button handler
                onEditworkplace = function(item) {
                        operationsTabList.removeAll();

                        filteredParentWorkPlaceList(_.filter(parentWorkPlaceList(), function(workplace) {
                            return workplace.WorkPlaceId !== item.id();
                        }));
                        getWorkplaceOperations(item.id());
                        selectedWorkPlace(item);
                        selectedWorkPlace().tabDetail(new model.operationWorkplace());
                        selectedWorkPlace().tabDetail().parentWorkPlaceId(item.id());
                        isWorkPlaceEditorVisible(true);
                    },
                //validation check 
                dobeforeworkplace = function() {
                        if (!selectedWorkPlace().isValid()) {
                            selectedWorkPlace().errors.showAllMessages();
                            return false;
                        }
                        return true;
                    },
                //add operation worklplace  handler
                onAddOperation = function(operationDetail) {
                        var selectedFleetPoolname = baseFleetPoolList.find(function(temp) {
                            if (temp.FleetPoold == fleelPoolString())
                                return temp.FleetPoolCodeName;
                            else return "";
                        });
                        var selectedOperationname = baseOperationsList.find(function(temp) {
                            if (temp.OperationId == operationString())
                                return temp.OperationCodeName;
                            else return "";
                        });
                        operationDetail.fleelPoolName(selectedFleetPoolname.FleetPoolCodeName);
                        operationDetail.fleelPoolId(fleelPoolString());
                        operationDetail.operationName(selectedOperationname.OperationCodeName);
                        operationDetail.operationId(operationString());
                        operationsTabList.push(operationDetail);
                        fleelPoolString(undefined);
                        operationString(undefined);
                        selectedWorkPlace().tabDetail(new model.operationWorkplace());
                    },
                //delete operation worklplace
                deleteOperationDetail = function(item) {
                    operationsTabList.remove(item);
                },
                //save Workplace
                saveWorkplace = function (operation) {
                    dataservice.saveWorkplace(workPalceClientToServerMapper(operation), {
                        success: function (uodatedOperation) {
                            debugger;
                            var newItem = model.OperationServertoClientMapper(uodatedOperation);
                            if (selectedWorkPlace().id() != undefined) {
                                var newObjtodelete = workplaces.find(function(temp) {
                                    return temp.id() == newItem.id();
                                });
                                workplaces.remove(newObjtodelete);
                                workplaces.push(newItem);
                            } else
                                workplaces.push(newItem);
                            updateParentWorkplaces();
                            isWorkPlaceEditorVisible(false);
                            toastr.success(ist.resourceText.WorkPlaceSaveSuccessMessage);
                        },
                        error: function(exceptionMessage, exceptionType) {
                            if (exceptionType === ist.exceptionType.CaresGeneralException)
                                toastr.error(exceptionMessage);
                            else
                                toastr.error(ist.resourceText.WorkPlaceSaveFailError);
                        }
                    });
                },
                //update Parent Workplaces
                updateParentWorkplaces = function() {
                    dataservice.updateParentWorkplace("update", {
                        success: function(data) {
                            getWorkPlaceBaseData();
                            workplaces.removeAll();
                            _.each(data.WorkPlaces, function(item) {
                                workplaces.push(model.OperationServertoClientMapper(item));
                            });
                        },
                        error: function() {
                            toastr.error(ist.resourceText.OperationLoadFailError);
                        }
                    });
                },
                //delete WorkPlace
                deleteWorkPlace = function(operation) {
                        dataservice.deleteWorkplace(operation.convertToServerData(), {
                            success: function() {
                                workplaces.remove(operation);
                                getWorkPlaceBaseData();
                                toastr.success(ist.resourceText.WorkPlaceDeleteSuccessMessage);
                            },
                            error: function(exceptionMessage, exceptionType) {
                                if (exceptionType === ist.exceptionType.CaresGeneralException)
                                    toastr.error(exceptionMessage);
                                else
                                    toastr.error(ist.resourceText.WorkPlaceDeleteFailError);
                            }
                        });
                    },
                //search button handler in filter section
                onSearch = function() {
                        getWorkPlaces();
                    },
                //hide filte section
                hideFilterSection = function() {
                        filterSectionVisilble(false);
                    },
                //Show filter section
                showFilterSection = function() {
                        filterSectionVisilble(true);
                    },
                //get WorkPlaces
                getWorkPlaces = function() {
                    dataservice.getWorkplaces({
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
                        success: function(data) {
                            workplaces.removeAll();
                            pager().totalCount(data.TotalCount);
                            _.each(data.WorkPlaces, function(item) {
                                workplaces.push(model.OperationServertoClientMapper(item));
                            });
                        },
                        error: function() {
                            toastr.error(ist.resourceText.WorkPlaceLoadFailError);
                        }
                    });
                },
                //get WorkPlace base data
                getWorkPlaceBaseData = function() {
                    dataservice.getWorkplaceBaseData(null, {
                        success: function(baseDataFromServer) {
                            poulateBaseData(baseDataFromServer); 
                        },
                        error: function(exceptionMessage, exceptionType) {
                            if (exceptionType === ist.exceptionType.CaresGeneralException) {
                                toastr.error(exceptionMessage);
                            } else {
                                toastr.error(ist.resourceText.WorkPlaceLoadBaseFailError);
                            }
                        }
                    });
                    },
                //set the base data 
                poulateBaseData = function (baseDataFromServer) {
                    baseCompniesList.removeAll();
                    baseWorkplaceTypeList.removeAll();
                    baseWorkLocationsList.removeAll();
                    baseFleetPoolList.removeAll();
                    baseOperationsList.removeAll();
                    parentWorkPlaceList.removeAll();
                    ko.utils.arrayPushAll(parentWorkPlaceList(), baseDataFromServer.ParentWorkPlaces);
                    parentWorkPlaceList.valueHasMutated();
                    ko.utils.arrayPushAll(baseCompniesList(), baseDataFromServer.Companies);
                    baseCompniesList.valueHasMutated();
                    ko.utils.arrayPushAll(baseWorkplaceTypeList(), baseDataFromServer.WorkPlaceTypes);
                    baseWorkplaceTypeList.valueHasMutated();
                    ko.utils.arrayPushAll(baseWorkLocationsList(), baseDataFromServer.WorkLocations);
                    baseWorkLocationsList.valueHasMutated();
                    ko.utils.arrayPushAll(baseFleetPoolList(), baseDataFromServer.FleetPools);
                    baseFleetPoolList.valueHasMutated();
                    ko.utils.arrayPushAll(baseOperationsList(), baseDataFromServer.Operations);
                    baseOperationsList.valueHasMutated();
                },
                workPalceClientToServerMapper = function (operation) {
                        _.each(operationsTabList(), function(item) {
                            var v = item.convertToServerData();
                            operation.OperationsWorkPlaces.push(v);
                        });
                        return operation.convertToServerData();
                },
                getWorkplaceOperations = function(workPlaceId) {
                    dataservice.getWorkplaceOperations(
                    {
                        WorkPlaceId: workPlaceId
                    },
                    {
                        success: function(data) {
                            operationsTabList.removeAll();
                            _.each(data.OperationWorkPlaces, function(item) {
                                var v = model.operationWorkplaceServertoClientMapper(item);
                                operationsTabList.push(v);
                            });
                        },
                        error: function() {
                            toastr.error(ist.resourceText.OperationLoadFailError);
                        }
                    });
                },
                // Initialize the view model
                initialize = function(specifiedView) {
                        view = specifiedView;
                        ko.applyBindings(view.viewModel, view.bindingRoot);
                        pager(pagination.Pagination({ PageSize: 5 }, workplaces, getWorkPlaces));
                        getWorkPlaceBaseData();
                        getWorkPlaces();
                    };
                return {
                    workplaceCodeTextFilter: workplaceCodeTextFilter,
                    workplaceNameTextFilter: workplaceNameTextFilter,
                    workplaceTypeFilter: workplaceTypeFilter,
                    companyFilter: companyFilter,
                    baseCompniesList: baseCompniesList,
                    baseWorkplaceTypeList: baseWorkplaceTypeList,
                    baseWorkLocationsList: baseWorkLocationsList,
                    isWorkPlaceEditorVisible: isWorkPlaceEditorVisible,
                    initialize: initialize,
                    onCreateWorkPlaceForm: onCreateWorkPlaceForm,
                    sortOn: sortOn,
                    getWorkPlaces: getWorkPlaces,
                    baseOperationsList: baseOperationsList,
                    sortIsAsc: sortIsAsc,
                    filterSectionVisilble: filterSectionVisilble,
                    hideFilterSection: hideFilterSection,
                    showFilterSection: showFilterSection,
                    pager: pager,
                    baseFleetPoolList: baseFleetPoolList,
                    onResetResuults: onResetResuults,
                    onEditworkplace: onEditworkplace,
                    onDeleteWorkplace: onDeleteWorkplace,
                    onSaveWorkPlace: onSaveWorkPlace,
                    onSearch: onSearch,
                    workplaces: workplaces,
                    onCancelSaveWorkPlace: onCancelSaveWorkPlace,
                    operationsTabList: operationsTabList,
                    onAddOperation: onAddOperation,
                    selectedWorkPlace: selectedWorkPlace,
                    operationString: operationString,
                    fleelPoolString: fleelPoolString,
                    deleteOperationDetail: deleteOperationDetail,
                    parentWorkPlaceList: parentWorkPlaceList,
                    filteredParentWorkPlaceList: filteredParentWorkPlaceList
                };
            })()
        };
        return ist.WorkPlace.viewModel;
    });
