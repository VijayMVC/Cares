define(["ko", "underscore", "underscore-ko"], function (ko) {

    var
    // Business Partner entity
    // ReSharper disable InconsistentNaming
    BusinessPartner = function (specifiedKey, specifiedBPName, specifiedDescription, specifiedisIndividual,
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
            // Business Partner Is Valid
            businessPartnerIsValid = ko.observable(specifiedbusinessPartnerIsValid).extend({ required: true }),
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
                businessPartnerIsValid: businessPartnerIsValid,
                companyId: companyId,
                paymentTermId: paymentTermId
            }),
            // Is Valid
            isValid = ko.computed(function () {
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
                businessPartnerIsValid: businessPartnerIsValid,
                companyId: companyId,
                paymentTermId: paymentTermId,
                bPRatingTypeId: bPRatingTypeId,
                businessLegalStatusId: businessLegalStatusId,
                systemGuarantorId: systemGuarantorId,
                dealingEmployeeId: dealingEmployeeId
            }),
            // Has Changes
            hasChanges = ko.computed(function () {
                return dirtyFlag.isDirty();
            }),
            // Reset
            reset = function () {
                dirtyFlag.reset();
            },
            // Convert Client to server
            convertToServerData = function () {
                return {
                    BusinessPartnerId: businessPartnerId(),
                    BusinessPartnerName: businessPartnerName(),
                    BusinessPartnerDesciption: businessPartnerDesciption(),
                    IsIndividual: isIndividual(),
                    IsSystemGuarantor: isSystemGuarantor(),
                    NonSystemGuarantor: nonSystemGuarantor(),
                    BusinessPartnerEmailAddress: businessPartnerEmailAddress(),
                    BusinessPartnerIsValid: businessPartnerIsValid(),
                    CompanyId: companyId(),
                    PaymentTermId: paymentTermId(),
                    BPRatingTypeId: bPRatingTypeId(),
                    BusinessLegalStatusId: businessLegalStatusId(),
                    SystemGuarantorId: systemGuarantorId(),
                    DealingEmployeeId: dealingEmployeeId(),
                };
            },
            // Convert Server to Client
            convertToClientData = function (source) {
                var businessPartner = new BusinessPartner();
                businessPartner.businessPartnerId(source.businessPartnerId === null ? undefined : source.businessPartnerId);
                businessPartner.businessPartnerName(source.businessPartnerName === null ? undefined : source.businessPartnerName);
                businessPartner.businessPartnerDesciption(source.businessPartnerDesciption === null ? undefined : source.businessPartnerDesciption);
                businessPartner.isIndividual(source.isIndividual === null ? undefined : source.isIndividual);
                businessPartner.isSystemGuarantor(source.isSystemGuarantor === null ? undefined : source.isSystemGuarantor);
                businessPartner.nonSystemGuarantor(source.nonSystemGuarantor === null ? undefined : source.nonSystemGuarantor);
                businessPartner.businessPartnerEmailAddress(source.businessPartnerEmailAddress === null ? undefined : source.businessPartnerEmailAddress);
                businessPartner.businessPartnerIsValid(source.businessPartnerIsValid === null ? undefined : source.businessPartnerIsValid);
                businessPartner.companyId(source.companyId === null ? undefined : source.companyId);
                businessPartner.paymentTermId(source.paymentTermId === null ? undefined : source.paymentTermId);
                businessPartner.bPRatingTypeId(source.bPRatingTypeId === null ? undefined : source.bPRatingTypeId);
                businessPartner.bPRatingTypeusinessLegalStatusId(source.businessLegalStatusId === null ? undefined : source.businessLegalStatusId);
                businessPartner.systemGuarantorId(source.systemGuarantorId === null ? undefined : source.systemGuarantorId);
                businessPartner.dealingEmployeeId(source.DealingEmployeeId === null ? undefined : source.DealingEmployeeId);
                return businessPartner;
            };



        self = {
            businessPartnerId: businessPartnerId,
            businessPartnerName: businessPartnerName,
            businessPartnerDesciption: businessPartnerDesciption,
            isIndividual: isIndividual,
            isSystemGuarantor: isSystemGuarantor,
            nonSystemGuarantor: nonSystemGuarantor,
            businessPartnerEmailAddress: businessPartnerEmailAddress,
            businessPartnerIsValid: businessPartnerIsValid,
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
            isBusy: isBusy,

            convertToServerData: convertToServerData,
            convertToClientData: convertToClientData
        };
        return self;
    };

    // BusinessPartner Factory
    BusinessPartner.Create = function () {
        return new BusinessPartner("", "", "", false, false, "", "", false, undefined, undefined, undefined, undefined, undefined);
    };

    return {
        BusinessPartner: BusinessPartner
    };
});