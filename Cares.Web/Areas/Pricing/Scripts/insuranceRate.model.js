/*
    Module with the model for the Insurance Rate
*/
define(["ko", "underscore", "underscore-ko"], function (ko) {
    var
        //Insurance Main Rate entity
        // ReSharper disable InconsistentNaming
     InsuranceRtMain = function () {
         // ReSharper restore InconsistentNaming
         var // Reference to this object
             self,
             // Unique key
             insuranceRtMainId = ko.observable(),
             //Insurance Rate Main Code
             insuranceRtMainCode = ko.observable().extend({ required: true }),
             //Insurance Rate Name
             insuranceRtName = ko.observable(),
             //Description
             description = ko.observable(),
             //Tariff Type Code Name
             tariffTypeCodeName = ko.observable(),
             //Tariff Type Id
             tariffTypeId = ko.observable().extend({ required: true }),
             //Start Date
             startDt = ko.observable().extend({ required: true }),
             //Operation Id
             operationId = ko.observable().extend({ required: true }),
             //Operation Code Name
             operationCodeName = ko.observable(),
              //Insurance Rate In Insurance Rate Main
             insuranceRts = ko.observableArray([]),
              // Formatted Start Date for grid
             formattedStartDate = ko.computed({
                 read: function () {
                     return moment(startDt()).format(ist.datePattern);
                 }
             }),
             // Errors
             errors = ko.validation.group({
                 insuranceRtMainCode: insuranceRtMainCode,
                 tariffTypeId: tariffTypeId,
                 startDt: startDt,
                 operationId: operationId
             }),
             // Is Valid
             isValid = ko.computed(function () {
                 return errors().length === 0;
             }),
              // Convert to server
             convertToServerData = function () {
                 return {
                     InsuranceRtMainId: insuranceRtMainId(),
                 };
             },
             // True if the booking has been changed
             // ReSharper disable InconsistentNaming
             dirtyFlag = new ko.dirtyFlag({
                 insuranceRtMainCode: insuranceRtMainCode,
                 insuranceRtName: insuranceRtName,
                 description: description,
                 tariffTypeId: tariffTypeId,
                 startDt: startDt,
                 operationId: operationId
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
             insuranceRtMainId: insuranceRtMainId,
             insuranceRtMainCode: insuranceRtMainCode,
             insuranceRtName: insuranceRtName,
             description: description,
             tariffTypeId: tariffTypeId,
             startDt: startDt,
             operationId: operationId,
             tariffTypeCodeName: tariffTypeCodeName,
             operationCodeName: operationCodeName,
             formattedStartDate: formattedStartDate,
             insuranceRts: insuranceRts,
             errors: errors,
             isValid: isValid,
             dirtyFlag: dirtyFlag,
             hasChanges: hasChanges,
             reset: reset,
             convertToServerData: convertToServerData,


         };
         return self;
     };
    // ReSharper disable once AssignToImplicitGlobalInFunctionScope
    InsuranceTypeRt = function () {
        // ReSharper restore InconsistentNaming
        var // Reference to this object
            self,
            // Unique key
            insuranceRtId = ko.observable(),
            //Virtual Id
            virtualInsuranceRtId = ko.observable(),
            //Insurance Rate Main Id
            insuranceRtMainId = ko.observable(),
            //Insurance Type Id
            insuranceTypeId = ko.observable(),
            //Insurance Type Code Name
            insuranceTypeCodeName = ko.observable(),
            //Hire Group Deatil Code Name
            hireGroupDetailCodeName = ko.observable(),
            //Hire Group Detail ID
            hireGroupDetailId = ko.observable(),
            //Vehicel Make Code Name
            vehicleMakeCodeName = ko.observable(),
            //Vehicle Model Code Name
            vehicleModelCodeName = ko.observable(),
            //Vehicel Category Code Name
            vehicleCategoryCodeName = ko.observable(),
            //Model Year
            modelYear = ko.observable(),
            //Insurance Rate
            insuranceRate = ko.observable().extend({ required: true }),
            //Start Date
            startDate = ko.observable().extend({ required: true }),
            //Is checked
            isChecked = ko.observable(),
             //Virtual Is checked
            virtualIsChecked = ko.observable(),
            //Revision Number
            revisionNumber = ko.observable(),

            // Errors
            errors = ko.validation.group({
                insuranceRate: insuranceRate,
                startDate: startDate,
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
            insuranceRtId: insuranceRtId,
            virtualInsuranceRtId: virtualInsuranceRtId,
            insuranceRtMainId: insuranceRtMainId,
            insuranceTypeId: insuranceTypeId,
            insuranceTypeCodeName: insuranceTypeCodeName,
            hireGroupDetailCodeName: hireGroupDetailCodeName,
            hireGroupDetailId: hireGroupDetailId,
            vehicleMakeCodeName: vehicleMakeCodeName,
            vehicleModelCodeName: vehicleModelCodeName,
            vehicleCategoryCodeName: vehicleCategoryCodeName,
            modelYear: modelYear,
            insuranceRate: insuranceRate,
            startDate: startDate,
            isChecked: isChecked,
            virtualIsChecked: virtualIsChecked,
            revisionNumber: revisionNumber,
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
    var InsuranceRtMainClientMapper = function (source) {
        var insuranceRtMain = new InsuranceRtMain();
        insuranceRtMain.insuranceRtMainId(source.InsuranceRtMainId === null ? undefined : source.InsuranceRtMainId);
        insuranceRtMain.insuranceRtMainCode(source.InsuranceRtMainCode === null ? undefined : source.InsuranceRtMainCode);
        insuranceRtMain.insuranceRtName(source.InsuranceRtName === null ? undefined : source.InsuranceRtName);
        insuranceRtMain.description(source.InsuranceRtMainDescription === null ? undefined : source.InsuranceRtMainDescription);
        insuranceRtMain.startDt(source.StartDt !== null ? moment(source.StartDt, ist.utcFormat).toDate() : undefined);
        insuranceRtMain.tariffTypeId(source.TariffTypeId === null ? undefined : source.TariffTypeId);
        insuranceRtMain.operationId(source.OperationId === null ? undefined : source.OperationId);
        insuranceRtMain.tariffTypeCodeName(source.TariffTypeCodeName === null ? undefined : source.TariffTypeCodeName);
        insuranceRtMain.operationCodeName(source.OperationCodeName === null ? undefined : source.OperationCodeName);
        return insuranceRtMain;
    };
    //Insurance Rate Main Copier
    var InsuranceRtMainCopier = function (source) {
        var insuranceRtMain = new InsuranceRtMain();
        insuranceRtMain.insuranceRtMainId(source.insuranceRtMainId() === null ? undefined : source.insuranceRtMainId());
        insuranceRtMain.insuranceRtMainCode(source.insuranceRtMainCode() === null ? undefined : source.insuranceRtMainCode());
        insuranceRtMain.insuranceRtName(source.insuranceRtName() === null ? undefined : source.insuranceRtName());
        insuranceRtMain.description(source.description() === null ? undefined : source.description());
        insuranceRtMain.startDt(source.startDt() !== null ? moment(source.startDt(), ist.utcFormat).toDate() : undefined);
        insuranceRtMain.tariffTypeId(source.tariffTypeId() === null ? undefined : source.tariffTypeId());
        insuranceRtMain.operationId(source.operationId() === null ? undefined : source.operationId());
        insuranceRtMain.tariffTypeCodeName(source.tariffTypeCodeName() === null ? undefined : source.tariffTypeCodeName());
        insuranceRtMain.operationCodeName(source.operationCodeName() === null ? undefined : source.operationCodeName());
        return insuranceRtMain;
    };
    //Server To Client Mapper
    // ReSharper disable once InconsistentNaming
    var InsuranceTypeRtClientMapper = function (source) {
        var insuranceTypeRt = new InsuranceTypeRt();
        insuranceTypeRt.insuranceRtId(source.InsuranceRtId === null ? undefined : source.InsuranceRtId);
        insuranceTypeRt.virtualInsuranceRtId(source.InsuranceRtId === null ? 0 : source.InsuranceRtId);
        insuranceTypeRt.insuranceRtMainId(source.InsuranceRtMainId === null ? undefined : source.InsuranceRtMainId);
        insuranceTypeRt.insuranceTypeId(source.InsuranceTypeId === null ? undefined : source.InsuranceTypeId);
        insuranceTypeRt.insuranceTypeCodeName(source.InsuranceTypeCodeName === null ? undefined : source.InsuranceTypeCodeName);
        insuranceTypeRt.hireGroupDetailCodeName(source.HireGroupDetailCodeName === null ? undefined : source.HireGroupDetailCodeName);
        insuranceTypeRt.startDate(source.StartDate !== null ? moment(source.StartDate, ist.utcFormat).toDate() : undefined);
        insuranceTypeRt.hireGroupDetailId(source.HireGroupDetailId === null ? undefined : source.HireGroupDetailId);
        insuranceTypeRt.vehicleMakeCodeName(source.VehicleMakeCodeName === null ? undefined : source.VehicleMakeCodeName);
        insuranceTypeRt.vehicleModelCodeName(source.VehicleModelCodeName === null ? undefined : source.VehicleModelCodeName);
        insuranceTypeRt.vehicleCategoryCodeName(source.VehicleCategoryCodeName === null ? undefined : source.VehicleCategoryCodeName);
        insuranceTypeRt.modelYear(source.ModelYear === null ? undefined : source.ModelYear);
        insuranceTypeRt.insuranceRate(source.InsuranceRate === null ? undefined : source.InsuranceRate);
        insuranceTypeRt.isChecked(source.IsChecked === null ? false : source.IsChecked);
        insuranceTypeRt.virtualIsChecked(source.IsChecked === null ? false : source.IsChecked);
        insuranceTypeRt.revisionNumber(source.RevisionNumber === null ? 0 : source.RevisionNumber);
        return insuranceTypeRt;
    };
    //Client To Server Mapper
    var InsuranceRtServerMapper = function (source) {
        var result = {};
        result.InsuranceRtMainId = source.insuranceRtMainId() === undefined ? 0 : source.insuranceRtMainId();
        result.InsuranceRtMainCode = source.insuranceRtMainCode() === undefined ? null : source.insuranceRtMainCode();
        result.InsuranceRtName = source.insuranceRtName() === undefined ? null : source.insuranceRtName();
        result.InsuranceRtMainDescription = source.description() === undefined ? null : source.description();
        result.StartDt = source.startDt() === undefined || source.startDt() === null ? undefined : moment(source.startDt()).format(ist.utcFormat);
        result.OperationId = source.operationId();
        result.TariffTypeId = source.tariffTypeId();
        result.InsuranceRts = [];
        _.each(source.insuranceRts(), function (item) {
            result.InsuranceRts.push(InsuranceTypeRtServerMapper(item));
        });
        return result;
    };
    //Client To Server Mapper
    // ReSharper disable once InconsistentNaming
    var InsuranceTypeRtServerMapper = function (source) {
        var result = {};
        result.InsuranceRtId = source.insuranceRtId() === undefined ? 0 : source.insuranceRtId();
        result.InsuranceTypeId = source.insuranceTypeId() === undefined ? 0 : source.insuranceTypeId();
        result.HireGroupDetailId = source.hireGroupDetailId() === undefined ? null : source.hireGroupDetailId();
        result.InsuranceTypeId = source.insuranceTypeId() === undefined ? 0 : source.insuranceTypeId();
        result.InsuranceRate = source.insuranceRate() === undefined ? 0 : source.insuranceRate();
        result.RevisionNumber = source.revisionNumber() === undefined ? 0 : source.revisionNumber();
        result.StartDate = source.startDate() === undefined || source.startDate() === null ? undefined : moment(source.startDate()).format(ist.utcFormat);
        return result;
    };
    return {
        InsuranceRtMain: InsuranceRtMain,
        InsuranceRtMainClientMapper: InsuranceRtMainClientMapper,
        InsuranceTypeRt: InsuranceTypeRt,
        InsuranceTypeRtClientMapper: InsuranceTypeRtClientMapper,
        InsuranceRtServerMapper: InsuranceRtServerMapper,
        InsuranceRtMainCopier: InsuranceRtMainCopier
    };
});