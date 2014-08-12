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
            //Hire Group Detail list
            hireGroupDetailList = ko.observableArray([]),
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
            hireGroupDetailList: hireGroupDetailList,
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
    HireGroupDetail = function () {
        // ReSharper restore InconsistentNaming
        var // Reference to this object
            self,
            // Unique key
            hireGroupDetailId = ko.observable(),
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
            vehicleModelYearId = ko.observable(),
            //Vehicle Model Year 
            vehicleModelYear = ko.observable(),
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
            hireGroupDetailId: hireGroupDetailId,
            vehicleMakeId: vehicleMakeId,
            vehicleCategoryId: vehicleCategoryId,
            vehicleModelId: vehicleModelId,
            vehicleModelYearId: vehicleModelYearId,
            vehicleMakeName: vehicleMakeName,
            vehicleCategoryName: vehicleCategoryName,
            vehicleModelName: vehicleModelName,
            vehicleModelYear: vehicleModelYear,
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
    //Hire grou Mapper
    // ReSharper disable once InconsistentNaming
    var HireGroupDetailClientMapper = function (source) {
        var hireGroupDetail = new HireGroupDetail();
        hireGroupDetail.hireGroupDetailId(source.hireGroupDetailId === null ? undefined : source.hireGroupDetailId);
        hireGroupDetail.vehicleMakeId(source.vehicleMakeId === null ? undefined : source.vehicleMakeId);
        hireGroupDetail.vehicleMakeName(source.vehicleMakeName === null ? undefined : source.vehicleMakeName);
        hireGroupDetail.vehicleCategoryId(source.vehicleCategoryId === null ? undefined : source.vehicleCategoryId);
        hireGroupDetail.vehicleCategoryName(source.vehicleCategoryName === null ? undefined : source.vehicleCategoryName);
        hireGroupDetail.vehicleModelId(source.vehicleModelId === null ? undefined : source.vehicleModelId);
        hireGroupDetail.vehicleModelName(source.vehicleModelName === null ? undefined : source.vehicleModelName);
        hireGroupDetail.vehicleModelYear(source.vehicleModelYear === 2006 ? undefined : source.vehicleModelYear);
        return hireGroupDetail;
    };
    var HireGroupDetailServerMapper = function (source) {
        var result = {}; 
        result.HireGroupDetailId = source.hireGroupDetailId() === undefined ? 0 : source.hireGroupDetailId();
        result.VehicleMakeId = source.vehicleMakeId() === undefined ? null : source.vehicleMakeId();
        result.VehicleMakeCodeName = source.vehicleMakeName() === undefined ? null : source.vehicleMakeName();
        result.VehicleCategoryId = source.vehicleCategoryId() === undefined ? null : source.vehicleCategoryId();
        result.VehicleCategoryCodeName = source.vehicleCategoryName() === undefined ? null : source.vehicleCategoryName();
        result.VehicleModelId = source.vehicleModelId() === undefined ? null : source.vehicleModelId();
        result.VehicleModelCodeName = source.vehicleModelName() === undefined ? null : source.vehicleModelName();
        result.VehicleModelYear = source.vehicleModelYear() === undefined ? 2006 : source.vehicleModelYear();
        return result;
    };
    var HireGroupServerMapper = function (source) {
        var result = {};
        result.HireGroupId = source.hireGroupId() === undefined ? 0 : source.hireGroupId();
        result.HireGroupCode = source.hireGroupCode() === undefined ? null : source.hireGroupCode();
        result.HireGroupName = source.hireGroupName() === undefined ? null : source.hireGroupName();
        result.ParentHireGroupId = source.parentHireGroupId() === undefined ? null : source.parentHireGroupId();
        result.CompanyId = source.companyId() === undefined ? null : source.companyId();
        result.Description = source.description() === undefined ? null : source.description();
        result.IsParent = source.isParent() === undefined ? false : source.isParent();
        result.HireGroupDetailList = [];
        _.each(source.hireGroupDetailList(), function (item) {
            result.HireGroupDetailList.push(item);
        });

        return result;
    };
    return {
        HireGroup: HireGroup,
        HireGroupClientMapper: HireGroupClientMapper,
        HireGroupDetail: HireGroupDetail,
        HireGroupDetailServerMapper: HireGroupDetailServerMapper,
        HireGroupServerMapper: HireGroupServerMapper,
        HireGroupDetailClientMapper: HireGroupDetailClientMapper
    };
});