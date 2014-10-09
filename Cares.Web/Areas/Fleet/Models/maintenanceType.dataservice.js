/*
    Data service module with ajax calls to the server
*/
define("maintenanceType/maintenanceType.dataservice", function () {

    // Data service for forecast 
    var dataService = (function () {
        var
            // True if initialized
            isInitialized = false,
            // Initialize
            initialize = function() {
                if (!isInitialized) {


                    // Define request to get Maintenance Types 
                    amplify.request.define('getMaintenanceTypes', 'ajax', {
                        url: ist.siteUrl + '/Api/MaintenanceType',
                        dataType: 'json',
                        decoder: amplify.request.decoders.istStatusDecoder,
                        type: 'GET'
                    });
                    // Define request to delete Maintenance Type
                    amplify.request.define('deleteMaintenanceType', 'ajax', {
                        url: ist.siteUrl + '/Api/MaintenanceType',
                        dataType: 'json',
                        decoder: amplify.request.decoders.istStatusDecoder,
                        type: 'DELETE'
                    });
                    // Define request to add/update Maintenance Type
                    amplify.request.define('saveMaintenanceType', 'ajax', {
                        url: ist.siteUrl + '/Api/MaintenanceType',
                        dataType: 'json',
                        decoder: amplify.request.decoders.istStatusDecoder,
                        type: 'POST'
                    });

                    //Maintenance Type base Data
                    amplify.request.define('getMaintenanceTypeBaseData', 'ajax', {
                        url: ist.siteUrl + '/Api/MaintenanceTypeBase',
                        dataType: 'json',
                        decoder: amplify.request.decoders.istStatusDecoder,
                        type: 'GET'
                    });

                    isInitialized = true;
                }
            },
            // Get Maintenance Types
            getMaintenanceTypes = function (params, callbacks) {
                return amplify.request({
                    resourceId: 'getMaintenanceTypes',
                    success: callbacks.success,
                    error: callbacks.error,
                    data: params
                });
            },
            //add-update Maintenance Type.
            saveMaintenanceType = function (params, callbacks) {
                return amplify.request({
                    resourceId: 'saveMaintenanceType',
                    success: callbacks.success,
                    error: callbacks.error,
                    data: params
                });
            },
            //delete Maintenance Type.
            deleteMaintenanceType = function (params, callbacks) {
                return amplify.request({
                    resourceId: 'deleteMaintenanceType',
                    success: callbacks.success,
                    error: callbacks.error,
                    data: params
                });
            },

            //  Maintenance Type Base Data
            getMaintenanceTypeBaseData = function (params, callbacks) {
                initialize();
                return amplify.request({
                    resourceId: 'getMaintenanceTypeBaseData',
                    success: callbacks.success,
                    error: callbacks.error,
                    data: params
                });
            };
      
        return {
            getMaintenanceTypeBaseData: getMaintenanceTypeBaseData,
            saveMaintenanceType: saveMaintenanceType,
            getMaintenanceTypes: getMaintenanceTypes,
            deleteMaintenanceType: deleteMaintenanceType,

        };
    })();
    return dataService;
});