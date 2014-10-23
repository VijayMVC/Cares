CREATE TABLE [dbo].[BookingService] (
    [BookingServiceID] BIGINT   IDENTITY (1, 1) NOT NULL,
    [BookingMainID]    BIGINT   NOT NULL,
    [ServiceTypeID]    SMALLINT NOT NULL,
    [StartDate]        DATETIME NOT NULL,
    [EndDate]          DATETIME NOT NULL,
    [DomainKey]        BIGINT   NOT NULL,
    CONSTRAINT [PK_BookingService] PRIMARY KEY CLUSTERED ([BookingServiceID] ASC),
    CONSTRAINT [FK_BookingService_BookingMain] FOREIGN KEY ([BookingMainID]) REFERENCES [dbo].[BookingMain] ([BookingMainID]) ON DELETE CASCADE,
    CONSTRAINT [FK_BookingService_ServiceType] FOREIGN KEY ([ServiceTypeID]) REFERENCES [dbo].[ServiceType] ([ServiceTypeID]) ON DELETE CASCADE
);

