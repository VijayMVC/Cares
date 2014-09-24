define(["ko", "underscore", "underscore-ko"], function(ko) {
    
    //Discount Sub Type Detail
    var discountSubTypeDetail = function (specifiedId, specifiedCode, specifiedName, specifieddescription, specifieDiscountTypeId, specifiedDiscountTypeName) {
        var            
            id = ko.observable(specifiedId),
            code = ko.observable(specifiedCode).extend({ required: true }),
            name = ko.observable(specifiedName).extend({ required: true }),
            description = ko.observable(specifieddescription),
            discountTypeId = ko.observable(specifieDiscountTypeId).extend({ required: true }),
            discountTypeName = ko.observable(specifiedDiscountTypeName),
            errors = ko.validation.group({
                name: name,
                code: code,
                discountTypeId: discountTypeId
            }),
            // Is Valid
            isValid = ko.computed(function() {
                return errors().length === 0;
            }),
            dirtyFlag = new ko.dirtyFlag({
                name: name,
                code: code,
                discountTypeId: discountTypeId

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
                    DiscountSubTypeId: id(),
                    DiscountSubTypeCode: code(),
                    DiscountSubTypeName: name(),
                    DiscountSubTypeDescription: description(),
                    DiscountTypeId: discountTypeId()
                };
            };
        return {
            id: id,
            code: code,
            name: name,
            description: description,
            discountTypeId: discountTypeId,
            discountTypeName: discountTypeName,
            errors: errors,
            isValid: isValid,
            dirtyFlag: dirtyFlag,
            hasChanges: hasChanges,
            convertToServerData: convertToServerData,
            reset: reset
            
        };
    };
    // server to client mapper
    var discountSubTypeServertoClinetMapper = function (source) {
        return discountSubTypeDetail.Create(source);
    };
    
    // Discount Sub Type Factory
    discountSubTypeDetail.Create = function (source) {
        return new discountSubTypeDetail(source.DiscountSubTypeId, source.DiscountSubTypeCode, source.DiscountSubTypeName, source.DiscountSubTypeDescription, source.DiscountTypeId, source.DiscountTypeName);
    };

    //function to attain cancel button functionality 
    discountSubTypeDetail.CreateFromClientModel = function (itemFromServer) {
        return new discountSubTypeDetail(itemFromServer.id, itemFromServer.code, itemFromServer.name,
            itemFromServer.description, itemFromServer.discountTypeId, itemFromServer.discountTypeName);
    };
    return {
        DiscountSubTypeDetail: discountSubTypeDetail,
        DiscountSubTypeServertoClinetMapper: discountSubTypeServertoClinetMapper,
    };
});