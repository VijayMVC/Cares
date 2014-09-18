CREATE TABLE [dbo].[RAAdditionalCharge] (
    [RAAdditionalChargeID]   BIGINT         IDENTITY (1, 1) NOT NULL,
    [RAMainID]               BIGINT         NOT NULL,
    [AdditionalChargeTypeID] SMALLINT       NOT NULL,
    [HireGroupDetailID]      BIGINT         NULL,
    [AdditionalChargeRate]   FLOAT (53)     NOT NULL,
    [Quantity]               SMALLINT       CONSTRAINT [DF__RAAdditio__Quant__0504B816] DEFAULT ((1)) NOT NULL,
    [PlateNumber]            NVARCHAR (100) NOT NULL,
    [RowVersion]             BIGINT         NOT NULL,
    [IsActive]               BIT            NOT NULL,
    [IsDeleted]              BIT            NOT NULL,
    [IsPrivate]              BIT            NOT NULL,
    [IsReadOnly]             BIT            NOT NULL,
    [RecCreatedDt]           DATETIME       NOT NULL,
    [RecLastUpdatedDt]       DATETIME       NOT NULL,
    [RecCreatedBy]           NVARCHAR (100) NOT NULL,
    [RecLastUpdatedBy]       NVARCHAR (100) NOT NULL,
    [UserDomainKey]          BIGINT         NOT NULL,
    CONSTRAINT [PK82_1_1] PRIMARY KEY NONCLUSTERED ([RAAdditionalChargeID] ASC),
    CONSTRAINT [RefAdditionalChargeType549] FOREIGN KEY ([AdditionalChargeTypeID]) REFERENCES [dbo].[AdditionalChargeType] ([AdditionalChargeTypeID]),
    CONSTRAINT [RefHireGroupDetail551] FOREIGN KEY ([HireGroupDetailID]) REFERENCES [dbo].[HireGroupDetail] ([HireGroupDetailID]),
    CONSTRAINT [RefRAMain548] FOREIGN KEY ([RAMainID]) REFERENCES [dbo].[RAMain] ([RAMainID])
);

