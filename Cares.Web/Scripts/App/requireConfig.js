// Setup requirejs
(function () {

    var root = this;

    requirejs.config({
        baseUrl: "/Scripts/App",
        waitSeconds: 20,
        paths: {
            "product": "/Areas/Product/Scripts",
            "common": "/Areas/Common/Scripts",
            "Fleet": "/Areas/Fleet/Scripts"
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
