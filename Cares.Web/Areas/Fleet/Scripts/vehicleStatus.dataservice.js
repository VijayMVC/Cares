/*
    Data service module with ajax calls to the server
*/
define("vehicleStatus/vehicleStatus.dataservice", function () {

    // Data service for forecast 
    var dataService = (function () {
        var
            // True if initialized
            isInitialized = false,
            // Initialize
            initialize = function() {
                if (!isInitialized) {
                    // Define request to get  Vehicle Statuses
                    amplify.request.define('getVehicleStatuses', 'ajax', {
                        url: ist.siteUrl + '/Api/VehicleStatus',
                        dataType: 'json',
                        decoder: amplify.request.decoders.istStatusDecoder,
                        type: 'GET'
                    });
                    // Define request to delete  Vehicle Status
                    amplify.request.define('deleteVehicleStatus', 'ajax', {
                        url: ist.siteUrl + '/Api/VehicleStatus',
                        dataType: 'json',
                        decoder: amplify.request.decoders.istStatusDecoder,
                        type: 'DELETE'
                    });
                    // Define request to add/update  Vehicle Status 
                    amplify.request.define('saveVehicleStatus', 'ajax', {
                        url: ist.siteUrl + '/Api/VehicleStatus',
                        dataType: 'json',
                        decoder: amplify.request.decoders.istStatusDecoder,
                        type: 'POST'
                    });
                    isInitialized = true;
                }
            },
            // Get  Vehicle Statuses
            getVehicleStatuses = function (params, callbacks) {
                initialize();
                return amplify.request({
                    resourceId: 'getVehicleStatuses',
                    success: callbacks.success,
                    error: callbacks.error,
                    data: params
                });
            },
            //add-update  Vehicle Status
            saveVehicleStatus = function (params, callbacks) {
                return amplify.request({
                    resourceId: 'saveVehicleStatus',
                    success: callbacks.success,
                    error: callbacks.error,
                    data: params
                });
            },
            //delete  Vehicle Status
            deleteVehicleStatus = function (params, callbacks) {
                return amplify.request({
                    resourceId: 'deleteVehicleStatus',
                    success: callbacks.success,
                    error: callbacks.error,
                    data: params
                });
            };
        return {
            saveVehicleStatus: saveVehicleStatus,
            getVehicleStatuses: getVehicleStatuses,
            deleteVehicleStatus: deleteVehicleStatus,

        };
    })();
    return dataService;
});