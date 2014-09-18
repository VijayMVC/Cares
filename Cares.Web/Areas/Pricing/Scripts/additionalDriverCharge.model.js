/*
    Module with the model for the Additional Driver Charge
*/
define(["ko", "underscore", "underscore-ko"], function (ko) {
    var
   //Additional Driver Charge Entity
    // ReSharper disable once InconsistentNaming
    AdditionalDriverCharge = function () {
        var // Reference to this object
          self,
          // Unique key
          id = ko.observable(),
          //Company Id
          companyId = ko.observable().extend({ required: true }),
          //Company Code Name
          companyCodeName = ko.observable(),
          //Department ID
          depId = ko.observable().extend({ required: true }),
          //opeartion Id
          operationId = ko.observable().extend({ required: true }),
          //operation Code Name
          operationCodeName = ko.observable(),
          //Tariff Type Id
           tariffTypeId = ko.observable().extend({ required: true }),
           //Tariff Type Code
          tariffTypeCode = ko.observable(),
          //Tariff Type Code Name
          tariffTypeCodeName = ko.observable(),
         //Effective Start Date
          effectiveStartDate = ko.observable().extend({ required: true }),
          //Rate
          rate = ko.observable().extend({ required: true, number: true }),
          //Revision Number
          revisionNumber = ko.observable(),

              // Errors
            errors = ko.validation.group({
                companyId: companyId,
                depId: depId,
                operationId: operationId,
                tariffTypeId: tariffTypeId,
                effectiveStartDate: effectiveStartDate,
                rate: rate,
               
            }),
            // Is Valid
            isValid = ko.computed(function () {
                return errors().length === 0;
            }),

            // True if the booking has been changed
            // ReSharper disable InconsistentNaming
            dirtyFlag = new ko.dirtyFlag({
                companyId: companyId,
                depId: depId,
                operationId: operationId,
                tariffTypeId: tariffTypeId,
                effectiveStartDate: effectiveStartDate,
                rate: rate,
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
            id:id,
            companyId: companyId,
            companyCodeName:companyCodeName,
            depId: depId,
            operationId: operationId,
            operationCodeName: operationCodeName,
            tariffTypeId: tariffTypeId,
            tariffTypeCode: tariffTypeCode,
            tariffTypeCodeName: tariffTypeCodeName,
            effectiveStartDate: effectiveStartDate,
            rate: rate,
            revisionNumber:revisionNumber,
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
    var AdditionalDriverChargeClientMapper = function (source) {
        var addDriverChage = new AdditionalDriverCharge();
        addDriverChage.id(source.AdditionalDriverChargeId === null ? undefined : source.AdditionalDriverChargeId);
        addDriverChage.companyId(source.CompanyId === null ? undefined : source.CompanyId);
        addDriverChage.companyCodeName(source.CompanyCodeName === null ? undefined : source.CompanyCodeName);
        addDriverChage.depId(source.DepartmentId === null ? undefined : source.DepartmentId);
        addDriverChage.operationId(source.OperationId === null ? undefined : source.OperationId);
        addDriverChage.operationCodeName(source.OperationCodeName === null ? undefined : source.OperationCodeName);
        addDriverChage.tariffTypeId(source.TariffTypeId === null ? undefined : source.TariffTypeId);
        addDriverChage.tariffTypeCode(source.TariffTypeCode === null ? undefined : source.TariffTypeCode);
        addDriverChage.tariffTypeCodeName(source.TariffTypeCodeName === null ? undefined : source.TariffTypeCodeName);
        addDriverChage.effectiveStartDate(source.StartDt !== null ? moment(source.StartDt, ist.utcFormat).toDate() : undefined);
        addDriverChage.rate(source.AdditionalDriverChargeRate === null ? undefined : source.AdditionalDriverChargeRate);
        addDriverChage.revisionNumber(source.RevisionNumber === null ? undefined : source.RevisionNumber);
       
        return addDriverChage;
    };
    return {
        AdditionalDriverCharge: AdditionalDriverCharge,
        AdditionalDriverChargeClientMapper:AdditionalDriverChargeClientMapper
    };
});