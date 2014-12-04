/*
    Module with the model for the RA Queue
*/
define(["ko", "underscore", "underscore-ko"], function (ko) {
    var
        //BookingMain entity
        // ReSharper disable InconsistentNaming
     BookingMain = function () {
         // ReSharper restore InconsistentNaming
         var // Reference to this object
             self,
             // Unique key
            bookingMainId = ko.observable(),
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
             bookingMainId: bookingMainId,
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
    var BookingMainClientMapper = function (source) {
        var bookingMain = new BookingMain();
        bookingMain.bookingMainId(source.BookingMainId === null ? undefined : source.BookingMainId);
        bookingMain.startDate(source.StartDtTime !== null ? moment(source.StartDtTime, ist.utcFormat).toDate() : undefined);
        bookingMain.endDate(source.EndDtTime !== null ? moment(source.EndDtTime, ist.utcFormat).toDate() : undefined);
        bookingMain.closeLocCode(source.CloseLocation === null ? undefined : source.CloseLocation);
        bookingMain.oprationCode(source.OperationCode === null ? undefined : source.OperationCode);
        bookingMain.statusCode(source.StatusCode === null ? undefined : source.StatusCode);
        bookingMain.openLocCode(source.OpenLocation === null ? undefined : source.OpenLocation);
        return bookingMain;
    };
    return {
        BookingMain: BookingMain,
        BookingMainClientMapper: BookingMainClientMapper,
    };
});