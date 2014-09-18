CREATE TABLE [dbo].[RAVehicleCheckList] (
    [RAVehicleCheckListID]          BIGINT         IDENTITY (1, 1) NOT NULL,
    [Status]                        BIT            NOT NULL,
    [RAHireGroupID]                 BIGINT         NOT NULL,
    [VehicleCheckListID]            SMALLINT       NOT NULL,
    [RAVehicleCheckListDescription] NVARCHAR (500) NULL,
    [RowVersion]                    BIGINT         CONSTRAINT [DF__RAVehicle__RowVe__420DC656] DEFAULT ((0)) NOT NULL,
    [IsActive]                      BIT            CONSTRAINT [DF__RAVehicle__IsAct__4301EA8F] DEFAULT ((1)) NOT NULL,
    [IsDeleted]                     BIT            CONSTRAINT [DF__RAVehicle__IsDel__43F60EC8] DEFAULT ((0)) NOT NULL,
    [IsPrivate]                     BIT            CONSTRAINT [DF__RAVehicle__IsPri__44EA3301] DEFAULT ((0)) NOT NULL,
    [IsReadOnly]                    BIT            CONSTRAINT [DF__RAVehicle__IsRea__45DE573A] DEFAULT ((0)) NOT NULL,
    [RecCreatedDt]                  DATETIME       NOT NULL,
    [RecCreatedBy]                  NVARCHAR (100) NOT NULL,
    [RecLastUpdatedDt]              DATETIME       NOT NULL,
    [RecLastUpdatedBy]              NVARCHAR (100) NOT NULL,
    [UserDomainKey]                 BIGINT         NOT NULL,
    CONSTRAINT [PK126_1_1_1] PRIMARY KEY NONCLUSTERED ([RAVehicleCheckListID] ASC),
    CONSTRAINT [RefRAHireGroup525] FOREIGN KEY ([RAHireGroupID]) REFERENCES [dbo].[RAHireGroup] ([RAHireGroupID]),
    CONSTRAINT [RefVehicleCheckList520] FOREIGN KEY ([VehicleCheckListID]) REFERENCES [dbo].[VehicleCheckList] ([VehicleCheckListID])
);

