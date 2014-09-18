CREATE TABLE [dbo].[AdditionalCharge] (
    [AdditionalChargeID]      BIGINT         IDENTITY (1, 1) NOT NULL,
    [ChildAdditionalChargeID] BIGINT         NULL,
    [AdditionalChargeTypeID]  SMALLINT       NOT NULL,
    [HireGroupDetailID]       BIGINT         NULL,
    [AdditionalChargeRate]    FLOAT (53)     NULL,
    [StartDt]                 DATETIME       NOT NULL,
    [RowVersion]              BIGINT         NOT NULL,
    [RevisionNumber]          BIGINT         NULL,
    [IsActive]                BIT            NOT NULL,
    [IsDeleted]               BIT            NOT NULL,
    [IsPrivate]               BIT            NOT NULL,
    [IsReadOnly]              BIT            NOT NULL,
    [RecCreatedDt]            DATETIME       NOT NULL,
    [RecLastUpdatedDt]        DATETIME       NOT NULL,
    [RecCreatedBy]            NVARCHAR (100) NOT NULL,
    [RecLastUpdatedBy]        NVARCHAR (100) NOT NULL,
    [UserDomainKey]           BIGINT         NOT NULL,
    CONSTRAINT [PK82_1] PRIMARY KEY NONCLUSTERED ([AdditionalChargeID] ASC),
    CONSTRAINT [RefAdditionalCharge400] FOREIGN KEY ([ChildAdditionalChargeID]) REFERENCES [dbo].[AdditionalCharge] ([AdditionalChargeID]),
    CONSTRAINT [RefAdditionalChargeType393] FOREIGN KEY ([AdditionalChargeTypeID]) REFERENCES [dbo].[AdditionalChargeType] ([AdditionalChargeTypeID]),
    CONSTRAINT [RefHireGroupDetail394] FOREIGN KEY ([HireGroupDetailID]) REFERENCES [dbo].[HireGroupDetail] ([HireGroupDetailID])
);

