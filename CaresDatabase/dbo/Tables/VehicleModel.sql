CREATE TABLE [dbo].[VehicleModel] (
    [VehicleModelID]          SMALLINT       IDENTITY (1, 1) NOT NULL,
    [VehicleModelCode]        NVARCHAR (100) NOT NULL,
    [VehicleModelName]        NVARCHAR (255) NULL,
    [VehicleModelDescription] NVARCHAR (500) NULL,
    [IsActive]                BIT            CONSTRAINT [DF__VehicleMo__IsAct__1CA7377D] DEFAULT ((1)) NOT NULL,
    [IsDeleted]               BIT            CONSTRAINT [DF__VehicleMo__IsDel__1D9B5BB6] DEFAULT ((0)) NOT NULL,
    [IsReadOnly]              BIT            CONSTRAINT [DF__VehicleMo__IsRea__1E8F7FEF] DEFAULT ((0)) NOT NULL,
    [IsPrivate]               BIT            CONSTRAINT [DF__VehicleMo__IsPri__1F83A428] DEFAULT ((0)) NOT NULL,
    [RecCreatedDt]            DATETIME       NOT NULL,
    [RecCreatedBy]            NVARCHAR (100) NOT NULL,
    [RecLastUpdatedBy]        NVARCHAR (100) NOT NULL,
    [RecLastUpdatedDt]        DATETIME       NOT NULL,
    [RowVersion]              BIGINT         NOT NULL,
    [UserDomainKey]           BIGINT         NOT NULL,
    CONSTRAINT [PK12_1_2_1_1] PRIMARY KEY NONCLUSTERED ([VehicleModelID] ASC)
);

