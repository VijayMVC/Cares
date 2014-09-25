define(["ko", "underscore", "underscore-ko"], function(ko) {
    
     //Service Item Detail
    var serviceItemDetail = function (specifiedId, specifiedCode, specifiedName, specifieddescription, specifiedServiceTypeId, specifiedServerTypeName) {
        var            
            id = ko.observable(specifiedId),
            code = ko.observable(specifiedCode).extend({ required: true }),
            name = ko.observable(specifiedName).extend({ required: true }),
            description = ko.observable(specifieddescription),
            serviceTypeId = ko.observable(specifiedServiceTypeId).extend({ required: true }),
            serviceTypeName = ko.observable(specifiedServerTypeName),
            errors = ko.validation.group({
                name: name,
                code: code,
                serviceTypeId: serviceTypeId
            }),
            // Is Valid
            isValid = ko.computed(function() {
                return errors().length === 0;
            }),
            dirtyFlag = new ko.dirtyFlag({
                name: name,
                code: code,
                serviceTypeId: serviceTypeId
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
                    ServiceTypeId: serviceTypeId(),
                    ServiceItemId:id(),
                    ServiceItemName: name(),
                    ServiceItemCode: code(),
                    ServiceItemDescription: description(),

                };
            };
        return {
            id: id,
            code: code,
            name: name,
            description: description,
            serviceTypeId: serviceTypeId,
            serviceTypeName:serviceTypeName,
            errors: errors,
            isValid: isValid,
            dirtyFlag: dirtyFlag,
            hasChanges: hasChanges,
            convertToServerData: convertToServerData,
            reset: reset
            
        };
    };
    // server to client mapper
    var serviceItemServertoClinetMapper = function (source) {
        return serviceItemDetail.Create(source);
    };
    
    // Service Item Factory
    serviceItemDetail.Create = function (source) {
        return new serviceItemDetail(source.ServiceItemId, source.ServiceItemCode, source.ServiceItemName, source.ServiceItemDescription, source.ServiceTypeId, source.ServiceTypeName);
    };

    //function to attain cancel button functionality 
    serviceItemDetail.CreateFromClientModel = function (itemFromServer) {
        return new serviceItemDetail(itemFromServer.id, itemFromServer.code, itemFromServer.name,
            itemFromServer.description, itemFromServer.serviceTypeId, itemFromServer.serviceTypeName);
    };
    return {
        ServiceItemDetail: serviceItemDetail,
        serviceItemServertoClinetMapper: serviceItemServertoClinetMapper,
    };
});