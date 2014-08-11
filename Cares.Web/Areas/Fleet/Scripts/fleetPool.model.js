define(["ko", "underscore", "underscore-ko"], function(ko) {

    var
        // FleetPool entity
        // ReSharper disable InconsistentNaming
        FleetPool = function(specifiedId, specifiedCode, specifiedName, specifiedOperationName, specifiedRegionName, specifiedOperationId, specifiedCountryId, specifiedRegionId, specifiedvehicleasigned, specifieddescription) {
            // ReSharper restore InconsistentNaming
            var
                // Unique key id
                id = ko.observable(specifiedId),
                //Code
                code = ko.observable(specifiedCode),
                // Name
                name = ko.observable(specifiedName).extend({ required: true }),
                //Operation Name
                operationName = ko.observable(specifiedOperationName),
                operationId = ko.observable(specifiedOperationId),
                countryName = ko.observable(specifiedOperationName),
                countryId = ko.observable(specifiedCountryId),
                regionId = ko.observable(specifiedRegionId),
                regionName = ko.observable(specifiedRegionName),
                vehiclesAssigned = ko.observable(specifiedvehicleasigned),
                description = ko.observable(specifieddescription),
                errors = ko.validation.group({
                    name: name
                }),
                // Is Valid
                isValid = ko.computed(function() {
                    return errors().length === 0;
                }),
                // True if the booking has been changed
// ReSharper disable InconsistentNaming
                dirtyFlag = new ko.dirtyFlag({
                    // ReSharper restore InconsistentNaming
                    id: id,
                    name: name,
                    code: code,
                    operationId: operationId,
                    operationName: operationName,
                    regionId: regionId,
                    regionName: regionName,
                    countryId: countryId,
                    countryName: countryName,
                    vehiclesAssigned: vehiclesAssigned,
                    description: description
                }),
                // Has Changes
                hasChanges = ko.computed(function() {
                    return dirtyFlag.isDirty();
                }),
                // Reset
                reset = function() {
                    dirtyFlag.reset();
                },
                // Convert to server
                convertToServerData = function() {
                    return {
                        FleetPoolCode: code(),
                        FleetPoolName: name(),
                        FleetPoolId: id()
                    };
                };


            return {
                id: id,
                code: code,
                name: name,
                operationId: operationId,
                operationName: operationName,
                regionId: regionId,
                regionName: countryName,
                countryId: countryId,
                countryName: countryName,
                errors: errors,
                isValid: isValid,
                dirtyFlag: dirtyFlag,
                hasChanges: hasChanges,
                reset: reset,
                convertToServerData: convertToServerData,
                description: description,
                vehiclesAssigned: vehiclesAssigned

            };
        };

    var FleetPoolDetail = function (specifiedId, specifiedCode, specifiedName, specifieddescription, specifiedOperationName, specifiedOperationId, 
        specifiedRegionName, specifiedRegionId, specifiedCountryName, specifiedCountryId, specifiedvehicleasigned) {
        var            
            id = ko.observable(specifiedId),
            code = ko.observable(specifiedCode).extend({ required: true }),
            name = ko.observable(specifiedName).extend({ required: true }),
            operationName = ko.observable(specifiedOperationName),
            description = ko.observable(specifieddescription),
            operationId = ko.observable(specifiedOperationId),
            regionName = ko.observable(specifiedRegionName),
            regionId = ko.observable(specifiedRegionId).extend({ required: true }),
            countryName = ko.observable(specifiedCountryName),
            countryId = ko.observable(specifiedCountryId),
            vehiclesAssigned = ko.observable(specifiedvehicleasigned),            
            // Errors
            errors = ko.validation.group({
                name: name,
                code: code,
                regionId: regionId
            }),
            // Is Valid
            isValid = ko.computed(function() {
                return errors().length === 0;
            }),
            // True if the booking has been changed        
            dirtyFlag = new ko.dirtyFlag({
                name: name,
                code: code,
                operationId: operationId,
                countryId: countryId,
                regionId: regionId,
                description: description,
                vehiclesAssigned: vehiclesAssigned
            }),
            // Has Changes
            hasChanges = ko.computed(function() {
                return dirtyFlag.isDirty();
            }),
            // Reset
            reset = function() {
                dirtyFlag.reset();
            },
            // Convert to server
            convertToServerData = function() {
                return {
                    FleetPoolCode: code(),
                    FleetPoolName: name(),
                    FleetPoolId: id()
                };
            };


        return {
            id: id,
            code: code,
            name: name,
            operationName: operationName,
            operationId: operationId,
            countryName: countryName,
            countryId: countryId,
            regionId: regionId,
            regionName: regionName,
            description: description,
            vehiclesAssigned: vehiclesAssigned,
            errors: errors,
            isValid: isValid,
            dirtyFlag: dirtyFlag,
            hasChanges: hasChanges,
            reset: reset,
            convertToServerData: convertToServerData

        };
    };

    var fleetPoolServertoClinetMapper = function(source) {
        return FleetPoolDetail.Create(source);
    };

    // FleetPool Factory
    FleetPoolDetail.Create = function (source) {
        return new FleetPoolDetail(source.FleetPoolId, source.FleetPoolCode, source.FleetPoolName, source.Description, source.OperationName, 
            source.OperationId, source.RegionName, source.RegionId, source.CountryName, source.CountryId, source.ApproximateVehiclesAsgnd);
    };

    return {
        FleetPool: FleetPool,
        FleetPoolDetail: FleetPoolDetail,
        fleetPoolServertoClinetMapper: fleetPoolServertoClinetMapper

    };
});