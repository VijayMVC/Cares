define(["ko", "underscore", "underscore-ko"], function (ko) {

    var
    // tariff Type entity
    // ReSharper disable InconsistentNaming
    tariffType = function (specifiedKey, specifieOperationId, specifiedMeasurementUnitId, specifiedtariffTypeCode, specifiedtariffTypeName,
        specifiedTariffTypeDescription, specifiedPricingStrategyId, specifiedDurationFrom, specifiedDurationTo, specifiedGracePeriod, specifiedEffectiveDate,
        specifiedRevisionNumber, specifiedRowVersion, specifiedChildTariffTypeId, specifiedRecCreatedDt, specifiedRecLastUpdatedDt, specifiedRecLastUpdatedBy,
         specifiedRecCreatedBy, specifiedIsActive, specifiedIsDeleted, specifiedIsPrivate, specifiedIsReadOnly) {
        // ReSharper restore InconsistentNaming
        var // Reference to this object
            self,
            // Unique key
            tariffTypeId = ko.observable(specifiedKey),
             // Operation ID
            operationId = ko.observable(specifieOperationId).extend({ required: true }),
            // Measurement Unit ID
            measurementUnitId = ko.observable(specifiedMeasurementUnitId).extend({ required: true }),
            //Company ID
            companyId = ko.observable(specifiedMeasurementUnitId).extend({ required: true }),
            // Tariff Type Code 
            tariffTypeCode = ko.observable(specifiedtariffTypeCode).extend({ required: true }),
            // tariff Type Name
            tariffTypeName = ko.observable(specifiedtariffTypeName),
            //Tariff Type Description
            tariffTypeDescription = ko.observable(specifiedTariffTypeDescription),
            //Pricing Strategy ID
            pricingStrategyId = ko.observable(specifiedPricingStrategyId),
            //Duration From
            durationFrom = ko.observable(specifiedDurationFrom),
            //Duration To
            durationTo = ko.observable(specifiedDurationTo),
            //Grace Period
            gracePeriod = ko.observable(specifiedGracePeriod),
            //Effective Date
            effectiveDate = ko.observable(specifiedEffectiveDate),
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
               // name: name,
               // price: price,
               // categoryId: categoryId
            }),
            // Is Valid
            isValid = ko.computed(function () {
                return errors().length === 0;
            }),
            // True if the booking has been changed
            // ReSharper disable InconsistentNaming
            dirtyFlag = new ko.dirtyFlag({
                // ReSharper restore InconsistentNaming
               // name: name,
               // price: price,
               // categoryId: categoryId,
               // description: description
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
                    Id: id(),
                   // Name: name(),
                  //  Price: price(),
                   // CategoryId: categoryId(),
                   // Description: description()
                };
            };

        self = {
            tariffTypeId: tariffTypeId,
            //userDomainKey: userDomainKey,
            operationId: operationId,
            measurementUnitId: measurementUnitId,
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
            isActiveisActive: isActiveisActive,
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
            convertToServerData: convertToServerData
        };
        return self;
    };

    //// tariff Type Factory
    //tariffType.Create = function (source) {
    //    return new Product(source.Id, source.Name, source.Price, source.Description, source.CategoryId);
    //};

    return {
        tariffType: tariffType
    };
});