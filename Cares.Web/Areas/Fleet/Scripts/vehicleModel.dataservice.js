/*
    Data service module with ajax calls to the server
*/
define("vehicleModel/vehicleModel.dataservice", function () {

    // Data service for forecast 
    var dataService = (function () {
        var
            // True if initialized
            isInitialized = false,
            // Initialize
            initialize = function() {
                if (!isInitialized) {
                    // Define request to get  Vehicle Models
                    amplify.request.define('getVehicleModels', 'ajax', {
                        url: '/Api/VehicleModel',
                        dataType: 'json',
                        decoder: amplify.request.decoders.istStatusDecoder,
                        type: 'GET'
                    });
                    // Define request to delete  Vehicle Model
                    amplify.request.define('deleteVehicleModel', 'ajax', {
                        url: '/Api/VehicleModel',
                        dataType: 'json',
                        decoder: amplify.request.decoders.istStatusDecoder,
                        type: 'DELETE'
                    });
                    // Define request to add/update  Vehicle Model 
                    amplify.request.define('saveVehicleModel', 'ajax', {
                        url: '/Api/VehicleModel',
                        dataType: 'json',
                        decoder: amplify.request.decoders.istStatusDecoder,
                        type: 'POST'
                    });
                    isInitialized = true;
                }
            },
            // Get  Vehicle Models
            getVehicleModels = function (params, callbacks) {
                initialize();
                return amplify.request({
                    resourceId: 'getVehicleModels',
                    success: callbacks.success,
                    error: callbacks.error,
                    data: params
                });
            },
            //add-update  Vehicle Model
            saveVehicleModel = function (params, callbacks) {
                return amplify.request({
                    resourceId: 'saveVehicleModel',
                    success: callbacks.success,
                    error: callbacks.error,
                    data: params
                });
            },
            //delete  Vehicle Model
            deleteVehicleModel = function (params, callbacks) {
                return amplify.request({
                    resourceId: 'deleteVehicleModel',
                    success: callbacks.success,
                    error: callbacks.error,
                    data: params
                });
            };
        return {
            saveVehicleModel: saveVehicleModel,
            getVehicleModels: getVehicleModels,
            deleteVehicleModel: deleteVehicleModel,

        };
    })();
    return dataService;
});