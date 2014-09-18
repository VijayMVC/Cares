CREATE TABLE [dbo].[AdditionalDriverCharge] (
    [AdditionalDriverChargeID]      BIGINT         IDENTITY (1, 1) NOT NULL,
    [ChildAdditionalDriverChargeID] BIGINT         NULL,
    [AdditionalDriverChargeRate]    FLOAT (53)     NOT NULL,
    [TariffTypeCode]                NVARCHAR (100) NOT NULL,
    [RevisionNumber]                BIGINT         NOT NULL,
    [StartDt]                       DATETIME       NOT NULL,
    [IsActive]                      BIT            NOT NULL,
    [IsDeleted]                     BIT            NOT NULL,
    [IsPrivate]                     BIT            NOT NULL,
    [IsReadOnly]                    BIT            NOT NULL,
    [RowVersion]                    BIGINT         NOT NULL,
    [RecCreatedDt]                  DATETIME       NOT NULL,
    [RecLastUpdatedDt]              DATETIME       NOT NULL,
    [RecCreatedBy]                  NVARCHAR (100) NOT NULL,
    [RecLastUpdatedBy]              NVARCHAR (100) NOT NULL,
    [UserDomainKey]                 BIGINT         NOT NULL,
    CONSTRAINT [PK80_1_1] PRIMARY KEY NONCLUSTERED ([AdditionalDriverChargeID] ASC),
    CONSTRAINT [RefAdditionalDriverCharge402] FOREIGN KEY ([ChildAdditionalDriverChargeID]) REFERENCES [dbo].[AdditionalDriverCharge] ([AdditionalDriverChargeID])
);

