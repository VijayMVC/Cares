/*
    Data service module with ajax calls to the server
*/
define("area/area.dataservice", function () {

    // Data service for forecast 
    var dataService = (function () {
        var
            // True if initialized
            isInitialized = false,
            // Initialize
            initialize = function() {
                if (!isInitialized) {
                    // Define request to get Areas 
                    amplify.request.define('getAreas', 'ajax', {
                        url: ist.siteUrl + '/Api/Area',
                        dataType: 'json',
                        decoder: amplify.request.decoders.istStatusDecoder,
                        type: 'GET'
                    });
                    // Define request to delete Area
                    amplify.request.define('deleteArea', 'ajax', {
                        url: ist.siteUrl + '/Api/Area',
                        dataType: 'json',
                        decoder: amplify.request.decoders.istStatusDecoder,
                        type: 'DELETE'
                    });
                    // Define request to add/update Area
                    amplify.request.define('saveArea', 'ajax', {
                        url: ist.siteUrl + '/Api/Area',
                        dataType: 'json',
                        decoder: amplify.request.decoders.istStatusDecoder,
                        type: 'POST'
                    });

                    //Area base Data
                    amplify.request.define('getAreaBaseData', 'ajax', {
                        url: ist.siteUrl + '/Api/AreaBase',
                        dataType: 'json',
                        decoder: amplify.request.decoders.istStatusDecoder,
                        type: 'GET'
                    });

                    isInitialized = true;
                }
            },
            // Get Areas
            getAreas = function(params, callbacks) {
                initialize();
                return amplify.request({
                    resourceId: 'getAreas',
                    success: callbacks.success,
                    error: callbacks.error,
                    data: params
                });
            },
            //add-update Areas.
            saveArea = function(params, callbacks) {
                return amplify.request({
                    resourceId: 'saveArea',
                    success: callbacks.success,
                    error: callbacks.error,
                    data: params
                });
            },
            //delete Area.
            deleteArea = function (params, callbacks) {
                return amplify.request({
                    resourceId: 'deleteArea',
                    success: callbacks.success,
                    error: callbacks.error,
                    data: params
                });
            },


            //  Area Base Data
            getAreaBaseData = function (params, callbacks) {
                initialize();
                return amplify.request({
                    resourceId: 'getAreaBaseData',
                    success: callbacks.success,
                    error: callbacks.error,
                    data: params
                });
            };
      
        return {
            getAreaBaseData: getAreaBaseData,
            saveArea: saveArea,
            getAreas: getAreas,
            deleteArea: deleteArea,
        };
    })();
    return dataService;
});