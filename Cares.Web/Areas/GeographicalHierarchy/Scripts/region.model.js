define(["ko", "underscore", "underscore-ko"], function(ko) {
    
    //Region Detail
    var regionDetail = function (specifiedId, specifiedCode, specifiedName, specifieddescription, specifiedcountryId, specifiedcountryName) {
        var            
            id = ko.observable(specifiedId),
            code = ko.observable(specifiedCode).extend({ required: true }),
            name = ko.observable(specifiedName).extend({ required: true }),
            description = ko.observable(specifieddescription),
            countryId = ko.observable(specifiedcountryId).extend({ required: true }),
            countryName = ko.observable(specifiedcountryName),
            errors = ko.validation.group({
                name: name,
                code: code,
                countryId: countryId
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
                    RegionId: id(),
                    RegionCode: code(),
                    RegionName: name(),
                    RegionDescription: description(),
                    CountryId:countryId()
                };
            };
        return {
            id: id,
            code: code,
            name: name,
            description: description,
            countryId: countryId,
            countryName:countryName,
            errors: errors,
            isValid: isValid,
            dirtyFlag: dirtyFlag,
            hasChanges: hasChanges,
            convertToServerData: convertToServerData,
            reset: reset
            
        };
    };
    // server to client mapper
    var regionServertoClinetMapper = function (source) {
        return regionDetail.Create(source);
    };
    
    // Region Factory
    regionDetail.Create = function (source) {
        return new regionDetail(source.RegionId, source.RegionCode, source.RegionName, source.RegionDescription, source.CountryId, source.CountryName);
    };

    //function to attain cancel button functionality 
    regionDetail.CreateFromClientModel = function (itemFromServer) {
        return new regionDetail(itemFromServer.id, itemFromServer.code, itemFromServer.name,
            itemFromServer.description, itemFromServer.countryId, itemFromServer.countryName);
    };
    return {
        regionDetail: regionDetail,
        regionServertoClinetMapper: regionServertoClinetMapper,
    };
});