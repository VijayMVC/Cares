/*
    Data service module with ajax calls to the server
*/
define("designGrade/designGrade.dataservice", function () {

    // Data service for forecast 
    var dataService = (function () {
        var
            // True if initialized
            isInitialized = false,
            // Initialize
            initialize = function() {
                if (!isInitialized) {


                    // Define request to get Design.Grades
                    amplify.request.define('getDesignGrades', 'ajax', {
                        url: ist.siteUrl + '/Api/DesignGrade',
                        dataType: 'json',
                        decoder: amplify.request.decoders.istStatusDecoder,
                        type: 'GET'
                    });
                    // Define request to delete  Design.Grade
                    amplify.request.define('deleteDesignGrade', 'ajax', {
                        url: ist.siteUrl + '/Api/DesignGrade',
                        dataType: 'json',
                        decoder: amplify.request.decoders.istStatusDecoder,
                        type: 'DELETE'
                    });
                    // Define request to add/update  Design.Grade
                    amplify.request.define('saveDesignGrade', 'ajax', {
                        url: ist.siteUrl + '/Api/DesignGrade',
                        dataType: 'json',
                        decoder: amplify.request.decoders.istStatusDecoder,
                        type: 'POST'
                    });

                    isInitialized = true;
                }
            },
            // Get  Design.Grades
            getDesignGrades = function(params, callbacks) {
                initialize();
                return amplify.request({
                    resourceId: 'getDesignGrades',
                    success: callbacks.success,
                    error: callbacks.error,
                    data: params
                });
            },
            //add-update  Design.Grade.
            saveDesignGrade = function (params, callbacks) {
                return amplify.request({
                    resourceId: 'saveDesignGrade',
                    success: callbacks.success,
                    error: callbacks.error,
                    data: params
                });
            },
            //delete  Design.Grade.
            deleteDesignGrade = function (params, callbacks) {
                debugger;
                return amplify.request({
                    resourceId: 'deleteDesignGrade',
                    success: callbacks.success,
                    error: callbacks.error,
                    data: params
                });
            };

        return {
            saveDesignGrade: saveDesignGrade,
            getDesignGrades: getDesignGrades,
            deleteDesignGrade: deleteDesignGrade,

        };
    })();
    return dataService;
});