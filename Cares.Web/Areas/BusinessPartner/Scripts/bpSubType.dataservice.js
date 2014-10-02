/*
    Data service module with ajax calls to the server
*/
define("bpSubType/bpSubType.dataservice", function () {

    // Data service for forecast 
    var dataService = (function () {
        var
            // True if initialized
            isInitialized = false,
            // Initialize
            initialize = function () {
                if (!isInitialized) {


                    // Define request to get Business Partner Sub Types
                    amplify.request.define('getBusinessPartnerSubTypes', 'ajax', {
                        url: ist.siteUrl + '/Api/BusinessPartnerSubType',
                        dataType: 'json',
                        decoder: amplify.request.decoders.istStatusDecoder,
                        type: 'GET'
                    });
                    // Define request to delete Business Partner Sub Type
                    amplify.request.define('deleteBusinessPartnerSubType', 'ajax', {
                        url: ist.siteUrl + '/Api/BusinessPartnerSubType',
                        dataType: 'json',
                        decoder: amplify.request.decoders.istStatusDecoder,
                        type: 'DELETE'
                    });
                    // Define request to add/update Business Partner Sub Type
                    amplify.request.define('saveBusinessPartnerSubType', 'ajax', {
                        url: ist.siteUrl + '/Api/BusinessPartnerSubType',
                        dataType: 'json',
                        decoder: amplify.request.decoders.istStatusDecoder,
                        type: 'POST'
                    });

                    //Business Partner Sub Type base Data
                    amplify.request.define('getBusinessPartnerSubTypeData', 'ajax', {
                        url: ist.siteUrl + '/Api/BusinessPartnerSubTypeBase',
                        dataType: 'json',
                        decoder: amplify.request.decoders.istStatusDecoder,
                        type: 'GET'
                    });

                    isInitialized = true;
                }
            },
            // Get Business Partner Sub Types
            getBusinessPartnerSubTypes = function (params, callbacks) {
                return amplify.request({
                    resourceId: 'getBusinessPartnerSubTypes',
                    success: callbacks.success,
                    error: callbacks.error,
                    data: params
                });
            },
            //add-update Business Partner Sub Type
            saveBusinessPartnerSubType = function (params, callbacks) {
                return amplify.request({
                    resourceId: 'saveBusinessPartnerSubType',
                    success: callbacks.success,
                    error: callbacks.error,
                    data: params
                });
            },
            //delete Business Partner Sub Type
            deleteBusinessPartnerSubType = function (params, callbacks) {
                return amplify.request({
                    resourceId: 'deleteBusinessPartnerSubType',
                    success: callbacks.success,
                    error: callbacks.error,
                    data: params
                });
            },
            //  Business Partner Sub Type Base Data
            getBusinessPartnerSubTypeData = function (params, callbacks) {
                initialize();
                return amplify.request({
                    resourceId: 'getBusinessPartnerSubTypeData',
                    success: callbacks.success,
                    error: callbacks.error,
                    data: params
                });
            };

        return {
            getBusinessPartnerSubTypeBaseData: getBusinessPartnerSubTypeData,
            saveBusinessPartnerSubType: saveBusinessPartnerSubType,
            getBusinessPartnerSubTypes: getBusinessPartnerSubTypes,
            deleteBusinessPartnerSubType: deleteBusinessPartnerSubType
        };
    })();
    return dataService;
});