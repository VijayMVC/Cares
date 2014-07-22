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
                    // Define request to get tarrif type by id 
                    amplify.request.define('getTarrifTypeById', 'ajax', {
                        url: '/Api/GetTariffDetails',
                        dataType: 'json',
                        type: 'GET'
                    });
                    // Define request to get tarrif type  
                    amplify.request.define('getTarrifType', 'ajax', {
                        url: '/Api/TarrifType',
                        dataType: 'json',
                        type: 'GET'
                    });
                    // Define request to save updateTarrifType
                    amplify.request.define('createTarrifType', 'ajax', {
                        url: '/Api/TarrifType',
                        dataType: 'json',
                        type: 'PUT'
                    });

                    // Define request to update updateTarrifType
                    amplify.request.define('updateTarrifType', 'ajax', {
                        url: '/Api/TarrifType',
                        dataType: 'json',
                        type: 'POST'
                    });
                    isInitialized = true;
                }
            },
            // Get Tarrif type base
            getTarrifTypeBase = function(callbacks) {
                initialize();
                return amplify.request({
                    resourceId: 'getTarrifTypeBase',
                    success: callbacks.success,
                    error: callbacks.error,
                });
            },
            // Get Tarrif type 
            getTarrifType = function(params, callbacks) {
                initialize();
                return amplify.request({
                    resourceId: 'getTarrifType',
                    success: callbacks.success,
                    error: callbacks.error,
                    data: params
                });
            },
            // Create Tarrif type 
            createTarrifType = function (param, callbacks) {
                initialize();
                return amplify.request({
                    resourceId: 'createTarrifType',
                    success: callbacks.success,
                    error: callbacks.error,
                    data: param
                });
            },
             // Get Tarrif type bby id 
            getTarrifTypeById = function (param, callbacks) {
                initialize();
                return amplify.request({
                    resourceId: 'getTarrifTypeById',
                    success: callbacks.success,
                    error: callbacks.error,
                    data: param
                });
            },
            
            // Update a Tarrif type 
            updateTarrifType = function (param, callbacks) {
                initialize();
                return amplify.request({
                    resourceId: 'updateTarrifType',
                    success: callbacks.success,
                    error: callbacks.error,
                    data: param
                });
            };
            
        return {
            getTarrifTypeBase: getTarrifTypeBase,
            getTarrifType: getTarrifType,
            createTarrifType: createTarrifType,
            updateTarrifType: updateTarrifType,
            getTarrifTypeById: getTarrifTypeById

        };
    })();

    return dataService;
});