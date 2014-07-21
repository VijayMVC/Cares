/*
    Data service module with ajax calls to the server
*/
define("tariffRate/tariffRate.dataservice", function () {

    // Data service for forecast 
    var dataService = (function () {
        var
            // True if initialized
            isInitialized = false,
            // Initialize
            initialize = function() {
                if (!isInitialized) {
                    
                    // Define request to get Tariff Rate base 
                    amplify.request.define('getTariffRateBase', 'ajax', {
                        url: '/Api/TariffRateBase',
                        dataType: 'json',
                        type: 'GET'
                    });

                    isInitialized = true;
                }
            },
            // Get Tariff Rate base
            getTariffRateBase = function (callbacks) {
                initialize();
                return amplify.request({
                    resourceId: 'getTariffRateBase',
                    success: callbacks.success,
                    error: callbacks.error,
                });
            };// Get Tariff Rate 
          

        return {
            getTariffRateBase: getTariffRateBase,
          
        };
    })();

    return dataService;
});