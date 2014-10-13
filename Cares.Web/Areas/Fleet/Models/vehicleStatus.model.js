define(["ko", "underscore", "underscore-ko"], function(ko) {
    
    // Vehicle Status Detail
    var vehicleStatusDetail = function (specifiedId, specifiedCode, specifiedName, specifieddescription) {
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
                    VehicleStatusId: id(),
                    VehicleStatusCode: code(),
                    VehicleStatusName: name(),
                    VehicleStatusDescription: description()
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
    var vehicleStatusServertoClinetMapper = function (source) {
        return vehicleStatusDetail.Create(source);
    };
    
    //Vehicle Status Factory
    vehicleStatusDetail.Create = function (source) {
        return new vehicleStatusDetail(source.VehicleStatusId, source.VehicleStatusCode, source.VehicleStatusName, source.VehicleStatusDescription);
    };

    //function to attain cancel button functionality 
    vehicleStatusDetail.CreateFromClientModel = function (itemFromServer) {
        return new vehicleStatusDetail(itemFromServer.id, itemFromServer.code, itemFromServer.name,
            itemFromServer.description);
    };
    return {
        VehicleStatusDetail: vehicleStatusDetail,
        vehicleStatusServertoClinetMapper: vehicleStatusServertoClinetMapper,
    };
});