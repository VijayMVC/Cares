define(["ko", "underscore", "underscore-ko"], function(ko) {
    var
        // Workplace entity
        // ReSharper disable InconsistentNaming
        workLocation = function (specifiedId, specifiedCode, specifiedName, specifiedDescription, cmpId, spcCompanyName, spccontatctPerson, spstreatAdress,
          spcountryId, spcountryName, spregionId, spregionName, spsubRegionId, spsubRegionName, spcityId, spcityName, spareaId, spareaName,
          spwebPage, spzipCode, sppoBox, spEmail) {
            var
                id = ko.observable(specifiedId),
                code = ko.observable(specifiedCode).extend({ required: true }),
                name = ko.observable(specifiedName),
                description = ko.observable(specifiedDescription),
                companyId = ko.observable(cmpId),
                companyName = ko.observable(spcCompanyName),

                 contatctPerson = ko.observable(spccontatctPerson),

                 streatAdress = ko.observable(spstreatAdress),
                 email = ko.observable(spEmail),

                countryId = ko.observable(spcountryId),
                countryName = ko.observable(spcountryName),

                regionId = ko.observable(spregionId),
                regionName = ko.observable(spregionName),

                subRegionId = ko.observable(spsubRegionId),
                subRegionName = ko.observable(spsubRegionName),

                cityId = ko.observable(spcityId),
                cityName = ko.observable(spcityName).extend({ required: true }),

                areaId = ko.observable(spareaId),
                areaName = ko.observable(spareaName),

                webPage = ko.observable(spwebPage),
                zipCode = ko.observable(spzipCode),
                poBox = ko.observable(sppoBox),

                // ReSharper disable once InconsistentNaming
                Phones = ko.observableArray([]),

                phoneDetail = ko.observable(),
                errors = ko.validation.group({
                   
                }),
                // Is Valid
                isValid = ko.computed(function() {
                    return errors().length === 0;
                }),
                dirtyFlag = new ko.dirtyFlag({
                   
                }),
                // Has Changes
                hasChanges = ko.computed(function() {
                    return dirtyFlag.isDirty();
                }),
                // Reset
                reset = function() {
                    dirtyFlag.reset();
                },
                // Convert to server data
                convertToServerData = function () {

                   // ReSharper disable once InconsistentNaming
                    var Address = {
                        ContactPerson: contatctPerson(),
                        StreetAddress: streatAdress(),
                        EmailAddress: email(),
                        WebPage: webPage(),
                        ZipCode: zipCode(),
                        POBox: poBox(),
                        CountryId: countryId(),
                        RegionId: regionId(),
                        SubRegionId: subRegionId(),
                        CityId: cityId(),
                        AreaId: areaId()
                    };
                    return {
                        WorkLocationId: id(),
                        CompanyId: companyId(),
                        WorkLocationCode: code(),
                        WorkLocationName: name(),
                        WorkLocationDescription: description(),
                        Address: Address,
                        Phones: Phones()
                           };
                };
            return {
                id: id,
                name: name,
                code: code,
                description: description,
                companyId: companyId,
                companyName: companyName,
                contatctPerson:contatctPerson,
                streatAdress: streatAdress,
                email: email,
                countryId:countryId,
                countryName:countryName,
                regionId:regionId,
                regionName:regionName,
                subRegionId:subRegionId,
                subRegionName:subRegionName,
                cityId:cityId,
                cityName:cityName,
                areaId:areaId,
                areaName: areaName,
                webPage:webPage,
                zipCode: zipCode,
                poBox:poBox,
                phoneDetail: phoneDetail,
                Phones:Phones,

                hasChanges: hasChanges,
                reset: reset,
                convertToServerData: convertToServerData,
                isValid: isValid,
                errors: errors
            };
        };
    //server to client mapper
    var workLocationServertoClientMapper = function (itemFromServer) {
        var pob = new workLocation(itemFromServer.WorkLocationId, itemFromServer.WorkLocationCode, itemFromServer.WorkLocationName, itemFromServer.WorkLocationDescription,
            itemFromServer.CompanyId,
            itemFromServer.CompanyName, itemFromServer.Address.ContactPerson, itemFromServer.Address.StreetAddress, itemFromServer.Address.CountryId, itemFromServer.Address.CountryName,
            itemFromServer.Address.RegionId, itemFromServer.Address.RegionName, itemFromServer.Address.SubRegionId, itemFromServer.Address.SubRegionName, itemFromServer.Address.CityId,
            itemFromServer.Address.CityName, itemFromServer.Address.AreaId, itemFromServer.Address.AreaName,
            itemFromServer.Address.WebPage, itemFromServer.Address.ZipCode, itemFromServer.Address.POBox, itemFromServer.Address.EmailAddress);
        return pob;
    };
    //function to attain cancel button functionality 
    workLocation.CreateFromClientModel = function (itemFromServer) {
        var pob = new workLocation(itemFromServer.id, itemFromServer.code, itemFromServer.name, itemFromServer.description, itemFromServer.companyId,
            itemFromServer.companyName, itemFromServer.contatctPerson, itemFromServer.streatAdress, itemFromServer.countryId, itemFromServer.countryName,
            itemFromServer.regionId, itemFromServer.regionName, itemFromServer.subRegionId, itemFromServer.subRegionName, itemFromServer.cityId,
            itemFromServer.cityName, itemFromServer.areaId, itemFromServer.areaName,
            itemFromServer.webPage, itemFromServer.zipCode, itemFromServer.poBox, itemFromServer.email);
        return pob;
    };

    var
        // phone Workplace entity
        // ReSharper disable InconsistentNaming
        phone = function(specifiedId, specifiedphoneTypeId, specifiedphoneTypeName, specifiedphoneNumber, specifiedisDefault, specifiedworkLocationId) {
            var
                id = ko.observable(specifiedId),
                phoneTypeId = ko.observable(specifiedphoneTypeId),
                phoneTypeName = ko.observable(specifiedphoneTypeName).extend({ required: true }),
                isDefault = ko.observable(specifiedisDefault),
                phoneNumber = ko.observable(specifiedphoneNumber),
                workLocationId = ko.observable(specifiedworkLocationId),

                errors = ko.validation.group({

                }),
                // Is Valid
                isValid = ko.computed(function() {
                    return errors().length === 0;
                }),
                dirtyFlag = new ko.dirtyFlag({

                }),
                // Has Changes
                hasChanges = ko.computed(function() {
                    return dirtyFlag.isDirty();
                }),
                // Reset
                reset = function() {
                    dirtyFlag.reset();
                },
                // Convert to server data
                convertToServerData = function() {
                    return {
                        PhoneId: id(),
                        IsDefault: isDefault(),
                        PhoneNumber: phoneNumber(),
                        PhoneTypeId: phoneTypeId()
                    };
                };
            return {
                id: id,
                phoneTypeId: phoneTypeId,
                phoneTypeName: phoneTypeName,
                isDefault: isDefault,
                phoneNumber: phoneNumber,
                workLocationId: workLocationId,
                hasChanges: hasChanges,
                reset: reset,
                convertToServerData: convertToServerData,
                isValid: isValid,
                errors: errors
            };
        };
    // operation Workplace Server to Client Mapper
    var phoneServertoClientMapper = function (itemFromServer) {
        var pob = new phone(itemFromServer.PhoneId, itemFromServer.PhoneTypeId, itemFromServer.PhoneTypeName, itemFromServer.PhoneNumber,
            itemFromServer.IsDefault, itemFromServer.WorkLocationID);
        return pob;
    };
    var createPhone = function (isDefaultValue) {
        debugger;
        var pob = new phone(undefined, undefined, undefined, undefined,
         isDefaultValue, undefined);
        return pob;
    };
    return {
        phone: phone,
        createPhone:createPhone,
        workLocation: workLocation,
        workLocationServertoClientMapper: workLocationServertoClientMapper,
        phoneServertoClientMapper: phoneServertoClientMapper
    };


});