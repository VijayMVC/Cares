/*
    Data service module with ajax calls to the server
*/
define("jobType/jobType.dataservice", function () {

    // Data service for forecast 
    var dataService = (function () {
        var
            // True if initialized
            isInitialized = false,
            // Initialize
            initialize = function() {
                if (!isInitialized) {


                    // Define request to get Cities 
                    amplify.request.define('getJobTypes', 'ajax', {
                        url: ist.siteUrl + '/Api/JobType',
                        dataType: 'json',
                        decoder: amplify.request.decoders.istStatusDecoder,
                        type: 'GET'
                    });
                    // Define request to delete City
                    amplify.request.define('deleteJobType', 'ajax', {
                        url: ist.siteUrl + '/Api/JobType',
                        dataType: 'json',
                        decoder: amplify.request.decoders.istStatusDecoder,
                        type: 'DELETE'
                    });
                    // Define request to add/update City
                    amplify.request.define('saveJobType', 'ajax', {
                        url: ist.siteUrl + '/Api/JobType',
                        dataType: 'json',
                        decoder: amplify.request.decoders.istStatusDecoder,
                        type: 'POST'
                    });

                    isInitialized = true;
                }
            },
            // Get Cities
            getJobTypes = function (params, callbacks) {
                initialize();
                return amplify.request({
                    resourceId: 'getJobTypes',
                    success: callbacks.success,
                    error: callbacks.error,
                    data: params
                });
            },
            //add-update City.
            saveJobType = function (params, callbacks) {
                return amplify.request({
                    resourceId: 'saveJobType',
                    success: callbacks.success,
                    error: callbacks.error,
                    data: params
                });
            },
            //delete City.
            deleteJobType = function(params, callbacks) {
                return amplify.request({
                    resourceId: 'deleteJobType',
                    success: callbacks.success,
                    error: callbacks.error,
                    data: params
                });
            };

        return {
            saveJobType: saveJobType,
            getJobTypes: getJobTypes,
            deleteJobType: deleteJobType,

        };
    })();
    return dataService;
});