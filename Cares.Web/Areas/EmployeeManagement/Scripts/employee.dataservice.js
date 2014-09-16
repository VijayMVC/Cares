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
                    // Define request to save Employee
                    amplify.request.define('saveEmployee', 'ajax', {
                        url: '/Api/Employee',
                        dataType: 'json',
                        decoder: amplify.request.decoders.istStatusDecoder,
                        type: 'POST'
                    });

                    // Define request to get Employee
                    amplify.request.define('getEmployeeDetailById', 'ajax', {
                        url: '/Api/EmployeeDetail',
                        dataType: 'json',
                        type: 'GET'
                    });
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
            getEmployees = function(params, callbacks) {
                initialize();
                return amplify.request({
                    resourceId: 'getEmployees',
                    success: callbacks.success,
                    error: callbacks.error,
                    data: params
                });
            },
            // Create Employee
            saveEmployee = function(param, callbacks) {
                initialize();
                return amplify.request({
                    resourceId: 'saveEmployee',
                    success: callbacks.success,
                    error: callbacks.error,
                    data: param
                });
            },
            // Get Vehicle Data By Employee id 
            getEmployeeDetailById = function(params, callbacks) {
                initialize();
                return amplify.request({
                    resourceId: 'getEmployeeDetailById',
                    success: callbacks.success,
                    error: callbacks.error,
                    data: params
                });
            };
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
            saveEmployee: saveEmployee,
            getEmployeeDetailById: getEmployeeDetailById,
            //deleteVehicle: deleteVehicle

        };
    })();

    return dataService;
});