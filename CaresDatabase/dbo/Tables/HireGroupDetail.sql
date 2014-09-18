CREATE TABLE [dbo].[HireGroupDetail] (
    [HireGroupDetailID] BIGINT         IDENTITY (1, 1) NOT NULL,
    [HireGroupID]       BIGINT         NOT NULL,
    [VehicleCategoryID] SMALLINT       NOT NULL,
    [ModelYear]         SMALLINT       NOT NULL,
    [VehicleModelID]    SMALLINT       NOT NULL,
    [VehicleMakeID]     SMALLINT       NOT NULL,
    [RowVersion]        BIGINT         NOT NULL,
    [IsActive]          BIT            CONSTRAINT [DF__HireGroup__IsAct__08162EEB] DEFAULT ((1)) NOT NULL,
    [IsDeleted]         BIT            CONSTRAINT [DF__HireGroup__IsDel__090A5324] DEFAULT ((0)) NOT NULL,
    [IsReadOnly]        BIT            CONSTRAINT [DF__HireGroup__IsRea__09FE775D] DEFAULT ((0)) NOT NULL,
    [IsPrivate]         BIT            CONSTRAINT [DF__HireGroup__IsPri__0AF29B96] DEFAULT ((0)) NOT NULL,
    [RecCreatedDt]      DATETIME       NOT NULL,
    [RecCreatedBy]      NVARCHAR (100) NOT NULL,
    [RecLastUpdatedBy]  NVARCHAR (100) NOT NULL,
    [RecLastUpdatedDt]  DATETIME       NOT NULL,
    [UserDomainKey]     BIGINT         NOT NULL,
    CONSTRAINT [PK12_2] PRIMARY KEY NONCLUSTERED ([HireGroupDetailID] ASC),
    CONSTRAINT [RefHireGroup360] FOREIGN KEY ([HireGroupID]) REFERENCES [dbo].[HireGroup] ([HireGroupID]),
    CONSTRAINT [RefVehicleCategory361] FOREIGN KEY ([VehicleCategoryID]) REFERENCES [dbo].[VehicleCategory] ([VehicleCategoryID]),
    CONSTRAINT [RefVehicleMake363] FOREIGN KEY ([VehicleMakeID]) REFERENCES [dbo].[VehicleMake] ([VehicleMakeID]),
    CONSTRAINT [RefVehicleModel362] FOREIGN KEY ([VehicleModelID]) REFERENCES [dbo].[VehicleModel] ([VehicleModelID])
);

