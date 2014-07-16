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
            measurementUnit:self.MeasurementUnit,
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

    var TarrifTypeDetail = function (specifiedKey, specifieOperationId, specifiedMeasurementUnitId, specifiedDepartmentId, specifiedtariffTypeCode, specifiedTarrifTypeName,
        specifiedTariffTypeDescription, specifiedPricingStrategyId, specifiedDurationFrom, specifiedDurationTo, specifiedGracePeriod, specifiedEffectiveDate,
        specifiedRevisionNumber, specifiedRowVersion, specifiedChildTariffTypeId, specifiedRecCreatedDt, specifiedRecLastUpdatedDt, specifiedRecLastUpdatedBy,
        specifiedRecCreatedBy, specifiedIsActive, specifiedIsDeleted, specifiedIsPrivate, specifiedIsReadOnly) {
        // ReSharper restore InconsistentNaming
        var // Reference to this object
            // Unique key
            tarrifTypeId = ko.observable(specifiedKey || null),
            // Operation ID
            operationId = ko.observable(specifieOperationId).extend({ required: true }),
            // Measurement Unit ID
            measurementUnitId = ko.observable(specifiedMeasurementUnitId).extend({ required: true }),
            //Company ID
            companyId = ko.observable().extend({ required: true }),
             //Department ID
            departmentId = ko.observable(specifiedDepartmentId).extend({ required: true }),
            // Tariff Type Code 
            tariffTypeCode = ko.observable(specifiedtariffTypeCode).extend({ required: true }),
            // Tarrif Type Name
            tarrifTypeName = ko.observable(specifiedTarrifTypeName),
            //Tariff Type Description
            tariffTypeDescription = ko.observable(specifiedTariffTypeDescription),
            //Pricing Strategy ID
            pricingStrategyId = ko.observable(specifiedPricingStrategyId).extend({ required: true }),
            //Duration From
            durationFrom = ko.observable(specifiedDurationFrom).extend({ required: true }),
            //Duration To
            durationTo = ko.observable(specifiedDurationTo).extend({ required: true }),
            //Grace Period
            gracePeriod = ko.observable(specifiedGracePeriod).extend({ required: true }),
            //Effective Date
            effectiveDate = ko.observable(specifiedEffectiveDate).extend({ required: true }),
            //Revision Number
            revisionNumber = ko.observable(specifiedRevisionNumber),
            //Row Version
            rowVersion = ko.observable(specifiedRowVersion),
            //ChildTariffTypeID
            childTariffTypeId = ko.observable(specifiedChildTariffTypeId),
            //Rec Created Date
            recCreatedDt = ko.observable(specifiedRecCreatedDt),
            //RecLast Updated Date
            recLastUpdatedDt = ko.observable(specifiedRecLastUpdatedDt),
            //Rec Last Updated By
            recLastUpdatedBy = ko.observable(specifiedRecLastUpdatedBy),
            //Rec Created By
            recCreatedBy = ko.observable(specifiedRecCreatedBy),
            //IsActive
            isActive = ko.observable(specifiedIsActive),
            //IsDeleted
            isDeleted = ko.observable(specifiedIsDeleted),
            //IsPrivate
            isPrivate = ko.observable(specifiedIsPrivate),
            //IsReadOnly
            isReadOnly = ko.observable(specifiedIsReadOnly),
            // Is Busy
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
            // Convert to server
            convertToServerData = function () {
                return {
                   // Id: id(),
                    // Name: name(),
                    //  Price: price(),
                    // CategoryId: categoryId(),
                    // Description: description()
                };
            };

        self = {
            tarrifTypeId: tarrifTypeId,
            //userDomainKey: userDomainKey,
            operationId: operationId,
            measurementUnitId: measurementUnitId,
            departmentId:departmentId,
            companyId:companyId,
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
            isActive: isActive,
            isDeleted: isDeleted,
            isPrivate: isPrivate,
            isReadOnly: isReadOnly,

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
    return {
        TarrifType: TarrifType,
        TarrifTypeDetail: TarrifTypeDetail
    };
});