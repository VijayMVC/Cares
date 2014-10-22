CREATE TABLE [dbo].[BookingAdditionalDriver] (
    [BookingAdditionDriverID]      BIGINT         IDENTITY (1, 1) NOT NULL,
    [BookingMainID]                BIGINT         NOT NULL,
    [AdditionDriverName]           NVARCHAR (255) NOT NULL,
    [AdditionaDriverLicenseNo]     NVARCHAR (100) NOT NULL,
    [AdditionalDriverLicenseExpDt] DATETIME       NOT NULL,
    CONSTRAINT [PK_BookingAdditionalDriver] PRIMARY KEY CLUSTERED ([BookingAdditionDriverID] ASC),
    CONSTRAINT [FK_BookingAdditionalDriver_BookingMain] FOREIGN KEY ([BookingMainID]) REFERENCES [dbo].[BookingMain] ([BookingMainID]) ON DELETE CASCADE
);

