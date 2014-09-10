/*
    Data service module with ajax calls to the server
*/
define("employee/employee.dataservice", function () {

    // Data service for forecast 
    var dataService = (function () {
        var // True if initialized
            isInitialized = false,
            // Initializep
            initialize = function() {
                if (!isInitialized) {

                    // Define request to get Employee base data 
                    amplify.request.define('getEmployeeBaseData', 'ajax', {
                        url: '/Api/EmployeeBase',
                        dataType: 'json',
                        type: 'GET'
                    });
                    // Define request to get Employees  
                    amplify.request.define('getEmployees', 'ajax', {
                        url: '/Api/Employee',
                        dataType: 'json',
                        type: 'GET'
                    });
                    //// Define request to save Vehicle
                    //amplify.request.define('saveVehicle', 'ajax', {
                    //    url: '/Api/Vehicle',
                    //    dataType: 'json',
                    //    decoder: amplify.request.decoders.istStatusDecoder,
                    //    type: 'POST'
                    //});

                    //// Define request to get Vehicle
                    //amplify.request.define('getVehicleDetailById', 'ajax', {
                    //    url: '/Api/VehicleDetail',
                    //    dataType: 'json',
                    //    type: 'GET'
                    //});
                    //// Define request to delete Vehicle
                    //amplify.request.define('deleteVehicle', 'ajax', {
                    //    url: '/Api/Vehicle',
                    //    dataType: 'json',
                    //    type: 'DELETE'
                    //});
                    isInitialized = true;
                }
            },
            // Get Employee base
            getEmployeeBaseData = function(callbacks) {
                initialize();
                return amplify.request({
                    resourceId: 'getEmployeeBaseData',
                    success: callbacks.success,
                    error: callbacks.error,
                });
            },
            // Get Employee List
            getEmployees = function (params, callbacks) {
                initialize();
                return amplify.request({
                    resourceId: 'getEmployees',
                    success: callbacks.success,
                    error: callbacks.error,
                    data: params
                });
            };

        //// Create Vehicle
        //saveVehicle = function (param, callbacks) {
        //    initialize();
        //    return amplify.request({
        //        resourceId: 'saveVehicle',
        //        success: callbacks.success,
        //        error: callbacks.error,
        //        data: param
        //    });
        //},
        //  // Get Vehicle Data By Vehicle id 
        //getVehicleDetailById = function (params, callbacks) {
        //    initialize();
        //    return amplify.request({
        //        resourceId: 'getVehicleDetailById',
        //        success: callbacks.success,
        //        error: callbacks.error,
        //        data: params
        //    });
        //},
        //// Delete
        //deleteVehicle = function (param, callbacks) {
        //    initialize();
        //    return amplify.request({
        //        resourceId: 'deleteVehicle',
        //        success: callbacks.success,
        //        error: callbacks.error,
        //        data: param
        //    });
        //};

        return {
            getEmployeeBaseData: getEmployeeBaseData,
            getEmployees: getEmployees,
            //saveVehicle: saveVehicle,
            //getVehicleDetailById: getVehicleDetailById,
            //deleteVehicle: deleteVehicle

        };
    })();

    return dataService;
});