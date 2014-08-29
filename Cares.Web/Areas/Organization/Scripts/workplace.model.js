define(["ko", "underscore", "underscore-ko"], function(ko) {
    var
        // Workplace entity
        // ReSharper disable InconsistentNaming
        operation = function (specifiedId, specifiedCode, specifiedName, specifiedDescription, cmpId, spcCompanyName, spparentWorkPlaceId, spparentWorkPlaceName,
          specifiedworkplaceTypeId, specifiedworkplaceTypeName ,spworkLocationId,spworkLocationName) {
            var
                id = ko.observable(specifiedId),
                code = ko.observable(specifiedCode).extend({ required: true }),
                name = ko.observable(specifiedName).extend({ required: true }),
                description = ko.observable(specifiedDescription).extend({ required: true }),
                companyId = ko.observable(cmpId).extend({ required: true }),
                companyName = ko.observable(spcCompanyName).extend({ required: true }),

                parentWorkPlaceId = ko.observable(spparentWorkPlaceId).extend({ required: true }),
                parentWorkPlaceName = ko.observable(spparentWorkPlaceName).extend({ required: true }),

                workplaceTypeId = ko.observable(specifiedworkplaceTypeId).extend({ required: true }),
                workplaceTypeName = ko.observable(specifiedworkplaceTypeName).extend({ required: true }),

                workLocationId = ko.observable(spworkLocationId).extend({ required: true }),
                workLocationName = ko.observable(spworkLocationName).extend({ required: true }),

                errors = ko.validation.group({
                    name: name,
                    code: code,
                    description: description,
                }),
                // Is Valid
                isValid = ko.computed(function() {
                    return errors().length === 0;
                }),
                dirtyFlag = new ko.dirtyFlag({
                    name: name,
                    code: code,
                    description: description,
                }),
                // Has Changes
                hasChanges = ko.computed(function() {
                    return dirtyFlag.isDirty();
                }),
                // Reset
                reset = function() {
                    dirtyFlag.reset();
                },
                // Convert to server data
                convertToServerData = function() {
                    return {
                        WorkPlaceId :id(),
                        WorkPlaceCode:code(),
                        WorkPlaceName:name(),
                        WorkPlaceDescription:description(),
                        WorkPlaceTypeId:workplaceTypeId(),
                        CompanyId:companyId(),
                        WorkLocationId:workLocationId(),
                        ParentWorkPlaceId: parentWorkPlaceId()
                    };
                };
            return {
                id: id,
                name: name,
                code: code,
                description: description,
                companyId: companyId,
                companyName: companyName,

                workLocationId:workLocationId,
                workLocationName:workLocationName,

                workplaceTypeName:workplaceTypeName,
                workplaceTypeId:workplaceTypeId,

                parentWorkPlaceId: parentWorkPlaceId,
                parentWorkPlaceName:parentWorkPlaceName,

                hasChanges: hasChanges,
                reset: reset,
                convertToServerData: convertToServerData,
                isValid: isValid,
                errors: errors
            };
        };
    //server to client mapper
    var OperationServertoClientMapper = function (itemFromServer) {
        var pob = new operation(itemFromServer.WorkPlaceId, itemFromServer.WorkPlaceCode, itemFromServer.WorkPlaceName,
            itemFromServer.WorkPlaceDescription, itemFromServer.CompanyId, itemFromServer.CompanyName, itemFromServer.WorkPlaceId, itemFromServer.WorkPlaceName,
            itemFromServer.WorkPlaceTypeId, itemFromServer.WorkPlaceTypeName, itemFromServer.WorkLocationId, itemFromServer.WorkLocationName);
        return pob;
    };
    //function to attain cancel button functionality 
    operation.CreateFromClientModel = function (itemFromServer) {
        var pob = new operation(itemFromServer.id, itemFromServer.code, itemFromServer.name,
            itemFromServer.description, itemFromServer.companyId, itemFromServer.companyName, itemFromServer.parentWorkPlaceId, itemFromServer.parentWorkPlaceName,
            itemFromServer.workplaceTypeId, itemFromServer.workplaceTypeName, itemFromServer.workLocationId, itemFromServer.workLocationName);
        return pob;
    };
    return {
        operation: operation,
        OperationServertoClientMapper: OperationServertoClientMapper
    };
});