/*
    Data service module with ajax calls to the server
*/
define("maintenanceTypeGroup/maintenanceTypeGroup.dataservice", function () {

    // Data service for forecast 
    var dataService = (function () {
        var
            // True if initialized
            isInitialized = false,
            // Initialize
            initialize = function() {
                if (!isInitialized) {
                    // Define request to get Maintenece Type Groups
                    amplify.request.define('getMainteneceTypeGroups', 'ajax', {
                        url: '/Api/MainteneceTypeGroup',
                        dataType: 'json',
                        decoder: amplify.request.decoders.istStatusDecoder,
                        type: 'GET'
                    });
                    // Define request to delete Maintenece Type
                    amplify.request.define('deleteMainteneceTypeGroup', 'ajax', {
                        url: '/Api/MainteneceTypeGroup',
                        dataType: 'json',
                        decoder: amplify.request.decoders.istStatusDecoder,
                        type: 'DELETE'
                    });
                    // Define request to add/update Maintenece Type
                    amplify.request.define('saveMainteneceTypeGroup', 'ajax', {
                        url: '/Api/MainteneceTypeGroup',
                        dataType: 'json',
                        decoder: amplify.request.decoders.istStatusDecoder,
                        type: 'POST'
                    });
                    isInitialized = true;
                }
            },
            // Get Maintenece Types
            getMainteneceTypeGroups = function (params, callbacks) {
                initialize();
                return amplify.request({
                    resourceId: 'getMainteneceTypeGroups',
                    success: callbacks.success,
                    error: callbacks.error,
                    data: params
                });
            },
            //add-update Maintenece Type
            saveMainteneceTypeGroup = function (params, callbacks) {
                return amplify.request({
                    resourceId: 'saveMainteneceTypeGroup',
                    success: callbacks.success,
                    error: callbacks.error,
                    data: params
                });
            },
            //delete Maintenece Type
            deleteMainteneceTypeGroup = function (params, callbacks) {
                return amplify.request({
                    resourceId: 'deleteMainteneceTypeGroup',
                    success: callbacks.success,
                    error: callbacks.error,
                    data: params
                });
            };
        return {
            saveMainteneceTypeGroup: saveMainteneceTypeGroup,
            getMainteneceTypeGroups: getMainteneceTypeGroups,
            deleteMainteneceTypeGroup: deleteMainteneceTypeGroup,

        };
    })();
    return dataService;
});