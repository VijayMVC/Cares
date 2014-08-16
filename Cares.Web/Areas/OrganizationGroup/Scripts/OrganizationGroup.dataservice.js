/*
    Data service module with ajax calls to the server
*/
define("OrganizationGroup/OrganizationGroup.dataservice", function () {

    // Data service for forecast 
    var dataService = (function () {
        var
            // True if initialized
            isInitialized = false,
            // Initialize
            initialize = function() {
                if (!isInitialized) {
                    // Define request to get FleetPool Base data
                    amplify.request.define('getOrganizationGroups', 'ajax', {
                        url: '/Api/OrganizationGroup',
                        dataType: 'json',
                        decoder: amplify.request.decoders.istStatusDecoder,
                        type: 'GET'
                    });
                    //delete org group
                    // Define request to get FleetPool Base data
                    amplify.request.define('deleteOrganizationGroup', 'ajax', {
                        url: '/Api/OrganizationGroup',
                        dataType: 'json',
                        decoder: amplify.request.decoders.istStatusDecoder,
                        type: 'DELETE'
                    });
                    amplify.request.define('addOrganizationGroup', 'ajax', {
                        url: '/Api/OrganizationGroup',
                        dataType: 'json',
                        decoder: amplify.request.decoders.istStatusDecoder,
                        type: 'POST'
                    });
                    isInitialized = true;
                }
            },
            // Get Fleet Pool Base Data
            getOrganizationGroups = function (params, callbacks) {
                initialize();
                return amplify.request({
                    resourceId: 'getOrganizationGroups',
                    success: callbacks.success,
                    error: callbacks.error,
                    data: params
                });
            },
            addOrganizationGroup = function (params, callbacks) {
                  debugger;
                  return amplify.request({
                      resourceId: 'addOrganizationGroup',
                      success: callbacks.success,
                      error: callbacks.error,
                      data: params
                  });
              },
        deleteOrganizationGroup=function (params, callbacks) {
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