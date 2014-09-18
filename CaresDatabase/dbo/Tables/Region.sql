CREATE TABLE [dbo].[Region] (
    [RegionID]          SMALLINT       IDENTITY (1, 1) NOT NULL,
    [CountryID]         SMALLINT       NOT NULL,
    [RegionCode]        NVARCHAR (100) NOT NULL,
    [RegionName]        NVARCHAR (255) NULL,
    [RegionDescription] NVARCHAR (500) NULL,
    [RowVersion]        BIGINT         CONSTRAINT [DF_Region_RowVersion] DEFAULT ((0)) NOT NULL,
    [IsActive]          BIT            CONSTRAINT [DF__Region__IsActive__2779CBAB] DEFAULT ((1)) NOT NULL,
    [IsDeleted]         BIT            CONSTRAINT [DF__Region__IsDelete__286DEFE4] DEFAULT ((0)) NOT NULL,
    [IsPrivate]         BIT            CONSTRAINT [DF__Region__IsPrivat__2962141D] DEFAULT ((0)) NOT NULL,
    [IsReadOnly]        BIT            CONSTRAINT [DF__Region__IsReadOn__2A563856] DEFAULT ((0)) NOT NULL,
    [RecCreatedDt]      DATETIME       NOT NULL,
    [RecLastUpdatedBy]  NVARCHAR (100) NOT NULL,
    [RecCreatedBy]      NVARCHAR (100) NOT NULL,
    [RecLastUpdatedDt]  DATETIME       NOT NULL,
    [UserDomainKey]     BIGINT         NOT NULL,
    CONSTRAINT [PK27] PRIMARY KEY NONCLUSTERED ([RegionID] ASC),
    CONSTRAINT [RefCountry41] FOREIGN KEY ([CountryID]) REFERENCES [dbo].[Country] ([CountryID])
);

