/*
    Data service module with ajax calls to the server
*/
define("empStatus/empStatus.dataservice", function () {

    // Data service for forecast 
    var dataService = (function () {
        var
            // True if initialized
            isInitialized = false,
            // Initialize
            initialize = function() {
                if (!isInitialized) {


                    // Define request to get Regions 
                    amplify.request.define('getEmpStatus', 'ajax', {
                        url: ist.siteUrl + '/Api/EmployeeStatus',
                        dataType: 'json',
                        decoder: amplify.request.decoders.istStatusDecoder,
                        type: 'GET'
                    });
                    // Define request to delete Region
                    amplify.request.define('deleteEmpStatus', 'ajax', {
                        url: ist.siteUrl + '/Api/EmployeeStatus',
                        dataType: 'json',
                        decoder: amplify.request.decoders.istStatusDecoder,
                        type: 'DELETE'
                    });
                    // Define request to add/update Regio
                    amplify.request.define('saveEmpStatus', 'ajax', {
                        url: ist.siteUrl + '/Api/EmployeeStatus',
                        dataType: 'json',
                        decoder: amplify.request.decoders.istStatusDecoder,
                        type: 'POST'
                    });

                    isInitialized = true;
                }
            },
            // Get Regions
            getEmpStatus = function(params, callbacks) {
                initialize();
                return amplify.request({
                    resourceId: 'getEmpStatus',
                    success: callbacks.success,
                    error: callbacks.error,
                    data: params
                });
            },
            //add-update Region.
            saveEmpStatus = function (params, callbacks) {
                return amplify.request({
                    resourceId: 'saveEmpStatus',
                    success: callbacks.success,
                    error: callbacks.error,
                    data: params
                });
            },
            //delete Region.
            deleteEmpStatus = function (params, callbacks) {
                debugger;
                return amplify.request({
                    resourceId: 'deleteEmpStatus',
                    success: callbacks.success,
                    error: callbacks.error,
                    data: params
                });
            };
      
        return {
            saveEmpStatus: saveEmpStatus,
            getEmpStatus: getEmpStatus,
            deleteEmpStatus: deleteEmpStatus,

        };
    })();
    return dataService;
});