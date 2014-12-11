CREATE TABLE [dbo].[LicenseDetailsDefault] (
    [LicenseDetailsId] INT            NOT NULL,
    [LicenseTypeId]    INT            NOT NULL,
    [RAPerMonth]       INT            NOT NULL,
    [Employee]         INT            NOT NULL,
    [Branches]         INT            NOT NULL,
    [FleetPools]       INT            NOT NULL,
    [Vehicles]         INT            NOT NULL,
    [RowVersion]       BIGINT         CONSTRAINT [DF_LicenseDetailsDefault_RowVersion] DEFAULT ((0)) NOT NULL,
    [IsActive]         BIT            CONSTRAINT [DF_LicenseDetailsDefault_IsActive] DEFAULT ((1)) NOT NULL,
    [IsPrivate]        BIT            CONSTRAINT [DF_LicenseDetailsDefault_IsPrivate] DEFAULT ((0)) NOT NULL,
    [IsReadOnly]       BIT            CONSTRAINT [DF_LicenseDetailsDefault_IsReadOnly] DEFAULT ((0)) NOT NULL,
    [IsDeleted]        BIT            CONSTRAINT [DF_LicenseDetailsDefault_IsDeleted] DEFAULT ((0)) NOT NULL,
    [RecCreatedDt]     DATETIME       NOT NULL,
    [RecCreatedBy]     NVARCHAR (100) NOT NULL,
    [RecLastUpdatedDt] DATETIME       NOT NULL,
    [RecLastUpdatedBy] NVARCHAR (100) NOT NULL,
    [UserDomainKey]    BIGINT         NOT NULL,
    CONSTRAINT [LicenseDetailsDefault_pk] PRIMARY KEY CLUSTERED ([LicenseDetailsId] ASC),
    CONSTRAINT [LicenseDetailsDefault_fk] FOREIGN KEY ([LicenseTypeId]) REFERENCES [dbo].[CaresLicenseType] ([LicenseTypeId]) ON DELETE CASCADE
);

