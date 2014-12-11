CREATE TABLE [dbo].[CaresLicenseType] (
    [LicenseTypeId]    INT            NOT NULL,
    [Name]             NVARCHAR (255) NULL,
    [Price]            FLOAT (53)     NOT NULL,
    [RowVersion]       BIGINT         CONSTRAINT [DF_CaresLicenseType_RowVersion] DEFAULT ((0)) NOT NULL,
    [IsActive]         BIT            CONSTRAINT [DF_CaresLicenseType_IsActive] DEFAULT ((1)) NOT NULL,
    [IsPrivate]        BIT            CONSTRAINT [DF_CaresLicenseType_IsPrivate] DEFAULT ((0)) NOT NULL,
    [IsReadOnly]       BIT            CONSTRAINT [DF_CaresLicenseType_IsReadOnly] DEFAULT ((0)) NOT NULL,
    [IsDeleted]        BIT            CONSTRAINT [DF_CaresLicenseType_IsDeleted] DEFAULT ((0)) NOT NULL,
    [RecCreatedDt]     DATETIME       NOT NULL,
    [RecCreatedBy]     NVARCHAR (100) NOT NULL,
    [RecLastUpdatedDt] DATETIME       NOT NULL,
    [RecLastUpdatedBy] NVARCHAR (100) NOT NULL,
    [UserDomainKey]    BIGINT         NOT NULL,
    CONSTRAINT [PK_CaresLicenseType] PRIMARY KEY CLUSTERED ([LicenseTypeId] ASC)
);

