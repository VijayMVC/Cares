define(["ko", "underscore", "underscore-ko"], function(ko) {
    
    //Business Partner Main Type Detail Detail
    var bPMainTypeDetail = function (specifiedId, specifiedCode, specifiedName, specifieddescription) {
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
                    BusinessPartnerMainTypeId: id(),
                    BusinessPartnerMainTypeCode: code(),
                    BusinessPartnerMainTypeName: name(),
                    BusinessPartnerMainTypeDescription: description()
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
    var bpMainTypeServertoClinetMapper = function (source) {
        return bPMainTypeDetail.Create(source);
    };
    
    //Business Partne Factory
    bPMainTypeDetail.Create = function (source) {
        return new bPMainTypeDetail(source.BusinessPartnerMainTypeId, source.BusinessPartnerMainTypeCode, source.BusinessPartnerMainTypeName, source.BusinessPartnerMainTypeDescription);
    };

    //function to attain cancel button functionality 
    bPMainTypeDetail.CreateFromClientModel = function (itemFromServer) {
        return new bPMainTypeDetail(itemFromServer.id, itemFromServer.code, itemFromServer.name,
            itemFromServer.description);
    };
    return {
        BpMainTypeDetail: bPMainTypeDetail,
        bpMainTypeServertoClinetMapper: bpMainTypeServertoClinetMapper,
    };
});