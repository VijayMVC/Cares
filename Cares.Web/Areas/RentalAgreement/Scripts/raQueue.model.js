/*
    Module with the model for the RA Queue
*/
define(["ko", "underscore", "underscore-ko"], function (ko) {
    var
        //RA Main entity
        // ReSharper disable InconsistentNaming
     RaMain = function () {
         // ReSharper restore InconsistentNaming
         var // Reference to this object
             self,
             // Unique key
            raMianId = ko.observable(),
            //Start Date
            startDate = ko.observable(),
            //End Date
            endDate = ko.observable(),
            //Open Location code
            openLocCode = ko.observable(),
            //Close Location Code
            closeLocCode = ko.observable(),
            //Operation Code
            oprationCode = ko.observable(),
            //Status Code
            statusCode = ko.observable(),
             // Formatted Start Date for grid
             formattedStartDate = ko.computed({
                 read: function () {
                     return moment(startDate()).format(ist.datePattern);
                 }
             }),
             // Formatted End Date for grid
             formattedEndDate = ko.computed({
                 read: function () {
                     return moment(endDate()).format(ist.datePattern);
                 }
             });

         self = {
             raMianId: raMianId,
             startDate: startDate,
             endDate: endDate,
             openLocCode: openLocCode,
             closeLocCode: closeLocCode,
             oprationCode: oprationCode,
             statusCode: statusCode,
             formattedStartDate: formattedStartDate,
             formattedEndDate: formattedEndDate,

         };
         return self;
     };
    //Server To Client Mapper
    // ReSharper disable once InconsistentNaming
    var RaMainClientMapper = function (source) {
        var raMain = new RaMain();
        raMain.raMianId(source.EffectiveDate !== null ? moment(source.EffectiveDate, ist.utcFormat).toDate() : undefined);
        raMain.startDate(source.EffectiveDate !== null ? moment(source.EffectiveDate, ist.utcFormat).toDate() : undefined);
        raMain.endDate(source.InsuranceRtId === null ? undefined : source.InsuranceRtId);
        raMain.openLocCode(source.InsuranceRtId === null ? undefined : source.InsuranceRtId);
        raMain.closeLocCode(source.InsuranceRtId === null ? undefined : source.InsuranceRtId);
        raMain.oprationCode(source.InsuranceRtId === null ? undefined : source.InsuranceRtId);
        raMain.statusCode(source.InsuranceRtId === null ? undefined : source.InsuranceRtId);
        return raMain;
    };
    return {
        RaMain: RaMain,
        RaMainClientMapper: RaMainClientMapper,
    };
});