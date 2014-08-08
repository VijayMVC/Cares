/*
    Module with the model for the Hire Group
*/
define(["ko", "underscore", "underscore-ko"], function (ko) {
    var
        //Hire Group entity
        // ReSharper disable InconsistentNaming
     HireGroup = function () {
         // ReSharper restore InconsistentNaming
         var // Reference to this object
             self,
             // Unique key
             hireGroupId = ko.observable(),
             // Hire Group Code 
             hireGroupCode = ko.observable(),
             //Hire Group Name
             hireGroupName = ko.observable(),
             // Parent Hire Group
             parentHireGroup = ko.observable(),
             // Descriptione
             description = ko.observable(),
             //Company 
             company = ko.observable(),
             //Is Parent
             isParent = ko.observable();

         self = {
             hireGroupId: hireGroupId,
             hireGroupCode: hireGroupCode,
             hireGroupName: hireGroupName,
             parentHireGroup: parentHireGroup,
             description: description,
             company: company,
             isParent: isParent
         };
         return self;
     };
// ReSharper disable once InconsistentNaming
    var HireGroupClientMapper = function (source) {
        var hireGroup = new HireGroup();
        hireGroup.hireGroupId(source.HireGroupId === null ? undefined : source.HireGroupId);
        hireGroup.hireGroupCode(source.HireGroupCode === null ? undefined : source.HireGroupCode);
        hireGroup.hireGroupName(source.HireGroupName === null ? undefined : source.HireGroupName);
        hireGroup.parentHireGroup(source.ParentHireGroupName === null ? undefined : source.ParentHireGroupName);
        hireGroup.description(source.Description === null ? undefined : source.Description);
        hireGroup.company(source.CompanyName === null ? undefined : source.CompanyName);
        hireGroup.isParent(source.IsParent === null ? undefined : source.IsParent);
        return hireGroup;
    };
    return {
        HireGroup: HireGroup,
        HireGroupClientMapper:HireGroupClientMapper
    };
});