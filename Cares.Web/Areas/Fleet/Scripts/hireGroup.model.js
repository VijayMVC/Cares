/*
    Module with the model for the Hire Group
*/
define(["ko", "underscore", "underscore-ko"], function (ko) {
    var
     //Hire Group entity
    // ReSharper disable once InconsistentNaming
    HireGroup = function () {
        // ReSharper restore InconsistentNaming
        var // Reference to this object
            self,
            // Unique key
            hireGroupId = ko.observable(),
            // Hire Group Code 
            hireGroupCode = ko.observable().extend({ required: true }),
            // Hire Group Name
            hireGroupName = ko.observable(),
            // Company Id
            companyId = ko.observable().extend({ required: true }),
            //Company 
             companyName = ko.observable(),
            //Is Parent
            isParent = ko.observable(),
            //Virtual Is Parent,Check for edit
            virtualIsParent = ko.observable(),
            //Parent Hire Group Id
            parentHireGroupId = ko.observable(),
           // Parent Hire Group
           parentHireGroupName = ko.observable(),
            //Description
            description = ko.observable(),
            //Hire Group Vehicle Detail list
            hireGroupVehicleDetailList = ko.observableArray([]),
            //Upgraded hire group list
            upgragedHireGroupList = ko.observableArray([]),
            //Vehile detail Object
            vehicleDetail = ko.observable(),
            // Errors
            errors = ko.validation.group({
                hireGroupCode: hireGroupCode,
                companyId: companyId,
            }),
            // Is Valid
            isValid = ko.computed(function () {
                return errors().length === 0;
            }),
            // True if the booking has been changed
            // ReSharper disable InconsistentNaming
            dirtyFlag = new ko.dirtyFlag({

            }),
            // Has Changes
            hasChanges = ko.computed(function () {
                return dirtyFlag.isDirty();
            }),
            // Reset
            reset = function () {
                dirtyFlag.reset();
            };

        self = {
            hireGroupId: hireGroupId,
            hireGroupCode: hireGroupCode,
            hireGroupName: hireGroupName,
            companyId: companyId,
            companyName: companyName,
            isParent: isParent,
            parentHireGroupId: parentHireGroupId,
            parentHireGroupName: parentHireGroupName,
            description: description,
            virtualIsParent: virtualIsParent,
            //Objects
            vehicleDetail: vehicleDetail,
            //Arrays
            hireGroupVehicleDetailList: hireGroupVehicleDetailList,
            upgragedHireGroupList: upgragedHireGroupList,
            // Utility Methods
            errors: errors,
            isValid: isValid,
            dirtyFlag: dirtyFlag,
            hasChanges: hasChanges,
            reset: reset,
        };
        return self;
    };
    // ReSharper disable once AssignToImplicitGlobalInFunctionScope
    VehicleDetail = function () {
        // ReSharper restore InconsistentNaming
        var // Reference to this object
            self,
            // Unique key
            vehicleDetailId = ko.observable(),
            // Vehicle Make 
            vehicleMakeId = ko.observable().extend({ required: true }),
            //Vehicle Make Name
            vehicleMakeName = ko.observable(),
            //Vehicle Category Id
            vehicleCategoryId = ko.observable().extend({ required: true }),
            //Vehicle Category Name
            vehicleCategoryName = ko.observable(),
            //Vehicle Model Id
            vehicleModelId = ko.observable().extend({ required: true }),
            //Vehicle Model Name
            vehicleModelName = ko.observable(),
               //Vehicle Model Year Id
            vehicleModelYearId = ko.observable().extend({ required: true }),
            //Vehicle Model Year 
            vehicleModeYear = ko.observable(),
            // Errors
            errors = ko.validation.group({
                vehicleMakeId: vehicleMakeId,
                vehicleCategoryId: vehicleCategoryId,
                vehicleModelId: vehicleModelId,
                vehicleModelYearId: vehicleModelYearId,
            }),
            // Is Valid
            isValid = ko.computed(function () {
                return errors().length === 0;
            }),
            // True if the booking has been changed
        // ReSharper disable InconsistentNaming
            dirtyFlag = new ko.dirtyFlag({
                vehicleMakeId: vehicleMakeId,
                vehicleCategoryId: vehicleCategoryId,
                vehicleModelId: vehicleModelId,
                vehicleModelYearId: vehicleModelYearId,
            }),
            // Has Changes
            hasChanges = ko.computed(function () {
                return dirtyFlag.isDirty();
            }),
            // Reset
            reset = function () {
                dirtyFlag.reset();
            };

        self = {
            vehicleDetailId: vehicleDetailId,
            vehicleMakeId: vehicleMakeId,
            vehicleCategoryId: vehicleCategoryId,
            vehicleModelId: vehicleModelId,
            vehicleModelYearId: vehicleModelYearId,
            vehicleMakeName: vehicleMakeName,
            vehicleCategoryName: vehicleCategoryName,
            vehicleModelName: vehicleModelName,
            vehicleModeYear: vehicleModeYear,
            // Utility Methods
            errors: errors,
            isValid: isValid,
            dirtyFlag: dirtyFlag,
            hasChanges: hasChanges,
            reset: reset,
        };
        return self;
    };
    // ReSharper disable once InconsistentNaming
    var HireGroupClientMapper = function (source) {
        var hireGroup = new HireGroup();
        hireGroup.hireGroupId(source.HireGroupId === null ? undefined : source.HireGroupId);
        hireGroup.hireGroupCode(source.HireGroupCode === null ? undefined : source.HireGroupCode);
        hireGroup.hireGroupName(source.HireGroupName === null ? undefined : source.HireGroupName);
        hireGroup.parentHireGroupName(source.ParentHireGroupName === null ? undefined : source.ParentHireGroupName);
        hireGroup.parentHireGroupId(source.ParentHireGroupId === null ? undefined : source.ParentHireGroupId);
        hireGroup.description(source.Description === null ? undefined : source.Description);
        hireGroup.companyName(source.CompanyName === null ? undefined : source.CompanyName);
        hireGroup.companyId(source.CompanyId === null ? undefined : source.CompanyId);
        hireGroup.isParent(source.IsParent === null ? false : source.IsParent);
        hireGroup.virtualIsParent(source.IsParent === null ? false : source.IsParent);
        return hireGroup;
    };
    return {
        HireGroup: HireGroup,
        HireGroupClientMapper: HireGroupClientMapper,
        VehicleDetail: VehicleDetail
    };
});