CREATE TABLE [dbo].[DiscountSubType] (
    [DiscountSubTypeID]          SMALLINT       IDENTITY (1, 1) NOT NULL,
    [DiscountSubTypeCode]        NVARCHAR (100) NOT NULL,
    [DiscountSubTypeName]        NVARCHAR (255) NULL,
    [DiscountSubTypeDescription] NVARCHAR (500) NULL,
    [DiscountTypeID]             SMALLINT       NOT NULL,
    [RowVersion]                 BIGINT         CONSTRAINT [DF__DiscountS__RowVe__15660868] DEFAULT ((0)) NOT NULL,
    [IsActive]                   BIT            CONSTRAINT [DF__DiscountS__IsAct__165A2CA1] DEFAULT ((1)) NOT NULL,
    [IsDeleted]                  BIT            CONSTRAINT [DF__DiscountS__IsDel__174E50DA] DEFAULT ((0)) NOT NULL,
    [IsPrivate]                  BIT            CONSTRAINT [DF__DiscountS__IsPri__18427513] DEFAULT ((0)) NOT NULL,
    [IsReadOnly]                 BIT            CONSTRAINT [DF__DiscountS__IsRea__1936994C] DEFAULT ((0)) NOT NULL,
    [RecCreatedBy]               NVARCHAR (100) NOT NULL,
    [RecLastUpdatedBy]           NVARCHAR (100) NOT NULL,
    [RecCreatedDt]               DATETIME       NOT NULL,
    [RecLastUpdatedDt]           DATETIME       NOT NULL,
    [UserDomainKey]              BIGINT         NOT NULL,
    CONSTRAINT [PK164] PRIMARY KEY NONCLUSTERED ([DiscountSubTypeID] ASC),
    CONSTRAINT [RefDiscountType374] FOREIGN KEY ([DiscountTypeID]) REFERENCES [dbo].[DiscountType] ([DiscountTypeID])
);

