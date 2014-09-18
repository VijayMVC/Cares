CREATE TABLE [dbo].[Area] (
    [AreaID]           SMALLINT       IDENTITY (1, 1) NOT NULL,
    [AreaCode]         NVARCHAR (100) NOT NULL,
    [AreaName]         NVARCHAR (255) NULL,
    [AreaDescription]  NVARCHAR (500) NULL,
    [CityID]           SMALLINT       NOT NULL,
    [RowVersion]       BIGINT         CONSTRAINT [DF_Area_RowVersion] DEFAULT ((0)) NOT NULL,
    [IsActive]         BIT            CONSTRAINT [DF_Area_IsActive] DEFAULT ((1)) NOT NULL,
    [IsPrivate]        BIT            CONSTRAINT [DF_Area_IsPrivate] DEFAULT ((0)) NOT NULL,
    [IsReadOnly]       BIT            CONSTRAINT [DF_Area_IsReadOnly] DEFAULT ((0)) NOT NULL,
    [IsDeleted]        BIT            CONSTRAINT [DF_Area_IsDeleted] DEFAULT ((0)) NOT NULL,
    [RecCreatedDt]     DATETIME       NOT NULL,
    [RecCreatedBy]     NVARCHAR (100) NOT NULL,
    [RecLastUpdatedDt] DATETIME       NOT NULL,
    [RecLastUpdatedBy] NVARCHAR (100) NOT NULL,
    [UserDomainKey]    BIGINT         NOT NULL,
    CONSTRAINT [PK30] PRIMARY KEY CLUSTERED ([AreaID] ASC),
    CONSTRAINT [RefCity3041] FOREIGN KEY ([CityID]) REFERENCES [dbo].[City] ([CityID])
);

