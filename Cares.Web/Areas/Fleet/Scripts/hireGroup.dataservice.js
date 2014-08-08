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
            };
          
        return {
            getHireGroupBase: getHireGroupBase,
            getHireGroup: getHireGroup,
           
        };
    })();

    return dataService;
});