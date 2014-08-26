/*
    Data service module with ajax calls to the server
*/
define("department/department.dataservice", function () {

    // Data service for forecast 
    var dataService = (function () {
        var
            // True if initialized
            isInitialized = false,
            // Initialize
            initialize = function() {
            if (!isInitialized) {
                //Department base Data
                amplify.request.define('getDepartmentBaseData', 'ajax', {
                    url: '/Api/DepartmentBase',
                    dataType: 'json',
                    decoder: amplify.request.decoders.istStatusDecoder,
                    type: 'GET'
                });
                //save Department
                amplify.request.define('saveDepartment', 'ajax', {
                    url: '/Api/Department',
                    dataType: 'json',
                    decoder: amplify.request.decoders.istStatusDecoder,
                    type: 'POST'
                });
                //get Departments
                amplify.request.define('getDepartments', 'ajax', {
                    url: '/Api/Department',
                    dataType: 'json',
                    decoder: amplify.request.decoders.istStatusDecoder,
                    type: 'GET'
                });
                //delete Department
                amplify.request.define('deleteDepartment', 'ajax', {
                    url: '/Api/Department',
                    dataType: 'json',
                    decoder: amplify.request.decoders.istStatusDecoder,
                    type: 'DELETE'
                });
                isInitialized = true;
            }
        },
        //  Department Base Data
            getDepartmentBaseData = function (params, callbacks) {
                initialize();
                return amplify.request({
                    resourceId: 'getDepartmentBaseData',
                    success: callbacks.success,
                    error: callbacks.error,
                    data: params
                });
            },
            //get Departments
            getDepartments = function (params, callbacks) {
                initialize();
                return amplify.request({
                    resourceId: 'getDepartments',
                    success: callbacks.success,
                    error: callbacks.error,
                    data: params
                });
            },
            //save Department
            saveDepartment = function (params, callbacks) {
                initialize();
                return amplify.request({
                    resourceId: 'saveDepartment',
                    success: callbacks.success,
                    error: callbacks.error,
                    data: params
                });
            },
            //delete Department
            deleteDepartment = function (params, callbacks) {
                initialize();
                return amplify.request({
                    resourceId: 'deleteDepartment',
                    success: callbacks.success,
                    error: callbacks.error,
                    data: params
                });
            };

        return {
            getDepartmentBaseData: getDepartmentBaseData,
            getDepartments: getDepartments,
            saveDepartment: saveDepartment,
            deleteDepartment: deleteDepartment
        };
    })();
    return dataService;
});