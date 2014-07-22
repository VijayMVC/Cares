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
   specifiedBusinessLegalStatus, specifiedSystemGuarantor, specifiedDealingEmployee,
   specifiedIndividualFirstName, specifiedIndividualMiddleName, specifiedIndividualLastName,
   specifiedIndividualInitials, specifiedIndividualLiscenseNumber, specifiedIndividualLiscenseExpiryDate,
   specifiedIndividualGenderStatus, specifiedIndividualPassportNumber, specifiedIndividualNicNumber,
   specifiedIndividualMaritalStatusCode, specifiedIndividualTaxRegisterationCode, specifiedIndividualTaxNumber,
   specifiedIndividualDateOfBirth, specifiedIndividualOccupationTypeId, specifiedIndividualIsCompanyExternal,
   specifiedIndividualCompanyName, specifiedIndividualCompanyAddress, specifiedIndividualCompanyPhone,
   specifiedIndividualBusinessPartnerCompnayId, specifiedIndividualNicExpiryDate, specifiedIndividualPassportExpiryDate,
   specifiedIndividualPassportCountryId, specifiedIndividualIqamaNo, specifiedIndividualIqamaExpiryDate,
   specifiedBusinessPartnerCompanyCode, specifiedBusinessPartnerCompanyName, specifiedBusinessPartnerCompanyEstablishedSince,
   specifiedBusinessPartnerCompanySwiftCode, specifiedBusinessPartnerCompanyAccountNumber, specifiedBusinessPartnerCompanyBusinessSegmentId) {
       
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
           
           // Business Partner Company Code
           businessPartnerCompanyCode = ko.observable(specifiedBusinessPartnerCompanyCode),
           // Business Partner Company Name
           businessPartnerCompanyName = ko.observable(specifiedBusinessPartnerCompanyName),
           // Business Partner Company Established Since
           businessPartnerCompanyEstablishedSince = ko.observable(specifiedBusinessPartnerCompanyEstablishedSince),
           // Business Partner Company Swift Code
           businessPartnerCompanySwiftCode = ko.observable(specifiedBusinessPartnerCompanySwiftCode),
           // Business Partner Company Account Number
           businessPartnerCompanyAccountNumber = ko.observable(specifiedBusinessPartnerCompanyAccountNumber),
           // Business Partner Company Established Since
           businessPartnerCompanyBusinessSegmentId = ko.observable(specifiedBusinessPartnerCompanyBusinessSegmentId),
           
           // Is Busy
           isBusy = ko.observable(false),
           // Errors
           errors = ko.validation.group({
               isIndividual: isIndividual,
               isSystemGuarantor: isSystemGuarantor,
               companyId: companyId,
               paymentTermId: paymentTermId,
               individualFirstName: individualFirstName,
               individualLastName: individualLastName,
               individualDateOfBirth: individualDateOfBirth
           }),
           // Is Valid
           isValid = ko.computed(function() {
               return errors().length === 0;
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
               
               businessPartnerCompanyCode:businessPartnerCompanyCode,
               businessPartnerCompanyName:businessPartnerCompanyName,
               businessPartnerCompanyEstablishedSince: businessPartnerCompanyEstablishedSince,
               businessPartnerCompanySwiftCode: businessPartnerCompanySwiftCode,
               businessPartnerCompanyAccountNumber: businessPartnerCompanyAccountNumber,
               businessPartnerCompanyBusinessSegmentId: businessPartnerCompanyBusinessSegmentId
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
           individualIqamaExpiryDate:individualIqamaExpiryDate,

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
        
        // First  tab : Individual Info
        result.IndividualFirstName = clientData.individualFirstName();
        result.IndividualMiddleName = clientData.individualMiddleName();
        result.IndividualLastName = clientData.individualLastName();
        result.IndividualInitials = clientData.individualInitials();
        result.IndividualLiscenseNumber = clientData.individualLiscenseNumber();
        result.IndividualLiscenseExpiryDate = clientData.individualLiscenseExpiryDate() === undefined ? undefined : moment(clientData.individualLiscenseExpiryDate()).format(ist.utcFormat);
        result.IndividualGenderStatus = clientData.individualGenderStatus();
        result.IndividualPassportNumber = clientData.individualPassportNumber();
        result.IndividualNicNumber = clientData.individualNicNumber();
        result.IndividualMaritalStatusCode = clientData.individualMaritalStatusCode();
        result.IndividualTaxRegisterationCode = clientData.individualTaxRegisterationCode();
        result.IndividualTaxNumber = clientData.individualTaxNumber();
        result.IndividualDateOfBirth = clientData.individualDateOfBirth() === undefined ? undefined : moment(clientData.individualDateOfBirth()).format(ist.utcFormat);
        result.IndividualOccupationTypeId = clientData.individualOccupationTypeId();
        result.IndividualIsCompanyExternal = clientData.individualIsCompanyExternal();
        result.IndividualCompanyName = clientData.individualCompanyName();
        result.IndividualCompanyAddress = clientData.individualCompanyAddress();
        result.IndividualCompanyPhone = clientData.individualCompanyPhone();
        result.IndividualBusinessPartnerCompnayId = clientData.individualBusinessPartnerCompnayId();
        result.IndividualNicExpiryDate = clientData.individualNicExpiryDate() === undefined ? undefined : moment(clientData.individualNicExpiryDate()).format(ist.utcFormat);
        result.IndividualPassportExpiryDate = clientData.individualPassportExpiryDate() === undefined ? undefined : moment(clientData.individualPassportExpiryDate()).format(ist.utcFormat);
        result.IndividualPassportCountryId = clientData.individualPassportCountryId();
        result.IndividualIqamaNo = clientData.individualIqamaNo();
        result.IndividualIqamaExpiryDate = clientData.individualIqamaExpiryDate() === undefined ? undefined : moment(clientData.individualIqamaExpiryDate()).format(ist.utcFormat);
        
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

        // First Tab : Individual
        businessPartner.individualFirstName(serverData.IndividualFirstName=== null ? undefined : serverData.IndividualFirstName);
        businessPartner.individualMiddleName(serverData.IndividualMiddleName=== null ? undefined : serverData.IndividualMiddleName);
        businessPartner.individualLastName(serverData.IndividualLastName=== null ? undefined : serverData.IndividualLastName);
        businessPartner.individualInitials(serverData.IndividualInitials=== null ? undefined : serverData.IndividualInitials);
        businessPartner.individualLiscenseNumber(serverData.IndividualLiscenseNumber=== null ? undefined : serverData.IndividualLiscenseNumber);
        businessPartner.individualLiscenseExpiryDate(serverData.IndividualLiscenseExpiryDate=== null ? undefined : serverData.IndividualLiscenseExpiryDate);
        businessPartner.individualGenderStatus(serverData.IndividualGenderStatus=== null ? undefined : serverData.IndividualGenderStatus);
        businessPartner.individualPassportNumber(serverData.IndividualPassportNumber=== null ? undefined : serverData.IndividualPassportNumber);
        businessPartner.individualNicNumber(serverData.IndividualNicNumber=== null ? undefined : serverData.IndividualNicNumber);
        businessPartner.individualMaritalStatusCode(serverData.IndividualMaritalStatusCode=== null ? undefined : serverData.IndividualMaritalStatusCode);
        businessPartner.individualTaxRegisterationCode(serverData.IndividualTaxRegisterationCode=== null ? undefined : serverData.IndividualTaxRegisterationCode);
        businessPartner.individualTaxNumber(serverData.IndividualTaxNumber=== null ? undefined : serverData.IndividualTaxNumber);
        businessPartner.individualDateOfBirth(serverData.IndividualDateOfBirth=== null ? undefined : serverData.IndividualDateOfBirth);
        businessPartner.individualOccupationTypeId(serverData.IndividualOccupationTypeId=== null ? undefined : serverData.IndividualOccupationTypeId);
        businessPartner.individualIsCompanyExternal(serverData.IndividualIsCompanyExternal=== null ? undefined : serverData.IndividualIsCompanyExternal);
        businessPartner.individualCompanyName(serverData.IndividualCompanyName=== null ? undefined : serverData.IndividualCompanyName);
        businessPartner.individualCompanyAddress(serverData.IndividualCompanyAddress=== null ? undefined : serverData.IndividualCompanyAddress);
        businessPartner.individualCompanyPhone(serverData.IndividualCompanyPhone=== null ? undefined : serverData.IndividualCompanyPhone);
        businessPartner.individualBusinessPartnerCompnayId(serverData.IndividualBusinessPartnerCompnayId=== null ? undefined : serverData.IndividualBusinessPartnerCompnayId);
        businessPartner.individualNicExpiryDate(serverData.IndividualNicExpiryDate=== null ? undefined : serverData.IndividualNicExpiryDate);
        businessPartner.individualPassportExpiryDate(serverData.IndividualPassportExpiryDate=== null ? undefined : serverData.IndividualPassportExpiryDate);
        businessPartner.individualPassportCountryId(serverData.IndividualPassportCountryId=== null ? undefined : serverData.IndividualPassportCountryId);
        businessPartner.individualIqamaNo(serverData.IndividualIqamaNo=== null ? undefined : serverData.IndividualIqamaNo);
        businessPartner.individualIqamaExpiryDate(serverData.IndividualIqamaExpiryDate === null ? undefined : serverData.IndividualIqamaExpiryDate);

        return businessPartner;
    };

    return {
        BusinessPartner: BusinessPartner,
        BusinessPartnerDetail: BusinessPartnerDetail,
        BusinessPartnerClientMapper: BusinessPartnerClientMapper,
        BusinessPartnerServerMapper: BusinessPartnerServerMapper
    };
});