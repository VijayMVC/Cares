define(["ko", "underscore", "underscore-ko"], function(ko) {
    
    //Sub Region Detail
    var subRegionDetail = function (specifiedId, specifiedCode, specifiedName, specifieddescription, specifiedregionId, specifiedregionName) {
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
                    DiscountTypeId: id(),
                    DiscountTypeName: code(),
                    DiscountTypeCode: name(),
                    DiscountTypeDescrition: description()
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
    var subRegionServertoClinetMapper = function (source) {
        return subRegionDetail.Create(source);
    };
    
    // Sub Region Factory
    subRegionDetail.Create = function (source) {
        return new subRegionDetail(source.DiscountTypeId, source.DiscountTypeName, source.DiscountTypeCode, source.DiscountTypeDescrition);
    };

    //function to attain cancel button functionality 
    subRegionDetail.CreateFromClientModel = function (itemFromServer) {
        return new subRegionDetail(itemFromServer.id, itemFromServer.code, itemFromServer.name,
            itemFromServer.description);
    };
    return {
        subRegionDetail: subRegionDetail,
        subRegionServertoClinetMapper: subRegionServertoClinetMapper,
    };
});