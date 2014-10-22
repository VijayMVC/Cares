CREATE TABLE [dbo].[VehicleImage] (
    [VehicleImageID]          BIGINT         IDENTITY (1, 1) NOT NULL,
    [VehicleID]               BIGINT         NOT NULL,
    [Image]                   IMAGE          NOT NULL,
    [VehicleImageCode]        NVARCHAR (255) NOT NULL,
    [VehicleImageName]        NVARCHAR (255) NULL,
    [VehicleImageDescription] NVARCHAR (500) NULL,
    [RowVersion]              BIGINT         CONSTRAINT [DF__VehicleIm__RowVe__68343A95] DEFAULT ((0)) NOT NULL,
    [IsActive]                BIT            CONSTRAINT [DF__VehicleIm__IsAct__69285ECE] DEFAULT ((1)) NOT NULL,
    [IsDeleted]               BIT            CONSTRAINT [DF__VehicleIm__IsDel__6A1C8307] DEFAULT ((0)) NOT NULL,
    [IsPrivate]               BIT            CONSTRAINT [DF__VehicleIm__IsPri__6B10A740] DEFAULT ((0)) NOT NULL,
    [IsReadOnly]              BIT            CONSTRAINT [DF__VehicleIm__IsRea__6C04CB79] DEFAULT ((0)) NOT NULL,
    [RecCreatedDt]            DATETIME       NOT NULL,
    [RecCreatedBy]            NVARCHAR (100) NOT NULL,
    [RecLastUpdatedDt]        DATETIME       NOT NULL,
    [RecLastUpdatedBy]        NVARCHAR (100) NOT NULL,
    [UserDomainKey]           BIGINT         NOT NULL,
    CONSTRAINT [PK61_1] PRIMARY KEY CLUSTERED ([VehicleImageID] ASC),
    CONSTRAINT [FK_VehicleImage_Vehicle] FOREIGN KEY ([VehicleID]) REFERENCES [dbo].[Vehicle] ([VehicleID])
);



