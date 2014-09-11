/*
    Module with the model for the Employee
*/
define(["ko", "underscore", "underscore-ko"], function (ko) {
    var
     //Employee List View entity
    // ReSharper disable once InconsistentNaming
    Employee = function () {
        // ReSharper restore InconsistentNaming
        var // Reference to this object
            self,
            // Unique key
            id = ko.observable(),
            //Code
            code = ko.observable(),
            //First Name
            fName = ko.observable(),
             //Last Name
            lName = ko.observable(),
            //Status
            status = ko.observable(),
            //Company
            company = ko.observable(),
            //Nationality
            nationality = ko.observable();

        self = {
            id: id,
            code: code,
            fName: fName,
            lName: lName,
            status: status,
            company: company,
            nationality: nationality,

        };
        return self;
    };
    //Employee Detail Entity
    // ReSharper disable once InconsistentNaming
    var EmployeeDetail = function () {
        var // Reference to this object
          self,
          // Unique key
          empId = ko.observable(),
          //Company Id
          companyId = ko.observable().extend({ required: true }),
          //Employee Status Id
          statusId = ko.observable().extend({ required: true }),
          //Code
          code = ko.observable().extend({ required: true }),
          //First Name
          fName = ko.observable().extend({ required: true }),
          //Middle Name
          mName = ko.observable(),
          //Last Name
          lName = ko.observable(),
          //Date Of birth
          dOB = ko.observable().extend({ required: true }),
          //Gender
          gender = ko.observable(),
          //Nationality Id
          nationalityId = ko.observable(),
          //Notes
          notes = ko.observable(),
           //Notes 1
          notes1 = ko.observable(),
           //Notes2
          notes2 = ko.observable(),
           //Notes 3
          notes3 = ko.observable(),
           //Notes 4
          notes4 = ko.observable(),
           //Notes 5
          notes5 = ko.observable(),

           //#region Other Tabs object
            //Vehicle Other Detail
            jobInfo = ko.observable(new JobInfo()),
          
          //#endregion
          
                 // Errors
            errors = ko.validation.group({
                companyId: companyId,
                statusId: statusId,
                code: code,
                fName: fName,
                dOB: dOB,
            }),
            // Is Valid
            isValid = ko.computed(function () {
                return errors().length === 0;
            }),

            // True if the booking has been changed
            // ReSharper disable InconsistentNaming
            dirtyFlag = new ko.dirtyFlag({
                companyId: companyId,
                statusId: statusId,
                code: code,
                fName: fName,
                mName: mName,
                lName: lName,
                dOB: dOB,
                nationalityId: nationalityId,
                notes: notes,
                notes1: notes1,
                notes2: notes2,
                notes3: notes3,
                notes4: notes4,
                notes5: notes5,
                gender: gender,
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
            empId: empId,
            companyId: companyId,
            statusId: statusId,
            code: code,
            fName: fName,
            mName: mName,
            lName: lName,
            dOB: dOB,
            nationalityId: nationalityId,
            notes: notes,
            notes1: notes1,
            notes2: notes2,
            notes3: notes3,
            notes4: notes4,
            notes5: notes5,
            gender: gender,
            jobInfo :jobInfo,
            errors: errors,
            isValid: isValid,
            dirtyFlag: dirtyFlag,
            hasChanges: hasChanges,
            reset: reset,
        };
        return self;
    };
    //Employee Detail Entity
    // ReSharper disable once InconsistentNaming
    var JobInfo = function () {
        var // Reference to this object
          self,
          // Unique key
          jobInfoId = ko.observable(),
          //Job Type Id
          jobTypeId = ko.observable(),
          //Desgnation Id
          desgId = ko.observable().extend({ required: true }),
          //Degnation Grade Id
          desgGardeId = ko.observable().extend({ required: true }),
          //Department ID
          depId = ko.observable().extend({ required: true }),
          //Work PLace ID
          workPlaceId = ko.observable().extend({ required: true }),
          //Supervisor ID
          supervisorId = ko.observable(),
          //Joining DAte
          joiningDate = ko.observable(),
          //Salary
          salary = ko.observable(),
        
              // Errors
            errors = ko.validation.group({
               
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
            jobInfoId: jobInfoId,
            jobTypeId:jobTypeId,
            desgId: desgId,
            desgGardeId: desgGardeId,
            depId: depId,
            workPlaceId: workPlaceId,
            supervisorId: supervisorId,
            joiningDate: joiningDate,
            salary: salary,
            errors: errors,
            isValid: isValid,
            dirtyFlag: dirtyFlag,
            hasChanges: hasChanges,
            reset: reset,
        };
        return self;
    };
    //Server To Client Mapper
    // ReSharper disable once InconsistentNaming
    var EmployeeClientMapper = function (source) {
        var employee = new Employee();
        employee.id(source.Id === null ? undefined : source.Id);
        employee.code(source.Code === null ? undefined : source.Code);
        employee.fName(source.FirstName === null ? undefined : source.FirstName);
        employee.lName(source.LastName === null ? undefined : source.LastName);
        employee.status(source.EmpStatus === null ? undefined : source.EmpStatus);
        employee.company(source.CompanyCodeName === null ? undefined : source.CompanyCodeName);
        employee.nationality(source.Nationality === null ? undefined : source.Nationality);

        return employee;
    };
    //Client To Server(Vehicle Other Detail)
    var EmployeeDetailServerMapper = function (source) {
        var result = {};
        result.EmployeeId = source.empId() === undefined ? 0 : source.empId();
        result.CompanyId = source.companyId() === undefined ? null : source.companyId();
        result.EmpStatusId = source.statusId() === undefined ? null : source.statusId();
        result.EmpCode = source.code() === undefined ? null : source.code();
        result.EmpFName = source.fName() === undefined ? null : source.fName();
        result.EmpMName = source.mName() === undefined ? null : source.mName();
        result.EmpLName = source.lName() === undefined ? null : source.lName();
        result.NationalityId = source.nationalityId() === undefined ? null : source.nationalityId();
        result.Gender = source.gender() === undefined ? null : source.gender();
        result.Notes = source.notes() === undefined ? null : source.notes();
        result.Notes1 = source.notes1() === undefined ? null : source.notes1();
        result.Notes2 = source.notes2() === undefined ? null : source.notes2();
        result.Notes3 = source.notes3() === undefined ? null : source.notes3();
        result.Notes4 = source.notes4() === undefined ? null : source.notes4();
        result.Notes5 = source.notes5() === undefined ? null : source.notes5();
        result.DOB = source.dOB() === undefined || source.dOB() === null ? null : moment(source.dOB()).format(ist.utcFormat);

        return result;
    };
    //Server To Client Mapper
    // ReSharper disable once InconsistentNaming
    var EmployeeDetailClientMapper = function (source) {
        var empDetail = new EmployeeDetail();
        empDetail.empId(source.EmployeeId === null ? undefined : source.EmployeeId);
        empDetail.companyId(source.CompanyId === null ? undefined : source.CompanyId);
        empDetail.statusId(source.EmpStatusId === null ? undefined : source.EmpStatusId);
        empDetail.code(source.EmpCode === null ? undefined : source.EmpCode);
        empDetail.fName(source.EmpFName === null ? undefined : source.EmpFName);
        empDetail.mName(source.EmpMName === null ? undefined : source.EmpMName);
        empDetail.lName(source.EmpLName === null ? undefined : source.EmpLName);
        empDetail.nationalityId(source.NationalityId === null ? undefined : source.NationalityId);
        empDetail.notes(source.Notes === null ? undefined : source.Notes);
        empDetail.notes1(source.Notes1 === null ? undefined : source.Notes1);
        empDetail.notes2(source.Notes2 === null ? undefined : source.Notes2);
        empDetail.notes3(source.Notes3 === null ? undefined : source.Notes3);
        empDetail.notes4(source.Notes4 === null ? undefined : source.Notes4);
        empDetail.notes5(source.Notes5 === null ? undefined : source.Notes5);
        empDetail.gender(source.Gender === null ? undefined : source.Gender);
        empDetail.dOB(source.DOB !== null ? moment(source.DOB, ist.utcFormat).toDate() : undefined);
       
        return empDetail;
    };
    var EmployeeDetailServerMapperForId = function (source) {
        var result = {};
        result.EmployeeId = source.id() === undefined ? 0 : source.id();
       
        return result;
    };
    return {
        Employee: Employee,
        EmployeeDetail: EmployeeDetail,
        JobInfo:JobInfo,
        EmployeeClientMapper: EmployeeClientMapper,
        EmployeeDetailClientMapper:EmployeeDetailClientMapper,
        EmployeeDetailServerMapper: EmployeeDetailServerMapper,
        EmployeeDetailServerMapperForId: EmployeeDetailServerMapperForId

    };
});