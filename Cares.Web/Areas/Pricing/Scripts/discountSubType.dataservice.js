/*
    Data service module with ajax calls to the server
*/
define("discountSubType/discountSubType.dataservice", function () {

    // Data service for forecast 
    var dataService = (function () {
        var
            // True if initialized
            isInitialized = false,
            // Initialize
            initialize = function() {
                if (!isInitialized) {
                    // Define request to get Discount Sub Type 
                    amplify.request.define('getDiscountSubType', 'ajax', {
                        url: ist.siteUrl + '/Api/DiscountSubType',
                        dataType: 'json',
                        decoder: amplify.request.decoders.istStatusDecoder,
                        type: 'GET'
                    });
                    // Define request to delete Discount Sub Type
                    amplify.request.define('deleteDiscountSubType', 'ajax', {
                        url: ist.siteUrl + '/Api/DiscountSubType',
                        dataType: 'json',
                        decoder: amplify.request.decoders.istStatusDecoder,
                        type: 'DELETE'
                    });
                    // Define request to add/update Discount  Sub Type
                    amplify.request.define('saveDiscountSubType', 'ajax', {
                        url: ist.siteUrl + '/Api/DiscountSubType',
                        dataType: 'json',
                        decoder: amplify.request.decoders.istStatusDecoder,
                        type: 'POST'
                    });

                    //Discount Sub Type base Data
                    amplify.request.define('getDiscountSubTypeBaseData', 'ajax', {
                        url: ist.siteUrl + '/Api/DiscountSubTypeBase',
                        dataType: 'json',
                        decoder: amplify.request.decoders.istStatusDecoder,
                        type: 'GET'
                    });

                    isInitialized = true;
                }
            },
            // Get Discount Sub Types
            getDiscountSubType = function (params, callbacks) {
                initialize();
                return amplify.request({
                    resourceId: 'getDiscountSubType',
                    success: callbacks.success,
                    error: callbacks.error,
                    data: params
                });
            },
            //add-update Discount Sub Types
            saveDiscountSubType = function (params, callbacks) {
                return amplify.request({
                    resourceId: 'saveDiscountSubType',
                    success: callbacks.success,
                    error: callbacks.error,
                    data: params
                });
            },
            //delete Discount Sub Type.
            deleteDiscountSubType = function (params, callbacks) {
                return amplify.request({
                    resourceId: 'deleteDiscountSubType',
                    success: callbacks.success,
                    error: callbacks.error,
                    data: params
                });
            },
            //  Discount Sub Type Base Data
            getDiscountSubTypeBaseData = function (params, callbacks) {
                initialize();
                return amplify.request({
                    resourceId: 'getDiscountSubTypeBaseData',
                    success: callbacks.success,
                    error: callbacks.error,
                    data: params
                });
            };
      
        return {
            getDiscountSubTypeBaseData: getDiscountSubTypeBaseData,
            saveDiscountSubType: saveDiscountSubType,
            getDiscountSubType: getDiscountSubType,
            deleteDiscountSubType: deleteDiscountSubType,
        };
    })();
    return dataService;
});