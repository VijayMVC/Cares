define(["ko", "underscore", "underscore-ko"], function(ko) {
    
    //Design. Grade Detail
// ReSharper disable once InconsistentNaming
    var DesignGrade = function (specifiedId, specifiedCode, specifiedName, specifieddescription) {
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
                    DesigGradeId: id(),
                    DesigGradeCode: code(),
                    DesigGradeName: name(),
                    DesigGradeDescription: description(),
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
    var servertoClinetMapper = function (source) {
        return DesignGrade.Create(source);
    };
    
    // Design Grade Factory
    DesignGrade.Create = function (source) {
        return new DesignGrade(source.DesigGradeId, source.DesigGradeCode, source.DesigGradeName, source.DesigGradeDescription);
    };

    //function to attain cancel button functionality 
    DesignGrade.CreateFromClientModel = function (itemFromServer) {
        return new DesignGrade(itemFromServer.id, itemFromServer.code, itemFromServer.name,
            itemFromServer.description);
    };
    return {
        DesignGrade: DesignGrade,
        servertoClinetMapper: servertoClinetMapper,
    };
});