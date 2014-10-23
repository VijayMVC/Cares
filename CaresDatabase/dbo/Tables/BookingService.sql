CREATE TABLE [dbo].[BookingService] (
    [BookingServiceID] BIGINT   IDENTITY (1, 1) NOT NULL,
    [BookingMainID]    BIGINT   NOT NULL,
    [ServiceItemID]    BIGINT   NOT NULL,
    [StartDate]        DATETIME NOT NULL,
    [EndDate]          DATETIME NOT NULL,
    [Quantity]         INT      NOT NULL,
    [DomainKey]        BIGINT   NOT NULL,
    CONSTRAINT [PK_BookingService] PRIMARY KEY CLUSTERED ([BookingServiceID] ASC),
    CONSTRAINT [FK_BookingService_BookingMain] FOREIGN KEY ([BookingMainID]) REFERENCES [dbo].[BookingMain] ([BookingMainID]) ON DELETE CASCADE,
    CONSTRAINT [FK_BookingService_ServiceItem] FOREIGN KEY ([ServiceItemID]) REFERENCES [dbo].[ServiceItem] ([ServiceItemID]) ON DELETE CASCADE
);



