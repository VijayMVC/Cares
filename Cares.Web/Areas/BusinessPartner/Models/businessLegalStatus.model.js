define(["ko", "underscore", "underscore-ko"], function(ko) {
    
    //Business Legal Status Detail
    var businessLegalStatusDetail = function (specifiedId, specifiedCode, specifiedName, specifieddescription) {
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
                    BusinessLegalStatusId: id(),
                    BusinessLegalStatusCode: code(),
                    BusinessLegalStatusName: name(),
                    BusinessLegalStatusDescription: description(),
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
    var businessLegalStatusServertoClinetMapper = function (source) {
        return businessLegalStatusDetail.Create(source);
    };
    
    // Business Legal Status Factory
    businessLegalStatusDetail.Create = function (source) {
        return new businessLegalStatusDetail(source.BusinessLegalStatusId, source.BusinessLegalStatusCode, source.BusinessLegalStatusName, source.BusinessLegalStatusDescription);
    };

    //function to attain cancel button functionality 
    businessLegalStatusDetail.CreateFromClientModel = function (itemFromServer) {
        return new businessLegalStatusDetail(itemFromServer.id, itemFromServer.code, itemFromServer.name,
            itemFromServer.description);
    };
    return {
        BusinessLegalStatusDetail: businessLegalStatusDetail,
        businessLegalStatusServertoClinetMapper: businessLegalStatusServertoClinetMapper,
    };
});