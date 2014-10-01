/*
    Data service module with ajax calls to the server
*/
define("ratingType/ratingType.dataservice", function () {

    // Data service for forecast 
    var dataService = (function () {
        var
            // True if initialized
            isInitialized = false,
            // Initialize
            initialize = function() {
                if (!isInitialized) {
                    // Define request to get Rating Types 
                    amplify.request.define('getRatingTypes', 'ajax', {
                        url: ist.siteUrl + '/Api/RatingType',
                        dataType: 'json',
                        decoder: amplify.request.decoders.istStatusDecoder,
                        type: 'GET'
                    });
                    // Define request to delete Rating Type
                    amplify.request.define('deleteRatingType', 'ajax', {
                        url: ist.siteUrl + '/Api/RatingType',
                        dataType: 'json',
                        decoder: amplify.request.decoders.istStatusDecoder,
                        type: 'DELETE'
                    });
                    // Define request to add/update Rating Type
                    amplify.request.define('saveRatingType', 'ajax', {
                        url: ist.siteUrl + '/Api/RatingType',
                        dataType: 'json',
                        decoder: amplify.request.decoders.istStatusDecoder,
                        type: 'POST'
                    });
                    isInitialized = true;
                }
            },
            // Get Rating Types
            getRatingTypes = function (params, callbacks) {
                initialize();
                return amplify.request({
                    resourceId: 'getRatingTypes',
                    success: callbacks.success,
                    error: callbacks.error,
                    data: params
                });
            },
            //add-update Rating Type.
            saveRatingType = function (params, callbacks) {
                return amplify.request({
                    resourceId: 'saveRatingType',
                    success: callbacks.success,
                    error: callbacks.error,
                    data: params
                });
            },
            //delete Rating Type.
            deleteRatingType = function (params, callbacks) {
                return amplify.request({
                    resourceId: 'deleteRatingType',
                    success: callbacks.success,
                    error: callbacks.error,
                    data: params
                });
            };
        return {
            saveRatingType: saveRatingType,
            getRatingTypes: getRatingTypes,
            deleteRatingType: deleteRatingType,
        };
    })();
    return dataService;
});