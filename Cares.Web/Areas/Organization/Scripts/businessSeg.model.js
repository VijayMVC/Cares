define(["ko", "underscore", "underscore-ko"], function(ko) {
    
    //workPlaceType Detail
    var businessSegmentDetail = function (specifiedId, specifiedCode, specifiedName, specifieddescription) {
        var            
            id = ko.observable(specifiedId),
            code = ko.observable(specifiedCode).extend({ required: true }),
            name = ko.observable(specifiedName).extend({ required: true }),
            description = ko.observable(specifieddescription),
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
                debugger;
                return {
                    BusinessSegmentId: id(),
                    BusinessSegmentCode: code(),
                    BusinessSegmentName: name(),
                    BusinessSegmentDescription: description(),
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
    var businessSegmentServertoClinetMapper = function (source) {
        return businessSegmentDetail.Create(source);
    };
    
    // FleetPool Factory
    businessSegmentDetail.Create = function (source) {
        return new businessSegmentDetail(source.BusinessSegmentId, source.BusinessSegmentCode, source.BusinessSegmentName, source.BusinessSegmentDescription);
    };

    //function to attain cancel button functionality 
    businessSegmentDetail.CreateFromClientModel = function (itemFromServer) {
        return new businessSegmentDetail(itemFromServer.id, itemFromServer.code, itemFromServer.name,
            itemFromServer.description);
    };
    return {
        businessSegmentDetail: businessSegmentDetail,
        businessSegmentServertoClinetMapper: businessSegmentServertoClinetMapper,
    };
});