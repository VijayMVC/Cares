define(["ko", "underscore", "underscore-ko"], function(ko) {
    
     //Nrt Type Detail
    var nRtTypeDetail = function (specifiedId, specifiedCode, specifiedName, specifieddescription, specifiedvehicleStatus, specifiedvehicleStatusName) {
        var            
            id = ko.observable(specifiedId),
            code = ko.observable(specifiedCode).extend({ required: true }),
            name = ko.observable(specifiedName).extend({ required: true }),
            description = ko.observable(specifieddescription),
            vehicleStatusId = ko.observable(specifiedvehicleStatus).extend({ required: true }),
            vehicleStatusName = ko.observable(specifiedvehicleStatusName),
            errors = ko.validation.group({
                name: name,
                code: code,
                vehicleStatusId: vehicleStatusId
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
                    NrtTypeId: id(),
                    NrtTypeCode: code(),
                    NrtTypeName: name(),
                    Description: description(),
                    VehicleStatusId: vehicleStatusId()
                };
            };
        return {
            id: id,
            code: code,
            name: name,
            description: description,
            vehicleStatusId: vehicleStatusId,
            vehicleStatusName: vehicleStatusName,
            errors: errors,
            isValid: isValid,
            dirtyFlag: dirtyFlag,
            hasChanges: hasChanges,
            convertToServerData: convertToServerData,
            reset: reset
            
        };
    };
    // server to client mapper
    var nRtTypeServertoClinetMapper = function (source) {
        return nRtTypeDetail.Create(source);
    };
    
    // Nrt Type  Factory
    nRtTypeDetail.Create = function (source) {
        return new nRtTypeDetail(source.NrtTypeId, source.NrtTypeCode, source.NrtTypeName, source.Description, source.VehicleStatusId, source.VehicleStatusName);
    };

    //function to attain cancel button functionality 
    nRtTypeDetail.CreateFromClientModel = function (itemFromServer) {
        return new nRtTypeDetail(itemFromServer.id, itemFromServer.code, itemFromServer.name,
            itemFromServer.description, itemFromServer.vehicleStatusId, itemFromServer.vehicleStatusName);
    };
    return {
        NrtTypeDetail: nRtTypeDetail,
        nRtTypeServertoClinetMapper: nRtTypeServertoClinetMapper,
    };
});