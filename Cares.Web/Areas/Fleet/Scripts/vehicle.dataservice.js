/*
    Data service module with ajax calls to the server
*/
define("vehicle/vehicle.dataservice", function () {

    // Data service for forecast 
    var dataService = (function () {
        var // True if initialized
            isInitialized = false,
            // Initializep
            initialize = function () {
                if (!isInitialized) {

                    // Define request to get Vehicle base data 
                    amplify.request.define('getVehicleBase', 'ajax', {
                        url: '/Api/VehicleBase',
                        dataType: 'json',
                        type: 'GET'
                    });
                    // Define request to get Vehicles  
                    amplify.request.define('getVehicles', 'ajax', {
                        url: '/Api/Vehicle',
                        dataType: 'json',
                        type: 'GET'
                    });
                    // Define request to save Vehicle
                    amplify.request.define('saveVehicle', 'ajax', {
                        url: '/Api/Vehicle',
                        dataType: 'json',
                        type: 'PUT'
                    });

                    // Define request to get Vehicle
                    amplify.request.define('getVehicleDetailById', 'ajax', {
                        url: '/Api/GetVehicleDetailData',
                        dataType: 'json',
                        type: 'GET'
                    });
                    // Define request to delete Vehicle
                    amplify.request.define('deleteVehicle', 'ajax', {
                        url: '/Api/Vehicle',
                        dataType: 'json',
                        type: 'DELETE'
                    });
                    isInitialized = true;
                }
            },
            // Get Vehicle base
            getVehicleBase = function (callbacks) {
                initialize();
                return amplify.request({
                    resourceId: 'getVehicleBase',
                    success: callbacks.success,
                    error: callbacks.error,
                });
            },
            // Get Vehicle List
            getVehicles = function (params, callbacks) {
                initialize();
                return amplify.request({
                    resourceId: 'getVehicles',
                    success: callbacks.success,
                    error: callbacks.error,
                    data: params
                });
            },

        // Create Vehicle
        saveVehicle = function (param, callbacks) {
            initialize();
            return amplify.request({
                resourceId: 'saveVehicle',
                success: callbacks.success,
                error: callbacks.error,
                data: param
            });
        },
          // Get Vehicle Data By Vehicle id 
        getVehicleDetailById = function (params, callbacks) {
            initialize();
            return amplify.request({
                resourceId: 'getVehicleDetailById',
                success: callbacks.success,
                error: callbacks.error,
                data: params
            });
        },
        // Delete
        deleteVehicle = function (param, callbacks) {
            initialize();
            return amplify.request({
                resourceId: 'deleteVehicle',
                success: callbacks.success,
                error: callbacks.error,
                data: param
            });
        };

        return {
            getVehicleBase: getVehicleBase,
            getVehicles: getVehicles,
            saveVehicle: saveVehicle,
            getVehicleDetailById: getVehicleDetailById,
            deleteVehicle: deleteVehicle

        };
    })();

    return dataService;
});