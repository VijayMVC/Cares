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
            raMainId = ko.observable(),
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
             raMainId: raMainId,
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
        raMain.raMainId(source.RaMainId === null ? undefined : source.RaMainId);
        raMain.startDate(source.StartDtTime !== null ? moment(source.StartDtTime, ist.utcFormat).toDate() : undefined);
        raMain.endDate(source.EndDtTime !== null ? moment(source.EndDtTime, ist.utcFormat).toDate() : undefined);
        raMain.openLocCode(source.OpenLocation === null ? undefined : source.OpenLocation);
        raMain.closeLocCode(source.CloseLocation === null ? undefined : source.CloseLocation);
        raMain.oprationCode(source.OperationCode === null ? undefined : source.OperationCode);
        raMain.statusCode(source.RaStatusCode === null ? undefined : source.RaStatusCode);
        return raMain;
    };
    return {
        RaMain: RaMain,
        RaMainClientMapper: RaMainClientMapper,
    };
});