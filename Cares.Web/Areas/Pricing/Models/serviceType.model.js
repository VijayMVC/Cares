define(["ko", "underscore", "underscore-ko"], function(ko) {
    
     //Service Type Detail
    var serviceTypeDetail = function (specifiedId, specifiedCode, specifiedName, specifieddescription) {
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
                    ServiceTypeId: id(),
                    ServiceTypeName: name(),
                    ServiceTypeCode: code(),
                    ServiceTypeDescription: description()
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
    var serviceTypeServertoClinetMapper = function (source) {
        return serviceTypeDetail.Create(source);
    };
    
    // Service Type Factory
    serviceTypeDetail.Create = function (source) {
        return new serviceTypeDetail(source.ServiceTypeId, source.ServiceTypeCode, source.ServiceTypeName, source.ServiceTypeDescription);
    };

    //function to attain cancel button functionality 
    serviceTypeDetail.CreateFromClientModel = function (itemFromServer) {
        return new serviceTypeDetail(itemFromServer.id, itemFromServer.code, itemFromServer.name,
            itemFromServer.description);
    };
    return {
        ServiceTypeDetail: serviceTypeDetail,
        serviceTypeServertoClinetMapper: serviceTypeServertoClinetMapper,
    };
});