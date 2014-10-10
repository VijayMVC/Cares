define(["ko", "underscore", "underscore-ko"], function(ko) {
    
    //Vehicle Make Detail
    var vehicleMakeDetail = function (specifiedId, specifiedCode, specifiedName, specifieddescription) {
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
                    VehicleMakeId: id(),
                    VehicleMakeCode: code(),
                    VehicleMakeName: name(),
                    VehicleMakeDescription: description()
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
    var vehicleMakeServertoClinetMapper = function (source) {
        return vehicleMakeDetail.Create(source);
    };
    
    //Vehicle Make Factory
    vehicleMakeDetail.Create = function (source) {
        return new vehicleMakeDetail(source.VehicleMakeId, source.VehicleMakeCode, source.VehicleMakeName, source.VehicleMakeDescription);
    };

    //function to attain cancel button functionality 
    vehicleMakeDetail.CreateFromClientModel = function (itemFromServer) {
        return new vehicleMakeDetail(itemFromServer.id, itemFromServer.code, itemFromServer.name,
            itemFromServer.description);
    };
    return {
        VehicleMakeDetail: vehicleMakeDetail,
        vehicleMakeServertoClinetMapper: vehicleMakeServertoClinetMapper,
    };
});