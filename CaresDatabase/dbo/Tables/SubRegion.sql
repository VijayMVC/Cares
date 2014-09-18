CREATE TABLE [dbo].[SubRegion] (
    [SubRegionID]          SMALLINT       IDENTITY (1, 1) NOT NULL,
    [SubRegionCode]        NVARCHAR (255) NOT NULL,
    [SubRegionName]        NVARCHAR (255) NULL,
    [SubRegionDescription] NVARCHAR (500) NULL,
    [RegionID]             SMALLINT       NOT NULL,
    [RowVersion]           BIGINT         CONSTRAINT [DF_SubRegion_RowVersion] DEFAULT ((0)) NOT NULL,
    [IsActive]             BIT            CONSTRAINT [DF_SubRegion_IsActive] DEFAULT ((1)) NOT NULL,
    [IsPrivate]            BIT            CONSTRAINT [DF_SubRegion_IsPrivate] DEFAULT ((0)) NOT NULL,
    [IsReadOnly]           BIT            CONSTRAINT [DF_SubRegion_IsReadOnly] DEFAULT ((0)) NOT NULL,
    [IsDeleted]            BIT            CONSTRAINT [DF_SubRegion_IsDeleted] DEFAULT ((0)) NOT NULL,
    [RecCreatedDt]         DATETIME       NOT NULL,
    [RecCreatedBy]         NVARCHAR (100) NOT NULL,
    [RecLastUpdatedDt]     DATETIME       NOT NULL,
    [RecLastUpdatedBy]     NVARCHAR (100) NOT NULL,
    [UserDomainKey]        BIGINT         NOT NULL,
    CONSTRAINT [PK28] PRIMARY KEY CLUSTERED ([SubRegionID] ASC),
    CONSTRAINT [RefsubRegion1973] FOREIGN KEY ([RegionID]) REFERENCES [dbo].[Region] ([RegionID])
);

