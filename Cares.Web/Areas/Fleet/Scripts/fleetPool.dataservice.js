/*
    Data service module with ajax calls to the server
*/
define("Fleet/fleetPool.dataservice", function () {

    // Data service for forecast 
    var dataService = (function () {
        var
            // True if initialized
            isInitialized = false,
            // Initialize
            initialize = function() {
                if (!isInitialized) {

                    // Define request to get FleetPool Base data
                    amplify.request.define('getFleetPoolBasedata', 'ajax', {
                        url: '/Api/FleetPoolBase',
                        dataType: 'json',
                        type: 'GET'
                    });

                    // Define request to get FleetPools
                    amplify.request.define('getFleetPools', 'ajax', {
                        url: '/Api/FleetPool',
                        dataType: 'json',
                        type: 'GET'
                    });


                    //// Define request to save product
                    //amplify.request.define('createProduct', 'ajax', {
                    //    url: '/Api/FleetPool',
                    //    dataType: 'json',
                    //    type: 'PUT'
                    //});

                    //// Define request to update product
                    //amplify.request.define('updateProduct', 'ajax', {
                    //    url: '/Api/FleetPool',
                    //    dataType: 'json',
                    //    type: 'POST'
                    //});

                    // Define request to delete FleetPool
                    amplify.request.define('deleteFleetPool', 'ajax', {
                        url: '/Api/FleetPool',
                        dataType: 'json',
                        type: 'DELETE'
                    });

                    isInitialized = true;
                }
            },

            // Get Fleet Pool Base Data
            getFleetPoolBasedata = function(params, callbacks) {
                initialize();
                return amplify.request({
                    resourceId: 'getFleetPoolBasedata',
                    success: callbacks.success,
                    error: callbacks.error,
                    data: params
                });
            },

            ///get Fleet Pools
            getFleetPools = function(params, callbacks) {
                initialize();
                return amplify.request({
                    resourceId: 'getFleetPools',
                    success: callbacks.success,
                    error: callbacks.error,
                    data: params
                });
            },

            //// Create Product
            //createProduct = function (param, callbacks) {
            //    initialize();
            //    return amplify.request({
            //        resourceId: 'createProduct',
            //        success: callbacks.success,
            //        error: callbacks.error,
            //        data: param
            //    });
            //},

            //// Update a Product
            //updateProduct = function (param, callbacks) {
            //    initialize();
            //    return amplify.request({
            //        resourceId: 'updateProduct',
            //        success: callbacks.success,
            //        error: callbacks.error,
            //        data: param
            //    });
            //},

            // save Forecast
        deleteFleetPool = function(param, callbacks) {
            initialize();
            return amplify.request({
                resourceId: 'deleteFleetPool',
                success: callbacks.success,
                error: callbacks.error,
                data: param
            });
        };

        return {
            getFleetPoolBasedata: getFleetPoolBasedata,
            getFleetPools: getFleetPools,
            deleteFleetPool: deleteFleetPool
        };
    })();

    return dataService;
});