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
            initialize = function () {
                if (!isInitialized) {

                    // Define request to get Tariff Rate base 
                    amplify.request.define('getTariffRateBase', 'ajax', {
                        url: '/Api/TariffRateBase',
                        dataType: 'json',
                        type: 'GET'
                    });
                    // Define request to get tarrif type  
                    amplify.request.define('getTariffRate', 'ajax', {
                        url: '/Api/TariffRate',
                        dataType: 'json',
                        type: 'GET'
                    });
                    // Define request to save Tariff Rate
                    amplify.request.define('createTariffRate', 'ajax', {
                        url: '/Api/GetTariffRateDetail',
                        dataType: 'json',
                        type: 'PUT'
                    });

                    // Define request to update Tariff rate
                    amplify.request.define('updateTariffRate', 'ajax', {
                        url: '/Api/TariffRate',
                        dataType: 'json',
                        type: 'POST'
                    });
                    // Define request to get tarrif Rate by id 
                    amplify.request.define('getTariffRateById', 'ajax', {
                        url: '/Api/GetTariffRateDetail',
                        dataType: 'json',
                        type: 'GET'
                    });
                    // Define request to delete Tariff Rate
                    amplify.request.define('deleteTariffRate', 'ajax', {
                        url: '/Api/TariffRate',
                        dataType: 'json',
                        type: 'DELETE'
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
            },
             // Get Tariff Rates 
            getTariffRate = function (params, callbacks) {
                initialize();
                return amplify.request({
                    resourceId: 'getTariffRate',
                    success: callbacks.success,
                    error: callbacks.error,
                    data: params
                });
            },
             // Create Product
            createTariffRate = function (param, callbacks) {
                initialize();
                return amplify.request({
                    resourceId: 'createTariffRate',
                    success: callbacks.success,
                    error: callbacks.error,
                    data: param
                });
            },
            // Update a Product
            updateTariffRate = function (param, callbacks) {
                initialize();
                return amplify.request({
                    resourceId: 'updateTariffRate',
                    success: callbacks.success,
                    error: callbacks.error,
                    data: param
                });
            },
             // Get Tarrif type bby id 
            getTariffRateById = function (param, callbacks) {
                initialize();
                return amplify.request({
                    resourceId: 'getTariffRateById',
                    success: callbacks.success,
                    error: callbacks.error,
                    data: param
                });
            },
            // Delete
            deleteTariffRate = function (param, callbacks) {
                initialize();
                return amplify.request({
                    resourceId: 'deleteTariffRate',
                    success: callbacks.success,
                    error: callbacks.error,
                    data: param
                });
            };
        return {
            getTariffRateBase: getTariffRateBase,
            getTariffRate: getTariffRate,
            createTariffRate: createTariffRate,
            updateTariffRate: updateTariffRate,
            deleteTariffRate: deleteTariffRate,
            getTariffRateById: getTariffRateById
        };
    })();

    return dataService;
});