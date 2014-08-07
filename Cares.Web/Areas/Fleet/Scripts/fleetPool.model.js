define(["ko", "underscore", "underscore-ko"], function (ko) {

    var
    // FleetPool entity
    // ReSharper disable InconsistentNaming
    FleetPool = function (specifiedId, specifiedCode, specifiedName, specifiedOperationName, specifiedRegionName, specifiedOperationId, specifiedCountryId, specifiedRegionId, specifiedvehicleasigned,specifieddescription) {
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
                operationId: operationId,
                operationName:operationName,
                regionId: regionId,
                regionName:regionName,
                countryId: countryId,
                countryName: countryName,
                vehiclesAssigned: vehiclesAssigned,
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
                    FleetPoolCode: code(),
                    FleetPoolName: name(),
                    FleetPoolId: id()
                };
            };
       

        return {
            id:id,
            code: code,
            name: name,
            operationId: operationId,
            operationName:operationName,
            regionId: regionId,
            regionName:countryName,
            countryId: countryId,
            countryName:countryName,
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

    var FleetPoolDetail = function () {
        var
           // Unique key id
           id = ko.observable(undefined),
           //Code
           code = ko.observable(undefined),
           // Name
           name = ko.observable(undefined).extend({ required: true }),
           operationName = ko.observable(undefined),
            operationId = ko.observable(undefined),
            countryName = ko.observable(undefined),
            countryId = ko.observable(undefined),
            regionId = ko.observable(undefined),
            regionName = ko.observable(undefined),
          vehiclesAssigned = ko.observable(undefined),
            description = ko.observable(undefined),
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
               id: id,
               name: name,
               code: code,
               operationName: operationName,
               operationId: operationId,
               countryName: countryName,
               countryId: countryId,
               regionId: regionId,
               regionName: regionName,
               description: description,
               vehiclesAssigned: vehiclesAssigned
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

    var fleetPoolServertoClinetMapper = function (source) {

        var fleetPool = new FleetPoolDetail();
        fleetPool.id(source.FleetPoolId);
        fleetPool.name(source.FleetPoolName);
        fleetPool.code(source.FleetPoolCode);
        fleetPool.regionName(source.RegionName);
        fleetPool.regionId(source.RegionId);
        fleetPool.countryName(source.CountryName);
        fleetPool.operationName(source.OperationName);
        fleetPool.countryId(source.CountryId);
        fleetPool.operationId(source.OperationId);
        fleetPool.description(source.Description);
        fleetPool.vehiclesAssigned(source.ApproximateVehiclesAsgnd);

        return fleetPool;
    };

    // FleetPool Factory
    FleetPool.Create = function (source) {
        return new FleetPool(source.FleetPoolId,source.FleetPoolCode, source.FleetPoolName, source.operationName ,source.regionName,source.countryId,source.countryName,source.operationId);
    };

    return {
        FleetPool: FleetPool,
        FleetPoolDetail: FleetPoolDetail,
        fleetPoolServertoClinetMapper: fleetPoolServertoClinetMapper

    };
});