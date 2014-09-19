﻿/*
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
                        url: '/Api/RentalAgreementBase',
                        dataType: 'json',
                        type: 'GET'
                    });
                    
                    // Define request to get Vehicles
                    amplify.request.define('getVehiclesByHireGroup', 'ajax', {
                        url: '/Api/HireGroupVehicles',
                        dataType: 'json',
                        type: 'GET'
                    });
                    
                    // Define request to get Hire Group by code , vehicle category / make / mode / model year
                    amplify.request.define('getHireGroupsByCodeAndVehicleInfo', 'ajax', {
                        url: '/Api/RentalAgreementHireGroups',
                        dataType: 'json',
                        dataMap: JSON.stringify,
                        contentType: "application/json; charset=utf-8",
                        type: 'POST'
                    });
                    
                    // Define request to get Customer by Customer No
                    amplify.request.define('getCustomerByNo', 'ajax', {
                        url: '/Api/RentalAgreementBusinessPartner',
                        dataType: 'json',
                        type: 'GET'
                    });
                    
                    // Define request to get Customer by Nic No
                    amplify.request.define('getCustomerByNicNo', 'ajax', {
                        url: '/Api/RentalAgreementBusinessPartner',
                        dataType: 'json',
                        type: 'GET'
                    });
                    
                    // Define request to get Customer by Passport No
                    amplify.request.define('getCustomerByPassportNo', 'ajax', {
                        url: '/Api/RentalAgreementBusinessPartner',
                        dataType: 'json',
                        type: 'GET'
                    });
                    
                    // Define request to get Customer by License No
                    amplify.request.define('getCustomerByLicenseNo', 'ajax', {
                        url: '/Api/RentalAgreementBusinessPartner',
                        dataType: 'json',
                        type: 'GET'
                    });
                    
                    // Define request to get Customer by Phone No
                    amplify.request.define('getCustomerByPhoneNo', 'ajax', {
                        url: '/Api/RentalAgreementBusinessPartner',
                        dataType: 'json',
                        type: 'GET'
                    });
                    
                    // #region MockCalls
                    /* Mock Calls */

                    // Get base data
                    //amplify.request.define('getBase', function (settings) {

                    //    // data returned
                    //    var data = {
                    //        Operations: [{ Name: "Operation1", Id: 1 }],
                    //        Locations: [{ Name: "L01", Id: 1 }],
                    //        PaymentTerms: [{ Name: "Credit", Id: 1 }, { Name: "Spot", Id: 2 }]
                    //    };
                    //    settings.success(data);
                    //});

                    //// Get Vehicles
                    //amplify.request.define('getVehicles', function (settings) {

                    //    // data returned
                    //    var data = {
                    //        Vehicles: [
                    //            { Id: 1, PlateNumber: "1234A", HireGroup: "AA2-Grade2", VehicleMake: "Toyota", VehicleModel: "Yaris", ModelYear: 2010 },
                    //            { Id: 2, PlateNumber: "1234ABC", HireGroup: "AA2-Grade2", VehicleMake: "Toyota", VehicleModel: "Corolla", ModelYear: 2012 }
                    //        ]
                    //    };
                    //    settings.success(data);
                    //});

                    /* Mock Calls */
                    // #endregion

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
            getVehiclesByHireGroup = function (params, callbacks) {
                initialize();
                return amplify.request({
                    resourceId: 'getVehiclesByHireGroup',
                    success: callbacks.success,
                    error: callbacks.error,
                    data: params
                });
            },
            
            // Get Hire Groups
            getHireGroupsByCodeAndVehicleInfo = function (params, callbacks) {
                initialize();
                return amplify.request({
                    resourceId: 'getHireGroupsByCodeAndVehicleInfo',
                    success: callbacks.success,
                    error: callbacks.error,
                    data: params
                });
            },
            
            // Get Customer by Customer No
            getCustomerByNo = function (params, callbacks) {
                initialize();
                return amplify.request({
                    resourceId: 'getCustomerByNo',
                    success: callbacks.success,
                    error: callbacks.error,
                    data: params
                });
            },
            
            // Get Customer by Nic No
            getCustomerByNicNo = function (params, callbacks) {
                initialize();
                return amplify.request({
                    resourceId: 'getCustomerByNicNo',
                    success: callbacks.success,
                    error: callbacks.error,
                    data: params
                });
            },
            
            // Get Customer by Passport No
            getCustomerByPassportNo = function (params, callbacks) {
                initialize();
                return amplify.request({
                    resourceId: 'getCustomerByPassportNo',
                    success: callbacks.success,
                    error: callbacks.error,
                    data: params
                });
            },
            
            // Get Customer by License No
            getCustomerByLicenseNo = function (params, callbacks) {
                initialize();
                return amplify.request({
                    resourceId: 'getCustomerByLicenseNo',
                    success: callbacks.success,
                    error: callbacks.error,
                    data: params
                });
            },
            
            // Get Customer by Phone No
            getCustomerByPhoneNo = function (params, callbacks) {
                initialize();
                return amplify.request({
                    resourceId: 'getCustomerByPhoneNo',
                    success: callbacks.success,
                    error: callbacks.error,
                    data: params
                });
            };


        return {
            getBase: getBase,
            getVehiclesByHireGroup: getVehiclesByHireGroup,
            getHireGroupsByCodeAndVehicleInfo: getHireGroupsByCodeAndVehicleInfo,
            getCustomerByNo: getCustomerByNo,
            getCustomerByNicNo: getCustomerByNicNo,
            getCustomerByPassportNo: getCustomerByPassportNo,
            getCustomerByLicenseNo: getCustomerByLicenseNo,
            getCustomerByPhoneNo: getCustomerByPhoneNo
        };
    })();

    return dataService;
});