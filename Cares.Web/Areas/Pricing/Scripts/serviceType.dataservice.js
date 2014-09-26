/*
    Data service module with ajax calls to the server
*/
define("serviceType/serviceType.dataservice", function () {

    // Data service for forecast 
    var dataService = (function () {
        var
            // True if initialized
            isInitialized = false,
            // Initialize
            initialize = function() {
                if (!isInitialized) {


                    // Define request to get Service Type
                    amplify.request.define('getServiceType', 'ajax', {
                        url: '/Api/ServiceType',
                        dataType: 'json',
                        decoder: amplify.request.decoders.istStatusDecoder,
                        type: 'GET'
                    });
                    // Define request to delete Service Type
                    amplify.request.define('deleteServiceType', 'ajax', {
                        url: '/Api/ServiceType',
                        dataType: 'json',
                        decoder: amplify.request.decoders.istStatusDecoder,
                        type: 'DELETE'
                    });
                    // Define request to add/update  Service Type
                    amplify.request.define('saveServiceType', 'ajax', {
                        url: '/Api/ServiceType',
                        dataType: 'json',
                        decoder: amplify.request.decoders.istStatusDecoder,
                        type: 'POST'
                    });
                    isInitialized = true;
                }
            },
            // Get Sub Service Type
            getServiceType = function (params, callbacks) {
                initialize();
                return amplify.request({
                    resourceId: 'getServiceType',
                    success: callbacks.success,
                    error: callbacks.error,
                    data: params
                });
            },
            //add-update Service Type
            saveServiceType = function (params, callbacks) {
                return amplify.request({
                    resourceId: 'saveServiceType',
                    success: callbacks.success,
                    error: callbacks.error,
                    data: params
                });
            },
            //delete Service Type
            deleteServiceType = function (params, callbacks) {
                return amplify.request({
                    resourceId: 'deleteServiceType',
                    success: callbacks.success,
                    error: callbacks.error,
                    data: params
                });
            };
      
        return {
            saveServiceType: saveServiceType,
            getServiceType: getServiceType,
            deleteServiceType: deleteServiceType,

        };
    })();
    return dataService;
});