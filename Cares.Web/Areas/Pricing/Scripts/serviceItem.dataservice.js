/*
    Data service module with ajax calls to the server
*/
define("serviceItem/serviceItem.dataservice", function () {

    // Data service for forecast 
    var dataService = (function () {
        var
            // True if initialized
            isInitialized = false,
            // Initialize
            initialize = function() {
                if (!isInitialized) {


                    // Define request to get Service Items
                    amplify.request.define('getServiceItem', 'ajax', {
                        url: '/Api/ServiceItem',
                        dataType: 'json',
                        decoder: amplify.request.decoders.istStatusDecoder,
                        type: 'GET'
                    });
                    // Define request to delete Service Type
                    amplify.request.define('deleteServiceItem', 'ajax', {
                        url: '/Api/ServiceItem',
                        dataType: 'json',
                        decoder: amplify.request.decoders.istStatusDecoder,
                        type: 'DELETE'
                    });
                    // Define request to add/update  Service Type
                    amplify.request.define('saveServiceItem', 'ajax', {
                        url: '/Api/ServiceItem',
                        dataType: 'json',
                        decoder: amplify.request.decoders.istStatusDecoder,
                        type: 'POST'
                    });
                    //Service Item base Data
                    amplify.request.define('getServiceItemBaseData', 'ajax', {
                        url: '/Api/ServiceItemBase',
                        dataType: 'json',
                        decoder: amplify.request.decoders.istStatusDecoder,
                        type: 'GET'
                    });

                    isInitialized = true;
                }
            },
            // Get Sub Service Item
            getServiceItem = function (params, callbacks) {
                return amplify.request({
                    resourceId: 'getServiceItem',
                    success: callbacks.success,
                    error: callbacks.error,
                    data: params
                });
            },
             
            //add-update Service Type
            saveServiceItem = function (params, callbacks) {
                return amplify.request({
                    resourceId: 'saveServiceItem',
                    success: callbacks.success,
                    error: callbacks.error,
                    data: params
                });
            },
            //delete Service Item
            deleteServiceItem = function (params, callbacks) {
                return amplify.request({
                    resourceId: 'deleteServiceItem',
                    success: callbacks.success,
                    error: callbacks.error,
                    data: params
                });
            },

            //  Service Item Base Data
            getServiceItemBaseData = function (params, callbacks) {
                initialize();
                return amplify.request({
                    resourceId: 'getServiceItemBaseData',
                    success: callbacks.success,
                    error: callbacks.error,
                    data: params
                });
            };

      
        return {
            saveServiceItem: saveServiceItem,
            getServiceItem: getServiceItem,
            deleteServiceItem: deleteServiceItem,
            getServiceItemBaseData: getServiceItemBaseData

        };
    })();
    return dataService;
}); 