/*
    Data service module with ajax calls to the server
*/
define("OrganizationGroup/OrganizationGroup.dataservice", function () {

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
            };
                 
    
        return {
            getFleetPoolBasedata: getFleetPoolBasedata,
        };
    })();
    return dataService;
});