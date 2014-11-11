/*
    Module with the view model for the rentalAgreement
*/
define("rentalAgreement/rentalAgreement.viewModel",
    ["jquery", "amplify", "ko", "rentalAgreement/rentalAgreement.dataservice", "rentalAgreement/rentalAgreement.model", "common/pagination", "sammy"],
    function ($, amplify, ko, dataservice, model, pagination, sammy) {

        var ist = window.ist || {};
        ist.rentalAgreement = {
            viewModel: (function () {
                var// the view 
                    view,
                    // Callbacks
                    rentalAgreementModelCallbacks = {
                        OnCustomerNoChanged: function (value) {
                            getCustomerByNo(value);
                        },
                        OnNicChanged: function (value) {
                            getCustomerByNicNo(value);
                        },
                        OnPassportChanged: function (value) {
                            getCustomerByPassportNo(value);
                        },
                        OnLicenseChanged: function (value) {
                            getCustomerByLicenseNo(value);
                        },
                        OnPhoneChanged: function (value, type) {
                            getCustomerByPhoneNo(value, type);
                        },
                        OnRentalDurationChange: function () {
                            resetHireGroups();
                            // Set Vehicle Popup Start Date
                            vehicleStartDtFilter(moment(rentalAgreement().start()).toDate());
                            // Set Vehicle Popup End Date
                            vehicleEndDtFilter(moment(rentalAgreement().end()).toDate());
                        },
                        OnOutLocationChange: function () {
                            resetHireGroups();
                            // Set Vehicle Popup Out Location
                            vehicleOperationsWorkPlaceFilter(rentalAgreement().openLocation());
                        },
                        OnBookingNoChange: function (bookingId) {
                            loadByBooking(bookingId);
                        }
                    },
                    // Allocation Status Enums
                    allocationStatus = {
                        desired: 1,
                        upgraded: 2,
                        replaced: 3
                    },
                    // Vehicle Status Enums
                    vehicleStatusEnum = {
                        retired: 1,
                        available: 2,
                        reserved: 3,
                        onRent: 4,
                        theftStolen: 5,
                        totalLoss: 6,
                        damaged: 7
                    },
                    // RA Status Enums
                    raStatusEnum = {
                        open: 1,
                        close: 2,
                        paymentPending: 3,
                        systemGeneratedBooking: 4,
                        onlineBooking: 5,
                        reservation: 6,
                        convertedToAgreement: 7
                    },
                    // Main RA
                    rentalAgreement = ko.observable(model.RentalAgreement.Create({}, rentalAgreementModelCallbacks)),
                    // Currently Logged In User Default Settings
                    employeeDefaultSettings = ko.observable(),
                    // #region Arrays
                    // Operations
                    operations = ko.observableArray([]),
                    // Locations
                    locations = ko.observableArray([]),
                    // available locations
                    availableLocations = ko.computed(function () {
                        if (!rentalAgreement().operationId()) {
                            return [];
                        }

                        return locations.filter(function (location) {
                            return location.operationId === rentalAgreement().operationId();
                        });
                    }),
                    // payment terms
                    paymentTerms = ko.observableArray([]),
                    // payment modes
                    paymentModes = ko.observableArray([]),
                    // Vehicles
                    vehicles = ko.observableArray([]),
                    // Pagination
                    vehiclePager = ko.observable(),
                    // Service Items
                    serviceItems = ko.observableArray([]),
                    // Discounts
                    raDiscounts = ko.observableArray([]),
                    // Chauffers
                    chauffers = ko.observableArray([]),
                    // additional Charges
                    additionalCharges = ko.observableArray([]),
                    // Insurance Rates
                    insuranceRates = ko.observableArray([]),
                    // Opening RA from Booking
                    openingRaUsingBooking = ko.observable(false),
                    // Can Edit Booking No
                    canEditBooking = ko.computed(function () {
                        return !openingRaUsingBooking() && !rentalAgreement().id();
                    }),
                    // Booking Insurance
                    bookingInsurances = ko.observableArray([]),
                    // Chauffer Filter
                    chaufferFilter = ko.observable(model.Chauffer.Create({})),
                    // allocation statuses
                    allocationStatuses = ko.observableArray([]),
                    // vehicle statuses
                    vehicleStatuses = ko.observableArray([]),
                    // Can search hire group
                    canLookForHireGroups = ko.computed(function () {
                        return !rentalAgreement().id() && rentalAgreement().start() && rentalAgreement().end() && rentalAgreement().openLocation() &&
                            rentalAgreement().isHeaderValid();
                    }),
                    // selected Hire Group 
                    selectedHireGroup = ko.observable(),
                    // hireGroup Text
                    hireGroupText = ko.computed(function () {
                        return selectedHireGroup() ? selectedHireGroup().hireGroup : undefined;
                    }),
                    // Vehicle Start Dt Filter
                    vehicleStartDtFilter = ko.observable(moment(rentalAgreement().start()).toDate()),
                    // Vehicle End Dt Filter
                    vehicleEndDtFilter = ko.observable(moment(rentalAgreement().end()).toDate()),
                    // Is Valid Vehicle Duration 
                    isValidVehicleDuration = ko.computed(function () {
                        return vehicleEndDtFilter() > vehicleStartDtFilter() &&
                            (rentalAgreement().start() <= vehicleStartDtFilter() && rentalAgreement().end() >= vehicleEndDtFilter());
                    }),
                    // Vehicle OperationsWorkplace Filter
                    vehicleOperationsWorkPlaceFilter = ko.observable(),
                    // Vehicle Allocation Status Filter
                    vehicleAllocationStatusFilter = ko.observable(),
                    // select Hire Group
                    selectHireGroup = function (hireGroup) {
                        if (selectedHireGroup() !== hireGroup) {
                            selectedHireGroup(hireGroup);
                        }
                    },
                    // Selected Vehicle
                    selectedVehicle = ko.observable(model.Vehicle.Create({})),
                    // #endregion Arrays
                    // #region Utility Functions
                    selectVehicle = function (vehicle) {
                        if (selectedVehicle() !== vehicle) {
                            var vehicleStatus = getVehicleStatusByKey(vehicleStatusEnum.reserved);
                            var raHireGroup = model.RentalAgreementHireGroup.Create({
                                VehicleId: vehicle.id,
                                HireGroupDetailId: selectedHireGroup().id,
                                HireGroupDetail: { HireGroup: selectedHireGroup().code },
                                AllocationStatusKey: allocationStatus.desired,
                                AllocationStatusId: vehicleAllocationStatusFilter(),
                                RaMainId: rentalAgreement().id(),
                                Vehicle: vehicle,
                                VehicleMovements: [
                                    {
                                        OperationsWorkPlaceId: rentalAgreement().openLocation(),
                                        Odometer: vehicle.currentOdometer,
                                        VehicleStatusId: vehicleStatus ? vehicleStatus.id : vehicle.vehicleStatudId,
                                        DtTime: moment(rentalAgreement().start()).toDate(),
                                        FuelLevel: vehicle.fuelLevel,
                                        Status: model.vehicleMovementEnum.outMovement
                                    },
                                    {
                                        OperationsWorkPlaceId: rentalAgreement().openLocation(),
                                        DtTime: moment(rentalAgreement().end()).toDate(),
                                        FuelLevel: vehicle.fuelLevel,
                                        Status: model.vehicleMovementEnum.inMovement
                                    }
                                ]
                            }, false, rentalAgreement());
                            selectedVehicle(vehicle);
                            rentalAgreement().rentalAgreementHireGroups.push(raHireGroup);

                            // Add Insurance if it being opened from booking
                            if (openingRaUsingBooking() && bookingInsurances().length > 0) {
                                bookingInsurances.each(function (insurance) {
                                    insurance.start(moment(vehicleStartDtFilter()).toDate());
                                    insurance.end(moment(vehicleEndDtFilter()).toDate());
                                    raHireGroup.raHireGroupInsurances.push(insurance);
                                });
                            }

                            // Close vehicle Dialog
                            view.hideVehicleDialog();

                            calculateBill();
                        }
                    },
                    // Stop Event Bubbling
                    stopEventBubbling = function (data, e) {
                        e.stopImmediatePropagation();
                    },
                    // Open Extras Dialog
                    openExtrasDialog = function () {
                        resetServiceItemsSelection();
                        view.showExtrasDialog();
                    },
                    // Add Selected Extras to Rental Agreement
                    // Data - Binding Data
                    // PopoverId - Id 
                    // Panel - Id of the Panel to Expand if collapsed
                    addExtrasToRentalAgreement = function (data, panel) {
                        serviceItems.each(function (serviceItem) {
                            if (serviceItem.isSelected()) {
                                var raServiceItem = model.RentalAgreementServiceItem.Create(serviceItem.convertToServerData(), rentalAgreement());
                                raServiceItem.start(moment(rentalAgreement().start()).toDate());
                                raServiceItem.end(moment(rentalAgreement().end()).toDate());
                                raServiceItem.rentalAgreementId(rentalAgreement().id() || 0);
                                rentalAgreement().rentalAgreementServiceItems.push(raServiceItem);
                            }
                        });
                        // Close Extras Dialog
                        view.hideExtrasDialog();
                        // Expand Panel
                        view.expandPanel(panel);
                    },
                    // Reset Service Items Selection
                    resetServiceItemsSelection = function () {
                        serviceItems.each(function (serviceItem) {
                            serviceItem.isSelected(false);
                        });
                    },
                    // Open Chauffer Dialog
                    openChaufferDialog = function() {
                        // Set Filters
                        setChaufferPopover();
                        // Show Dialog
                        view.showChaufferDialog();
                    },
                    // Set Chauffer Popover
                    setChaufferPopover = function () {
                        chaufferFilter().start(moment(rentalAgreement().start()).toDate());
                        chaufferFilter().end(moment(rentalAgreement().end()).toDate());
                        // Reset Chauffers Selection
                        resetChauffersSelection();
                    },
                    // Can Search Chauffers
                    canSearchChauffers = ko.computed(function () {
                        return rentalAgreement().openLocation() && chaufferFilter().start() && chaufferFilter().end();
                    }),
                    // Search Chauffers
                    searchChauffers = function () {
                        getChauffers();
                    },
                    // Add Selected Chauffers to Rental Agreement
                    addChauffersToRentalAgreement = function (data, panel) {
                        chauffers.each(function (chauffer) {
                            if (chauffer.isSelected()) {
                                var driver = chauffer.convertToServerData();
                                driver.IsChauffer = true;
                                driver.StartDtTime = moment(rentalAgreement().start()).toDate();
                                driver.EndDtTime = moment(rentalAgreement().end()).toDate();
                                driver.RaMainId = rentalAgreement().id() || 0;
                                rentalAgreement().rentalAgreementDrivers.push(model.RentalAgreementDriver.Create(driver, rentalAgreement()));
                            }
                        });
                        // Close Dialog
                        view.hideChaufferDialog();
                        // Expand Panel
                        view.expandPanel(panel);
                    },
                    // Reset Chauffers Selection
                    resetChauffersSelection = function () {
                        chauffers.each(function (chauffer) {
                            chauffer.isSelected(false);
                        });
                    },
                    // Add Driver To Rental Agreement
                    addDriverToRentalAgreement = function (data, panel) {
                        var driver = model.RentalAgreementDriver.Create({
                            IsChauffer: false, StartDtTime: moment(rentalAgreement().start()).toDate(),
                            EndDtTime: moment(rentalAgreement().end()).toDate(), RaMainId: rentalAgreement().id() || 0
                        }, rentalAgreement());
                        rentalAgreement().rentalAgreementDrivers.push(driver);
                        // Expand Panel
                        view.expandPanel(panel);
                    },
                    // Plate Numbers To Select From For Additional Charge
                    plateNumbers = ko.computed(function () {
                        if (rentalAgreement().rentalAgreementHireGroups().length === 0) {
                            return [];
                        }

                        return rentalAgreement().rentalAgreementHireGroups.map(function (raHireGroup) {
                            return raHireGroup.vehicle().plateNumber();
                        });
                    }),
                    // Open Add Charges Dialog
                    openAddChargesDialog = function () {
                        // Reset Selection
                        resetAdditionalChargesSelection();
                        // Show Dialog
                        view.showDamagesDialog();
                    },
                    // Add Additional Charges to Rental Agreement
                    addAdditionalChargesToRentalAgreement = function (data, panel) {
                        additionalCharges.each(function (additionalCharge) {
                            if (additionalCharge.isSelected()) {
                                var addCharge = additionalCharge.convertToServerData();
                                addCharge.HireGroupDetailId = selectedHireGroup() ? selectedHireGroup().id : undefined;
                                addCharge.RaMainId = rentalAgreement().id() || 0;
                                rentalAgreement().rentalAgreementAdditionalCharges.push(model.RentalAgreementAdditionalCharge.Create(addCharge));
                            }
                        });
                        // Close Dialog
                        view.hideDamagesDialog();
                        // Expand Panel
                        view.expandPanel(panel);
                    },
                    // Reset Additional Charges Selection
                    resetAdditionalChargesSelection = function () {
                        additionalCharges.each(function (additionalCharge) {
                            additionalCharge.isSelected(false);
                        });
                    },
                    // Selected Ra Hire Group
                    selectedRaHireGroup = ko.observable(model.RentalAgreementHireGroup.Create({ Vehicle: model.Vehicle.Create({}) }, false, rentalAgreement())),
                    // Select Ra HireGroup
                    selectRaHireGroup = function (raHireGroup) {
                        if (selectedRaHireGroup() !== raHireGroup) {
                            selectedRaHireGroup(raHireGroup);
                            // Select Vehicle
                            selectedVehicle(raHireGroup.vehicle);
                            setRaHireGroupInsurances();
                        }
                    },
                    // Open vehicle dialog
                    openVehicleDialog = function() {
                        // Set Filters
                        setVehicleFilters();
                        // Show Dialog
                        view.showVehicleDialog();
                    },
                    // Set Vehicle Popover Filters
                    setVehicleFilters = function () {
                        var allocationStatusItem = getAllocationStatusByKey(allocationStatus.desired);
                        vehicleAllocationStatusFilter(allocationStatusItem ? allocationStatusItem.id : undefined);
                        vehicleOperationsWorkPlaceFilter(rentalAgreement().openLocation());
                    },
                    // Open Ra Hire Group Insurance Dialog
                    openRaHireGroupInsuranceDialog = function () {
                        view.show();
                    },
                    // Set Ra HireGroup Insurances
                    setRaHireGroupInsurances = function () {
                        insuranceRates.each(function (insuranceRt) {
                            var raHireGroupIns = selectedRaHireGroup().raHireGroupInsurances.find(function (raHireGroupInsurance) {
                                return raHireGroupInsurance.insuranceTypeId() === insuranceRt.id;
                            });
                            if (!raHireGroupIns) {
                                selectedRaHireGroup().raHireGroupInsurances
                                    .push(model.RentalAgreementHireGroupInsurance.Create({
                                        InsuranceTypeId: insuranceRt.id,
                                        RaHireGroupId: selectedRaHireGroup().id(),
                                        InsuranceTypeCodeName: insuranceRt.codeName,
                                        StartDtTime: moment(vehicleStartDtFilter()).toDate(),
                                        EndDtTime: moment(vehicleEndDtFilter()).toDate()
                                    }, rentalAgreement()));
                            }
                        });
                    },
                    // Add Payment To Rental Agreement
                    addPaymentToRentalAgreement = function (data, panel) {
                        var payment = model.RentalAgreementPayment.Create({
                            RaMainId: rentalAgreement().id() || 0
                        });
                        rentalAgreement().raPayments.push(payment);
                        // Expand Panel
                        view.expandPanel(panel);
                    },
                    // Open Vehicle Movement Dialog
                    openVehicleMovementDialog = function() {
                        view.showVehicleMovementDialog();
                    },
                    // Hide Vehicle Movement Dialog
                    hideVehicleMovementDialog = function() {
                        view.hideVehicleMovementDialog();
                    },
                    // Open Discounts Dialog
                    openDiscountsDialog = function () {
                        view.showDiscountsDialog();
                    },
                    // Add Discounts to Ra
                    addDiscountsToRentalAgreement = function (data, panelId) {
                        // Close Dialog
                        view.hideDiscountsDialog();
                        // Expand Panel
                        view.expandPanel(panelId);
                    },
                    // #endregion Utility Functions
                    // #region Observables
                    // Initialize the view model
                    initialize = function (specifiedView) {
                        view = specifiedView;

                        ko.applyBindings(view.viewModel, view.bindingRoot);

                        getBase();

                        // Set Pager
                        vehiclePager(pagination.Pagination({}, vehicles, getVehicles));

                        // Get Service Items
                        getServiceItems();

                        // Get Additional Charges
                        getAdditionalCharges();

                        // Get Insurance Rates
                        getInsuranceRates();
                    },
                    // Sammy root
                    app = sammy(function () {
                        this.get("#/byId/:raMainId", function () {
                            load(this.params["raMainId"]);
                        });
                    }),
                    // Get Base
                    getBase = function () {
                        dataservice.getBase({
                            success: function (data) {
                                var operationItems = [], locationItems = [], paymentTermItems = [], allocationStatusItems = [],
                                    vehicleStatusItems = [], paymentModeItems = [];
                                // Operations
                                _.each(data.Operations, function (operation) {
                                    operationItems.push(model.Operation.Create(operation));
                                });
                                ko.utils.arrayPushAll(operations(), operationItems);
                                operations.valueHasMutated();

                                // Locations
                                _.each(data.OperationsWorkPlaces, function (operationWorkPlace) {
                                    locationItems.push(model.OperationsWorkPlace.Create(operationWorkPlace));
                                });
                                ko.utils.arrayPushAll(locations(), locationItems);
                                locations.valueHasMutated();

                                // Payment Terms
                                _.each(data.PaymentTerms, function (paymentTerm) {
                                    paymentTermItems.push(model.PaymentTerm.Create(paymentTerm));
                                });
                                ko.utils.arrayPushAll(paymentTerms(), paymentTermItems);
                                paymentTerms.valueHasMutated();

                                // Allocation Status
                                _.each(data.AllocationStatuses, function (allocationStatusItem) {
                                    allocationStatusItems.push(model.AllocationStatus.Create(allocationStatusItem));
                                });
                                ko.utils.arrayPushAll(allocationStatuses(), allocationStatusItems);
                                allocationStatuses.valueHasMutated();

                                // Vehicle Statuses
                                _.each(data.VehicleStatuses, function (vehicleStatus) {
                                    vehicleStatusItems.push(model.VehicleStatus.Create(vehicleStatus));
                                });
                                ko.utils.arrayPushAll(vehicleStatuses(), vehicleStatusItems);
                                vehicleStatuses.valueHasMutated();

                                // Payment Modes
                                _.each(data.PaymentModes, function (paymentMode) {
                                    paymentModeItems.push(model.PaymentMode.Create(paymentMode));
                                });
                                ko.utils.arrayPushAll(paymentModes(), paymentModeItems);
                                paymentModes.valueHasMutated();

                                // Default Settings if any
                                if (data.DefaultSetting) {
                                    employeeDefaultSettings(data.DefaultSetting);

                                    // Set Default Settings For RA for Current Employee
                                    rentalAgreement().operationId(employeeDefaultSettings().DefaultOperationId || undefined);
                                    rentalAgreement().openLocation(employeeDefaultSettings().DefaultOperationWorkplaceId || undefined);
                                    rentalAgreement().closeLocation(employeeDefaultSettings().DefaultOperationWorkplaceId || undefined);
                                    rentalAgreement().paymentTermId(employeeDefaultSettings().DefaultPaymentTermId || undefined);
                                }

                                // Run Sammy
                                app.run();
                            },
                            error: function (response) {
                                toastr.error("Failed to load base data. Error: " + response);
                            }
                        });
                    },
                    // Reset Hire Groups
                    resetHireGroups = function () {
                        selectedHireGroup(undefined);
                        vehicles.removeAll();
                        if (!rentalAgreement().id()) {
                            rentalAgreement().rentalAgreementHireGroups.removeAll();
                            selectedVehicle(model.Vehicle.Create({}));
                        }
                    },
                    // Get Chauffers
                    getChauffers = function () {
                        dataservice.getChauffers({
                            OperationsWorkPlaceId: rentalAgreement().openLocation(),
                            StartDtTime: moment(chaufferFilter().start()).format(ist.utcFormat) + 'Z',
                            EndDtTime: moment(chaufferFilter().end()).format(ist.utcFormat) + 'Z',
                        }, {
                            success: function (data) {
                                var chauffersItems = [];

                                _.each(data, function (chauffer) {
                                    chauffersItems.push(model.Chauffer.Create(chauffer));
                                });

                                ko.utils.arrayPushAll(chauffers(), chauffersItems);
                                chauffers.valueHasMutated();
                            },
                            error: function (response) {
                                toastr.error("Failed to load Chauffers. Error: " + response);
                            }
                        });
                    },
                    // Get ServiceItems
                    getServiceItems = function () {
                        dataservice.getServiceItems({
                            success: function (data) {
                                var services = [];

                                _.each(data, function (serviceItem) {
                                    services.push(model.ServiceItem.Create(serviceItem));
                                });

                                ko.utils.arrayPushAll(serviceItems(), services);
                                serviceItems.valueHasMutated();
                            },
                            error: function (response) {
                                toastr.error("Failed to load Service Items. Error: " + response);
                            }
                        });
                    },
                    // Get Additional Charges
                    getAdditionalCharges = function () {
                        dataservice.getAdditionalCharges({
                            success: function (data) {
                                var additionalChargeItems = [];

                                _.each(data, function (additionalCharge) {
                                    additionalChargeItems.push(model.AdditionalCharge.Create(additionalCharge));
                                });

                                ko.utils.arrayPushAll(additionalCharges(), additionalChargeItems);
                                additionalCharges.valueHasMutated();
                            },
                            error: function (response) {
                                toastr.error("Failed to load Additional Charges. Error: " + response);
                            }
                        });
                    },
                    // Get Insurance Rates
                    getInsuranceRates = function () {
                        dataservice.getInsuranceRates({
                            success: function (data) {
                                var insuranceItems = [];

                                _.each(data, function (insurance) {
                                    insuranceItems.push(model.InsuranceType.Create(insurance));
                                });

                                ko.utils.arrayPushAll(insuranceRates(), insuranceItems);
                                insuranceRates.valueHasMutated();
                            },
                            error: function (response) {
                                toastr.error("Failed to load Insurances. Error: " + response);
                            }
                        });
                    },
                    // Can Search Vehicles
                    canSearchVehicles = ko.computed(function () {
                        return selectedHireGroup() && vehicleStartDtFilter() && vehicleEndDtFilter() && vehicleOperationsWorkPlaceFilter() &&
                            vehicleAllocationStatusFilter() && isValidVehicleDuration();
                    }),
                    // Search Vehicles
                    searchVehicles = function () {
                        getVehicles();
                    },
                    // Get Vehicle Status By Key
                    getVehicleStatusByKey = function (key) {
                        return vehicleStatuses.find(function (vehicleStatus) {
                            return vehicleStatus.key === key;
                        });
                    },
                    // Get Allocation Status By Key
                    getAllocationStatusByKey = function (key) {
                        return allocationStatuses.find(function (allocationStatusItem) {
                            return allocationStatusItem.key === key;
                        });
                    },
                    // Get Allocation Status By Id
                    getAllocationStatusById = function (id) {
                        return allocationStatuses.find(function (allocationStatusItem) {
                            return allocationStatusItem.id === id;
                        });
                    },
                    // Get Vehicles
                    getVehicles = function () {
                        var allocationStatusItem = getAllocationStatusById(vehicleAllocationStatusFilter());

                        dataservice.getVehiclesByHireGroup({
                            HireGroupDetailId: selectedHireGroup().id,
                            StartDtTime: moment(vehicleStartDtFilter()).format(ist.utcFormat) + 'Z',
                            EndDtTime: moment(vehicleEndDtFilter()).format(ist.utcFormat) + 'Z',
                            OperationsWorkPlaceId: vehicleOperationsWorkPlaceFilter(),
                            AllocationStatusKey: allocationStatusItem ? allocationStatusItem.key : undefined
                        }, {
                            success: function (data) {
                                vehicles.removeAll();

                                var vehicleItems = [];

                                _.each(data.Vehicles, function (vehicle) {
                                    vehicleItems.push(model.Vehicle.Create(vehicle));
                                });

                                vehiclePager().totalCount(data.TotalCount);
                                ko.utils.arrayPushAll(vehicles(), vehicleItems);
                                vehicles.valueHasMutated();
                            },
                            error: function (response) {
                                toastr.error("Failed to load vehicles. Error: " + response);
                            }
                        });
                    },
                    // Calculate Bill
                    calculateBill = function () {
                        var rentalBillRequest = rentalAgreement().convertToServerData();
                        dataservice.calculateBill(rentalBillRequest, {
                            success: function (data) {
                                rentalAgreement().billing(model.Billing.Create(data));
                            },
                            error: function (response) {
                                toastr.error("Failed to calculate bill. Error: " + response);
                            }
                        });
                    },
                    // Can Open Rental Agreement
                    canOpen = ko.computed(function () {
                        return !rentalAgreement().id() || rentalAgreement().raStatusId() == raStatusEnum.close;
                    }),
                    // Open Rental Agreement
                    openRentalAgreement = function () {
                        saveRentalAgreement(raStatusEnum.open);
                    },
                    // Validate Drivers
                    validateDrivers = function () {
                        rentalAgreement().rentalAgreementDrivers.each(function (raDriver) {
                            if (!raDriver.isValid()) {
                                raDriver.errors.showAllMessages();

                                var driverText = raDriver.isChauffer() ? "Chauffer " : "Driver ";

                                // If Invalid Period
                                if (raDriver.isInvalidPeriod()) {
                                    toastr.info("Selected " + driverText + "Start and End Date/Time should be between Rental Dates!");
                                }

                                // If License Expired
                                if (raDriver.isLicenseExpired()) {
                                    toastr.info("Selected " + driverText + "License has expired!");
                                }
                            }
                        });
                    },
                    // Validate Add Charges
                    validateAddCharges = function () {
                        rentalAgreement().rentalAgreementAdditionalCharges.each(function (raAdditionalCharge) {
                            if (!raAdditionalCharge.isValid()) {
                                raAdditionalCharge.errors.showAllMessages();
                            }
                        });
                    },
                    // Validate Extras
                    validateExtras = function () {
                        rentalAgreement().rentalAgreementServiceItems.each(function (raServiceItem) {
                            if (!raServiceItem.isValid()) {
                                raServiceItem.errors.showAllMessages();

                                // If Invalid Period
                                if (raServiceItem.isInvalidPeriod()) {
                                    toastr.info("Selected Service Item(s) Start and End Date/Time should be between Rental Dates!");
                                }
                            }
                        });
                    },
                    // Validate Chauffers
                    validateChauffers = function () {
                        // Check for Overlapping Chauffers
                        var isOverlapping = false;
                        var chauffer, internalChauffer;
                        for (var i = 0; i < rentalAgreement().raChauffers().length - 1 ; i++) {
                            chauffer = rentalAgreement().raChauffers()[i];
                            for (var j = i + 1; j < rentalAgreement().raChauffers().length - 1; j++) {
                                internalChauffer = rentalAgreement().raChauffers()[j];
                                if (chauffer.id() === internalChauffer().id() && !isOverlapping) {
                                    isOverlapping = chauffer.end() > internalChauffer().start() && internalChauffer().end() < chauffer().start();
                                    break;
                                }
                            }
                        }
                        return isOverlapping;
                    },
                    // Validate HireGroup insurances
                    validateInsurances = function () {
                        rentalAgreement().rentalAgreementHireGroups.each(function (raHireGroup) {
                            if (!raHireGroup.isValid()) {
                                raHireGroup.raHireGroupInsurances.each(function (raHireGroupInsurance) {
                                    if (raHireGroupInsurance().isSelected() && !raHireGroupInsurance.isValid()) {
                                        raHireGroupInsurance.errors.showAllMessages();
                                    }
                                });
                            }
                        });
                    },
                    // Validate Errors
                    validateErrors = function () {
                        if (!rentalAgreement().isValid()) {
                            rentalAgreement().errors.showAllMessages();
                            if (!rentalAgreement().businessPartner().isValid()) {
                                rentalAgreement().businessPartner().errors.showAllMessages();
                                if (rentalAgreement().businessPartner().isIndividual() && !rentalAgreement().businessPartner().businessPartnerIndividual().isValid()) {
                                    rentalAgreement().businessPartner().businessPartnerIndividual().errors.showAllMessages();

                                    // Validate Age
                                    if (!rentalAgreement().businessPartner().businessPartnerIndividual().isAgeValid()) {
                                        toastr.info("Customer age must be 21 years minimum!");
                                    }

                                    // Validate License
                                    if (rentalAgreement().businessPartner().businessPartnerIndividual().isLicenseExpired()) {
                                        toastr.info("Customer License has expired!");
                                    }
                                }
                            }

                            // Validate Drivers
                            validateDrivers();

                            // Validate Additional Charges
                            validateAddCharges();

                            // Validate Service items
                            validateExtras();

                            // Validate Hire Group Insurances
                            validateInsurances();

                            return false;
                        }
                        return true;
                    },
                    // Validate Before Opening Agreement
                    validateBeforeSave = function () {
                        // Validate Validation Errors
                        if (!validateErrors()) {
                            return;
                        }

                        // Chauffers Overlap
                        if (validateChauffers()) {
                            toastr.info("Selected Chauffers are overlapping, please adjust their duration!");
                            return;
                        }

                        // Validate Hire Group
                        if (rentalAgreement().rentalAgreementHireGroups().length === 0) {
                            toastr.info("Vehicle not selected");
                            return;
                        }
                    },
                    // Can Update Rental Agreement
                    canUpdate = ko.computed(function () {
                        return rentalAgreement().id() && rentalAgreement().raStatusId() != raStatusEnum.close;
                    }),
                    // Update Rental Agreement
                    updateRentalAgreement = function () {
                        saveRentalAgreement(raStatusEnum.open);
                    },
                    // Can Close Rental Agreement
                    canClose = ko.computed(function () {
                        return rentalAgreement().id() && rentalAgreement().raStatusId() != raStatusEnum.close;
                    }),
                    // Close Rental Agreement
                    closeRentalAgreement = function () {
                        // Validate Rental Agreement Before Close
                        if (!validateBeforeClose()) {
                            return;
                        }
                        if (!rentalAgreement().isValid()) {
                            toastr.info("Please fix errors first!");
                            return;
                        }

                        saveRentalAgreement(raStatusEnum.close);
                    },
                    // Validate Before Close
                    validateBeforeClose = function () {
                        // Validate Bill
                        if (!validateBill() || !validateVehicle()) {
                            return false;
                        }

                        return true;
                    },
                    // Validate Bill
                    validateBill = function () {
                        if (rentalAgreement().billing().balance() > 0) {
                            toastr.info("Can not close agreement because payment is pending.");
                            return false;
                        }
                        return true;
                    },
                    // Validate Vehicle
                    validateVehicle = function () {
                        var vehiclesNotReturned = rentalAgreement().rentalAgreementHireGroups.filter(function (raHireGroup) {
                            return !raHireGroup.vehicleMovementIn().odometer || !raHireGroup.vehicleMovementIn().operationsWorkPlaceId() ||
                            !raHireGroup.vehicleMovementIn().vehicleStatusId();
                        });

                        if (vehiclesNotReturned.length > 0) {
                            toastr.info("One of the Vehicle(s) not returned");
                            return false;
                        }

                        return true;
                    },
                    // Get Desired Hire Group
                    getDesiredHireGroup = function (raMain) {
                        var raHireGroupItem = _.find(raMain.RaHireGroups, function (raHireGroup) {
                            return raHireGroup.AllocationStatusKey === allocationStatus.desired;
                        });

                        return raHireGroupItem ? raHireGroupItem.HireGroupDetail : undefined;
                    },
                    // Select Desired Hire Group
                    selectDesiredHireGroup = function (hireGroup) {
                        if (!hireGroup) {
                            return;
                        }

                        selectHireGroup(model.HireGroupDetail.Create(hireGroup));
                    },
                    // Load Rental Agreement
                    load = function (raMainId) {
                        openingRaUsingBooking(false);

                        dataservice.getRentalAgreement({ id: raMainId }, {
                            success: function (data) {
                                // Set Ra Main
                                rentalAgreement(model.RentalAgreement.Create(data, rentalAgreementModelCallbacks, true));

                                // Select Desired Hire Group
                                selectDesiredHireGroup(getDesiredHireGroup(data));
                            },
                            error: function (response) {
                                toastr.error("Failed to load Rental Agreement. Error: " + response);
                            }
                        });
                    },
                    // Load Rental Agreement
                    loadByBooking = function (bookingMainId) {
                        openingRaUsingBooking(true);

                        dataservice.getRentalAgreementByBooking({ id: bookingMainId }, {
                            success: function (data) {
                                // If no Booking Found
                                if (!data) {
                                    openingRaUsingBooking(false);
                                    return;
                                }

                                var desiredHireGroup = undefined;
                                // Look for Added Insurances - Need to add to the vehicle
                                if (data.RaHireGroups.length > 0) {
                                    var insuranceItems = [];

                                    _.each(data.RaHireGroups[0].RaHireGroupInsurances, function (insurance) {
                                        var insuranceItem = model.RentalAgreementHireGroupInsurance.Create(insurance, rentalAgreement());
                                        insuranceItem.isSelected(true);
                                        insuranceItems.push(insuranceItem);
                                    });

                                    ko.utils.arrayPushAll(bookingInsurances(), insuranceItems);
                                    bookingInsurances.valueHasMutated();

                                    // Keep Desired Hire Group
                                    desiredHireGroup = data.RaHireGroups[0].HireGroupDetail;

                                    // Reset RaHireGroups
                                    data.RaHireGroups = [];
                                }

                                // Set Ra Main
                                rentalAgreement(model.RentalAgreement.Create(data, rentalAgreementModelCallbacks, true));

                                // Select Desired Hire Group
                                selectDesiredHireGroup(desiredHireGroup);

                            },
                            error: function (response) {
                                openingRaUsingBooking(false);
                                toastr.error("Failed to load Rental Agreement. Error: " + response);
                            }
                        });
                    },
                    // Save Rental Agreement
                    saveRentalAgreement = function (action) {
                        if (!validateBeforeSave()) {
                            return;
                        }

                        var raMain = rentalAgreement().convertToServerData();
                        var saveRaRequest = {
                            RaMain: raMain,
                            Action: action
                        };
                        dataservice.saveRentalAgreement(saveRaRequest, {
                            success: function (data) {
                                if (data && data.RaMainId > 0) {
                                    load(data.RaMainId);
                                }
                                toastr.success("Agreement saved successfully!");
                            },
                            error: function (response) {
                                toastr.error("Failed to process request. Error: " + response);
                            }
                        });
                    },
                    // Add Vehicle CheckLists Out
                    addVehicleCheckListsOutToRa = function (raHireGroup, e) {
                        selectRaHireGroup(raHireGroup);
                        getVehicleCheckLists(model.vehicleMovementEnum.outMovement);
                        view.showRaVehicleCheckListDialog(model.vehicleMovementEnum.outMovement);
                        e.stopImmediatePropagation();
                    },
                    // Add Vehicle CheckLists In
                    addVehicleCheckListsInToRa = function (raHireGroup, e) {
                        selectRaHireGroup(raHireGroup);
                        getVehicleCheckLists(model.vehicleMovementEnum.inMovement);
                        view.showRaVehicleCheckListDialog(model.vehicleMovementEnum.inMovement);
                        e.stopImmediatePropagation();
                    },
                    // Get CheckLists For Vehicle
                    getVehicleCheckLists = function (status) {
                        if (!selectedRaHireGroup() || !selectedRaHireGroup().vehicle()) {
                            return;
                        }

                        dataservice.getCheckListsForVehicle({ VehicleId: selectedRaHireGroup().vehicle().id }, {
                            success: function (data) {
                                // Set Vehicle CheckLists into RA
                                addVehicleCheckListsToRa(data, status);
                            },
                            error: function (response) {
                                toastr.error("Failed to load checklists for vehicle. Error: " + response);
                            }
                        });
                    },
                    // Add Vehicle CheckLists To RA
                    addVehicleCheckListsToRa = function (data, status) {
                        _.each(data, function (vehicleCheckList) {
                            vehicleCheckList = model.VehicleCheckList.Create(vehicleCheckList);

                            var raVehicleChkList = selectedRaHireGroup().raVehicleCheckLists.find(function (raVehicleCheckList) {
                                return raVehicleCheckList.vehicleCheckListId() === vehicleCheckList.id && raVehicleCheckList.status() === status;
                            });

                            if (!raVehicleChkList) {
                                selectedRaHireGroup().raVehicleCheckLists.push(model.RentalAgreementVehicleCheckList.Create({
                                    VehicleCheckListId: vehicleCheckList.id,
                                    RaHireGroupId: selectedRaHireGroup().id() || 0,
                                    VehicleCheckListKey: vehicleCheckList.key,
                                    VehicleCheckListCodeName: vehicleCheckList.codeName,
                                    IsInterior: vehicleCheckList.isInterior,
                                    RaVehicleCheckListDescription: vehicleCheckList.description,
                                    Status: status
                                }));
                            }
                        });
                    },
                    // Get Customer Call back Handler
                    getCustomerCallbackHandler = {
                        success: function (data) {
                            if (!data) {
                                return;
                            }
                            rentalAgreement().businessPartner(model.BusinessPartner.Create(data, rentalAgreementModelCallbacks));
                        },
                        error: function (response) {
                            toastr.error("Failed to load customer. Error: " + response);
                        }
                    },
                    // Is Existing
                    isExistingBusinessPartner = ko.observable(false),
                    // Set Existing True
                    setExistingTrue = function() {
                        isExistingBusinessPartner(true);
                    },
                    // Set Existing False
                    setExistingFalse = function() {
                        isExistingBusinessPartner(false);
                    },
                    // Get Customer By Customer No
                    getCustomerByNo = function (customerNo) {
                        if (!isExistingBusinessPartner()) {
                            return;
                        }

                        dataservice.getCustomerByNo({
                            BusinessPartnerId: customerNo
                        }, getCustomerCallbackHandler);
                    },
                    // Get Customer By Nic No
                    getCustomerByNicNo = function (nicNo) {
                        if (!isExistingBusinessPartner()) {
                            return;
                        }

                        dataservice.getCustomerByNicNo({
                            NicNo: nicNo
                        }, getCustomerCallbackHandler);
                    },
                    // Get Customer By Passport No
                    getCustomerByPassportNo = function (passportNo) {
                        if (!isExistingBusinessPartner()) {
                            return;
                        }

                        dataservice.getCustomerByPassportNo({
                            PassportNo: passportNo
                        }, getCustomerCallbackHandler);
                    },
                    // Get Customer By License No
                    getCustomerByLicenseNo = function (licenseNo) {
                        if (!isExistingBusinessPartner()) {
                            return;
                        }

                        dataservice.getCustomerByLicenseNo({
                            LicenseNo: licenseNo
                        }, getCustomerCallbackHandler);
                    },
                    // Get Customer By Phone No
                    getCustomerByPhoneNo = function (phoneNo, type) {
                        if (!isExistingBusinessPartner()) {
                            return;
                        }

                        dataservice.getCustomerByPhoneNo({
                            PhoneNo: phoneNo,
                            PhoneType: type
                        }, getCustomerCallbackHandler);
                    };
                // #endregion Service Calls

                return {
                    // Observables
                    operations: operations,
                    vehicles: vehicles,
                    paymentTerms: paymentTerms,
                    selectedVehicle: selectedVehicle,
                    selectHireGroup: selectHireGroup,
                    rentalAgreement: rentalAgreement,
                    model: model,
                    canLookForHireGroups: canLookForHireGroups,
                    serviceItems: serviceItems,
                    chauffers: chauffers,
                    raDiscounts: raDiscounts,
                    chaufferFilter: chaufferFilter,
                    canSearchChauffers: canSearchChauffers,
                    canSearchVehicles: canSearchVehicles,
                    hireGroupText: hireGroupText,
                    additionalCharges: additionalCharges,
                    insuranceRates: insuranceRates,
                    allocationStatuses: allocationStatuses,
                    vehicleStatuses: vehicleStatuses,
                    vehicleStartDtFilter: vehicleStartDtFilter,
                    vehicleEndDtFilter: vehicleEndDtFilter,
                    vehicleOperationsWorkPlaceFilter: vehicleOperationsWorkPlaceFilter,
                    vehicleAllocationStatusFilter: vehicleAllocationStatusFilter,
                    vehicleStatusEnum: vehicleStatusEnum,
                    availableLocations: availableLocations,
                    selectedRaHireGroup: selectedRaHireGroup,
                    selectRaHireGroup: selectRaHireGroup,
                    paymentModes: paymentModes,
                    plateNumbers: plateNumbers,
                    canEditBooking: canEditBooking,
                    isValidVehicleDuration: isValidVehicleDuration,
                    isExistingBusinessPartner: isExistingBusinessPartner,
                    setExistingTrue: setExistingTrue,
                    setExistingFalse: setExistingFalse,
                    // Observables
                    // Utility Methods
                    initialize: initialize,
                    selectVehicle: selectVehicle,
                    stopEventBubbling: stopEventBubbling,
                    calculateBill: calculateBill,
                    getChauffers: getChauffers,
                    getServiceItems: getServiceItems,
                    addExtrasToRentalAgreement: addExtrasToRentalAgreement,
                    resetServiceItemsSelection: resetServiceItemsSelection,
                    addChauffersToRentalAgreement: addChauffersToRentalAgreement,
                    resetChauffersSelection: resetChauffersSelection,
                    addDriverToRentalAgreement: addDriverToRentalAgreement,
                    setChaufferPopover: setChaufferPopover,
                    searchChauffers: searchChauffers,
                    searchVehicles: searchVehicles,
                    addAdditionalChargesToRentalAgreement: addAdditionalChargesToRentalAgreement,
                    resetAdditionalChargesSelection: resetAdditionalChargesSelection,
                    getInsuranceRates: getInsuranceRates,
                    getVehicleStatusByKey: getVehicleStatusByKey,
                    getAllocationStatusByKey: getAllocationStatusByKey,
                    setVehicleFilters: setVehicleFilters,
                    setRaHireGroupInsurances: setRaHireGroupInsurances,
                    openRaHireGroupInsuranceDialog: openRaHireGroupInsuranceDialog,
                    openRentalAgreement: openRentalAgreement,
                    closeRentalAgreement: closeRentalAgreement,
                    updateRentalAgreement: updateRentalAgreement,
                    canOpen: canOpen,
                    canUpdate: canUpdate,
                    canClose: canClose,
                    addPaymentToRentalAgreement: addPaymentToRentalAgreement,
                    addVehicleCheckListsOutToRa: addVehicleCheckListsOutToRa,
                    addVehicleCheckListsInToRa: addVehicleCheckListsInToRa,
                    openExtrasDialog: openExtrasDialog,
                    openChaufferDialog: openChaufferDialog,
                    openAddChargesDialog: openAddChargesDialog,
                    openVehicleDialog: openVehicleDialog,
                    openVehicleMovementDialog: openVehicleMovementDialog,
                    hideVehicleMovementDialog: hideVehicleMovementDialog,
                    openDiscountsDialog: openDiscountsDialog,
                    addDiscountsToRentalAgreement: addDiscountsToRentalAgreement
                    // Utility Methods
                };
            })()
        };
        return ist.rentalAgreement.viewModel;
    });
