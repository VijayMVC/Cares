CREATE TABLE [dbo].[VehicleDisposalInfo] (
    [VehicleID]           BIGINT         NOT NULL,
    [SaleDate]            DATETIME       NULL,
    [SalePrice]           MONEY          NULL,
    [SoldTo]              NVARCHAR (255) NULL,
    [DisposalDescription] NVARCHAR (500) NULL,
    [BPMainID]            BIGINT         NULL,
    [RecCreatedDt]        DATETIME       NOT NULL,
    [RecCreatedBy]        NVARCHAR (100) NOT NULL,
    [RecLastUpdatedDt]    DATETIME       NOT NULL,
    [RecLastUpdatedBy]    NVARCHAR (100) NOT NULL,
    [RowVersion]          BIGINT         NOT NULL,
    [UserDomainKey]       BIGINT         NOT NULL,
    CONSTRAINT [PK100] PRIMARY KEY NONCLUSTERED ([VehicleID] ASC),
    CONSTRAINT [RefBPMain287] FOREIGN KEY ([BPMainID]) REFERENCES [dbo].[BPMain] ([BPMainID]),
    CONSTRAINT [RefVehicle213] FOREIGN KEY ([VehicleID]) REFERENCES [dbo].[Vehicle] ([VehicleID])
);

