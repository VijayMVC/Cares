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
            //Document Info
            documentInfo = ko.observable(new DocumentInfo()),
            //Employee Address List
            employeeAddressList = ko.observableArray([]),
            //Employee Phone List
            phonesList = ko.observableArray([]),
            //job Progress List
            jobProgressList = ko.observableArray([]),
            //Authorized Location List
            authorizedLocationList = ko.observableArray([]),

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
            documentInfo: documentInfo,
            authorizedLocationList: authorizedLocationList,
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
          jobTypeId = ko.observable().extend({ required: true }),
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
          joiningDate = ko.observable().extend({ required: true }),
          //Salary
          salary = ko.observable().extend({ number: true }),

              // Errors
            errors = ko.validation.group({
                jobTypeId: jobTypeId,
                desgId: desgId,
                desgGardeId: desgGardeId,
                depId: depId,
                workPlaceId: workPlaceId,
                joiningDate: joiningDate,
                salary: salary,
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
                operationId: operationId

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
    //Document Info. entity
    // ReSharper disable once InconsistentNaming
    var DocumentInfo = function () {
        // ReSharper restore InconsistentNaming
        var // Reference to this object
            self,
           //  Id
            id = ko.observable(),
            //NIC
            nic = ko.observable(),
            //NIC expiry date
            nicExpDt = ko.observable(),
            //Iqama Number
            iqamaNum = ko.observable(),
            //Iqama Expiry Date
            iqamaExpDt = ko.observable(),
            //Passport Number
            passportNum = ko.observable(),
            //Passport Expiry Date
            passportExpDt = ko.observable(),
            //Passport Country
            passCountryId = ko.observable(),
            //Visa Number
            visaNum = ko.observable(),
            //Visa Expiry Date
            visaExpDt = ko.observable(),
            //Visa IssuingCountry
            visaIssuingCountry = ko.observable(),
            //License Num
            licenseNum = ko.observable(),
            //license Expiry Date
            licenseExpDt = ko.observable(),
            //License Type Id
            licenseTypeId = ko.observable(),
            //Insurance Number
            insuranceNum = ko.observable(),
            //Insurance Company
            insuranceComp = ko.observable(),
            //Insurance Date
            insuranceDt = ko.observable(),
             // Is Busy
            isBusy = ko.observable(false),
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
            id: id,
            nic: nic,
            nicExpDt: nicExpDt,
            iqamaNum: iqamaNum,
            iqamaExpDt: iqamaExpDt,
            passportNum: passportNum,
            passportExpDt: passportExpDt,
            passCountryId: passCountryId,
            visaNum: visaNum,
            visaExpDt: visaExpDt,
            visaIssuingCountry: visaIssuingCountry,
            licenseNum: licenseNum,
            licenseExpDt: licenseExpDt,
            licenseTypeId: licenseTypeId,
            insuranceNum: insuranceNum,
            insuranceComp: insuranceComp,
            insuranceDt: insuranceDt,
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
        //Employee Document Info tab
        result.EmpDocsInfo = DocumentInfoServerMapper(source.documentInfo());
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
        // Job Progress tab
        result.AuthorizedLocations = [];
        _.each(source.authorizedLocationList(), function (item) {
            result.AuthorizedLocations.push(AuthorizedLocationServerMapper(item));
        });


        return result;
    };
    // Convert Address Client to Server
    var AddressServerMapper = function (item) {
        var result = {};
        result.AddressId = item.addressId() === undefined ? 0 : item.addressId();
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
    // Convert Address Server to Client
    var AddressClientMapper = function (source) {
        var address = new Address();
        address.addressId(source.AddressId === null ? undefined : source.AddressId);
        address.contactPerson(source.ContactPerson === null ? undefined : source.ContactPerson);
        address.streetAddress(source.StreetAddress === null ? undefined : source.StreetAddress);
        address.emailAddress(source.EmailAddress === null ? undefined : source.EmailAddress);
        address.webPage(source.WebPage === null ? undefined : source.WebPage);
        address.zipCode(source.ZipCode === null ? undefined : source.ZipCode);
        address.poBox(source.PoBox === null ? undefined : source.PoBox);
        address.countryName(source.CountryName === null ? undefined : source.CountryName);
        address.regionName(source.RegionName === null ? undefined : source.RegionName);
        address.subRegionName(source.SubRegionName === null ? undefined : source.SubRegionName);
        address.cityName(source.CityName === null ? undefined : source.CityName);
        address.areaName(source.AreaName === null ? undefined : source.AreaName);
        address.addressTypeName(source.AddressTypeName === null ? undefined : source.AddressTypeName);
        address.countryId(source.CountryId === null ? undefined : source.CountryId);
        address.regionId(source.RegionId === null ? undefined : source.RegionId);
        address.subRegionId(source.SubRegionId === null ? undefined : source.SubRegionId);
        address.cityId(source.CityId === null ? undefined : source.CityId);
        address.areaId(source.AreaId === null ? undefined : source.AreaId);
        address.addressTypeId(source.AddressTypeId === null ? undefined : source.AddressTypeId);
        return address;
    };
    // Convert Phone Client to Server
    var PhoneServerMapper = function (item) {
        var result = {};
        // Fourth Tab : Business Partner Phone
        result.PhoneId = item.phoneId() === undefined ? 0 : item.phoneId();
        result.IsDefault = item.isDefault() === undefined ? undefined : item.isDefault();
        result.PhoneNumber = item.phoneNumber() === undefined ? undefined : item.phoneNumber();
        result.PhoneTypeId = item.phoneTypeId() === undefined ? undefined : item.phoneTypeId();
        return result;
    };
    // Convert Phone Server to Client
    var PhoneClientMapper = function (source) {
        var phone = new Phone();
        phone.phoneId(source.PhoneId === null ? undefined : source.PhoneId);
        phone.isDefault(source.IsDefault === null ? undefined : source.IsDefault);
        phone.phoneNumber(source.PhoneNumber === null ? undefined : source.PhoneNumber);
        phone.phoneTypeName(source.PhoneTypeName === null ? undefined : source.PhoneTypeName);
        return phone;
    };
    // Convert Job Progress Client to Server
    var JobProgressServerMapper = function (item) {
        var result = {};
        result.EmpJobProgId = item.empJobProgId() === undefined ? 0 : item.empJobProgId();
        result.DesignationId = item.designationId() === undefined ? 0 : item.designationId();
        result.WorkplaceId = item.workplaceId() === undefined ? 0 : item.workplaceId();
        result.DesigStDt = item.desigStDt() === undefined || item.desigStDt() === null ? null : moment(item.desigStDt()).format(ist.utcFormat);
        result.DesigEndDt = item.desigEndDt() === undefined || item.desigEndDt() === null ? null : moment(item.desigEndDt()).format(ist.utcFormat);
        return result;
    };
    // Convert Job Progress Server to Client
    var JobProgressClientMapper = function (source) {
        var jobProgress = new JobProgress();
        jobProgress.empJobProgId(source.EmpJobProgId === null ? undefined : source.EmpJobProgId);
        jobProgress.desigName(source.DesignationCodeName === null ? undefined : source.DesignationCodeName);
        jobProgress.workplaceName(source.WorkplaceCodeName === null ? undefined : source.WorkplaceCodeName);
        jobProgress.desigStDt(source.DesigStDt !== null ? moment(source.DesigStDt, ist.utcFormat).toDate() : undefined);
        jobProgress.desigEndDt(source.DesigEndDt !== null ? moment(source.DesigEndDt, ist.utcFormat).toDate() : undefined);
        return jobProgress;
    };
    // Convert Job Info Client to Server
    var JobInfoServerMapper = function (item) {
        var result = {};
        result.JobInfoId = item.jobInfoId() === undefined ? 0 : item.jobInfoId();
        result.EmployeeId = 0;
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
    // Convert Phone Server to Client
    var JobInfoClientMapper = function (source) {
        var jobInfo = new JobInfo();
        jobInfo.jobInfoId(source.EmployeeId === null ? undefined : source.EmployeeId);
        jobInfo.desgId(source.DesignationId === null ? undefined : source.DesignationId);
        jobInfo.desgGardeId(source.DesigGradeId === null ? undefined : source.DesigGradeId);
        jobInfo.jobTypeId(source.JobTypeId === null ? undefined : source.JobTypeId);
        jobInfo.depId(source.DepartmentId === null ? undefined : source.DepartmentId);
        jobInfo.workPlaceId(source.WorkplaceId === null ? undefined : source.WorkplaceId);
        jobInfo.supervisorId(source.SupervisorId === null ? undefined : source.SupervisorId);
        jobInfo.salary(source.Salary === null ? undefined : source.Salary);
        jobInfo.joiningDate(source.JoiningDt !== null ? moment(source.JoiningDt, ist.utcFormat).toDate() : undefined);
        return jobInfo;
    };
    // Convert Phone Client to Server
    var DocumentInfoServerMapper = function (item) {
        var result = {};
        result.EmployeeId = item.id() === undefined ? 0 : item.id();
        result.NIC = item.nic() === undefined ? null : item.nic();
        result.NICExpDt = item.nicExpDt() === undefined || item.nicExpDt() === null ? null : moment(item.nicExpDt()).format(ist.utcFormat);
        result.IqamaNo = item.iqamaNum() === undefined ? null : item.iqamaNum();
        result.IqamaExpDt = item.iqamaExpDt() === undefined || item.iqamaExpDt() === null ? null : moment(item.iqamaExpDt()).format(ist.utcFormat);
        result.PassportNo = item.passportNum() === undefined ? null : item.passportNum();
        result.PassportExpDt = item.passportExpDt() === undefined || item.passportExpDt() === null ? null : moment(item.passportExpDt()).format(ist.utcFormat);
        result.PassportCountryId = item.passCountryId() === undefined ? null : item.passCountryId();
        result.VisaNo = item.visaNum() === undefined ? null : item.visaNum();
        result.VisaExpDt = item.visaExpDt() === undefined || item.visaExpDt() === null ? null : moment(item.visaExpDt()).format(ist.utcFormat);
        result.VisaIssueCountryId = item.visaIssuingCountry() === undefined ? null : item.visaIssuingCountry();
        result.LicenseNo = item.licenseNum() === undefined ? null : item.licenseNum();
        result.LicenseExpDt = item.licenseExpDt() === undefined || item.licenseExpDt() === null ? null : moment(item.licenseExpDt()).format(ist.utcFormat);
        result.LicenseTypeId = item.licenseTypeId() === undefined ? null : item.licenseTypeId();
        result.InsuranceNo = item.insuranceNum() === undefined ? null : item.insuranceNum();
        result.InsuranceCompany = item.insuranceComp() === undefined ? null : item.insuranceComp();
        result.InsuranceDt = item.insuranceDt() === undefined || item.insuranceDt() === null ? null : moment(item.insuranceDt()).format(ist.utcFormat);
        return result;
    };
    // Convert Phone Server to Client
    var DocumentInfoClientMapper = function (source) {
        var docInfo = new DocumentInfo();
        docInfo.id(source.EmployeeId === null ? undefined : source.EmployeeId);
        docInfo.nic(source.NIC === null ? undefined : source.NIC);
        docInfo.nicExpDt(source.NICExpDt !== null ? moment(source.NICExpDt, ist.utcFormat).toDate() : undefined);
        docInfo.iqamaNum(source.IqamaNo === null ? undefined : source.IqamaNo);
        docInfo.iqamaExpDt(source.IqamaExpDt !== null ? moment(source.IqamaExpDt, ist.utcFormat).toDate() : undefined);
        docInfo.passportNum(source.PassportNo === null ? undefined : source.PassportNo);
        docInfo.passportExpDt(source.PassportExpDt !== null ? moment(source.PassportExpDt, ist.utcFormat).toDate() : undefined);
        docInfo.passCountryId(source.PassportCountryId === null ? undefined : source.PassportCountryId);
        docInfo.visaNum(source.VisaNo === null ? undefined : source.VisaNo);
        docInfo.visaExpDt(source.VisaExpDt !== null ? moment(source.VisaExpDt, ist.utcFormat).toDate() : undefined);
        docInfo.visaIssuingCountry(source.VisaIssueCountryId === null ? undefined : source.VisaIssueCountryId);
        docInfo.licenseNum(source.LicenseNo === null ? undefined : source.LicenseNo);
        docInfo.licenseExpDt(source.LicenseExpDt !== null ? moment(source.LicenseExpDt, ist.utcFormat).toDate() : undefined);
        docInfo.licenseTypeId(source.LicenseTypeId === null ? undefined : source.LicenseTypeId);
        docInfo.insuranceNum(source.InsuranceNo === null ? undefined : source.InsuranceNo);
        docInfo.insuranceComp(source.InsuranceCompany === null ? undefined : source.InsuranceCompany);
        docInfo.insuranceDt(source.InsuranceDt !== null ? moment(source.InsuranceDt, ist.utcFormat).toDate() : undefined);
        return docInfo;
    };
    //Convert Authorized Location Client to Server
    var AuthorizedLocationServerMapper = function (source) {
        var result = {};
        result.EmpAuthLocationId = source.id() === undefined ? 0 : source.id();
        result.OperationsWorkplaceId = source.operationsWorkplaceId() === undefined ? 0 : source.operationsWorkplaceId();
        result.IsDefault = source.isDefault() === undefined ? true : source.isDefault();
        result.IsOperationDefault = source.isOperationDefault() === undefined ? true : source.isOperationDefault();
        return result;
    };
    //Convert Authorized Location Server to Client
    var AuthorizedLocationClientMapper = function (source) {
        var authLocation = new AuthorizedLocation();
        authLocation.id(source.EmpAuthLocationId === null ? undefined : source.EmpAuthLocationId);
        authLocation.operationsWorkplaceName(source.OperationworkPalceCode === null ? undefined : source.OperationworkPalceCode);
        authLocation.operationName(source.OperationCodeName === null ? undefined : source.OperationCodeName);
        authLocation.isDefault(source.IsDefault === null ? undefined : source.IsDefault);
        authLocation.isOperationDefault(source.IsOperationDefault === null ? undefined : source.IsOperationDefault);
        return authLocation;
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

        //Job Info
        empDetail.jobInfo(JobInfoClientMapper(source.EmpJobInfo));
        //Document Info
        empDetail.documentInfo(DocumentInfoClientMapper(source.EmpDocsInfo));

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
        DocumentInfo: DocumentInfo,
        EmployeeClientMapper: EmployeeClientMapper,
        EmployeeDetailClientMapper: EmployeeDetailClientMapper,
        JobInfoClientMapper: JobInfoClientMapper,
        AddressClientMapper: AddressClientMapper,
        PhoneClientMapper: PhoneClientMapper,
        JobProgressClientMapper: JobProgressClientMapper,
        DocumentInfoClientMapper: DocumentInfoClientMapper,
        AuthorizedLocationClientMapper: AuthorizedLocationClientMapper,
        EmployeeDetailServerMapper: EmployeeDetailServerMapper,
        AddressServerMapper: AddressServerMapper,
        PhoneServerMapper: PhoneServerMapper,
        JobProgressServerMapper: JobProgressServerMapper,
        DocumentInfoServerMapper: DocumentInfoServerMapper,
        AuthorizedLocationServerMapper: AuthorizedLocationServerMapper,
        EmployeeDetailServerMapperForId: EmployeeDetailServerMapperForId

    };
});