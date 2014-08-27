define(["ko", "underscore", "underscore-ko"], function(ko) {

    var
        // Company entity
        // ReSharper disable InconsistentNaming
        Company = function (specifiedId, specifiedCode, specifiedName, specifiedDescription) {
            var
               id = ko.observable(specifiedId),
               code = ko.observable(specifiedCode),
               name = ko.observable(specifiedName),
               description = ko.observable(specifiedDescription),
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
                // Convert to server
                convertToServerData = function () {
                    return {
                        CompanyId: id(),
                        CompanyName: name(),
                        CompanyCode: code(),
                        CompanyDescription: description()
                    };
                };
            return {
                CompanyId: id,
                CompanyName: name,
                CompanyCode: code,
                CompanyDescription: description,
                convertToServerData: convertToServerData,
                isValid: isValid,
                hasChanges: hasChanges,
                reset: reset
            };
        };
    //detail object of company
    var CompanyDetail = function (specifiedbusinessSegmentId,specifiedCode,specifiedDescription,specifiedId, specifiedlegalName,
      specifiedName, specifiedcrNumber, specifiedntn, specifiedorgGroupId,specifiedpaidUpCapital,specifiedparentCompanyId, 
           specifieduan, specifiedparentCompanyName, specifiedbusinessSegmentName, specifiedorgGroup) {
        var
              id = ko.observable(specifiedId),
              parentCompanyName = ko.observable(specifiedparentCompanyName),
              parentCompanyId = ko.observable(specifiedparentCompanyId),
              orgGroupId = ko.observable(specifiedorgGroupId).extend({ required: true }),
              orgGroupName = ko.observable(specifiedorgGroup),
              legalName = ko.observable(specifiedlegalName),
              crNumber = ko.observable(specifiedcrNumber),
              uan = ko.observable(specifieduan),
              ntn = ko.observable(specifiedntn),
              paidUpCapital = ko.observable(specifiedpaidUpCapital).extend({ required: true }),
              code = ko.observable(specifiedCode).extend({ required: true }),
              name = ko.observable(specifiedName).extend({ required: true }),
              description = ko.observable(specifiedDescription),
              businessSegmentId = ko.observable(specifiedbusinessSegmentId).extend({ required: true }),
              businessSegmentName = ko.observable(specifiedbusinessSegmentName),
              errors = ko.validation.group({
                name:name,
                code:code,
                orgGroupId:orgGroupId,
                businessSegmentId:businessSegmentId,
                paidUpCapital: paidUpCapital
             }),
            // Is Valid
            isValid = ko.computed(function() {
                return errors().length === 0;
            }),
            // True if the booking has been changed        
            dirtyFlag = new ko.dirtyFlag({
                name: name,
                code: code,
                orgGroupId: orgGroupId,
                businessSegmentId: businessSegmentId,
                paidUpCapital: paidUpCapital
               
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
            convertToServerData = function() {
                return {
                    CompanyId: id(),
                    ParentCompanyId: parentCompanyId(),
                    OrgGroupId: orgGroupId(),
                    CompanyCode: code(),
                    CompanyName: name(),
                    CompanyDescription: description(),
                    CompanyLegalName: legalName(),
                    CrNumber: crNumber(),
                    Uan: uan(),
                    Ntn: ntn(),
                    PaidUpCapital: paidUpCapital(),
                    BusinessSegmentId: businessSegmentId()
                   
                };
            };
        return {
            companyId: id,
            parentCompanyId: parentCompanyId,
            orgGroupId: orgGroupId,
            CompanyLegalName: legalName,
            parentCompanyName:parentCompanyName,
            crNumber: crNumber,
            uan: uan,
            ntn: ntn,
            paidUpCapital: paidUpCapital,
            businessSegmentId: businessSegmentId,
            companyName: name,
            companyCode: code,
            companyDescription: description,
            errors: errors,
            isValid: isValid,
            dirtyFlag: dirtyFlag,
            hasChanges: hasChanges,
            convertToServerData: convertToServerData,
            reset: reset,
            orgGroupName: orgGroupName,
            businessSegmentName: businessSegmentName,
            
        };
    };
    // server to client mapper
    var CompanyServertoClinetMapper = function (source) {
        return CompanyDetail.Create(source);
    };
    //client to server mapper
    var CompanyClienttoServerMapper = function (client) {
        var source = new CompanyDetail(client.businessSegmentId(), client.companyCode(), client.companyDescription(), client.companyId(),
             client.CompanyLegalName(),client.companyName(), client.crNumber(), client.ntn(), client.orgGroupId(), client.paidUpCapital()
            , client.parentCompanyId(),client.uan(),"","",client.orgGroupId());
        return source.convertToServerData();
    };
    // Company Factory
    CompanyDetail.Create = function (source) {
        return new CompanyDetail(source.BusinessSegmentId ,source.CompanyCode, source.CompanyDescription, source.CompanyId, source.CompanyLegalName,
           source.CompanyName,  source.CrNumber,  source.Ntn,  source.OrgGroupId,  source.PaidUpCapital,  source.ParentCompanyId,  source.Uan,
         source.ParentCompanyName, source.BusinessSegmentName, source.OrgGroupName);
    };
    // To attain the cancel button property
    CompanyDetail.CreateFromClientModel = function (source) {
        return new CompanyDetail(source.businessSegmentId, source.companyCode, source.companyDescription, source.companyId, source.CompanyLegalName,
            source.companyName, source.crNumber, source.ntn, source.orgGroupId, source.paidUpCapital, source.parentCompanyId, source.uan,
           source.parentCompanyName, source.businessSegmentName, source.orgGroupName);
    };
    return {
        CompanyServertoClinetMapper: CompanyServertoClinetMapper,
        CompanyClienttoServerMapper: CompanyClienttoServerMapper,
        Company: Company,
        CompanyDetail: CompanyDetail
    };
});