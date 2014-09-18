CREATE TABLE [dbo].[VehicleCategory] (
    [VehicleCategoryID]          SMALLINT       IDENTITY (1, 1) NOT NULL,
    [VehicleCategoryCode]        NVARCHAR (100) NOT NULL,
    [VehicleCategoryName]        NVARCHAR (255) NULL,
    [VehicleCategoryDescription] NVARCHAR (500) NULL,
    [IsActive]                   BIT            CONSTRAINT [DF__VehicleCa__IsAct__01F34141] DEFAULT ((1)) NOT NULL,
    [IsDeleted]                  BIT            CONSTRAINT [DF__VehicleCa__IsDel__02E7657A] DEFAULT ((0)) NOT NULL,
    [IsReadOnly]                 BIT            CONSTRAINT [DF__VehicleCa__IsRea__03DB89B3] DEFAULT ((0)) NOT NULL,
    [IsPrivate]                  BIT            CONSTRAINT [DF__VehicleCa__IsPri__04CFADEC] DEFAULT ((0)) NOT NULL,
    [RecCreatedDt]               DATETIME       NOT NULL,
    [RecCreatedBy]               NVARCHAR (100) NOT NULL,
    [RecLastUpdatedBy]           NVARCHAR (100) NOT NULL,
    [RecLastUpdatedDt]           DATETIME       NOT NULL,
    [RowVersion]                 BIGINT         NOT NULL,
    [UserDomainKey]              BIGINT         NOT NULL,
    CONSTRAINT [PK12_1_2_1] PRIMARY KEY NONCLUSTERED ([VehicleCategoryID] ASC)
);

