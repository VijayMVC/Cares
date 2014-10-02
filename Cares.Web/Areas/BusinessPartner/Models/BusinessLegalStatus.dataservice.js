/*
    Data service module with ajax calls to the server
*/
define("businessLegalStatus/businessLegalStatus.dataservice", function () {

    // Data service for forecast 
    var dataService = (function () {
        var
            // True if initialized
            isInitialized = false,
            // Initialize
            initialize = function() {
                if (!isInitialized) {
                    // Define request to get Business Legal Statuses
                    amplify.request.define('getBusinessLegalStatuses', 'ajax', {
                        url: ist.siteUrl + '/Api/BusinessLegalStatus',
                        dataType: 'json',
                        decoder: amplify.request.decoders.istStatusDecoder,
                        type: 'GET'
                    });
                    // Define request to delete Business Legal Status
                    amplify.request.define('deleteBusinessLegalStatus', 'ajax', {
                        url: ist.siteUrl + '/Api/BusinessLegalStatus',
                        dataType: 'json',
                        decoder: amplify.request.decoders.istStatusDecoder,
                        type: 'DELETE'
                    });
                    // Define request to add/update Business Legal Status
                    amplify.request.define('saveBusinessLegalStatus', 'ajax', {
                        url: ist.siteUrl + '/Api/BusinessLegalStatus',
                        dataType: 'json',
                        decoder: amplify.request.decoders.istStatusDecoder,
                        type: 'POST'
                    });
                    isInitialized = true;
                }
            },
            // Get Business Legal Statuses
            getBusinessLegalStatuses = function (params, callbacks) {
                initialize();
                return amplify.request({
                    resourceId: 'getBusinessLegalStatuses',
                    success: callbacks.success,
                    error: callbacks.error,
                    data: params
                });
            },
            //add-update Business Legal Status
            saveBusinessLegalStatus = function (params, callbacks) {
                return amplify.request({
                    resourceId: 'saveBusinessLegalStatus',
                    success: callbacks.success,
                    error: callbacks.error,
                    data: params
                });
            },
            //delete Business Legal Status
            deleteBusinessLegalStatus = function (params, callbacks) {
                return amplify.request({
                    resourceId: 'deleteBusinessLegalStatus',
                    success: callbacks.success,
                    error: callbacks.error,
                    data: params
                });
            };
        return {
            saveBusinessLegalStatus: saveBusinessLegalStatus,
            getBusinessLegalStatuses: getBusinessLegalStatuses,
            deleteBusinessLegalStatus: deleteBusinessLegalStatus,
        };
    })();
    return dataService;
});