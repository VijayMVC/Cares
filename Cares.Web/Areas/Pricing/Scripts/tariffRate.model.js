define(["ko", "underscore", "underscore-ko"], function (ko) {

    var
    //Tariff Rate entity
    // ReSharper disable InconsistentNaming
    TariffRate = function () {
        // ReSharper restore InconsistentNaming
        var // Reference to this object
            self,
            // Unique key
            tariffRateId = ko.observable(),
            // Tariff Rate Code 
            tariffRateCode = ko.observable(),
            // Tarrif Type Name
            tariffRateName = ko.observable(),
            //Start From
            startEffectiveDate = ko.observable(),
            //End To
            endEffectiveDate = ko.observable();

        self = {
            tariffRateId: tariffRateId,
            tariffRateCode: tariffRateCode,
            tariffRateName: tariffRateName,
            startEffectiveDate: startEffectiveDate,
            endEffectiveDate: endEffectiveDate,
        };
        return self;
    };
// ReSharper disable once InconsistentNaming
    var TariffRateDetail = function () {
        // ReSharper restore InconsistentNaming
        var // Reference to this object
           // Unique key
            tariffRateId = ko.observable(),
            // Tariff Rate Code 
            tariffRateCode = ko.observable().extend({ required: true }),
            // Tarrif Type Name
            tariffRateName = ko.observable(),
            //Description
            description = ko.observable(),
            //Operation Id
             operationId = ko.observable().extend({ required: true }),
             //Tariff Type Id
             tariffTypeId = ko.observable().extend({ required: true }),
            //Start From
            startEffectiveDate = ko.observable().extend({ required: true }),
            //End To
            endEffectiveDate = ko.observable().extend({ required: true }),
            isBusy = ko.observable(false),
            // Errors
            errors = ko.validation.group({
                tariffRateCode: tariffRateCode,
                operationId: operationId,
                tariffTypeId: tariffTypeId,
                startEffectiveDate: startEffectiveDate,
                endEffectiveDate: endEffectiveDate,
            }),
            // Is Valid
            isValid = ko.computed(function () {
                return errors().length === 0;
            }),
            // True if the booking has been changed
            // ReSharper disable InconsistentNaming
            dirtyFlag = new ko.dirtyFlag({
                tariffRateCode: tariffRateCode,
                tariffRateName: tariffRateName,
                description: description,
                operationId: operationId,
                startEffectiveDate: startEffectiveDate,
                endEffectiveDate: endEffectiveDate,
                tariffTypeId: tariffTypeId,

            }),
            // Has Changes
            hasChanges = ko.computed(function () {
                return dirtyFlag.isDirty();
            }),
            // Reset
            reset = function () {
                dirtyFlag.reset();
            },


        self = {
            tariffRateId: tariffRateId,
            tariffRateCode: tariffRateCode,
            tariffRateName: tariffRateName,
            description: description,
            operationId: operationId,
            tariffTypeId: tariffTypeId,
            startEffectiveDate: startEffectiveDate,
            endEffectiveDate: endEffectiveDate,

            errors: errors,
            isValid: isValid,
            dirtyFlag: dirtyFlag,
            hasChanges: hasChanges,
            reset: reset,
            isBusy: isBusy

        };
        return self;
    };
    var HireGroupDetail = function () {
        // ReSharper restore InconsistentNaming
        var // Reference to this object
           // Unique key
            hireGroupDetailId = ko.observable(),
             // Hire Group
            hireGroup = ko.observable(),
            //Vehicle Make
            vehicleMake = ko.observable(),
            //Vehicle Model
             vehicleModel = ko.observable(),
             //Vehicle Category
             vehicleCategory = ko.observable(),
            //Model Year
            modelYear = ko.observable(),
            //Allow Mileage
            allowMileage = ko.observable(),
            //Excess Mileage Charge
            excessMileageCharge = ko.observable(),
            //Standard Rate
            standardRate = ko.observable(),
            //Start Date
            startDate = ko.observable(),
            //End Date
            endDate = ko.observable(),
            //Is Checked
            isChecked = ko.observable(true),
            
        self = {
            hireGroupDetailId: hireGroupDetailId,
            hireGroup: hireGroup,
            vehicleMake: vehicleMake,
            vehicleModel: vehicleModel,
            vehicleCategory: vehicleCategory,
            modelYear: modelYear,
            allowMileage: allowMileage,
            excessMileageCharge: excessMileageCharge,
            standardRate: standardRate,
            startDate: startDate,
            endDate: endDate,
            isChecked: isChecked

        };
        return self;
    };

    //Server To Client Mapper
// ReSharper disable once InconsistentNaming
    var TariffRateClientMapper = function (source) {
        var tariffRate = new TariffRate();
        tariffRate.tariffRateId(source.StandardRtMainId === null ? undefined : source.StandardRtMainId);
        tariffRate.tariffRateCode(source.StandardRtMainCode === null ? undefined : source.StandardRtMainCode);
        tariffRate.tariffRateName(source.StandardRtMainName === null ? undefined : source.StandardRtMainName);
        return tariffRate;
    };
    // ReSharper disable once InconsistentNaming
    var TariffRateDetailClientMapper = function (source) {
        var tariffRate = new TariffRateDetail();
        tariffRate.tariffRateId(source.StandardRtMainId === null ? undefined : source.StandardRtMainId);
        tariffRate.tariffRateCode(source.StandardRtMainCode === null ? undefined : source.StandardRtMainCode);
        tariffRate.tariffRateName(source.StandardRtMainName === null ? undefined : source.StandardRtMainName);
        return tariffRate;
    };
    //Server To Client Mapper
// ReSharper disable once InconsistentNaming
    var HireGroupClientMapper = function (source) {
        var hireGroupDetail = new HireGroupDetail();
        hireGroupDetail.hireGroupDetailId(source.HireGroupDetailId === null ? undefined : source.HireGroupDetailId);
        hireGroupDetail.hireGroup(source.HireGroup === null ? undefined : source.HireGroup);
        hireGroupDetail.vehicleMake(source.VehicleMake === null ? undefined : source.VehicleMake);
        hireGroupDetail.vehicleModel(source.VehicleModel === null ? undefined : source.VehicleModel);
        hireGroupDetail.vehicleCategory(source.VehicleCategory === null ? undefined : source.VehicleCategory);
        hireGroupDetail.modelYear(source.ModelYear === null ? undefined : source.ModelYear);
        hireGroupDetail.allowMileage(source.AllowMileage === null ? undefined : source.AllowMileage);
        hireGroupDetail.excessMileageCharge(source.ExcessMileageCharge === null ? undefined : source.ExcessMileageCharge);
        hireGroupDetail.standardRate(source.StandardRate === null ? undefined : source.StandardRate);
        hireGroupDetail.startDate(source.StartDate !== null ? moment(source.StartDate, ist.utcFormat).toDate() : undefined);
        hireGroupDetail.endDate(source.EndDate !== null ? moment(source.EndDate, ist.utcFormat).toDate() : undefined);
        hireGroupDetail.isChecked(true);
        return hireGroupDetail;
    };
    return {
        TariffRate: TariffRate,
        TariffRateDetail: TariffRateDetail,
        TariffRateClientMapper: TariffRateClientMapper,
        HireGroupDetail: HireGroupDetail,
        HireGroupClientMapper: HireGroupClientMapper,
        TariffRateDetailClientMapper: TariffRateDetailClientMapper
    };
});