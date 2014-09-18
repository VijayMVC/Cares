CREATE TABLE [dbo].[LicenseType] (
    [LicenseTypeID]          BIGINT         IDENTITY (1, 1) NOT NULL,
    [LicenseTypeCode]        NVARCHAR (100) NOT NULL,
    [LicenseTypeName]        NVARCHAR (255) NULL,
    [LicenseTypeDescription] NVARCHAR (500) NULL,
    [RowVersion]             BIGINT         CONSTRAINT [DF__LicenseTy__RowVe__24B26D99] DEFAULT ((0)) NOT NULL,
    [IsActive]               BIT            CONSTRAINT [DF__LicenseTy__IsAct__25A691D2] DEFAULT ((1)) NOT NULL,
    [IsPrivate]              BIT            CONSTRAINT [DF__LicenseTy__IsPri__269AB60B] DEFAULT ((0)) NOT NULL,
    [IsDeleted]              BIT            CONSTRAINT [DF__LicenseTy__IsDel__278EDA44] DEFAULT ((0)) NOT NULL,
    [IsReadOnly]             BIT            CONSTRAINT [DF__LicenseTy__IsRea__2882FE7D] DEFAULT ((0)) NOT NULL,
    [RecCreatedDt]           DATETIME       NOT NULL,
    [RecCreatedBy]           NVARCHAR (100) NOT NULL,
    [RecLastUpdatedDt]       DATETIME       NOT NULL,
    [RecLastUpdatedBy]       NVARCHAR (100) NOT NULL,
    [UserDomainKey]          BIGINT         NOT NULL,
    CONSTRAINT [PK43_14] PRIMARY KEY CLUSTERED ([LicenseTypeID] ASC)
);

