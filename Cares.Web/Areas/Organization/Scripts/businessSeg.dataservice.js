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
                    // Define request to delete Business Segment
                    amplify.request.define('deleteBusinessSeg', 'ajax', {
                        url: '/Api/BusinessSegment',
                        dataType: 'json',
                        decoder: amplify.request.decoders.istStatusDecoder,
                        type: 'DELETE'
                    });
                    // Define request to add/update saveBusinessSegment
                    amplify.request.define('saveBusinessSeg', 'ajax', {
                        url: '/Api/BusinessSegment',
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
            //add-update BusinessSeg.
            saveBusinessSeg = function (params, callbacks) {
                return amplify.request({
                    resourceId: 'saveBusinessSeg',
                    success: callbacks.success,
                    error: callbacks.error,
                    data: params
                });
            },
            //delete BusinessSeg.
            deleteBusinessSeg = function (params, callbacks) {
                debugger;
                return amplify.request({
                    resourceId: 'deleteBusinessSeg',
                    success: callbacks.success,
                    error: callbacks.error,
                    data: params
                });
            };
      
        return {
            saveBusinessSegment: saveBusinessSeg,
            getBusinessSeg: getBusinessSeg,
            deleteBusinessSegment: deleteBusinessSeg,

        };
    })();
    return dataService;
});