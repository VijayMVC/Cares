define(["ko", "underscore", "underscore-ko"], function(ko) {
    
    //Document Detail
    var documentDetail = function (specifiedId, specifiedCode, specifiedName, specifieddescription, specifieddocumentGroupId, specifieddocumentGroupName) {
        var            
            id = ko.observable(specifiedId),
            code = ko.observable(specifiedCode).extend({ required: true }),
            name = ko.observable(specifiedName).extend({ required: true }),
            description = ko.observable(specifieddescription),
            documentGroupId = ko.observable(specifieddocumentGroupId).extend({ required: true }),
            documentGroupName = ko.observable(specifieddocumentGroupName),
            errors = ko.validation.group({
                name: name,
                code: code,
                documentGroupId: documentGroupId
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
                    DocumentId: id(),
                    DocumentCode: code(),
                    DocumentName: name(),
                    DocumentDescription: description(),
                    DocumentGroupId: documentGroupId()
                };
            };
        return {
            id: id,
            code: code,
            name: name,
            description: description,
            documentGroupId: documentGroupId,
            documentGroupName: documentGroupName,
            errors: errors,
            isValid: isValid,
            dirtyFlag: dirtyFlag,
            hasChanges: hasChanges,
            convertToServerData: convertToServerData,
            reset: reset
            
        };
    };
    // server to client mapper
    var documentServertoClinetMapper = function (source) {
        return documentDetail.Create(source);
    };
    
    // Document Factory
    documentDetail.Create = function (source) {
        return new documentDetail(source.DocumentId, source.DocumentCode, source.DocumentName, source.DocumentDescription, source.DocumentGroupId, source.DocumentGroupName);
    };

    //function to attain cancel button functionality 
    documentDetail.CreateFromClientModel = function (itemFromServer) {
        return new documentDetail(itemFromServer.id, itemFromServer.code, itemFromServer.name,
            itemFromServer.description, itemFromServer.documentGroupId, itemFromServer.documentGroupName);
    };
    return {
        DocumentDetail: documentDetail,
        DocumentServertoClinetMapper: documentServertoClinetMapper,
    };
});