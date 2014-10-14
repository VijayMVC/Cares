define(["ko", "underscore", "underscore-ko"], function(ko) {
    
    // Insurance Type Detail
    var insuranceTypeDetail = function (specifiedId, specifiedCode, specifiedName, specifieddescription) {
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
                    InsuranceTypeId: id(),
                    InsuranceTypeCode: code(),
                    InsuranceTypeName: name(),
                    InsuranceTypeDescription: description(),
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
    var insuranceTypeServertoClinetMapper = function (source) {
        return insuranceTypeDetail.Create(source);
    };
    
    // Insurance Type Factory
    insuranceTypeDetail.Create = function (source) {
        return new insuranceTypeDetail(source.InsuranceTypeId, source.InsuranceTypeCode, source.InsuranceTypeName, source.InsuranceTypeDescription);
    };

    //function to attain cancel button functionality 
    insuranceTypeDetail.CreateFromClientModel = function (itemFromServer) {
        return new insuranceTypeDetail(itemFromServer.id, itemFromServer.code, itemFromServer.name,
            itemFromServer.description);
    };
    return {
        InsuranceTypeDetail: insuranceTypeDetail,
        insuranceTypeServertoClinetMapper: insuranceTypeServertoClinetMapper,
    };
});