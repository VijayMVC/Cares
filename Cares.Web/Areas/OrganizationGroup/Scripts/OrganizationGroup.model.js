define(["ko", "underscore", "underscore-ko"], function(ko) {

    var
        // OrganizationGroup entity
        // ReSharper disable InconsistentNaming
        OrganizationGroup = function (specifiedId, specifiedCode, specifiedName, specifiedDescription) {
            var
                id = ko.observable(specifiedId),
                code = ko.observable(specifiedCode).extend({ required: true }),
                name = ko.observable(specifiedName).extend({ required: true }),
                description = ko.observable(specifiedDescription).extend({ required: true }),
                errors = ko.validation.group({
                    id: id,
                    name: name,
                    code: code,
                    description: description
                }),
                // Is Valid
                isValid = ko.computed(function() {
                    return errors().length === 0;
                }),
                dirtyFlag = new ko.dirtyFlag({
                    // ReSharper restore InconsistentNaming
                    name: name,
                    code: code,
                    description: description
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
                convertToServerData = function() {
                    return {
                        
                    };
                };
            return {
                id: id,
                code: code,
                name: name,
                description: description,
                hasChanges: hasChanges,
                reset: reset,
                convertToServerData: convertToServerData,
                isValid: isValid
            };
        };
    var organizationGroupDetail = function (specifiedId, specifiedCode, specifiedName, specifieddescription) {
        var            
            id = ko.observable(specifiedId),
            code = ko.observable(specifiedCode).extend({ required: true }),
            name = ko.observable(specifiedName).extend({ required: true }),
            description = ko.observable(specifieddescription).extend({ required: true }),
            errors = ko.validation.group({
                name: name,
                code: code,
                description: description
            }),
            // Is Valid
            isValid = ko.computed(function() {
                return errors().length === 0;
            }),
            // True if the booking has been changed        
            dirtyFlag = new ko.DirtyFlag({
                name: name,
                code: code,
                description: description
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
            convertToServerData = function() {
                return {
                    
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
            reset: reset,
            convertToServerData: convertToServerData
        };
    };
    // server to client mapper
    var organizationGroupServertoClinetMapper = function (source) {
    };
    //client to server mapper
    var organizationGroupClienttoServerMapper = function (client) {
    };
    // FleetPool Factory
    organizationGroupDetail.Create = function (source) {
        return new organizationGroupDetail(source.FleetPoolId, source.FleetPoolCode, source.FleetPoolName, source.Description);
    };
    return {
        OrganizationGroup: OrganizationGroup,
        organizationGroupDetail: organizationGroupDetail,
        organizationGroupServertoClinetMapper: organizationGroupServertoClinetMapper,
        organizationGroupClienttoServerMapper: organizationGroupClienttoServerMapper
    };
});