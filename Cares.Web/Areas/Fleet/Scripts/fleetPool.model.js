define(["ko", "underscore", "underscore-ko"], function(ko) {

    var
        // FleetPool entity
        // ReSharper disable InconsistentNaming
        FleetPool = function (specifiedId, specifiedCode, specifiedName, specifiedOperationName, specifiedRegionName, specifiedOperationId,
        specifiedCountryId, specifiedRegionId, specifiedvehicleasigned, specifieddescription) {
            // ReSharper restore InconsistentNaming
            var
                id = ko.observable(specifiedId),
                code = ko.observable(specifiedCode).extend({ required: true }),
                name = ko.observable(specifiedName),
                operationName = ko.observable(specifiedOperationName),
                operationId = ko.observable(specifiedOperationId).extend({ required: true }),
                countryName = ko.observable(specifiedOperationName),
                countryId = ko.observable(specifiedCountryId).extend({ required: true }),
                regionId = ko.observable(specifiedRegionId).extend({ required: true }),
                regionName = ko.observable(specifiedRegionName),
                vehiclesAssigned = ko.observable(specifiedvehicleasigned).extend({ required: true }),
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
                        FleetPoolId: id(),
                        ApproximateVehiclesAsgnd:vehiclesAssigned(),
                        Description: description(),
                        OperationId:operationId(),
                        RegionId:regionId()
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
            countryId = ko.observable(specifiedCountryId).extend({ required: true }),
            vehiclesAssigned = ko.observable(specifiedvehicleasigned).extend({ required: true }),
            // Errors
            errors = ko.validation.group({
                name: name,
                code: code,
                regionId: regionId,
                countryId: countryId,
                vehiclesAssigned: vehiclesAssigned
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
    // server to client mapper
    var fleetPoolServertoClinetMapper = function(source) {
        return FleetPoolDetail.Create(source);
    };
    //client to server mapper
    var fleePoolClienttoServerMapper = function (client) {
        var server = FleetPool(client.id(), client.code(), client.name(), undefined, undefined, client.operationId(),
            client.countryId(), client.regionId(), client.vehiclesAssigned(), client.description());
        return server.convertToServerData();
    };
    // FleetPool Factory
    FleetPoolDetail.Create = function (source) {
        return new FleetPoolDetail(source.FleetPoolId, source.FleetPoolCode, source.FleetPoolName, source.Description, source.OperationName, 
            source.OperationId, source.RegionName, source.RegionId, source.CountryName, source.CountryId, source.ApproximateVehiclesAsgnd);
    };
    return {
        FleetPool: FleetPool,
        FleetPoolDetail: FleetPoolDetail,
        fleetPoolServertoClinetMapper: fleetPoolServertoClinetMapper,
        fleePoolClienttoServerMapper: fleePoolClienttoServerMapper
    };
});