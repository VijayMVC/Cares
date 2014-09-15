/*
    Data service module with ajax calls to the server
*/
define("subRegion/subRegion.dataservice", function () {

    // Data service for forecast 
    var dataService = (function () {
        var
            // True if initialized
            isInitialized = false,
            // Initialize
            initialize = function() {
                if (!isInitialized) {


                    // Define request to get Sub Regions 
                    amplify.request.define('getSubRegions', 'ajax', {
                        url: '/Api/SubRegion',
                        dataType: 'json',
                        decoder: amplify.request.decoders.istStatusDecoder,
                        type: 'GET'
                    });
                    // Define request to delete Sub Region
                    amplify.request.define('deleteSubRegion', 'ajax', {
                        url: '/Api/SubRegion',
                        dataType: 'json',
                        decoder: amplify.request.decoders.istStatusDecoder,
                        type: 'DELETE'
                    });
                    // Define request to add/update Sub Region
                    amplify.request.define('saveSubRegion', 'ajax', {
                        url: '/Api/SubRegion',
                        dataType: 'json',
                        decoder: amplify.request.decoders.istStatusDecoder,
                        type: 'POST'
                    });

                    //Sub Region base Data
                    amplify.request.define('getSubRegionBaseData', 'ajax', {
                        url: '/Api/SubRegionBase',
                        dataType: 'json',
                        decoder: amplify.request.decoders.istStatusDecoder,
                        type: 'GET'
                    });

                    isInitialized = true;
                }
            },
            // Get Sub Regions
            getSubRegions = function(params, callbacks) {
                initialize();
                return amplify.request({
                    resourceId: 'getSubRegions',
                    success: callbacks.success,
                    error: callbacks.error,
                    data: params
                });
            },
            //add-update Sub Region.
            saveSubRegion = function(params, callbacks) {
                return amplify.request({
                    resourceId: 'saveSubRegion',
                    success: callbacks.success,
                    error: callbacks.error,
                    data: params
                });
            },
            //delete Sub Region.
            deleteSubRegion = function (params, callbacks) {
                debugger;
                return amplify.request({
                    resourceId: 'deleteSubRegion',
                    success: callbacks.success,
                    error: callbacks.error,
                    data: params
                });
            },


            // Sub Region Base Data
            getSubRegionBaseData = function (params, callbacks) {
                initialize();
                return amplify.request({
                    resourceId: 'getSubRegionBaseData',
                    success: callbacks.success,
                    error: callbacks.error,
                    data: params
                });
            };
      
        return {
            getSubRegionBaseData: getSubRegionBaseData,
            saveSubRegion: saveSubRegion,
            getSubRegions: getSubRegions,
            deleteSubRegion: deleteSubRegion,

        };
    })();
    return dataService;
});