/*
    Data service module with ajax calls to the server
*/
define("occupationType/occupationType.dataservice", function () {

    // Data service for forecast 
    var dataService = (function () {
        var
            // True if initialized
            isInitialized = false,
            // Initialize
            initialize = function() {
                if (!isInitialized) {
                    // Define request to get Occupation Types
                    amplify.request.define('getOccupationTypes', 'ajax', {
                        url: ist.siteUrl + '/Api/OccupationType',
                        dataType: 'json',
                        decoder: amplify.request.decoders.istStatusDecoder,
                        type: 'GET'
                    });
                    // Define request to delete Occupation Type
                    amplify.request.define('deleteOccupationType', 'ajax', {
                        url: ist.siteUrl + '/Api/OccupationType',
                        dataType: 'json',
                        decoder: amplify.request.decoders.istStatusDecoder,
                        type: 'DELETE'
                    });
                    // Define request to add/update Occupation Type
                    amplify.request.define('saveOccupationType', 'ajax', {
                        url: ist.siteUrl + '/Api/OccupationType',
                        dataType: 'json',
                        decoder: amplify.request.decoders.istStatusDecoder,
                        type: 'POST'
                    });
                    isInitialized = true;
                }
            },
            // Get Occupation Types
            getOccupationTypes = function (params, callbacks) {
                initialize();
                return amplify.request({
                    resourceId: 'getOccupationTypes',
                    success: callbacks.success,
                    error: callbacks.error,
                    data: params
                });
            },
            //add-update Occupation Type
            saveOccupationType = function (params, callbacks) {
                return amplify.request({
                    resourceId: 'saveOccupationType',
                    success: callbacks.success,
                    error: callbacks.error,
                    data: params
                });
            },
            //delete Occupation Type
            deleteOccupationType = function (params, callbacks) {
                return amplify.request({
                    resourceId: 'deleteOccupationType',
                    success: callbacks.success,
                    error: callbacks.error,
                    data: params
                });
            };
        return {
            saveOccupationType: saveOccupationType,
            getOccupationTypes: getOccupationTypes,
            deleteOccupationType: deleteOccupationType,
        };
    })();
    return dataService;
});