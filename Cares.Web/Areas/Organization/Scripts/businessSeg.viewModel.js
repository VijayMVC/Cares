/*
    Module with the view model for the Business Segment
*/
define("businessSeg/businessSeg.viewModel",
    ["jquery", "amplify", "ko", "businessSeg/businessSeg.dataservice", "businessSeg/businessSeg.model",
    "common/confirmation.viewModel", "common/pagination"],
    function($, amplify, ko, dataservice, model, confirmation, pagination) {
        var ist = window.ist || {};
        ist.BusinessSegment = {
            viewModel: (function() { 
                var view,
                    //array to save org groups
                    businessSegments = ko.observableArray([]),
                    //pager%
                    pager = ko.observable(),
                    //org code filter in filter sec
                    searchFilter = ko.observable(),
        
                    //sorting
                    sortOn = ko.observable(1),
                    //Assending  / Desending
                    sortIsAsc = ko.observable(true),
                    //to control the visibility of editor sec
                    isBusinessSegmentEditorVisible = ko.observable(false),
                    //to control the visibility of filter ec
                    filterSectionVisilble = ko.observable(false),


                     // Editor View Model
                    editorViewModel = new ist.ViewModel(model.businessSegmentDetail),
                    // Selected Business Segment
                    selectedBusinessSegment = editorViewModel.itemForEditing,

                    //save button handler
                    onSavebtn = function() {
                    if (dobeforeBusinessSegment())
                        saveBusinessSegment(selectedBusinessSegment());
                },
                //Save Business Segment
                    saveBusinessSegment = function(item) {
                      dataservice.saveBusinessSegment(item.convertToServerData(), {
                        success: function(dataFromServer) {
                            var newItem = model.businessSegmentServertoClinetMapper(dataFromServer);
                            if (item.id() !== undefined) {
                                var newObjtodelete = businessSegments.find(function(temp) {
                                    return temp.id() == newItem.id();
                                });
                                businessSegments.remove(newObjtodelete);
                                businessSegments.push(newItem);
                            } else
                                businessSegments.push(newItem);
                            isBusinessSegmentEditorVisible(false);
                            toastr.success(ist.resourceText.BusinessSegmentSaveSuccessMessage);
                        },
                        error: function(exceptionMessage, exceptionType) {
                            if (exceptionType === ist.exceptionType.CaresGeneralException)
                                toastr.error(exceptionMessage);
                            else
                                toastr.error(ist.resourceText.BusinessSegmentSaveFailError);
                        }
                    });
                },
                //validation check 
                    dobeforeBusinessSegment = function() {
                    if (!selectedBusinessSegment().isValid()) {
                        selectedBusinessSegment().errors.showAllMessages();
                        return false;
                    }
                    return true;
                },
                //cancel button handler
                    onCancelbtn = function() {
                    editorViewModel.revertItem();
                    isBusinessSegmentEditorVisible(false);
                },
                // create new Business Segment
                    onCreateForm = function() {
                    var businessSegment = new model.businessSegmentDetail();
                    editorViewModel.selectItem(businessSegment);
                    isBusinessSegmentEditorVisible(true);
                },
                //reset butto handle 
                    resetResuults = function() {
                    searchFilter(undefined);
                    getBusinessSegment();
                },
                //delete button handler
                    onDeletItem = function(item) {
                    if (!item.id()) {
                        businessSegments.remove(item);
                        return;
                    }
                    // Ask for confirmation
                    confirmation.afterProceed(function() {
                        deleteBusinessSeg(item);
                    });
                    confirmation.show();
                },
                //edit button handler
                    onEditItem = function(item) {
                    editorViewModel.selectItem(item);
                    isBusinessSegmentEditorVisible(true);
                },
                //delete Business Segment
                    deleteBusinessSeg = function(businessSeg) {
                       dataservice.deleteBusinessSegment(businessSeg.convertToServerData(), {
                        success: function() {
                            businessSegments.remove(businessSeg);
                            toastr.success(ist.resourceText.BusinessSegmentDeleteSuccessMessage);
                        },
                        error: function(exceptionMessage, exceptionType) {
                            if (exceptionType === ist.exceptionType.CaresGeneralException)
                                toastr.error(exceptionMessage);
                            else
                                toastr.error(ist.resourceText.BusinessSegmentDeleteFailError);
                        }
                    });
                },
                //search button handler in filter section
                    search = function() {
                    pager().reset();
                    getBusinessSegment();
                },
                //hide filte section
                    hideFilterSection = function() {
                    filterSectionVisilble(false);
                },
                //Show filter section
                    showFilterSection = function() {
                        filterSectionVisilble(true);
                    },
                    //get workplace list from Dataservice
                    getBusinessSegment = function() {
                    dataservice.getBusinessSeg(
                    {
                        BusinessSegmentFilterText: searchFilter(),
                        PageSize: pager().pageSize(),
                        PageNo: pager().currentPage(),
                        SortBy: sortOn(),
                        IsAsc: sortIsAsc()
                    },
                    {
                        success: function(data) {
                            businessSegments.removeAll();
                            pager().totalCount(data.TotalCount);
                            _.each(data.BusinessSegments, function(item) {
                                businessSegments.push(model.businessSegmentServertoClinetMapper(item));
                            });
                        },
                        error: function() {
                            isLoadingFleetPools(false);
                            toastr.error(ist.resourceText.BusinessSegmentLoadFailError);
                        }
                    });
                },
                // Initialize the view model
                    initialize = function(specifiedView) {
                        view = specifiedView;
                        ko.applyBindings(view.viewModel, view.bindingRoot);
                        pager(pagination.Pagination({ PageSize: 10 }, businessSegments, getBusinessSegment));
                        getBusinessSegment();
                    };
                return {
                    businessSegments: businessSegments,
                    initialize: initialize,
                    search: search,
                    searchFilter: searchFilter,
                    sortOn: sortOn,
                    sortIsAsc: sortIsAsc,
                    onCreateForm: onCreateForm,
                    filterSectionVisilble: filterSectionVisilble,
                    isBusinessSegmentEditorVisible: isBusinessSegmentEditorVisible,
                    hideFilterSection: hideFilterSection,
                    showFilterSection: showFilterSection,
                    pager: pager,
                    resetResuults: resetResuults,
                    onDeletItem: onDeletItem,
                    onEditItem: onEditItem,
                    onCancelbtn: onCancelbtn,
                    selectedBusinessSegment: selectedBusinessSegment,
                    onSavebtn: onSavebtn,
                    getBusinessSegment: getBusinessSegment,

                };
            })()
        };
        return ist.BusinessSegment.viewModel;
    });
