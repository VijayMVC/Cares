/*
    Data service module with ajax calls to the server
*/
define("region/region.dataservice", function () {

    // Data service for forecast 
    var dataService = (function () {
        var
            // True if initialized
            isInitialized = false,
            // Initialize
            initialize = function() {
                if (!isInitialized) {


                    // Define request to get Regions 
                    amplify.request.define('getRegions', 'ajax', {
                        url: '/Api/Region',
                        dataType: 'json',
                        decoder: amplify.request.decoders.istStatusDecoder,
                        type: 'GET'
                    });
                    // Define request to delete Region
                    amplify.request.define('deleteRegion', 'ajax', {
                        url: '/Api/Region',
                        dataType: 'json',
                        decoder: amplify.request.decoders.istStatusDecoder,
                        type: 'DELETE'
                    });
                    // Define request to add/update Regio
                    amplify.request.define('saveRegion', 'ajax', {
                        url: '/Api/Region',
                        dataType: 'json',
                        decoder: amplify.request.decoders.istStatusDecoder,
                        type: 'POST'
                    });

                    //Region base Data
                    amplify.request.define('getRegionBaseData', 'ajax', {
                        url: '/Api/RegionBase',
                        dataType: 'json',
                        decoder: amplify.request.decoders.istStatusDecoder,
                        type: 'GET'
                    });

                    isInitialized = true;
                }
            },
            // Get Regions
            getRegions = function(params, callbacks) {
                return amplify.request({
                    resourceId: 'getRegions',
                    success: callbacks.success,
                    error: callbacks.error,
                    data: params
                });
            },
            //add-update Region.
            saveRegion = function(params, callbacks) {
                return amplify.request({
                    resourceId: 'saveRegion',
                    success: callbacks.success,
                    error: callbacks.error,
                    data: params
                });
            },
            //delete Region.
            deleteRegion = function (params, callbacks) {
                return amplify.request({
                    resourceId: 'deleteRegion',
                    success: callbacks.success,
                    error: callbacks.error,
                    data: params
                });
            },


            //  Region Base Data
            getRegionBaseData = function (params, callbacks) {
                initialize();
                return amplify.request({
                    resourceId: 'getRegionBaseData',
                    success: callbacks.success,
                    error: callbacks.error,
                    data: params
                });
            };
      
        return {
            getRegionBaseData: getRegionBaseData,
            saveRegion: saveRegion,
            getRegions: getRegions,
            deleteRegion: deleteRegion,

        };
    })();
    return dataService;
});