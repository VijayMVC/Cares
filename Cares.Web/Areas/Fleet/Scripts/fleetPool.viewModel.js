/*
    Module with the view model for the Item
*/
define("Fleet/fleetPool.viewModel",
    ["jquery", "amplify", "ko", "Fleet/fleetPool.dataservice", "Fleet/fleetPoolWithKoMapping.model", "common/confirmation.viewModel", "common/pagination"],
    function ($, amplify, ko, dataservice, model, confirmation, pagination) {

        var ist = window.ist || {};
        ist.fleetPool = {
            viewModel: (function () {
                var// the view 
                    view,
                    // Active Item
                    selectedItem = ko.observable(),
                    // #region Arrays
                    // fleetPools
                    fleetPools = ko.observableArray([]),
                    // #endregion Arrays
                    // #region Busy Indicators
                    isLoadingData = ko.observable(false),
                    // #endregion Busy Indicators
                    // #region Observables
                    // Sort On
                    sortOn = ko.observable(1),
                    // Sort Order -  true means asc, false means desc
                    sortIsAsc = ko.observable(true),
                    // Is Editable
                    isEditable = ko.observable(false),
                    // Pagination
                    pager = ko.observable(),
                    // fleetPool Code
                    fpCode = ko.observable(),
                    // fleetPool Name
                    fpName = ko.observable(),
                    // fleetPool Country
                    fpCountry = ko.observable(),
                    // fleetPool Region
                    fpRegion = ko.observable(),
                    // fleetPool Company
                    fpCompany = ko.observable(),
                    // fleetPool Department
                    fpDepartment = ko.observable(),
                    // fleetPool Operation
                    fpOperation = ko.observable(),
                    
                    // #region Utility Functions
                    // Select a fleetPool
                    selectItem = function (item) {
                        if (selectedItem() && selectedItem().hasChanges()) {
                            onSaveItem(item);
                            return;
                        }
                        if (selectedItem() !== item) {
                            selectedItem(item);
                        }
                        isEditable(false);
                    },
                    // Edit a Item
                    onEditItemInline = function (item, e) {
                        selectItem(item);
                        isEditable(true);
                        e.stopImmediatePropagation();
                    },
                    // Edit a Item - In a Form
                    onEditItem = function (item, e) {
                        selectItem(item);
                        showItemEditor();
                        e.stopImmediatePropagation();
                    },
                    // Show Item Editor
                    showItemEditor = function () {
                        isItemEditorVisible(true);
                    },
                    // close Item Editor
                    onCloseItemEditor = function () {
                        if (selectedItem().hasChanges()) {
                            confirmation.messageText("Do you want to save changes?");
                            confirmation.afterProceed(onSaveItem);
                            confirmation.afterCancel(function () {
                                selectedItem().reset();
                                closeItemEditor();
                            });
                            confirmation.show();
                            return;
                        }
                        closeItemEditor();
                    },
                    // close Item Editor
                    closeItemEditor = function () {
                        isItemEditorVisible(false);
                    },
                    // Delete a item
                    onDeleteItem = function (item) {
                        if (!item.id()) {
                            items.remove(item);
                            return;
                        }

                        // Ask for confirmation
                        confirmation.afterProceed(function () {
                            deleteItem(item);
                        });
                        confirmation.show();
                    },
                    // Create Item
                    createItem = function () {
                        var item = new model.Item({ Name: "", CategoryId: undefined, Price: "", Id: 0, Description: "" });
                        item.assignCategories(categories());
                        items.splice(0, 0, item);
                        // Select the newly added item
                        selectedItem(item);
                    },
                    // Create Item - In Form
                    createItemInForm = function () {
                        createItem();
                        showItemEditor();
                    },
                    // Save Item
                    onSaveItem = function (item) {
                        if (doBeforeSelect()) {
                            // Commits and Selects the Row
                            saveItem(item);
                        }
                    },
                    // Do Before Logic
                    doBeforeSelect = function () {
                        var flag = true;
                        if (!selectedItem().isValid()) {
                            selectedItem().errors.showAllMessages();
                            flag = false;
                        }
                        return flag;
                    },
                    // Initialize the view model
                    initialize = function (specifiedView) {
                        view = specifiedView;

                        ko.applyBindings(view.viewModel, view.bindingRoot);

                        //getBase();

                        // Set Pager
                        pager(pagination.Pagination({}, items, getItems));

                        getItems();
                    },
                    // Template Chooser
                    templateToUse = function (item) {
                        return (item === selectedItem() ? 'editItemTemplate' : 'itemItemTemplate');
                    },
                    // Map Items - Server to Client
                    mapItems = function (data) {
                        var itemList = [];
                        _.each(data.Items, function (item) {
                            var item = new model.Item(item);
                            item.assignCategories(categories());
                            itemList.push(item);
                        });

                        ko.utils.arrayPushAll(items(), itemList);
                        items.valueHasMutated();
                    },
                    // Get Base
                    getBase = function () {
                        dataservice.getItemBase({
                            success: function (data) {
                                categories.removeAll();
                                ko.utils.arrayPushAll(categories(), data);
                                categories.valueHasMutated();
                            },
                            error: function () {
                                toastr.error("Failed to load base data");
                            }
                        });
                    },
                    // Search 
                    search = function () {
                        pager().reset();
                        getItems();
                    },
                    // Get Items
                    getItems = function () {
                        isLoadingItems(true);
                        dataservice.getItems({
                            SearchString: searchFilter(), CategoryId: categoryFilter(), PageSize: pager().pageSize(),
                            PageNo: pager().currentPage(), SortBy: sortOn(), IsAsc: sortIsAsc()
                        }, {
                            success: function (data) {
                                pager().totalCount(data.TotalCount);
                                items.removeAll();
                                mapItems(data);
                                isLoadingItems(false);
                            },
                            error: function () {
                                isLoadingItems(false);
                                toastr.error("Failed to load items!");
                            }
                        });
                    },
                    // Delete Item
                    deleteItem = function (item) {
                        dataservice.deleteItem(item.convertToServerData(), {
                            success: function () {
                                items.remove(item);
                                toastr.success("Item removed successfully");
                            },
                            error: function () {
                                toastr.error("Failed to remove item!");
                            }
                        });
                    },
                    // Save Item
                    saveItem = function (item) {
                        var method = "updateItem";
                        if (!selectedItem().id()) {
                            method = "createItem";
                        }
                        // Ignore additional properties
                        var mapping = {
                            'ignore': ["categories", "categoryName", "assignCategories", "dirtyFlag", "hasChanges", "errors", "isValid",
                                "reset"]
                        };
                        dataservice[method](ko.mapping.toJS(selectedItem(), mapping), {
                            success: function () {
                                // Reset Changes
                                selectedItem().reset();
                                // If Item is specified then select it
                                if (item) {
                                    selectItem(item);
                                }
                                if (isItemEditorVisible) {
                                    closeItemEditor();
                                }
                                toastr.success("Item saved successfully");
                            },
                            error: function () {
                                toastr.error('Failed to save item!');
                            }
                        });
                    };
                // #endregion Service Calls

                return {
                    // Observables
                    selectedItem: selectedItem,
                    isLoadingItems: isLoadingItems,
                    categories: categories,
                    items: items,
                    totalPrice: totalPrice,
                    searchFilter: searchFilter,
                    categoryFilter: categoryFilter,
                    sortOn: sortOn,
                    sortIsAsc: sortIsAsc,
                    // Observables
                    // Utility Methods
                    onSaveItem: onSaveItem,
                    createItem: createItem,
                    onDeleteItem: onDeleteItem,
                    initialize: initialize,
                    templateToUse: templateToUse,
                    selectItem: selectItem,
                    search: search,
                    getItems: getItems,
                    pager: pager,
                    onEditItemInline: onEditItemInline,
                    onEditItem: onEditItem,
                    showItemEditor: showItemEditor,
                    onCloseItemEditor: onCloseItemEditor,
                    isItemEditorVisible: isItemEditorVisible,
                    createItemInForm: createItemInForm
                    // Utility Methods
                };
            })()
        };
        return ist.fleetPool.viewModel;
    });
