define(["ko", "underscore", "underscore-ko"], function(ko) {

    var
        // department entity
        // ReSharper disable InconsistentNaming
        department = function (specifiedId, specifiedCode, specifiedName, specifiedDescription, spcCompanyName, spcCompanyId, specifiedDepartmentType) {
            var
                id = ko.observable(specifiedId),
                code = ko.observable(specifiedCode).extend({ required: true }),
                name = ko.observable(specifiedName).extend({ required: true }),
                description = ko.observable(specifiedDescription).extend({ required: true }),
                companyName = ko.observable(spcCompanyName).extend({ required: true }),
                companyId = ko.observable(spcCompanyId).extend({ required: true }),
                departmentType = ko.observable(specifiedDepartmentType).extend({ required: true }),

                errors = ko.validation.group({
                    name: name,
                    code: code,
                    description: description,
                    companyId: companyId,
                    departmentType: departmentType,
                }),
                // Is Valid
                isValid = ko.computed(function() {
                    return errors().length === 0;
                }),
                dirtyFlag = new ko.dirtyFlag({
                    name: name,
                    code: code,
                    description: description,
                    companyId: companyId,
                    departmentType: departmentType,
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
                        DepartmentId: id(),
                        DepartmentCode: code(),
                        DepartmentName: name(),
                        DepartmentDescription: description(),
                        CompanyId: companyId(),
                        DepartmentType: departmentType()
                    };
                };
            return {
                id:id,
                name: name,
                code: code,
                description: description,
                companyId: companyId,
                departmentType: departmentType,
                companyName: companyName,
                hasChanges: hasChanges,
                reset: reset,
                convertToServerData: convertToServerData,
                isValid: isValid,
                errors: errors
            };
        };

    var DepartmentServertoClientMapper = function (itemFromServer) {
        return new department(itemFromServer.DepartmentId, itemFromServer.DepartmentCode, itemFromServer.DepartmentName,
            itemFromServer.DepartmentDescription, itemFromServer.CompanyName, itemFromServer.CompanyId, itemFromServer.DepartmentType);
    };

    department.CreateFromClientModel = function (item) {
        return new department(item.id, item.code, item.name,
            item.description, item.companyName, item.companyId, item.departmentType);
    };

    return {
        department: department,
        DepartmentServertoClientMapper: DepartmentServertoClientMapper
    };
});