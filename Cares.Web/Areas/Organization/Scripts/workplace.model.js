define(["ko", "underscore", "underscore-ko"], function(ko) {
    var
        // Workplace entity
        // ReSharper disable InconsistentNaming
        workPlace = function (specifiedId, specifiedCode, specifiedName, specifiedDescription, cmpId, spcCompanyName, spparentWorkPlaceId, spparentWorkPlaceName,
          specifiedworkplaceTypeId, specifiedworkplaceTypeName ,spworkLocationId,spworkLocationName) {
            var
                id = ko.observable(specifiedId),
                code = ko.observable(specifiedCode).extend({ required: true }),
                name = ko.observable(specifiedName),
                description = ko.observable(specifiedDescription),
                companyId = ko.observable(cmpId),
                companyName = ko.observable(spcCompanyName),
                parentWorkPlaceId = ko.observable(spparentWorkPlaceId),
                parentWorkPlaceName = ko.observable(spparentWorkPlaceName),
                workplaceTypeId = ko.observable(specifiedworkplaceTypeId).extend({ required: true }),
                workplaceTypeName = ko.observable(specifiedworkplaceTypeName),
                workLocationId = ko.observable(spworkLocationId).extend({ required: true }),
                workLocationName = ko.observable(spworkLocationName).extend({ required: true }),
                OperationsWorkPlaces = ko.observableArray([]),
                tabDetail = ko.observable(),
                errors = ko.validation.group({
                    code: code,
                    workplaceTypeId: workplaceTypeId,
                    workLocationId: workLocationId
                }),
                // Is Valid
                isValid = ko.computed(function() {
                    return errors().length === 0;
                }),
                dirtyFlag = new ko.dirtyFlag({
                    code: code,
                    workplaceTypeId: workplaceTypeId,
                    workLocationId: workLocationId
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
                    return {
                        WorkPlaceId :id(),
                        WorkPlaceCode:code(),
                        WorkPlaceName:name(),
                        WorkPlaceDescription:description(),
                        WorkPlaceTypeId:workplaceTypeId(),
                        CompanyId:companyId(),
                        WorkLocationId:workLocationId(),
                        ParentWorkPlaceId: parentWorkPlaceId(),
                        OperationsWorkPlaces:OperationsWorkPlaces()
                    };
                };
            return {
                id: id,
                name: name,
                code: code,
                description: description,
                companyId: companyId,
                companyName: companyName,
                workLocationId:workLocationId,
                workLocationName:workLocationName,
                workplaceTypeName:workplaceTypeName,
                workplaceTypeId:workplaceTypeId,
                parentWorkPlaceId: parentWorkPlaceId,
                parentWorkPlaceName: parentWorkPlaceName,
                OperationsWorkPlaces: OperationsWorkPlaces,
                tabDetail: tabDetail,
                hasChanges: hasChanges,
                reset: reset,
                convertToServerData: convertToServerData,
                isValid: isValid,
                errors: errors
            };
        };
    //server to client mapper
    var OperationServertoClientMapper = function (itemFromServer) {
        var pob = new workPlace(itemFromServer.WorkPlaceId, itemFromServer.WorkPlaceCode, itemFromServer.WorkPlaceName,
            itemFromServer.WorkPlaceDescription, itemFromServer.CompanyId, itemFromServer.CompanyName, itemFromServer.ParentWorkPlaceId, itemFromServer.ParentWorkPlaceName,
            itemFromServer.WorkPlaceTypeId, itemFromServer.WorkPlaceTypeName, itemFromServer.WorkLocationId, itemFromServer.WorkLocationName);
        return pob;
    };
    //function to attain cancel button functionality 
    workPlace.CreateFromClientModel = function (itemFromServer) {
        var pob = new workPlace(itemFromServer.id, itemFromServer.code, itemFromServer.name,
            itemFromServer.description, itemFromServer.companyId, itemFromServer.companyName, itemFromServer.parentWorkPlaceId, itemFromServer.parentWorkPlaceName,
            itemFromServer.workplaceTypeId, itemFromServer.workplaceTypeName, itemFromServer.workLocationId, itemFromServer.workLocationName);
        return pob;
    };

    var
       // operation Workplace entity
       // ReSharper disable InconsistentNaming
       operationWorkplace = function (specifiedId, specifiedCode, specifiedName, specifiedDescription, specifiedoperationId, specifiedoperationName,
          specifiedfleelPoolId, specifiedfleelPoolName, specifiedcostCenter, specifiedWorkPlaceId, isCretedNewvalue) {
           var
                parentWorkPlaceId = ko.observable(specifiedWorkPlaceId),

                locationId = ko.observable(specifiedId),
                locationCode = ko.observable(specifiedCode).extend({ required: true }),
                locationName = ko.observable(specifiedName),
                locationDescription = ko.observable(specifiedDescription),
                operationId = ko.observable(specifiedoperationId),
                operationName = ko.observable(specifiedoperationName),
                fleelPoolId = ko.observable(specifiedfleelPoolId),
                fleelPoolName = ko.observable(specifiedfleelPoolName),
                costCenter = ko.observable(specifiedcostCenter).extend({ required: true }),
                errors = ko.validation.group({
                    locationCode: locationCode,
                    costCenter: costCenter
               }),
               // Is Valid
               isValid = ko.computed(function () {
                   return errors().length === 0;
               }),
               dirtyFlag = new ko.dirtyFlag({
                   locationCode: locationCode,
                   costCenter: costCenter
               }),
               // Has Changes
               hasChanges = ko.computed(function () {
                   return dirtyFlag.isDirty();
               }),
               // Reset
               reset = function () {
                   dirtyFlag.reset();
               },
               // Convert to server data
               convertToServerData = function () {
                   return {
                       OperationsWorkPlaceId: locationId(),
                       LocationCode: locationCode(),
                       OperationId: operationId(),
                       FleetPoolId: fleelPoolId(),
                       CostCenter: costCenter(),
                       WorkPlaceId: parentWorkPlaceId()
                   };
               };
           return {
               locationId: locationId,
               locationCode: locationCode,
               locationName: locationName,
               locationDescription:locationDescription,
               operationId:operationId,
               operationName:operationName,
               fleelPoolId:fleelPoolId,
               fleelPoolName:fleelPoolName,
               costCenter:costCenter,
               parentWorkPlaceId:parentWorkPlaceId,
               hasChanges: hasChanges,
               reset: reset,
               convertToServerData: convertToServerData,
               isValid: isValid,
               errors: errors
           };
       };
    // operation Workplace Server to Client Mapper
    var operationWorkplaceServertoClientMapper = function (itemFromServer) {
        var pob = new operationWorkplace(itemFromServer.OperationsWorkPlaceId, itemFromServer.LocationCode, "-", "-",
            itemFromServer.OperationId, itemFromServer.OperationName,
          itemFromServer.FleetPoolId, itemFromServer.FleetPoolName, itemFromServer.CostCenter, itemFromServer.WorkPlaceId,false);
        return pob;
    };
    return {
        operationWorkplace: operationWorkplace,
        workPlace: workPlace,
        OperationServertoClientMapper: OperationServertoClientMapper,
        operationWorkplaceServertoClientMapper: operationWorkplaceServertoClientMapper
    };


});