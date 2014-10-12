/*
    Module with the model for the Non Revenue Ticket
*/
define(["ko", "underscore", "underscore-ko"], function (ko) {
    var
   //Non Revenue Ticket Main Entity
    // ReSharper disable once InconsistentNaming
    NRTMain = function () {
        var // Reference to this object
            self,
            // Unique key
            id = ko.observable(),
            //Operation ID
            operationId = ko.observable().extend({ required: true }),
            //Out Location Id
            outLocationId = ko.observable().extend({ required: true }),
            //Return Location Id
            retLocationId = ko.observable().extend({ required: true }),
            //Start Date
            startDate = ko.observable(new Date).extend({ required: true }),
            //End Date
            endDate = ko.observable().extend({ required: true }),
            //NRT Type ID
            nRtTypeId = ko.observable().extend({ required: true }),
            //Vehicle Detail In NRT Main
            vehicleDetail = ko.observable(new VehicleDetail()),
            //chauffer In Nrt
            chaufferInNrt = ko.observable(new ChaufferInNrt()),
            //Chauffers List
             chauffersList = ko.observableArray([]),
             //NRT Charges List
             nrtChargesList = ko.observableArray([]),
            // Errors
            errors = ko.validation.group({
                operationId: operationId,
                outLocationId: outLocationId,
                retLocationId: retLocationId,
                startDate: startDate,
                endDate: endDate,
                nRtTypeId: nRtTypeId,
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
            id: id,
            operationId: operationId,
            outLocationId: outLocationId,
            retLocationId: retLocationId,
            startDate: startDate,
            endDate: endDate,
            nRtTypeId: nRtTypeId,
            vehicleDetail: vehicleDetail,
            chaufferInNrt: chaufferInNrt,
            chauffersList: chauffersList,
            nrtChargesList: nrtChargesList,
            errors: errors,
            isValid: isValid,
            dirtyFlag: dirtyFlag,
            hasChanges: hasChanges,
            reset: reset,
        };
        return self;
    };
    //Vehicle Detail In Revenue TicketEntity
    // ReSharper disable once InconsistentNaming
    var VehicleDetail = function () {
        var // Reference to this object
            self,
            // Unique key
            id = ko.observable(),
            //vehicle ID
            vehicleId = ko.observable(),
            //Plate Number
            plateNum = ko.observable(),
            //Is Return Location
            isReturnLoc = ko.observable(false),
            //Out Date Time
            outDtTime = ko.observable().extend({ required: true }),
            //In date Time
            inDtTime = ko.observable().extend({ required: true }),
            //Out Location
            outLocId = ko.observable().extend({ required: true }),
             //In Location
            inLocId = ko.observable().extend({ required: true }),
            //Out Odemetor
            outOdemeter = ko.observable().extend({ required: true }),
            //In Odemeter
            inOdemeter = ko.observable().extend({ required: true }),
            //Fuel In
            fuelIn = ko.observable().extend({ required: true }),
            //Fuel Out
            fuelOut = ko.observable().extend({ required: true }),
            //Fuel Difference
            fuelDiff = ko.observable(),
            //Condition In
            conditionIn = ko.observable().extend({ required: true }),
            //Condition Out
            conditionOut = ko.observable().extend({ required: true }),
            //vehicle In Status Id
            vInStatusId = ko.observable().extend({ required: true }),
            //Vehicle Out Status Id
            vOutStatusId = ko.observable().extend({ required: true }),
              // Errors
            errors = ko.validation.group({
                outDtTime: outDtTime,
                outLocId: outLocId,
                outOdemeter: outOdemeter,
                fuelOut: fuelOut,
                vOutStatusId: vOutStatusId,
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
            id: id,
            vehicleId: vehicleId,
            plateNum: plateNum,
            isReturnLoc: isReturnLoc,
            outDtTime: outDtTime,
            inDtTime: inDtTime,
            outLocId: outLocId,
            inLocId: inLocId,
            outOdemeter: outOdemeter,
            inOdemeter: inOdemeter,
            fuelIn: fuelIn,
            fuelOut: fuelOut,
            fuelDiff: fuelDiff,
            conditionIn: conditionIn,
            conditionOut: conditionOut,
            vInStatusId: vInStatusId,
            vOutStatusId: vOutStatusId,
            errors: errors,
            isValid: isValid,
            dirtyFlag: dirtyFlag,
            hasChanges: hasChanges,
            reset: reset,
        };
        return self;
    };
    //Chauffer In Revenue TicketEntity
    // ReSharper disable once InconsistentNaming
    var ChaufferInNrt = function () {
        var // Reference to this object
            self,
            // Unique key
            id = ko.observable(),
            //Desig Grade Id
            desigGradeId = ko.observable(),
            //Chauffer Id
            chaufferId = ko.observable(),
            //Code
            code = ko.observable(),
            //Name
            name = ko.observable(),
              //License Number
            licenseNum = ko.observable(),
              //License Expiry Date
            licenseExpiryDt = ko.observable(),
            //String valued formatted date
            formattedLicenseExpiryDt = ko.computed({
                read: function () {
                    return moment(licenseExpiryDt()).format(ist.datePattern);
                }
            }),
            //Start Date
             startDt = ko.observable(),
            //String valued formatted date
            formattedStartDt = ko.computed({
                read: function () {
                    return moment(startDt()).format(ist.datePattern);
                }
            }),
             //Start Hour
             startHour = ko.observable(),
             //Start Minute
             startMinute = ko.observable(),
             //End Date
             endDt = ko.observable(),
               //String valued formatted date
                formattedEndDt = ko.computed({
                    read: function () {
                        return moment(endDt()).format(ist.datePattern);
                    }
                }),
             //End Hour
              endHour = ko.observable(),
            //End Minute
             endMinute = ko.observable(),

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
            id: id,
            desigGradeId: desigGradeId,
            code: code,
            name: name,
            licenseNum: licenseNum,
            licenseExpiryDt: licenseExpiryDt,
            formattedLicenseExpiryDt: formattedLicenseExpiryDt,
            startDt: startDt,
            startHour: startHour,
            startMinute: startMinute,
            endDt: endDt,
            endHour: endHour,
            endMinute: endMinute,
            formattedStartDt: formattedStartDt,
            formattedEndDt: formattedEndDt,
            chaufferId: chaufferId,
            errors: errors,
            isValid: isValid,
            dirtyFlag: dirtyFlag,
            hasChanges: hasChanges,
            reset: reset,
        };
        return self;
    };
    //Maintenance Activity In Non Revenue Ticket Entity
    // ReSharper disable once InconsistentNaming
    var MaintenanceActivity = function () {
        var // Reference to this object
            self,
            // Unique key
            id = ko.observable(),
            //Additonal Charge Type ID
            additionalChargeTypeId = ko.observable(),
            //Code
            code = ko.observable(),
            //Additional Charge Type Name
            name = ko.observable(),
            //Quantity
            qty = ko.observable().extend({ required: true }),
            //Total Rate
            totalRate = ko.observable(),
            //Contact Person
            contactPerson = ko.observable(),
            //Description
            description = ko.observable(),
             //Rate
            rate = ko.observable(),
            // Errors
            errors = ko.validation.group({
                qty: qty
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
            id: id,
            code: code,
            name: name,
            qty: qty,
            totalRate: totalRate,
            contactPerson: contactPerson,
            description: description,
            rate: rate,
            additionalChargeTypeId: additionalChargeTypeId,
            errors: errors,
            isValid: isValid,
            dirtyFlag: dirtyFlag,
            hasChanges: hasChanges,
            reset: reset,
        };
        return self;
    };

    //Vehicle List View entity
    // ReSharper disable once InconsistentNaming
    var Vehicle = function () {
        // ReSharper restore InconsistentNaming
        var // Reference to this object
            self,
            // Unique key
            vehicleId = ko.observable(),
            //plate Number
            plateNumber = ko.observable(),
            //Tank Size
            tankSize = ko.observable(),
            //Current Odometer
            currentOdometer = ko.observable(),
            //Fuel Level
            fuelLevel = ko.observable(),
            //Model Year
            modelYear = ko.observable(),
            //Vehicle Make Code Name
            vehicleMakeCodeName = ko.observable(),
            //Vehicle Model Code Name
            vehicleModelCodeName = ko.observable(),
            //Vehicle Category Code Name
            vehicleCategoryCodeName = ko.observable(),
            //Vehicle Status Code Name
            vehicleStatusCodeName = ko.observable();

        self = {
            vehicleId: vehicleId,
            plateNumber: plateNumber,
            tankSize: tankSize,
            currentOdometer: currentOdometer,
            fuelLevel: fuelLevel,
            modelYear: modelYear,
            vehicleMakeCodeName: vehicleMakeCodeName,
            vehicleStatusCodeName: vehicleStatusCodeName,
            vehicleModelCodeName: vehicleModelCodeName,
            vehicleCategoryCodeName: vehicleCategoryCodeName
        };
        return self;
    };
    //Vehicle For List View
    var VehicleForListView = function () {
        // ReSharper restore InconsistentNaming
        var // Reference to this object
            self,
            //plate Number
            plateNumber = ko.observable(),
            //Tank Size
            tankSize = ko.observable(),
            //Model Year
            modelYear = ko.observable(),
            //Vehicle Make Code Name
            vehicleMakeCodeName = ko.observable(),
            //Vehicle Model Code Name
            vehicleModelCodeName = ko.observable(),
            //Vehicle Category Code Name
            vehicleCategoryCodeName = ko.observable();

        self = {
            plateNumber: plateNumber,
            tankSize: tankSize,
            modelYear: modelYear,
            vehicleMakeCodeName: vehicleMakeCodeName,
            vehicleModelCodeName: vehicleModelCodeName,
            vehicleCategoryCodeName: vehicleCategoryCodeName
        };
        return self;
    };
    //Chauffer List View entity
    // ReSharper disable once InconsistentNaming
    var Chauffer = function () {
        // ReSharper restore InconsistentNaming
        var // Reference to this object
            self,
            // Unique key
            id = ko.observable(),
            //Code
            code = ko.observable(),
            //Name
            name = ko.observable(),
            //Desig Grade Id
            desigGradeId = ko.observable(),
            //category
            category = ko.observable(),
            //License Number
            licenseNum = ko.observable(),
            //License Expiry Date
            licenseExpiryDt = ko.observable(),
            //String valued formatted date
            formattedLicenseExpiryDt = ko.computed({
                read: function () {
                    return moment(licenseExpiryDt()).format(ist.datePattern);
                }
            });
        self = {
            id: id,
            desigGradeId: desigGradeId,
            code: code,
            name: name,
            category: category,
            licenseNum: licenseNum,
            licenseExpiryDt: licenseExpiryDt,
            formattedLicenseExpiryDt: formattedLicenseExpiryDt,
        };
        return self;
    };
    //Chauffer List View entity
    // ReSharper disable once InconsistentNaming
    var AdditionalCharge = function () {
        // ReSharper restore InconsistentNaming
        var // Reference to this object
            self,
            //Additional Charge Type Id
            additionalChargeTypeId = ko.observable(),
            //Code
            code = ko.observable(),
            //Name
            name = ko.observable(),
            //Hire Group Detail
            hireGroupDetail = ko.observable(),
            //Rate
            rate = ko.observable(),
            //True when Additonal Charge Selected in dialog
            isChecked = ko.observable();

        self = {
            additionalChargeTypeId: additionalChargeTypeId,
            code: code,
            name: name,
            hireGroupDetail: hireGroupDetail,
            rate: rate,
            isChecked: isChecked,
        };
        return self;
    };
    //Convert Server To Client
    // ReSharper disable once InconsistentNaming
    var AdditionalChargeClientMapper = function (source) {
        var addChrg = new AdditionalCharge();
        addChrg.additionalChargeTypeId(source.AdditionalChargeTypeId === null ? undefined : source.AdditionalChargeTypeId);
        addChrg.code(source.AdditionalChargeTypeCode === null ? undefined : source.AdditionalChargeTypeCode);
        addChrg.name(source.AdditionalChargeTypeName === null ? undefined : source.AdditionalChargeTypeName);
        addChrg.hireGroupDetail(source.HireGroupDetail === null ? undefined : source.HireGroupDetail);
        addChrg.rate(source.AdditionalChargeRate === null ? undefined : source.AdditionalChargeRate);
        return addChrg;
    };
    //Convert Server To Client
    // ReSharper disable once InconsistentNaming
    var VehicleClientMapper = function (source) {
        var vehicle = new Vehicle();
        vehicle.vehicleId(source.VehicleId === null ? undefined : source.VehicleId);
        vehicle.plateNumber(source.PlateNumber === null ? undefined : source.PlateNumber);
        vehicle.tankSize(source.TankSize === null ? undefined : source.TankSize);
        vehicle.currentOdometer(source.CurrentOdometer === null ? undefined : source.CurrentOdometer);
        vehicle.fuelLevel(source.FuelLevel === null ? undefined : source.FuelLevel);
        vehicle.modelYear(source.ModelYear === null ? undefined : source.ModelYear);
        vehicle.vehicleMakeCodeName(source.VehicleMakeCodeName === null ? undefined : source.VehicleMakeCodeName);
        vehicle.vehicleModelCodeName(source.VehicleModelCodeName === null ? undefined : source.VehicleModelCodeName);
        vehicle.vehicleStatusCodeName(source.VehicleStatusCodeName === null ? undefined : source.VehicleStatusCodeName);
        vehicle.vehicleCategoryCodeName(source.VehicleCategoryCodeName === null ? undefined : source.VehicleCategoryCodeName);
        return vehicle;
    };
    //Convert Server To Client
    // ReSharper disable once InconsistentNaming
    var VehicleForListViewClientMapper = function (source) {
        var vehicle = new VehicleForListView();
        vehicle.plateNumber(source.plateNumber() === null ? undefined : source.plateNumber());
        vehicle.tankSize(source.tankSize() === null ? undefined : source.tankSize());
        vehicle.modelYear(source.modelYear() === null ? undefined : source.modelYear());
        vehicle.vehicleMakeCodeName(source.vehicleMakeCodeName() === null ? undefined : source.vehicleMakeCodeName());
        vehicle.vehicleModelCodeName(source.vehicleModelCodeName() === null ? undefined : source.vehicleModelCodeName());
        vehicle.vehicleCategoryCodeName(source.vehicleCategoryCodeName() === null ? undefined : source.vehicleCategoryCodeName());
        return vehicle;
    };
    //Convert Server To Client
    // ReSharper disable once InconsistentNaming
    var NrtMainClientMapper = function (source) {
        var nrtMain = new NRTMain();
        nrtMain.id(source.NrtMainId === null ? undefined : source.NrtMainId);
        nrtMain.operationId(source.OperationId === null ? undefined : source.OperationId);
        nrtMain.outLocationId(source.OpenLocationId === null ? undefined : source.OpenLocationId);
        nrtMain.retLocationId(source.CloseLocationId === null ? undefined : source.CloseLocationId);
        nrtMain.nRtTypeId(source.NrtTypeId === null ? undefined : source.NrtTypeId);
        nrtMain.startDate(source.StartDtTime !== null ? moment(source.StartDtTime, ist.utcFormat).toDate() : undefined);
        nrtMain.endDate(source.EndDtTime !== null ? moment(source.EndDtTime, ist.utcFormat).toDate() : undefined);

        return nrtMain;
    };
    //Convert Server To Client
    // ReSharper disable once InconsistentNaming
    var MaintenanceActivityClientMapper = function (source) {
        var activity = new MaintenanceActivity();
        activity.id(source.NrtChargeId === null ? undefined : source.NrtChargeId);
        activity.code(source.Code === null ? undefined : source.Code);
        activity.name(source.Name === null ? undefined : source.Name);
        activity.qty(source.Quantity === null ? undefined : source.Quantity);
        activity.totalRate(source.TotalNrtChargeRate === null ? undefined : source.TotalNrtChargeRate);
        activity.contactPerson(source.ContactPerson === null ? undefined : source.ContactPerson);
        activity.description(source.Description === null ? undefined : source.Description);
        activity.rate(source.NrtChargeRate === null ? undefined : source.NrtChargeRate);
        activity.additionalChargeTypeId(source.AdditionalChargeTypeId === null ? undefined : source.AdditionalChargeTypeId);
        return activity;
    };
    //Client To Server Mapper
    // ReSharper disable once InconsistentNaming
    var MaintenanceActivityServerMapper = function (source) {
        var result = {};
        result.NrtChargeId = source.id() === undefined ? 0 : source.id();
        result.Quantity = source.qty() === undefined ? 0 : source.qty();
        result.TotalNrtChargeRate = source.totalRate() === undefined ? 0 : source.totalRate();
        result.ContactPerson = source.contactPerson() === undefined ? null : source.contactPerson();
        result.Description = source.description() === undefined ? null : source.description();
        result.NrtChargeRate = source.rate() === undefined ? 0 : source.rate();
        result.AdditionalChargeTypeId = source.additionalChargeTypeId() === undefined ? null : source.additionalChargeTypeId();
        return result;
    };
    //Convert Server To Client
    // ReSharper disable once InconsistentNaming
    var ChaufferInNrtClientMapper = function (source) {
        var chaufferInNrt = new ChaufferInNrt();
        chaufferInNrt.id(source.NrtDriverId === null ? undefined : source.NrtDriverId);
        chaufferInNrt.code(source.Code === null ? undefined : source.Code);
        chaufferInNrt.name(source.Name === null ? undefined : source.Name);
        chaufferInNrt.chaufferId(source.ChaufferId === null ? undefined : source.ChaufferId);
        chaufferInNrt.desigGradeId(source.OpenLocationId === null ? undefined : source.OpenLocationId);
        chaufferInNrt.licenseNum(source.CloseLocationId === null ? undefined : source.CloseLocationId);
        chaufferInNrt.startDt(source.StartDtTime !== null ? moment(source.StartDtTime, ist.utcFormat).toDate() : undefined);
        chaufferInNrt.startHour(source.StartDtTime !== null ? moment(source.StartDtTime, ist.utcFormat).format(ist.hourPattern) : undefined);
        chaufferInNrt.startMinute(source.StartDtTime !== null ? moment(source.StartDtTime, ist.utcFormat).format(ist.minutePattern) : undefined);
        chaufferInNrt.endDt(source.EndDtTime !== null ? moment(source.EndDtTime, ist.utcFormat).toDate() : undefined);
        chaufferInNrt.endHour(source.EndDtTime !== null ? moment(source.EndDtTime, ist.hourPattern).format(ist.hourPattern) : undefined);
        chaufferInNrt.endMinute(source.EndDtTime !== null ? moment(source.EndDtTime, ist.minutePattern).format(ist.minutePattern) : undefined);
        chaufferInNrt.licenseExpiryDt(source.LicenseExpDt !== null ? moment(source.LicenseExpDt, ist.utcFormat).toDate() : undefined);
        return chaufferInNrt;
    };
    //Convert Server To Client
    // ReSharper disable once InconsistentNaming
    var ChaufferClientMapper = function (source) {
        var chauffer = new Chauffer();
        chauffer.id(source.ChaufferId === null ? undefined : source.ChaufferId);
        chauffer.desigGradeId(source.DesigGradeId === null ? undefined : source.DesigGradeId);
        chauffer.code(source.ChaufferCode === null ? undefined : source.ChaufferCode);
        chauffer.name(source.ChaufferName === null ? undefined : source.ChaufferName);
        chauffer.category(source.DesigGradeCodeName === null ? undefined : source.DesigGradeCodeName);
        chauffer.licenseNum(source.LicenseNo === null ? undefined : source.LicenseNo);
        chauffer.licenseExpiryDt(source.LicenseExpDt !== null ? moment(source.LicenseExpDt, ist.utcFormat).toDate() : undefined);
        return chauffer;
    };
    //Client To Server Mapper
    // ReSharper disable once InconsistentNaming
    var NRTServerMapper = function (source) {
        var result = {};
        result.VehicleId = source.vehicleDetail().vehicleId() === undefined || source.vehicleDetail().vehicleId() === null ? 0 : source.vehicleDetail().vehicleId();
        result.NrtMainId = source.id === undefined || source.id() === null ? 0 : source.id();
        result.NrtMain = NRTMainServerMapper(source);
        result.NrtVehicleMovements = [];
        result.NrtVehicleMovements.push(VehicleDetailServerMapper(source.vehicleDetail()));
        result.NrtCharges = [];
        _.each(source.nrtChargesList(), function (item) {
            result.NrtCharges.push(MaintenanceActivityServerMapper(item));
        });
        result.NrtDrivers = [];
        _.each(source.chauffersList(), function (item) {
            result.NrtDrivers.push(ChaufferServerMapper(item));
        });
        return result;
    };
    //Client To Server Mapper
    // ReSharper disable once InconsistentNaming
    var NRTMainServerMapper = function (source) {
        var result = {};
        result.NrtMainId = source.id() === undefined || source.id() === null ? 0 : source.id();
        result.NrtTypeId = source.nRtTypeId() === undefined || source.nRtTypeId() === null ? 0 : source.nRtTypeId();
        result.OpenLocationId = source.outLocationId() === undefined || source.outLocationId() === null ? 0 : source.outLocationId();
        result.CloseLocationId = source.retLocationId() === undefined || source.retLocationId() === null ? 0 : source.retLocationId();
        //result.NrtStatusId = source.tariffTypeId() === undefined || source.tariffTypeId() === null ? 0 : source.tariffTypeId();
        result.StartDtTime = source.startDate() === undefined || source.startDate() === null ? undefined : moment(source.startDate()).format(ist.utcFormat);
        result.EndDtTime = source.endDate() === undefined || source.endDate() === null ? undefined : moment(source.endDate()).format(ist.utcFormat);
        //result.NrtStatusMovement = VehicleDetailServerMapper(source.vehicleDetail());
        return result;
    };
    //Client To Server Mapper
    // ReSharper disable once InconsistentNaming
    var VehicleDetailServerMapper = function (source) {
        var result = {};
        result.NrtVehicleMovementId = source.id() === undefined || source.id() === null ? 0 : source.id();
        result.VehicleId = source.vehicleId() === undefined || source.vehicleId() === null ? 0 : source.vehicleId();
        result.VehicleStatusId = source.vOutStatusId() === undefined || source.vOutStatusId() === null ? 0 : source.vOutStatusId();
        result.OperationsWorkPlaceId = source.outLocId() === undefined || source.outLocId() === null ? 0 : source.outLocId();
        result.Odometer = source.outOdemeter() === undefined || source.outOdemeter() === null ? 0 : source.outOdemeter();
        result.FuelLevel = source.fuelOut() === undefined || source.fuelOut() === null ? 0 : source.fuelOut();
        result.MovementStatus = source.isReturnLoc() === undefined || source.isReturnLoc() === null ? 0 : source.isReturnLoc();;
        result.DtTime = source.outDtTime() === undefined || source.outDtTime() === null ? undefined : moment(source.outDtTime()).format(ist.utcFormat);

        return result;
    };
    //Client To Server Mapper
    // ReSharper disable once InconsistentNaming
    var ChaufferServerMapper = function (source) {
        var result = {};
        result.NrtDriverId = source.id() === undefined || source.id() === null ? 0 : source.id();
        result.ChaufferId = source.chaufferId() === undefined || source.chaufferId() === null ? 0 : source.chaufferId();
        result.DesigGradeId = source.desigGradeId() === undefined || source.desigGradeId() === null ? 0 : source.desigGradeId();
        result.LicenseNo = source.licenseNum() === undefined || source.licenseNum() === null ? null : source.licenseNum();
        result.StartDtTime = source.startDt() === undefined || source.startDt() === null ? undefined : moment(source.startDt()).format(ist.utcFormat);
        result.EndDtTime = source.endDt() === undefined || source.endDt() === null ? undefined : moment(source.endDt()).format(ist.utcFormat);
        result.LicenseExpDt = source.licenseExpiryDt() === undefined || source.licenseExpiryDt() === null ? undefined : moment(source.licenseExpiryDt()).format(ist.utcFormat);
        return result;
    };
    // Convert Client to server
    // ReSharper disable once InconsistentNaming
    var NrtMainServerMapperForId = function (source) {
        var result = {};
        result.NrtMainId = source.id() === undefined ? 0 : source.id();
        return result;
    };
    return {
        NRTMain: NRTMain,
        Vehicle: Vehicle,
        VehicleDetail: VehicleDetail,
        VehicleForListView: VehicleForListView,
        Chauffer: Chauffer,
        ChaufferInNrt: ChaufferInNrt,
        AdditionalCharge: AdditionalCharge,
        MaintenanceActivity: MaintenanceActivity,
        VehicleClientMapper: VehicleClientMapper,
        ChaufferClientMapper: ChaufferClientMapper,
        NRTMainServerMapper: NRTMainServerMapper,
        VehicleDetailServerMapper: VehicleDetailServerMapper,
        ChaufferServerMapper: ChaufferServerMapper,
        AdditionalChargeClientMapper: AdditionalChargeClientMapper,
        MaintenanceActivityServerMapper: MaintenanceActivityServerMapper,
        NRTServerMapper: NRTServerMapper,
        NrtMainServerMapperForId: NrtMainServerMapperForId,
        NrtMainClientMapper: NrtMainClientMapper,
        ChaufferInNrtClientMapper: ChaufferInNrtClientMapper,
        MaintenanceActivityClientMapper: MaintenanceActivityClientMapper,
        VehicleForListViewClientMapper: VehicleForListViewClientMapper,
    };
});