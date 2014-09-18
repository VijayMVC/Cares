CREATE TABLE [dbo].[VehicleDepreciation] (
    [VehicleID]             BIGINT         NOT NULL,
    [UsefulPeriodStartDate] DATETIME       NULL,
    [FirstMonthDepAmount]   MONEY          NULL,
    [MonthlyDepAmount]      MONEY          NULL,
    [LastMonthDepAmount]    MONEY          NULL,
    [ResidualValue]         MONEY          NULL,
    [UsefulPeriodEndDate]   DATETIME       NULL,
    [RowVersion]            BIGINT         NOT NULL,
    [RecCreatedDt]          DATETIME       NOT NULL,
    [RecCreatedBy]          NVARCHAR (100) NOT NULL,
    [RecLastUpdatedBy]      NVARCHAR (100) NOT NULL,
    [RecLastUpdatedDt]      DATETIME       NOT NULL,
    [UserDomainKey]         BIGINT         NOT NULL,
    CONSTRAINT [PK_VehicleDepreciation_1] PRIMARY KEY CLUSTERED ([VehicleID] ASC),
    CONSTRAINT [RefVehicle2251] FOREIGN KEY ([VehicleID]) REFERENCES [dbo].[Vehicle] ([VehicleID])
);

