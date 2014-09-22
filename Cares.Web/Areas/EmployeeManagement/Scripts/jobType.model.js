define(["ko", "underscore", "underscore-ko"], function(ko) {
    
    //Job Type Detail
    var jobTypeDetail = function (specifiedId, specifiedCode, specifiedName, specifieddescription) {
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
                    JobTypeId: id(),
                    JobTypeCode: code(),
                    JobTypeName: name(),
                    JobTypeDescription: description()
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
    var jobTypeServertoClinetMapper = function (source) {
        return jobTypeDetail.Create(source);
    };
    
    // Job Type Factory
    jobTypeDetail.Create = function (source) {
        return  new jobTypeDetail(source.JobTypeId, source.JobTypeCode, source.JobTypeName, source.JobTypeDescription);
    };

    //function to attain cancel button functionality 
    jobTypeDetail.CreateFromClientModel = function (itemFromServer) {
        return new jobTypeDetail(itemFromServer.id, itemFromServer.code, itemFromServer.name,
            itemFromServer.description);
    };
    return {
        JobTypeDetail: jobTypeDetail,
        jobTypeServertoClinetMapper: jobTypeServertoClinetMapper,
    };
});