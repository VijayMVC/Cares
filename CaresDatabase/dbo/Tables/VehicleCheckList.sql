CREATE TABLE [dbo].[VehicleCheckList] (
    [VehicleCheckListID]          SMALLINT       IDENTITY (1, 1) NOT NULL,
    [VehicleCheckListCode]        NVARCHAR (100) NOT NULL,
    [VehicleCheckListName]        NVARCHAR (255) NULL,
    [VehicleCheckListDescription] NVARCHAR (500) NULL,
    [IsInterior]                  BIT            NOT NULL,
    [VehicleCheckListKey]         SMALLINT       NULL,
    [RowVersion]                  BIGINT         CONSTRAINT [DF__VehicleCh__RowVe__05C3D225] DEFAULT ((0)) NOT NULL,
    [IsActive]                    BIT            CONSTRAINT [DF__VehicleCh__IsAct__06B7F65E] DEFAULT ((1)) NOT NULL,
    [IsDeleted]                   BIT            CONSTRAINT [DF__VehicleCh__IsDel__07AC1A97] DEFAULT ((0)) NOT NULL,
    [IsPrivate]                   BIT            CONSTRAINT [DF__VehicleCh__IsPri__08A03ED0] DEFAULT ((0)) NOT NULL,
    [IsReadOnly]                  BIT            CONSTRAINT [DF__VehicleCh__IsRea__09946309] DEFAULT ((0)) NOT NULL,
    [RecCreatedDt]                DATETIME       NOT NULL,
    [RecCreatedBy]                NVARCHAR (100) NOT NULL,
    [RecLastUpdatedDt]            DATETIME       NOT NULL,
    [RecLastUpdatedBy]            NVARCHAR (100) NOT NULL,
    [UserDomainKey]               BIGINT         NOT NULL,
    CONSTRAINT [PK89_1_2_3] PRIMARY KEY NONCLUSTERED ([VehicleCheckListID] ASC)
);

