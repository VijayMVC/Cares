/*
    Data service module with ajax calls to the server
*/
define("nRTType/nRTType.dataservice", function () {

    // Data service for forecast 
    var dataService = (function () {
        var
            // True if initialized
            isInitialized = false,
            // Initialize
            initialize = function() {
                if (!isInitialized) {


                    // Define request to get Nrt Types
                    amplify.request.define('getNrtTypes', 'ajax', {
                        url: '/Api/NrtType',
                        dataType: 'json',
                        decoder: amplify.request.decoders.istStatusDecoder,
                        type: 'GET'
                    });
                    // Define request to delete Nrt Type
                    amplify.request.define('deleteNrtType', 'ajax', {
                        url: '/Api/NrtType',
                        dataType: 'json',
                        decoder: amplify.request.decoders.istStatusDecoder,
                        type: 'DELETE'
                    });
                    // Define request to add/update Nrt Type
                    amplify.request.define('saveNrtType', 'ajax', {
                        url: '/Api/NrtType',
                        dataType: 'json',
                        decoder: amplify.request.decoders.istStatusDecoder,
                        type: 'POST'
                    });

                    //Nrt Type base Data
                    amplify.request.define('getNrtTypeBaseData', 'ajax', {
                        url: '/Api/NrtTypeBase',
                        dataType: 'json',
                        decoder: amplify.request.decoders.istStatusDecoder,
                        type: 'GET'
                    });

                    isInitialized = true;
                }
            },
            // Get Nrt Types
            getNrtTypes = function (params, callbacks) {
                initialize();
                return amplify.request({
                    resourceId: 'getNrtTypes',
                    success: callbacks.success,
                    error: callbacks.error,
                    data: params
                });
            },
            //add-update Nrt Type
            saveNrtType = function (params, callbacks) {
                return amplify.request({
                    resourceId: 'saveNrtType',
                    success: callbacks.success,
                    error: callbacks.error,
                    data: params
                });
            },
            //delete Nrt Type
            deleteNrtType = function (params, callbacks) {
                return amplify.request({
                    resourceId: 'deleteNrtType',
                    success: callbacks.success,
                    error: callbacks.error,
                    data: params
                });
            },


            // Nrt Type Base Data
            getNrtTypeBaseData = function (params, callbacks) {
                initialize();
                return amplify.request({
                    resourceId: 'getNrtTypeBaseData',
                    success: callbacks.success,
                    error: callbacks.error,
                    data: params
                });
            };
      
        return {
            getNrtTypeBaseData: getNrtTypeBaseData,
            saveNrtType: saveNrtType,
            getNrtTypes: getNrtTypes,
            deleteNrtType: deleteNrtType,

        };
    })();
    return dataService;
});