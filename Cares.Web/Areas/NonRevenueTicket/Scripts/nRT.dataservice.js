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
        };
        return {
            getNRTBase: getNRTBase,
        };
    })();

    return dataService;
});