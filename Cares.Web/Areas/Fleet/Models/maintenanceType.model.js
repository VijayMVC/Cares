define(["ko", "underscore", "underscore-ko"], function(ko) {
    
    // Maintenance Type Detail
    var maintenanceTypeDetail = function (specifiedId, specifiedCode, specifiedName, specifieddescription, specifiedMaintenanceTypeGroupId, specifiedMaintenanceTypeGroupName) {
        var            
            id = ko.observable(specifiedId),
            code = ko.observable(specifiedCode).extend({ required: true }),
            name = ko.observable(specifiedName).extend({ required: true }),
            description = ko.observable(specifieddescription),
            maintenanceTypeGroupId = ko.observable(specifiedMaintenanceTypeGroupId).extend({ required: true }),
            maintenanceTypeGroupName = ko.observable(specifiedMaintenanceTypeGroupName),
            errors = ko.validation.group({
                name: name,
                code: code,
                maintenanceTypeGroupId: maintenanceTypeGroupId
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
                    MaintenanceTypeId: id(),
                    MaintenanceTypeCode: code(),
                    MaintenanceTypeName: name(),
                    MaintenanceTypeDescription: description(),
                    MaintenanceTypeGroupId: maintenanceTypeGroupId()
                };
            };
        return {
            id: id,
            code: code,
            name: name,
            description: description,
            maintenanceTypeGroupId: maintenanceTypeGroupId,
            maintenanceTypeGroupName: maintenanceTypeGroupName,
            errors: errors,
            isValid: isValid,
            dirtyFlag: dirtyFlag,
            hasChanges: hasChanges,
            convertToServerData: convertToServerData,
            reset: reset
            
        };
    };
    // server to client mapper
    var maintenanceTypeServertoClinetMapper = function (source) {
        return maintenanceTypeDetail.Create(source);
    };
    
    // Maintenance Type Factory
    maintenanceTypeDetail.Create = function (source) {
        return new maintenanceTypeDetail(source.MaintenanceTypeId, source.MaintenanceTypeCode, source.MaintenanceTypeName, source.MaintenanceTypeDescription,
            source.MaintenanceTypeGroupId, source.MaintenanceTypeGroupName);
    };

    //function to attain cancel button functionality 
    maintenanceTypeDetail.CreateFromClientModel = function (itemFromServer) {
        return new maintenanceTypeDetail(itemFromServer.id, itemFromServer.code, itemFromServer.name,
            itemFromServer.description, itemFromServer.maintenanceTypeGroupId, itemFromServer.maintenanceTypeGroupName);
    };
    return {
        MaintenanceTypeDetail: maintenanceTypeDetail,
        maintenanceTypeServertoClinetMapper: maintenanceTypeServertoClinetMapper,
    };
});