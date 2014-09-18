CREATE TABLE [dbo].[NRTCharge] (
    [NRTChargeID]            BIGINT         IDENTITY (1, 1) NOT NULL,
    [TotalNRTChargeRate]     FLOAT (53)     CONSTRAINT [DF__NRTCharge__Total__3E723F9C] DEFAULT ((0)) NOT NULL,
    [ContactPerson]          NVARCHAR (100) NULL,
    [Description]            NVARCHAR (500) NULL,
    [NRTChargeRate]          FLOAT (53)     NOT NULL,
    [Quantity]               SMALLINT       CONSTRAINT [DF__NRTCharge__Quant__3F6663D5] DEFAULT ((1)) NOT NULL,
    [RowVersion]             BIGINT         NOT NULL,
    [IsActive]               BIT            NOT NULL,
    [IsDeleted]              BIT            NOT NULL,
    [IsPrivate]              BIT            NOT NULL,
    [IsReadOnly]             BIT            NOT NULL,
    [RecCreatedDt]           DATETIME       NOT NULL,
    [RecLastUpdatedDt]       DATETIME       NOT NULL,
    [RecCreatedBy]           NVARCHAR (100) NOT NULL,
    [RecLastUpdatedBy]       NVARCHAR (100) NOT NULL,
    [AdditionalChargeTypeID] SMALLINT       NOT NULL,
    [NRTVehicleID]           BIGINT         NOT NULL,
    [UserDomainKey]          BIGINT         NOT NULL,
    CONSTRAINT [PK82_1_1_1] PRIMARY KEY NONCLUSTERED ([NRTChargeID] ASC),
    CONSTRAINT [RefAdditionalChargeType586] FOREIGN KEY ([AdditionalChargeTypeID]) REFERENCES [dbo].[AdditionalChargeType] ([AdditionalChargeTypeID]),
    CONSTRAINT [RefNRTVehicle597] FOREIGN KEY ([NRTVehicleID]) REFERENCES [dbo].[NRTVehicle] ([NRTVehicleID])
);

