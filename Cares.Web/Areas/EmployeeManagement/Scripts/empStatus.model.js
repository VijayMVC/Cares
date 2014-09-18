define(["ko", "underscore", "underscore-ko"], function(ko) {
    
    //Employee Status Detail
     // ReSharper disable once InconsistentNaming
    var EmployeeStatusDetail = function (specifiedId, specifiedCode, specifiedName, specifieddescription, specifiedEmpStatusFlag) {
        var            
            id = ko.observable(specifiedId),
            code = ko.observable(specifiedCode).extend({ required: true }),
            name = ko.observable(specifiedName).extend({ required: true }),
            description = ko.observable(specifieddescription),
            empStatusFlag = ko.observable(specifiedEmpStatusFlag).extend({ required: true }), 
            empStatusFlagString = ko.computed(function () {
                if (specifiedEmpStatusFlag == true) return 'YES';
                else return 'NO';
            }),
            errors = ko.validation.group({
                name: name,
                code: code,
                empStatusFlag: empStatusFlag
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
                    EmpStatusId: id(),
                    EmpStatusCode: code(),
                    EmpStatusName: name(),
                    EmpStatusDescription: description(),
                    EmpStatusFlag: empStatusFlag()
                };
            };
        return {
            id: id,
            code: code,
            name: name,
            description: description,
            empStatusFlag: empStatusFlag,
            empStatusFlagString:empStatusFlagString,
            errors: errors,
            isValid: isValid,
            dirtyFlag: dirtyFlag,
            hasChanges: hasChanges,
            convertToServerData: convertToServerData,
            reset: reset
            
        };
    };
    // server to client mapper
    var empStatusServertoClinetMapper = function (source) {
        return new EmployeeStatusDetail(source.EmpStatusId, source.EmpStatusCode, source.EmpStatusName, source.EmpStatusDescription, source.EmpStatusFlag);
    };
    
    // EmployeeStatus Factory
    var createEmployeeStatusDetail = function (serviceStatus) {
        return new EmployeeStatusDetail(undefined, undefined, undefined, undefined, serviceStatus);
    };

    //function to attain cancel button functionality 
    EmployeeStatusDetail.CreateFromClientModel = function (itemFromServer) {
        return new EmployeeStatusDetail(itemFromServer.id, itemFromServer.code, itemFromServer.name,
            itemFromServer.description, itemFromServer.empStatusFlag);
    };
    return {
        EmployeeStatusDetail: EmployeeStatusDetail,
        CreateEmployeeStatusDetail: createEmployeeStatusDetail,
        empStatusServertoClinetMapper: empStatusServertoClinetMapper,
    };
});