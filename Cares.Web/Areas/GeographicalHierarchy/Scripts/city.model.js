define(["ko", "underscore", "underscore-ko"], function(ko) {
    
    //City Detail
    var cityDetail = function (specifiedId, specifiedCode, specifiedName, specifieddescription, specifiedcountryId, specifiedcountryName, specifiedRegionId, specifiedRegionName,
       specifiedsubRegionId, specifiedsubRegionName) {
        var            
            id = ko.observable(specifiedId),
            code = ko.observable(specifiedCode).extend({ required: true }),
            name = ko.observable(specifiedName).extend({ required: true }),
            description = ko.observable(specifieddescription),
            countryId = ko.observable(specifiedcountryId).extend({ required: true }),
            countryName = ko.observable(specifiedcountryName),
            regionId = ko.observable(specifiedRegionId).extend({ required: true }),
            regionName = ko.observable(specifiedRegionName),
            subRegionId = ko.observable(specifiedsubRegionId).extend({ required: true }),
            subRegionName = ko.observable(specifiedsubRegionName),
            errors = ko.validation.group({
                name: name,
                code: code,
                countryId: countryId,
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
                    CityId:id(),
                    CityCode: code(),
                    CityName: name(),
                    CityDescription: description(),
                    RegionId: regionId(),
                    SubRegionId:subRegionId(),
                    CountryId: countryId()
                };
            };
        return {
            id: id,
            code: code,
            name: name,
            description: description,
            countryId: countryId,
            countryName: countryName,
            regionId: regionId,
            subRegionId: subRegionId,
            regionName: regionName,
            subRegionName:subRegionName,
            errors: errors,
            isValid: isValid,
            dirtyFlag: dirtyFlag,
            hasChanges: hasChanges,
            convertToServerData: convertToServerData,
            reset: reset
            
        };
    };
    // server to client mapper
    var cityServertoClinetMapper = function (source) {
        return cityDetail.Create(source);
    };
    
    // City Factory
    cityDetail.Create = function (source) {
       var obj= new cityDetail(source.CityId, source.CityCode, source.CityName, source.CityDescription, source.CountryId, source.CountryName,
            source.RegionId, source.RegionName, source.SubRegionId, source.SubRegionName);
        return obj;
    };

    //function to attain cancel button functionality 
    cityDetail.CreateFromClientModel = function (itemFromServer) {
        return new cityDetail(itemFromServer.id, itemFromServer.code, itemFromServer.name,
            itemFromServer.description, itemFromServer.countryId, itemFromServer.countryName, itemFromServer.regionId,
            itemFromServer.regionName, itemFromServer.subRegionId, itemFromServer.subRegionName);
    };
    return {
        cityDetail: cityDetail,
        cityServertoClinetMapper: cityServertoClinetMapper,
    };
});