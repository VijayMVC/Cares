define(["ko", "underscore", "underscore-ko"], function (ko) {

    var

    // BusinessPartner entity - Using Knockout Mapping
    // ReSharper disable InconsistentNaming
    BusinessPartner = function (data) {
        // ReSharper restore InconsistentNaming
        var // Reference to this object
            self = {},
            // 
            mapping = {
                // customize the creation of the name property so that it provides validation
                BusinessPartnerName: {
                    create: function (options) {
                        return ko.observable(options.data).extend({ required: true });
                    }
                },
                BusinessPartnerDesciption: {
                    create: function (options) {
                        return ko.observable(options.data).extend({ required: true });
                    }
                },
                IsIndividual: {
                    create: function (options) {
                        return ko.observable(options.data).extend({ required: true });
                    }
                },
                BPRatingTypeName: {
                    create: function (options) {
                        return ko.observable(options.data).extend({ required: true });
                    }
                },
                CompanyCode: {
                    create: function (options) {
                        return ko.observable(options.data).extend({ required: true });
                    }
                },
                CompanyName: {
                    create: function (options) {
                        return ko.observable(options.data).extend({ required: true });
                    }
                },
                //CompanyId: {
                //    create: function (options) {
                //        return ko.observable(options.data).extend({ required: true });
                //    }
                //},
                //PaymentTermId: {
                //        create: function (options) {
                //            return ko.observable(options.data).extend({ required: true });
                //        }
                //},
                //BPRatingTypeId: {
                //        create: function (options) {
                //            return ko.observable(options.data).extend({ required: true });
                //        }
                //},
                //BusinessLegalStatusId: {
                //    create: function (options) {
                //        return ko.observable(options.data).extend({ required: true });
                //    }
                //}
            };

        // Map data to self
        ko.mapping.fromJS(data, mapping, self);

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
        

        //// Categoreis
        //self.categories = ko.observableArray([]),
        //    return categoryResult ? categoryResult.Name : "";
        //}),
        //// Assign Categories
        //self.assignCategories = function (categoryList) {
        //    self.categories.removeAll();
        //    if (!categoryList) {
        //        return;
        //    }
        //    ko.utils.arrayPushAll(self.categories(), categoryList);
        //    self.categories.valueHasMutated();
        //},
        // Errors
        self.errors = ko.validation.group({
            businessPartnerName: self.BusinessPartnerName
            
        }),
        // Is Valid
        self.isValid = ko.computed(function () {
            return self.errors().length === 0;
        }),
        // True if the booking has been changed
        // ReSharper disable InconsistentNaming
        self.dirtyFlag = new ko.dirtyFlag({
            // ReSharper restore InconsistentNaming
            businessPartnerName: self.BusinessPartnerName,
            businessPartnerDesciption: self.BusinessPartnerDesciption
            //isSystemGuarantor: self.IsSystemGuarantor,
            //systemGuarantorId: self.SystemGuarantorId,
            //nonSystemGuarantor: self.NonSystemGuarantor,
            //dealingEmployeeId: self.DealingEmployeeId,
            //businessPartnerEmailAddress: self.BusinessPartnerEmailAddress,
            //businessPartnerIsValid: self.businessPartnerIsValid
        }),
        // Has Changes
        self.hasChanges = ko.computed(function () {
            return self.dirtyFlag.isDirty();
        }),
        // Reset
        self.reset = function () {
            self.dirtyFlag.reset();
        };

        return {
            businessPartnerName: self.BusinessPartnerName,
            businessPartnerId: self.BusinessPartnerIdComputed,
            businessPartnerDesciption: self.BusinessPartnerDesciption,
            isIndividual: self.isIndividualComputed,
            bPRatingType: self.BPRatingTypeComputed,
            company: self.companyComputed,
            //companyId: self.CompanyId !== undefined ? self.CompanyId : ko.observable(),
            //paymentTermId: self.PaymentTermId !== undefined ? self.PaymentTermId : ko.observable(),
            //bPRatingTypeId: self.BPRatingTypeId !== undefined ? self.BPRatingTypeId : ko.observable(),
            //businessLegalStatusId: self.BusinessLegalStatusId !== undefined ? self.BusinessLegalStatusId : ko.observable(),
            //isSystemGuarantor: self.IsSystemGuarantor !== undefined ? self.IsSystemGuarantor : ko.observable(),
            //systemGuarantorId: self.SystemGuarantorId !== undefined ? self.SystemGuarantorId : ko.observable(),
            //nonSystemGuarantor: self.NonSystemGuarantor !== undefined ? self.NonSystemGuarantor : ko.observable(),
            //dealingEmployeeId: self.DealingEmployeeId !== undefined ? self.DealingEmployeeId : ko.observable(),
            //businessPartnerEmailAddress: self.BusinessPartnerEmailAddress !== undefined ? self.BusinessPartnerEmailAddress : ko.observable(),
            //businessPartnerIsValid: self.businessPartnerIsValid !== undefined ? self.businessPartnerIsValid : ko.observable(),
            hasChanges: self.hasChanges,
            reset: self.reset,
            errors: self.errors,
            isValid: self.isValid
        };
    };

    return {
        BusinessPartner: BusinessPartner
    };
});