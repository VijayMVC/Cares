define(["ko", "underscore", "underscore-ko"], function(ko) {
    
    //Area Detail
// ReSharper disable once InconsistentNaming
    var AreaDetail = function (specifiedId, specifiedCode, specifiedName, specifieddescription, specifiedCityId, specifiedCityName) {
        var            
            id = ko.observable(specifiedId),
            code = ko.observable(specifiedCode).extend({ required: true }),
            name = ko.observable(specifiedName).extend({ required: true }),
            description = ko.observable(specifieddescription),
            cityId = ko.observable(specifiedCityId).extend({ required: true }),
            cityName = ko.observable(specifiedCityName),
            errors = ko.validation.group({
                name: name,
                code: code,
                cityId: cityId
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
                    AreaId: id(),
                    AreaCode: code(),
                    AreaName: name(),
                    AreaDescription: description(),
                    CityId:cityId()
                };
            };
        return {
            id: id,
            code: code,
            name: name,
            description: description,
            cityId: cityId,
            cityName: cityName,
            errors: errors,
            isValid: isValid,
            dirtyFlag: dirtyFlag,
            hasChanges: hasChanges,
            convertToServerData: convertToServerData,
            reset: reset
            
        };
    };
    // server to client mapper
    var areaServertoClinetMapper = function (source) {
        return AreaDetail.Create(source);
    };
    
    // Area Factory
    AreaDetail.Create = function (source) {
        return new AreaDetail(source.AreaId, source.AreaCode, source.AreaName, source.AreaDescription, source.CityId, source.CityName);
    };

    //function to attain cancel button functionality 
    AreaDetail.CreateFromClientModel = function (itemFromServer) {
        return new AreaDetail(itemFromServer.id, itemFromServer.code, itemFromServer.name,
            itemFromServer.description, itemFromServer.cityId, itemFromServer.cityName);
    };
    return {
        AreaDetail: AreaDetail,
        areaServertoClinetMapper: areaServertoClinetMapper,
    };
});