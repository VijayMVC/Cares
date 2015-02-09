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
            fuelLevel = ko.observable(specifiedFuelLevel).extend({ required: true }),
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
            //Maintenance Schedule
            maintenanceSchedule = ko.observable(new MaintenanceSchedule()),
            //Vehicle Image
            vehicleImage = ko.observable(new VehicleImage()),
            //Check List Item
            checkListItem = ko.observable(new CheckListItem()),

            //Maintenance Schedule List
             maintenanceScheduleListInVehicle = ko.observableArray([]),
            //Check List Items
             checkListItemListInVehicle = ko.observableArray([]),

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
                fuelLevel: fuelLevel
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
            vehicleDisposalInfo: vehicleDisposalInfo,
            maintenanceSchedule: maintenanceSchedule,
            maintenanceScheduleListInVehicle: maintenanceScheduleListInVehicle,
            checkListItem: checkListItem,
            checkListItemListInVehicle: checkListItemListInVehicle,
            vehicleImage: vehicleImage
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
          numberOfDoors = ko.observable().extend({ number: true }),
          //Engine CC
          horsePowerCc = ko.observable().extend({ required: true, number: true }),
          //Number Of Cylinders
          numberOfCylinders = ko.observable().extend({ number: true }),
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
          topSpeed = ko.observable().extend({ number: true }),
          //Interior Description
          interiorDescription = ko.observable(),
          //Front Wheel Size
          frontWheelSize = ko.observable().extend({ number: true }),
          //Back Wheel Size
          backWheelSize = ko.observable().extend({ number: true }),
            // Errors
            errors = ko.validation.group({
                chasisNumber: chasisNumber,
                horsePowerCc: horsePowerCc,
                numberOfDoors: numberOfDoors,
                numberOfCylinders: numberOfCylinders,
                topSpeed: topSpeed,
                frontWheelSize: frontWheelSize,
                backWheelSize: backWheelSize
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
          purchaseCost = ko.observable().extend({ number: true }),
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
                purchaseCost: purchaseCost
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
          downPayment = ko.observable().extend({ number: true }),
          //Leased Start Date
          leasedStartDate = ko.observable(),
          //Leased Finish Date
          leasedFinishDate = ko.observable(),
          //Monthly Payment
          monthlyPayment = ko.observable().extend({ number: true }),
          //Leased From
          leasedFrom = ko.observable(),
          //Interest Rate
          interestRate = ko.observable().extend({ number: true }),
          //Prinicipal Payment
          prinicipalPayment = ko.observable().extend({ number: true }),
          //First Payment Date
          firstPaymentDate = ko.observable(),
          //Lease To Ownership
          leaseToOwnership = ko.observable(),
          //First Month Payment
          firstMonthPayment = ko.observable().extend({ number: true }),
          //Last Month Payment
          lastMonthPayment = ko.observable().extend({ number: true }),
          //Business Partner Id
          bPMainId = ko.observable(),

        // Errors
            errors = ko.validation.group({
                downPayment: downPayment,
                monthlyPayment: monthlyPayment,
                interestRate: interestRate,
                prinicipalPayment: prinicipalPayment,
                firstMonthPayment: firstMonthPayment,
                lastMonthPayment: lastMonthPayment
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
            lastMonthPayment: lastMonthPayment,
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
          coverageLimit = ko.observable().extend({ number: true }),
          //Renewal Date
          renewalDate = ko.observable(),
          //Insurance Date
          insuranceDate = ko.observable(),
          //Premium
          premium = ko.observable().extend({ number: true }),
          //Insured Value
          insuredValue = ko.observable().extend({ number: true }),
          //Insured From
          insuredFrom = ko.observable(),
          //Business partner ID
          bPMainId = ko.observable(),
          //Insurance Type Id
          insuranceTypeId = ko.observable().extend({ required: true }),

            // Errors
            errors = ko.validation.group({
                coverageLimit: coverageLimit,
                premium: premium,
                insuredValue: insuredValue,
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
          //Maintenance Start Date
          maintenanceStartDate = ko.observable().extend({ required: true }),
          //Frequency
          frequency = ko.observable().extend({ number: true }),
          //Frequency In Kilo Meter
          frequencyKiloMeter = ko.observable().extend({ number: true }),
          //Maintenance Type Id
          maintenanceTypeId = ko.observable().extend({ required: true }),
          //Maintenance Typ Code Name 
          maintenanceTypCodeName = ko.observable(),
            // Errors
            errors = ko.validation.group({
                maintenanceStartDate: maintenanceStartDate,
                maintenanceTypeId: maintenanceTypeId,
                frequency: frequency,
                frequencyKiloMeter: frequencyKiloMeter
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
            maintenanceScheduleId: maintenanceScheduleId,
            maintenanceStartDate: maintenanceStartDate,
            frequency: frequency,
            frequencyKiloMeter: frequencyKiloMeter,
            maintenanceTypeId: maintenanceTypeId,
            maintenanceTypCodeName: maintenanceTypCodeName,
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
          //Vehicle Check List Id
          vehicleCheckListId = ko.observable().extend({ required: true }),
          //Vehicle Check List Code Name
          vehicleCheckListCodeName = ko.observable(),

            // Errors
            errors = ko.validation.group({
                vehicleCheckListId: vehicleCheckListId
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
            checkListItemId: checkListItemId,
            vehicleCheckListId: vehicleCheckListId,
            vehicleCheckListCodeName: vehicleCheckListCodeName,
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
          firstMonthDepAmount = ko.observable().extend({ number: true }),
          //Monthly Dep. Amount
          monthlyDepAmount = ko.observable().extend({ number: true }),
          //Last Month Dep Amount
          lastMonthDepAmount = ko.observable().extend({ number: true }),
          //Residual Value
          residualValue = ko.observable().extend({ number: true }),
          //Useful Period End Date
          usefulPeriodEndDate = ko.observable(),

           // Errors
            errors = ko.validation.group({
                firstMonthDepAmount: firstMonthDepAmount,
                monthlyDepAmount: monthlyDepAmount,
                lastMonthDepAmount: lastMonthDepAmount,
                residualValue: residualValue
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
          salePrice = ko.observable().extend({ number: true }),
          //Sold To
          soldTo = ko.observable(),
          //Disposal Description
          disposalDescription = ko.observable(),
          //Business Partner Id
          bPMainId = ko.observable(),

            // Errors
            errors = ko.validation.group({
                salePrice: salePrice
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
    //Insurance Info Entity
    // ReSharper disable once InconsistentNaming
    var VehicleImage = function () {
        var // Reference to this object
            // Unique key
            id = ko.observable(),
            //Image URL
            imageUrl = ko.observable();


       return {
            id: id,
            imageUrl: imageUrl,
        };
        
    }

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
        result.VehicleName = source.vehicleName();
        result.PlateNumber = source.plateNumber();
        result.OperationId = source.operationId();
        result.RegionId = source.regionId();
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
        // Vehicle Maintenance Schedule
        // from client to server
        result.VehicleMaintenanceTypeFrequency = [];
        _.each(source.maintenanceScheduleListInVehicle(), function (item) {
            result.VehicleMaintenanceTypeFrequency.push(MaintenanceScheduleServerMapper(item));
        });
        // Vehicle Check List Items
        // from client to server
        result.VehicleImages = [];
        result.VehicleImages.push({ VehicleImageId: 0, ImageSource: source.vehicleImage().imageUrl() });
        result.VehicleCheckListItems = [];
        _.each(source.checkListItemListInVehicle(), function (item) {
            result.VehicleCheckListItems.push(CheckListItemServerMapper(item));
        });

        return result;
    };
    //Server To Client Mapper
    // ReSharper disable once InconsistentNaming
    var VehicleDetailClientMapper = function (source) {
        var vehicleDetail = new VehicleDetail();
        vehicleDetail.vehicleId(source.VehicleId === null ? undefined : source.VehicleId);
        vehicleDetail.vehicleName(source.VehicleName === null ? undefined : source.VehicleName);
        vehicleDetail.plateNumber(source.PlateNumber === null ? undefined : source.PlateNumber);
        vehicleDetail.operationId(source.OperationId === null ? undefined : source.OperationId);
        vehicleDetail.regionId(source.RegionId === null ? undefined : source.RegionId);
        vehicleDetail.fleetPoolId(source.FleetPoolId === null ? undefined : source.FleetPoolId);
        vehicleDetail.modelYear(source.ModelYear === null ? undefined : source.ModelYear);
        vehicleDetail.fuelTypeId(source.FuelTypeId === null ? undefined : source.FuelTypeId);
        vehicleDetail.locationId(source.OperationsWorkPlaceId === null ? undefined : source.OperationsWorkPlaceId);
        vehicleDetail.fuelLevel(source.FuelLevel === null ? undefined : source.FuelLevel);
        vehicleDetail.vehicleMakeId(source.VehicleMakeId === null ? undefined : source.VehicleMakeId);
        vehicleDetail.vehicleModelId(source.VehicleModelId === null ? undefined : source.VehicleModelId);
        vehicleDetail.vehicleCategoryId(source.VehicleCategoryId === null ? undefined : source.VehicleCategoryId);
        vehicleDetail.statusId(source.VehicleStatusId === null ? undefined : source.VehicleStatusId);
        vehicleDetail.transmissionTypeId(source.TransmissionTypeId === null ? undefined : source.TransmissionTypeId);
        vehicleDetail.tankSize(source.TankSize === null ? undefined : source.TankSize);
        vehicleDetail.color(source.Color === null ? undefined : source.Color);
        vehicleDetail.currentOdemeter(source.CurrentOdometer === null ? undefined : source.CurrentOdometer);
        vehicleDetail.initialOdemeter(source.InitialOdometer === null ? undefined : source.InitialOdometer);
        vehicleDetail.branchOwnerIsChecked(source.IsBranchOwner === null ? false : source.IsBranchOwner);
        //Vehicle Other Detail
        vehicleDetail.otherVehicleDetail(OtherVehicleDetailClientMapper(source.VehicleOtherDetail)),
        //Vehicle Purchase Info
        vehicleDetail.vehiclePurchaseInfo(VehiclePurchaseInfoClientMapper(source.VehiclePurchaseInfo)),
        //Vehicle Leased Info
        vehicleDetail.vehicleLeasedInfo(VehicleLeasedInfoClientMapper(source.VehicleLeasedInfo));
        //Vehicle Insurance Info
        vehicleDetail.vehicleInsuranceInfo(VehicleInsuranceInfoClientMapper(source.VehicleInsuranceInfo));
        //Vehicle Depreciation
        vehicleDetail.vehicleDepreciation(VehicleDepreciationClientMapper(source.VehicleDepreciation));
        //Vehicle Disposal Info
        vehicleDetail.vehicleDisposalInfo(VehicleDisposalInfoClientMapper(source.VehicleDisposalInfo));

        return vehicleDetail;
    };
    // Convert (Vehicle Detail) Client to server
    var VehicleDetailServerMappeForDelete = function (source) {
        var result = {};
        // Main top section
        result.VehicleId = source.vehicleId();
        return result;
    };
    //Server To Client Mapper
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
    //Server To Client Mapper
    // ReSharper disable once InconsistentNaming
    var OtherVehicleDetailClientMapper = function (source) {
        var otherVehicleDetail = new OtherVehicleDetail();
        otherVehicleDetail.otherVehicleDetailId(source.VehicleId === null ? undefined : source.VehicleId);
        otherVehicleDetail.numberOfDoors(source.NumberOfDoors === null ? undefined : source.NumberOfDoors);
        otherVehicleDetail.horsePowerCc(source.HorsePower_CC === null ? undefined : source.HorsePower_CC);
        otherVehicleDetail.numberOfCylinders(source.NumberOfCylinders === null ? undefined : source.NumberOfCylinders);
        otherVehicleDetail.isAlloyRim(source.IsAlloyRim === false ? undefined : source.IsAlloyRim);
        otherVehicleDetail.chasisNumber(source.ChasisNumber === null ? undefined : source.ChasisNumber);
        otherVehicleDetail.engineNumber(source.EngineNumber === null ? undefined : source.EngineNumber);
        otherVehicleDetail.keyCode(source.KeyCode === null ? undefined : source.KeyCode);
        otherVehicleDetail.radioCode(source.RadioCode === null ? undefined : source.RadioCode);
        otherVehicleDetail.accessories(source.Accessories === null ? undefined : source.Accessories);
        otherVehicleDetail.topSpeed(source.TopSpeed === null ? undefined : source.TopSpeed);
        otherVehicleDetail.interiorDescription(source.InteriorDescription === null ? undefined : source.InteriorDescription);
        otherVehicleDetail.frontWheelSize(source.FrontWheelSize === null ? undefined : source.FrontWheelSize);
        otherVehicleDetail.backWheelSize(source.BackWheelSize === null ? undefined : source.BackWheelSize);

        return otherVehicleDetail;
    };

    //Client To Server(Vehicle Purchase Info)
    var VehiclePurchaseInfoServerMapper = function (source) {
        var result = {};
        // second  tab : Vehicle Purchase Info
        result.VehiclePurchaseInfoId = source.vehiclePurchaseInfoId() === undefined ? 0 : source.vehiclePurchaseInfoId();
        result.PurchaseDate = source.purchaseDate() === undefined || source.purchaseDate() === null ? null : moment(source.purchaseDate()).format(ist.utcFormat);
        result.PurchaseCost = source.purchaseCost() === undefined ? null : source.purchaseCost();
        result.IsUsedVehicle = source.isUsedVehicle() === undefined ? null : source.isUsedVehicle();
        result.BPMainId = source.bPMainId() === undefined ? null : source.bPMainId();
        result.PurchaseOrderNumber = source.purchaseOrderNumber() === undefined ? null : source.purchaseOrderNumber();
        result.PurchaseDescription = source.purchaseDescription() === undefined ? null : source.purchaseDescription();

        return result;
    };
    //Server To Client Mapper
    // ReSharper disable once InconsistentNaming
    var VehiclePurchaseInfoClientMapper = function (source) {
        var vehiclePurchaseInfo = new VehiclePurchaseInfo();
        vehiclePurchaseInfo.vehiclePurchaseInfoId(source.VehiclePurchaseInfoId === null ? undefined : source.VehiclePurchaseInfoId);
        vehiclePurchaseInfo.purchaseDate(source.PurchaseDate !== null ? moment(source.PurchaseDate, ist.utcFormat).toDate() : undefined);
        vehiclePurchaseInfo.purchaseCost(source.PurchaseCost === null ? undefined : source.PurchaseCost);
        vehiclePurchaseInfo.isUsedVehicle(source.IsUsedVehicle === null ? undefined : source.IsUsedVehicle);
        vehiclePurchaseInfo.bPMainId(source.BPMainId === null ? undefined : source.BPMainId);
        vehiclePurchaseInfo.purchaseOrderNumber(source.PurchaseOrderNumber === null ? undefined : source.PurchaseOrderNumber);
        vehiclePurchaseInfo.purchaseDescription(source.PurchaseDescription === null ? undefined : source.PurchaseDescription);

        return vehiclePurchaseInfo;
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
        result.LastMonthPayment = source.lastMonthPayment() === undefined ? null : source.lastMonthPayment();
        result.BPMainId = source.bPMainId() === undefined ? null : source.bPMainId();

        return result;
    };
    //Server To Client Mapper
    // ReSharper disable once InconsistentNaming
    var VehicleLeasedInfoClientMapper = function (source) {
        var vehicleLeasedInfo = new VehicleLeasedInfo();
        vehicleLeasedInfo.leasedInfoId(source.VehicleLeasedInfoId === null ? undefined : source.VehicleLeasedInfoId);
        vehicleLeasedInfo.downPayment(source.DownPayment === null ? undefined : source.DownPayment);
        vehicleLeasedInfo.leasedStartDate(source.LeasedStartDate !== null ? moment(source.LeasedStartDate, ist.utcFormat).toDate() : undefined);
        vehicleLeasedInfo.leasedFinishDate(source.LeasedFinishDate !== null ? moment(source.LeasedFinishDate, ist.utcFormat).toDate() : undefined);
        vehicleLeasedInfo.monthlyPayment(source.MonthlyPayment === null ? undefined : source.MonthlyPayment);
        vehicleLeasedInfo.leasedFrom(source.LeasedFrom === null ? undefined : source.LeasedFrom);
        vehicleLeasedInfo.interestRate(source.InterestRate === null ? undefined : source.InterestRate);
        vehicleLeasedInfo.prinicipalPayment(source.PrinicipalPayment === null ? undefined : source.PrinicipalPayment);
        vehicleLeasedInfo.firstPaymentDate(source.FirstPaymentDate !== null ? moment(source.FirstPaymentDate, ist.utcFormat).toDate() : undefined);
        vehicleLeasedInfo.leaseToOwnership(source.LeaseToOwnership === null ? undefined : source.LeaseToOwnership);
        vehicleLeasedInfo.firstMonthPayment(source.FirstMonthPayment === null ? undefined : source.FirstMonthPayment);
        vehicleLeasedInfo.lastMonthPayment(source.LastMonthPayment === null ? undefined : source.LastMonthPayment);
        vehicleLeasedInfo.bPMainId(source.BPMainId === null ? undefined : source.BPMainId);

        return vehicleLeasedInfo;
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
        result.InsuranceTypeId = source.insuranceTypeId() === undefined ? null : source.insuranceTypeId();

        return result;
    };
    //Server To Client Mapper
    // ReSharper disable once InconsistentNaming
    var VehicleInsuranceInfoClientMapper = function (source) {
        var vehicleInsuranceInfo = new VehicleInsuranceInfo();
        vehicleInsuranceInfo.insuranceInfoId(source.VehicleInsuranceInfoId === null ? undefined : source.VehicleInsuranceInfoId);
        vehicleInsuranceInfo.insuranceAgent(source.InsuranceAgent === null ? undefined : source.InsuranceAgent);
        vehicleInsuranceInfo.renewalDate(source.RenewalDate !== null ? moment(source.RenewalDate, ist.utcFormat).toDate() : undefined);
        vehicleInsuranceInfo.insuranceDate(source.InsuranceDate !== null ? moment(source.InsuranceDate, ist.utcFormat).toDate() : undefined);
        vehicleInsuranceInfo.coverageLimit(source.CoverageLimit === null ? undefined : source.CoverageLimit);
        vehicleInsuranceInfo.premium(source.Premium === null ? undefined : source.Premium);
        vehicleInsuranceInfo.insuredValue(source.InsuredValue === null ? undefined : source.InsuredValue);
        vehicleInsuranceInfo.insuredFrom(source.InsuredFrom === null ? undefined : source.InsuredFrom);
        vehicleInsuranceInfo.bPMainId(source.BPMainId === null ? undefined : source.BPMainId);
        vehicleInsuranceInfo.insuranceTypeId(source.InsuranceTypeId === null ? undefined : source.InsuranceTypeId);

        return vehicleInsuranceInfo;
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
    //Server To Client Mapper
    // ReSharper disable once InconsistentNaming
    var VehicleDepreciationClientMapper = function (source) {
        var vehicleDepreciation = new VehicleDepreciation();
        vehicleDepreciation.depriciationInfoId(source.VehicleDepreciationId === null ? undefined : source.VehicleDepreciationId);
        vehicleDepreciation.usefulPeriodStartDate(source.UsefulPeriodStartDate !== null ? moment(source.UsefulPeriodStartDate, ist.utcFormat).toDate() : undefined);
        vehicleDepreciation.usefulPeriodEndDate(source.UsefulPeriodEndDate !== null ? moment(source.UsefulPeriodEndDate, ist.utcFormat).toDate() : undefined);
        vehicleDepreciation.firstMonthDepAmount(source.FirstMonthDepAmount === null ? undefined : source.FirstMonthDepAmount);
        vehicleDepreciation.monthlyDepAmount(source.MonthlyDepAmount === null ? undefined : source.MonthlyDepAmount);
        vehicleDepreciation.lastMonthDepAmount(source.LastMonthDepAmount === null ? undefined : source.LastMonthDepAmount);
        vehicleDepreciation.residualValue(source.ResidualValue === null ? undefined : source.ResidualValue);

        return vehicleDepreciation;
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
    //Server To Client Mapper
    // ReSharper disable once InconsistentNaming
    var VehicleDisposalInfoClientMapper = function (source) {
        var vehicleDisposalInfo = new VehicleDisposalInfo();
        vehicleDisposalInfo.disposalInfoId(source.VehicleDisposalInfoId === null ? undefined : source.VehicleDisposalInfoId);
        vehicleDisposalInfo.saleDate(source.SaleDate !== null ? moment(source.SaleDate, ist.utcFormat).toDate() : undefined);
        vehicleDisposalInfo.salePrice(source.SalePrice === null ? undefined : source.SalePrice);
        vehicleDisposalInfo.soldTo(source.SoldTo === null ? undefined : source.SoldTo);
        vehicleDisposalInfo.disposalDescription(source.DisposalDescription === null ? undefined : source.DisposalDescription);
        vehicleDisposalInfo.bPMainId(source.BPMainId === null ? undefined : source.BPMainId);

        return vehicleDisposalInfo;
    };
    //Client To Server(Vehicle Maintenance Schedule)
    var MaintenanceScheduleServerMapper = function (source) {
        var result = {};
        // Fifth  tab :Vehicle Maintenance Schedule
        result.MaintenanceTypeFrequencyId = source.maintenanceScheduleId() === undefined ? 0 : source.maintenanceScheduleId();
        result.MaintenanceStartDate = source.maintenanceStartDate() === undefined || source.maintenanceStartDate() === null ? undefined : moment(source.maintenanceStartDate()).format(ist.utcFormat);
        result.Frequency = source.frequency() === undefined ? null : source.frequency();
        result.FrequencyKiloMeter = source.frequencyKiloMeter() === undefined ? null : source.frequencyKiloMeter();
        result.MaintenanceTypeId = source.maintenanceTypeId() === undefined ? null : source.maintenanceTypeId();

        return result;
    };
    //Server To Client Mapper
    // ReSharper disable once InconsistentNaming
    var MaintenanceScheduleClientMapper = function (source) {
        var maintenanceSchedule = new MaintenanceSchedule();
        maintenanceSchedule.maintenanceScheduleId(source.MaintenanceTypeFrequencyId === null ? undefined : source.MaintenanceTypeFrequencyId);
        maintenanceSchedule.maintenanceStartDate(source.MaintenanceStartDate !== null ? moment(source.MaintenanceStartDate, ist.utcFormat).toDate() : undefined);
        maintenanceSchedule.frequency(source.Frequency === null ? undefined : source.Frequency);
        maintenanceSchedule.frequencyKiloMeter(source.FrequencyKiloMeter === null ? undefined : source.FrequencyKiloMeter);
        maintenanceSchedule.maintenanceTypeId(source.MaintenanceTypeId === null ? undefined : source.MaintenanceTypeId);
        maintenanceSchedule.maintenanceTypCodeName(source.MaintenanceTypeCodeName === null ? undefined : source.MaintenanceTypeCodeName);

        return maintenanceSchedule;
    };
    //Client To Server(Vehicle Check List Item)
    var CheckListItemServerMapper = function (source) {
        var result = {};
        // Sixth  tab :Vehicle Check List Item
        result.VehicleCheckListItemId = source.checkListItemId() === undefined ? 0 : source.checkListItemId();
        result.VehicleCheckListId = source.vehicleCheckListId() === undefined ? null : source.vehicleCheckListId();

        return result;
    };
    //Server To Client Mapper
    // ReSharper disable once InconsistentNaming
    var CheckListItemClientMapper = function (source) {
        var checkListItem = new CheckListItem();
        checkListItem.checkListItemId(source.VehicleCheckListItemId === null ? undefined : source.VehicleCheckListItemId);
        checkListItem.vehicleCheckListId(source.VehicleCheckListId === null ? undefined : source.VehicleCheckListId);
        checkListItem.vehicleCheckListCodeName(source.VehicleCheckListCodeName === null ? undefined : source.VehicleCheckListCodeName);
        return checkListItem;
    };
    //Client To Server(Vehicle Image Upload)
    var VehicleImageServerMapper = function (source) {
        var result = {};
        result.VehicleImageId = source.id() === undefined ? 0 : source.id();
        //result.InsuranceAgent = source.insuranceAgent() === undefined ? null : source.insuranceAgent();
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
        VehicleImage: VehicleImage,
        //Server Mappers
        VehicleDetailServerMapper: VehicleDetailServerMapper,
        VehicleDetailServerMappeForDelete: VehicleDetailServerMappeForDelete,
        OtherVehicleDetailServerMapper: OtherVehicleDetailServerMapper,
        VehiclePurchaseInfoServerMapper: VehiclePurchaseInfoServerMapper,
        VehicleLeasedInfoServerMapper: VehicleLeasedInfoServerMapper,
        VehicleInsuranceInfoServerMapper: VehicleInsuranceInfoServerMapper,
        VehicleDepreciationServerMapper: VehicleDepreciationServerMapper,
        VehicleDisposalInfoServerMapper: VehicleDisposalInfoServerMapper,
        MaintenanceScheduleServerMapper: MaintenanceScheduleServerMapper,
        CheckListItemServerMapper: CheckListItemServerMapper,
        //Client Mappers
        VehicleClientMapper: VehicleClientMapper,
        OtherVehicleDetailClientMapper: OtherVehicleDetailClientMapper,
        VehiclePurchaseInfoClientMapper: VehiclePurchaseInfoClientMapper,
        VehicleLeasedInfoClientMapper: VehicleLeasedInfoClientMapper,
        VehicleInsuranceInfoClientMapper: VehicleInsuranceInfoClientMapper,
        VehicleDepreciationClientMapper: VehicleDepreciationClientMapper,
        VehicleDisposalInfoClientMapper: VehicleDisposalInfoClientMapper,
        MaintenanceScheduleClientMapper: MaintenanceScheduleClientMapper,
        CheckListItemClientMapper: CheckListItemClientMapper,
        VehicleDetailClientMapper: VehicleDetailClientMapper,
        VehicleImageServerMapper: VehicleImageServerMapper
    };
});