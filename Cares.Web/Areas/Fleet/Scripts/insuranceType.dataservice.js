/*
    Data service module with ajax calls to the server
*/
define("insuranceType/insuranceType.dataservice", function () {

    // Data service for forecast 
    var dataService = (function () {
        var
            // True if initialized
            isInitialized = false,
            // Initialize
            initialize = function() {
                if (!isInitialized) {


                    // Define request to get Insurance Types 
                    amplify.request.define('getInsuranceTypes', 'ajax', {
                        url: ist.siteUrl + '/Api/InsuranceType',
                        dataType: 'json',
                        decoder: amplify.request.decoders.istStatusDecoder,
                        type: 'GET'
                    });
                    // Define request to delete Insurance Type
                    amplify.request.define('deleteInsuranceType', 'ajax', {
                        url: ist.siteUrl + '/Api/InsuranceType',
                        dataType: 'json',
                        decoder: amplify.request.decoders.istStatusDecoder,
                        type: 'DELETE'
                    });
                    // Define request to add/update Insurance Type
                    amplify.request.define('saveInsuranceType', 'ajax', {
                        url: ist.siteUrl + '/Api/InsuranceType',
                        dataType: 'json',
                        decoder: amplify.request.decoders.istStatusDecoder,
                        type: 'POST'
                    });


                    isInitialized = true;
                }
            },
            // Get Insurance Types
            getInsuranceTypes = function (params, callbacks) {
                initialize();
                return amplify.request({
                    resourceId: 'getInsuranceTypes',
                    success: callbacks.success,
                    error: callbacks.error,
                    data: params
                });
            },
            //add-update Insurance Type.
            saveInsuranceType = function(params, callbacks) {
                return amplify.request({
                    resourceId: 'saveInsuranceType',
                    success: callbacks.success,
                    error: callbacks.error,
                    data: params
                });
            },
            //delete Insurance Type.
            deleteInsuranceType = function(params, callbacks) {
                return amplify.request({
                    resourceId: 'deleteInsuranceType',
                    success: callbacks.success,
                    error: callbacks.error,
                    data: params
                });
            };
        return {
            saveInsuranceType: saveInsuranceType,
            getInsuranceTypes: getInsuranceTypes,
            deleteInsuranceType: deleteInsuranceType,

        };
    })();
    return dataService;
});