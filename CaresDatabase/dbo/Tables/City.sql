CREATE TABLE [dbo].[City] (
    [CityID]           SMALLINT       IDENTITY (1, 1) NOT NULL,
    [CityCode]         NVARCHAR (100) NOT NULL,
    [CityName]         NVARCHAR (255) NULL,
    [CityDescription]  NVARCHAR (500) NULL,
    [RegionID]         SMALLINT       NULL,
    [SubRegionID]      SMALLINT       NULL,
    [CountryID]        SMALLINT       NOT NULL,
    [RowVersion]       BIGINT         CONSTRAINT [DF_City_RowVersion] DEFAULT ((0)) NOT NULL,
    [IsActive]         BIT            CONSTRAINT [DF_City_IsActive] DEFAULT ((1)) NOT NULL,
    [IsPrivate]        BIT            CONSTRAINT [DF_City_IsPrivate] DEFAULT ((0)) NOT NULL,
    [IsReadOnly]       BIT            CONSTRAINT [DF_City_IsReadOnly] DEFAULT ((0)) NOT NULL,
    [IsDeleted]        BIT            CONSTRAINT [DF_City_IsDeleted] DEFAULT ((0)) NOT NULL,
    [RecCreatedDt]     DATETIME       NOT NULL,
    [RecCreatedBy]     NVARCHAR (100) NOT NULL,
    [RecLastUpdatedDt] DATETIME       NOT NULL,
    [RecLastUpdatedBy] NVARCHAR (100) NOT NULL,
    [UserDomainKey]    BIGINT         NOT NULL,
    CONSTRAINT [PK31] PRIMARY KEY CLUSTERED ([CityID] ASC),
    CONSTRAINT [RefCountry291] FOREIGN KEY ([CountryID]) REFERENCES [dbo].[Country] ([CountryID]),
    CONSTRAINT [RefRegion291] FOREIGN KEY ([RegionID]) REFERENCES [dbo].[Region] ([RegionID]),
    CONSTRAINT [RefSubRegion291] FOREIGN KEY ([SubRegionID]) REFERENCES [dbo].[SubRegion] ([SubRegionID])
);

