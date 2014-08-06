/*
    Data service module with ajax calls to the server
*/
define("rentalAgreement/Mocks/rentalAgreement.dataservice", function () {

    var defineRequests = function() {
        // Get base data
        amplify.request.define('getBase', function (settings) {

            // data returned
            var data = {
                Operations: [{ Name: "Operation1", Id: 1 }]
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
    };

    return {
        defineRequests: defineRequests
    };

});