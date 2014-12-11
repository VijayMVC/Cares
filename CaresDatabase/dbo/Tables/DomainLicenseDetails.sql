CREATE TABLE [dbo].[DomainLicenseDetails] (
    [DomainLicenseDetailsId] INT            IDENTITY (1, 1) NOT NULL,
    [RAPerMonth]             INT            NOT NULL,
    [Employee]               INT            NOT NULL,
    [Branches]               INT            NOT NULL,
    [FleetPools]             INT            NOT NULL,
    [Vehicles]               INT            NOT NULL,
    [IsActive]               BIT            CONSTRAINT [DF_DomainLicenseDetails_IsActive] DEFAULT ((1)) NOT NULL,
    [IsPrivate]              BIT            CONSTRAINT [DF_DomainLicenseDetails_IsPrivate] DEFAULT ((0)) NOT NULL,
    [IsReadOnly]             BIT            CONSTRAINT [DF_DomainLicenseDetails_IsReadOnly] DEFAULT ((0)) NOT NULL,
    [IsDeleted]              BIT            CONSTRAINT [DF_DomainLicenseDetails_IsDeleted] DEFAULT ((0)) NOT NULL,
    [RecCreatedDt]           DATETIME       NOT NULL,
    [RecCreatedBy]           NVARCHAR (100) NOT NULL,
    [RecLastUpdatedDt]       DATETIME       NOT NULL,
    [RecLastUpdatedBy]       NVARCHAR (100) NOT NULL,
    [UserDomainKey]          BIGINT         NOT NULL,
    CONSTRAINT [PK_DomainLicenseDetails] PRIMARY KEY CLUSTERED ([DomainLicenseDetailsId] ASC)
);

