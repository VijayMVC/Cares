// Setup requirejs
(function () {

    var root = this;

    requirejs.config({
        baseUrl: "/Scripts/App",
        waitSeconds: 20,
        paths: {
            "businessPartner": "/Areas/BusinessPartner/Scripts",
            "product": "/Areas/Product/Scripts",
            "common": "/Areas/Common/Scripts",
            "Fleet": "/Areas/Fleet/Scripts",
            "hireGroup": "/Areas/Fleet/Scripts",
            "vehicle": "/Areas/Fleet/Scripts",
            "tariffType": "/Areas/Pricing/Scripts",
            "tariffRate": "/Areas/Pricing/Scripts",
            "insuranceRate": "/Areas/Pricing/Scripts",
            "serviceRate": "/Areas/Pricing/Scripts",
            "additionalDriverCharge": "/Areas/Pricing/Scripts",
            "additionalCharge": "/Areas/Pricing/Scripts",
            "rentalAgreement": "/Areas/RentalAgreement/Scripts",
            "Organization": "/Areas/Organization/Scripts",
            "company": "/Areas/Organization/Scripts",
            "operation": "/Areas/Organization/Scripts",
            "department": "/Areas/Organization/Scripts",
            "workplace": "/Areas/Organization/Scripts",
            "workLocation": "/Areas/Organization/Scripts",
            "workplaceType": "/Areas/Organization/Scripts",
            "businessSeg": "/Areas/Organization/Scripts",
            "employee": "/Areas/EmployeeManagement/Scripts",
            "region": "/Areas/GeographicalHierarchy/Scripts",
            "subRegion": "/Areas/GeographicalHierarchy/Scripts",
            "city": "/Areas/GeographicalHierarchy/Scripts",
            "area": "/Areas/GeographicalHierarchy/Scripts",
            "empStatus": "/Areas/EmployeeManagement/Scripts",
            "designGrade": "/Areas/EmployeeManagement/Scripts",
            "designation": "/Areas/EmployeeManagement/Scripts",
            "jobType": "/Areas/EmployeeManagement/Scripts",
            "discountType": "/Areas/Pricing/Scripts"
        }
    });
    
    function defineThirdPartyModules() {
        // These are already loaded via bundles. 
        // We define them and put them in the root object.
        define("jquery", [], function () { return root.jQuery; });
        define("ko", [], function () { return root.ko; });
        define("underscore-knockout", [], function () { });
        define("underscore-ko", [], function () { });
        define("knockout", [], function () { return root.ko; });
        define("knockout-validation", [], function () { });
        define("moment", [], function () { return root.moment; });
        define("amplify", [], function () { return root.amplify; });
        define("underscore", [], function () { return root._; });
    }

    defineThirdPartyModules();


})();
