define(["ko", "underscore", "underscore-ko"], function(ko) {
    
    //Vehicle CheckList Detail
    var vehicleCheckListDetail = function (specifiedId, specifiedCode, specifiedName, specifieddescription, specifiedCityId) {
        var            
            id = ko.observable(specifiedId),
            code = ko.observable(specifiedCode).extend({ required: true }),
            name = ko.observable(specifiedName).extend({ required: true }),
            description = ko.observable(specifieddescription),
            isInterior = ko.observable(specifiedCityId).extend({ required: true }),
            errors = ko.validation.group({
                name: name,
                code: code,
                isInterior: isInterior
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
                    VehicleCheckListId: id(),
                    VehicleCheckListCode: code(),
                    VehicleCheckListName: name(),
                    VehicleCheckListDescription: description(),
                    IsInterior: isInterior()
                };
            };
        return {
            id: id,
            code: code,
            name: name,
            description: description,
            isInterior: isInterior,
            errors: errors,
            isValid: isValid,
            dirtyFlag: dirtyFlag,
            hasChanges: hasChanges,
            convertToServerData: convertToServerData,
            reset: reset
            
        };
    };
    // server to client mapper
    var vehicleCheckListServertoClinetMapper = function (source) {
        return vehicleCheckListDetail.Create(source);
    };
    
    // Vehicle Check List Factory
    vehicleCheckListDetail.Create = function (source) {
        return new vehicleCheckListDetail(source.VehicleCheckListId, source.VehicleCheckListCode, source.VehicleCheckListName, source.VehicleCheckListDescription, source.IsInterior);
    };
    //Create custimize Vehicle Check List objects
    var createCustomVehicleCheckList = function() {
        return new vehicleCheckListDetail(undefined, undefined, undefined, undefined, false);
    };
    //function to attain cancel button functionality 
    vehicleCheckListDetail.CreateFromClientModel = function (itemFromServer) {
        return new vehicleCheckListDetail(itemFromServer.id, itemFromServer.code, itemFromServer.name,
            itemFromServer.description, itemFromServer.isInterior);
    };
    return {
        vehicleCheckListDetail:vehicleCheckListDetail,
        vehicleCheckListServertoClinetMapper: vehicleCheckListServertoClinetMapper,
        CreateCustomVehicleCheckList: createCustomVehicleCheckList
    };
});