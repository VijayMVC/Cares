define(["ko", "underscore", "underscore-ko"], function(ko) {
    
    //Sub Region Detail
    var subRegionDetail = function (specifiedId, specifiedCode, specifiedName, specifieddescription, specifiedregionId, specifiedregionName) {
        var            
            id = ko.observable(specifiedId),
            code = ko.observable(specifiedCode).extend({ required: true }),
            name = ko.observable(specifiedName).extend({ required: true }),
            description = ko.observable(specifieddescription),
            regionId = ko.observable(specifiedregionId).extend({ required: true }),
            regionName = ko.observable(specifiedregionName),
            errors = ko.validation.group({
                name: name,
                code: code,
                regionId: regionId
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
                    SubRegionId: id(),
                    SubRegionCode: code(),
                    SubRegionName: name(),
                    SubRegionDescription: description(),
                    RegionId: regionId()
                };
            };
        return {
            id: id,
            code: code,
            name: name,
            description: description,
            regionId: regionId,
            regionName: regionName,
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
        debugger;
        return new subRegionDetail(source.SubRegionId, source.SubRegionCode, source.SubRegionName, source.SubRegionDescription, source.RegionId, source.RegionName);
    };

    //function to attain cancel button functionality 
    subRegionDetail.CreateFromClientModel = function (itemFromServer) {
        return new subRegionDetail(itemFromServer.id, itemFromServer.code, itemFromServer.name,
            itemFromServer.description, itemFromServer.regionId, itemFromServer.regionName);
    };
    return {
        subRegionDetail: subRegionDetail,
        subRegionServertoClinetMapper: subRegionServertoClinetMapper,
    };
});