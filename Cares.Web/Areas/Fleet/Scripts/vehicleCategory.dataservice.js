/*
    Data service module with ajax calls to the server
*/
define("vehicleCategory/vehicleCategory.dataservice", function () {

    // Data service for forecast 
    var dataService = (function () {
        var
            // True if initialized
            isInitialized = false,
            // Initialize
            initialize = function() {
                if (!isInitialized) {


                    // Define request to get  Vehicle Categories
                    amplify.request.define('getVehicleCategories', 'ajax', {
                        url: ist.siteUrl + '/Api/VehicleCategory',
                        dataType: 'json',
                        decoder: amplify.request.decoders.istStatusDecoder,
                        type: 'GET'
                    });
                    // Define request to delete Vehicle Category
                    amplify.request.define('deleteVehicleCategory', 'ajax', {
                        url: ist.siteUrl + '/Api/VehicleCategory',
                        dataType: 'json',
                        decoder: amplify.request.decoders.istStatusDecoder,
                        type: 'DELETE'
                    });
                    // Define request to add/update Vehicle Category
                    amplify.request.define('saveVehicleCategory', 'ajax', {
                        url: ist.siteUrl + '/Api/VehicleCategory',
                        dataType: 'json',
                        decoder: amplify.request.decoders.istStatusDecoder,
                        type: 'POST'
                    });


                    isInitialized = true;
                }
            },
            // Get Vehicle Categories
            getVehicleCategories = function (params, callbacks) {
                initialize();
                return amplify.request({
                    resourceId: 'getVehicleCategories',
                    success: callbacks.success,
                    error: callbacks.error,
                    data: params
                });
            },
            //add-update Vehicle Category
            saveVehicleCategory = function (params, callbacks) {
                return amplify.request({
                    resourceId: 'saveVehicleCategory',
                    success: callbacks.success,
                    error: callbacks.error,
                    data: params
                });
            },
            //delete Vehicle Category
            deleteVehicleCategory = function (params, callbacks) {
                return amplify.request({
                    resourceId: 'deleteVehicleCategory',
                    success: callbacks.success,
                    error: callbacks.error,
                    data: params
                });
            };
        return {
            saveVehicleCategory: saveVehicleCategory,
            getVehicleCategories: getVehicleCategories,
            deleteVehicleCategory: deleteVehicleCategory,

        };
    })();
    return dataService;
});