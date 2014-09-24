/*
    Data service module with ajax calls to the server
*/
define("discountType/discountType.dataservice", function () {

    // Data service for forecast 
    var dataService = (function () {
        var
            // True if initialized
            isInitialized = false,
            // Initialize
            initialize = function() {
                if (!isInitialized) {


                    // Define request to get Discount Type
                    amplify.request.define('getDiscountType', 'ajax', {
                        url: '/Api/DiscountType',
                        dataType: 'json',
                        decoder: amplify.request.decoders.istStatusDecoder,
                        type: 'GET'
                    });
                    // Define request to delete Discount Type
                    amplify.request.define('deleteDiscountType', 'ajax', {
                        url: '/Api/DiscountType',
                        dataType: 'json',
                        decoder: amplify.request.decoders.istStatusDecoder,
                        type: 'DELETE'
                    });
                    // Define request to add/update  Discount Type
                    amplify.request.define('saveDiscountType', 'ajax', {
                        url: '/Api/DiscountType',
                        dataType: 'json',
                        decoder: amplify.request.decoders.istStatusDecoder,
                        type: 'POST'
                    });
                    isInitialized = true;
                }
            },
            // Get Sub Discount Type
            getDiscountType = function (params, callbacks) {
                initialize();
                return amplify.request({
                    resourceId: 'getDiscountType',
                    success: callbacks.success,
                    error: callbacks.error,
                    data: params
                });
            },
            //add-update Discount Type
            saveDiscountType = function (params, callbacks) {
                return amplify.request({
                    resourceId: 'saveDiscountType',
                    success: callbacks.success,
                    error: callbacks.error,
                    data: params
                });
            },
            //delete Discount Type
            deleteDiscountType = function (params, callbacks) {
                return amplify.request({
                    resourceId: 'deleteDiscountType',
                    success: callbacks.success,
                    error: callbacks.error,
                    data: params
                });
            };
      
        return {
            saveDiscountType: saveDiscountType,
            getDiscountType: getDiscountType,
            deleteDiscountType: deleteDiscountType,

        };
    })();
    return dataService;
});