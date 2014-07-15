/*
    Data service module with ajax calls to the server
*/
define("Fleet/fleetPool.dataservice", function () {

    // Data service for forecast 
    var dataService = (function () {
        var
            // True if initialized
            isInitialized = false,
            // Initialize
            initialize = function () {
                if (!isInitialized) {

                    // Define request to get products
                    amplify.request.define('get', 'ajax', {
                        url: '/Api/FleetPool',
                        dataType: 'json',
                        type: 'GET'
                    });

                    //// Define request to save product
                    //amplify.request.define('createProduct', 'ajax', {
                    //    url: '/Api/FleetPool',
                    //    dataType: 'json',
                    //    type: 'PUT'
                    //});

                    //// Define request to update product
                    //amplify.request.define('updateProduct', 'ajax', {
                    //    url: '/Api/FleetPool',
                    //    dataType: 'json',
                    //    type: 'POST'
                    //});

                    //// Define request to delete product
                    //amplify.request.define('deleteProduct', 'ajax', {
                    //    url: '/Api/FleetPool',
                    //    dataType: 'json',
                    //    type: 'DELETE'
                    //});

                    isInitialized = true;
                }
            },

            // Get Products
            getProducts = function (params, callbacks) {
                initialize();
                return amplify.request({
                    resourceId: 'get',
                    success: callbacks.success,
                    error: callbacks.error,
                    data: params
                });
            }
            //,

            //// Get Product Base
            //getProductBase = function (callbacks) {
            //    initialize();
            //    return amplify.request({
            //        resourceId: 'getProductBase',
            //        success: callbacks.success,
            //        error: callbacks.error
            //    });
            //},

            //// Create Product
            //createProduct = function (param, callbacks) {
            //    initialize();
            //    return amplify.request({
            //        resourceId: 'createProduct',
            //        success: callbacks.success,
            //        error: callbacks.error,
            //        data: param
            //    });
            //},

            //// Update a Product
            //updateProduct = function (param, callbacks) {
            //    initialize();
            //    return amplify.request({
            //        resourceId: 'updateProduct',
            //        success: callbacks.success,
            //        error: callbacks.error,
            //        data: param
            //    });
            //},

            //// save Forecast
            //deleteProduct = function (param, callbacks) {
            //    initialize();
            //    return amplify.request({
            //        resourceId: 'deleteProduct',
            //        success: callbacks.success,
            //        error: callbacks.error,
            //        data: param
            //    });
        //}
        ;


        return {
            getProducts: getProducts,
            //createProduct: createProduct,
            //updateProduct: updateProduct,
            //deleteProduct: deleteProduct,
            //getProductBase: getProductBase
        };
    })();

    return dataService;
});