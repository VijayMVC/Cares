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
           //Job Info
            jobInfo = ko.observable(new JobInfo()),
            //Addess 
            address = ko.observable(new Address()),
            //Phone
            phone = ko.observable(new Phone()),
            //Job Progress
            jobProgress = ko.observable(new JobProgress()),
            //Authorized Location
            authorizedLocation = ko.observable(new AuthorizedLocation()),
            //Employee Address List
            employeeAddressList = ko.observableArray([]),
            //Employee Phone List
            phonesList = ko.observableArray([]),
            //job Progress List
            jobProgressList = ko.observableArray([]),

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
            jobInfo: jobInfo,
            address: address,
            phone: phone,
            employeeAddressList: employeeAddressList,
            phonesList: phonesList,
            jobProgress: jobProgress,
            jobProgressList: jobProgressList,
            authorizedLocation: authorizedLocation,
            errors: errors,
            isValid: isValid,
            dirtyFlag: dirtyFlag,
            hasChanges: hasChanges,
            reset: reset,
        };
        return self;
    };
    //Employee Detail Entity
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
          salary = ko.observable().extend({ number: true }),

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
            jobTypeId: jobTypeId,
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
    // Business Partner Address entity
    var Address = function () {
        // ReSharper restore InconsistentNaming
        var // Reference to this object
            self,
            // Main Top Section 
            // Address Id
            addressId = ko.observable(),
            // Contact Person
            contactPerson = ko.observable(),
            // Street Address
            streetAddress = ko.observable().extend({ required: true }),
            // Email Address
            emailAddress = ko.observable().extend({ email: true }),
            // Web Page
            webPage = ko.observable(),
            // Zip Code
            zipCode = ko.observable(),
            // PO Box
            poBox = ko.observable(),
            // Country Id
            countryId = ko.observable().extend({ required: true }),
             // Country Name
            countryName = ko.observable(),
            // Region Id
            regionId = ko.observable(),
             // Region Name
            regionName = ko.observable(),
            // Sub Region Id
            subRegionId = ko.observable(),
             // Sub Region Name
            subRegionName = ko.observable(),
            // City Id
            cityId = ko.observable(),
            // City Name
            cityName = ko.observable(),
            // Area Id
            areaId = ko.observable(),
            // Area Name
            areaName = ko.observable(),
            // Address Type Id
            addressTypeId = ko.observable().extend({ required: true }),
             // Address Type Name
            addressTypeName = ko.observable(),
              // Is Busy
            isBusy = ko.observable(false),
            // Errors
            errors = ko.validation.group({
                streetAddress: streetAddress,
                countryId: countryId,
                addressTypeId: addressTypeId,
                emailAddress: emailAddress
            }),
            // Is Valid
            isValid = ko.computed(function () {
                return errors().length === 0;
            }),
            // True if the booking has been changed
            // ReSharper disable InconsistentNaming
            dirtyFlag = new ko.dirtyFlag({
                // ReSharper restore InconsistentNaming
                addressId: addressId,
                contactPerson: contactPerson,
                streetAddress: streetAddress,
                emailAddress: emailAddress,
                webPage: webPage,
                zipCode: zipCode,
                poBox: poBox,
                countryId: countryId,
                regionId: regionId,
                subRegionId: subRegionId,
                cityId: cityId,
                areaId: areaId,
                addressTypeId: addressTypeId,
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
            addressId: addressId,
            contactPerson: contactPerson,
            streetAddress: streetAddress,
            emailAddress: emailAddress,
            webPage: webPage,
            zipCode: zipCode,
            poBox: poBox,
            countryId: countryId,
            countryName: countryName,
            regionId: regionId,
            regionName: regionName,
            subRegionId: subRegionId,
            subRegionName: subRegionName,
            cityId: cityId,
            cityName: cityName,
            areaId: areaId,
            areaName: areaName,
            addressTypeId: addressTypeId,
            addressTypeName: addressTypeName,
            errors: errors,
            isValid: isValid,
            dirtyFlag: dirtyFlag,
            hasChanges: hasChanges,
            reset: reset,
            isBusy: isBusy
        };
        return self;
    };
    // Phone entity
    var Phone = function () {
        // ReSharper restore InconsistentNaming
        var // Reference to this object
            self,
            // Main Top Section 
            // Phone Id
            phoneId = ko.observable(),
            // Is Default
            isDefault = ko.observable(),
            // Phone Number
            phoneNumber = ko.observable().extend({ required: true }),
              // Phone Type Id
            phoneTypeId = ko.observable().extend({ required: true }),
             // Phone Type Name
            phoneTypeName = ko.observable(),
            // Is Busy
            isBusy = ko.observable(false),
            // Errors
            errors = ko.validation.group({
                phoneTypeId: phoneTypeId,
                phoneNumber: phoneNumber
            }),
            // Is Valid
            isValid = ko.computed(function () {
                return errors().length === 0;
            }),
            // True if the booking has been changed
            // ReSharper disable InconsistentNaming
            dirtyFlag = new ko.dirtyFlag({
                // ReSharper restore InconsistentNaming
                phoneId: phoneId,
                isDefault: isDefault,
                phoneNumber: phoneNumber,
                phoneTypeId: phoneTypeId,
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
            phoneId: phoneId,
            isDefault: isDefault,
            phoneNumber: phoneNumber,
            phoneTypeId: phoneTypeId,
            phoneTypeName: phoneTypeName,
            errors: errors,
            isValid: isValid,
            dirtyFlag: dirtyFlag,
            hasChanges: hasChanges,
            reset: reset,
            isBusy: isBusy
        };
        return self;
    };
    // Job Progress entity
    // ReSharper disable once InconsistentNaming
    var JobProgress = function () {
        // ReSharper restore InconsistentNaming
        var // Reference to this object
            self,
            // Main Top Section 
            // Job Progress Id
            empJobProgId = ko.observable(),
            // Designation Id
            designationId = ko.observable().extend({ required: true }),
            // Workplace Id
            workplaceId = ko.observable().extend({ required: true }),
              //Designation Start Date
            desigStDt = ko.observable().extend({ required: true }),
             // Designation End Date
            desigEndDt = ko.observable().extend({ required: true }),
            //Designation Name
            desigName = ko.observable(),
            //Work place Name
            workplaceName = ko.observable(),
            // Is Busy
            isBusy = ko.observable(false),
            // Errors
            errors = ko.validation.group({
                designationId: designationId,
                workplaceId: workplaceId,
                desigStDt: desigStDt,
                desigEndDt: desigEndDt,
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
            empJobProgId: empJobProgId,
            designationId: designationId,
            workplaceId: workplaceId,
            desigStDt: desigStDt,
            desigEndDt: desigEndDt,
            desigName: desigName,
            workplaceName: workplaceName,
            errors: errors,
            isValid: isValid,
            dirtyFlag: dirtyFlag,
            hasChanges: hasChanges,
            reset: reset,
            isBusy: isBusy
        };
        return self;
    };
    // Authorized Location entity
    // ReSharper disable once InconsistentNaming
    var AuthorizedLocation = function () {
        // ReSharper restore InconsistentNaming
        var // Reference to this object
            self,
            // Main Top Section 
            //  Id
            id = ko.observable(),
            // Operations Workplace Id
            operationsWorkplaceId = ko.observable().extend({ required: true }),
            // Workplace Id
            isDefault = ko.observable(true),
            //Is Operation Default
            isOperationDefault = ko.observable(true),
             // operations Workplace Name
            operationsWorkplaceName = ko.observable(),
            //Operation Name
            operationName = ko.observable(),
            //Operation Id
            operationId = ko.observable(),
             // Is Busy
            isBusy = ko.observable(false),
            // Errors
            errors = ko.validation.group({
                operationsWorkplaceId: operationsWorkplaceId,
               
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
            operationsWorkplaceId: operationsWorkplaceId,
            isDefault: isDefault,
            isOperationDefault: isOperationDefault,
            operationsWorkplaceName: operationsWorkplaceName,
            operationName: operationName,
            operationId: operationId,
            errors: errors,
            isValid: isValid,
            dirtyFlag: dirtyFlag,
            hasChanges: hasChanges,
            reset: reset,
            isBusy: isBusy
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
    //Client To ServerEmployee Detail)
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
        // Address tab
        result.Addresses = [];
        _.each(source.employeeAddressList(), function (item) {
            result.Addresses.push(AddressServerMapper(item));
        });
        //Job Info Tab
        result.EmpJobInfo = JobInfoServerMapper(source.jobInfo());

        // Phone tab
        result.PhoneNumbers = [];
        _.each(source.phonesList(), function (item) {
            result.PhoneNumbers.push(PhoneServerMapper(item));
        });

        // Job Progress tab
        result.EmpJobProgs = [];
        _.each(source.jobProgressList(), function (item) {
            result.EmpJobProgs.push(JobProgressServerMapper(item));
        });


        return result;
    };
    // Convert Address Client to Server
    var AddressServerMapper = function (item) {
        var result = {};
        result.AddressId = item.addressId() === undefined ? undefined : item.addressId();
        result.ContactPerson = item.contactPerson() === undefined ? undefined : item.contactPerson();
        result.StreetAddress = item.streetAddress() === undefined ? undefined : item.streetAddress();
        result.EmailAddress = item.emailAddress() === undefined ? undefined : item.emailAddress();
        result.WebPage = item.webPage() === undefined ? undefined : item.webPage();
        result.ZipCode = item.zipCode() === undefined ? undefined : item.zipCode();
        result.PoBox = item.poBox() === undefined ? undefined : item.poBox();
        result.CountryId = item.countryId() === undefined ? undefined : item.countryId();
        result.RegionId = item.regionId() === undefined ? undefined : item.regionId();
        result.SubRegionId = item.subRegionId() === undefined ? undefined : item.subRegionId();
        result.CityId = item.cityId() === undefined ? undefined : item.cityId();
        result.AreaId = item.areaId() === undefined ? undefined : item.areaId();
        result.AddressTypeId = item.addressTypeId() === undefined ? undefined : item.addressTypeId();
        return result;
    };
    // Convert Phone Client to Server
    var PhoneServerMapper = function (item) {
        var result = {};
        // Fourth Tab : Business Partner Phone
        result.PhoneId = item.phoneId() === undefined ? undefined : item.phoneId();
        result.IsDefault = item.isDefault() === undefined ? undefined : item.isDefault();
        result.PhoneNumber = item.phoneNumber() === undefined ? undefined : item.phoneNumber();
        result.PhoneTypeId = item.phoneTypeId() === undefined ? undefined : item.phoneTypeId();
        return result;
    };
    // Convert Job Progress Client to Server
    var JobProgressServerMapper = function (item) {
        var result = {};
        result.EmpJobProgId = item.empJobProgId() === undefined ? null : item.empJobProgId();
        result.DesignationId = item.designationId() === undefined ? null : item.designationId();
        result.WorkplaceId = item.workplaceId() === undefined ? null : item.workplaceId();
        result.DesigStDt = item.desigStDt() === undefined || item.desigStDt() === null ? null : moment(item.desigStDt()).format(ist.utcFormat);
        result.DesigEndDt = item.desigEndDt() === undefined || item.desigEndDt() === null ? null : moment(item.desigEndDt()).format(ist.utcFormat);
        return result;
    };
    // Convert Phone Client to Server
    var JobInfoServerMapper = function (item) {
        var result = {};
        result.JobInfoId = item.jobInfoId() === undefined ? null : item.jobInfoId();
        result.DesignationId = item.desgId() === undefined ? null : item.desgId();
        result.DesigGradeId = item.desgGardeId() === undefined ? null : item.desgGardeId();
        result.JobTypeId = item.jobTypeId() === undefined ? null : item.jobTypeId();
        result.DepartmentId = item.depId() === undefined ? null : item.depId();
        result.WorkplaceId = item.workPlaceId() === undefined ? null : item.workPlaceId();
        result.SupervisorId = item.supervisorId() === undefined ? null : item.supervisorId();
        result.Salary = item.salary() === undefined ? null : item.salary();
        result.JoiningDt = item.joiningDate() === undefined || item.joiningDate() === null ? null : moment(item.joiningDate()).format(ist.utcFormat);
        return result;
    };
    //Server To Client Mapper
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
    //Server To Client
    var EmployeeDetailServerMapperForId = function (source) {
        var result = {};
        result.EmployeeId = source.id() === undefined ? 0 : source.id();

        return result;
    };
    return {
        Employee: Employee,
        EmployeeDetail: EmployeeDetail,
        JobInfo: JobInfo,
        Address: Address,
        Phone: Phone,
        JobProgress: JobProgress,
        AuthorizedLocation: AuthorizedLocation,

        EmployeeClientMapper: EmployeeClientMapper,
        EmployeeDetailClientMapper: EmployeeDetailClientMapper,

        EmployeeDetailServerMapper: EmployeeDetailServerMapper,
        AddressServerMapper: AddressServerMapper,
        PhoneServerMapper: PhoneServerMapper,
        JobProgressServerMapper: JobProgressServerMapper,
        EmployeeDetailServerMapperForId: EmployeeDetailServerMapperForId

    };
});