/*
    Module with the model for the Chauffer Charge
*/
define(["ko", "underscore", "underscore-ko"], function (ko) {
    var
   //Chauffer Charge Main Entity
    // ReSharper disable once InconsistentNaming
    ChaufferChargeMain = function () {
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
            //String valued formatted date
            formattedStartDate = ko.computed({
                read: function() {
                    return moment(startDate()).format(ist.datePattern);
                }
            }),
            //Chauffer Charge
            chaufferCharge = ko.observable(new ChaufferCharge()),
             // Errors
            errors = ko.validation.group({
                code: code,
                companyId: companyId,
                departmentId: departmentId,
                operationId: operationId,
                tariffTypeId: tariffTypeId,
                startDate: startDate,
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
            id:id,
            code: code,
            companyId: companyId,
            departmentId: departmentId,
            operationId: operationId,
            tariffTypeId: tariffTypeId,
            startDate: startDate,
            companyCodeName: companyCodeName,
            operationCodeName: operationCodeName,
            tariffTypeCodeName: tariffTypeCodeName,
            name: name,
            description: description,
            formattedStartDate: formattedStartDate,
            chaufferCharge: chaufferCharge,
            errors: errors,
            isValid: isValid,
            dirtyFlag: dirtyFlag,
            hasChanges: hasChanges,
            reset: reset,
        };
        return self;
    };
    //Chauffer Charge Entity
    // ReSharper disable once AssignToImplicitGlobalInFunctionScope
    ChaufferCharge = function () {
        var // Reference to this object
          self,
          // Unique key
          id = ko.observable(),
          //Designation Grade Id
         desigGradeId = ko.observable().extend({ required: true }),
          //Designation Grade Code Name
          desigGradeCodeName = ko.observable(),
          //Start Date
          startDate = ko.observable().extend({ required: true }),
          //Rate
          rate = ko.observable().extend({ required: true, number: true }),
          //Revision Number
          revisionNumber = ko.observable(),
           //String valued formatted date
            formattedStartDate = ko.computed({
                read: function () {
                    return moment(startDate()).format(ist.datePattern);
                }
            }),
              // Errors
            errors = ko.validation.group({
                desigGradeId: desigGradeId,
                startDate: startDate,
                rate: rate,
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
            desigGradeId: desigGradeId,
            desigGradeCodeName: desigGradeCodeName,
            startDate: startDate,
            formattedStartDate: formattedStartDate,
            revisionNumber: revisionNumber,
            rate: rate,
            errors: errors,
            isValid: isValid,
            dirtyFlag: dirtyFlag,
            hasChanges: hasChanges,
            reset: reset,
        };
        return self;
    };

    //Convert Server To Client
    var ChaufferChargeMainClientMapper = function (source) {
        var chaufferChargeMain = new ChaufferChargeMain();
        chaufferChargeMain.id(source.ChaufferChargeMainId === null ? undefined : source.ChaufferChargeMainId);
        chaufferChargeMain.code(source.Code === null ? undefined : source.Code);
        chaufferChargeMain.name(source.Name === null ? undefined : source.Name);
        chaufferChargeMain.description(source.Description === null ? undefined : source.Description);
        chaufferChargeMain.companyId(source.CompanyId === null ? undefined : source.CompanyId);
        chaufferChargeMain.companyCodeName(source.CompanyCodeName === null ? undefined : source.CompanyCodeName);
        chaufferChargeMain.departmentId(source.DepartmentId === null ? undefined : source.DepartmentId);
        chaufferChargeMain.operationId(source.OperationId === null ? undefined : source.OperationId);
        chaufferChargeMain.operationCodeName(source.OperationCodeName === null ? undefined : source.OperationCodeName);
        chaufferChargeMain.tariffTypeId(source.TariffTypeId === null ? undefined : source.TariffTypeId);
        chaufferChargeMain.tariffTypeCodeName(source.TariffTypeCodeName === null ? undefined : source.TariffTypeCodeName);
        chaufferChargeMain.startDate(source.StartDate !== null ? moment(source.StartDate, ist.utcFormat).toDate() : undefined);
        return chaufferChargeMain;
    };

    //Convert Server To Client
    var AdditionalChargeClientMapper = function (source) {
        var addCharge = new AdditionalCharge();
        addCharge.id(source.AdditionalChargeId === null ? undefined : source.AdditionalChargeId);
        addCharge.hireGroupDetailCodeName(source.HireGroupDetailCodeName === null ? undefined : source.HireGroupDetailCodeName);
        addCharge.hireGroupDetailId(source.HireGroupDetailId === null ? undefined : source.HireGroupDetailId);
        addCharge.revisionNumber(source.RevisionNumber === null ? undefined : source.RevisionNumber);
        addCharge.rate(source.AdditionalChargeRate === null ? undefined : source.AdditionalChargeRate);
        addCharge.startDate(source.StartDt !== null ? moment(source.StartDt, ist.utcFormat).toDate() : undefined);
        return addCharge;
    };
    //Convert Client To Server
    var AdditionalChargeTypeServerMapper = function (source) {
        var result = {};
        result.AdditionalChargeTypeId = source.id() === undefined ? 0 : source.id();
        result.Code = source.code() === undefined ? null : source.code();
        result.Name = source.name() === undefined ? null : source.name();
        result.Description = source.description() === undefined ? 0 : source.description();
        result.IsEditable = source.isEditable() === undefined ? 0 : source.isEditable();
        result.AdditionalCharges = [];
        _.each(source.additionalChargesList(), function (item) {
            result.AdditionalCharges.push(AdditionalChargeServerMapper(item));
        });

        return result;
    };
    //Convert Client To Server
    var AdditionalChargeServerMapper = function (item) {
        var result = {};
        result.AdditionalChargeId = item.id() === undefined ? 0 : item.id();
        result.HireGroupDetailId = item.hireGroupDetailId() === undefined ? null : item.hireGroupDetailId();
        result.AdditionalChargeRate = item.rate() === undefined ? null : item.rate();
        result.revisionNumber = item.rate() === undefined ? null : item.rate();
        result.StartDt = item.startDate() === undefined || item.startDate() === null ? null : moment(item.startDate()).format(ist.utcFormat);
        return result;
    };
    // Convert Client to server
    var ChaufferChargeServerMapperForId = function (source) {
        var result = {};
        result.AdditionalChargeTypeId = source.id() === undefined ? 0 : source.id();
        return result;
    };
    return {
        ChaufferChargeMain: ChaufferChargeMain,
        ChaufferCharge: ChaufferCharge,
        ChaufferChargeMainClientMapper: ChaufferChargeMainClientMapper,
        ChaufferChargeServerMapperForId: ChaufferChargeServerMapperForId,
    };
});