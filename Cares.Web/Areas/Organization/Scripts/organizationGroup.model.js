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
                convertToServerData = function () {
                    return {
                        OrgGroupId: id(),
                        OrgGroupCode: code(),
                        OrgGroupName: name(),
                        OrgGroupDescription: description()
                    };
                };
            return {
                OrgGroupId: id,
                OrgGroupCode: code,
                OrgGroupName: name,
                OrgGroupDescription: description,
                hasChanges: hasChanges,
                reset: reset,
                convertToServerData: convertToServerData,
                isValid: isValid
            };
        };
    //organization detail 
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
            dirtyFlag = new ko.dirtyFlag({
                id:id,
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
            convertToServerData: convertToServerData,
            reset: reset
            
        };
    };
    // server to client mapper
    var organizationGroupServertoClinetMapper = function (source) {
        return organizationGroupDetail.Create(source);
    };
    //client to server mapper
    var organizationGroupClienttoServerMapper = function (client) {
        return new OrganizationGroup(client.id(), client.code(), client.name(), client.description()).convertToServerData();
    };
    // FleetPool Factory
    organizationGroupDetail.Create = function (source) {
        return new organizationGroupDetail(source.OrgGroupId, source.OrgGroupCode, source.OrgGroupName, source.OrgGroupDescription);
    };
    return {
        OrganizationGroup: OrganizationGroup,
        organizationGroupDetail: organizationGroupDetail,
        organizationGroupServertoClinetMapper: organizationGroupServertoClinetMapper,
        organizationGroupClienttoServerMapper: organizationGroupClienttoServerMapper
    };
});