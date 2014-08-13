/*
    Data service module with ajax calls to the server
*/
define("hireGroup/hireGroup.dataservice", function () {

    // Data service for forecast 
    var dataService = (function () {
        var // True if initialized
            isInitialized = false,
            // Initializep
            initialize = function() {
                if (!isInitialized) {

                    // Define request to get Hire Group base data 
                    amplify.request.define('getHireGroupBase', 'ajax', {
                        url: '/Api/HireGroupBase',
                        dataType: 'json',
                        type: 'GET'
                    });
                    // Define request to get Hire Group 
                    amplify.request.define('getHireGroup', 'ajax', {
                        url: '/Api/HireGroup',
                        dataType: 'json',
                        type: 'GET'
                    });
                    // Define request to save Hire Group
                    amplify.request.define('createHireGroup', 'ajax', {
                        url: '/Api/HireGroup',
                        dataType: 'json',
                        type: 'PUT'
                    });

                    // Define request to update Hire Group
                    amplify.request.define('updateHireGroup', 'ajax', {
                        url: '/Api/HireGroup',
                        dataType: 'json',
                        type: 'POST'
                    });
                    // Define request to get Hire Group
                    amplify.request.define('getHireGroupDetailById', 'ajax', {
                        url: '/Api/GetHireGroupDetailData',
                        dataType: 'json',
                        type: 'GET'
                    });
                    // Define request to delete Hire Group
                    amplify.request.define('deleteHireGroup', 'ajax', {
                        url: '/Api/HireGroup',
                        dataType: 'json',
                        type: 'DELETE'
                    });
                    isInitialized = true;
                }
            },
            // Get Hire Group base
            getHireGroupBase = function(callbacks) {
                initialize();
                return amplify.request({
                    resourceId: 'getHireGroupBase',
                    success: callbacks.success,
                    error: callbacks.error,
                });
            },
            // Get Hire Group List
            getHireGroup = function(params, callbacks) {
                initialize();
                return amplify.request({
                    resourceId: 'getHireGroup',
                    success: callbacks.success,
                    error: callbacks.error,
                    data: params
                });
            },
       
        // Create Hire Group
        createHireGroup = function (param, callbacks) {
            initialize();
            return amplify.request({
                resourceId: 'createHireGroup',
                success: callbacks.success,
                error: callbacks.error,
                data: param
            });
        },
        // Update a Hire Group
        updateHireGroup = function (param, callbacks) {
            initialize();
            return amplify.request({
                resourceId: 'updateHireGroup',
                success: callbacks.success,
                error: callbacks.error,
                data: param
            });
        },
        // Get Hire Group id 
        getHireGroupDetailById = function (params, callbacks) {
            initialize();
            return amplify.request({
                resourceId: 'getHireGroupDetailById',
                success: callbacks.success,
                error: callbacks.error,
                data: params
            });
        },
        // Delete
        deleteHireGroup = function (param, callbacks) {
            initialize();
            return amplify.request({
                resourceId: 'deleteHireGroup',
                success: callbacks.success,
                error: callbacks.error,
                data: param
            });
        };
          
        return {
            getHireGroupBase: getHireGroupBase,
            getHireGroup: getHireGroup,
            createHireGroup:createHireGroup,
            updateHireGroup:updateHireGroup,
            getHireGroupDetailById: getHireGroupDetailById,
            deleteHireGroup: deleteHireGroup
           
        };
    })();

    return dataService;
});