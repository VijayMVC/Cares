define(["ko", "underscore", "underscore-ko"], function(ko) {
    
    //Rating type Detail
    var ratingTypeDetail = function (specifiedId, specifiedCode, specifiedName, specifieddescription) {
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
                    BpRatingTypeId: id(),
                    BpRatingTypeCode: code(),
                    BpRatingTypeName: name(),
                    BpRatingTypeDescription: description(),
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
    var ratingTypeServertoClinetMapper = function (source) {
        return ratingTypeDetail.Create(source);
    };
    
    // Rating type Factory
    ratingTypeDetail.Create = function (source) {
        return new ratingTypeDetail(source.BpRatingTypeId, source.BpRatingTypeCode, source.BpRatingTypeName, source.BpRatingTypeDescription);
    };

    //function to attain cancel button functionality 
    ratingTypeDetail.CreateFromClientModel = function (itemFromServer) {
        return new ratingTypeDetail(itemFromServer.id, itemFromServer.code, itemFromServer.name,
            itemFromServer.description);
    };
    return {
        RatingTypeDetail: ratingTypeDetail,
        ratingTypeServertoClinetMapper: ratingTypeServertoClinetMapper,
    };
});