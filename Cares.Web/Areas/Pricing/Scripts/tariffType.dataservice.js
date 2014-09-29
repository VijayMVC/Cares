/*
    Data service module with ajax calls to the server
*/
define("tariffType/tariffType.dataservice", function () {

    // Data service for forecast 
    var dataService = (function () {
        var
            // True if initialized
            isInitialized = false,
            // Initialize
            initialize = function() {
                if (!isInitialized) {
                    
                    // Define request to get tariff type base 
                    amplify.request.define('getTariffTypeBase', 'ajax', {
                        url: ist.siteUrl + '/Api/TariffTypeBase',
                        dataType: 'json',
                        type: 'GET'
                    });
                    // Define request to get tariff type by id 
                    amplify.request.define('getTariffTypeById', 'ajax', {
                        url: ist.siteUrl + '/Api/GetTariffTypeDetails',
                        dataType: 'json',
                        type: 'GET'
                    });
                    // Define request to get tariff type  
                    amplify.request.define('getTariffType', 'ajax', {
                        url: ist.siteUrl + '/Api/TariffType',
                        dataType: 'json',
                        type: 'GET'
                    });
                    // Define request to save Add tariffType
                    amplify.request.define('createTariffType', 'ajax', {
                        url: ist.siteUrl + '/Api/TariffType',
                        dataType: 'json',
                        decoder: amplify.request.decoders.istStatusDecoder,
                        type: 'POST'
                    });

                    // Define request to update updatetariffType
                    amplify.request.define('updateTariffType', 'ajax', {
                        url: ist.siteUrl + '/Api/TariffType',
                        dataType: 'json',
                        decoder: amplify.request.decoders.istStatusDecoder,
                        type: 'POST'
                    });
                    isInitialized = true;
                }
            },
            // Get tariff type base
            getTariffTypeBase = function(callbacks) {
                initialize();
                return amplify.request({
                    resourceId: 'getTariffTypeBase',
                    success: callbacks.success,
                    error: callbacks.error,
                });
            },
            // Get tariff type 
            getTariffType = function(params, callbacks) {
                initialize();
                return amplify.request({
                    resourceId: 'getTariffType',
                    success: callbacks.success,
                    error: callbacks.error,
                    data: params
                });
            },
            // Create tariff type 
            createTariffType = function (param, callbacks) {
                initialize();
                return amplify.request({
                    resourceId: 'createTariffType',
                    success: callbacks.success,
                    error: callbacks.error,
                    data: param
                });
            },
             // Get tariff type bby id 
            getTariffTypeById = function (param, callbacks) {
                initialize();
                return amplify.request({
                    resourceId: 'getTariffTypeById',
                    success: callbacks.success,
                    error: callbacks.error,
                    data: param
                });
            },
            
            // Update a tariff type 
            updateTariffType = function (param, callbacks) {
                initialize();
                return amplify.request({
                    resourceId: 'updateTariffType',
                    success: callbacks.success,
                    error: callbacks.error,
                    data: param
                });
            };
            
        return {
            getTariffTypeBase: getTariffTypeBase,
            getTariffType: getTariffType,
            createTariffType: createTariffType,
            updateTariffType: updateTariffType,
            getTariffTypeById: getTariffTypeById

        };
    })();

    return dataService;
});