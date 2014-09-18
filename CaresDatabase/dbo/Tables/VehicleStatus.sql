CREATE TABLE [dbo].[VehicleStatus] (
    [VehicleStatusID]          SMALLINT       IDENTITY (1, 1) NOT NULL,
    [VehicleStatusCode]        NVARCHAR (100) NOT NULL,
    [VehicleStatusName]        NVARCHAR (255) NULL,
    [VehicleStatusDescription] NVARCHAR (500) NULL,
    [VehicleStatusKey]         SMALLINT       NULL,
    [AvailabilityCheck]        BIT            NOT NULL,
    [IsActive]                 BIT            CONSTRAINT [DF__VehicleSt__IsAct__0BD1B136] DEFAULT ((1)) NOT NULL,
    [IsDeleted]                BIT            CONSTRAINT [DF__VehicleSt__IsDel__0CC5D56F] DEFAULT ((0)) NOT NULL,
    [IsReadOnly]               BIT            CONSTRAINT [DF__VehicleSt__IsRea__0DB9F9A8] DEFAULT ((0)) NOT NULL,
    [IsPrivate]                BIT            CONSTRAINT [DF__VehicleSt__IsPri__0EAE1DE1] DEFAULT ((0)) NOT NULL,
    [RecCreatedDt]             DATETIME       NOT NULL,
    [RecCreatedBy]             NVARCHAR (100) NOT NULL,
    [RecLastUpdatedBy]         NVARCHAR (100) NOT NULL,
    [RecLastUpdatedDt]         DATETIME       NOT NULL,
    [RowVersion]               BIGINT         NOT NULL,
    [UserDomainKey]            BIGINT         NOT NULL,
    CONSTRAINT [PK12_1_2_1_2] PRIMARY KEY NONCLUSTERED ([VehicleStatusID] ASC)
);

