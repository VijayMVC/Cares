CREATE TABLE [dbo].[VehicleImageHireGroupDetail] (
    [VehicleImageHireGroupDetailID] BIGINT         IDENTITY (1, 1) NOT NULL,
    [VehicleImageID]                BIGINT         NOT NULL,
    [HireGroupDetailID]             BIGINT         NOT NULL,
    [RowVersion]                    BIGINT         CONSTRAINT [DF__VehicleIm__RowVe__131DCD43] DEFAULT ((0)) NOT NULL,
    [IsActive]                      BIT            CONSTRAINT [DF__VehicleIm__IsAct__1411F17C] DEFAULT ((1)) NOT NULL,
    [IsDeleted]                     BIT            CONSTRAINT [DF__VehicleIm__IsDel__150615B5] DEFAULT ((0)) NOT NULL,
    [IsPrivate]                     BIT            CONSTRAINT [DF__VehicleIm__IsPri__15FA39EE] DEFAULT ((0)) NOT NULL,
    [IsReadOnly]                    BIT            CONSTRAINT [DF__VehicleIm__IsRea__16EE5E27] DEFAULT ((0)) NOT NULL,
    [RecCreatedDt]                  DATETIME       NOT NULL,
    [RecCreatedBy]                  NVARCHAR (100) NOT NULL,
    [RecLastUpdatedDt]              DATETIME       NOT NULL,
    [RecLastUpdatedBy]              NVARCHAR (100) NOT NULL,
    [UserDomainKey]                 BIGINT         NOT NULL,
    CONSTRAINT [PK61_1_1] PRIMARY KEY CLUSTERED ([VehicleImageHireGroupDetailID] ASC, [VehicleImageID] ASC, [HireGroupDetailID] ASC),
    CONSTRAINT [RefHireGroupDetail627] FOREIGN KEY ([HireGroupDetailID]) REFERENCES [dbo].[HireGroupDetail] ([HireGroupDetailID]),
    CONSTRAINT [RefVehicleImage626] FOREIGN KEY ([VehicleImageID]) REFERENCES [dbo].[VehicleImage] ([VehicleImageID])
);

