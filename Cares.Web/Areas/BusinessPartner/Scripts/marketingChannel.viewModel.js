/*
    Module with the view model for the Marketing Channel
*/
define("marketingChannel/marketingChannel.viewModel",
    ["jquery", "amplify", "ko", "marketingChannel/marketingChannel.dataservice", "marketingChannel/marketingChannel.model",
    "common/confirmation.viewModel", "common/pagination"],
    function($, amplify, ko, dataservice, model, confirmation, pagination) {
        var ist = window.ist || {};
        ist.MarketingChannel = {
            viewModel: (function() { 
                var view,
                    //array to save Marketing Channels
                    marketingChannels = ko.observableArray([]),
                    //pager%
                    pager = ko.observable(),
                    //org code filter in filter sec
                    searchFilter = ko.observable(),
                    //sorting
                    sortOn = ko.observable(1),
                    //Assending  / Desending
                    sortIsAsc = ko.observable(true),
                    //to control the visibility of editor sec
                    isMarketingChannelEditorVisible = ko.observable(false),
                    //to control the visibility of filter ec
                    filterSectionVisilble = ko.observable(false),
                     // Editor View Model
                    editorViewModel = new ist.ViewModel(model.MarketingChannelGroupDetail),
                    // Selected Marketing Channel
                    selectedMarketingChannel = editorViewModel.itemForEditing,
                    //save button handler
                    onSavebtn = function() {
                        if (dobeforeMarketingChannel())
                            saveMarketingChannel(selectedMarketingChannel());
                },
                //Save Marketing Channel
                    saveMarketingChannel = function (item) {
                        dataservice.saveMarketingChannel(item.convertToServerData(), {
                        success: function(dataFromServer) {
                            var newItem = model.marketingChannelServertoClinetMapper(dataFromServer);
                            if (item.id() !== undefined) {
                                var newObjtodelete = marketingChannels.find(function(temp) {
                                    return temp.id() == newItem.id();
                                });
                                marketingChannels.remove(newObjtodelete);
                                marketingChannels.push(newItem);
                            } else
                                marketingChannels.push(newItem);
                            isMarketingChannelEditorVisible(false);
                            toastr.success(ist.resourceText.MarketingChannelSuccessfullySavedMessage);
                        },
                        error: function(exceptionMessage, exceptionType) {
                            if (exceptionType === ist.exceptionType.CaresGeneralException)
                                toastr.error(exceptionMessage);
                            else
                                toastr.error(ist.resourceText.FailedToSaveMarketingChannelError);
                        }
                    });
                },
                //validation check 
                    dobeforeMarketingChannel = function () {
                    if (!selectedMarketingChannel().isValid()) {
                        selectedMarketingChannel().errors.showAllMessages();
                        return false;
                    }
                    return true;
                },
                //cancel button handler
                    onCancelbtn = function() {
                    editorViewModel.revertItem();
                    isMarketingChannelEditorVisible(false);
                },
                // create new Marketing Channel
                    onCreateForm = function () {
                    var marketingChannel = new model.MarketingChannelGroupDetail();
                    editorViewModel.selectItem(marketingChannel);
                    isMarketingChannelEditorVisible(true);
                },
                //reset butto handle 
                    resetResuults = function() {
                    searchFilter(undefined);
                    getMarketingChannels();
                },
                //delete button handler
                    onDeleteItem = function(item) {
                    if (!item.id()) {
                        marketingChannels.remove(item);
                        return;
                    }
                    // Ask for confirmation
                    confirmation.afterProceed(function() {
                        deleteMarketingChannel(item);
                    });
                    confirmation.show();
                },
                //edit button handler
                    onEditItem = function(item) {
                    editorViewModel.selectItem(item);
                    isMarketingChannelEditorVisible(true);
                },
                //delete Marketing Channel
                    deleteMarketingChannel = function (marketingChannel) {
                        dataservice.deleteMarketingChannel(marketingChannel.convertToServerData(), {
                        success: function() {
                            marketingChannels.remove(marketingChannel);
                            toastr.success(ist.resourceText.MarketingChannelSuccessfullyDeletedMessage);
                        },
                        error: function(exceptionMessage, exceptionType) {
                            if (exceptionType === ist.exceptionType.CaresGeneralException)
                                toastr.error(exceptionMessage);
                            else
                                toastr.error(ist.resourceText.FailedToDeleteMarketingChannelError);
                        }
                    });
                },
                //search button handler in filter section
                    search = function() {
                    pager().reset();
                    getMarketingChannels();
                },
                //hide filte section
                    hideFilterSection = function() {
                    filterSectionVisilble(false);
                },
                //Show filter section
                    showFilterSection = function() {
                        filterSectionVisilble(true);
                    },
                    //get Marketing Channels list from Dataservice
                    getMarketingChannels = function () {
                        dataservice.getMarketingChannels(
                        {
                            MarketingChannelFilterText: searchFilter(),
                            PageSize: pager().pageSize(),
                            PageNo: pager().currentPage(),
                            SortBy: sortOn(),
                            IsAsc: sortIsAsc()
                    },
                    {
                        success: function (data) {
                            marketingChannels.removeAll();
                            pager().totalCount(data.TotalCount);
                            _.each(data.MarketingChannels, function (item) {
                                marketingChannels.push(model.marketingChannelServertoClinetMapper(item));
                            });
                        },
                        error: function() {
                            isLoadingFleetPools(false);
                            toastr.error(ist.resourceText.FailedToLoadMarketingChannelsError);
                        }
                    });
                    },
                    
                // Initialize the view model
                    initialize = function(specifiedView) {
                        view = specifiedView;
                        ko.applyBindings(view.viewModel, view.bindingRoot);
                        pager(pagination.Pagination({ PageSize: 10 }, marketingChannels, getMarketingChannels));
                        getMarketingChannels();
                    };
                return {
                    marketingChannels: marketingChannels,
                    initialize: initialize,
                    search: search,
                    searchFilter: searchFilter,
                    sortOn: sortOn,
                    sortIsAsc: sortIsAsc,
                    onCreateForm: onCreateForm,
                    filterSectionVisilble: filterSectionVisilble,
                    isMarketingChannelEditorVisible: isMarketingChannelEditorVisible,
                    hideFilterSection: hideFilterSection,
                    showFilterSection: showFilterSection,
                    pager: pager,
                    resetResuults: resetResuults,
                    onDeleteItem: onDeleteItem,
                    onEditItem: onEditItem,
                    onCancelbtn: onCancelbtn,
                    selectedMarketingChannel: selectedMarketingChannel,
                    onSavebtn: onSavebtn,
                    getMarketingChannels: getMarketingChannels,
                };
            })()
        };
        return ist.MarketingChannel.viewModel;
    });
