/*
    Module with the model for the Seasonal Discount
*/
define(["ko", "underscore", "underscore-ko"], function (ko) {
    var
   //Seasonal Discount Main Entity
    // ReSharper disable once InconsistentNaming
    SeasonalDiscountMain = function () {
        var // Reference to this object
            self,
            // Unique key
            id = ko.observable(),
            //Code
            code = ko.observable().extend({ required: true }),
            //Name
            name = ko.observable(),
            //Description
            description = ko.observable(),
            //Company Id
            companyId = ko.observable().extend({ required: true }),
            //company Code Name
            companyCodeName = ko.observable(),
            //Department Id
            departmentId = ko.observable().extend({ required: true }),
            //operation Id
            operationId = ko.observable().extend({ required: true }),
            //Operation Code Name
            operationCodeName = ko.observable(),
            //Tariff type Id
            tariffTypeId = ko.observable().extend({ required: true }),
            //Tariff type Code Name
            tariffTypeCodeName = ko.observable(),
            //Start Date
            startDate = ko.observable().extend({ required: true }),
            //End Date
            endDate = ko.observable().extend({ required: true }),
            //String valued formatted date
            formattedStartDate = ko.computed({
                read: function () {
                    return moment(startDate()).format(ist.datePattern);
                }
            }),
             //String valued formatted date
            formattedEndDate = ko.computed({
                read: function () {
                    return moment(endDate()).format(ist.datePattern);
                }
            }),
            //Seasonal Discount
            seasonalDiscount = ko.observable(new SeasonalDiscount()),
            //Seasonal Discount List
            seasonalDiscountsList = ko.observable([]),
             // Errors
            errors = ko.validation.group({
                code: code,
                companyId: companyId,
                departmentId: departmentId,
                operationId: operationId,
                tariffTypeId: tariffTypeId,
                startDate: startDate,
                endDate: endDate,
            }),
            // Is Valid
            isValid = ko.computed(function () {
                return errors().length === 0;
            }),

            // True if the booking has been changed
            // ReSharper disable InconsistentNaming
            dirtyFlag = new ko.dirtyFlag({
                code: code,
                companyId: companyId,
                departmentId: departmentId,
                operationId: operationId,
                tariffTypeId: tariffTypeId,
                startDate: startDate,
                endDate: endDate,
                name: name,
                description: description,

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
            id: id,
            code: code,
            companyId: companyId,
            departmentId: departmentId,
            operationId: operationId,
            tariffTypeId: tariffTypeId,
            startDate: startDate,
            endDate: endDate,
            companyCodeName: companyCodeName,
            operationCodeName: operationCodeName,
            tariffTypeCodeName: tariffTypeCodeName,
            name: name,
            description: description,
            formattedStartDate: formattedStartDate,
            formattedEndDate: formattedEndDate,
            seasonalDiscount: seasonalDiscount,
            seasonalDiscountsList: seasonalDiscountsList,
            errors: errors,
            isValid: isValid,
            dirtyFlag: dirtyFlag,
            hasChanges: hasChanges,
            reset: reset,
        };
        return self;
    };
    //Seasonal Discounte Entity
    // ReSharper disable once AssignToImplicitGlobalInFunctionScope
    SeasonalDiscount = function () {
        var // Reference to this object
          self,
          // Unique key
          id = ko.observable(),
          //Opearation Workplace Id
         opWorkplaceId = ko.observable(),
          //Opearation Workplace Code Name
          opWorkplaceCodeName = ko.observable("All"),
            //Hire Group Id
         hireGroupId = ko.observable(),
          //Hire Group Code Name
          hireGroupCodeName = ko.observable("All"),
          //Vehicle Category ID
          vCategoryId = ko.observable(),
          //Vehicle Category Code Name
          vCategoryCodeName = ko.observable("All"),
          //Customer Type ID
          customerTypeId = ko.observable(),
          //Customer Type Code Name
          customerTypeCodeName = ko.observable("Both"),
           //Vehicle Make ID
          vMakeId = ko.observable(),
          //Vehicle Make Code Name
          vMakeCodeName = ko.observable("All"),
            //Vehicle Model ID
          vModelId = ko.observable(),
          //Vehicle Model Code Name
          vModelCodeName = ko.observable("All"),
          //MOdel Year
          modelYear = ko.observable(),
          //model Year Code
          modelYearCode = ko.observable("All"),
           //Rating Type ID
          ratingId = ko.observable(),
          //Rating Type Code Name
          ratingCodeName = ko.observable("All"),
          //From Date
          fromDate = ko.observable().extend({ required: true }),
          //To Date
          toDate = ko.observable().extend({ required: true }),
          //Rate
          discount = ko.observable().extend({ required: true, number: true }),
          //Revision Number
          revisionNumber = ko.observable(),
           //String valued formatted date
            formattedStartDate = ko.computed({
                read: function () {
                    return moment(fromDate()).format(ist.datePattern);
                }
            }),
             //String valued formatted date
            formattedEndDate = ko.computed({
                read: function () {
                    return moment(toDate()).format(ist.datePattern);
                }
            }),
              // Errors
            errors = ko.validation.group({
                fromDate: fromDate,
                toDate: toDate,
                discount: discount,
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
            id: id,
            opWorkplaceId: opWorkplaceId,
            opWorkplaceCodeName: opWorkplaceCodeName,
            hireGroupId: hireGroupId,
            hireGroupCodeName: hireGroupCodeName,
            vCategoryId: vCategoryId,
            vCategoryCodeName: vCategoryCodeName,
            customerTypeId: customerTypeId,
            customerTypeCodeName: customerTypeCodeName,
            vMakeId: vMakeId,
            vMakeCodeName: vMakeCodeName,
            vModelId: vModelId,
            vModelCodeName: vModelCodeName,
            modelYear: modelYear,
            modelYearCode: modelYearCode,
            formattedStartDate: formattedStartDate,
            formattedEndDate: formattedEndDate,
            revisionNumber: revisionNumber,
            ratingId: ratingId,
            ratingCodeName: ratingCodeName,
            fromDate: fromDate,
            toDate: toDate,
            discount: discount,
            errors: errors,
            isValid: isValid,
            dirtyFlag: dirtyFlag,
            hasChanges: hasChanges,
            reset: reset,
        };
        return self;
    };
    //Convert Server To Client
    var SeasonalDiscountMainClientMapper = function (source) {
        var seasonalDiscountMain = new SeasonalDiscountMain();
        seasonalDiscountMain.id(source.SeasonalDiscountMainId === null ? undefined : source.SeasonalDiscountMainId);
        seasonalDiscountMain.code(source.Code === null ? undefined : source.Code);
        seasonalDiscountMain.name(source.Name === null ? undefined : source.Name);
        seasonalDiscountMain.description(source.Description === null ? undefined : source.Description);
        seasonalDiscountMain.companyId(source.CompanyId === null ? undefined : source.CompanyId);
        seasonalDiscountMain.companyCodeName(source.CompanyCodeName === null ? undefined : source.CompanyCodeName);
        seasonalDiscountMain.departmentId(source.DepartmentId === null ? undefined : source.DepartmentId);
        seasonalDiscountMain.operationId(source.OperationId === null ? undefined : source.OperationId);
        seasonalDiscountMain.operationCodeName(source.OperationCodeName === null ? undefined : source.OperationCodeName);
        seasonalDiscountMain.tariffTypeId(source.TariffTypeId === null ? undefined : source.TariffTypeId);
        seasonalDiscountMain.tariffTypeCodeName(source.TariffTypeCodeName === null ? undefined : source.TariffTypeCodeName);
        seasonalDiscountMain.startDate(source.StartDt !== null ? moment(source.StartDt, ist.utcFormat).toDate() : undefined);
        seasonalDiscountMain.endDate(source.EndDt !== null ? moment(source.EndDt, ist.utcFormat).toDate() : undefined);
        return seasonalDiscountMain;
    };
    //Convert Server To Client
    var SeasonalDiscountClientMapper = function (source) {
        var seasonalDiscount = new SeasonalDiscount();
        seasonalDiscount.id(source.SeasonalDiscountId === null ? undefined : source.SeasonalDiscountId);
        seasonalDiscount.opWorkplaceId(source.OperationsWorkPlaceId === null ? undefined : source.OperationsWorkPlaceId);
        seasonalDiscount.opWorkplaceCodeName(source.OperationsWorkPlaceCode === null ? "All" : source.OperationsWorkPlaceCode);
        seasonalDiscount.hireGroupId(source.HireGroupId === null ? undefined : source.HireGroupId);
        seasonalDiscount.hireGroupCodeName(source.HireGroupCodeName === null ? "All" : source.HireGroupCodeName);
        seasonalDiscount.vMakeId(source.VehicleMakeId === null ? undefined : source.VehicleMakeId);
        seasonalDiscount.vMakeCodeName(source.VehicleMakeCodeName === null ? "All" : source.VehicleMakeCodeName);
        seasonalDiscount.vCategoryId(source.VehicleCategoryId === null ? undefined : source.VehicleCategoryId);
        seasonalDiscount.vCategoryCodeName(source.VehicleCategoryCodeName === null ? "All" : source.VehicleCategoryCodeName);
        seasonalDiscount.vModelId(source.VehicleModelId === null ? undefined : source.VehicleModelId);
        seasonalDiscount.vModelCodeName(source.VehicleModelCodeName === null ? "All" : source.VehicleModelCodeName);
        seasonalDiscount.customerTypeId(source.CustomerType === null ? undefined : source.CustomerType);
        seasonalDiscount.customerTypeCodeName(source.CustomerTypeCodeName === null ? "Both" : source.CustomerTypeCodeName);
        seasonalDiscount.modelYear(source.ModelYear === null ? undefined : source.ModelYear);
        seasonalDiscount.modelYearCode(source.ModelYear === null ? "All" : source.ModelYear);
        seasonalDiscount.ratingId(source.RatingTypeId === null ? undefined : source.RatingTypeId);
        seasonalDiscount.ratingCodeName(source.RatingTypeId === null ? undefined : source.RatingTypeId);
        seasonalDiscount.ratingCodeName(source.RatingTypeCodeName === null ? "All" : source.RatingTypeCodeName);
        seasonalDiscount.discount(source.DiscountPerc === null ? undefined : source.DiscountPerc);
        seasonalDiscount.revisionNumber(source.RevisionNumber === null ? undefined : source.RevisionNumber);
        seasonalDiscount.fromDate(source.StartDt !== null ? moment(source.StartDt, ist.utcFormat).toDate() : undefined);
        seasonalDiscount.toDate(source.EndDt !== null ? moment(source.EndDt, ist.utcFormat).toDate() : undefined);
        return seasonalDiscount;
    };
    //Convert Client To Server
    var SeasonalDiscountMainServerMapper = function (source) {
        var result = {};
        result.SeasonalDiscountMainId = source.id() === undefined ? 0 : source.id();
        result.Code = source.code() === undefined ? null : source.code();
        result.Name = source.name() === undefined ? null : source.name();
        result.Description = source.description() === undefined ? null : source.description();
        result.TariffTypeCode = source.tariffTypeId() === undefined ? 0 : source.tariffTypeId();
        result.StartDt = source.startDate() === undefined || source.startDate() === null ? null : moment(source.startDate()).format(ist.utcFormat);
        result.EndDt = source.endDate() === undefined || source.endDate() === null ? null : moment(source.endDate()).format(ist.utcFormat);
        result.SeasonalDiscountList = [];
        _.each(source.seasonalDiscountsList(), function (item) {
            result.SeasonalDiscountList.push(SeasonalDiscountServerMapper(item));
        });
        return result;
    };
    //Convert Client To Server
    var SeasonalDiscountServerMapper = function (item) {
        var result = {};
        result.SeasonalDiscountId = item.id() === undefined ? 0 : item.id();
        result.OperationsWorkPlaceId = item.opWorkplaceId() === undefined ? null : item.opWorkplaceId();
        result.HireGroupId = item.hireGroupId() === undefined ? null : item.hireGroupId();
        result.VehicleMakeId = item.vMakeId() === undefined ? null : item.vMakeId();
        result.VehicleCategoryId = item.vCategoryId() === undefined ? null : item.vCategoryId();
        result.VehicleModelId = item.vModelId() === undefined ? null : item.vModelId();
        result.CustomerType = item.customerTypeId() === undefined ? null : item.customerTypeId();
        result.ModelYear = item.modelYear() === undefined ? null : item.modelYear();
        result.RatingTypeId = item.ratingId() === undefined ? null : item.ratingId();
        result.DiscountPerc = item.discount() === undefined ? null : item.discount();
        result.StartDt = item.fromDate() === undefined || item.fromDate() === null ? null : moment(item.fromDate()).format(ist.utcFormat);
        result.EndDt = item.toDate() === undefined || item.toDate() === null ? null : moment(item.toDate()).format(ist.utcFormat);
        return result;
    };
    // Convert Client to server
    var SeasonalDiscountServerMapperForId = function (source) {
        var result = {};
        result.SeasonalDiscountMainId = source.id() === undefined ? 0 : source.id();
        return result;
    };


    return {
        SeasonalDiscountMain: SeasonalDiscountMain,
        SeasonalDiscount: SeasonalDiscount,
        SeasonalDiscountMainClientMapper: SeasonalDiscountMainClientMapper,
        SeasonalDiscountClientMapper: SeasonalDiscountClientMapper,
        SeasonalDiscountMainServerMapper: SeasonalDiscountMainServerMapper,
        SeasonalDiscountServerMapper: SeasonalDiscountServerMapper,
        SeasonalDiscountServerMapperForId: SeasonalDiscountServerMapperForId,
    };
});