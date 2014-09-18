CREATE TABLE [dbo].[MarketingChannel] (
    [MarketingChannelID]          SMALLINT       IDENTITY (1, 1) NOT NULL,
    [MarketingChannelCode]        NVARCHAR (100) NOT NULL,
    [MarketingChannelName]        NVARCHAR (255) NULL,
    [MarketingChannelDescription] NVARCHAR (500) NULL,
    [RowVersion]                  BIGINT         CONSTRAINT [DF__Marketing__RowVe__3118447E] DEFAULT ((0)) NOT NULL,
    [IsActive]                    BIT            CONSTRAINT [DF__Marketing__IsAct__320C68B7] DEFAULT ((1)) NOT NULL,
    [IsDeleted]                   BIT            CONSTRAINT [DF__Marketing__IsDel__33008CF0] DEFAULT ((0)) NOT NULL,
    [IsPrivate]                   BIT            CONSTRAINT [DF__Marketing__IsPri__33F4B129] DEFAULT ((0)) NOT NULL,
    [IsReadOnly]                  BIT            CONSTRAINT [DF__Marketing__IsRea__34E8D562] DEFAULT ((0)) NOT NULL,
    [RecCreatedDt]                DATETIME       NOT NULL,
    [RecCreatedBy]                NVARCHAR (100) NOT NULL,
    [RecLastUpdatedDt]            DATETIME       NOT NULL,
    [RecLastUpdatedBy]            NVARCHAR (100) NOT NULL,
    [UserDomainKey]               BIGINT         NOT NULL,
    CONSTRAINT [PK125] PRIMARY KEY CLUSTERED ([MarketingChannelID] ASC)
);

