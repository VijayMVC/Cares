define(["ko", "underscore", "underscore-ko"], function(ko) {
    
    // Marketing Channel Detail
    var marketingChannelGroupDetail = function (specifiedId, specifiedCode, specifiedName, specifieddescription) {
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
                    MarketingChannelId: id(),
                    MarketingChannelCode: code(),
                    MarketingChannelName: name(),
                    MarketingChannelDescription: description()
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
    var marketingChannelServertoClinetMapper = function (source) {
        return marketingChannelGroupDetail.Create(source);
    };
    
    //Document Group Factory
    marketingChannelGroupDetail.Create = function (source) {
        return new marketingChannelGroupDetail(source.MarketingChannelId, source.MarketingChannelCode, source.MarketingChannelName, source.MarketingChannelDescription);
    };

    //function to attain cancel button functionality 
    marketingChannelGroupDetail.CreateFromClientModel = function (itemFromServer) {
        return new marketingChannelGroupDetail(itemFromServer.id, itemFromServer.code, itemFromServer.name,
            itemFromServer.description);
    };
    return {
        MarketingChannelGroupDetail: marketingChannelGroupDetail,
        marketingChannelServertoClinetMapper: marketingChannelServertoClinetMapper,
    };
});