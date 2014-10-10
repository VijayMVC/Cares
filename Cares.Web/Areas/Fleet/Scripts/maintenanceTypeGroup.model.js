define(["ko", "underscore", "underscore-ko"], function(ko) {
    
    //Maintenance Type Group Detail
    var maintenanceTypeGroupGroupDetail = function (specifiedId, specifiedCode, specifiedName, specifieddescription) {
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
                    MaintenanceTypeGroupId: id(),
                    MaintenanceTypeGroupCode: code(),
                    MaintenanceTypeGroupName: name(),
                    MaintenanceTypeGroupDescription: description()
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
    var maintenanceTypeGroupServertoClinetMapper = function (source) {
        return maintenanceTypeGroupGroupDetail.Create(source);
    };
    
    //Maintenance Type Group Factory
    maintenanceTypeGroupGroupDetail.Create = function (source) {
        return new maintenanceTypeGroupGroupDetail(source.MaintenanceTypeGroupId, source.MaintenanceTypeGroupCode, source.MaintenanceTypeGroupName, source.MaintenanceTypeGroupDescription);
    };

    //function to attain cancel button functionality 
    maintenanceTypeGroupGroupDetail.CreateFromClientModel = function (itemFromServer) {
        return new maintenanceTypeGroupGroupDetail(itemFromServer.id, itemFromServer.code, itemFromServer.name,
            itemFromServer.description);
    };
    return {
        MaintenanceTypeGroupGroupDetail: maintenanceTypeGroupGroupDetail,
        maintenanceTypeGroupServertoClinetMapper: maintenanceTypeGroupServertoClinetMapper,
    };
});