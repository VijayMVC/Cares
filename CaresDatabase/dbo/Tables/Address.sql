CREATE TABLE [dbo].[Address] (
    [AddressID]        BIGINT         IDENTITY (1, 1) NOT NULL,
    [ContactPerson]    NVARCHAR (255) NULL,
    [StreetAddress]    NVARCHAR (500) NOT NULL,
    [EmailAddress]     NVARCHAR (255) NULL,
    [WebPage]          NVARCHAR (500) NULL,
    [ZipCode]          NVARCHAR (10)  NULL,
    [POBox]            NVARCHAR (20)  NULL,
    [CountryID]        SMALLINT       NOT NULL,
    [RegionID]         SMALLINT       NULL,
    [SubRegionID]      SMALLINT       NULL,
    [CityID]           SMALLINT       NULL,
    [AreaID]           SMALLINT       NULL,
    [AddressTypeID]    SMALLINT       NOT NULL,
    [BPMainID]         BIGINT         NULL,
    [EmployeeID]       BIGINT         NULL,
    [RowVersion]       BIGINT         CONSTRAINT [DF_Address_RowVersion] DEFAULT ((0)) NOT NULL,
    [IsActive]         BIT            CONSTRAINT [DF__Address__IsActiv__031C6FA4] DEFAULT ((1)) NOT NULL,
    [IsDeleted]        BIT            CONSTRAINT [DF__Address__IsDelet__041093DD] DEFAULT ((0)) NOT NULL,
    [IsPrivate]        BIT            CONSTRAINT [DF__Address__IsPriva__0504B816] DEFAULT ((0)) NOT NULL,
    [IsReadOnly]       BIT            CONSTRAINT [DF__Address__IsReadO__05F8DC4F] DEFAULT ((0)) NOT NULL,
    [RecCreatedDt]     DATETIME       NOT NULL,
    [RecCreatedBy]     NVARCHAR (100) NOT NULL,
    [RecLastUpdatedDt] DATETIME       NOT NULL,
    [RecLastUpdatedBy] NVARCHAR (100) NOT NULL,
    [UserDomainKey]    BIGINT         NOT NULL,
    CONSTRAINT [PK32] PRIMARY KEY NONCLUSTERED ([AddressID] ASC),
    CONSTRAINT [RefAddressType1971] FOREIGN KEY ([AddressTypeID]) REFERENCES [dbo].[AddressType] ([AddressTypeID]),
    CONSTRAINT [RefArea1973] FOREIGN KEY ([AreaID]) REFERENCES [dbo].[Area] ([AreaID]),
    CONSTRAINT [RefBPMain241] FOREIGN KEY ([BPMainID]) REFERENCES [dbo].[BPMain] ([BPMainID]),
    CONSTRAINT [RefCity1973] FOREIGN KEY ([CityID]) REFERENCES [dbo].[City] ([CityID]),
    CONSTRAINT [RefCountry1971] FOREIGN KEY ([CountryID]) REFERENCES [dbo].[Country] ([CountryID]),
    CONSTRAINT [RefEmployee343] FOREIGN KEY ([EmployeeID]) REFERENCES [dbo].[Employee] ([EmployeeID]) ON DELETE CASCADE,
    CONSTRAINT [RefRegion332] FOREIGN KEY ([RegionID]) REFERENCES [dbo].[Region] ([RegionID]),
    CONSTRAINT [RefSubRegion333] FOREIGN KEY ([SubRegionID]) REFERENCES [dbo].[SubRegion] ([SubRegionID])
);





