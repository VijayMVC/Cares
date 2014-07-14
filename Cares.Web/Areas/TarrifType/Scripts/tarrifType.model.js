define(["ko", "underscore", "underscore-ko"], function (ko) {

    var
    // Tarrif Type entity
    // ReSharper disable InconsistentNaming
    TarrifType = function (specifiedUserDomainKey, specifiedKey, specifieOperationId, specifiedMeasurementUnitId, specifiedtariffTypeCode, specifiedTarrifTypeName,
        specifiedTariffTypeDescription, specifiedPricingStrategyId, specifiedDurationFrom, specifiedDurationTo, specifiedGracePeriod, specifiedEffectiveDate,
        specifiedRevisionNumber, specifiedRowVersion, specifiedChildTariffTypeId, specifiedRecCreatedDt, specifiedRecLastUpdatedDt, specifiedRecLastUpdatedBy,
         specifiedRecCreatedBy) {
        // ReSharper restore InconsistentNaming
        var // Reference to this object
            self,
            // Unique key
            tarrifTypeId = ko.observable(specifiedKey),
            //User Domain Key
            userDomainKey = ko.observable(specifiedUserDomainKey),
            // Operation ID
            operationId = ko.observable(specifieOperationId).extend({ required: true }),
            // Measurement Unit ID
            measurementUnitId = ko.observable(specifiedMeasurementUnitId).extend({ required: true }),
            // Tariff Type Code 
            tariffTypeCode = ko.observable(specifiedtariffTypeCode).extend({ required: true }),
            // Tarrif Type Name
            tarrifTypeName = ko.observable(specifiedTarrifTypeName),
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
            isActive = ko.observable(),
            //IsDeleted
            isDeleted = ko.observable(),
             //IsPrivate
            isPrivate = ko.observable(),
             //IsReadOnly
            isReadOnly = ko.observable(),
            // Is Busy
            isBusy = ko.observable(false),
           

            // Category Name
            categoryName = ko.computed(function () {
                if (!categoryId()) {
                    return "";
                }
                var categoryResult = categories.find(function (category) {
                    return category.Id === categoryId();
                });

                return categoryResult ? categoryResult.Name : "";
            }),
            // Assign Categories
            assignCategories = function (categoryList) {
                categories.removeAll();
                ko.utils.arrayPushAll(categories(), categoryList);
                categories.valueHasMutated();
            },
            // Errors
            errors = ko.validation.group({
                name: name,
                price: price,
                categoryId: categoryId
            }),
            // Is Valid
            isValid = ko.computed(function () {
                return errors().length === 0;
            }),
            // True if the booking has been changed
            // ReSharper disable InconsistentNaming
            dirtyFlag = new ko.dirtyFlag({
                // ReSharper restore InconsistentNaming
                name: name,
                price: price,
                categoryId: categoryId,
                description: description
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
                    Name: name(),
                    Price: price(),
                    CategoryId: categoryId(),
                    Description: description()
                };
            };

        self = {
            tarrifTypeId: tarrifTypeId,
            userDomainKey: userDomainKey,
            operationId: operationId,
            measurementUnitId: measurementUnitId,
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
            assignCategories: assignCategories,
            categoryName: categoryName,
            convertToServerData: convertToServerData
        };
        return self;
    };

    //// Tarrif Type Factory
    //TarrifType.Create = function (source) {
    //    return new Product(source.Id, source.Name, source.Price, source.Description, source.CategoryId);
    //};

    return {
        TarrifType: TarrifType
    };
});