CREATE TABLE [dbo].[BookingIsurance] (
    [BookingInsuranceID] BIGINT   IDENTITY (1, 1) NOT NULL,
    [BookingMainID]      BIGINT   NOT NULL,
    [InsuranceTypeID]    SMALLINT NOT NULL,
    [StartDate]          DATETIME NOT NULL,
    [EndDate]            DATETIME NOT NULL,
    [UserDomainKey]      BIGINT   NOT NULL,
    CONSTRAINT [PK_BookingIsurance] PRIMARY KEY CLUSTERED ([BookingInsuranceID] ASC),
    CONSTRAINT [FK_BookingIsurance_BookingMain] FOREIGN KEY ([BookingMainID]) REFERENCES [dbo].[BookingMain] ([BookingMainID]) ON DELETE CASCADE,
    CONSTRAINT [FK_BookingIsurance_InsuranceType] FOREIGN KEY ([InsuranceTypeID]) REFERENCES [dbo].[InsuranceType] ([InsuranceTypeID]) ON DELETE CASCADE
);

