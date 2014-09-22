define(["ko", "underscore", "underscore-ko"], function(ko) {
    
    //Designation Status Detail
    var designationsDetail = function (specifiedId, specifiedCode, specifiedName, specifieddescription) {
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
                    DesignationId: id(),
                    DesignationCode: code(),
                    DesignationName: name(),
                    DesignationDescription: description()
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
    var designationServertoClinetMapper = function (source) {
        return designationsDetail.Create(source);
    };
    
    // Designations Factory
    designationsDetail.Create = function (source) {
        return new designationsDetail(source.DesignationId, source.DesignationCode, source.DesignationName, source.DesignationDescription);
    };

    //function to attain cancel button functionality 
    designationsDetail.CreateFromClientModel = function (itemFromServer) {
        return new designationsDetail(itemFromServer.id, itemFromServer.code, itemFromServer.name,
            itemFromServer.description);
    };
    return {
        DesignationsDetail: designationsDetail,
        designationServertoClinetMapper: designationServertoClinetMapper,
    };
});