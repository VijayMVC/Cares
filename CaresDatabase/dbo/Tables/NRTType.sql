CREATE TABLE [dbo].[NRTType] (
    [NRTTypeID]        BIGINT         IDENTITY (1, 1) NOT NULL,
    [NRTTypeCode]      NVARCHAR (100) NOT NULL,
    [NRTTypeKey]       INT            NULL,
    [NRTTypeName]      NVARCHAR (255) NOT NULL,
    [Description]      NVARCHAR (500) NULL,
    [StandardLifeTime] FLOAT (53)     NULL,
    [RowVersion]       BIGINT         NOT NULL,
    [IsActive]         BIT            CONSTRAINT [DF__NRTType__IsActiv__49E3F248] DEFAULT ((1)) NOT NULL,
    [IsDeleted]        BIT            CONSTRAINT [DF__NRTType__IsDelet__4AD81681] DEFAULT ((0)) NOT NULL,
    [IsPrivate]        BIT            CONSTRAINT [DF__NRTType__IsPriva__4BCC3ABA] DEFAULT ((0)) NOT NULL,
    [IsReadOnly]       BIT            CONSTRAINT [DF__NRTType__IsReadO__4CC05EF3] DEFAULT ((0)) NOT NULL,
    [RecCreatedBy]     NVARCHAR (100) NOT NULL,
    [RecCreatedDt]     DATETIME       NOT NULL,
    [RecLastUpdatedBy] NVARCHAR (100) NOT NULL,
    [RecLastUpdatedDt] DATETIME       NOT NULL,
    [VehicleStatusID]  SMALLINT       NULL,
    [UserDomainKey]    BIGINT         NOT NULL,
    CONSTRAINT [PK249] PRIMARY KEY NONCLUSTERED ([NRTTypeID] ASC),
    CONSTRAINT [RefVehicleStatus610] FOREIGN KEY ([VehicleStatusID]) REFERENCES [dbo].[VehicleStatus] ([VehicleStatusID])
);

