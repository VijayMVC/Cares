CREATE TABLE [dbo].[AdditionalChargeType] (
    [AdditionalChargeTypeID]          SMALLINT       IDENTITY (1, 1) NOT NULL,
    [AdditionalChargeTypeCode]        NVARCHAR (100) NOT NULL,
    [AdditionalChargeTypeName]        NVARCHAR (255) NULL,
    [AdditionalChargeTypeDescription] NVARCHAR (500) NULL,
    [AdditionalChargeKey]             SMALLINT       NULL,
    [IsEditable]                      BIT            NOT NULL,
    [IsActive]                        BIT            CONSTRAINT [DF__Additiona__IsAct__54CB950F] DEFAULT ((1)) NOT NULL,
    [IsDeleted]                       BIT            CONSTRAINT [DF__Additiona__IsDel__55BFB948] DEFAULT ((0)) NOT NULL,
    [IsReadOnly]                      BIT            CONSTRAINT [DF__Additiona__IsRea__56B3DD81] DEFAULT ((0)) NOT NULL,
    [IsPrivate]                       BIT            CONSTRAINT [DF__Additiona__IsPri__57A801BA] DEFAULT ((0)) NOT NULL,
    [RecCreatedDt]                    DATETIME       NOT NULL,
    [RecCreatedBy]                    NVARCHAR (100) NOT NULL,
    [RecLastUpdatedBy]                NVARCHAR (100) NOT NULL,
    [RecLastUpdatedDt]                DATETIME       NOT NULL,
    [RowVersion]                      BIGINT         NOT NULL,
    [UserDomainKey]                   BIGINT         NOT NULL,
    CONSTRAINT [PK12_1_2_2] PRIMARY KEY NONCLUSTERED ([AdditionalChargeTypeID] ASC)
);

