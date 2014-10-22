CREATE TABLE [dbo].[VehiclePurchaseInfo] (
    [VehicleID]           BIGINT         NOT NULL,
    [PurchaseDate]        DATETIME       NULL,
    [PurchasedFrom]       NVARCHAR (255) NULL,
    [PurchaseOrderNumber] NVARCHAR (50)  NULL,
    [PurchaseCost]        MONEY          NULL,
    [IsUsedVehicle]       BIT            NULL,
    [PurchaseDescription] NVARCHAR (500) NULL,
    [BPMainID]            BIGINT         NULL,
    [RecCreatedDt]        DATETIME       NOT NULL,
    [RecCreatedBy]        NVARCHAR (100) NOT NULL,
    [RecLastUpdatedBy]    NVARCHAR (100) NOT NULL,
    [RecLastUpdatedDt]    DATETIME       NOT NULL,
    [RowVersion]          BIGINT         NOT NULL,
    [UserDomainKey]       BIGINT         NOT NULL,
    CONSTRAINT [PK99] PRIMARY KEY NONCLUSTERED ([VehicleID] ASC),
    CONSTRAINT [RefBPMain284] FOREIGN KEY ([BPMainID]) REFERENCES [dbo].[BPMain] ([BPMainID]),
    CONSTRAINT [RefVehicle212] FOREIGN KEY ([VehicleID]) REFERENCES [dbo].[Vehicle] ([VehicleID]) ON DELETE CASCADE
);



