/*
    Data service module with ajax calls to the server
*/
define("documentGroup/documentGroup.dataservice", function () {

    // Data service for forecast 
    var dataService = (function () {
        var
            // True if initialized
            isInitialized = false,
            // Initialize
            initialize = function() {
                if (!isInitialized) {
                    // Define request to get Document Groups
                    amplify.request.define('getDocumentGroups', 'ajax', {
                        url: ist.siteUrl + '/Api/DocumentGroup',
                        dataType: 'json',
                        decoder: amplify.request.decoders.istStatusDecoder,
                        type: 'GET'
                    });
                    // Define request to delete Document Group
                    amplify.request.define('deleteDocumentGroup', 'ajax', {
                        url: ist.siteUrl + '/Api/DocumentGroup',
                        dataType: 'json',
                        decoder: amplify.request.decoders.istStatusDecoder,
                        type: 'DELETE'
                    });
                    // Define request to add/update Document Group
                    amplify.request.define('saveDocumentGroup', 'ajax', {
                        url: ist.siteUrl + '/Api/DocumentGroup',
                        dataType: 'json',
                        decoder: amplify.request.decoders.istStatusDecoder,
                        type: 'POST'
                    });
                    isInitialized = true;
                }
            },
            // Get Document Groups
            getDocumentGroups = function (params, callbacks) {
                initialize();
                return amplify.request({
                    resourceId: 'getDocumentGroups',
                    success: callbacks.success,
                    error: callbacks.error,
                    data: params
                });
            },
            //add-update Document Group.
            saveDocumentGroup = function (params, callbacks) {
                return amplify.request({
                    resourceId: 'saveDocumentGroup',
                    success: callbacks.success,
                    error: callbacks.error,
                    data: params
                });
            },
            //delete Document Group.
            deleteDocumentGroup = function(params, callbacks) {
                return amplify.request({
                    resourceId: 'deleteDocumentGroup',
                    success: callbacks.success,
                    error: callbacks.error,
                    data: params
                });
            };
        return {
            saveDocumentGroup: saveDocumentGroup,
            getDocumentGroups: getDocumentGroups,
            deleteDocumentGroup: deleteDocumentGroup,

        };
    })();
    return dataService;
});