/*
    Data service module with ajax calls to the server
*/
define("designation/designation.dataservice", function () {

    // Data service for forecast 
    var dataService = (function () {
        var
            // True if initialized
            isInitialized = false,
            // Initialize
            initialize = function() {
                if (!isInitialized) {


                    // Define request to get Designations 
                    amplify.request.define('getDesignations', 'ajax', {
                        url: '/Api/Designation',
                        dataType: 'json',
                        decoder: amplify.request.decoders.istStatusDecoder,
                        type: 'GET'
                    });
                    // Define request to delete Designation
                    amplify.request.define('deleteDesignation', 'ajax', {
                        url: '/Api/Designation',
                        dataType: 'json',
                        decoder: amplify.request.decoders.istStatusDecoder,
                        type: 'DELETE'
                    });
                    // Define request to add/update Designation
                    amplify.request.define('saveDesignation', 'ajax', {
                        url: '/Api/Designation',
                        dataType: 'json',
                        decoder: amplify.request.decoders.istStatusDecoder,
                        type: 'POST'
                    });

                    isInitialized = true;
                }
            },
            // Get Designations
            getDesignations = function (params, callbacks) {
                initialize();
                return amplify.request({
                    resourceId: 'getDesignations',
                    success: callbacks.success,
                    error: callbacks.error,
                    data: params
                });
            },
            //add-update Designation.
            saveDesignation = function (params, callbacks) {
                return amplify.request({
                    resourceId: 'saveDesignation',
                    success: callbacks.success,
                    error: callbacks.error,
                    data: params
                });
            },
            //delete Designation.
            deleteDesignation = function (params, callbacks) {
                return amplify.request({
                    resourceId: 'deleteDesignation',
                    success: callbacks.success,
                    error: callbacks.error,
                    data: params
                });
            };
        return {
            saveDesignation: saveDesignation,
            getDesignations: getDesignations,
            deleteDesignation: deleteDesignation,

        };
    })();
    return dataService;
});