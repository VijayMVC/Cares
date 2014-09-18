CREATE TABLE [dbo].[NRTVehicle] (
    [NRTVehicleID]     BIGINT         IDENTITY (1, 1) NOT NULL,
    [NRTMainID]        BIGINT         NOT NULL,
    [VehicleID]        BIGINT         NOT NULL,
    [RowVersion]       BIGINT         CONSTRAINT [DF__NRTVehicl__RowVe__4DB4832C] DEFAULT ((0)) NOT NULL,
    [IsActive]         BIT            CONSTRAINT [DF__NRTVehicl__IsAct__4EA8A765] DEFAULT ((1)) NOT NULL,
    [IsDeleted]        BIT            CONSTRAINT [DF__NRTVehicl__IsDel__4F9CCB9E] DEFAULT ((0)) NOT NULL,
    [IsPrivate]        BIT            CONSTRAINT [DF__NRTVehicl__IsPri__5090EFD7] DEFAULT ((0)) NOT NULL,
    [IsReadOnly]       BIT            CONSTRAINT [DF__NRTVehicl__IsRea__51851410] DEFAULT ((0)) NOT NULL,
    [RecCreatedDt]     DATETIME       NOT NULL,
    [RecCreatedBy]     NVARCHAR (100) NOT NULL,
    [RecLastUpdatedDt] DATETIME       NOT NULL,
    [RecLastUpdatedBy] NVARCHAR (100) NOT NULL,
    [UserDomainKey]    BIGINT         NOT NULL,
    CONSTRAINT [PK89_1_3_1_1] PRIMARY KEY NONCLUSTERED ([NRTVehicleID] ASC),
    CONSTRAINT [RefNRTMain606] FOREIGN KEY ([NRTMainID]) REFERENCES [dbo].[NRTMain] ([NRTMainID]),
    CONSTRAINT [RefVehicle594] FOREIGN KEY ([VehicleID]) REFERENCES [dbo].[Vehicle] ([VehicleID])
);

