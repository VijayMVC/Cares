/*
    Data service module with ajax calls to the server
*/
define("bookingMain/bookingMain.dataservice", function () {

    // Data service for forecast 
    var dataService = (function () {
        var // True if initialized
            isInitialized = false,
            // Initialize
            initialize = function () {
                if (!isInitialized) {
                    // Define request to get bookingMain base Data
                    amplify.request.define('getBookingMainBaseData', 'ajax', {
                        url: ist.siteUrl + '/Api/BookingMainBase',
                        dataType: 'json',
                        type: 'GET'
                    });

                    // Define request to get bookingMain
                    amplify.request.define('getBookingMain', 'ajax', {
                        url: ist.siteUrl + '/Api/BookingMain',
                        dataType: 'json',
                        type: 'GET'
                    });

                    isInitialized = true;
                }
            },
            // Get BookingMain Base Data
            getBookingMainBaseData = function (callbacks) {
                initialize();
                return amplify.request({
                    resourceId: 'getBookingMainBaseData',
                    success: callbacks.success,
                    error: callbacks.error,
                });
            },
        // Get BookingMain
        getBookingMain = function (params, callbacks) {
            initialize();
            return amplify.request({
                resourceId: 'getBookingMain',
                success: callbacks.success,
                error: callbacks.error,
                data: params
            });
        };

        return {
            getBookingMainBaseData:getBookingMainBaseData,
            getBookingMain: getBookingMain,
        };
    })();

    return dataService;
});