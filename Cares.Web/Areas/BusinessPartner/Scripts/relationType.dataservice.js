/*
    Data service module with ajax calls to the server
*/
define("relationType/relationType.dataservice", function () {

    // Data service for forecast 
    var dataService = (function () {
        var
            // True if initialized
            isInitialized = false,
            // Initialize
            initialize = function() {
                if (!isInitialized) {
                    // Define request to getBusiness Partner Relationship Types
                    amplify.request.define('getBusinessPartnerRelationshipType', 'ajax', {
                        url: ist.siteUrl + '/Api/BusinessPartnerRelationshipType',
                        dataType: 'json',
                        decoder: amplify.request.decoders.istStatusDecoder,
                        type: 'GET'
                    });
                    // Define request to delete Business Partner Relationship Type
                    amplify.request.define('deleteBusinessPartnerRelationshipType', 'ajax', {
                        url: ist.siteUrl + '/Api/BusinessPartnerRelationshipType',
                        dataType: 'json',
                        decoder: amplify.request.decoders.istStatusDecoder,
                        type: 'DELETE'
                    });
                    // Define request to add/update Business Partner Relationship Type
                    amplify.request.define('saveBusinessPartnerRelationshipType', 'ajax', {
                        url: ist.siteUrl + '/Api/BusinessPartnerRelationshipType',
                        dataType: 'json',
                        decoder: amplify.request.decoders.istStatusDecoder,
                        type: 'POST'
                    });
                    isInitialized = true;
                }
            },
            // Get Business Partner Relationship Types
            getBusinessPartnerRelationshipType = function (params, callbacks) {
                initialize();
                return amplify.request({
                    resourceId: 'getBusinessPartnerRelationshipType',
                    success: callbacks.success,
                    error: callbacks.error,
                    data: params
                });
            },
            //add-update Business Partner Relationship Type
            saveBusinessPartnerRelationshipType = function (params, callbacks) {
                return amplify.request({
                    resourceId: 'saveBusinessPartnerRelationshipType',
                    success: callbacks.success,
                    error: callbacks.error,
                    data: params
                });
            },
            //delete Business Partner Relationship Type
            deleteBusinessPartnerRelationshipType = function (params, callbacks) {
                return amplify.request({
                    resourceId: 'deleteBusinessPartnerRelationshipType',
                    success: callbacks.success,
                    error: callbacks.error,
                    data: params
                });
            };
        return {
            saveBusinessPartnerRelationshipType: saveBusinessPartnerRelationshipType,
            getBusinessPartnerRelationshipType: getBusinessPartnerRelationshipType,
            deleteBusinessPartnerRelationshipType: deleteBusinessPartnerRelationshipType,
        };
    })();
    return dataService;
});