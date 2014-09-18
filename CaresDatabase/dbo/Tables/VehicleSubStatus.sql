CREATE TABLE [dbo].[VehicleSubStatus] (
    [VehicleSubStatusID]          SMALLINT       IDENTITY (1, 1) NOT NULL,
    [VehicleStatusID]             SMALLINT       NOT NULL,
    [VehicleSubStatusCode]        NVARCHAR (100) NOT NULL,
    [VehicleSubStatusName]        NVARCHAR (255) NULL,
    [VehicleSubStatusDescription] NVARCHAR (500) NULL,
    [IsActive]                    BIT            CONSTRAINT [DF__VehicleSu__IsAct__2EC5E7B8] DEFAULT ((1)) NOT NULL,
    [IsDeleted]                   BIT            CONSTRAINT [DF__VehicleSu__IsDel__2FBA0BF1] DEFAULT ((0)) NOT NULL,
    [IsReadOnly]                  BIT            CONSTRAINT [DF__VehicleSu__IsRea__30AE302A] DEFAULT ((0)) NOT NULL,
    [IsPrivate]                   BIT            CONSTRAINT [DF__VehicleSu__IsPri__31A25463] DEFAULT ((0)) NOT NULL,
    [RecCreatedDt]                DATETIME       NOT NULL,
    [RecCreatedBy]                NVARCHAR (100) NOT NULL,
    [RecLastUpdatedBy]            NVARCHAR (100) NOT NULL,
    [RecLastUpdatedDt]            DATETIME       NOT NULL,
    [RowVersion]                  BIGINT         NOT NULL,
    [UserDomainKey]               BIGINT         NOT NULL,
    CONSTRAINT [PK12_1_2_1_2_1] PRIMARY KEY NONCLUSTERED ([VehicleSubStatusID] ASC),
    CONSTRAINT [RefVehicleStatus321] FOREIGN KEY ([VehicleStatusID]) REFERENCES [dbo].[VehicleStatus] ([VehicleStatusID])
);

