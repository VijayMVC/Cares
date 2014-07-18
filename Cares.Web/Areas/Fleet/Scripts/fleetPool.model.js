define(["ko", "underscore", "underscore-ko"], function (ko) {

    var
    // FleetPool entity
    // ReSharper disable InconsistentNaming
    FleetPool = function (specifiedId,specifiedCode, specifiedName, specifiedOperationName, specifiedRegionName, specifiedCountry) {
        // ReSharper restore InconsistentNaming
        var 
            // Unique key id
            id = ko.observable(specifiedId),
            //Code
            code = ko.observable(specifiedCode),
            // Name
            name = ko.observable(specifiedName).extend({ required: true }),
            //Operation Name
            operation = ko.observable(specifiedOperationName),
            //Region Name
            region = ko.observable(specifiedRegionName),
            //Country
            country=ko.observable(specifiedCountry),
            // Errors
            errors = ko.validation.group({
                name: name
            }),
            // Is Valid
            isValid = ko.computed(function () {
                return errors().length === 0;
            }),
            // True if the booking has been changed
// ReSharper disable InconsistentNaming
            dirtyFlag = new ko.dirtyFlag({
                // ReSharper restore InconsistentNaming
                id:id,
                name: name,
                code: code,
                operation: operation,
                region: region,
                country:country
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
                    FleetPoolCode: code(),
                    FleetPoolName: name(),
                    FleetPoolId: id()
                };
            };

        return {
            id:id,
            code: code,
            name: name,
            operation: operation,
            region: region,
            country:country,
            errors: errors,
            isValid: isValid,
            dirtyFlag: dirtyFlag,
            hasChanges: hasChanges,
            reset: reset,
            convertToServerData: convertToServerData
        };
    };

    // FleetPool Factory
    FleetPool.Create = function (source) {
        return new FleetPool(source.FleetPoolId,source.FleetPoolCode, source.FleetPoolName, source.Operation.OperationName, source.Region.RegionName, source.Region.Country);
    };

    return {
        FleetPool: FleetPool
    };
});