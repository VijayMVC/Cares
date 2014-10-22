CREATE TABLE [dbo].[VehicleCheckListItem] (
    [VehicleCheckListItemID] BIGINT         IDENTITY (1, 1) NOT NULL,
    [VehicleCheckListID]     SMALLINT       NOT NULL,
    [VehicleID]              BIGINT         NOT NULL,
    [RowVersion]             BIGINT         NOT NULL,
    [IsActive]               BIT            CONSTRAINT [DF__VehicleCh__IsAct__0A888742] DEFAULT ((1)) NOT NULL,
    [IsDeleted]              BIT            CONSTRAINT [DF__VehicleCh__IsDel__0B7CAB7B] DEFAULT ((0)) NOT NULL,
    [IsReadOnly]             BIT            CONSTRAINT [DF__VehicleCh__IsRea__0C70CFB4] DEFAULT ((0)) NOT NULL,
    [IsPrivate]              BIT            CONSTRAINT [DF__VehicleCh__IsPri__0D64F3ED] DEFAULT ((0)) NOT NULL,
    [RecCreatedDt]           DATETIME       NOT NULL,
    [RecCreatedBy]           NVARCHAR (100) NOT NULL,
    [RecLastUpdatedBy]       NVARCHAR (100) NOT NULL,
    [RecLastUpdatedDt]       DATETIME       NOT NULL,
    [UserDomainKey]          BIGINT         NOT NULL,
    CONSTRAINT [PK106_1] PRIMARY KEY NONCLUSTERED ([VehicleCheckListItemID] ASC),
    CONSTRAINT [RefVehicle609] FOREIGN KEY ([VehicleID]) REFERENCES [dbo].[Vehicle] ([VehicleID]) ON DELETE CASCADE,
    CONSTRAINT [RefVehicleCheckList608] FOREIGN KEY ([VehicleCheckListID]) REFERENCES [dbo].[VehicleCheckList] ([VehicleCheckListID])
);



