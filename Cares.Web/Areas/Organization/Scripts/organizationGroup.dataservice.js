/*
    Data service module with ajax calls to the server
*/
define("Organization/organizationGroup.dataservice", function () {

    // Data service for forecast 
    var dataService = (function () {
        var
            // True if initialized
            isInitialized = false,
            // Initialize
            initialize = function() {
                if (!isInitialized) {
                    // Define request to get OrganizationGroup Base data
                    amplify.request.define('getOrganizationGroups', 'ajax', {
                        url: ist.siteUrl + '/Api/OrganizationGroup',
                        dataType: 'json',
                        decoder: amplify.request.decoders.istStatusDecoder,
                        type: 'GET'
                    });
                    // Define request to delete OrganizationGroup
                    amplify.request.define('deleteOrganizationGroup', 'ajax', {
                        url: ist.siteUrl + '/Api/OrganizationGroup',
                        dataType: 'json',
                        decoder: amplify.request.decoders.istStatusDecoder,
                        type: 'DELETE'
                    });
                    // Define request to add/update OrganizationGroup
                    amplify.request.define('addOrganizationGroup', 'ajax', {
                        url: ist.siteUrl + '/Api/OrganizationGroup',
                        dataType: 'json',
                        decoder: amplify.request.decoders.istStatusDecoder,
                        type: 'POST'
                    });
                    isInitialized = true;
                }
            },
            // Get Fleet Pools 
            getOrganizationGroups = function(params, callbacks) {
                initialize();
                return amplify.request({
                    resourceId: 'getOrganizationGroups',
                    success: callbacks.success,
                    error: callbacks.error,
                    data: params
                });
            },
            //add-update OrganizationGroup
            addOrganizationGroup = function(params, callbacks) {
                return amplify.request({
                    resourceId: 'addOrganizationGroup',
                    success: callbacks.success,
                    error: callbacks.error,
                    data: params
                });
            },
              //delete OrganizationGroup
            deleteOrganizationGroup = function(params, callbacks) {
                return amplify.request({
                    resourceId: 'deleteOrganizationGroup',
                    success: callbacks.success,
                    error: callbacks.error,
                    data: params
                });
            };
        return {
            addOrganizationGroup:addOrganizationGroup,
            getOrganizationGroups: getOrganizationGroups,
            deleteOrganizationGroup: deleteOrganizationGroup
        };
    })();
    return dataService;
});