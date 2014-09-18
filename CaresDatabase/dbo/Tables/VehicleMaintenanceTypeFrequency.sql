CREATE TABLE [dbo].[VehicleMaintenanceTypeFrequency] (
    [MaintenanceTypeFrequencyID] BIGINT         IDENTITY (1, 1) NOT NULL,
    [VehicleID]                  BIGINT         NOT NULL,
    [MaintenanceStartDate]       DATETIME       NOT NULL,
    [Frequency]                  INT            NULL,
    [FrequencyKiloMeter]         INT            NULL,
    [MaintenanceTypeID]          SMALLINT       NOT NULL,
    [RowVersion]                 BIGINT         NOT NULL,
    [RecCreatedDt]               DATETIME       NOT NULL,
    [RecCreatedBy]               NVARCHAR (100) NOT NULL,
    [RecLastUpdatedBy]           NVARCHAR (100) NOT NULL,
    [RecLastUpdatedDt]           DATETIME       NOT NULL,
    [UserDomainKey]              BIGINT         NOT NULL,
    CONSTRAINT [PK106] PRIMARY KEY NONCLUSTERED ([MaintenanceTypeFrequencyID] ASC),
    CONSTRAINT [RefMaintenanceType314] FOREIGN KEY ([MaintenanceTypeID]) REFERENCES [dbo].[MaintenanceType] ([MaintenanceTypeID]),
    CONSTRAINT [RefVehicle220] FOREIGN KEY ([VehicleID]) REFERENCES [dbo].[Vehicle] ([VehicleID])
);

