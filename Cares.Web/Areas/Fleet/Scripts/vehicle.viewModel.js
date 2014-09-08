/*
    Module with the view model for the Vehicle
*/
define("vehicle/vehicle.viewModel",
    ["jquery", "amplify", "ko", "vehicle/vehicle.dataservice", "vehicle/vehicle.model", "common/confirmation.viewModel", "common/pagination"],
    function ($, amplify, ko, dataservice, model, confirmation, pagination) {
        var ist = window.ist || {};
        ist.vehicle = {
            viewModel: (function () {
                var // the view 
                    view,
                     // Active Vehicle
                   selectedVehicle = ko.observable(),
                    //Active Vehicle Copy 
                   selectedVehicleCopy = ko.observable(),
                    //Active Vehicle Id
                    selectedVehicleId = ko.observable(),
                      // Show Filter Section
                    filterSectionVisilble = ko.observable(false),
                    // #region Arrays
                    // Operations
                     //Vehicles
                    vehicles = ko.observableArray([]),
                    //Operations
                    operations = ko.observableArray([]),
                    //FleetPools
                    fleetPools = ko.observableArray([]),
                    //Companies
                    companies = ko.observableArray([]),
                    //Regions
                    regions = ko.observableArray([]),
                    //Fuel Types
                    fuelTypes = ko.observableArray([]),
                    //Vehicle Models
                    vehicleModels = ko.observableArray([]),
                    //Vehicle Statuses
                    vehicleStatuses = ko.observableArray([]),
                    //Departments
                    departments = ko.observableArray([]),
                    //Vehicle Categories
                    vehicleCategories = ko.observableArray([]),
                    //TransmissionTypes
                    transmissionTypes = ko.observableArray([]),
                    //Vehicle Makes
                    vehicleMakes = ko.observableArray([]),
                    //Business Partners 
                    businessPartners = ko.observableArray([]),
                    //Insurance Type
                    insuranceType = ko.observableArray([]),
                    //Maintenance Types
                    maintenanceTypes = ko.observableArray([]),
                    //Vehicle Check List
                    vehicleCheckList = ko.observableArray([]),
                    //Filterd Departments
                    filteredDepartments = ko.observableArray([]),
                    //Filtered Operations
                    filteredOperations = ko.observableArray([]),
                    //Locations
                    locations = ko.observableArray([]),
                    //Maintenance Schedule List
                    maintenanceScheduleList = ko.observableArray([]),
                     //Maintenance Schedule List
                    checkListItemList = ko.observableArray([]),
                    // #endregion Arrays

                    // #region Busy Indicators
                    isLoadingVehicles = ko.observable(false),
                    // #endregion Busy Indicators
                    // #region Observables
                    // Sort On
                    sortOn = ko.observable(1),
                    // Sort Order -  true means asc, false means desc
                    sortIsAsc = ko.observable(true),
                    // Sort On Vehicle
                    sortOnHg = ko.observable(1),
                    // Sort Order -  true means asc, false means desc
                    sortIsAscHg = ko.observable(true),
                    // Is Vehicle Editor Visible
                    isVehicleEditorVisible = ko.observable(false),
                    // Pagination
                    pager = ko.observable(),
                     //Search filter
                    searchFilter = ko.observable(),
                    //Hire Group Filter
                    hireGroupFilter = ko.observable(),
                    // Fleet Pool Filter
                    fleetPoolFilter = ko.observable(),
                    //Operation Filter
                    operationFilter = ko.observable(),
                    // #region Utility Functions
                    // Initialize the view model
                    initialize = function (specifiedView) {
                        view = specifiedView;
                        ko.applyBindings(view.viewModel, view.bindingRoot);
                        getBaseData();
                        // Set Pager
                        pager(new pagination.Pagination({}, vehicles, getVehicles));
                        getVehicles();

                    },
                     // Collapase filter section
                    collapseFilterSection = function () {
                        filterSectionVisilble(false);
                    },
                    //Show filter section
                    showFilterSection = function () {
                        filterSectionVisilble(true);
                    },
                    //close Vehicle Editor
                    closeVehicleEditor = function () {
                        isVehicleEditorVisible(false);
                    },
                    //Show Vehicle Editor
                    showVehicleEditor = function () {
                        isVehicleEditorVisible(true);
                    },
                     //Create Vehicle Rate
                    createVehicle = function () {
                        var vehicle = new model.VehicleDetail.Create();
                        checkListItemList.removeAll();
                        maintenanceScheduleList.removeAll();
                        //Select the newly added Vehicle
                        selectedVehicle(vehicle);
                        showVehicleEditor();
                    },
                      //Edit Vehicle
                    onEditVehicle = function (vehicle, e) {
                        checkListItemList.removeAll();
                        maintenanceScheduleList.removeAll();
                        //selectedVehicle(vehicle);
                        //selectedtariffRateCopy(model.TariffRateCoppier(selectedtariffRate()));
                        getVehicleById(vehicle);
                        showVehicleEditor();
                        e.stopImmediatePropagation();
                    },
                      //Get Vehicle data By Id
                    getVehicleById = function (vehicle) {
                        isLoadingVehicles(true);
                        dataservice.getVehicleDetailById(model.VehicleDetailServerMappeForDelete(vehicle), {
                            success: function (data) {
                                var vehicleDetail = model.VehicleDetailClientMapper(data);
                                selectedVehicle(vehicleDetail);
                                _.each(data.VehicleCheckListItems, function (item) {
                                    var checkListItem = model.CheckListItemClientMapper(item);
                                    checkListItemList.push(checkListItem);
                                });
                                _.each(data.VehicleMaintenanceTypeFrequency, function (item) {
                                    var maintenanceScheduleItem = model.MaintenanceScheduleClientMapper(item);
                                    maintenanceScheduleList.push(maintenanceScheduleItem);
                                });
                                isLoadingVehicles(false);
                            },
                            error: function () {
                                isLoadingVehicles(false);
                                toastr.error(ist.resourceText.VehicleDetailFailedMsg);
                            }
                        });
                    },
                    // Delete a Vehicle
                    onDeleteVehicle = function (vehicle) {
                        if (!vehicle.vehicleId()) {
                            vehicles.remove(vehicle);
                            return;
                        }
                        // Ask for confirmation
                        confirmation.afterProceed(function () {
                            deleteVehicle(vehicle);
                        });
                        confirmation.show();
                    },
                    // Delete Vehicle
                    deleteVehicle = function (vehicle) {
                        dataservice.deleteVehicle(model.VehicleDetailServerMappeForDelete(vehicle), {
                            success: function () {
                                vehicles.remove(vehicle);
                                toastr.success("Vehicle Succesfully delete.");
                            },
                            error: function () {
                                toastr.error("error");
                            }
                        });
                    },
                   // Save Vehicle
                    onSaveVehicle = function (vehicle) {
                        if (doBeforeSave()) {
                            if (vehicle.maintenanceScheduleListInVehicle().length !== 0) {
                                vehicle.maintenanceScheduleListInVehicle.removeAll();
                            }
                            if (vehicle.checkListItemListInVehicle().length !== 0) {
                                vehicle.checkListItemListInVehicle.removeAll();
                            }
                            ko.utils.arrayPushAll(vehicle.maintenanceScheduleListInVehicle(), maintenanceScheduleList());
                            ko.utils.arrayPushAll(vehicle.checkListItemListInVehicle(), checkListItemList());
                            saveVehicle(vehicle);
                        }
                    },
                    // Do Before Logic
                    doBeforeSave = function () {
                        var flag = true;
                        if (!selectedVehicle().isValid() || !selectedVehicle().otherVehicleDetail().isValid()) {
                            selectedVehicle().errors.showAllMessages();
                            selectedVehicle().otherVehicleDetail().errors.showAllMessages();
                            flag = false;
                        }
                        return flag;
                    },
                    // Save Vehicle
                    saveVehicle = function (vehicle) {
                        dataservice.saveVehicle(model.VehicleDetailServerMapper(vehicle), {
                            success: function (data) {
                                var vehicleResult = new model.VehicleClientMapper(data);
                                if ((selectedVehicle().vehicleId() === undefined) || (selectedVehicle().vehicleId() === 0)) {
                                    vehicles.splice(0, 0, vehicleResult);
                                } else {
                                    // selectedVehicle().VehicleCode(VehicleResult.VehicleCode());


                                }
                                closeVehicleEditor();
                                toastr.success(ist.resourceText.hirGroupAddSuccesMsg);
                            },
                            error: function () {
                                toastr.error(ist.resourceText.hirGroupAddFailedMsg);
                            }
                        });
                    },
                    // //Get Base Data
                    getBaseData = function (callBack) {
                        dataservice.getVehicleBase({
                            success: function (data) {
                                //Operations 
                                operations.removeAll();
                                ko.utils.arrayPushAll(operations(), data.Operations);
                                operations.valueHasMutated();
                                //Fleet Pools  array
                                fleetPools.removeAll();
                                ko.utils.arrayPushAll(fleetPools(), data.FleetPools);
                                fleetPools.valueHasMutated();
                                //Vehicle Makes
                                vehicleMakes.removeAll();
                                ko.utils.arrayPushAll(vehicleMakes(), data.VehicleMakes);
                                vehicleMakes.valueHasMutated();
                                //Vehicle Categories
                                vehicleCategories.removeAll();
                                ko.utils.arrayPushAll(vehicleCategories(), data.VehicleCategories);
                                vehicleCategories.valueHasMutated();
                                //Vehicle Models
                                vehicleModels.removeAll();
                                ko.utils.arrayPushAll(vehicleModels(), data.VehicleModels);
                                vehicleModels.valueHasMutated();
                                //Companies  
                                companies.removeAll();
                                ko.utils.arrayPushAll(companies(), data.Companies);
                                companies.valueHasMutated();
                                //Regions   
                                regions.removeAll();
                                ko.utils.arrayPushAll(regions(), data.Regions);
                                regions.valueHasMutated();
                                //Fuel Types    
                                fuelTypes.removeAll();
                                ko.utils.arrayPushAll(fuelTypes(), data.FuelTypes);
                                fuelTypes.valueHasMutated();
                                //Vehicles Statuses     
                                vehicleStatuses.removeAll();
                                ko.utils.arrayPushAll(vehicleStatuses(), data.VehicleStatuses);
                                vehicleStatuses.valueHasMutated();
                                //Departments       
                                departments.removeAll();
                                ko.utils.arrayPushAll(departments(), data.Departments);
                                departments.valueHasMutated();
                                //Transmission Types        
                                transmissionTypes.removeAll();
                                ko.utils.arrayPushAll(transmissionTypes(), data.TransmissionTypes);
                                transmissionTypes.valueHasMutated();
                                //Business Partners        
                                businessPartners.removeAll();
                                ko.utils.arrayPushAll(businessPartners(), data.BusinessPartners);
                                businessPartners.valueHasMutated();
                                //Insurance Types        
                                insuranceType.removeAll();
                                ko.utils.arrayPushAll(insuranceType(), data.InsuranceType);
                                insuranceType.valueHasMutated();
                                //Maintenance Types         
                                maintenanceTypes.removeAll();
                                ko.utils.arrayPushAll(maintenanceTypes(), data.MaintenanceTypes);
                                maintenanceTypes.valueHasMutated();
                                //Vehicle Check List          
                                vehicleCheckList.removeAll();
                                ko.utils.arrayPushAll(vehicleCheckList(), data.VehicleCheckList);
                                vehicleCheckList.valueHasMutated();
                                //Locations
                                locations.removeAll();
                                ko.utils.arrayPushAll(locations(), data.Locations);
                                locations.valueHasMutated();


                                if (callBack && typeof callBack === 'function') {
                                    callBack();
                                }
                            },
                            error: function () {
                                toastr.error(ist.resourceText.loadBaseDataFailedMsg);
                            }
                        });
                    },
                    // Search 
                    search = function () {
                        pager().reset();
                        getVehicles();
                    },
                    //Add Maintenance Schedule Item To Maintennace Schedule List
                     onAddMaintenanceSchedule = function (maintenanceSchedule) {
                         if (doBeforeSaveMaintenanceSchedule()) {
                             _.each(maintenanceTypes(), function (item) {
                                 if (item.MaintenanceTypeId === maintenanceSchedule.maintenanceTypeId())
                                     maintenanceSchedule.maintenanceTypCodeName(item.MaintenanceTypeCodeName);
                             });

                             maintenanceScheduleList.splice(0, 0, maintenanceSchedule);
                         }
                     },
                    // Do Before Logic
                    doBeforeSaveMaintenanceSchedule = function () {
                        var flag = true;
                        if (!selectedVehicle().maintenanceSchedule().isValid()) {
                            selectedVehicle().maintenanceSchedule().errors.showAllMessages();
                            flag = false;
                        }
                        return flag;
                    },
                    //Delete Maintenance Schedule Item
                    deleteMaintenanceSchedule = function (maintenanceSchedule) {
                        maintenanceScheduleList.remove(maintenanceSchedule);
                    },
                    //Add Maintenance Schedule Item To Maintennace Schedule List
                    onAddCheckListItem = function (checkListItem) {
                        if (doBeforeSaveCheckListItem()) {
                            _.each(vehicleCheckList(), function (item) {
                                if (item.VehicleCheckListId === checkListItem.vehicleCheckListId())
                                    checkListItem.vehicleCheckListCodeName(item.VehicleCheckListCodeName);
                            });

                            checkListItemList.splice(0, 0, checkListItem);
                        }
                    },
                    // Do Before Logic
                    doBeforeSaveCheckListItem = function () {
                        var flag = true;
                        if (!selectedVehicle().checkListItem().isValid()) {
                            selectedVehicle().checkListItem().errors.showAllMessages();
                            flag = false;
                        }
                        return flag;
                    },
                    //Delete Maintenance Schedule Item
                    deleteCheckListItem = function (checkListItem) {
                        checkListItemList.remove(checkListItem);
                    },
                    mapVehicles = function (data) {
                        var vehicleList = [];
                        _.each(data.Vehicles, function (item) {
                            var vehicle = new model.VehicleClientMapper(item);
                            vehicleList.push(vehicle);
                        });
                        ko.utils.arrayPushAll(vehicles(), vehicleList);
                        vehicles.valueHasMutated();
                    },
                      //on selected company
                    onSelectedCompany = function (company) {
                        filteredDepartments.removeAll();
                        filteredOperations.removeAll();
                        if (company.companyId() != undefined) {
                            _.each(departments(), function (item) {
                                if (item.CompanyId === company.companyId())
                                    filteredDepartments.push(item);
                            });
                            filteredDepartments.valueHasMutated();
                        }

                    },
                      //on selected Department 
                    onSelectedDepartemnt = function (department) {
                        filteredOperations.removeAll();
                        if (department.departmentId() != undefined) {
                            _.each(operations(), function (item) {
                                if (item.DepartmentId === department.departmentId())
                                    filteredOperations.push(item);
                            });
                            filteredOperations.valueHasMutated();
                        }
                    },
                    modelYears = [{ Id: 2001, Text: '2001' },
                        { Id: 2002, Text: '2002' },
                        { Id: 2003, Text: '2003' },
                         { Id: 2004, Text: '2004' },
                        { Id: 2005, Text: '2005' },
                        { Id: 2006, Text: '2006' },
                        { Id: 2007, Text: '2007' }
                    ],
                    // Get Vehicles
                    getVehicles = function () {
                        isLoadingVehicles(true);
                        dataservice.getVehicles({
                            SearchString: searchFilter(),
                            HireGroupString: hireGroupFilter(),
                            OperationId: operationFilter(),
                            FleetPoolId: fleetPoolFilter(),
                            PageSize: pager().pageSize(),
                            PageNo: pager().currentPage(),
                            SortBy: sortOn(),
                            IsAsc: sortIsAsc()
                        }, {
                            success: function (data) {
                                pager().totalCount(data.TotalCount);
                                vehicles.removeAll();
                                mapVehicles(data);
                                isLoadingVehicles(false);
                            },
                            error: function () {
                                isLoadingVehicles(false);
                                toastr.error(ist.resourceText.VehicleLoadFailedMsg);
                            }
                        });
                    };
                // #endregion Service Calls

                return {
                    // Observables
                    selectedVehicle: selectedVehicle,
                    selectedVehicleCopy: selectedVehicleCopy,
                    isLoadingVehicles: isLoadingVehicles,
                    sortOn: sortOn,
                    sortIsAsc: sortIsAsc,
                    sortOnHg: sortOnHg,
                    sortIsAscHg: sortIsAscHg,
                    isVehicleEditorVisible: isVehicleEditorVisible,
                    filterSectionVisilble: filterSectionVisilble,
                    //Arrays
                    vehicles: vehicles,
                    operations: operations,
                    companies: companies,
                    regions: regions,
                    fuelTypes: fuelTypes,
                    vehicleModels: vehicleModels,
                    vehicleStatuses: vehicleStatuses,
                    departments: departments,
                    vehicleCategories: vehicleCategories,
                    transmissionTypes: transmissionTypes,
                    vehicleMakes: vehicleMakes,
                    businessPartners: businessPartners,
                    insuranceType: insuranceType,
                    maintenanceTypes: maintenanceTypes,
                    vehicleCheckList: vehicleCheckList,
                    fleetPools: fleetPools,
                    modelYears: modelYears,
                    filteredDepartments: filteredDepartments,
                    filteredOperations: filteredOperations,
                    locations: locations,
                    maintenanceScheduleList: maintenanceScheduleList,
                    checkListItemList: checkListItemList,
                    //Filters
                    searchFilter: searchFilter,
                    hireGroupFilter: hireGroupFilter,
                    operationFilter: operationFilter,
                    fleetPoolFilter: fleetPoolFilter,
                    // Utility Methods
                    initialize: initialize,
                    search: search,
                    getVehicles: getVehicles,
                    mapVehicles: mapVehicles,
                    getBaseData: getBaseData,
                    pager: pager,
                    closeVehicleEditor: closeVehicleEditor,
                    showVehicleEditor: showVehicleEditor,
                    collapseFilterSection: collapseFilterSection,
                    showFilterSection: showFilterSection,
                    createVehicle: createVehicle,
                    onSelectedCompany: onSelectedCompany,
                    onSelectedDepartemnt: onSelectedDepartemnt,
                    onDeleteVehicle: onDeleteVehicle,
                    onSaveVehicle: onSaveVehicle,
                    onEditVehicle: onEditVehicle,
                    onAddMaintenanceSchedule: onAddMaintenanceSchedule,
                    deleteMaintenanceSchedule: deleteMaintenanceSchedule,
                    onAddCheckListItem: onAddCheckListItem,
                    deleteCheckListItem: deleteCheckListItem
                    // Utility Methods

                };
            })()
        };
        return ist.vehicle.viewModel;
    });
