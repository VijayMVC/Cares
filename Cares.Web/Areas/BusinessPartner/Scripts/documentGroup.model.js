define(["ko", "underscore", "underscore-ko"], function(ko) {
    
    //Document Group Detail
    var documentGroupDetail = function (specifiedId, specifiedCode, specifiedName, specifieddescription) {
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
                    DocumentGroupId: id(),
                    DocumentGroupCode: code(),
                    DocumentGroupName: name(),
                    DocumentGroupDescription: description()
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
    var documentGroupServertoClinetMapper = function (source) {
        return documentGroupDetail.Create(source);
    };
    
    //Document Group Factory
    documentGroupDetail.Create = function (source) {
        return new documentGroupDetail(source.DocumentGroupId, source.DocumentGroupCode, source.DocumentGroupName, source.DocumentGroupDescription);
    };

    //function to attain cancel button functionality 
    documentGroupDetail.CreateFromClientModel = function (itemFromServer) {
        return new documentGroupDetail(itemFromServer.id, itemFromServer.code, itemFromServer.name,
            itemFromServer.description);
    };
    return {
        DocumentGroupDetail: documentGroupDetail,
        documentGroupServertoClinetMapper: documentGroupServertoClinetMapper,
    };
});