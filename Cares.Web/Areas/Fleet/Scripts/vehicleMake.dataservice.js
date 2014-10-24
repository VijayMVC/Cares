/*
    Data service module with ajax calls to the server
*/
define("vehicleMake/vehicleMake.dataservice", function () {

    // Data service for forecast 
    var dataService = (function () {
        var
            // True if initialized
            isInitialized = false,
            // Initialize
            initialize = function() {
                if (!isInitialized) {
                    // Define request to get Vehicle Makes
                    amplify.request.define('getVehicleMakes', 'ajax', {
                        url: ist.siteUrl + '/Api/VehicleMake',
                        dataType: 'json',
                        decoder: amplify.request.decoders.istStatusDecoder,
                        type: 'GET'
                    });
                    // Define request to delete Vehicle Make
                    amplify.request.define('deleteVehicleMake', 'ajax', {
                        url: ist.siteUrl + '/Api/VehicleMake',
                        dataType: 'json',
                        decoder: amplify.request.decoders.istStatusDecoder,
                        type: 'DELETE'
                    });
                    // Define request to add/update Vehicle Makes
                    amplify.request.define('saveVehicleMake', 'ajax', {
                        url: ist.siteUrl + '/Api/VehicleMake',
                        dataType: 'json',
                        decoder: amplify.request.decoders.istStatusDecoder,
                        type: 'POST'
                    });
                    isInitialized = true;
                }
            },
            // Get Vehicle Makes
            getVehicleMakes = function (params, callbacks) {
                initialize();
                return amplify.request({
                    resourceId: 'getVehicleMakes',
                    success: callbacks.success,
                    error: callbacks.error,
                    data: params
                });
            },
            //add-update Vehicle Make
            saveVehicleMake = function (params, callbacks) {
                return amplify.request({
                    resourceId: 'saveVehicleMake',
                    success: callbacks.success,
                    error: callbacks.error,
                    data: params
                });
            },
            //delete Document Vehicle Make
            deleteVehicleMake = function (params, callbacks) {
                return amplify.request({
                    resourceId: 'deleteVehicleMake',
                    success: callbacks.success,
                    error: callbacks.error,
                    data: params
                });
            };
        return {
            saveVehicleMake: saveVehicleMake,
            getVehicleMakes: getVehicleMakes,
            deleteVehicleMake: deleteVehicleMake,

        };
    })();
    return dataService;
});