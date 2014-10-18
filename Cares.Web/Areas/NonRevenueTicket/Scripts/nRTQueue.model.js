/*
    Module with the model for the NRT Queue
*/
define(["ko", "underscore", "underscore-ko"], function (ko) {
    var
        //NRT Main entity
        // ReSharper disable InconsistentNaming
     NrtMain = function () {
         // ReSharper restore InconsistentNaming
         var // Reference to this object
             self,
             // Unique key
            nRtMainId = ko.observable(),
            //Start Date
            startDate = ko.observable(),
            //End Date
            endDate = ko.observable(),
            //Open Location code
            openLocCode = ko.observable(),
            //Close Location Code
            closeLocCode = ko.observable(),
            //NRT Type Code
            nrtTypeCode = ko.observable(),
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
             nRtMainId: nRtMainId,
             startDate: startDate,
             endDate: endDate,
             openLocCode: openLocCode,
             closeLocCode: closeLocCode,
             nrtTypeCode: nrtTypeCode,
             statusCode: statusCode,
             formattedStartDate: formattedStartDate,
             formattedEndDate: formattedEndDate,

         };
         return self;
     };
    //Server To Client Mapper
    // ReSharper disable once InconsistentNaming
    var NrtMainClientMapper = function (source) {
        var nRtMain = new NrtMain();
        nRtMain.nRtMainId(source.NrtMainId === null ? undefined : source.NrtMainId);
        nRtMain.startDate(source.StartDtTime !== null ? moment(source.StartDtTime, ist.utcFormat).toDate() : undefined);
        nRtMain.endDate(source.EndDtTime !== null ? moment(source.EndDtTime, ist.utcFormat).toDate() : undefined);
        nRtMain.openLocCode(source.OpenLocation === null ? undefined : source.OpenLocation);
        nRtMain.closeLocCode(source.CloseLocation === null ? undefined : source.CloseLocation);
        nRtMain.nrtTypeCode(source.NrtTypeCode === null ? undefined : source.NrtTypeCode);
        nRtMain.statusCode(source.NrtStatusCode === null ? undefined : source.NrtStatusCode);
        return nRtMain;
    };
    return {
        NrtMain: NrtMain,
        NrtMainClientMapper: NrtMainClientMapper,
    };
});