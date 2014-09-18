CREATE TABLE [dbo].[Country] (
    [CountryID]          SMALLINT       IDENTITY (1, 1) NOT NULL,
    [CountryCode]        NVARCHAR (100) NOT NULL,
    [CountryName]        NVARCHAR (255) NULL,
    [CountryDescription] NVARCHAR (500) NULL,
    [IsActive]           BIT            CONSTRAINT [DF__Country__IsActiv__3429BB53] DEFAULT ((0)) NOT NULL,
    [IsReadOnly]         BIT            CONSTRAINT [DF__Country__IsReadO__351DDF8C] DEFAULT ((0)) NOT NULL,
    [IsPrivate]          BIT            CONSTRAINT [DF__Country__IsPriva__361203C5] DEFAULT ((0)) NOT NULL,
    [IsDeleted]          BIT            CONSTRAINT [DF__Country__IsDelet__370627FE] DEFAULT ((0)) NOT NULL,
    [RecLastUpdatedDt]   DATETIME       NOT NULL,
    [RecLastUpdatedBy]   NVARCHAR (100) NOT NULL,
    [RecCreatedBy]       NVARCHAR (100) NOT NULL,
    [RecCreatedDt]       DATETIME       NOT NULL,
    [UserDomainKey]      BIGINT         NOT NULL,
    CONSTRAINT [PK25] PRIMARY KEY NONCLUSTERED ([CountryID] ASC)
);

