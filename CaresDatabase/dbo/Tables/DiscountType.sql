CREATE TABLE [dbo].[DiscountType] (
    [DiscountTypeID]          SMALLINT       IDENTITY (1, 1) NOT NULL,
    [DiscountTypeCode]        NVARCHAR (100) NOT NULL,
    [DiscountTypeName]        NVARCHAR (255) NULL,
    [DiscountTypeDescription] NVARCHAR (500) NULL,
    [RowVersion]              BIGINT         NOT NULL,
    [IsActive]                BIT            CONSTRAINT [DF__DiscountT__IsAct__1C1305F7] DEFAULT ((1)) NOT NULL,
    [IsDeleted]               BIT            CONSTRAINT [DF__DiscountT__IsDel__1D072A30] DEFAULT ((0)) NOT NULL,
    [IsPrivate]               BIT            CONSTRAINT [DF__DiscountT__IsPri__1DFB4E69] DEFAULT ((0)) NOT NULL,
    [IsReadOnly]              BIT            CONSTRAINT [DF__DiscountT__IsRea__1EEF72A2] DEFAULT ((0)) NOT NULL,
    [RecCreatedDt]            DATETIME       NOT NULL,
    [RecLastUpdatedDt]        DATETIME       NOT NULL,
    [RecCreatedBy]            NVARCHAR (100) NOT NULL,
    [RecLastUpdatedBy]        NVARCHAR (100) NOT NULL,
    [UserDomainKey]           BIGINT         NOT NULL,
    CONSTRAINT [PK110] PRIMARY KEY NONCLUSTERED ([DiscountTypeID] ASC)
);

