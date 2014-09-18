CREATE TABLE [dbo].[BPMarketingChannel] (
    [BPMarketingChannelID] BIGINT         IDENTITY (1, 1) NOT NULL,
    [MarketingChannelID]   SMALLINT       NOT NULL,
    [BPMainID]             BIGINT         NOT NULL,
    [RowVersion]           BIGINT         CONSTRAINT [DF__BPMarketi__RowVe__742F31CF] DEFAULT ((0)) NOT NULL,
    [RecCreatedBy]         NVARCHAR (100) NOT NULL,
    [RecCreatedDt]         DATETIME       NOT NULL,
    [RecLastUpdatedBy]     NVARCHAR (100) NOT NULL,
    [RecLastUpdatedDt]     DATETIME       NOT NULL,
    [UserDomainKey]        BIGINT         NOT NULL,
    CONSTRAINT [PK130] PRIMARY KEY CLUSTERED ([BPMarketingChannelID] ASC),
    CONSTRAINT [RefBPMain299] FOREIGN KEY ([BPMainID]) REFERENCES [dbo].[BPMain] ([BPMainID]),
    CONSTRAINT [RefMarketingChannel298] FOREIGN KEY ([MarketingChannelID]) REFERENCES [dbo].[MarketingChannel] ([MarketingChannelID])
);

