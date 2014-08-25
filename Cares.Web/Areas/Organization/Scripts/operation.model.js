define(["ko", "underscore", "underscore-ko"], function(ko) {

    var
        // Operation entity
        // ReSharper disable InconsistentNaming
        operation = function (specifiedId, specifiedCode, specifiedName, specifiedDescription, spcCompanyName, specifiedDepartment, specifiedDepartmentType, specifiedDepartmentId) {
            var
                id = ko.observable(specifiedId),
                code = ko.observable(specifiedCode).extend({ required: true }),
                name = ko.observable(specifiedName).extend({ required: true }),
                description = ko.observable(specifiedDescription).extend({ required: true }),
                companyName = ko.observable(spcCompanyName).extend({ required: true }),
                departmentName = ko.observable(specifiedDepartment).extend({ required: true }),
                DepartmentId=  ko.observable(specifiedDepartmentId).extend({ required: true }),
                departmentType = ko.observable(specifiedDepartmentType).extend({ required: true }),
                errors = ko.validation.group({
                    name: name,
                    code: code,
                    description: description,
                    DepartmentId: DepartmentId
                }),
                // Is Valid
                isValid = ko.computed(function() {
                    return errors().length === 0;
                }),
                dirtyFlag = new ko.dirtyFlag({
                    name: name,
                    code: code,
                    description: description,
                    DepartmentId: DepartmentId
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
                        OperationId: id(),
                        OperationCode: code(),
                        OperationName: name(),
                        OperationDescription: description(),
                        DepartmentId: DepartmentId(),
                    };
                };
            return {
                id: id,
                name: name,
                code: code,
                description: description,
                departmentName: departmentName,
                companyName: companyName,
                DepartmentId: DepartmentId,
                departmentType: departmentType,
                hasChanges: hasChanges,
                reset: reset,
                convertToServerData: convertToServerData,
                isValid: isValid,
                errors: errors
            };
        };
    var OperationServertoClientMapper = function (itemFromServer) {
        return new operation(itemFromServer.OperationId, itemFromServer.OperationCode, itemFromServer.OperationName,
            itemFromServer.OperationDescription, itemFromServer.CompanyName, itemFromServer.DepartmentName, itemFromServer.DepartmentType, itemFromServer.DepartmentId);
    };
    return {
        operation: operation,
        OperationServertoClientMapper: OperationServertoClientMapper
    };
});