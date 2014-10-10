/*
    Data service module with ajax calls to the server
*/
define("nRT/nRT.dataservice", function () {

    // Data service for forecast 
    var dataService = (function () {
        var // True if initialized
            isInitialized = false,
            // Initialize
            initialize = function () {
                if (!isInitialized) {

                    // Define request to get Non Revenue Ticket base data
                    amplify.request.define('getNRTBase', 'ajax', {
                        url: ist.siteUrl + '/Api/NRTBase',
                        dataType: 'json',
                        type: 'GET'
                    });
                    // Define request to Get Vehicles Detail 
                    amplify.request.define('getVehiclesDetail', 'ajax', {
                        url: ist.siteUrl + '/Api/GetVehiclesForNRT',
                        dataType: 'json',
                        decoder: amplify.request.decoders.istStatusDecoder,
                        type: 'POST'
                    });

                    // Define request to Get Chauffeurs
                    amplify.request.define('getChauffers', 'ajax', {
                        url: ist.siteUrl + '/Api/GetChaufferForNRT',
                        dataType: 'json',
                        decoder: amplify.request.decoders.istStatusDecoder,
                        type: 'POST'
                    });
                    // Define request to Get Additional Charge
                    amplify.request.define('getAdditionlCharge', 'ajax', {
                        url: ist.siteUrl + '/Api/GetAdditionalChargeForNrt',
                        dataType: 'json',
                        decoder: amplify.request.decoders.istStatusDecoder,
                        type: 'POST'
                    });
                    // Define request to save NRT
                    amplify.request.define('saveNRT', 'ajax', {
                        url: ist.siteUrl + '/Api/NRT',
                        dataType: 'json',
                        decoder: amplify.request.decoders.istStatusDecoder,
                        type: 'POST'
                    });
                    isInitialized = true;
                }
            },
             

        // Non Revenue Ticket base data
        // ReSharper disable once InconsistentNaming
        getNRTBase = function (callbacks) {
            initialize();
            return amplify.request({
                resourceId: 'getNRTBase',
                success: callbacks.success,
                error: callbacks.error,
            });
        },
          //Save NRT
            saveNrt = function (param, callbacks) {
                initialize();
                return amplify.request({
                    resourceId: 'saveNRT',
                    success: callbacks.success,
                    error: callbacks.error,
                    data: param
                });
            },
        // Get Vehicles Detail 
        getVehiclesDetail = function (param, callbacks) {
            initialize();
            return amplify.request({
                resourceId: 'getVehiclesDetail',
                success: callbacks.success,
                error: callbacks.error,
                data: param
            });
        },
        // Get Chauffer
        getChauffers = function (param, callbacks) {
            initialize();
            return amplify.request({
                resourceId: 'getChauffers',
                success: callbacks.success,
                error: callbacks.error,
                data: param
            });
        },
        // Get Additional Charge
        getAdditionlCharge = function (param, callbacks) {
            initialize();
            return amplify.request({
                resourceId: 'getAdditionlCharge',
                success: callbacks.success,
                error: callbacks.error,
                data: param
            });
        }; 
        return {
            getNRTBase: getNRTBase,
            getVehiclesDetail: getVehiclesDetail,
            getChauffers: getChauffers,
            getAdditionlCharge: getAdditionlCharge,
            saveNrt: saveNrt,
        };
    })();

    return dataService;
});