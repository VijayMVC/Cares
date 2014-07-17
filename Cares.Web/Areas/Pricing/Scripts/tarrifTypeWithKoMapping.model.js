define(["ko", "underscore", "underscore-ko"], function (ko) {

    var

    // Tarrif Type entity - Using Knockout Mapping
    // ReSharper disable InconsistentNaming
    TarrifType = function (data) {
        // ReSharper restore InconsistentNaming
        var // Reference to this object
            self = {};

        // Map data to self
        ko.mapping.fromJS(data, null, self);

        return {

            tariffTypeId: self.TariffTypeId,
            measurementUnit: self.MeasurementUnit,
            tariffTypeCode: self.TariffTypeCode,
            tarrifTypeName: self.TariffTypeName,
            pricingScheme: self.PricingScheme,
            companay: self.Companay,
            operation: self.Operation,
            gracePeriod: self.GracePeriod,
            effectiveDate: self.EffectiveDate,
            durationFrom: self.DurationFrom,
            revisionNumber: self.RevisionNumber,
            durationTo: self.DurationTo
        };
    };

    var TarrifTypeDetail = function () {
        // ReSharper restore InconsistentNaming
        var // Reference to this object
            // Unique key
            tarrifTypeId = ko.observable(),
            // Operation ID
            operationId = ko.observable().extend({ required: true }),
            // Measurement Unit ID
            measurementUnitId = ko.observable().extend({ required: true }),
            //Company ID
            companyId = ko.observable().extend({ required: true }),
             //Department ID
            departmentId = ko.observable().extend({ required: true }),
            // Tariff Type Code 
            tariffTypeCode = ko.observable().extend({ required: true }),
            // Tarrif Type Name
            tarrifTypeName = ko.observable(),
            //Tariff Type Description
            tariffTypeDescription = ko.observable(),
            //Pricing Strategy ID
            pricingStrategyId = ko.observable().extend({ required: true }),
            //Duration From
            durationFrom = ko.observable().extend({ required: true, number: true }),
            //Duration To
            durationTo = ko.observable().extend({ required: true, number: true }),
            //Grace Period
            gracePeriod = ko.observable().extend({ required: true, number: true }),
            //Effective Date
            effectiveDate = ko.observable().extend({ date: true, required: true, }),
            //Revision Number
            revisionNumber = ko.observable(),
            //Row Version
            rowVersion = ko.observable(),
            //ChildTariffTypeID
            childTariffTypeId = ko.observable(),
            //Rec Created Date
            recCreatedDt = ko.observable(),
            //RecLast Updated Date
            recLastUpdatedDt = ko.observable(),
            //Rec Last Updated By
            recLastUpdatedBy = ko.observable(),
            //Rec Created By
            recCreatedBy = ko.observable(),
            isBusy = ko.observable(false),

            // Errors
            errors = ko.validation.group({
                companyId: companyId,
                tariffTypeCode: tariffTypeCode,
                departmentId: departmentId,
                operationId: operationId,
                measurementUnitId: measurementUnitId,
                durationFrom: durationFrom,
                durationTo: durationTo,
                gracePeriod: gracePeriod,
                effectiveDate: effectiveDate,
                pricingStrategyId: pricingStrategyId,

            }),
            // Is Valid
            isValid = ko.computed(function () {
                return errors().length === 0;
            }),
            // True if the booking has been changed
            // ReSharper disable InconsistentNaming
            dirtyFlag = new ko.dirtyFlag({
                companyId: companyId,
                tariffTypeCode: tariffTypeCode,
                departmentId: departmentId,
                operationId: operationId,
                measurementUnitId: measurementUnitId,
                durationFrom: durationFrom,
                durationTo: durationTo,
                gracePeriod: gracePeriod,
                effectiveDate: effectiveDate,
                pricingStrategyId: pricingStrategyId,

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
            tarrifTypeId: tarrifTypeId,
            //userDomainKey: userDomainKey,
            operationId: operationId,
            measurementUnitId: measurementUnitId,
            departmentId: departmentId,
            companyId: companyId,
            tariffTypeCode: tariffTypeCode,
            tarrifTypeName: tarrifTypeName,
            tariffTypeDescription: tariffTypeDescription,
            pricingStrategyId: pricingStrategyId,
            durationFrom: durationFrom,
            durationTo: durationTo,
            gracePeriod: gracePeriod,
            effectiveDate: effectiveDate,
            revisionNumber: revisionNumber,
            rowVersion: rowVersion,
            childTariffTypeId: childTariffTypeId,
            recCreatedDt: recCreatedDt,
            recLastUpdatedDt: recLastUpdatedDt,
            recLastUpdatedBy: recLastUpdatedBy,
            recCreatedBy: recCreatedBy,
           
            errors: errors,
            isValid: isValid,
            dirtyFlag: dirtyFlag,
            hasChanges: hasChanges,
            reset: reset,
            isBusy: isBusy,
            //convertToServerData: convertToServerData
        };
        return self;
    };
    //Client To Server Mapper
    var TariffTypeServerMapper = function (tariffTypeObj) {
        var result = {};
        result.TariffTypeId = tariffTypeObj().tarrifTypeId() === undefined || tariffTypeObj().tarrifTypeId() === null ? 0 : tariffTypeObj().tarrifTypeId();
        result.TariffTypeCode = tariffTypeObj().tariffTypeCode() === undefined || tariffTypeObj().tariffTypeCode() === null ? 0 : tariffTypeObj().tariffTypeCode();
        result.TariffTypeName = tariffTypeObj().tarrifTypeName();
        result.TariffTypeDescription = tariffTypeObj().tariffTypeDescription();
        result.CompanyId = tariffTypeObj().companyId();
        result.DepartmentId = tariffTypeObj().departmentId();
        result.OperationId = tariffTypeObj().operationId();
        result.MeasurementUnitId = tariffTypeObj().measurementUnitId();
        result.DurationFrom = tariffTypeObj().durationFrom();
        result.DurationTo = tariffTypeObj().durationTo();
        result.GracePeriod = tariffTypeObj().gracePeriod();
        result.EffectiveDate = tariffTypeObj().effectiveDate() === undefined || tariffTypeObj().effectiveDate() === null ? undefined : moment(tariffTypeObj().effectiveDate()).format(ist.utcFormat);
        result.PricingStrategyId = tariffTypeObj().pricingStrategyId();
        result.RevisionNumber = tariffTypeObj().revisionNumber();
        return result;
    };
    //Server To Client Mapper
    var TariffTypeClientMapper = function (source) {
        var tarrifType = new TarrifTypeDetail();
        tarrifType.tarrifTypeId(source.TariffTypeId === null ? undefined : source.TariffTypeId);
        tarrifType.tariffTypeCode(source.TariffTypeCode === null ? undefined : source.TariffTypeCode);
        tarrifType.tarrifTypeName(source.TariffTypeName === null ? undefined : source.TariffTypeName);
        tarrifType.tariffTypeDescription(source.TariffTypeDescription === null ? undefined : source.TariffTypeDescription);
        tarrifType.companyId(source.CompanyId === null ? undefined : source.CompanyId);
        tarrifType.departmentId(source.DepartmentId === null ? undefined : source.DepartmentId);
        tarrifType.operationId(source.OperationId === null ? undefined : source.OperationId);
        tarrifType.measurementUnitId(source.MeasurementUnitId === null ? undefined : source.MeasurementUnitId);
        tarrifType.durationFrom(source.DurationFrom === null ? undefined : source.DurationFrom);
        tarrifType.durationTo(source.DurationTo === null ? undefined : source.DurationTo);
        tarrifType.gracePeriod(source.GracePeriod === null ? undefined : source.GracePeriod);
        tarrifType.effectiveDate(source.EffectiveDate !== null ? moment(source.EffectiveDate, ist.utcFormat).toDate() : undefined);
        tarrifType.pricingStrategyId(source.PricingStrategyId === null ? undefined : source.PricingStrategyId);
        tarrifType.revisionNumber(source.RevisionNumber === null ? undefined : source.RevisionNumber);
        return tarrifType;
    };

    return {
        TarrifType: TarrifType,
        TarrifTypeDetail: TarrifTypeDetail,
        TariffTypeServerMapper: TariffTypeServerMapper,
        TariffTypeClientMapper: TariffTypeClientMapper
    };
});