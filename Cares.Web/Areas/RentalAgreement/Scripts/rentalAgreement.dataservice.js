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
                        url: ist.siteUrl + '/Api/RentalAgreementBase',
                        dataType: 'json',
                        type: 'GET'
                    });
                    
                    // Define request to get Vehicles
                    amplify.request.define('getVehiclesByHireGroup', 'ajax', {
                        url: ist.siteUrl + '/Api/HireGroupVehicles',
                        dataType: 'json',
                        type: 'GET'
                    });
                    
                    // Define request to get Hire Group by code , vehicle category / make / mode / model year
                    amplify.request.define('getHireGroupsByCodeAndVehicleInfo', 'ajax', {
                        url: ist.siteUrl + '/Api/RentalAgreementHireGroups',
                        dataType: 'json',
                        dataMap: JSON.stringify,
                        contentType: "application/json; charset=utf-8",
                        type: 'POST'
                    });
                    
                    // Define request to get Customer by Customer No
                    amplify.request.define('getCustomerByNo', 'ajax', {
                        url: ist.siteUrl + '/Api/RentalAgreementBusinessPartner',
                        dataType: 'json',
                        type: 'GET'
                    });
                    
                    // Define request to get Customer by Nic No
                    amplify.request.define('getCustomerByNicNo', 'ajax', {
                        url: ist.siteUrl + '/Api/RentalAgreementBusinessPartner',
                        dataType: 'json',
                        type: 'GET'
                    });
                    
                    // Define request to get Customer by Passport No
                    amplify.request.define('getCustomerByPassportNo', 'ajax', {
                        url: ist.siteUrl + '/Api/RentalAgreementBusinessPartner',
                        dataType: 'json',
                        type: 'GET'
                    });
                    
                    // Define request to get Customer by License No
                    amplify.request.define('getCustomerByLicenseNo', 'ajax', {
                        url: ist.siteUrl + '/Api/RentalAgreementBusinessPartner',
                        dataType: 'json',
                        type: 'GET'
                    });
                    
                    // Define request to get Customer by Phone No
                    amplify.request.define('getCustomerByPhoneNo', 'ajax', {
                        url: ist.siteUrl + '/Api/RentalAgreementBusinessPartner',
                        dataType: 'json',
                        type: 'GET'
                    });

                    // Define request to Calcualte Bill
                    amplify.request.define('calculateBill', 'ajax', {
                        url: ist.siteUrl + '/Api/RentalAgreementBilling',
                        dataType: 'json',
                        dataMap: JSON.stringify,
                        contentType: "application/json; charset=utf-8",
                        type: 'POST'
                    });

                    // Define request to get Service Items
                    amplify.request.define('getServiceItems', 'ajax', {
                        url: ist.siteUrl + '/Api/RentalAgreementServiceItems',
                        dataType: 'json',
                        type: 'GET'
                    });

                    // Define request to get Chauffers
                    amplify.request.define('getChauffers', 'ajax', {
                        url: ist.siteUrl + '/Api/RentalAgreementChauffers',
                        dataType: 'json',
                        dataMap: JSON.stringify,
                        contentType: "application/json; charset=utf-8",
                        type: 'POST'
                    });

                    // Define request to get Additional Charges
                    amplify.request.define('getAdditionalCharges', 'ajax', {
                        url: ist.siteUrl + '/Api/RaAdditionalCharge',
                        dataType: 'json',
                        type: 'GET'
                    });

                    // Define request to get Insurance Rates
                    amplify.request.define('getInsuranceRates', 'ajax', {
                        url: ist.siteUrl + '/Api/RaInsuranceRts',
                        dataType: 'json',
                        type: 'GET'
                    });

                    // Define request to get RA
                    amplify.request.define('getRentalAgreement', 'ajax', {
                        url: ist.siteUrl + '/Api/RentalAgreement',
                        dataType: 'json',
                        type: 'GET'
                    });

                    // Define request to save RA
                    amplify.request.define('saveRentalAgreement', 'ajax', {
                        url: ist.siteUrl + '/Api/RentalAgreement',
                        dataType: 'json',
                        dataMap: JSON.stringify,
                        contentType: "application/json; charset=utf-8",
                        type: 'POST'
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
            },
            
            // Calculate Bill
            calculateBill = function (params, callbacks) {
                initialize();
                return amplify.request({
                    resourceId: 'calculateBill',
                    success: callbacks.success,
                    error: callbacks.error,
                    data: params
                });
            },
            
            // Get Service Items
            getServiceItems = function (callbacks) {
                initialize();
                return amplify.request({
                    resourceId: 'getServiceItems',
                    success: callbacks.success,
                    error: callbacks.error
                });
            },

            // Get Additional Charges
            getAdditionalCharges = function (callbacks) {
                initialize();
                return amplify.request({
                    resourceId: 'getAdditionalCharges',
                    success: callbacks.success,
                    error: callbacks.error
                });
            },

            // Get Insurance Rts
            getInsuranceRates = function (callbacks) {
                initialize();
                return amplify.request({
                    resourceId: 'getInsuranceRates',
                    success: callbacks.success,
                    error: callbacks.error
                });
            },
            
            // Get Chauffers
            getChauffers = function (params, callbacks) {
                initialize();
                return amplify.request({
                    resourceId: 'getChauffers',
                    success: callbacks.success,
                    error: callbacks.error,
                    data: params
                });
            },

            // Get Rental Agreement
            getRentalAgreement = function (params, callbacks) {
                initialize();
                return amplify.request({
                    resourceId: 'getRentalAgreement',
                    success: callbacks.success,
                    error: callbacks.error,
                    data: params
                });
            },
            
            // Save RA
            saveRentalAgreement = function (params, callbacks) {
                initialize();
                return amplify.request({
                    resourceId: 'saveRentalAgreement',
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
            getCustomerByPhoneNo: getCustomerByPhoneNo,
            calculateBill: calculateBill,
            getServiceItems: getServiceItems,
            getChauffers: getChauffers,
            getInsuranceRates: getInsuranceRates,
            getAdditionalCharges: getAdditionalCharges,
            getRentalAgreement: getRentalAgreement,
            saveRentalAgreement: saveRentalAgreement
        };
    })();

    return dataService;
});