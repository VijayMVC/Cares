define(["ko", "underscore", "underscore-ko"], function (ko) {

    var

    // BusinessPartner entity - Using Knockout Mapping
    // ReSharper disable InconsistentNaming
    BusinessPartner = function (data) {
        // ReSharper restore InconsistentNaming
        var // Reference to this object
            self = {};
            // 
        // Map data to self
        ko.mapping.fromJS(data, null, self);

        return {
            businessPartnerListId:self.BusinessPartnerListId,
            businessPartnerListName:self.BusinessPartnerListName,
            businessPartnerName: self.BusinessPartnerName,
            businessPartnerId: self.BusinessPartnerId,
            isIndividual: self.IsIndividual,
            bPRatingType: self.BPRatingTypeName,
            company: self.CompanyName
        };
    };
    
    var
   // Business Partner entity
   // ReSharper disable InconsistentNaming
   BusinessPartnerDetail = function (specifiedKey, specifiedBPName, specifiedDescription, specifiedisIndividual,
   specifiedisSystemGuarantor, specifiednonSystemGuarantor, specifiedbusinessPartnerEmailAddress,
   specifiedbusinessPartnerIsValid, specifiedCompany, specifiedPaymentTerm, specifiedBPRatigType,
   specifiedBusinessLegalStatus, specifiedSystemGuarantor, specifiedDealingEmployee)
   { 
       // ReSharper restore InconsistentNaming
       var // Reference to this object
           self,           
           // Main Top Section 
           // Unique key
           businessPartnerId = ko.observable(specifiedKey),
           // Busiess Partner Name
           businessPartnerName = ko.observable(specifiedBPName),
           // Busiess Partner Description
           businessPartnerDesciption = ko.observable(specifiedDescription),
           // Is individual or company
           isIndividual = ko.observable(specifiedisIndividual).extend({ required: true }),
           // Is System Guarantor
           isSystemGuarantor = ko.observable(specifiedisSystemGuarantor).extend({ required: true }),
           // Non System Guarantor
           nonSystemGuarantor = ko.observable(specifiednonSystemGuarantor),
           // Business Partner Email Address
           businessPartnerEmailAddress = ko.observable(specifiedbusinessPartnerEmailAddress),
           // Company Id
           companyId = ko.observable(specifiedCompany).extend({ required: true }),
           // Payment Term Id
           paymentTermId = ko.observable(specifiedPaymentTerm).extend({ required: true }),
           // Business Partner Rating Type Id
           bPRatingTypeId = ko.observable(specifiedBPRatigType),
           // Business Legal Status Id
           businessLegalStatusId = ko.observable(specifiedBusinessLegalStatus),
           // System Guarantor Id
           systemGuarantorId = ko.observable(specifiedSystemGuarantor),
           // Dealing Employee Id
           dealingEmployeeId = ko.observable(specifiedDealingEmployee),
           
           // Business Partner Individual
           businessPartnerIndividual = ko.observable(BusinessPartnerIndividual.Create()),

           // Is Busy
           isBusy = ko.observable(false),
           // Errors
           errors = ko.validation.group({
               isIndividual: isIndividual,
               isSystemGuarantor: isSystemGuarantor,
               companyId: companyId,
               paymentTermId: paymentTermId
           }),
           // Is Valid
           isValid = ko.computed(function() {
               return errors().length === 0 && businessPartnerIndividual().errors().length === 0;
           }),
           // True if the booking has been changed
           // ReSharper disable InconsistentNaming
           dirtyFlag = new ko.dirtyFlag({
               // ReSharper restore InconsistentNaming

               // Main top section
               businessPartnerId: businessPartnerId,
               businessPartnerName: businessPartnerName,
               businessPartnerDesciption: businessPartnerDesciption,
               isIndividual: isIndividual,
               isSystemGuarantor: isSystemGuarantor,
               nonSystemGuarantor: nonSystemGuarantor,
               businessPartnerEmailAddress: businessPartnerEmailAddress,
               companyId: companyId,
               paymentTermId: paymentTermId,
               bPRatingTypeId: bPRatingTypeId,
               businessLegalStatusId: businessLegalStatusId,
               systemGuarantorId: systemGuarantorId,
               dealingEmployeeId: dealingEmployeeId,
           }),
           // Has Changes
           hasChanges = ko.computed(function() {
               return dirtyFlag.isDirty();
           }),
           // Reset
           reset = function() {
               dirtyFlag.reset();
           };
       self = {
           // Main Top Section
           businessPartnerId: businessPartnerId,
           businessPartnerName: businessPartnerName,
           businessPartnerDesciption: businessPartnerDesciption,
           isIndividual: isIndividual,
           isSystemGuarantor: isSystemGuarantor,
           nonSystemGuarantor: nonSystemGuarantor,
           businessPartnerEmailAddress: businessPartnerEmailAddress,
           companyId: companyId,
           paymentTermId: paymentTermId,
           bPRatingTypeId: bPRatingTypeId,
           businessLegalStatusId: businessLegalStatusId,
           systemGuarantorId: systemGuarantorId,
           dealingEmployeeId: dealingEmployeeId,
              
           businessPartnerIndividual:businessPartnerIndividual,

           errors: errors,
           isValid: isValid,
           dirtyFlag: dirtyFlag,
           hasChanges: hasChanges,
           reset: reset,
           isBusy: isBusy
       };
       return self;
   };

    var
// Business Partner entity
// ReSharper disable InconsistentNaming
BusinessPartnerIndividual = function (
specifiedIndividualFirstName, specifiedIndividualMiddleName, specifiedIndividualLastName,
specifiedIndividualInitials, specifiedIndividualLiscenseNumber, specifiedIndividualLiscenseExpiryDate,
specifiedIndividualGenderStatus, specifiedIndividualPassportNumber, specifiedIndividualNicNumber,
specifiedIndividualMaritalStatusCode, specifiedIndividualTaxRegisterationCode, specifiedIndividualTaxNumber,
specifiedIndividualDateOfBirth, specifiedIndividualOccupationTypeId, specifiedIndividualIsCompanyExternal,
specifiedIndividualCompanyName, specifiedIndividualCompanyAddress, specifiedIndividualCompanyPhone,
specifiedIndividualBusinessPartnerCompnayId, specifiedIndividualNicExpiryDate, specifiedIndividualPassportExpiryDate,
specifiedIndividualPassportCountryId, specifiedIndividualIqamaNo, specifiedIndividualIqamaExpiryDate
    ) {

    // ReSharper restore InconsistentNaming
    var // Reference to this object
        // First tab - Individual Info
        // Individual First Name
        individualFirstName = ko.observable(specifiedIndividualFirstName).extend({ required: true }),
        // Individual Middle Name
        individualMiddleName = ko.observable(specifiedIndividualMiddleName),
         // Individual Last Name
        individualLastName = ko.observable(specifiedIndividualLastName).extend({ required: true }),
         // Individual Initials
        individualInitials = ko.observable(specifiedIndividualInitials),
         // Individual Liscense Number
        individualLiscenseNumber = ko.observable(specifiedIndividualLiscenseNumber),
        // Individual Liscense Expiry Date
        individualLiscenseExpiryDate = ko.observable(specifiedIndividualLiscenseExpiryDate),
        // Individual Gender Status
        individualGenderStatus = ko.observable(specifiedIndividualGenderStatus),
        // Individual Passport Number
        individualPassportNumber = ko.observable(specifiedIndividualPassportNumber),
        // Individual Nic Number
        individualNicNumber = ko.observable(specifiedIndividualNicNumber),
        // Individual Marital Status Code
        individualMaritalStatusCode = ko.observable(specifiedIndividualMaritalStatusCode),
        // Individual Tax Registration Code
        individualTaxRegisterationCode = ko.observable(specifiedIndividualTaxRegisterationCode),
        // Individual Tax Number
        individualTaxNumber = ko.observable(specifiedIndividualTaxNumber),
        // Individual Date Of Birth
        individualDateOfBirth = ko.observable(specifiedIndividualDateOfBirth).extend({ required: true }),
        // Individual Occupation Type Id
        individualOccupationTypeId = ko.observable(specifiedIndividualOccupationTypeId),
        // Individual IsCompanyExternal
        individualIsCompanyExternal = ko.observable(specifiedIndividualIsCompanyExternal),
        // Individual Company Name
        individualCompanyName = ko.observable(specifiedIndividualCompanyName),
        // Individual Company Address
        individualCompanyAddress = ko.observable(specifiedIndividualCompanyAddress),
        // Individual Company Phone
        individualCompanyPhone = ko.observable(specifiedIndividualCompanyPhone),
        // Individual Business Partner Compnay Id
        individualBusinessPartnerCompnayId = ko.observable(specifiedIndividualBusinessPartnerCompnayId),
        // Individual Nic Expiry Date
        individualNicExpiryDate = ko.observable(specifiedIndividualNicExpiryDate),
        // Individual Passport Expiry Date
        individualPassportExpiryDate = ko.observable(specifiedIndividualPassportExpiryDate),
         // Individual Passport Country Id
        individualPassportCountryId = ko.observable(specifiedIndividualPassportCountryId),
        // Individual Iqama No
        individualIqamaNo = ko.observable(specifiedIndividualIqamaNo),
         // Individual Iqama Expiry Date
        individualIqamaExpiryDate = ko.observable(specifiedIndividualIqamaExpiryDate),
        
        // Is Busy
        isBusy = ko.observable(false),
        // Errors
        errors = ko.validation.group({
            individualFirstName: individualFirstName,
            individualLastName: individualLastName,
            individualDateOfBirth: individualDateOfBirth
        }),
        // Is Valid
        isValid = ko.computed(function () {
            return errors().length === 0;
        }),
        // True if the booking has been changed
        // ReSharper disable InconsistentNaming
        dirtyFlag = new ko.dirtyFlag({
            // ReSharper restore InconsistentNaming

            // First Tab Controls
            individualFirstName: individualFirstName,
            individualMiddleName: individualMiddleName,
            individualLastName: individualLastName,
            individualInitials: individualInitials,
            individualLiscenseNumber: individualLiscenseNumber,
            individualLiscenseExpiryDate: individualLiscenseExpiryDate,
            individualGenderStatus: individualGenderStatus,
            individualPassportNumber: individualPassportNumber,
            individualNicNumber: individualNicNumber,
            individualMaritalStatusCode: individualMaritalStatusCode,
            individualTaxRegisterationCode: individualTaxRegisterationCode,
            individualTaxNumber: individualTaxNumber,
            individualDateOfBirth: individualDateOfBirth,
            individualOccupationTypeId: individualOccupationTypeId,
            individualIsCompanyExternal: individualIsCompanyExternal,
            individualCompanyName: individualCompanyName,
            individualCompanyAddress: individualCompanyAddress,
            individualCompanyPhone: individualCompanyPhone,
            individualBusinessPartnerCompnayId: individualBusinessPartnerCompnayId,
            individualNicExpiryDate: individualNicExpiryDate,
            individualPassportExpiryDate: individualPassportExpiryDate,
            individualPassportCountryId: individualPassportCountryId,
            individualIqamaNo: individualIqamaNo,
            individualIqamaExpiryDate: individualIqamaExpiryDate

        }),
        // Has Changes
        hasChanges = ko.computed(function () {
            return dirtyFlag.isDirty();
        }),
        // Reset
        reset = function () {
            dirtyFlag.reset();
        };
    return {
   
        // First Tab Controls
        individualFirstName: individualFirstName,
        individualMiddleName: individualMiddleName,
        individualLastName: individualLastName,
        individualInitials: individualInitials,
        individualLiscenseNumber: individualLiscenseNumber,
        individualLiscenseExpiryDate: individualLiscenseExpiryDate,
        individualGenderStatus: individualGenderStatus,
        individualPassportNumber: individualPassportNumber,
        individualNicNumber: individualNicNumber,
        individualMaritalStatusCode: individualMaritalStatusCode,
        individualTaxRegisterationCode: individualTaxRegisterationCode,
        individualTaxNumber: individualTaxNumber,
        individualDateOfBirth: individualDateOfBirth,
        individualOccupationTypeId: individualOccupationTypeId,
        individualIsCompanyExternal: individualIsCompanyExternal,
        individualCompanyName: individualCompanyName,
        individualCompanyAddress: individualCompanyAddress,
        individualCompanyPhone: individualCompanyPhone,
        individualBusinessPartnerCompnayId: individualBusinessPartnerCompnayId,
        individualNicExpiryDate: individualNicExpiryDate,
        individualPassportExpiryDate: individualPassportExpiryDate,
        individualPassportCountryId: individualPassportCountryId,
        individualIqamaNo: individualIqamaNo,
        individualIqamaExpiryDate: individualIqamaExpiryDate,

        errors: errors,
        isValid: isValid,
        dirtyFlag: dirtyFlag,
        hasChanges: hasChanges,
        reset: reset,
        isBusy: isBusy
    };
};


    // BusinessPartnerDetail Factory
    BusinessPartnerDetail.Create = function () {
        return new BusinessPartnerDetail("", "", "", false, false, "", "", false, undefined, undefined, undefined, undefined, undefined);
    };
    
    // BusinessPartnerDetail Factory
    BusinessPartnerIndividual.Create = function () {
        return new BusinessPartnerIndividual("", "", "", "", "", moment().toDate(), "", "", "", "", "", "", moment().toDate(), undefined,false, "", "", ""
            , undefined, moment().toDate(), moment().toDate(), undefined,
            "", moment().toDate());
    };
    
    // Convert Client to server
    var BusinessPartnerServerMapper = function(clientData) {
        var result = {};

        // Main top section
        result.BusinessPartnerId = clientData.businessPartnerId();
        result.BusinessPartnerName = clientData.businessPartnerName();
        result.BusinessPartnerDesciption = clientData.businessPartnerDesciption();
        result.IsIndividual = clientData.isIndividual();
        result.IsSystemGuarantor = clientData.isSystemGuarantor();
        result.NonSystemGuarantor = clientData.nonSystemGuarantor();
        result.BusinessPartnerEmailAddress = clientData.businessPartnerEmailAddress();
        result.CompanyId = clientData.companyId();
        result.PaymentTermId = clientData.paymentTermId();
        result.BPRatingTypeId = clientData.bPRatingTypeId();
        result.BusinessLegalStatusId = clientData.businessLegalStatusId();
        result.SystemGuarantorId = clientData.systemGuarantorId();
        result.DealingEmployeeId = clientData.dealingEmployeeId();
        
        // convert chlid object data 
        // from client to server
        result.BusinessPartnerIndividual = BusinessPartnerIndividualServerMapper(clientData);

        return result;
    };

    // Convert Client to server
    var BusinessPartnerIndividualServerMapper = function (clientData) {
        var result = {};

        // First  tab : Individual Info
        result.businessPartnerId = clientData.businessPartnerId() === undefined ? undefined : clientData.businessPartnerId();
        result.FirstName = clientData.businessPartnerIndividual().individualFirstName();
        result.MiddleName = clientData.businessPartnerIndividual().individualMiddleName();
        result.LastName = clientData.businessPartnerIndividual().individualLastName();
        result.Initials = clientData.businessPartnerIndividual().individualInitials();
        result.LiscenseNumber = clientData.businessPartnerIndividual().individualLiscenseNumber();
        result.LiscenseExpiryDate = clientData.businessPartnerIndividual().individualLiscenseExpiryDate() === undefined ? undefined : moment(clientData.businessPartnerIndividual().individualLiscenseExpiryDate()).format(ist.utcFormat);
        result.GenderStatus = clientData.businessPartnerIndividual().individualGenderStatus();
        result.PassportNumber = clientData.businessPartnerIndividual().individualPassportNumber();
        result.NicNumber = clientData.businessPartnerIndividual().individualNicNumber();
        result.MaritalStatusCode = clientData.businessPartnerIndividual().individualMaritalStatusCode();
        result.TaxRegisterationCode = clientData.businessPartnerIndividual().individualTaxRegisterationCode();
        result.TaxNumber = clientData.businessPartnerIndividual().individualTaxNumber();
        result.DateOfBirth = clientData.businessPartnerIndividual().individualDateOfBirth() === undefined ? undefined : moment(clientData.businessPartnerIndividual().individualDateOfBirth()).format(ist.utcFormat);
        result.OccupationTypeId = clientData.businessPartnerIndividual().individualOccupationTypeId();
        result.IsCompanyExternal = clientData.businessPartnerIndividual().individualIsCompanyExternal();
        result.CompanyName = clientData.businessPartnerIndividual().individualCompanyName();
        result.CompanyAddress = clientData.businessPartnerIndividual().individualCompanyAddress();
        result.CompanyPhone = clientData.businessPartnerIndividual().individualCompanyPhone();
        result.BusinessPartnerCompnayId = clientData.businessPartnerIndividual().individualBusinessPartnerCompnayId();
        result.NicExpiryDate = clientData.businessPartnerIndividual().individualNicExpiryDate() === undefined ? undefined : moment(clientData.businessPartnerIndividual().individualNicExpiryDate()).format(ist.utcFormat);
        result.PassportExpiryDate = clientData.businessPartnerIndividual().individualPassportExpiryDate() === undefined ? undefined : moment(clientData.businessPartnerIndividual().individualPassportExpiryDate()).format(ist.utcFormat);
        result.PassportCountryId = clientData.businessPartnerIndividual().individualPassportCountryId();
        result.IqamaNo = clientData.businessPartnerIndividual().individualIqamaNo();
        result.IqamaExpiryDate = clientData.businessPartnerIndividual().individualIqamaExpiryDate() === undefined ? undefined : moment(clientData.businessPartnerIndividual().individualIqamaExpiryDate()).format(ist.utcFormat);

        return result;
    };


    // Convert Server to Client
    var BusinessPartnerClientMapper = function (serverData) {
        
        var businessPartner = new BusinessPartnerDetail();
        
        // Main Top Section
        businessPartner.businessPartnerId(serverData.BusinessPartnerId === null ? undefined : serverData.BusinessPartnerId);
        businessPartner.businessPartnerName(serverData.BusinessPartnerName === null ? undefined : serverData.BusinessPartnerName);
        businessPartner.businessPartnerDesciption(serverData.BusinessPartnerDesciption === null ? undefined : serverData.BusinessPartnerDesciption);
        businessPartner.isIndividual(serverData.IsIndividual === null ? undefined : serverData.IsIndividual);
        businessPartner.isSystemGuarantor(serverData.IsSystemGuarantor === null ? undefined : serverData.IsSystemGuarantor);
        businessPartner.nonSystemGuarantor(serverData.NonSystemGuarantor === null ? undefined : serverData.NonSystemGuarantor);
        businessPartner.businessPartnerEmailAddress(serverData.BusinessPartnerEmailAddress === null ? undefined : serverData.BusinessPartnerEmailAddress);
        businessPartner.companyId(serverData.CompanyId === null ? undefined : serverData.CompanyId);
        businessPartner.paymentTermId(serverData.PaymentTermId === null ? undefined : serverData.PaymentTermId);
        businessPartner.bPRatingTypeId(serverData.BPRatingTypeId === null ? undefined : serverData.BPRatingTypeId);
        businessPartner.businessLegalStatusId(serverData.BusinessLegalStatusId === null ? undefined : serverData.BusinessLegalStatusId);
        businessPartner.systemGuarantorId(serverData.SystemGuarantorId === null ? undefined : serverData.SystemGuarantorId);
        businessPartner.dealingEmployeeId(serverData.DealingEmployeeId === null ? undefined : serverData.DealingEmployeeId);

        // First tab : Individual
        businessPartner.businessPartnerIndividual(BusinessPartnerIndividualClientMapper(serverData));
        
        return businessPartner;
    };

    // Convert Server to Client
    var BusinessPartnerIndividualClientMapper = function (serverData) {

        if (serverData.BusinessPartnerIndividual != null || serverData.BusinessPartnerIndividual != undefined) {

            var businessPartnerIndividual = new BusinessPartnerIndividual();

            // First Tab : Individual
            businessPartnerIndividual.individualFirstName(serverData.BusinessPartnerIndividual.FirstName === null ? undefined : serverData.BusinessPartnerIndividual.FirstName);
            businessPartnerIndividual.individualMiddleName(serverData.BusinessPartnerIndividual.MiddleName === null ? undefined : serverData.BusinessPartnerIndividual.MiddleName);
            businessPartnerIndividual.individualLastName(serverData.BusinessPartnerIndividual.LastName === null ? undefined : serverData.BusinessPartnerIndividual.LastName);
            businessPartnerIndividual.individualInitials(serverData.BusinessPartnerIndividual.Initials === null ? undefined : serverData.BusinessPartnerIndividual.Initials);
            businessPartnerIndividual.individualLiscenseNumber(serverData.BusinessPartnerIndividual.LiscenseNumber === null ? undefined : serverData.BusinessPartnerIndividual.LiscenseNumber);
            businessPartnerIndividual.individualLiscenseExpiryDate(serverData.BusinessPartnerIndividual.LiscenseExpiryDate === null ? undefined : serverData.BusinessPartnerIndividual.LiscenseExpiryDate);
            businessPartnerIndividual.individualGenderStatus(serverData.BusinessPartnerIndividual.GenderStatus === null ? undefined : serverData.BusinessPartnerIndividual.GenderStatus);
            businessPartnerIndividual.individualPassportNumber(serverData.BusinessPartnerIndividual.PassportNumber === null ? undefined : serverData.BusinessPartnerIndividual.PassportNumber);
            businessPartnerIndividual.individualNicNumber(serverData.BusinessPartnerIndividual.NicNumber === null ? undefined : serverData.BusinessPartnerIndividual.NicNumber);
            businessPartnerIndividual.individualMaritalStatusCode(serverData.BusinessPartnerIndividual.MaritalStatusCode === null ? undefined : serverData.BusinessPartnerIndividual.MaritalStatusCode);
            businessPartnerIndividual.individualTaxRegisterationCode(serverData.BusinessPartnerIndividual.TaxRegisterationCode === null ? undefined : serverData.BusinessPartnerIndividual.TaxRegisterationCode);
            businessPartnerIndividual.individualTaxNumber(serverData.BusinessPartnerIndividual.TaxNumber === null ? undefined : serverData.BusinessPartnerIndividual.TaxNumber);
            businessPartnerIndividual.individualDateOfBirth(serverData.BusinessPartnerIndividual.DateOfBirth === null ? undefined : serverData.BusinessPartnerIndividual.DateOfBirth);
            businessPartnerIndividual.individualOccupationTypeId(serverData.BusinessPartnerIndividual.OccupationTypeId === null ? undefined : serverData.BusinessPartnerIndividual.OccupationTypeId);
            businessPartnerIndividual.individualIsCompanyExternal(serverData.BusinessPartnerIndividual.IsCompanyExternal === null ? undefined : serverData.BusinessPartnerIndividual.IsCompanyExternal);
            businessPartnerIndividual.individualCompanyName(serverData.BusinessPartnerIndividual.CompanyName === null ? undefined : serverData.BusinessPartnerIndividual.CompanyName);
            businessPartnerIndividual.individualCompanyAddress(serverData.BusinessPartnerIndividual.CompanyAddress === null ? undefined : serverData.BusinessPartnerIndividual.CompanyAddress);
            businessPartnerIndividual.individualCompanyPhone(serverData.BusinessPartnerIndividual.CompanyPhone === null ? undefined : serverData.BusinessPartnerIndividual.CompanyPhone);
            businessPartnerIndividual.individualBusinessPartnerCompnayId(serverData.BusinessPartnerIndividual.BusinessPartnerCompnayId === null ? undefined : serverData.BusinessPartnerIndividual.BusinessPartnerCompnayId);
            businessPartnerIndividual.individualNicExpiryDate(serverData.BusinessPartnerIndividual.NicExpiryDate === null ? undefined : serverData.BusinessPartnerIndividual.NicExpiryDate);
            businessPartnerIndividual.individualPassportExpiryDate(serverData.BusinessPartnerIndividual.PassportExpiryDate === null ? undefined : serverData.BusinessPartnerIndividual.PassportExpiryDate);
            businessPartnerIndividual.individualPassportCountryId(serverData.BusinessPartnerIndividual.PassportCountryId === null ? undefined : serverData.BusinessPartnerIndividual.PassportCountryId);
            businessPartnerIndividual.individualIqamaNo(serverData.BusinessPartnerIndividual.IqamaNo === null ? undefined : serverData.BusinessPartnerIndividual.IqamaNo);
            businessPartnerIndividual.individualIqamaExpiryDate(serverData.BusinessPartnerIndividual.IqamaExpiryDate === null ? undefined : serverData.BusinessPartnerIndividual.IqamaExpiryDate);

            return businessPartnerIndividual;
        } else {
            return undefined;
        }
    };

    return {
        BusinessPartner: BusinessPartner,
        BusinessPartnerDetail: BusinessPartnerDetail,
        BusinessPartnerClientMapper: BusinessPartnerClientMapper,
        BusinessPartnerServerMapper: BusinessPartnerServerMapper,
        BusinessPartnerIndividualServerMapper: BusinessPartnerIndividualServerMapper,
        BusinessPartnerIndividual: BusinessPartnerIndividual,
        BusinessPartnerIndividualClientMapper:BusinessPartnerIndividualClientMapper
    };
});