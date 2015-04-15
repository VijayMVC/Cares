define(["ko", "underscore", "underscore-ko"], function(ko) {
    
    //Credit Limit Detail
    var creditLimitDetail = function (specifiedId, specifiedIsIndividual, specifiedStandardCreditLimit, specifieddescription, specifiedbpSubTypeId, specifiedbpSubName,
        specifiedbpRatingTypeId, specifiedbpRatingTypeName) {
        var            
            id = ko.observable(specifiedId),
            isIndividual = ko.observable(specifiedIsIndividual).extend({ required: true }),
            standardCreditLimit = ko.observable(specifiedStandardCreditLimit).extend({ required: true, number: true }),
            description = ko.observable(specifieddescription),
            bpSubTypeId = ko.observable(specifiedbpSubTypeId).extend({ required: true }),
            bpSubName = ko.observable(specifiedbpSubName),
            bpRatingTypeId = ko.observable(specifiedbpRatingTypeId).extend({ required: true }),
            bpRatingTypeName = ko.observable(specifiedbpRatingTypeName),
            errors = ko.validation.group({
                bpSubTypeId:bpSubTypeId,
                standardCreditLimit: standardCreditLimit,
                bpRatingTypeId: bpRatingTypeId
            }),
            // Is Valid
            isValid = ko.computed(function() {
                return errors().length === 0;
            }),
            dirtyFlag = new ko.dirtyFlag({
                bpSubTypeId: bpSubTypeId,
                standardCreditLimit: standardCreditLimit,
                bpRatingTypeId: bpRatingTypeId
            }),
            // Has Changes
            hasChanges = ko.computed(function() {
                return dirtyFlag.isDirty();
            }),
            // Reset
            reset = function() {
                dirtyFlag.reset();
            },
            // Convert to server
            convertToServerData = function () {
                return {
                    CreditLimitId: id(),
                    IsIndividual: isIndividual(),
                    StandardCreditLimit: standardCreditLimit(),
                    Description: description(),
                    BpSubTypeId: bpSubTypeId(),
                    BpRatingTypeId: bpRatingTypeId()
                };
            };
        return {
            id:id,
            isIndividual: isIndividual,
            standardCreditLimit: standardCreditLimit,
            description: description,
            bpSubTypeId: bpSubTypeId,
            bpSubName: bpSubName,
            bpRatingTypeId: bpRatingTypeId,
            bpRatingTypeName:bpRatingTypeName,
            errors: errors,
            isValid: isValid,
            dirtyFlag: dirtyFlag,
            hasChanges: hasChanges,
            convertToServerData: convertToServerData,
            reset: reset
            
        };
    };
    // server to client mapper
    var creditLimitServertoClinetMapper = function (source) {
        return creditLimitDetail.Create(source);
    };
    
    // Credit Limit Factory
    creditLimitDetail.Create = function (source) {
        return new creditLimitDetail(source.CreditLimitId, source.IsIndividual, source.StandardCreditLimit, source.Description, source.BpSubTypeId,
            source.BpSubTypeName, source.BpRatingTypeId, source.BpRatingTypeName);
    };

    //function to attain cancel button functionality 
    creditLimitDetail.CreateFromClientModel = function (itemFromServer) {
        return new creditLimitDetail(itemFromServer.id, itemFromServer.isIndividual, itemFromServer.standardCreditLimit,
            itemFromServer.description, itemFromServer.bpSubTypeId, itemFromServer.bpSubName, itemFromServer.bpRatingTypeId, itemFromServer.bpRatingTypeName);
    };
    // Dummy Credit Limit 
    var createCreditLimit = function (isIndividualValue) {
        return new creditLimitDetail(undefined, isIndividualValue, undefined, undefined, undefined, undefined, undefined, undefined);
    };
    return {
        creditLimitDetail: creditLimitDetail,
        CreateCreditLimit:createCreditLimit,
        creditLimitServertoClinetMapper: creditLimitServertoClinetMapper,
    };
});