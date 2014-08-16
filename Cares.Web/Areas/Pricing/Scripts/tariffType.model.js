define(["ko", "underscore", "underscore-ko"], function (ko) {
    var
    // tariff Type entity - Using Knockout Mapping
    // ReSharper disable InconsistentNaming
    TariffType = function (data) {
        // ReSharper restore InconsistentNaming
        var // Reference to this object
            self = {},
            mapping = {
                // customize the creation of the name property so that it provides validation
                EffectiveDate: {
                    create: function (options) {
                        return ko.observable(moment(options.data).format(ist.datePattern));
                    }
                }
            };

        // Map data to self
        ko.mapping.fromJS(data, mapping, self);

        return {
            tariffTypeId: self.TariffTypeId,
            measurementUnit: self.MeasurementUnit,
            tariffTypeCode: self.TariffTypeCode,
            tariffTypeName: self.TariffTypeName,
            pricingScheme: self.PricingScheme,
            company: self.Company,
            operation: self.Operation,
            gracePeriod: self.GracePeriod,
            effectiveDate: self.EffectiveDate,
            durationFrom: self.DurationFrom,
            revisionNumber: self.RevisionNumber,
            durationTo: self.DurationTo,
            
        };
    };
// ReSharper disable once InconsistentNaming
    var TariffTypeDetail = function () {
        // ReSharper restore InconsistentNaming
        var // Reference to this object
            // Unique key
            tariffTypeId = ko.observable(),
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
            // tariff Type Name
            tariffTypeName = ko.observable(),
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
            // Is busy
            isBusy = ko.observable(false),
            //String valued formatted date
            formattedEffectiveDate = ko.computed({
                read: function(){
                    return moment(effectiveDate()).format(ist.datePattern);
                }
            }),
            //string valued formatted created date
            formattedCreatedDate = ko.computed({
                read: function () {
                    return moment(recCreatedDt()).format(ist.datePattern);
                }
            }),
            //string valued formatted last updated date
            formattedModifiedDate = ko.computed({
                read: function () {
                    return moment(recLastUpdatedDt()).format(ist.datePattern);
                }
            }),

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
                tariffTypeName: tariffTypeName,
                tariffTypeDescription:tariffTypeDescription,
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
            tariffTypeId: tariffTypeId,
            //userDomainKey: userDomainKey,
            operationId: operationId,
            measurementUnitId: measurementUnitId,
            departmentId: departmentId,
            companyId: companyId,
            tariffTypeCode: tariffTypeCode,
            tariffTypeName: tariffTypeName,
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
            formattedEffectiveDate: formattedEffectiveDate,
            formattedModifiedDate: formattedModifiedDate,
            formattedCreatedDate: formattedCreatedDate
        };
        return self;
    };
    //Client To Server Mapper
    var TariffTypeServerMapper = function (tariffTypeObj) {
        var result = {};
        result.TariffTypeId = tariffTypeObj.tariffTypeId() === undefined || tariffTypeObj.tariffTypeId() === null ? 0 : tariffTypeObj.tariffTypeId();
        result.TariffTypeCode = tariffTypeObj.tariffTypeCode() === undefined || tariffTypeObj.tariffTypeCode() === null ? 0 : tariffTypeObj.tariffTypeCode();
        result.TariffTypeName = tariffTypeObj.tariffTypeName();
        result.TariffTypeDescription = tariffTypeObj.tariffTypeDescription();
        result.CompanyId = tariffTypeObj.companyId();
        result.DepartmentId = tariffTypeObj.departmentId();
        result.OperationId = tariffTypeObj.operationId();
        result.MeasurementUnitId = tariffTypeObj.measurementUnitId();
        result.DurationFrom = tariffTypeObj.durationFrom();
        result.DurationTo = tariffTypeObj.durationTo();
        result.GracePeriod = tariffTypeObj.gracePeriod();
        result.EffectiveDate = tariffTypeObj.effectiveDate() === undefined || tariffTypeObj.effectiveDate() === null ? undefined : moment(tariffTypeObj.effectiveDate()).format(ist.utcFormat);
        result.PricingStrategyId = tariffTypeObj.pricingStrategyId();
        result.RevisionNumber = tariffTypeObj.revisionNumber();
        return result;
    };
    //Server To Client Mapper
    var TariffTypeClientMapper = function (source) {
        var tariffType = new TariffTypeDetail();
        tariffType.tariffTypeId(source.TariffTypeId === null ? undefined : source.TariffTypeId);
        tariffType.tariffTypeCode(source.TariffTypeCode === null ? undefined : source.TariffTypeCode);
        tariffType.tariffTypeName(source.TariffTypeName === null ? undefined : source.TariffTypeName);
        tariffType.tariffTypeDescription(source.TariffTypeDescription === null ? undefined : source.TariffTypeDescription);
        tariffType.companyId(source.CompanyId === null ? undefined : source.CompanyId);
        tariffType.departmentId(source.DepartmentId === null ? undefined : source.DepartmentId);
        tariffType.operationId(source.OperationId === null ? undefined : source.OperationId);
        tariffType.measurementUnitId(source.MeasurementUnitId === null ? undefined : source.MeasurementUnitId);
        tariffType.durationFrom(source.DurationFrom === null ? undefined : source.DurationFrom);
        tariffType.durationTo(source.DurationTo === null ? undefined : source.DurationTo);
        tariffType.gracePeriod(source.GracePeriod === null ? undefined : source.GracePeriod);
        tariffType.effectiveDate(source.EffectiveDate !== null ? moment(source.EffectiveDate, ist.utcFormat).toDate() : undefined);
        tariffType.pricingStrategyId(source.PricingStrategyId === null ? undefined : source.PricingStrategyId);
        tariffType.revisionNumber(source.RevisionNumber === null ? undefined : source.RevisionNumber);
        tariffType.recCreatedBy(source.CreatedBy === null ? undefined : source.CreatedBy);
        tariffType.recCreatedDt(source.ModifiedDate === null ? undefined : source.CreatedDate);
        tariffType.recLastUpdatedBy(source.ModifiedBy === null ? undefined : source.ModifiedBy);
        tariffType.recLastUpdatedDt(source.ModifiedDate === null ? undefined : source.ModifiedDate);
        return tariffType;
    };
  

    return {
        TariffType: TariffType,
        TariffTypeDetail: TariffTypeDetail,
        TariffTypeServerMapper: TariffTypeServerMapper,
        TariffTypeClientMapper: TariffTypeClientMapper,
       
    };
});