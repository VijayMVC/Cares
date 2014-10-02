define(["ko", "underscore", "underscore-ko"], function (ko) {

    //Business Partner Sub Type Detail
    var businessPartnerSubTypeDetail = function (specifiedId, specifiedCode, specifiedName, specifieddescription, specifiedbusinessPartnerMainTypeGroupId, specifiedbusinessPartnerMainTypeName) {
        var
            id = ko.observable(specifiedId),
            code = ko.observable(specifiedCode).extend({ required: true }),
            name = ko.observable(specifiedName).extend({ required: true }),
            description = ko.observable(specifieddescription),
            businessPartnerMainTypeId = ko.observable(specifiedbusinessPartnerMainTypeGroupId).extend({ required: true }),
            businessPartnerMainTypeName = ko.observable(specifiedbusinessPartnerMainTypeName),
            errors = ko.validation.group({
                name: name,
                code: code,
                businessPartnerMainTypeId: businessPartnerMainTypeId
            }),
            // Is Valid
            isValid = ko.computed(function () {
                return errors().length === 0;
            }),
            dirtyFlag = new ko.dirtyFlag({
                name: name,
                code: code,
            }),
            // Has Changes
            hasChanges = ko.computed(function () {
                return dirtyFlag.isDirty();
            }),
            // Reset
            reset = function () {
                dirtyFlag.reset();
            },
            // Convert to server
            convertToServerData = function () {
                return {
                    BusinessPartnerSubTypeId: id(),
                    BusinessPartnerSubTypeCode: code(),
                    BusinessPartnerSubTypeName: name(),
                    BusinessPartnerSubTypeDescription: description(),
                    BusinessPartnerMainTypeId: businessPartnerMainTypeId()
                };
            };
        return {
            id: id,
            code: code,
            name: name,
            description: description,
            businessPartnerMainTypeId: businessPartnerMainTypeId,
            businessPartnerMainTypeName: businessPartnerMainTypeName,
            errors: errors,
            isValid: isValid,
            dirtyFlag: dirtyFlag,
            hasChanges: hasChanges,
            convertToServerData: convertToServerData,
            reset: reset

        };
    };
    // server to client mapper
    var businessPartnerSubTypeServertoClinetMapper = function (source) {
        return businessPartnerSubTypeDetail.Create(source);
    };

    // Business Partner Sub Type Factory
    businessPartnerSubTypeDetail.Create = function (source) {
        return new businessPartnerSubTypeDetail(source.BusinessPartnerSubTypeId, source.BusinessPartnerSubTypeCode, source.BusinessPartnerSubTypeName,
            source.BusinessPartnerSubTypeDescription, source.BusinessPartnerMainTypeId, source.BusinessPartnerMainTypeName);
    };

    //function to attain cancel button functionality 
    businessPartnerSubTypeDetail.CreateFromClientModel = function (itemFromServer) {
        return new businessPartnerSubTypeDetail(itemFromServer.id, itemFromServer.code, itemFromServer.name,
            itemFromServer.description, itemFromServer.businessPartnerMainTypeId, itemFromServer.businessPartnerMainTypeName);
    };
    return {
        BusinessPartnerSubTypeDetail: businessPartnerSubTypeDetail,
        businessPartnerSubTypeServertoClinetMapper: businessPartnerSubTypeServertoClinetMapper,
    };
});