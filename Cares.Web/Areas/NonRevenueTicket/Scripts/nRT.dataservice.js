/*
    Data service module with ajax calls to the server
*/
define("nRT/nRT.dataservice", function () {

    // Data service for forecast 
    var dataService = (function () {
        var // True if initialized
            isInitialized = false,
            // Initialize
            initialize = function () {
                if (!isInitialized) {

                    // Define request to get Non Revenue Ticket base data
                    amplify.request.define('getNRTBase', 'ajax', {
                        url: ist.siteUrl + '/Api/NRTBase',
                        dataType: 'json',
                        type: 'GET'
                    });
                    // Define request to Get Vehicles Detail 
                    amplify.request.define('getVehiclesDetail', 'ajax', {
                        url: ist.siteUrl + '/Api/GetVehiclesForNRT',
                        dataType: 'json',
                        decoder: amplify.request.decoders.istStatusDecoder,
                        type: 'POST'
                    });
                    isInitialized = true;
                }
            },
             

        // Non Revenue Ticket base data
        // ReSharper disable once InconsistentNaming
        getNRTBase = function (callbacks) {
            initialize();
            return amplify.request({
                resourceId: 'getNRTBase',
                success: callbacks.success,
                error: callbacks.error,
            });
        },
        // Get Vehicles Detail 
        getVehiclesDetail = function (param, callbacks) {
            initialize();
            return amplify.request({
                resourceId: 'getVehiclesDetail',
                success: callbacks.success,
                error: callbacks.error,
                data: param
            });
        };
        return {
            getNRTBase: getNRTBase,
            getVehiclesDetail: getVehiclesDetail,
        };
    })();

    return dataService;
});