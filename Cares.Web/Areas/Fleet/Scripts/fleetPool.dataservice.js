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
                        decoder: amplify.request.decoders.istStatusDecoder,
                        type: 'GET'
                    });
                    //save new added fleetpool
                    amplify.request.define('saveFleetPool', 'ajax', {
                        url: '/Api/FleetPool',
                        dataType: 'json',
                        decoder: amplify.request.decoders.istStatusDecoder,
                        type: 'POST'
                    });
                    // Define request to get FleetPools
                    amplify.request.define('getFleetPools', 'ajax', {
                        url: '/Api/FleetPool',
                        dataType: 'json',
                        type: 'GET'
                    });
                    // Define request to delete FleetPool
                    amplify.request.define('deleteFleetPool', 'ajax', {
                        url: '/Api/FleetPool',
                        dataType: 'json',
                        type: 'Delete'
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
            //add new fleetpool
            saveFleetPool = function (params, callbacks) {
                return amplify.request({
                    resourceId: 'saveFleetPool',
                    success: callbacks.success,
                    error: callbacks.error,
                    data: params
                });
            },            
        ///get Fleet Pools
            getFleetPools = function (params, callbacks) {
                initialize();
                return amplify.request({
                    resourceId: 'getFleetPools',
                    success: callbacks.success,
                    error: callbacks.error,
                    data: params
                });
            },
            // save Forecast
        deleteFleetPool = function (params, callbacks) {
            return amplify.request({
                resourceId: 'deleteFleetPool',
                success: callbacks.success,
                error: callbacks.error,
                data: params
            });
        };
        return {
            getFleetPoolBasedata: getFleetPoolBasedata,
            getFleetPools: getFleetPools,
            deleteFleetPool: deleteFleetPool,
            saveFleetPool: saveFleetPool
        };
    })();
    return dataService;
});