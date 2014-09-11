/*
    Data service module with ajax calls to the server
*/
define("businessSeg/businessSeg.dataservice", function () {

    // Data service for forecast 
    var dataService = (function () {
        var
            // True if initialized
            isInitialized = false,
            // Initialize
            initialize = function() {
                if (!isInitialized) {
                    // Define request to get OrganizationGroup 
                    amplify.request.define('getBusinessSeg', 'ajax', {
                        url: '/Api/BusinessSegment',
                        dataType: 'json',
                        decoder: amplify.request.decoders.istStatusDecoder,
                        type: 'GET'
                    });
                    // Define request to delete OrganizationGroup
                    amplify.request.define('deleteWorkPlaceType', 'ajax', {
                        url: '/Api/WorkPlaceType',
                        dataType: 'json',
                        decoder: amplify.request.decoders.istStatusDecoder,
                        type: 'DELETE'
                    });
                    // Define request to add/update OrganizationGroup
                    amplify.request.define('saveWorkPlaceType', 'ajax', {
                        url: '/Api/WorkPlaceType',
                        dataType: 'json',
                        decoder: amplify.request.decoders.istStatusDecoder,
                        type: 'POST'
                    });

                   
                    isInitialized = true;
                }
            },
            // Get Business Seg.
            getBusinessSeg = function (params, callbacks) {
                initialize();
                return amplify.request({
                    resourceId: 'getBusinessSeg',
                    success: callbacks.success,
                    error: callbacks.error,
                    data: params
                });
            },
            //add-update OrganizationGroup
            saveWorkPlaceType = function(params, callbacks) {
                return amplify.request({
                    resourceId: 'saveWorkPlaceType',
                    success: callbacks.success,
                    error: callbacks.error,
                    data: params
                });
            },
            //delete OrganizationGroup
            deleteWorkPlaceType = function (params, callbacks) {
                debugger;
                return amplify.request({
                    resourceId: 'deleteWorkPlaceType',
                    success: callbacks.success,
                    error: callbacks.error,
                    data: params
                });
            };
      
        return {
            saveWorkPlaceType: saveWorkPlaceType,
            getBusinessSeg: getBusinessSeg,
            deleteWorkPlaceType: deleteWorkPlaceType,

        };
    })();
    return dataService;
});