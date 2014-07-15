/*
    Data service module with ajax calls to the server
*/
define("tarrifType/tarrifType.dataservice", function () {

    // Data service for forecast 
    var dataService = (function () {
        var
            // True if initialized
            isInitialized = false,
            // Initialize
            initialize = function() {
                if (!isInitialized) {

                    // Define request to get tarrif type base 
                    amplify.request.define('getTarrifTypeBase', 'ajax', {
                        url: '/Api/TarrifTypeBase',
                        dataType: 'json',
                        type: 'GET'
                    });

                    // Define request to get tarrif type base 
                    amplify.request.define('getTarrifType', 'ajax', {
                        url: '/Api/TarrifType',
                        dataType: 'json',
                        type: 'GET'
                    });
                    isInitialized = true;
                }
            },

            // Get Tarrif type base
            getTarrifTypeBase = function (callbacks) {
                initialize();
                return amplify.request({
                    resourceId: 'getTarrifTypeBase',
                    success: callbacks.success,
                    error: callbacks.error,
                         });
            },   // Get Tarrif type 
            getTarrifType = function (params, callbacks) {
                initialize();
                return amplify.request({
                    resourceId: 'getTarrifType',
                    success: callbacks.success,
                    error: callbacks.error,
                    data: params
                });
            };

          
        return {
            getTarrifTypeBase: getTarrifTypeBase,
            getTarrifType: getTarrifType,
           
        };
    })();

    return dataService;
});