define(["ko", "underscore", "underscore-ko"], function(ko) {
    
    //Vehicle Model Detail
    var vehicleModelDetail = function (specifiedId, specifiedCode, specifiedName, specifieddescription) {
        var            
            id = ko.observable(specifiedId),
            code = ko.observable(specifiedCode).extend({ required: true }),
            name = ko.observable(specifiedName).extend({ required: true }),
            description = ko.observable(specifieddescription),          
            errors = ko.validation.group({
                name: name,
                code: code,
            }),
            // Is Valid
            isValid = ko.computed(function() {
                return errors().length === 0;
            }),
            dirtyFlag = new ko.dirtyFlag({
                name: name,
                code: code,
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
            convertToServerData = function () {
                return {
                    VehicleModelId: id(),
                    VehicleModelCode: code(),
                    VehicleModelName: name(),
                    VehicleModelDescription: description()
                };
            };
        return {
            id: id,
            code: code,
            name: name,
            description: description,
            errors: errors,
            isValid: isValid,
            dirtyFlag: dirtyFlag,
            hasChanges: hasChanges,
            convertToServerData: convertToServerData,
            reset: reset
            
        };
    };
    // server to client mapper
    var vehicleModelServertoClinetMapper = function (source) {
        return vehicleModelDetail.Create(source);
    };
    
    //Vehicle Model Factory
    vehicleModelDetail.Create = function (source) {
        return new vehicleModelDetail(source.VehicleModelId, source.VehicleModelCode, source.VehicleModelName, source.VehicleModelDescription);
    };

    //function to attain cancel button functionality 
    vehicleModelDetail.CreateFromClientModel = function (itemFromServer) {
        return new vehicleModelDetail(itemFromServer.id, itemFromServer.code, itemFromServer.name,
            itemFromServer.description);
    };
    return {
        VehicleModelDetail: vehicleModelDetail,
        vehicleModelServertoClinetMapper: vehicleModelServertoClinetMapper,
    };
});