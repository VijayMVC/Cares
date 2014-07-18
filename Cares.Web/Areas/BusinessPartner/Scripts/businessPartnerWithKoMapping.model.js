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

        // Extend BusinessPartner
        // Is Individual Computed
        self.isIndividualComputed = ko.computed(function() {
            if (self.IsIndividual() == true) {
                return "Individual";
            } else {
                return "Company";
            }
        });
        // Company Computed
        self.companyComputed = ko.computed(function () {
            if (!self.CompanyName()) {
               return "";
            }
            else {
                return self.CompanyCode()+"-"+self.CompanyName();
            }
        });
        // Rating Type Computed
        self.BPRatingTypeComputed = ko.computed(function () {
            if (!self.BPRatingTypeName()) {
                return "";
            }
            else {
                return self.BPRatingTypeCode() + "-" + self.BPRatingTypeName();
            }
        });
        // Business Partner Id Computed
        self.BusinessPartnerIdComputed = ko.computed(function () {
            if (!self.BusinessPartnerId()) {
                return "";
            }
            else {
                return (self.IsIndividual() == true ? "I": "C") + "-" + self.BusinessPartnerId();
            }
        });
       
        return {
            businessPartnerName: self.BusinessPartnerName,
            businessPartnerId: self.BusinessPartnerIdComputed,
            businessPartnerDesciption: self.BusinessPartnerDesciption,
            isIndividual: self.isIndividualComputed,
            bPRatingType: self.BPRatingTypeComputed,
            company: self.companyComputed,
        };
    };
    
    var
   // Business Partner entity
   // ReSharper disable InconsistentNaming
   BusinessPartnerDetail = function (specifiedKey, specifiedBPName, specifiedDescription, specifiedisIndividual,
       specifiedisSystemGuarantor, specifiednonSystemGuarantor, specifiedbusinessPartnerEmailAddress,
       specifiedbusinessPartnerIsValid, specifiedCompany, specifiedPaymentTerm, specifiedBPRatigType,
   specifiedBusinessLegalStatus, specifiedSystemGuarantor, specifiedDealingEmployee) {
       // ReSharper restore InconsistentNaming
       var // Reference to this object
           self,
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
               return errors().length === 0;
           }),
           // True if the booking has been changed
           // ReSharper disable InconsistentNaming
           dirtyFlag = new ko.dirtyFlag({
               // ReSharper restore InconsistentNaming
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
               dealingEmployeeId: dealingEmployeeId
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
        return result;
    };
    // Convert Server to Client
    var BusinessPartnerClientMapper = function (serverData) {
        var businessPartner = new BusinessPartnerDetail();
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
        return businessPartner;
    };

    return {
        BusinessPartner: BusinessPartner,
        BusinessPartnerDetail: BusinessPartnerDetail,
        BusinessPartnerClientMapper: BusinessPartnerClientMapper,
        BusinessPartnerServerMapper: BusinessPartnerServerMapper
    };
});