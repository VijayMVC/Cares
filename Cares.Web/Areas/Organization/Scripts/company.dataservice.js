/*
    Data service module with ajax calls to the server
*/
define("company/company.dataservice", function () {

    // Data service for forecast 
    var dataService = (function () {
        var
            // True if initialized
            isInitialized = false,
            // Initialize
            initialize = function() {
            if (!isInitialized) {
                //Get Companies
                amplify.request.define('getCompanies', 'ajax', {
                    url: '/Api/Company',
                    dataType: 'json',
                    decoder: amplify.request.decoders.istStatusDecoder,
                    type: 'GET'
                });
                //Get Companies Basedata
                amplify.request.define('getCompaniesBasedata', 'ajax', {
                    url: '/Api/CompanyBase',
                    dataType: 'json',
                    decoder: amplify.request.decoders.istStatusDecoder,
                    type: 'GET'
                });
                //Delete Company
                amplify.request.define('deleteCompany', 'ajax', {
                    url: '/Api/Company',
                    dataType: 'json',
                    decoder: amplify.request.decoders.istStatusDecoder,
                    type: 'DELETE'
                });
                //save Company
                amplify.request.define('saveCompany', 'ajax', {
                    url: '/Api/Company',
                    dataType: 'json',
                    decoder: amplify.request.decoders.istStatusDecoder,
                    type: 'POST'
                });
                isInitialized = true;
            }
        },
        //Delete Company
            deleteCompany = function(params, callbacks) {
                return amplify.request({
                    resourceId: 'deleteCompany',
                    success: callbacks.success,
                    error: callbacks.error,
                    data: params
                });
            },
            //save Company
            saveCompany = function(params, callbacks) {
                return amplify.request({
                    resourceId: 'saveCompany',
                    success: callbacks.success,
                    error: callbacks.error,
                    data: params
                });
            },
            //Get Companies
            getCompanies = function(params, callbacks) {
            return amplify.request({
                resourceId: 'getCompanies',
                success: callbacks.success,
                error: callbacks.error,
                data: params
            });
            },
           //Get Companies Basedata
            getCompaniesBasedata = function(params, callbacks) {
                initialize();
                return amplify.request({
                    resourceId: 'getCompaniesBasedata',
                    success: callbacks.success,
                    error: callbacks.error,
                    data: params
                });
            };
        return {
            getCompanies: getCompanies,
            getCompaniesBasedata: getCompaniesBasedata,
            deleteCompany: deleteCompany,
            saveCompany: saveCompany
        };
    })();
    return dataService;
});