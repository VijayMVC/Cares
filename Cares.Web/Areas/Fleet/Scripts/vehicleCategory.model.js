define(["ko", "underscore", "underscore-ko"], function(ko) {
    
    // Vehicle Category Detail
    var vehicleCategoryDetail = function (specifiedId, specifiedCode, specifiedName, specifieddescription) {
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
                    VehicleCategoryId: id(),
                    VehicleCategoryCode: code(),
                    VehicleCategoryName: name(),
                    VehicleCategoryDescription: description(),
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
    var vehicleCategoryServertoClinetMapper = function (source) {
        return vehicleCategoryDetail.Create(source);
    };
    
    // Maintenance Type Factory
    vehicleCategoryDetail.Create = function (source) {
        return new vehicleCategoryDetail(source.VehicleCategoryId, source.VehicleCategoryCode, source.VehicleCategoryName, source.VehicleCategoryDescription);
    };

    //function to attain cancel button functionality 
    vehicleCategoryDetail.CreateFromClientModel = function (itemFromServer) {
        return new vehicleCategoryDetail(itemFromServer.id, itemFromServer.code, itemFromServer.name,
            itemFromServer.description);
    };
    return {
        VehicleCategoryDetail: vehicleCategoryDetail,
        vehicleCategoryServertoClinetMapper: vehicleCategoryServertoClinetMapper,
    };
});