/*
    Data service module with ajax calls to the server
*/
define("city/city.dataservice", function () {

    // Data service for forecast 
    var dataService = (function () {
        var
            // True if initialized
            isInitialized = false,
            // Initialize
            initialize = function() {
                if (!isInitialized) {


                    // Define request to get Cities 
                    amplify.request.define('getCities', 'ajax', {
                        url: ist.siteUrl + '/Api/City',
                        dataType: 'json',
                        decoder: amplify.request.decoders.istStatusDecoder,
                        type: 'GET'
                    });
                    // Define request to delete City
                    amplify.request.define('deleteCity', 'ajax', {
                        url: ist.siteUrl + '/Api/City',
                        dataType: 'json',
                        decoder: amplify.request.decoders.istStatusDecoder,
                        type: 'DELETE'
                    });
                    // Define request to add/update City
                    amplify.request.define('saveCity', 'ajax', {
                        url: ist.siteUrl + '/Api/City',
                        dataType: 'json',
                        decoder: amplify.request.decoders.istStatusDecoder,
                        type: 'POST'
                    });

                    //City base Data
                    amplify.request.define('getCityBaseData', 'ajax', {
                        url: ist.siteUrl + '/Api/CityBase',
                        dataType: 'json',
                        decoder: amplify.request.decoders.istStatusDecoder,
                        type: 'GET'
                    });

                    isInitialized = true;
                }
            },
            // Get Cities
            getCities = function(params, callbacks) {
                initialize();
                return amplify.request({
                    resourceId: 'getCities',
                    success: callbacks.success,
                    error: callbacks.error,
                    data: params
                });
            },
            //add-update City.
            saveCity = function(params, callbacks) {
                return amplify.request({
                    resourceId: 'saveCity',
                    success: callbacks.success,
                    error: callbacks.error,
                    data: params
                });
            },
            //delete City.
            deleteCity = function (params, callbacks) {
                return amplify.request({
                    resourceId: 'deleteCity',
                    success: callbacks.success,
                    error: callbacks.error,
                    data: params
                });
            },


            //  Get City Data
            getCityBaseData = function (params, callbacks) {
                initialize();
                return amplify.request({
                    resourceId: 'getCityBaseData',
                    success: callbacks.success,
                    error: callbacks.error,
                    data: params
                });
            };
      
        return {
            getCityBaseData: getCityBaseData,
            saveCity: saveCity,
            getCities: getCities,
            deleteCity: deleteCity,

        };
    })();
    return dataService;
});