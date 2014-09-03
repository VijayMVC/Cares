/*
    Module with the model for the Vehicle
*/
define(["ko", "underscore", "underscore-ko"], function (ko) {
    var
     //Vehicle List View entity
    // ReSharper disable once InconsistentNaming
    Vehicle = function () {
        // ReSharper restore InconsistentNaming
        var // Reference to this object
            self,
            // Unique key
            vehicleId = ko.observable(),
            //  Vehicle Name
            vehicleName = ko.observable(),
            //plate Number
            plateNumber = ko.observable(),
            //Current Odometer
            currentOdometer = ko.observable(),
            //Fuel Level
            fuelLevel = ko.observable(),
            //Model Year
            modelYear = ko.observable(),
            //Vehicle Make Code Name
            vehicleMakeCodeName = ko.observable(),
            //Vehicle Status Code Name
            vehicleStatusCodeName = ko.observable(),
            //Fleet Pool Code Name
            fleetPoolCodeName = ko.observable(),
            //Operation Code NAme
            operationCodeName = ko.observable(),
            //Location
            location = ko.observable();

        self = {
            vehicleId: vehicleId,
            vehicleName: vehicleName,
            plateNumber: plateNumber,
            currentOdometer: currentOdometer,
            fuelLevel: fuelLevel,
            modelYear: modelYear,
            vehicleMakeCodeName: vehicleMakeCodeName,
            vehicleStatusCodeName: vehicleStatusCodeName,
            fleetPoolCodeName: fleetPoolCodeName,
            operationCodeName: operationCodeName,
            location: location
        };
        return self;
    };
    // ReSharper disable once AssignToImplicitGlobalInFunctionScope
    VehicleDetail = function (specifiedKey, specifiedVehicleName, specifiedPNumber, specifiedCompanyId, specifiedDepartmentId, specifiedOperationId, specifiedRegionId,
        specifiedFleetPoolId, specifiedLocationId, specifiedFuelTypeId, specifiedFuelLevel, specifiedVehicleMakeId,
        specifiedVehicleModelId, specifiedVehicleCategoryId, specifiedModelYear, specifiedStatusId, specifiedTransmissionTypeId, specifiedTankSize, specifiedColor,
        specifiedInitialOdemeter, specifiedCurrentOdemeter, specifiedBranchOwnerIsChecked, specifiedRegistrationDate, specifiedRegistrationExpDate) {
        // ReSharper restore InconsistentNaming
        var // Reference to this object
            self,
            // Unique key
            vehicleId = ko.observable(specifiedKey),
            //Vehicle Name
            vehicleName = ko.observable(specifiedVehicleName),
            //plate Number
            plateNumber = ko.observable(specifiedPNumber).extend({ required: true }),
            //Company ID
            companyId = ko.observable(specifiedCompanyId),
            //Department Id
            departmentId = ko.observable(specifiedDepartmentId),
            //Operation Id
            operationId = ko.observable(specifiedOperationId),
             //Region Id
            regionId = ko.observable(specifiedRegionId),
            //Fleet Pool Id
            fleetPoolId = ko.observable(specifiedFleetPoolId),
            //Location Id
            locationId = ko.observable(specifiedLocationId),
            //Fuel Type Id
            fuelTypeId = ko.observable(specifiedFuelTypeId).extend({ required: true }),
            //Fuel Level
            fuelLevel = ko.observable(specifiedFuelLevel),
            //Vehicle Make ID
            vehicleMakeId = ko.observable(specifiedVehicleMakeId).extend({ required: true }),
            //Vehicle Model ID
            vehicleModelId = ko.observable(specifiedVehicleModelId).extend({ required: true }),
            //Vehicle Category ID
            vehicleCategoryId = ko.observable(specifiedVehicleCategoryId).extend({ required: true }),
            //Model Year
            modelYear = ko.observable(specifiedModelYear).extend({ required: true }),
            //Status Id
            statusId = ko.observable(specifiedStatusId).extend({ required: true }),
            //Transmission ID
            transmissionTypeId = ko.observable(specifiedTransmissionTypeId).extend({ required: true }),
            //Tank Size
            tankSize = ko.observable(specifiedTankSize).extend({ required: true, number: true }),
            //Color
            color = ko.observable(specifiedColor).extend({ required: true }),
            //Initial Odementer
            initialOdemeter = ko.observable(specifiedInitialOdemeter).extend({ required: true, number: true }),
            //Current Odemeter
            currentOdemeter = ko.observable(specifiedCurrentOdemeter).extend({ required: true, number: true }),
            //Branch Owner
            branchOwnerIsChecked = ko.observable(specifiedBranchOwnerIsChecked).extend({ required: true }),
            //Registration Date
            registrationDate = ko.observable(specifiedRegistrationDate),
            //Registration Exp. Date
            registrationExpDate = ko.observable(specifiedRegistrationExpDate),

            //#region Other Tabs object
            //Vehicle Other Detail
            otherVehicleDetail = ko.observable(new OtherVehicleDetail()),
            //Vehicle Purchase Info
            vehiclePurchaseInfo = ko.observable(new VehiclePurchaseInfo()),
            //Vehicle Leased Info
            vehicleLeasedInfo = ko.observable(new VehicleLeasedInfo()),
            //Vehicle Insurance Info
            vehicleInsuranceInfo = ko.observable(new VehicleInsuranceInfo()),
            //Vehicle Depreciation
            vehicleDepreciation = ko.observable(new VehicleDepreciation()),
            //Vehicle Disposal Info
            vehicleDisposalInfo = ko.observable(new VehicleDisposalInfo()),

            // Errors
            errors = ko.validation.group({
                plateNumber: plateNumber,
                fuelTypeId: fuelTypeId,
                vehicleMakeId: vehicleMakeId,
                vehicleModelId: vehicleModelId,
                modelYear: modelYear,
                statusId: statusId,
                vehicleCategoryId: vehicleCategoryId,
                transmissionTypeId: transmissionTypeId,
                color: color,
                initialOdemeter: initialOdemeter,
                currentOdemeter: currentOdemeter,
                tankSize: tankSize,
            }),
            // Is Valid
            isValid = ko.computed(function () {
                return errors().length === 0;
            }),
             // Convert to server
            convertToServerData = function () {
                return {
                    VehicleId: vehicleId(),
                };
            },
            // True if the booking has been changed
            // ReSharper disable InconsistentNaming
            dirtyFlag = new ko.dirtyFlag({
                vehicleName: vehicleName,
                plateNumber: plateNumber,
                companyId: companyId,
                departmentId: departmentId,
                operationId: operationId,
                regionId: regionId,
                fleetPoolId: fleetPoolId,
                locationId: locationId,
                fuelTypeId: fuelTypeId,
                fuelLevel: fuelLevel,
                vehicleMakeId: vehicleMakeId,
                vehicleModelId: vehicleModelId,
                vehicleCategoryId: vehicleCategoryId,
                statusId: statusId,
                transmissionTypeId: transmissionTypeId,
                tankSize: tankSize,
                color: color,
                initialOdemeter: initialOdemeter,
                currentOdemeter: currentOdemeter,
                branchOwnerIsChecked: branchOwnerIsChecked,
                registrationDate: registrationDate,
                registrationExpDate: registrationExpDate,
                modelYear: modelYear,
            }),
            // Has Changes
            hasChanges = ko.computed(function () {
                return dirtyFlag.isDirty();
            }),
            // Reset
            reset = function () {
                dirtyFlag.reset();
            };

        self = {
            vehicleId: vehicleId,
            vehicleName: vehicleName,
            plateNumber: plateNumber,
            companyId: companyId,
            departmentId: departmentId,
            operationId: operationId,
            regionId: regionId,
            fleetPoolId: fleetPoolId,
            locationId: locationId,
            fuelTypeId: fuelTypeId,
            fuelLevel: fuelLevel,
            vehicleMakeId: vehicleMakeId,
            vehicleModelId: vehicleModelId,
            vehicleCategoryId: vehicleCategoryId,
            statusId: statusId,
            transmissionTypeId: transmissionTypeId,
            tankSize: tankSize,
            color: color,
            initialOdemeter: initialOdemeter,
            currentOdemeter: currentOdemeter,
            branchOwnerIsChecked: branchOwnerIsChecked,
            registrationDate: registrationDate,
            registrationExpDate: registrationExpDate,
            modelYear: modelYear,
            errors: errors,
            isValid: isValid,
            dirtyFlag: dirtyFlag,
            hasChanges: hasChanges,
            reset: reset,
            convertToServerData: convertToServerData,
            otherVehicleDetail: otherVehicleDetail,
            vehiclePurchaseInfo: vehiclePurchaseInfo,
            vehicleLeasedInfo: vehicleLeasedInfo,
            vehicleInsuranceInfo: vehicleInsuranceInfo,
            vehicleDepreciation: vehicleDepreciation,
            vehicleDisposalInfo: vehicleDisposalInfo
        };
        return self;
    };
    //Other Vehicle Detail Entity
    // ReSharper disable once InconsistentNaming
    var OtherVehicleDetail = function () {
        var // Reference to this object
          self,
          // Unique key
          otherVehicleDetailId = ko.observable(),
          //Number Of Doors
          numberOfDoors = ko.observable(),
          //Engine CC
          horsePowerCc = ko.observable().extend({ required: true }),
          //Number Of Cylinders
          numberOfCylinders = ko.observable(),
          //is Alloy Rim
          isAlloyRim = ko.observable(),
          //Chasis Number
          chasisNumber = ko.observable().extend({ required: true }),
          //Engine Number
          engineNumber = ko.observable(),
          //Key Code
          keyCode = ko.observable(),
          //Radio Code
          radioCode = ko.observable(),
          //Accessories
          accessories = ko.observable(),
          //Top Speed
          topSpeed = ko.observable(),
          //Interior Description
          interiorDescription = ko.observable(),
          //Front Wheel Size
          frontWheelSize = ko.observable(),
          //Back Wheel Size
          backWheelSize = ko.observable(),
            // Errors
            errors = ko.validation.group({
                chasisNumber: chasisNumber,
                horsePowerCc: horsePowerCc
            }),
            // Is Valid
            isValid = ko.computed(function () {
                return errors().length === 0;
            }),

            // True if the booking has been changed
            // ReSharper disable InconsistentNaming
            dirtyFlag = new ko.dirtyFlag({

            }),
            // Has Changes
            hasChanges = ko.computed(function () {
                return dirtyFlag.isDirty();
            }),
            // Reset
            reset = function () {
                dirtyFlag.reset();
            };

        self = {
            otherVehicleDetailId: otherVehicleDetailId,
            numberOfDoors: numberOfDoors,
            horsePowerCc: horsePowerCc,
            numberOfCylinders: numberOfCylinders,
            isAlloyRim: isAlloyRim,
            chasisNumber: chasisNumber,
            engineNumber: engineNumber,
            keyCode: keyCode,
            radioCode: radioCode,
            accessories: accessories,
            topSpeed: topSpeed,
            interiorDescription: interiorDescription,
            frontWheelSize: frontWheelSize,
            backWheelSize: backWheelSize,
            errors: errors,
            isValid: isValid,
            dirtyFlag: dirtyFlag,
            hasChanges: hasChanges,
            reset: reset,
        };
        return self;
    };
    //Vehicle Purchase Info Entity
    // ReSharper disable once InconsistentNaming
    var VehiclePurchaseInfo = function () {
        var // Reference to this object
          self,
          // Unique key
          vehiclePurchaseInfoId = ko.observable(),
          //Vehicle Id
          vehicleId = ko.observable(),
          //Purchase Date
          purchaseDate = ko.observable(),
          //Purchased From
          purchasedFrom = ko.observable(),
          //Purchase Cost
          purchaseCost = ko.observable(),
          //Is Used Vehicle
          isUsedVehicle = ko.observable(),
          //Business Partner MainId
          bPMainId = ko.observable(),
          //Purchase Order Number
          purchaseOrderNumber = ko.observable(),
          //Purchase Description
          purchaseDescription = ko.observable(),

            // Errors
            errors = ko.validation.group({
            }),
            // Is Valid
            isValid = ko.computed(function () {
                return errors().length === 0;
            }),

            // True if the booking has been changed
            // ReSharper disable InconsistentNaming
            dirtyFlag = new ko.dirtyFlag({

            }),
            // Has Changes
            hasChanges = ko.computed(function () {
                return dirtyFlag.isDirty();
            }),
            // Reset
            reset = function () {
                dirtyFlag.reset();
            };

        self = {
            vehiclePurchaseInfoId: vehiclePurchaseInfoId,
            vehicleId: vehicleId,
            purchaseDate: purchaseDate,
            purchasedFrom: purchasedFrom,
            purchaseCost: purchaseCost,
            isUsedVehicle: isUsedVehicle,
            bPMainId: bPMainId,
            purchaseOrderNumber: purchaseOrderNumber,
            purchaseDescription: purchaseDescription,
            errors: errors,
            isValid: isValid,
            dirtyFlag: dirtyFlag,
            hasChanges: hasChanges,
            reset: reset,
        };
        return self;
    };
    //Leased Info Entity
    // ReSharper disable once InconsistentNaming
    var VehicleLeasedInfo = function () {
        var // Reference to this object
          self,
          // Unique key
          leasedInfoId = ko.observable(),
          //Down Payment
          downPayment = ko.observable(),
          //Leased Start Date
          leasedStartDate = ko.observable(),
          //Leased Finish Date
          leasedFinishDate = ko.observable(),
          //Monthly Payment
          monthlyPayment = ko.observable(),
          //Leased From
          leasedFrom = ko.observable(),
          //Interest Rate
          interestRate = ko.observable(),
          //Prinicipal Payment
          prinicipalPayment = ko.observable(),
          //First Payment Date
          firstPaymentDate = ko.observable(),
          //Lease To Ownership
          leaseToOwnership = ko.observable(),
          //First Month Payment
          firstMonthPayment = ko.observable(),
          //Business Partner Id
          bPMainId = ko.observable(),


            // Errors
            errors = ko.validation.group({

            }),
            // Is Valid
            isValid = ko.computed(function () {
                return errors().length === 0;
            }),

            // True if the booking has been changed
            // ReSharper disable InconsistentNaming
            dirtyFlag = new ko.dirtyFlag({

            }),
            // Has Changes
            hasChanges = ko.computed(function () {
                return dirtyFlag.isDirty();
            }),
            // Reset
            reset = function () {
                dirtyFlag.reset();
            };

        self = {
            leasedInfoId: leasedInfoId,
            downPayment: downPayment,
            leasedStartDate: leasedStartDate,
            leasedFinishDate: leasedFinishDate,
            monthlyPayment: monthlyPayment,
            leasedFrom: leasedFrom,
            interestRate: interestRate,
            prinicipalPayment: prinicipalPayment,
            firstPaymentDate: firstPaymentDate,
            leaseToOwnership: leaseToOwnership,
            firstMonthPayment: firstMonthPayment,
            bPMainId: bPMainId,
            errors: errors,
            isValid: isValid,
            dirtyFlag: dirtyFlag,
            hasChanges: hasChanges,
            reset: reset,
        };
        return self;
    };
    //Insurance Info Entity
    // ReSharper disable once InconsistentNaming
    var VehicleInsuranceInfo = function () {
        var // Reference to this object
          self,
          // Unique key
          insuranceInfoId = ko.observable(),
          //Insurance Agent
          insuranceAgent = ko.observable(),
          //Coverage Limit
          coverageLimit = ko.observable(),
          //Renewal Date
          renewalDate = ko.observable(),
          //Insurance Date
          insuranceDate = ko.observable(),
          //Premium
          premium = ko.observable(),
          //Insured Value
          insuredValue = ko.observable(),
          //Insured From
          insuredFrom = ko.observable(),
          //Business partner ID
          bPMainId = ko.observable(),
          //Insurance Type Id
          insuranceTypeId = ko.observable().extend({ required: true }),


            // Errors
            errors = ko.validation.group({
                insuranceTypeId: insuranceTypeId
            }),
            // Is Valid
            isValid = ko.computed(function () {
                return errors().length === 0;
            }),

            // True if the booking has been changed
            // ReSharper disable InconsistentNaming
            dirtyFlag = new ko.dirtyFlag({

            }),
            // Has Changes
            hasChanges = ko.computed(function () {
                return dirtyFlag.isDirty();
            }),
            // Reset
            reset = function () {
                dirtyFlag.reset();
            };

        self = {
            insuranceInfoId: insuranceInfoId,
            insuranceAgent: insuranceAgent,
            coverageLimit: coverageLimit,
            renewalDate: renewalDate,
            insuranceDate: insuranceDate,
            premium: premium,
            insuredValue: insuredValue,
            insuredFrom: insuredFrom,
            bPMainId: bPMainId,
            insuranceTypeId: insuranceTypeId,
            errors: errors,
            isValid: isValid,
            dirtyFlag: dirtyFlag,
            hasChanges: hasChanges,
            reset: reset,
        };
        return self;
    };
    //Maintenance Schedule Entity
    // ReSharper disable once InconsistentNaming
    var MaintenanceSchedule = function () {
        var // Reference to this object
          self,
          // Unique key
          maintenanceScheduleId = ko.observable(),
            // Errors
            errors = ko.validation.group({

            }),
            // Is Valid
            isValid = ko.computed(function () {
                return errors().length === 0;
            }),

            // True if the booking has been changed
            // ReSharper disable InconsistentNaming
            dirtyFlag = new ko.dirtyFlag({

            }),
            // Has Changes
            hasChanges = ko.computed(function () {
                return dirtyFlag.isDirty();
            }),
            // Reset
            reset = function () {
                dirtyFlag.reset();
            };

        self = {
            errors: errors,
            isValid: isValid,
            dirtyFlag: dirtyFlag,
            hasChanges: hasChanges,
            reset: reset,
        };
        return self;
    };
    //Check List Item Entity
    // ReSharper disable once InconsistentNaming
    var CheckListItem = function () {
        var // Reference to this object
          self,
          // Unique key
          checkListItemId = ko.observable(),
            // Errors
            errors = ko.validation.group({

            }),
            // Is Valid
            isValid = ko.computed(function () {
                return errors().length === 0;
            }),

            // True if the booking has been changed
            // ReSharper disable InconsistentNaming
            dirtyFlag = new ko.dirtyFlag({

            }),
            // Has Changes
            hasChanges = ko.computed(function () {
                return dirtyFlag.isDirty();
            }),
            // Reset
            reset = function () {
                dirtyFlag.reset();
            };

        self = {
            errors: errors,
            isValid: isValid,
            dirtyFlag: dirtyFlag,
            hasChanges: hasChanges,
            reset: reset,
        };
        return self;
    };
    //Depriciation Info Entity
    // ReSharper disable once InconsistentNaming
    var VehicleDepreciation = function () {
        var // Reference to this object
          self,
          // Unique key
          depriciationInfoId = ko.observable(),
          //Useful Period Start Date
          usefulPeriodStartDate = ko.observable(),
          //First Month Dep. Amount
          firstMonthDepAmount = ko.observable(),
          //Monthly Dep. Amount
          monthlyDepAmount = ko.observable(),
          //Last Month Dep Amount
          lastMonthDepAmount = ko.observable(),
          //Residual Value
          residualValue = ko.observable(),
          //Useful Period End Date
          usefulPeriodEndDate = ko.observable(),

           // Errors
            errors = ko.validation.group({

            }),
            // Is Valid
            isValid = ko.computed(function () {
                return errors().length === 0;
            }),

            // True if the booking has been changed
            // ReSharper disable InconsistentNaming
            dirtyFlag = new ko.dirtyFlag({

            }),
            // Has Changes
            hasChanges = ko.computed(function () {
                return dirtyFlag.isDirty();
            }),
            // Reset
            reset = function () {
                dirtyFlag.reset();
            };

        self = {
            depriciationInfoId: depriciationInfoId,
            usefulPeriodStartDate: usefulPeriodStartDate,
            firstMonthDepAmount: firstMonthDepAmount,
            monthlyDepAmount: monthlyDepAmount,
            lastMonthDepAmount: lastMonthDepAmount,
            residualValue: residualValue,
            usefulPeriodEndDate: usefulPeriodEndDate,
            errors: errors,
            isValid: isValid,
            dirtyFlag: dirtyFlag,
            hasChanges: hasChanges,
            reset: reset,
        };
        return self;
    };
    //Disposal Info Entity
    // ReSharper disable once InconsistentNaming
    var VehicleDisposalInfo = function () {
        var // Reference to this object
          self,
          // Unique key
          disposalInfoId = ko.observable(),
          //Sale Date
          saleDate = ko.observable(),
          //Sale Price
          salePrice = ko.observable(),
          //Sold To
          soldTo = ko.observable(),
          //Disposal Description
          disposalDescription = ko.observable(),
          //Business Partner Id
          bPMainId = ko.observable(),

            // Errors
            errors = ko.validation.group({

            }),
            // Is Valid
            isValid = ko.computed(function () {
                return errors().length === 0;
            }),

            // True if the booking has been changed
            // ReSharper disable InconsistentNaming
            dirtyFlag = new ko.dirtyFlag({

            }),
            // Has Changes
            hasChanges = ko.computed(function () {
                return dirtyFlag.isDirty();
            }),
            // Reset
            reset = function () {
                dirtyFlag.reset();
            };

        self = {
            disposalInfoId: disposalInfoId,
            saleDate: saleDate,
            salePrice: salePrice,
            soldTo: soldTo,
            disposalDescription: disposalDescription,
            bPMainId: bPMainId,
            errors: errors,
            isValid: isValid,
            dirtyFlag: dirtyFlag,
            hasChanges: hasChanges,
            reset: reset,
        };
        return self;
    };
    // Vehicle Detail Factory
    VehicleDetail.Create = function () {
        return new VehicleDetail(0, "", "", undefined, undefined, undefined, undefined, undefined, undefined, undefined, undefined, undefined, undefined, undefined,
        undefined, undefined, undefined, undefined, "", "", undefined, true, undefined, undefined);
    };
    // Convert (Vehicle Detail) Client to server
    var VehicleDetailServerMapper = function (source) {
        var result = {};
        // Main top section
        result.VehicleId = source.vehicleId();
        result.vehicleName = source.vehicleName();
        result.PlateNumber = source.plateNumber();
        result.OperationId = source.operationId();
        result.regionId = source.regionId();
        result.FleetPoolId = source.fleetPoolId();
        result.FuelTypeId = source.fuelTypeId();
        result.OperationsWorkPlaceId = source.locationId();
        result.FuelLevel = source.fuelLevel();
        result.VehicleMakeId = source.vehicleMakeId();
        result.VehicleModelId = source.vehicleModelId();
        result.VehicleCategoryId = source.vehicleCategoryId();
        result.VehicleStatusId = source.statusId();
        result.TransmissionTypeId = source.transmissionTypeId();
        result.TankSize = source.tankSize();
        result.Color = source.color();
        result.InitialOdometer = source.initialOdemeter();
        result.CurrentOdometer = source.currentOdemeter();
        result.IsBranchOwner = source.branchOwnerIsChecked();
        result.RegistrationDate = source.registrationDate() === undefined || source.registrationDate() === null ? undefined : moment(source.registrationDate()).format(ist.utcFormat);
        result.RegistrationExpiryDate = source.registrationExpDate() === undefined || source.registrationExpDate() === null ? undefined : moment(source.registrationExpDate()).format(ist.utcFormat);
        result.ModelYear = source.modelYear();

        // Vehicle Other Detail tab
        // from client to server
        result.VehicleOtherDetail = OtherVehicleDetailServerMapper(source.otherVehicleDetail());
        // Vehicle Purchase Info tab
        // from client to server
        result.VehiclePurchaseInfo = VehiclePurchaseInfoServerMapper(source.vehiclePurchaseInfo());
        // Vehicle Purchase Info tab
        // from client to server
        result.VehicleLeasedInfo = VehicleLeasedInfoServerMapper(source.vehicleLeasedInfo());
        // Vehicle Insurance Info tab
        // from client to server
        result.VehicleInsuranceInfo = VehicleInsuranceInfoServerMapper(source.vehicleInsuranceInfo());
        // Vehicle Depriciation tab
        // from client to server
        result.VehicleDepreciation = VehicleDepreciationServerMapper(source.vehicleDepreciation());
        // Vehicle Disposal tab
        // from client to server
        result.VehicleDisposalInfo = VehicleDisposalInfoServerMapper(source.vehicleDisposalInfo());

        return result;
    };
    // Convert (Vehicle Detail) Client to server
    var VehicleDetailServerMappeForDelete = function (source) {
        var result = {};
        // Main top section
        result.VehicleId = source.vehicleId();
        return result;
    };
    // ReSharper disable once InconsistentNaming
    var VehicleClientMapper = function (source) {
        var vehicle = new Vehicle();
        vehicle.vehicleId(source.VehicleId === null ? undefined : source.VehicleId);
        vehicle.vehicleName(source.VehicleName === null ? undefined : source.VehicleName);
        vehicle.plateNumber(source.PlateNumber === null ? undefined : source.PlateNumber);
        vehicle.currentOdometer(source.CurrentOdometer === null ? undefined : source.CurrentOdometer);
        vehicle.modelYear(source.ModelYear === null ? undefined : source.ModelYear);
        vehicle.vehicleMakeCodeName(source.VehicleMakeCodeName === null ? undefined : source.VehicleMakeCodeName);
        vehicle.vehicleStatusCodeName(source.VehicleStatusCodeName === null ? undefined : source.VehicleStatusCodeName);
        vehicle.fleetPoolCodeName(source.FleetPoolCodeName === null ? undefined : source.FleetPoolCodeName);
        vehicle.operationCodeName(source.OperationCodeName === null ? undefined : source.OperationCodeName);
        vehicle.location(source.Location === null ? undefined : source.Location);
        vehicle.fuelLevel(source.FuelLevel === null ? undefined : source.FuelLevel);
        return vehicle;
    };
    //Client To Server(Vehicle Other Detail)
    var OtherVehicleDetailServerMapper = function (source) {
        var result = {};
        // First  tab : Other Vehicle Detail
        result.VehicleOtherDetailId = source.otherVehicleDetailId() === undefined ? 0 : source.otherVehicleDetailId();
        result.NumberOfDoors = source.numberOfDoors() === undefined ? null : source.numberOfDoors();
        result.HorsePower_CC = source.horsePowerCc() === undefined ? null : source.horsePowerCc();
        result.NumberOfCylinders = source.numberOfCylinders() === undefined ? null : source.numberOfCylinders();
        result.IsAlloyRim = source.isAlloyRim() === undefined ? null : source.isAlloyRim();
        result.ChasisNumber = source.chasisNumber() === undefined ? null : source.chasisNumber();
        result.EngineNumber = source.engineNumber() === undefined ? null : source.engineNumber();
        result.KeyCode = source.keyCode() === undefined ? null : source.keyCode();
        result.RadioCode = source.radioCode() === undefined ? null : source.radioCode();
        result.Accessories = source.accessories() === undefined ? null : source.accessories();
        result.TopSpeed = source.topSpeed() === undefined ? null : source.topSpeed();
        result.InteriorDescription = source.interiorDescription() === undefined ? null : source.interiorDescription();
        result.FrontWheelSize = source.frontWheelSize() === undefined ? null : source.frontWheelSize();
        result.BackWheelSize = source.backWheelSize() === undefined ? null : source.backWheelSize();

        return result;
    };
    //Client To Server(Vehicle Purchase Info)
    var VehiclePurchaseInfoServerMapper = function (source) {
        var result = {};
        // second  tab : Vehicle Purchase Info
        result.VehiclePurchaseInfoId = source.vehiclePurchaseInfoId() === undefined ? 0 : source.vehiclePurchaseInfoId();
        result.PurchaseDate = source.purchaseDate() === undefined || source.purchaseDate() === null ? null : moment(source.purchaseDate()).format(ist.utcFormat);
        result.PurchaseDescription = source.purchaseDescription() === undefined ? null : source.purchaseDescription();
        result.IsUsedVehicle = source.isUsedVehicle() === undefined ? null : source.isUsedVehicle();
        result.BPMainId = source.bPMainId() === undefined ? null : source.bPMainId();
        result.PurchaseOrderNumber = source.purchaseOrderNumber() === undefined ? null : source.purchaseOrderNumber();
        result.PurchaseDescription = source.purchaseOrderNumber() === undefined ? null : source.purchaseOrderNumber();

        return result;
    };
    //Client To Server(Vehicle leased Info)
    var VehicleLeasedInfoServerMapper = function (source) {
        var result = {};
        // Third  tab : Vehicle leased Info
        result.VehicleLeasedInfoId = source.leasedInfoId() === undefined ? 0 : source.leasedInfoId();
        result.DownPayment = source.downPayment() === undefined ? null : source.downPayment();
        result.LeasedStartDate = source.leasedStartDate() === undefined || source.leasedStartDate() === null ? undefined : moment(source.leasedStartDate()).format(ist.utcFormat);
        result.LeasedFinishDate = source.leasedFinishDate() === undefined || source.leasedFinishDate() === null ? undefined : moment(source.leasedFinishDate()).format(ist.utcFormat);
        result.MonthlyPayment = source.monthlyPayment() === undefined ? null : source.monthlyPayment();
        result.LeasedFrom = source.leasedFrom() === undefined ? null : source.leasedFrom();
        result.InterestRate = source.interestRate() === undefined ? null : source.interestRate();
        result.PrinicipalPayment = source.prinicipalPayment() === undefined ? null : source.prinicipalPayment();
        result.FirstPaymentDate = source.firstPaymentDate() === undefined || source.firstPaymentDate() === null ? undefined : moment(source.firstPaymentDate()).format(ist.utcFormat);
        result.LeaseToOwnership = source.leaseToOwnership() === undefined ? null : source.leaseToOwnership();
        result.FirstMonthPayment = source.firstMonthPayment() === undefined ? null : source.firstMonthPayment();
        result.BPMainId = source.bPMainId() === undefined ? null : source.bPMainId();

        return result;
    };
    //Client To Server(Vehicle Insurance Info)
    var VehicleInsuranceInfoServerMapper = function (source) {
        var result = {};
        // Fourth  tab : Vehicle Insurance Info
        result.VehicleInsuranceInfoId = source.insuranceInfoId() === undefined ? 0 : source.insuranceInfoId();
        result.InsuranceAgent = source.insuranceAgent() === undefined ? null : source.insuranceAgent();
        result.RenewalDate = source.renewalDate() === undefined || source.renewalDate() === null ? undefined : moment(source.renewalDate()).format(ist.utcFormat);
        result.InsuranceDate = source.insuranceDate() === undefined || source.insuranceDate() === null ? undefined : moment(source.insuranceDate()).format(ist.utcFormat);
        result.CoverageLimit = source.coverageLimit() === undefined ? null : source.coverageLimit();
        result.Premium = source.premium() === undefined ? null : source.premium();
        result.InsuredValue = source.insuredValue() === undefined ? null : source.insuredValue();
        result.InsuredFrom = source.insuredFrom() === undefined ? null : source.insuredFrom();
        result.BPMainId = source.bPMainId() === undefined ? null : source.bPMainId();
        result.BPMainInsuranceTypeIdId = source.insuranceTypeId() === undefined ? null : source.insuranceTypeId();

        return result;
    };
    //Client To Server(Vehicle Depreciation)
    var VehicleDepreciationServerMapper = function (source) {
        var result = {};
        // Seventh  tab : Vehicle Depreciation
        result.VehicleDepreciationId = source.depriciationInfoId() === undefined ? 0 : source.depriciationInfoId();
        result.UsefulPeriodStartDate = source.usefulPeriodStartDate() === undefined || source.usefulPeriodStartDate() === null ? undefined : moment(source.usefulPeriodStartDate()).format(ist.utcFormat);
        result.UsefulPeriodEndDate = source.usefulPeriodEndDate() === undefined || source.usefulPeriodEndDate() === null ? undefined : moment(source.usefulPeriodEndDate()).format(ist.utcFormat);
        result.FirstMonthDepAmount = source.firstMonthDepAmount() === undefined ? null : source.firstMonthDepAmount();
        result.MonthlyDepAmount = source.monthlyDepAmount() === undefined ? null : source.monthlyDepAmount();
        result.LastMonthDepAmount = source.lastMonthDepAmount() === undefined ? null : source.lastMonthDepAmount();
        result.ResidualValue = source.residualValue() === undefined ? null : source.residualValue();

        return result;
    };
    //Client To Server(Vehicle Disposal Info)
    var VehicleDisposalInfoServerMapper = function (source) {
        var result = {};
        // Eight  tab :Vehicle Disposal Info
        result.VehicleDisposalInfoId = source.disposalInfoId() === undefined ? 0 : source.disposalInfoId();
        result.SaleDate = source.saleDate() === undefined || source.saleDate() === null ? undefined : moment(source.saleDate()).format(ist.utcFormat);
        result.SalePrice = source.salePrice() === undefined ? null : source.salePrice();
        result.SoldTo = source.soldTo() === undefined ? null : source.soldTo();
        result.DisposalDescription = source.disposalDescription() === undefined ? null : source.disposalDescription();
        result.BPMainId = source.bPMainId() === undefined ? null : source.bPMainId();

        return result;
    };
    return {
        Vehicle: Vehicle,
        VehicleDetail: VehicleDetail,
        OtherVehicleDetail: OtherVehicleDetail,
        VehiclePurchaseInfo: VehiclePurchaseInfo,
        VehicleLeasedInfo: VehicleLeasedInfo,
        VehicleInsuranceInfo: VehicleInsuranceInfo,
        MaintenanceSchedule: MaintenanceSchedule,
        CheckListItem: CheckListItem,
        VehicleDepreciation: VehicleDepreciation,
        VehicleDisposalInfo: VehicleDisposalInfo,
        //Mappers
        VehicleClientMapper: VehicleClientMapper,
        VehicleDetailServerMapper: VehicleDetailServerMapper,
        VehicleDetailServerMappeForDelete: VehicleDetailServerMappeForDelete,
        OtherVehicleDetailServerMapper: OtherVehicleDetailServerMapper,
        VehiclePurchaseInfoServerMapper: VehiclePurchaseInfoServerMapper,
        VehicleLeasedInfoServerMapper: VehicleLeasedInfoServerMapper,
        VehicleInsuranceInfoServerMapper: VehicleInsuranceInfoServerMapper,
        VehicleDepreciationServerMapper: VehicleDepreciationServerMapper,
        VehicleDisposalInfoServerMapper: VehicleDisposalInfoServerMapper


    };
});