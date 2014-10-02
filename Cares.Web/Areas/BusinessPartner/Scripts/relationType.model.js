define(["ko", "underscore", "underscore-ko"], function(ko) {
    
    //Business Partner Relationship Type Detail
    var businessPartnerRelationshipTypeDetail = function (specifiedId, specifiedCode, specifiedName, specifieddescription) {
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
                    BusinessPartnerRelationshipTypeId: id(),
                    BusinessPartnerRelationshpTypeCode: code(),
                    BusinessPartnerRelationshipTypeName: name(),
                    BusinessPartnerRelationshipTypeDescription: description(),
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
    var businessPartnerRelationshipTypeServertoClinetMapper = function (source) {
        return businessPartnerRelationshipTypeDetail.Create(source);
    };
    
    //Business Partner Relationship Type  Factory
    businessPartnerRelationshipTypeDetail.Create = function (source) {
        return new businessPartnerRelationshipTypeDetail(source.BusinessPartnerRelationshipTypeId, source.BusinessPartnerRelationshpTypeCode,
            source.BusinessPartnerRelationshipTypeName, source.BusinessPartnerRelationshipTypeDescription);
    };

    //function to attain cancel button functionality 
    businessPartnerRelationshipTypeDetail.CreateFromClientModel = function (itemFromServer) {
        return new businessPartnerRelationshipTypeDetail(itemFromServer.id, itemFromServer.code, itemFromServer.name,
            itemFromServer.description);
    };
    return {
        BusinessPartnerRelationshipTypeDetail: businessPartnerRelationshipTypeDetail,
        businessPartnerRelationshipTypeServertoClinetMapper: businessPartnerRelationshipTypeServertoClinetMapper,
    };
});