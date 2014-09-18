CREATE TABLE [dbo].[VehicleMake] (
    [VehicleMakeID]          SMALLINT       IDENTITY (1, 1) NOT NULL,
    [VehicleMakeCode]        NVARCHAR (100) NOT NULL,
    [VehicleMakeName]        NVARCHAR (255) NULL,
    [VehicleMakeDescription] NVARCHAR (500) NULL,
    [IsActive]               BIT            CONSTRAINT [DF__VehicleMa__IsAct__18D6A699] DEFAULT ((1)) NOT NULL,
    [IsDeleted]              BIT            CONSTRAINT [DF__VehicleMa__IsDel__19CACAD2] DEFAULT ((0)) NOT NULL,
    [IsReadOnly]             BIT            CONSTRAINT [DF__VehicleMa__IsRea__1ABEEF0B] DEFAULT ((0)) NOT NULL,
    [IsPrivate]              BIT            CONSTRAINT [DF__VehicleMa__IsPri__1BB31344] DEFAULT ((0)) NOT NULL,
    [RecCreatedDt]           DATETIME       NOT NULL,
    [RecCreatedBy]           NVARCHAR (100) NOT NULL,
    [RecLastUpdatedBy]       NVARCHAR (100) NOT NULL,
    [RecLastUpdatedDt]       DATETIME       NOT NULL,
    [RowVersion]             BIGINT         NOT NULL,
    [UserDomainKey]          BIGINT         NOT NULL,
    CONSTRAINT [PK12_1] PRIMARY KEY NONCLUSTERED ([VehicleMakeID] ASC)
);

