/*
    Data service module with ajax calls to the server
*/
define("document/document.dataservice", function () {

    // Data service for forecast 
    var dataService = (function () {
        var
            // True if initialized
            isInitialized = false,
            // Initialize
            initialize = function() {
                if (!isInitialized) {


                    // Define request to get Documents 
                    amplify.request.define('getDocuments', 'ajax', {
                        url: ist.siteUrl + '/Api/Document',
                        dataType: 'json',
                        decoder: amplify.request.decoders.istStatusDecoder,
                        type: 'GET'
                    });
                    // Define request to delete Document
                    amplify.request.define('deleteDocument', 'ajax', {
                        url: ist.siteUrl + '/Api/Document',
                        dataType: 'json',
                        decoder: amplify.request.decoders.istStatusDecoder,
                        type: 'DELETE'
                    });
                    // Define request to add/update Document
                    amplify.request.define('saveDocument', 'ajax', {
                        url: ist.siteUrl + '/Api/Document',
                        dataType: 'json',
                        decoder: amplify.request.decoders.istStatusDecoder,
                        type: 'POST'
                    });

                    //Document base Data
                    amplify.request.define('getDocumentBaseData', 'ajax', {
                        url: ist.siteUrl + '/Api/DocumentBase',
                        dataType: 'json',
                        decoder: amplify.request.decoders.istStatusDecoder,
                        type: 'GET'
                    });

                    isInitialized = true;
                }
            },
            // Get Documents
            getDocuments = function (params, callbacks) {
                return amplify.request({
                    resourceId: 'getDocuments',
                    success: callbacks.success,
                    error: callbacks.error,
                    data: params
                });
            },
            //add-update Document.
            saveDocument = function (params, callbacks) {
                return amplify.request({
                    resourceId: 'saveDocument',
                    success: callbacks.success,
                    error: callbacks.error,
                    data: params
                });
            },
            //delete Document.
            deleteDocument = function (params, callbacks) {
                return amplify.request({
                    resourceId: 'deleteDocument',
                    success: callbacks.success,
                    error: callbacks.error,
                    data: params
                });
            },


            //  Document Base Data
            getDocumentBaseData = function (params, callbacks) {
                initialize();
                return amplify.request({
                    resourceId: 'getDocumentBaseData',
                    success: callbacks.success,
                    error: callbacks.error,
                    data: params
                });
            };
      
        return {
            getDocumentBaseData: getDocumentBaseData,
            saveDocument: saveDocument,
            getDocuments: getDocuments,
            deleteDocument: deleteDocument,

        };
    })();
    return dataService;
});