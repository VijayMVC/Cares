/*
    Data service module with ajax calls to the server
*/
define("rentalAgreement/rentalAgreement.dataservice", function () {

    // Data service for forecast 
    var dataService = (function () {
        var
            // True if initialized
            isInitialized = false,
            // Initialize
            initialize = function () {
                if (!isInitialized) {
                    
                    // Define request to get Base
                    amplify.request.define('getBase', 'ajax', {
                        url: 'GetBase',
                        dataType: 'json',
                        type: 'GET'
                    });
                    
                    // Define request to get Vehicles
                    amplify.request.define('getVehicles', 'ajax', {
                        url: 'GetVehicles',
                        dataType: 'json',
                        type: 'GET'
                    });
                    
                    /* Mock Calls */ 

                    // Get base data
                    amplify.request.define('getBase', function (settings) {

                        // data returned
                        var data = {
                            Operations: [{ Name: "Operation1", Id: 1 }],
                            Locations: [{ Name: "L01", Id: 1 }],
                            PaymentTerms: [{ Name: "Credit", Id: 1 }, { Name: "Spot", Id: 2 }]
                        };
                        settings.success(data);
                    });

                    // Get Vehicles
                    amplify.request.define('getVehicles', function (settings) {

                        // data returned
                        var data = {
                            Vehicles: [
                                { Id: 1, PlateNumber: "1234A", HireGroup: "AA2-Grade2", VehicleMake: "Toyota", VehicleModel: "Yaris", ModelYear: 2010 },
                                { Id: 2, PlateNumber: "1234ABC", HireGroup: "AA2-Grade2", VehicleMake: "Toyota", VehicleModel: "Corolla", ModelYear: 2012 }
                            ]
                        };
                        settings.success(data);
                    });

                    isInitialized = true;
                }
            },
            
            // Get Base
            getBase = function (callbacks) {
                initialize();
                return amplify.request({
                    resourceId: 'getBase',
                    success: callbacks.success,
                    error: callbacks.error
                });
            },
            
            // Get Vehicles
            getVehicles = function (callbacks) {
                initialize();
                return amplify.request({
                    resourceId: 'getVehicles',
                    success: callbacks.success,
                    error: callbacks.error
                });
            };


        return {
            getBase: getBase,
            getVehicles: getVehicles
        };
    })();

    return dataService;
});