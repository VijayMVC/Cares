/*
    Module with the model for the tariff Rate
*/
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
             tariffRateCode = ko.observable().extend({ required: true }),
             // tariff Type Name
             tariffRateName = ko.observable(),
             // Tariff Rate Description
             tariffRateDescription = ko.observable(),
             //Start From
             startEffectiveDate = ko.observable().extend({ required: true }),
             //End To
             //endEffectiveDate = ko.observable().extend({ required: true }),
             //Tariff Type Code Name
             tariffTypeCodeName = ko.observable(),
             //Tariff Type Id
             tariffTypeId = ko.observable().extend({ required: true }),
             //OperationCodeName
             operationCodeName = ko.observable(),
             //Operation Id
             operationId = ko.observable().extend({ required: true }),
             //Hire Group Details In Standard Rate
             hireGroupDetailsInStandardRtMain = ko.observableArray([]),
             // Formatted Start Date for grid
             formattedStartDate = ko.computed({
                 read: function () {
                     return moment(startEffectiveDate()).format(ist.datePattern);
                 }
             }),
             //// Formatted End Date for grid
             //formattedEndDate = ko.computed({
             //    read: function () {
             //        return moment(endEffectiveDate()).format(ist.datePattern);
             //    }
             //}),
             // Convert to server
             convertToServerData = function () {
                 return {
                     StandardRtMainId: tariffRateId(),
                 };
             },
             // Errors
             errors = ko.validation.group({
                 tariffRateCode: tariffRateCode,
                 operationId: operationId,
                 tariffTypeId: tariffTypeId,
                 startEffectiveDate: startEffectiveDate,
                // endEffectiveDate: endEffectiveDate,
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
                 tariffRateDescription: tariffRateDescription,
                 operationId: operationId,
                 startEffectiveDate: startEffectiveDate,
                // endEffectiveDate: endEffectiveDate,
                 tariffTypeId: tariffTypeId,
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
             tariffRateId: tariffRateId,
             tariffRateCode: tariffRateCode,
             tariffRateName: tariffRateName,
             startEffectiveDate: startEffectiveDate,
            // endEffectiveDate: endEffectiveDate,
             convertToServerData: convertToServerData,
             tariffTypeCodeName: tariffTypeCodeName,
             tariffTypeId: tariffTypeId,
             operationCodeName: operationCodeName,
             tariffRateDescription: tariffRateDescription,
             formattedStartDate: formattedStartDate,
             //formattedEndDate: formattedEndDate,
             operationId: operationId,
             errors: errors,
             isValid: isValid,
             dirtyFlag: dirtyFlag,
             hasChanges: hasChanges,
             reset: reset,
             hireGroupDetailsInStandardRtMain: hireGroupDetailsInStandardRtMain

         };
         return self;
     };
    //Hire Group Deatil
    var HireGroupDetail = function () {
        // ReSharper restore InconsistentNaming
        var // Reference to this object
           // Unique key
            hireGroupDetailId = ko.observable(),
            //Virtual Hire Group Id
            virtualHireGroupDetailId = ko.observable(),
            //standard Rate Main Id
            standardRateMainId = ko.observable(),
            //standard Rate Id
            standardRtId = ko.observable(),
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
            //Revision Number
            revisionNumber = ko.observable(),
            //Allow Mileage
            allowMileage = ko.observable().extend({ required: true, number: true }),
            //Excess Mileage Charge
            excessMileageCharge = ko.observable().extend({ required: true, number: true }),
            //Standard Rate
            standardRt = ko.observable().extend({ required: true, number: true }),
            //Start Date
            startDate = ko.observable().extend({ required: true }),
            //End Date
            //endDate = ko.observable().extend({ required: true }),
            //Check whether it is selected against Tariff Rate
            isChecked = ko.observable(false),
              // Errors
                errors = ko.validation.group({
                    allowMileage: allowMileage,
                    excessMileageCharge: excessMileageCharge,
                    standardRt: standardRt,
                    startDate: startDate,
                    //endDate: endDate
                }),
                // Is Valid
                isValid = ko.computed(function () {
                    return errors().length === 0;
                }),
                // True if the booking has been changed
                // ReSharper disable InconsistentNaming
                dirtyFlag = new ko.dirtyFlag({
                    allowMileage: allowMileage,
                    excessMileageCharge: excessMileageCharge,
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
            hireGroupDetailId: hireGroupDetailId,
            virtualHireGroupDetailId: virtualHireGroupDetailId,
            standardRateMainId: standardRateMainId,
            excessMileageCharge: excessMileageCharge,
            standardRtId: standardRtId,
            hireGroup: hireGroup,
            vehicleMake: vehicleMake,
            vehicleModel: vehicleModel,
            vehicleCategory: vehicleCategory,
            modelYear: modelYear,
            revisionNumber: revisionNumber,
            allowMileage: allowMileage,
            standardRt: standardRt,
            startDate: startDate,
            //endDate: endDate,
            isChecked: isChecked,
            errors: errors,
            isValid: isValid,
            dirtyFlag: dirtyFlag,
            hasChanges: hasChanges,
            reset: reset,
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
        tariffRate.tariffRateDescription(source.StandardRtMainDescription === null ? undefined : source.StandardRtMainDescription);
        tariffRate.startEffectiveDate(source.StartDt !== null ? moment(source.StartDt, ist.utcFormat).toDate() : undefined);
        //tariffRate.endEffectiveDate(source.EndDt !== null ? moment(source.EndDt, ist.utcFormat).toDate() : undefined);
        tariffRate.tariffTypeCodeName(source.TariffTypeCodeName === null ? undefined : source.TariffTypeCodeName);
        tariffRate.tariffTypeId(source.TariffTypeId === null ? undefined : source.TariffTypeId);
        tariffRate.operationCodeName(source.OperationCodeName === null ? undefined : source.OperationCodeName);
        tariffRate.operationId(source.OperationId === null ? undefined : source.OperationId);
        return tariffRate;
    };
    //Server To Client Mapper
    // ReSharper disable once InconsistentNaming
    var TariffRateCoppier = function (source) {
        var tariffRate = new TariffRate();
        tariffRate.tariffRateId(source.tariffRateId() === null ? undefined : source.tariffRateId());
        tariffRate.tariffRateCode(source.tariffRateCode() === null ? undefined : source.tariffRateCode());
        tariffRate.tariffRateName(source.tariffRateName() === null ? undefined : source.tariffRateName());
        tariffRate.tariffRateDescription(source.tariffRateDescription() === null ? undefined : source.tariffRateDescription());
        tariffRate.startEffectiveDate(source.startEffectiveDate() === null ? undefined : source.startEffectiveDate());
       // tariffRate.endEffectiveDate(source.endEffectiveDate() === null ? undefined : source.endEffectiveDate());
        tariffRate.tariffTypeCodeName(source.tariffTypeCodeName() === null ? undefined : source.tariffTypeCodeName());
        tariffRate.tariffTypeId(source.tariffTypeId() === null ? undefined : source.tariffTypeId());
        tariffRate.operationCodeName(source.operationCodeName() === null ? undefined : source.operationCodeName());
        tariffRate.operationId(source.operationId() === null ? undefined : source.operationId());
        return tariffRate;
    };
    //Client To Server Mapper
    // ReSharper disable once InconsistentNaming
    var TariffRateServerMapper = function (source) {
        var result = {};
        result.StandardRtMainId = source.tariffRateId() === undefined ? 0 : source.tariffRateId();
        result.TariffTypeCode = source.tariffRateCode() === undefined ? null : source.tariffRateCode();
        result.StandardRtMainCode = source.tariffRateCode() === undefined ? null : source.tariffRateCode();
        result.StandardRtMainDescription = source.tariffRateDescription() === undefined ? null : source.tariffRateDescription();
        result.StandardRtMainName = source.tariffRateName() === undefined ? null : source.tariffRateName();
        result.StartDt = source.startEffectiveDate() === undefined || source.startEffectiveDate() === null ? undefined : moment(source.startEffectiveDate()).format(ist.utcFormat);
        //result.EndDt = source.endEffectiveDate() === undefined || source.endEffectiveDate() === null ? undefined : moment(source.endEffectiveDate()).format(ist.utcFormat);
        result.OperationId = source.operationId();
        result.TariffTypeId = source.tariffTypeId();
        result.HireGroupDetailsInStandardRtMain = [];
        _.each(source.hireGroupDetailsInStandardRtMain(), function (item) {
            result.HireGroupDetailsInStandardRtMain.push(HireGroupServerMapper(item));
        });

        return result;
    };
    //Client To Server Mapper
    // ReSharper disable once InconsistentNaming
    var HireGroupServerMapper = function (source) {
        var result = {};
        result.HireGroupDetailId = source.hireGroupDetailId() === undefined ? 0 : source.hireGroupDetailId();
        result.StandardRtId = source.standardRtId() === undefined ? 0 : source.standardRtId();
        result.AllowMileage = source.allowMileage() === undefined ? null : source.allowMileage();
        result.RevisionNumber = source.revisionNumber() === undefined ? null : source.revisionNumber();
        result.ExcessMileageCharge = source.excessMileageCharge() === undefined ? null : source.excessMileageCharge();
        result.StandardRt = source.standardRt() === undefined ? null : source.standardRt();
        result.StartDate = source.startDate() === undefined || source.startDate() === null ? undefined : moment(source.startDate()).format(ist.utcFormat);
        //result.EndDt = source.endDate() === undefined || source.endDate() === null ? undefined : moment(source.endDate()).format(ist.utcFormat);
        return result;
    };
    //Server To Client Mapper
    // ReSharper disable once InconsistentNaming
    var HireGroupClientMapper = function (source) {
        var hireGroupDetail = new HireGroupDetail();
        hireGroupDetail.hireGroupDetailId(source.HireGroupDetailId === null ? undefined : source.HireGroupDetailId);
        hireGroupDetail.standardRtId(source.StandardRtId === null ? undefined : source.StandardRtId);
        hireGroupDetail.standardRateMainId(source.StandardRateMainId === null ? undefined : source.StandardRateMainId);
        hireGroupDetail.hireGroup(source.HireGroup === null ? undefined : source.HireGroup);
        hireGroupDetail.vehicleMake(source.VehicleMake === null ? undefined : source.VehicleMake);
        hireGroupDetail.vehicleModel(source.VehicleModel === null ? undefined : source.VehicleModel);
        hireGroupDetail.revisionNumber(source.RevisionNumber === null ? 0 : source.RevisionNumber);
        hireGroupDetail.vehicleCategory(source.VehicleCategory === null ? undefined : source.VehicleCategory);
        hireGroupDetail.modelYear(source.ModelYear === null ? undefined : source.ModelYear);
        hireGroupDetail.allowMileage(source.AllowMileage === null || source.AllowMileage === 0 ? undefined : source.AllowMileage);
        hireGroupDetail.excessMileageCharge(source.ExcessMileageCharge === null || source.ExcessMileageCharge === 0 ? undefined : source.ExcessMileageCharge);
        hireGroupDetail.standardRt(source.StandardRt === null || source.StandardRt === 0 ? undefined : source.StandardRt);
        hireGroupDetail.startDate(source.StartDate !== null ? moment(source.StartDate, ist.utcFormat).toDate() : undefined);
        //hireGroupDetail.endDate(source.EndDate !== null ? moment(source.EndDate, ist.utcFormat).toDate() : undefined);
        hireGroupDetail.isChecked(source.IsChecked === null ? false : source.IsChecked);
        hireGroupDetail.virtualHireGroupDetailId(source.IsChecked === true ? source.HireGroupDetailId : 0);
        return hireGroupDetail;
    };
    return {
        TariffRate: TariffRate,
        TariffRateClientMapper: TariffRateClientMapper,
        HireGroupDetail: HireGroupDetail,
        HireGroupClientMapper: HireGroupClientMapper,
        TariffRateServerMapper: TariffRateServerMapper,
        TariffRateCoppier: TariffRateCoppier,
        HireGroupServerMapper: HireGroupServerMapper
    };
});