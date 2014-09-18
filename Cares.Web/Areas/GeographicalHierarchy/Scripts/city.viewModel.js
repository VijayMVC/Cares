/*
    Module with the view model for the City
*/
define("city/city.viewModel",
    ["jquery", "amplify", "ko", "city/city.dataservice", "city/city.model",
    "common/confirmation.viewModel", "common/pagination"],
    function($, amplify, ko, dataservice, model, confirmation, pagination) {
        var ist = window.ist || {};
        ist.City = {
            viewModel: (function() { 
                var view,
                    //array to save City
                    cities = ko.observableArray([]),

                    //array to save basa data country list
                    baseCountriesList = ko.observableArray([]),
                     //array to save basa data Regions list
                    baseRegionsList = ko.observableArray([]),
                     //array to save basa data Sub Regions list
                    baseSubRegionsList = ko.observableArray([]),

                     //array to save filtered country data 
                     filteredCountriesList = ko.observableArray([]),
                      //array to save filtered Region data 
                     filteredRegionsList = ko.observableArray([]),
                     //array to save filtered Sub Region data 
                     filteredSubRegionsList = ko.observableArray([]),


                    //pager%
                    pager = ko.observable(),
                    //org code filter in filter sec
                    searchFilter = ko.observable(),
                    baseCountryFilter = ko.observable(),

                    //sorting
                    sortOn = ko.observable(1),
                    //Assending  / Desending
                    sortIsAsc = ko.observable(true),
                    //to control the visibility of editor sec
                    isCityEditorVisible = ko.observable(false),
                    //to control the visibility of filter ec
                    filterSectionVisilble = ko.observable(false),


                     // Editor View Model
                    editorViewModel = new ist.ViewModel(model.cityDetail),
                    // Selected City
                    selectedCity = editorViewModel.itemForEditing,
                    id = ko.observable(-1),
                    //save button handler
                    onSavebtn = function() {
                        if (dobeforeCity())
                        saveCity(selectedCity());
                },
                //Save City
                    saveCity = function(item) {
                        dataservice.saveCity(item.convertToServerData(), {
                        success: function(dataFromServer) {
                            var newItem = model.cityServertoClinetMapper(dataFromServer);
                            if (item.id() !== undefined) {
                                var newObjtodelete = cities.find(function(temp) {
                                    return temp.id() == newItem.id();
                                });
                                cities.remove(newObjtodelete);
                                cities.push(newItem);
                            } else
                                cities.push(newItem);
                            isCityEditorVisible(false);
                            toastr.success(ist.resourceText.CitySaveSuccessMessage);
                        },
                        error: function(exceptionMessage, exceptionType) {
                            if (exceptionType === ist.exceptionType.CaresGeneralException)
                                toastr.error(exceptionMessage);
                            else
                                toastr.error(ist.resourceText.CitySaveFailError);
                        }
                    });
                },
                //validation check 
                    dobeforeCity = function () {
                    if (!selectedCity().isValid()) {
                        selectedCity().errors.showAllMessages();
                        return false;
                    }
                    return true;
                },
                //cancel button handler
                    onCancelbtn = function() {
                    editorViewModel.revertItem();
                    isCityEditorVisible(false);
                },
                // create new Region
                    onCreateForm = function() {
                    var city = new model.cityDetail();
                    editorViewModel.selectItem(city);
                    filteredRegionsList.removeAll();
                    filteredSubRegionsList.removeAll();
                    isCityEditorVisible(true);
                },
                //reset butto handle 
                    resetResuults = function() {
                    searchFilter(undefined);
                    baseCountryFilter(undefined);
                    getCities();
                },
                //delete button handler
                    onDeleteItem = function(item) {
                    if (!item.id()) {
                        cities.remove(item);
                        return;
                    }
                    // Ask for confirmation
                    confirmation.afterProceed(function() {
                        deleteCity(item);
                    });
                    confirmation.show();
                },
                //edit button handler
                    onEditItem = function (item) {
                    setCityEditorData(item);
                    editorViewModel.selectItem(item);
                    isCityEditorVisible(true);
                    filteredRegionsList();
                    filteredSubRegionsList();
                    },
                //delete City
                    deleteCity = function(region) {
                        dataservice.deleteCity(region.convertToServerData(), {
                        success: function() {
                            cities.remove(region);
                            toastr.success(ist.resourceText.CityDeleteSuccessMessage);
                        },
                        error: function(exceptionMessage, exceptionType) {
                            if (exceptionType === ist.exceptionType.CaresGeneralException)
                                toastr.error(exceptionMessage);
                            else
                                toastr.error(ist.resourceText.CityDeleteFailError);
                        }
                    });
                },
                //search button handler in filter section
                    search = function() {
                    pager().reset();
                    getCities();
                },
                //hide filte section
                    hideFilterSection = function() {
                    filterSectionVisilble(false);
                },
                //Show filter section
                    showFilterSection = function() {
                        filterSectionVisilble(true);
                    },
                    //Get City list from Dataservice
                    getCities = function() {
                        dataservice.getCities(
                        {
                            CityFilterText: searchFilter(),
                            CountryId: baseCountryFilter(),
                            PageSize: pager().pageSize(),
                            PageNo: pager().currentPage(),
                            SortBy: sortOn(),
                            IsAsc: sortIsAsc()
                    },
                    {
                        success: function (data) {
                            cities.removeAll();
                            debugger;
                            pager().totalCount(data.TotalCount);
                            _.each(data.Cities, function (item) {
                                var b = model.cityServertoClinetMapper(item);
                                cities.push(b);
                            });
                        },
                        error: function() {
                            isLoadingFleetPools(false);
                            toastr.error(ist.resourceText.CityLoadFailError);
                        }
                    });
                    },
                     //get City base data
                    getBaseData = function () {
                        dataservice.getCityBaseData(null, {
                            success: function (data) {
                                setBaseData(data);
                            },
                            error: function (exceptionMessage, exceptionType) {
                                if (exceptionType === ist.exceptionType.CaresGeneralException) {
                                    toastr.error(exceptionMessage);
                                } else {
                                    toastr.error(ist.resourceText.CityBaseDataLoadFailError);
                                }
                            }
                        });
                    },
                     //country dropdown handler
                    onCountryChanged = function (item) {
                        setRegionDroDown(item.countryId());
                        return false;
                    },
                    setCityEditorData = function (selectedItem) {
                        setRegionDroDown(selectedItem.countryId());
                        setSubRegionDroDown(selectedItem.regionId());
                    },
                       //Region dropdown handler
                    onRegionChanged = function (item) {
                        if (item.id() != -1) {
                            var v = item.regionId();
                            setSubRegionDroDown(v);
                        }
                    },
                     setRegionDroDown = function(countryId) {
                         filteredRegionsList(_.filter(baseRegionsList(), function (region) {
                             return region.CountryId === countryId;
                         }));
                     },
                     setSubRegionDroDown = function (regionId) {
                         debugger;
                         filteredSubRegionsList(_.filter(baseSubRegionsList(), function (subRegion) {
                             return subRegion.RegionId === regionId;
                         }));
                     },
                   //base data setter function
                    setBaseData = function (data) {
                    baseCountriesList.removeAll();
                    ko.utils.arrayPushAll(baseCountriesList(), data.CountriyDropDowns);
                    baseCountriesList.valueHasMutated();

                    baseRegionsList.removeAll();
                    ko.utils.arrayPushAll(baseRegionsList(), data.RegionDropDowns);
                    baseRegionsList.valueHasMutated();

                    baseSubRegionsList.removeAll();
                    ko.utils.arrayPushAll(baseSubRegionsList(), data.SubRegionDowns);
                    baseSubRegionsList.valueHasMutated();
                },
                // Initialize the view model
                    initialize = function(specifiedView) {
                        view = specifiedView;
                        ko.applyBindings(view.viewModel, view.bindingRoot);
                        pager(pagination.Pagination({ PageSize: 5 }, cities, getCities));
                        getBaseData();
                        getCities();
                    };
                return {
                    cities: cities,
                    initialize: initialize,
                    search: search,
                    searchFilter: searchFilter,
                    sortOn: sortOn,
                    sortIsAsc: sortIsAsc,
                    onCreateForm: onCreateForm,
                    filterSectionVisilble: filterSectionVisilble,
                    isCityEditorVisible: isCityEditorVisible,
                    hideFilterSection: hideFilterSection,
                    showFilterSection: showFilterSection,
                    pager: pager,
                    resetResuults: resetResuults,
                    onDeleteItem: onDeleteItem,
                    onEditItem: onEditItem,
                    onCancelbtn: onCancelbtn,
                    selectedCity: selectedCity,
                    onSavebtn: onSavebtn,
                    getCities: getCities,
                    getBaseData: getBaseData,
                    baseCountriesList: baseCountriesList,
                    baseCountryFilter: baseCountryFilter,
                    baseRegionsList: baseRegionsList,
                    baseSubRegionsList: baseSubRegionsList,
                    filteredCountriesList: filteredCountriesList,
                    filteredRegionsList: filteredRegionsList,
                    filteredSubRegionsList: filteredSubRegionsList,
                    id: id,
                    onCountryChanged: onCountryChanged,
                    onRegionChanged: onRegionChanged
                };
            })()
        };
        return ist.City.viewModel;
    });
