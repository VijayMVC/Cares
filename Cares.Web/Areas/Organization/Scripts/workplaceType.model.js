define(["ko", "underscore", "underscore-ko"], function(ko) {
    
    //organization detail 
    var workPlaceTypeDetail = function (specifiedId, specifiedCode, specifiedName, specifieddescription, specifiedworkplaceNature) {
        var            
            id = ko.observable(specifiedId),
            code = ko.observable(specifiedCode).extend({ required: true }),
            name = ko.observable(specifiedName).extend({ required: true }),
            workplaceNature = ko.observable(specifiedworkplaceNature).extend({ required: true }),
            description = ko.observable(specifieddescription),
            errors = ko.validation.group({
                name: name,
                code: code,
                description: description,
                workplaceNature: workplaceNature
            }),
            // Is Valid
            isValid = ko.computed(function() {
                return errors().length === 0;
            }),
            // True if the booking has been changed        
            dirtyFlag = new ko.dirtyFlag({
                id:id,
                name: name,
                code: code,
                description: description,
                workplaceNature:workplaceNature
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
                    WorkPlaceTypeId: id(),
                    WorkPlaceTypeCode: code(),
                    WorkPlaceTypeName: name(),
                    WorkPlaceTypeDescription: description(),
                    WorkPlaceNature: workplaceNature()
                };
            };
        return {
            id: id,
            code: code,
            name: name,
            description: description,
            workplaceNature:workplaceNature,
            errors: errors,
            isValid: isValid,
            dirtyFlag: dirtyFlag,
            hasChanges: hasChanges,
            convertToServerData: convertToServerData,
            reset: reset
            
        };
    };
    // server to client mapper
    var workPlaceTypeServertoClinetMapper = function (source) {
        return workPlaceTypeDetail.Create(source);
    };
    
    // FleetPool Factory
    workPlaceTypeDetail.Create = function (source) {
        return new workPlaceTypeDetail(source.WorkPlaceTypeId, source.WorkPlaceTypeCode, source.WorkPlaceTypeName, source.WorkPlaceTypeDescription, source.WorkPlaceNature);
    };

    //function to attain cancel button functionality 
    workPlaceTypeDetail.CreateFromClientModel = function (itemFromServer) {
        return new workPlaceTypeDetail(itemFromServer.id, itemFromServer.code, itemFromServer.name,
            itemFromServer.description, itemFromServer.workplaceNature);
    };
    return {
        workPlaceTypeDetail: workPlaceTypeDetail,
        workPlaceTypeServertoClinetMapper: workPlaceTypeServertoClinetMapper,
    };
});