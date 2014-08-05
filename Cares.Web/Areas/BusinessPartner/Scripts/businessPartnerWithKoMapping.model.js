/*
    Client Models and Mappers for Business Partner and its child tabs
*/
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
           // Business Partner Company
           businessPartnerCompany = ko.observable(BusinessPartnerCompany.Create()),
           // Business Partner InTypes
           businessPartnerInTypes = ko.observableArray([]),
           // New Business Partner InType
           businessPartnerInTypeNew = ko.observable(BusinessPartnerInType.Create()),
            // Business Partner PhoneNumbers
           businessPartnerPhoneNumbers = ko.observableArray([]),
           // New Business Partner Phone Number
           businessPartnerPhoneNumberNew = ko.observable(BusinessPartnerPhone.Create()),
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
               return errors().length === 0
                   && businessPartnerIndividual().errors().length === 0
                   && businessPartnerCompany().errors().length === 0;
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
               businessPartnerIndividual: businessPartnerIndividual,
               businessPartnerCompany: businessPartnerCompany,
               businessPartnerInTypes: businessPartnerInTypes,
               businessPartnerPhoneNumbers:businessPartnerPhoneNumbers
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
           businessPartnerIndividual: businessPartnerIndividual,
           businessPartnerCompany:businessPartnerCompany,
           businessPartnerInTypes:businessPartnerInTypes,
           businessPartnerInTypeNew: businessPartnerInTypeNew,
           businessPartnerPhoneNumbers: businessPartnerPhoneNumbers,
           businessPartnerPhoneNumberNew:businessPartnerPhoneNumberNew,
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
    // Business Partner Individual entity
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
    var
  // Business Partner Company entity
  // ReSharper disable InconsistentNaming
    BusinessPartnerCompany = function (specifiedBusinessPartnerCompanyCode, specifiedBusinessPartnerCompanyName,
    specifiedEstablishedSince, specifiedSwiftCode, specifiedisAccountNumber, specifiedBusinessSegmentId) {
      // ReSharper restore InconsistentNaming
      var // Reference to this object
          self,
          // Main Top Section 
          // Business Partner Company Code
          businessPartnerCompanyCode = ko.observable(specifiedBusinessPartnerCompanyCode).extend({ required: true }),
          // Busiess Partner Company Name
          businessPartnerCompanyName = ko.observable(specifiedBusinessPartnerCompanyName),
          // Established Since
          businessPartnerCompanyEstablishedSince = ko.observable(specifiedEstablishedSince),
          // Swift Code
          businessPartnerCompanySwiftCode = ko.observable(specifiedSwiftCode),
          // Account Number
          businessPartnerCompanyAccountNumber = ko.observable(specifiedisAccountNumber),
          // Non System Guarantor
          businessPartnerCompanyBusinessSegmentId = ko.observable(specifiedBusinessSegmentId),     
          // Is Busy
          isBusy = ko.observable(false),
          // Errors
          errors = ko.validation.group({
              businessPartnerCompanyCode: businessPartnerCompanyCode
          }),
          // Is Valid
          isValid = ko.computed(function () {
              return errors().length === 0;
          }),
          // True if the booking has been changed
          // ReSharper disable InconsistentNaming
          dirtyFlag = new ko.dirtyFlag({
              // ReSharper restore InconsistentNaming
              businessPartnerCompanyCode: businessPartnerCompanyCode,
              businessPartnerCompanyName: businessPartnerCompanyName,
              businessPartnerCompanyEstablishedSince: businessPartnerCompanyEstablishedSince,
              businessPartnerCompanySwiftCode: businessPartnerCompanySwiftCode,
              businessPartnerCompanyAccountNumber: businessPartnerCompanyAccountNumber,
              businessPartnerCompanyBusinessSegmentId: businessPartnerCompanyBusinessSegmentId
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
          businessPartnerCompanyCode: businessPartnerCompanyCode,
          businessPartnerCompanyName: businessPartnerCompanyName,
          businessPartnerCompanyEstablishedSince: businessPartnerCompanyEstablishedSince,
          businessPartnerCompanySwiftCode: businessPartnerCompanySwiftCode,
          businessPartnerCompanyAccountNumber: businessPartnerCompanyAccountNumber,
          businessPartnerCompanyBusinessSegmentId: businessPartnerCompanyBusinessSegmentId,
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
 // Business Partner Phone entity
 // ReSharper disable InconsistentNaming
    BusinessPartnerPhone = function (specifiedPhoneId, specifiedIsDefault,
    specifiedPhoneNumber, specifiedbusinessPartnerId, specifiedPhoneTypeId, specifiedPhoneTypeName) {
     // ReSharper restore InconsistentNaming
     var // Reference to this object
         self,
         // Main Top Section 
         // Phone Id
         phoneId = ko.observable(specifiedPhoneId),
         // Is Default
         isDefault = ko.observable(specifiedIsDefault),
         // Phone Number
         phoneNumber = ko.observable(specifiedPhoneNumber).extend({ required: true }),
         // Business Partner Id
         businessPartnerId = ko.observable(specifiedbusinessPartnerId),
         // Phone Type Id
         phoneTypeId = ko.observable(specifiedPhoneTypeId).extend({ required: true }),
          // Phone Type Name
         phoneTypeName = ko.observable(specifiedPhoneTypeName),
         // Is Busy
         isBusy = ko.observable(false),
         // Errors
         errors = ko.validation.group({
             phoneTypeId: phoneTypeId,
             phoneNumber:phoneNumber
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
             businessPartnerId: businessPartnerId
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
         phoneTypeName:phoneTypeName,
         businessPartnerId: businessPartnerId,
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
    // Business Partner InType entity
    // ReSharper disable InconsistentNaming
    BusinessPartnerInType = function (specifiedBusinessPartnerInTypeId, specifiedBusinessPartnerInTypeDescription,
    specifiedfromDate, specifiedtoDate, specifiedbusinessPartnerId, specifiedbusinessPartnerSubTypeId, specifiedbusinessPartnerSubTypeName,
    specifiedbpRatingTypeId, specifiedbpRatingTypeName) {
    // ReSharper restore InconsistentNaming
    var // Reference to this object
        self,
        // Main Top Section 
        // Business Partner In Type Id
        businessPartnerInTypeId = ko.observable(specifiedBusinessPartnerInTypeId),
        // Busiess Partner In Type Description
        businessPartnerInTypeDescription = ko.observable(specifiedBusinessPartnerInTypeDescription),
        // Business Partner In Type From Date
        fromDate = ko.observable(specifiedfromDate),
        // Business Partner In Type To Date 
        toDate = ko.observable(specifiedtoDate),
        // Business Partner Id
        businessPartnerId = ko.observable(specifiedbusinessPartnerId),
        // Business Partner Sub Type Id
        businessPartnerSubTypeId = ko.observable(specifiedbusinessPartnerSubTypeId).extend({ required: true }),
         // Business Partner Sub Type Name
        businessPartnerSubTypeName = ko.observable(specifiedbusinessPartnerSubTypeName),
        // Business Partner Rating Type Id
        bpRatingTypeId = ko.observable(specifiedbpRatingTypeId),
          // Business Partner Rating Type Name
        bpRatingTypeName = ko.observable(specifiedbpRatingTypeName),
        // Is Busy
        isBusy = ko.observable(false),
        // Errors
        errors = ko.validation.group({
            businessPartnerSubTypeId: businessPartnerSubTypeId
        }),
        // Is Valid
        isValid = ko.computed(function () {
            return errors().length === 0;
        }),
        // True if the booking has been changed
        // ReSharper disable InconsistentNaming
        dirtyFlag = new ko.dirtyFlag({
            // ReSharper restore InconsistentNaming
            businessPartnerInTypeId: businessPartnerInTypeId,
            businessPartnerInTypeDescription: businessPartnerInTypeDescription,
            fromDate: fromDate,
            toDate: toDate,
            businessPartnerId: businessPartnerId,
            businessPartnerSubTypeId: businessPartnerSubTypeId,
            bpRatingTypeId: bpRatingTypeId
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
        businessPartnerInTypeId: businessPartnerInTypeId,
        businessPartnerInTypeDescription: businessPartnerInTypeDescription,
        fromDate: fromDate,
        toDate: toDate,
        businessPartnerId: businessPartnerId,
        businessPartnerSubTypeId: businessPartnerSubTypeId,
        businessPartnerSubTypeName: businessPartnerSubTypeName,
        bpRatingTypeId: bpRatingTypeId,
        bpRatingTypeName: bpRatingTypeName,
        errors: errors,
        isValid: isValid,
        dirtyFlag: dirtyFlag,
        hasChanges: hasChanges,
        reset: reset,
        isBusy: isBusy
    };
    return self;
};
    // BusinessPartnerDetail Factory
    BusinessPartnerDetail.Create = function () {
        return new BusinessPartnerDetail("", "", "", false, false, "", "", false, undefined, undefined, undefined, undefined, undefined);
    };
    // BusinessPartnerIndividual Factory
    BusinessPartnerIndividual.Create = function() {
        return new BusinessPartnerIndividual("", "", "", "", "", undefined, "", "", "", "", "", "", undefined, undefined, false, "", "", "", undefined, undefined, undefined, undefined,
            "", undefined);
    };
    // BusinessPartnerCompany Factory
    BusinessPartnerCompany.Create = function() {
        return new BusinessPartnerCompany("", "", undefined, "", "", undefined);
    };
    // BusinessPartnerInType Factory
    BusinessPartnerInType.Create = function () {
        return new BusinessPartnerInType(undefined, "", undefined, undefined, undefined, undefined, "", undefined, "");
    };
    BusinessPartnerPhone.Create = function() {
        return new BusinessPartnerPhone(undefined, undefined, undefined, undefined, undefined,undefined);
    };
    // Convert (Business Partner) Client to server
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
        // individual tab
        // from client to server
        result.BusinessPartnerIndividual = BusinessPartnerIndividualServerMapper(clientData);
        // company tab
        // from client to server
        result.BusinessPartnerCompany = BusinessPartnerCompanyServerMapper(clientData);
        // businesspartner type tab
        // from client to server
        result.BusinessPartnerInTypes = [];
        _.each(clientData.businessPartnerInTypes(), function (item) {
            result.BusinessPartnerInTypes.push(BusinessPartnerInTypeServerMapper(item));
        });
        return result;
    };
    // Convert (Business Partner Individual) Client to server
    var BusinessPartnerIndividualServerMapper = function (clientData) {
        var result = {};
        // First  tab : Individual Info
        result.businessPartnerId = clientData.businessPartnerId() === undefined ? undefined : clientData.businessPartnerId();
        result.FirstName = clientData.businessPartnerIndividual().individualFirstName();
        result.MiddleName = clientData.businessPartnerIndividual().individualMiddleName();
        result.LastName = clientData.businessPartnerIndividual().individualLastName();
        result.Initials = clientData.businessPartnerIndividual().individualInitials();
        result.LiscenseNumber = clientData.businessPartnerIndividual().individualLiscenseNumber();
        result.LiscenseExpiryDate = clientData.businessPartnerIndividual().individualLiscenseExpiryDate() === undefined ? undefined : moment(clientData.businessPartnerIndividual().individualLiscenseExpiryDate()).format(ist.utcFormat) + "Z";
        result.GenderStatus = clientData.businessPartnerIndividual().individualGenderStatus();
        result.PassportNumber = clientData.businessPartnerIndividual().individualPassportNumber();
        result.NicNumber = clientData.businessPartnerIndividual().individualNicNumber();
        result.MaritalStatusCode = clientData.businessPartnerIndividual().individualMaritalStatusCode();
        result.TaxRegisterationCode = clientData.businessPartnerIndividual().individualTaxRegisterationCode();
        result.TaxNumber = clientData.businessPartnerIndividual().individualTaxNumber();
        result.DateOfBirth = clientData.businessPartnerIndividual().individualDateOfBirth() === undefined ? undefined : moment(clientData.businessPartnerIndividual().individualDateOfBirth()).format(ist.utcFormat) + "Z";
        result.OccupationTypeId = clientData.businessPartnerIndividual().individualOccupationTypeId();
        result.IsCompanyExternal = clientData.businessPartnerIndividual().individualIsCompanyExternal();
        result.CompanyName = clientData.businessPartnerIndividual().individualCompanyName();
        result.CompanyAddress = clientData.businessPartnerIndividual().individualCompanyAddress();
        result.CompanyPhone = clientData.businessPartnerIndividual().individualCompanyPhone();
        result.BusinessPartnerCompnayId = clientData.businessPartnerIndividual().individualBusinessPartnerCompnayId();
        result.NicExpiryDate = clientData.businessPartnerIndividual().individualNicExpiryDate() === undefined ? undefined : moment(clientData.businessPartnerIndividual().individualNicExpiryDate()).format(ist.utcFormat) + "Z";
        result.PassportExpiryDate = clientData.businessPartnerIndividual().individualPassportExpiryDate() === undefined ? undefined : moment(clientData.businessPartnerIndividual().individualPassportExpiryDate()).format(ist.utcFormat) + "Z";
        result.PassportCountryId = clientData.businessPartnerIndividual().individualPassportCountryId();
        result.IqamaNo = clientData.businessPartnerIndividual().individualIqamaNo();
        result.IqamaExpiryDate = clientData.businessPartnerIndividual().individualIqamaExpiryDate() === undefined ? undefined : moment(clientData.businessPartnerIndividual().individualIqamaExpiryDate()).format(ist.utcFormat) + "Z";
        return result;
    };
    // Convert (Business Partner Company) Client to server
    var BusinessPartnerCompanyServerMapper = function (clientData) {
        var result = {};
        // Second  tab : Company Info
        result.BusinessPartnerId = clientData.businessPartnerId() === undefined ? undefined : clientData.businessPartnerId();
        result.BusinessPartnerCompanyCode = clientData.businessPartnerCompany().businessPartnerCompanyCode();
        result.BusinessPartnerCompanyName = clientData.businessPartnerCompany().businessPartnerCompanyName();
        result.EstablishedSince = clientData.businessPartnerCompany().businessPartnerCompanyEstablishedSince() === undefined ? undefined : moment(clientData.businessPartnerCompany().businessPartnerCompanyEstablishedSince()).format(ist.utcFormat) + "Z";
        result.SwiftCode = clientData.businessPartnerCompany().businessPartnerCompanySwiftCode();
        result.AccountNumber = clientData.businessPartnerCompany().businessPartnerCompanyAccountNumber();
        result.BusinessSegmentId = clientData.businessPartnerCompany().businessPartnerCompanyBusinessSegmentId() === undefined ? undefined : clientData.businessPartnerCompany().businessPartnerCompanyBusinessSegmentId();
        return result;
    };
    // Convert (BusinessPartner InType ) Client to Server
    var BusinessPartnerInTypeServerMapper = function (item) {
        var result = {};
        // Third Tab : Business Partner In Type
        result.BusinessPartnerInTypeId = item.businessPartnerInTypeId() === undefined ? undefined : item.businessPartnerInTypeId();
        result.BusinessPartnerInTypeDescription = item.businessPartnerInTypeDescription() === undefined ? undefined : item.businessPartnerInTypeDescription();
        result.FromDate = item.fromDate() === undefined ? undefined : moment(item.fromDate()).format(ist.utcFormat) + "Z";
        result.ToDate = item.toDate() === undefined ? undefined : moment(item.toDate()).format(ist.utcFormat) + "Z";
        result.BusinessPartnerId = item.businessPartnerId() === undefined ? undefined : item.businessPartnerId();
        result.BusinessPartnerSubTypeId = item.businessPartnerSubTypeId() === undefined ? undefined : item.businessPartnerSubTypeId();
        result.BusinessPartnerSubTypeName = item.businessPartnerSubTypeName() === undefined ? undefined : item.businessPartnerSubTypeName();
        result.BpRatingTypeId = item.bpRatingTypeId() === undefined ? undefined : item.bpRatingTypeId();
        result.BpRatingTypeName = item.bpRatingTypeName() === undefined ? undefined : item.bpRatingTypeName();
        return result;
    };

    // Convert (Business Partner) Server to Client
    var BusinessPartnerClientMapper = function(serverData) {
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
        // First tab : Individual Info
        businessPartner.businessPartnerIndividual(BusinessPartnerIndividualClientMapper(serverData));
        // Second tab : Company Info
        businessPartner.businessPartnerCompany(BusinessPartnerCompanyClientMapper(serverData));
        // third tab : BusinessPartner InTypes
         _.each(serverData.BusinessPartnerInTypes, function (item) {
            businessPartner.businessPartnerInTypes.push(BusinessPartnerInTypeClientMapper(item));
        });
        return businessPartner;
    };
    // Convert (Business Partner Individual) Server to Client
    var BusinessPartnerIndividualClientMapper = function (serverData) {
        if (serverData.BusinessPartnerIndividual != null || serverData.BusinessPartnerIndividual != undefined) {
            var businessPartnerIndividual = new BusinessPartnerIndividual();
            // First Tab : Individual
            businessPartnerIndividual.individualFirstName(serverData.BusinessPartnerIndividual.FirstName === null ? undefined : serverData.BusinessPartnerIndividual.FirstName);
            businessPartnerIndividual.individualMiddleName(serverData.BusinessPartnerIndividual.MiddleName === null ? undefined : serverData.BusinessPartnerIndividual.MiddleName);
            businessPartnerIndividual.individualLastName(serverData.BusinessPartnerIndividual.LastName === null ? undefined : serverData.BusinessPartnerIndividual.LastName);
            businessPartnerIndividual.individualInitials(serverData.BusinessPartnerIndividual.Initials === null ? undefined : serverData.BusinessPartnerIndividual.Initials);
            businessPartnerIndividual.individualLiscenseNumber(serverData.BusinessPartnerIndividual.LiscenseNumber === null ? undefined : serverData.BusinessPartnerIndividual.LiscenseNumber);
            businessPartnerIndividual.individualLiscenseExpiryDate(serverData.BusinessPartnerIndividual.LiscenseExpiryDate === null ? undefined : moment(serverData.BusinessPartnerIndividual.LiscenseExpiryDate).toDate());
            businessPartnerIndividual.individualGenderStatus(serverData.BusinessPartnerIndividual.GenderStatus === null ? undefined : serverData.BusinessPartnerIndividual.GenderStatus);
            businessPartnerIndividual.individualPassportNumber(serverData.BusinessPartnerIndividual.PassportNumber === null ? undefined : serverData.BusinessPartnerIndividual.PassportNumber);
            businessPartnerIndividual.individualNicNumber(serverData.BusinessPartnerIndividual.NicNumber === null ? undefined : serverData.BusinessPartnerIndividual.NicNumber);
            businessPartnerIndividual.individualMaritalStatusCode(serverData.BusinessPartnerIndividual.MaritalStatusCode === null ? undefined : serverData.BusinessPartnerIndividual.MaritalStatusCode);
            businessPartnerIndividual.individualTaxRegisterationCode(serverData.BusinessPartnerIndividual.TaxRegisterationCode === null ? undefined : serverData.BusinessPartnerIndividual.TaxRegisterationCode);
            businessPartnerIndividual.individualTaxNumber(serverData.BusinessPartnerIndividual.TaxNumber === null ? undefined : serverData.BusinessPartnerIndividual.TaxNumber);
            businessPartnerIndividual.individualDateOfBirth(serverData.BusinessPartnerIndividual.DateOfBirth === null ? undefined : moment(serverData.BusinessPartnerIndividual.DateOfBirth).toDate());
            businessPartnerIndividual.individualOccupationTypeId(serverData.BusinessPartnerIndividual.OccupationTypeId === null ? undefined : serverData.BusinessPartnerIndividual.OccupationTypeId);
            businessPartnerIndividual.individualIsCompanyExternal(serverData.BusinessPartnerIndividual.IsCompanyExternal === null ? undefined : serverData.BusinessPartnerIndividual.IsCompanyExternal);
            businessPartnerIndividual.individualCompanyName(serverData.BusinessPartnerIndividual.CompanyName === null ? undefined : serverData.BusinessPartnerIndividual.CompanyName);
            businessPartnerIndividual.individualCompanyAddress(serverData.BusinessPartnerIndividual.CompanyAddress === null ? undefined : serverData.BusinessPartnerIndividual.CompanyAddress);
            businessPartnerIndividual.individualCompanyPhone(serverData.BusinessPartnerIndividual.CompanyPhone === null ? undefined : serverData.BusinessPartnerIndividual.CompanyPhone);
            businessPartnerIndividual.individualBusinessPartnerCompnayId(serverData.BusinessPartnerIndividual.BusinessPartnerCompnayId === null ? undefined : serverData.BusinessPartnerIndividual.BusinessPartnerCompnayId);
            businessPartnerIndividual.individualNicExpiryDate(serverData.BusinessPartnerIndividual.NicExpiryDate === null ? undefined : moment(serverData.BusinessPartnerIndividual.NicExpiryDate).toDate());
            businessPartnerIndividual.individualPassportExpiryDate(serverData.BusinessPartnerIndividual.PassportExpiryDate === null ? undefined : moment(serverData.BusinessPartnerIndividual.PassportExpiryDate).toDate());
            businessPartnerIndividual.individualPassportCountryId(serverData.BusinessPartnerIndividual.PassportCountryId === null ? undefined : serverData.BusinessPartnerIndividual.PassportCountryId);
            businessPartnerIndividual.individualIqamaNo(serverData.BusinessPartnerIndividual.IqamaNo === null ? undefined : serverData.BusinessPartnerIndividual.IqamaNo);
            businessPartnerIndividual.individualIqamaExpiryDate(serverData.BusinessPartnerIndividual.IqamaExpiryDate === null ? undefined : moment(serverData.BusinessPartnerIndividual.IqamaExpiryDate).toDate());
            return businessPartnerIndividual;
        } else {
            return undefined;
        }
    };
    // Convert (Business Partner Company) Server to Client
    var BusinessPartnerCompanyClientMapper = function (serverData) {
        if (serverData.BusinessPartnerCompany != null || serverData.BusinessPartnerCompany != undefined) {
            var businessPartnerCompany = new BusinessPartnerCompany();
            // Second Tab : Individual
            businessPartnerCompany.businessPartnerCompanyCode(serverData.BusinessPartnerCompany.BusinessPartnerCompanyCode === null ? undefined : serverData.BusinessPartnerCompany.BusinessPartnerCompanyCode);
            businessPartnerCompany.businessPartnerCompanyName(serverData.BusinessPartnerCompany.BusinessPartnerCompanyName === null ? undefined : serverData.BusinessPartnerCompany.BusinessPartnerCompanyName);
            businessPartnerCompany.businessPartnerCompanyEstablishedSince(serverData.BusinessPartnerCompany.EstablishedSince === null ? undefined : moment(serverData.BusinessPartnerCompany.EstablishedSince).toDate());
            businessPartnerCompany.businessPartnerCompanySwiftCode(serverData.BusinessPartnerCompany.SwiftCode === null ? undefined : serverData.BusinessPartnerCompany.SwiftCode);
            businessPartnerCompany.businessPartnerCompanyAccountNumber(serverData.BusinessPartnerCompany.AccountNumber === null ? undefined : serverData.BusinessPartnerCompany.AccountNumber);
            businessPartnerCompany.businessPartnerCompanyBusinessSegmentId(serverData.BusinessPartnerCompany.BusinessSegmentId === null ? undefined : serverData.BusinessPartnerCompany.BusinessSegmentId);
            return businessPartnerCompany;
        } else {
            return undefined;
        }
    };
    // Convert (Business Partner InType) Server to Client
    var BusinessPartnerInTypeClientMapper = function (item) {
            var businessPartnerInType = new BusinessPartnerInType();
            // Third Tab : Business Partner In Type
            businessPartnerInType.businessPartnerInTypeId(item.BusinessPartnerInTypeId === null ? undefined : item.BusinessPartnerInTypeId);
            businessPartnerInType.businessPartnerInTypeDescription(item.BusinessPartnerInTypeDescription === null ? undefined : item.businessPartnerInTypeDescription);
            businessPartnerInType.fromDate(item.fromDate === null ? undefined : moment(item.fromDate).toDate());
            businessPartnerInType.toDate(item.toDate === null ? undefined :moment(item.toDate).toDate());
            businessPartnerInType.businessPartnerId(item.BusinessPartnerId === null ? undefined : item.BusinessPartnerId);
            businessPartnerInType.businessPartnerSubTypeId(item.BusinessPartnerSubTypeId === null ? undefined : item.BusinessPartnerSubTypeId);
            businessPartnerInType.businessPartnerSubTypeName(item.BusinessPartnerSubTypeName === null ? undefined : item.BusinessPartnerSubTypeName);
            businessPartnerInType.bpRatingTypeId(item.BpRatingTypeId === null ? undefined : item.BpRatingTypeId);
            businessPartnerInType.bpRatingTypeName(item.BpRatingTypeName === null ? undefined : item.BpRatingTypeName);
            return businessPartnerInType;
    };
    return {
        BusinessPartner: BusinessPartner,
        BusinessPartnerDetail: BusinessPartnerDetail,
        BusinessPartnerClientMapper: BusinessPartnerClientMapper,
        BusinessPartnerServerMapper: BusinessPartnerServerMapper,
        BusinessPartnerIndividual: BusinessPartnerIndividual,
        BusinessPartnerIndividualServerMapper: BusinessPartnerIndividualServerMapper,
        BusinessPartnerIndividualClientMapper: BusinessPartnerIndividualClientMapper,
        BusinessPartnerCompany: BusinessPartnerCompany,
        BusinessPartnerCompanyClientMapper: BusinessPartnerCompanyClientMapper,
        BusinessPartnerCompanyServerMapper: BusinessPartnerCompanyServerMapper,
        BusinessPartnerInType: BusinessPartnerInType,
        BusinessPartnerInTypeServerMapper: BusinessPartnerInTypeServerMapper,
        BusinessPartnerPhone: BusinessPartnerPhone
    };
});