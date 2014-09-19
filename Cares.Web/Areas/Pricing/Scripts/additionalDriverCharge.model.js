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
          revisionNumber = ko.observable(0),
           //String valued formatted date
            formattedEffectiveDate = ko.computed({
                read: function () {
                    return moment(effectiveStartDate()).format(ist.datePattern);
                }
            }),
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
            id: id,
            companyId: companyId,
            companyCodeName: companyCodeName,
            depId: depId,
            operationId: operationId,
            operationCodeName: operationCodeName,
            tariffTypeId: tariffTypeId,
            tariffTypeCode: tariffTypeCode,
            tariffTypeCodeName: tariffTypeCodeName,
            effectiveStartDate: effectiveStartDate,
            rate: rate,
            revisionNumber: revisionNumber,
            formattedEffectiveDate:formattedEffectiveDate,
            errors: errors,
            isValid: isValid,
            dirtyFlag: dirtyFlag,
            hasChanges: hasChanges,
            reset: reset,
        };
        return self;
    };

    // ReSharper disable once AssignToImplicitGlobalInFunctionScope
    AdditionalDriverChargeRevision = function () {
        var // Reference to this object
            self,
            //Tariff Type Code
            tariffTypeCode = ko.observable(),
            //Effective Start Date
            effectiveStartDate = ko.observable(),
            //Rate
            rate = ko.observable(),
            //Revision Number
            revisionNumber = ko.observable(0),
            //created By
            createdBy = ko.observable(0),
            //modified By
            modifiedBy = ko.observable(0),
            //modified Date
            modifiedDt = ko.observable(0),
            //String valued formatted date
            formattedEffectiveDate = ko.computed({
                read: function () {
                    return moment(effectiveStartDate()).format(ist.datePattern);
                }
            }),
            //string valued formatted last updated date
            formattedModifiedDate = ko.computed({
                read: function () {
                    return moment(modifiedDt()).format(ist.datePattern);
                }
            });
        self = {
            tariffTypeCode: tariffTypeCode,
            effectiveStartDate: effectiveStartDate,
            rate: rate,
            revisionNumber: revisionNumber,
            createdBy: createdBy,
            modifiedBy: modifiedBy,
            modifiedDt: modifiedDt,
            formattedEffectiveDate: formattedEffectiveDate,
            formattedModifiedDate: formattedModifiedDate,
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
    //Server To Client Mapper
    // ReSharper disable once InconsistentNaming
    var AdditionalDriverChargeRevisionClientMapper = function (source) {
        var addDriverChage = new AdditionalDriverChargeRevision();
        addDriverChage.tariffTypeCode(source.TariffTypeCode === null ? undefined : source.TariffTypeCode);
        addDriverChage.effectiveStartDate(source.StartDt !== null ? moment(source.StartDt, ist.utcFormat).toDate() : undefined);
        addDriverChage.modifiedDt(source.RecLastUpdatedDt !== null ? moment(source.RecLastUpdatedDt, ist.utcFormat).toDate() : undefined);
        addDriverChage.rate(source.AdditionalDriverChargeRate === null ? undefined : source.AdditionalDriverChargeRate);
        addDriverChage.revisionNumber(source.RevisionNumber === null ? undefined : source.RevisionNumber);
        addDriverChage.createdBy(source.RecCreatedBy === null ? undefined : source.RecCreatedBy);
        addDriverChage.modifiedBy(source.RecLastUpdatedBy === null ? undefined : source.RecLastUpdatedBy);

        return addDriverChage;
    };
    // Convert Client to Server
    var AdditionalDriverChrgServerMapper = function (item) {
        var result = {};
        result.AdditionalDriverChargeId = item.id() === undefined ? 0 : item.id();
        result.TariffTypeCode = item.tariffTypeId() === undefined ? null : item.tariffTypeId();
        result.AdditionalDriverChargeRate = item.rate() === undefined ? null : item.rate();
        result.RevisionNumber = item.revisionNumber() === undefined ? 0 : item.revisionNumber();
        result.StartDt = item.effectiveStartDate() === undefined || item.effectiveStartDate() === null ? null : moment(item.effectiveStartDate()).format(ist.utcFormat);
        return result;
    };
    // Convert Client to server
    var AdditionalDriverChrgServerMapperForId = function (source) {
        var result = {};
        result.AdditionalDriverChargeId = source.id() === undefined ? 0 : source.id();
        return result;
    };
    return {
        AdditionalDriverCharge: AdditionalDriverCharge,
        AdditionalDriverChargeClientMapper: AdditionalDriverChargeClientMapper,
        AdditionalDriverChrgServerMapper: AdditionalDriverChrgServerMapper,
        AdditionalDriverChrgServerMapperForId: AdditionalDriverChrgServerMapperForId,
        AdditionalDriverChargeRevision: AdditionalDriverChargeRevision,
        AdditionalDriverChargeRevisionClientMapper: AdditionalDriverChargeRevisionClientMapper
    };
});