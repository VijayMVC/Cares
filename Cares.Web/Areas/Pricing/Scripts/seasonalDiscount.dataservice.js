/*
    Data service module with ajax calls to the server
*/
define("seasonalDiscount/seasonalDiscount.dataservice", function () {

    // Data service for forecast 
    var dataService = (function () {
        var // True if initialized
            isInitialized = false,
            // Initialize
            initialize = function () {
                if (!isInitialized) {

                    // Define request to get Seasonal Discount  base 
                    amplify.request.define('getSeasonalDiscountBase', 'ajax', {
                        url: ist.siteUrl + '/Api/SeasonalDiscountBase',
                        dataType: 'json',
                        type: 'GET'
                    });
                    // Define request to get Seasonal Discounts
                    amplify.request.define('getSeasonalDiscounts', 'ajax', {
                        url: ist.siteUrl + '/Api/SeasonalDiscount',
                        dataType: 'json',
                        type: 'GET'
                    });
                    // Define request to get  Seasonal Discount  detail
                    amplify.request.define('getSeasonalDiscountDetail', 'ajax', {
                        url: ist.siteUrl + '/Api/SeasonalDiscountDetail',
                        dataType: 'json',
                        type: 'GET'
                    });
                    // Define request to save Seasonal Discount
                    amplify.request.define('saveSeasonalDiscount', 'ajax', {
                        url: ist.siteUrl + '/Api/SeasonalDiscount',
                        dataType: 'json',
                        decoder: amplify.request.decoders.istStatusDecoder,
                        type: 'POST'
                    });
                    // Define request to delete Seasonal Discounts
                    amplify.request.define('deleteSeasonalDiscount', 'ajax', {
                        url: ist.siteUrl + '/Api/SeasonalDiscount',
                        dataType: 'json',
                        type: 'DELETE'
                    });
                    isInitialized = true;
                }
            },
            // Get Seasonal Discount  Base
            getSeasonalDiscountBase= function (callbacks) {
                initialize();
                return amplify.request({
                    resourceId: 'getSeasonalDiscountBase',
                    success: callbacks.success,
                    error: callbacks.error,
                });
            },
              // Get Seasonal Discount s by id 
            getSeasonalDiscountDetail = function (params, callbacks) {
                initialize();
                return amplify.request({
                    resourceId: 'getSeasonalDiscountDetail',
                    success: callbacks.success,
                    error: callbacks.error,
                    data: params
                });
            },
               // Save Seasonal Discount 
            saveSeasonalDiscount = function (param, callbacks) {
                initialize();
                return amplify.request({
                    resourceId: 'saveSeasonalDiscount',
                    success: callbacks.success,
                    error: callbacks.error,
                    data: param
                });
            },
              // Delete
            deleteSeasonalDiscount = function (param, callbacks) {
                initialize();
                return amplify.request({
                    resourceId: 'deleteSeasonalDiscount',
                    success: callbacks.success,
                    error: callbacks.error,
                    data: param
                });
            },
            // Get Seasonal Discounts
            getSeasonalDiscounts = function (params, callbacks) {
                initialize();
                return amplify.request({
                    resourceId: 'getSeasonalDiscounts',
                    success: callbacks.success,
                    error: callbacks.error,
                    data: params
                });
            };
        return {
            getSeasonalDiscountBase: getSeasonalDiscountBase,
            getSeasonalDiscounts: getSeasonalDiscounts,
            saveSeasonalDiscount: saveSeasonalDiscount,
            deleteSeasonalDiscount: deleteSeasonalDiscount,
            getSeasonalDiscountDetail: getSeasonalDiscountDetail,

        };
    })();

    return dataService;
});