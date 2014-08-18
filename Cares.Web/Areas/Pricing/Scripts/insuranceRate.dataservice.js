/*
    Data service module with ajax calls to the server
*/
define("insuranceRate/insuranceRate.dataservice", function () {

    // Data service for forecast 
    var dataService = (function () {
        var // True if initialized
            isInitialized = false,
            // Initialize
            initialize = function () {
                if (!isInitialized) {

                    // Define request to get Insurance Rate base 
                    amplify.request.define('getInsuranceRateBase', 'ajax', {
                        url: '/Api/InsuranceRateBase',
                        dataType: 'json',
                        type: 'GET'
                    });

                    isInitialized = true;
                }
            },
            // Get Insurance Rate base
            getInsuranceRateBase = function (callbacks) {
                initialize();
                return amplify.request({
                    resourceId: 'getInsuranceRateBase',
                    success: callbacks.success,
                    error: callbacks.error,
                });
            };

        return {
            getInsuranceRateBase: getInsuranceRateBase,
        };
    })();

    return dataService;
});