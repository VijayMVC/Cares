/*
    Module with the view model for the WorkLocaion
*/
define("workLocation/workLocation.viewModel",
    ["jquery", "amplify", "ko", "workLocation/workLocation.dataservice", "workLocation/workLocation.model",
    "common/confirmation.viewModel", "common/pagination"],
    function($, amplify, ko, dataservice, model, confirmation, pagination) {
        var ist = window.ist || {};
        ist.WorkLocaion = {
            viewModel: (function() {
                var view,
                    //WorkLocaion list
                    workLocations = ko.observableArray([]),
                    //Companies list
                    baseCompaniesList = ko.observableArray([]),
                    baseCountriesList = ko.observableArray([]),
                    //regions list
                    baseRegionsList = ko.observableArray([]),
                    filteredRegionsList = ko.observableArray([]),
                    // sub regions list
                    baseSubRegionsList = ko.observableArray([]),
                    filteredSubRegiosnList = ko.observableArray([]),
                    //cities list
                    baseCitiesList = ko.observableArray([]),
                    filteredCitiesList = ko.observableArray([]),
                    //areas list
                    baseAreasList = ko.observableArray([]),
                    filteredAreasList = ko.observableArray([]),
                    //phones list
                    basePhoneTypesList = ko.observableArray([]),
                    phonesList = ko.observableArray([]),

                    //filters
                    workLocationFilter = ko.observable(),
                    cityFilter = ko.observable(),
                    areaFilter = ko.observable(),

                    // selected phone number
                    selectedPhoneTypeString = ko.observable(),
                    isWorklocationCreateMode = ko.observable(true),
                    //check
                    id = ko.observable(-1),
                    //pager
                    pager = ko.observable(),
                    //sorting
                    sortOn = ko.observable(1),
                    //Assending  / Desending
                    sortIsAsc = ko.observable(true),
                    //to control the visibility of editor sec
                    isWorkLocationEditorVisible = ko.observable(false),
                    //to control the visibility of filter ec
                    filterSectionVisilble = ko.observable(false),

                    // Editor View Model
                    editorViewModel = new ist.ViewModel(model.workLocation),
                    selectedWorkLocation = editorViewModel.itemForEditing,
                    //save button handler
                    onSaveWorkLocation = function() {
                        if (dobeforeworkLocation())
                            saveWorkLocation(selectedWorkLocation());
                    },
                    //cancel button handler
                    onCancelSaveWorkLocation = function() {
                        editorViewModel.revertItem();
                        isWorklocationCreateMode(true);
                        isWorkLocationEditorVisible(false);
                    },
                    // create new org group handler
                    onCreateWorkLocationForm = function() {
                        var workLocation = new model.workLocation();
                        editorViewModel.selectItem(workLocation);
                        selectedWorkLocation().phoneDetail(new model.createPhone(false));
                        phonesList.removeAll();
                        filteredRegionsList.removeAll();
                        filteredCitiesList.removeAll();
                        filteredSubRegiosnList.removeAll();
                        filteredAreasList.removeAll();
                        isWorklocationCreateMode(true);
                        isWorkLocationEditorVisible(true);
                    },
                    //reset butto handle 
                    onResetResuults = function() {
                    workLocationFilter(undefined),
                        cityFilter(undefined),
                        areaFilter(undefined),
                        getWorkLocations(undefined);
                    },
                //delete button handler
                    onDeleteWorkLocation = function(item) {
                        if (!item.id()) {
                            fleetPools.remove(item);
                            return;
                        }
                        // Ask for confirmation
                        confirmation.afterProceed(function() {
                            deleteWorkLocation(item);
                        });
                        confirmation.show();
                    },
                    //edit button handler
                    onEditworkLocation = function(item) {
                        isWorklocationCreateMode(false);
                        populateRegionDropDown(item.countryId());
                        populateSubRegionDropDown(item.regionId());
                        populateCityDropDown(item.subRegionId(), item.regionId());
                        populateAreaDropDown(item.cityId());
                        getWorkLocationPhones(item.id());
                        editorViewModel.selectItem(item);
                        selectedWorkLocation().phoneDetail(new model.createPhone(false));
                        selectedWorkLocation().phoneDetail().workLocationId(item.id());
                        isWorkLocationEditorVisible(true);
                    },
                    //validation check  for workLocation
                    dobeforeworkLocation = function() {
                        if (!selectedWorkLocation().isValid()) {
                            selectedWorkLocation().errors.showAllMessages();
                            return false;
                        }
                        return true;
                    },
                    //validation check  for phone
                    dobeforePhone = function() {
                        if (!selectedWorkLocation().phoneDetail().isValid()) {
                            selectedWorkLocation().phoneDetail().errors.showAllMessages();
                            return false;
                        }
                        return true;
                    },
                    //add phone  handler
                    onAddPhone = function(phoneDetail) {
                        if (dobeforePhone()) {
                            var selectedPhoneType = basePhoneTypesList.find(function(temp) {
                                if (selectedWorkLocation().phoneDetail() && temp.PhoneTypeId == selectedWorkLocation().phoneDetail().phoneTypeId())
                                    return temp.PhoneTypeCodeName;
                                else return "";
                            });
                            phoneDetail.phoneTypeName(selectedPhoneType.PhoneTypeCodeName);
                            if (phoneDetail.isDefault())
                                phoneDetail.isDefault('Yes');
                            else
                                phoneDetail.isDefault('No');

                            phoneDetail.phoneTypeId(selectedWorkLocation().phoneDetail().phoneTypeId());
                            phonesList.push(phoneDetail);
                            selectedPhoneTypeString(undefined);

                            selectedWorkLocation().phoneDetail(new model.createPhone(false));
                        }
                        return false;
                    },
                    //delete phone
                    deletePhoneDetail = function(item) {
                        phonesList.remove(item);
                    },
                    //save Work Location
                    saveWorkLocation = function(operation) {
                        dataservice.saveWorkLocation(workLocationClientToServerMapper(operation), {
                            success: function(uodatedOperation) {
                                var newItem = model.workLocationServertoClientMapper(uodatedOperation);
                                if (selectedWorkLocation().id() != undefined) {
                                    var newObjtodelete = workLocations.find(function(temp) {
                                        return temp.id() == newItem.id();
                                    });
                                    workLocations.remove(newObjtodelete);
                                    workLocations.push(newItem);
                                } else
                                    workLocations.push(newItem);
                                isWorkLocationEditorVisible(false);
                                toastr.success(ist.resourceText.WorkLocationSaveSuccessMessage);
                            },
                            error: function(exceptionMessage, exceptionType) {
                                if (exceptionType === ist.exceptionType.CaresGeneralException)
                                    toastr.error(exceptionMessage);
                                else
                                    toastr.error(ist.resourceText.WorkLocationSaveFailError);
                            }
                        });
                    },
                    //delete WorkLocation
                    deleteWorkLocation = function(operation) {
                        dataservice.deleteWorkLocation(operation.convertToServerData(), {
                            success: function() {
                                workLocations.remove(operation);
                                getWorkLocationBaseData();
                                toastr.success(ist.resourceText.WorkLocationDeleteSuccessMessage);
                            },
                            error: function(exceptionMessage, exceptionType) {
                                if (exceptionType === ist.exceptionType.CaresGeneralException)
                                    toastr.error(exceptionMessage);
                                else
                                    toastr.error(ist.resourceText.WorkLocationDeleteFailError);
                            }
                        });
                    },
                    //search button handler in filter section
                    onSearch = function() {
                        getWorkLocations();
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
                    getWorkLocations = function() {
                        dataservice.getWorkLocations({
                            WorkLocationFilterText: workLocationFilter(),
                            CityId: cityFilter(),
                            AreaId: areaFilter(),
                            PageSize: pager().pageSize(),
                            PageNo: pager().currentPage(),
                            SortBy: sortOn(),
                            IsAsc: sortIsAsc()
                        },
                        {
                            success: function(data) {
                                workLocations.removeAll();
                                pager().totalCount(data.TotalCount);
                                _.each(data.WorkLocations, function(item) {
                                    workLocations.push(model.workLocationServertoClientMapper(item));
                                });
                            },
                            error: function() {
                                toastr.error(ist.resourceText.WorkLocationLoadFailError);
                            }
                        });
                    },
                    //get WorkLocation base data
                    getWorkLocationBaseData = function() {
                        dataservice.getWorkLocationBaseData(null, {
                            success: function(baseDataFromServer) {
                                poulateBaseData(baseDataFromServer);
                            },
                            error: function(exceptionMessage, exceptionType) {
                                if (exceptionType === ist.exceptionType.CaresGeneralException) {
                                    toastr.error(exceptionMessage);
                                } else {
                                    toastr.error(ist.resourceText.WorkLocationLoadBaseFailError);
                                }
                            }
                        });
                    },
                    //set the base data 
                    poulateBaseData = function(baseDataFromServer) {
                        baseCompaniesList.removeAll();
                        baseCountriesList.removeAll();
                        baseRegionsList.removeAll();
                        baseSubRegionsList.removeAll();
                        baseCitiesList.removeAll();
                        baseAreasList.removeAll();
                        basePhoneTypesList.removeAll();
                        ko.utils.arrayPushAll(baseCompaniesList(), baseDataFromServer.Companies);
                        baseCompaniesList.valueHasMutated();
                        ko.utils.arrayPushAll(baseCountriesList(), baseDataFromServer.Countries);
                        baseCountriesList.valueHasMutated();
                        ko.utils.arrayPushAll(baseRegionsList(), baseDataFromServer.Regions);
                        baseRegionsList.valueHasMutated();
                        ko.utils.arrayPushAll(baseSubRegionsList(), baseDataFromServer.SubRegions);
                        baseSubRegionsList.valueHasMutated();
                        ko.utils.arrayPushAll(baseCitiesList(), baseDataFromServer.Cities);
                        baseCitiesList.valueHasMutated();
                        ko.utils.arrayPushAll(baseAreasList(), baseDataFromServer.Areas);
                        baseAreasList.valueHasMutated();
                        ko.utils.arrayPushAll(basePhoneTypesList(), baseDataFromServer.PhoneTypes);
                        basePhoneTypesList.valueHasMutated();

                        ko.utils.arrayPushAll(filteredAreasList(), baseAreasList());
                        filteredAreasList.valueHasMutated();

                    },
                    //country dropdown handler
                    onCountryChanged = function (item) {
                        populateRegionDropDown(item.countryId());
                        return false;
                    },
                    // country dropdown changed for regions
                    populateRegionDropDown = function(countryId) {
                        filteredRegionsList(_.filter(baseRegionsList(), function(region) {
                            return region.CountryId === countryId;
                        }));
                        return false;
                    },
                    //Region dropdown handler
                    onRegionChanged = function (item) {
                        if (item.id() != -1) {
                            var v = item.regionId();
                            populateSubRegionDropDown(v);
                        }
                    },
                    // region dropdown changed for subregions
                    populateSubRegionDropDown = function(regionId) {
                        filteredSubRegiosnList(_.filter(baseSubRegionsList(), function(subRegion) {
                            return subRegion.RegionId === regionId;
                        }));
                    },
                    //SubRegion dropdown handler
                    onSubRegionChanged = function (item) {
                        if (item.id() != -1) {
                            populateCityDropDown(item.subRegionId(), item.regionId());
                        }
                    },
                    //sub Region dropdown changed for cities
                    populateCityDropDown = function(subRegionId, regionId) {
                        filteredCitiesList(_.filter(baseCitiesList(), function(city) {
                            return city.SubRegionId === subRegionId && city.RegionId === regionId;
                        }));
                    },
                    //City dropdown handler
                    onCityChanged = function (item) {
                        if (item.id() != -1) {
                            cityFilter(item.cityId());
                            populateAreaDropDown(cityFilter());
                        }
                    },
                    //city dropdown changed for area
                    populateAreaDropDown = function (cityId) {
                        filteredAreasList(_.filter(baseAreasList(), function (area) {
                            if (cityId !== undefined)
                                return area.CityId === cityId;
                            else {
                                return '';
                            }
                        }));
                    },
                    // city dropdown in filter section
                    onCityChangedinFilter = function () {
                        populateAreaDropDown(cityFilter());
                    },
                    // work location client to server mapper
                    workLocationClientToServerMapper = function(operation) {
                        _.each(phonesList(), function(item) {
                            var v = item.convertToServerData();
                            operation.Phones.push(v);
                        });
                        return operation.convertToServerData();
                    },
                    getWorkLocationPhones = function(workLocationId) {
                        dataservice.getWorkLocationPhones(
                        {
                            workLocationId: workLocationId
                        },
                        {
                            success: function(data) {
                                phonesList.removeAll();
                                _.each(data.PhonesAssociatedWithWorkLocation, function(item) {
                                    var v = model.phoneServertoClientMapper(item);
                                    phonesList.push(v);
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
                        pager(pagination.Pagination({ PageSize: 5 }, workLocations, getWorkLocations));
                        getWorkLocationBaseData();
                        getWorkLocations();
                    };
                return {
                    //lists
                    baseCompaniesList:baseCompaniesList,
                    baseCountriesList:baseCountriesList,
                    baseRegionsList: baseRegionsList,
                    filteredRegionsList:filteredRegionsList,
                    baseSubRegionsList:baseSubRegionsList,
                    filteredSubRegiosnList: filteredSubRegiosnList,
                    baseCitiesList:baseCitiesList,
                    filteredCitiesList:filteredCitiesList,
                    baseAreasList: baseAreasList,
                    filteredAreasList:filteredAreasList,
                    isWorkLocationEditorVisible: isWorkLocationEditorVisible,
                    initialize: initialize,
                    onCreateWorkLocationForm: onCreateWorkLocationForm,
                    sortOn: sortOn,
                    getWorkLocations: getWorkLocations,
                    sortIsAsc: sortIsAsc,
                    filterSectionVisilble: filterSectionVisilble,
                    hideFilterSection: hideFilterSection,
                    showFilterSection: showFilterSection,
                    pager: pager,
                    id:id, // for checking purposes 
                    onResetResuults: onResetResuults,
                    onEditworkLocation: onEditworkLocation,
                    onDeleteWorkLocation: onDeleteWorkLocation,
                    onSaveWorkLocation: onSaveWorkLocation,
                    onSearch: onSearch,
                    workLocations: workLocations,
                    onCancelSaveWorkLocation: onCancelSaveWorkLocation,
                    onAddPhone: onAddPhone,
                    selectedWorkLocation: selectedWorkLocation,
                    deletePhoneDetail: deletePhoneDetail,
                    onCountryChanged: onCountryChanged,
                    onRegionChanged: onRegionChanged,
                    cityFilter: cityFilter,
                    onSubRegionChanged: onSubRegionChanged,
                    onCityChanged: onCityChanged,
                    onCityChangedinFilter:onCityChangedinFilter,
                    areaFilter:areaFilter,
                    workLocationFilter: workLocationFilter,
                    isWorklocationCreateMode: isWorklocationCreateMode,

                    basePhoneTypesList: basePhoneTypesList,
                    phonesList: phonesList,
                    selectedPhoneTypeString: selectedPhoneTypeString
                };
            })()
        };
        return ist.WorkLocaion.viewModel;
    });
