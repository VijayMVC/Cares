CREATE TABLE [dbo].[InsuranceRtMain] (
    [InsuranceRtMainID]          BIGINT         IDENTITY (1, 1) NOT NULL,
    [TariffTypeCode]             NVARCHAR (100) NOT NULL,
    [InsuranceRtMainCode]        NVARCHAR (100) NOT NULL,
    [InsuranceRtMainName]        NVARCHAR (255) NULL,
    [InsuranceRtMainDescription] NVARCHAR (500) NULL,
    [StartDt]                    DATETIME       NOT NULL,
    [RowVersion]                 BIGINT         NOT NULL,
    [IsActive]                   BIT            CONSTRAINT [DF_InsuranceRtMain_IsActive] DEFAULT ((1)) NOT NULL,
    [IsDeleted]                  BIT            CONSTRAINT [DF_InsuranceRtMain_IsDeleted] DEFAULT ((0)) NOT NULL,
    [IsPrivate]                  BIT            CONSTRAINT [DF_InsuranceRtMain_IsPrivate] DEFAULT ((0)) NOT NULL,
    [IsReadOnly]                 BIT            CONSTRAINT [DF_InsuranceRtMain_IsReadOnly] DEFAULT ((0)) NOT NULL,
    [RecCreatedDt]               DATETIME       NOT NULL,
    [RecLastUpdatedDt]           DATETIME       NOT NULL,
    [RecCreatedBy]               NVARCHAR (100) NOT NULL,
    [RecLastUpdatedBy]           NVARCHAR (100) NOT NULL,
    [UserDomainKey]              BIGINT         NOT NULL,
    CONSTRAINT [PK82] PRIMARY KEY NONCLUSTERED ([InsuranceRtMainID] ASC)
);

