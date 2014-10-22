CREATE TABLE [dbo].[VehicleLeasedInfo] (
    [VehicleID]         BIGINT         NOT NULL,
    [DownPayment]       MONEY          NULL,
    [LeasedStartDate]   DATETIME       NULL,
    [LeasedFinishDate]  DATETIME       NULL,
    [MonthlyPayment]    MONEY          NULL,
    [InterestRate]      FLOAT (53)     NULL,
    [PrinicipalPayment] MONEY          NULL,
    [FirstPaymentDate]  DATETIME       NULL,
    [LeasedFrom]        NVARCHAR (255) NULL,
    [LeaseToOwnership]  BIT            NULL,
    [LastMonthPayment]  MONEY          NULL,
    [FirstMonthPayment] MONEY          NULL,
    [BPMainID]          BIGINT         NULL,
    [RecCreatedDt]      DATETIME       NOT NULL,
    [RecLastUpdatedBy]  NVARCHAR (100) NOT NULL,
    [RecCreatedBy]      NVARCHAR (100) NOT NULL,
    [RowVersion]        BIGINT         NOT NULL,
    [RecLastUpdatedDt]  DATETIME       NOT NULL,
    [UserDomainKey]     BIGINT         NOT NULL,
    CONSTRAINT [PK3] PRIMARY KEY NONCLUSTERED ([VehicleID] ASC),
    CONSTRAINT [RefBPMain286] FOREIGN KEY ([BPMainID]) REFERENCES [dbo].[BPMain] ([BPMainID]),
    CONSTRAINT [RefVehicle210] FOREIGN KEY ([VehicleID]) REFERENCES [dbo].[Vehicle] ([VehicleID]) ON DELETE CASCADE
);



