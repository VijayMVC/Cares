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

                    //base data
                    amplify.request.define('getDepartmentBaseData', 'ajax', {
                        url: '/Api/DepartmentBase',
                        dataType: 'json',
                        decoder: amplify.request.decoders.istStatusDecoder,
                        type: 'GET'
                    });



                    amplify.request.define('saveDepartment', 'ajax', {
                        url: '/Api/Department',
                        dataType: 'json',
                        decoder: amplify.request.decoders.istStatusDecoder,
                        type: 'POST'
                    });

                    amplify.request.define('getDepartments', 'ajax', {
                        url: '/Api/Department',
                        dataType: 'json',
                        decoder: amplify.request.decoders.istStatusDecoder,
                        type: 'GET'
                    });

                    amplify.request.define('deleteDepartment', 'ajax', {
                        url: '/Api/Department',
                        dataType: 'json',
                        decoder: amplify.request.decoders.istStatusDecoder,
                        type: 'DELETE'
                    });

                    isInitialized = true;
                }
            },
            //  Base Data
            getDepartmentBaseData = function (params, callbacks) {
                initialize();
                return amplify.request({
                    resourceId: 'getDepartmentBaseData',
                    success: callbacks.success,
                    error: callbacks.error,
                    data: params
                });
            },

            getDepartments = function (params, callbacks) {
                initialize();
                return amplify.request({
                    resourceId: 'getDepartments',
                    success: callbacks.success,
                    error: callbacks.error,
                    data: params
                });
            },

            saveDepartment = function (params, callbacks) {
                initialize();
                return amplify.request({
                    resourceId: 'saveDepartment',
                    success: callbacks.success,
                    error: callbacks.error,
                    data: params
                });
            },
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