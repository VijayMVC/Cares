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
                    amplify.request.define('gettariffTypeBase', 'ajax', {
                        url: '/Api/tariffTypeBase',
                        dataType: 'json',
                        type: 'GET'
                    });
                    // Define request to get tariff type by id 
                    amplify.request.define('gettariffTypeById', 'ajax', {
                        url: '/Api/GetTariffDetails',
                        dataType: 'json',
                        type: 'GET'
                    });
                    // Define request to get tariff type  
                    amplify.request.define('gettariffType', 'ajax', {
                        url: '/Api/tariffType',
                        dataType: 'json',
                        type: 'GET'
                    });
                    // Define request to save updatetariffType
                    amplify.request.define('createtariffType', 'ajax', {
                        url: '/Api/tariffType',
                        dataType: 'json',
                        type: 'PUT'
                    });

                    // Define request to update updatetariffType
                    amplify.request.define('updatetariffType', 'ajax', {
                        url: '/Api/tariffType',
                        dataType: 'json',
                        type: 'POST'
                    });
                    isInitialized = true;
                }
            },
            // Get tariff type base
            gettariffTypeBase = function(callbacks) {
                initialize();
                return amplify.request({
                    resourceId: 'gettariffTypeBase',
                    success: callbacks.success,
                    error: callbacks.error,
                });
            },
            // Get tariff type 
            gettariffType = function(params, callbacks) {
                initialize();
                return amplify.request({
                    resourceId: 'gettariffType',
                    success: callbacks.success,
                    error: callbacks.error,
                    data: params
                });
            },
            // Create tariff type 
            createtariffType = function (param, callbacks) {
                initialize();
                return amplify.request({
                    resourceId: 'createtariffType',
                    success: callbacks.success,
                    error: callbacks.error,
                    data: param
                });
            },
             // Get tariff type bby id 
            gettariffTypeById = function (param, callbacks) {
                initialize();
                return amplify.request({
                    resourceId: 'gettariffTypeById',
                    success: callbacks.success,
                    error: callbacks.error,
                    data: param
                });
            },
            
            // Update a tariff type 
            updatetariffType = function (param, callbacks) {
                initialize();
                return amplify.request({
                    resourceId: 'updatetariffType',
                    success: callbacks.success,
                    error: callbacks.error,
                    data: param
                });
            };
            
        return {
            gettariffTypeBase: gettariffTypeBase,
            gettariffType: gettariffType,
            createtariffType: createtariffType,
            updatetariffType: updatetariffType,
            gettariffTypeById: gettariffTypeById

        };
    })();

    return dataService;
});