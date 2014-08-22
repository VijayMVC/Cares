/*
    Module with the model for the Service Rate
*/
define(["ko", "underscore", "underscore-ko"], function (ko) {
    var
        //Service Main Rate entity
        // ReSharper disable InconsistentNaming
     ServiceRtMain = function () {
         // ReSharper restore InconsistentNaming
         var // Reference to this object
             self,
             // Unique key
             serviceRtMainId = ko.observable(),
              //Service Rate Main Code
             serviceRtMainCode = ko.observable().extend({ required: true }),
             //Service Rate Name
             serviceRtMainName = ko.observable(),
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
              //Service Rate In Service Rate Main
             serviceItemRts = ko.observableArray([]),
              // Formatted Start Date for grid
             formattedStartDate = ko.computed({
                 read: function () {
                     return moment(startDt()).format(ist.datePattern);
                 }
             }),
             // Errors
             errors = ko.validation.group({
                 serviceRtMainCode: serviceRtMainCode,
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
                     serviceRtMainId: serviceRtMainId(),
                 };
             },
             // True if the booking has been changed
             // ReSharper disable InconsistentNaming
             dirtyFlag = new ko.dirtyFlag({
                 serviceRtMainCode: serviceRtMainCode,
                 serviceRtMainName: serviceRtMainName,
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
             serviceRtMainId: serviceRtMainId,
             serviceRtMainCode: serviceRtMainCode,
             serviceRtMainName: serviceRtMainName,
             description: description,
             tariffTypeId: tariffTypeId,
             startDt: startDt,
             operationId: operationId,
             tariffTypeCodeName: tariffTypeCodeName,
             operationCodeName: operationCodeName,
             formattedStartDate: formattedStartDate,
             serviceItemRts: serviceItemRts,
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
    ServiceItemRt = function () {
        // ReSharper restore InconsistentNaming
        var // Reference to this object
            self,
            // Unique key
            serviceRtId = ko.observable(),
            //Virtual Id
             virtualServiceRtId = ko.observable(),
            //Service Item ID
            serviceItemId = ko.observable(),
            //Service Rate
            serviceRate = ko.observable().extend({ required: true, number: true }),
            //Start Date
            startDt = ko.observable().extend({ required: true }),
            //Servie Item Code
            serviceItemCode = ko.observable(),
            //Service Item Name
            serviceItemName = ko.observable(),
            //Service Type Code Name
            serviceTypeCodeName = ko.observable(),
            //Revision Number
            revisionNumber = ko.observable(),
           //Is Checked         
            isChecked = ko.observable(),
            //Virtual Is Checked
            virtualIsChecked = ko.observable(),
                       // Errors
           errors = ko.validation.group({
               serviceRate: serviceRate,
               startDt: startDt
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
            serviceRtId: serviceRtId,
            virtualServiceRtId: virtualServiceRtId,
            serviceItemId: serviceItemId,
            serviceRate: serviceRate,
            startDt: startDt,
            serviceItemCode: serviceItemCode,
            serviceItemName: serviceItemName,
            serviceTypeCodeName: serviceTypeCodeName,
            revisionNumber: revisionNumber,
            isChecked: isChecked,
            virtualIsChecked: virtualIsChecked,
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
    var ServiceRtMainClientMapper = function (source) {
        var serviceRtMain = new ServiceRtMain();
        serviceRtMain.serviceRtMainId(source.ServiceRtMainId === null ? undefined : source.ServiceRtMainId);
        serviceRtMain.serviceRtMainCode(source.ServiceRtMainCode === null ? undefined : source.ServiceRtMainCode);
        serviceRtMain.serviceRtMainName(source.ServiceRtMainName === null ? undefined : source.ServiceRtMainName);
        serviceRtMain.description(source.ServiceRtMainDescription === null ? undefined : source.ServiceRtMainDescription);
        serviceRtMain.startDt(source.StartDt !== null ? moment(source.StartDt, ist.utcFormat).toDate() : undefined);
        serviceRtMain.tariffTypeId(source.TariffTypeId === null ? undefined : source.TariffTypeId);
        serviceRtMain.operationId(source.OperationId === null ? undefined : source.OperationId);
        serviceRtMain.tariffTypeCodeName(source.TariffTypeCodeName === null ? undefined : source.TariffTypeCodeName);
        serviceRtMain.operationCodeName(source.OperationCodeName === null ? undefined : source.OperationCodeName);
        return serviceRtMain;
    };
    //Server To Client Mapper
    // ReSharper disable once InconsistentNaming
    var ServiceItemRtClientMapper = function (source) {
        var serviceItemRt = new ServiceItemRt();
        serviceItemRt.serviceRtId(source.ServiceRtId === null ? undefined : source.ServiceRtId);
        serviceItemRt.virtualServiceRtId(source.ServiceRtId === null ? undefined : source.ServiceRtId);
        serviceItemRt.serviceItemId(source.ServiceItemId === null ? 0 : source.ServiceItemId);
        serviceItemRt.serviceRate(source.ServiceRate === null ? undefined : source.ServiceRate);
        serviceItemRt.serviceItemCode(source.ServiceItemCode === null ? undefined : source.ServiceItemCode);
        serviceItemRt.serviceItemName(source.ServiceItemName === null ? undefined : source.ServiceItemName);
        serviceItemRt.serviceTypeCodeName(source.ServiceTypeCodeName === null ? undefined : source.ServiceTypeCodeName);
        serviceItemRt.startDt(source.StartDt !== null ? moment(source.StartDt, ist.utcFormat).toDate() : undefined);
        serviceItemRt.isChecked(source.IsChecked === null ? false : source.IsChecked);
        serviceItemRt.virtualIsChecked(source.IsChecked === null ? false : source.IsChecked);
        serviceItemRt.revisionNumber(source.RevisionNumber === null ? 0 : source.RevisionNumber);
        return serviceItemRt;
    };
    //Client To Server Mapper
    var ServiceRtMainServerMapper = function (source) {
        var result = {};
        result.InsuranceRtMainId = source.serviceRtMainId() === undefined ? 0 : source.serviceRtMainId();
        result.ServiceRtMainCode = source.serviceRtMainCode() === undefined ? null : source.serviceRtMainCode();
        result.ServiceRtMainName = source.serviceRtMainName() === undefined ? null : source.serviceRtMainName();
        result.ServiceRtMainDescription = source.description() === undefined ? null : source.description();
        result.StartDt = source.startDt() === undefined || source.startDt() === null ? undefined : moment(source.startDt()).format(ist.utcFormat);
        result.OperationId = source.operationId();
        result.TariffTypeId = source.tariffTypeId();
        result.ServiceRts = [];
        _.each(source.serviceItemRts(), function (item) {
            result.ServiceRts.push(ServiceItemRtServerMapper(item));
        });
        return result;
    };
    //Client To Server Mapper
    var ServiceItemRtServerMapper = function (source) {
        var result = {};
        result.ServiceRtId = source.serviceRtId() === undefined ? 0 : source.serviceRtId();
        result.ServiceItemId = source.serviceItemId() === undefined ? null : source.serviceItemId();
        result.ServiceRate = source.serviceRate() === undefined ? null : source.serviceRate();
        result.startDt = source.startDt() === undefined || source.startDt() === null ? undefined : moment(source.startDt()).format(ist.utcFormat);
        return result;
    };
    return {
        ServiceRtMain: ServiceRtMain,
        ServiceItemRt: ServiceItemRt,
        ServiceRtMainClientMapper: ServiceRtMainClientMapper,
        ServiceItemRtClientMapper: ServiceItemRtClientMapper,
        ServiceItemRtServerMapper: ServiceItemRtServerMapper,
        ServiceRtMainServerMapper: ServiceRtMainServerMapper
    };
});