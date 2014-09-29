/*
    Data service module with ajax calls to the server
*/
define("vehicleCheckList/vehicleCheckList.dataservice", function () {

    // Data service for forecast 
    var dataService = (function () {
        var
            // True if initialized
            isInitialized = false,
            // Initialize
            initialize = function() {
                if (!isInitialized) {
                    // Define request to get Vehicle Check Lists 
                    amplify.request.define('getVehicleCheckList', 'ajax', {
                        url: ist.siteUrl + '/Api/VehicleCheckList',
                        dataType: 'json',
                        decoder: amplify.request.decoders.istStatusDecoder,
                        type: 'GET'
                    });
                    // Define request to delete Vehicle CheckList
                    amplify.request.define('deleteVehicleCheckList', 'ajax', {
                        url: ist.siteUrl + '/Api/VehicleCheckList',
                        dataType: 'json',
                        decoder: amplify.request.decoders.istStatusDecoder,
                        type: 'DELETE'
                    });
                    // Define request to add/update Vehicle CheckList
                    amplify.request.define('saveVehicleCheckList', 'ajax', {
                        url: ist.siteUrl + '/Api/VehicleCheckList',
                        dataType: 'json',
                        decoder: amplify.request.decoders.istStatusDecoder,
                        type: 'POST'
                    });


                    isInitialized = true;
                }
            },
            // Get Vehicle CheckLists
            getVehicleCheckList = function (params, callbacks) {
                initialize();
                return amplify.request({
                    resourceId: 'getVehicleCheckList',
                    success: callbacks.success,
                    error: callbacks.error,
                    data: params
                });
            },
            //add-update Vehicle CheckList
            saveVehicleCheckList = function (params, callbacks) {
                return amplify.request({
                    resourceId: 'saveVehicleCheckList',
                    success: callbacks.success,
                    error: callbacks.error,
                    data: params
                });
            },
            //delete Vehicle CheckList
            deleteVehicleCheckList = function (params, callbacks) {
                return amplify.request({
                    resourceId: 'deleteVehicleCheckList',
                    success: callbacks.success,
                    error: callbacks.error,
                    data: params
                });
            };
        return {
            saveVehicleCheckList: saveVehicleCheckList,
            getVehicleCheckList: getVehicleCheckList,
            deleteVehicleCheckList: deleteVehicleCheckList,
        };
    })();
    return dataService;
});