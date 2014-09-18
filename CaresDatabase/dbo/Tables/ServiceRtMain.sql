CREATE TABLE [dbo].[ServiceRtMain] (
    [ServiceRtMainID]          BIGINT         IDENTITY (1, 1) NOT NULL,
    [ServiceRtMainCode]        NVARCHAR (100) NOT NULL,
    [TariffTypeCode]           NVARCHAR (100) NOT NULL,
    [ServiceRtMainName]        NVARCHAR (255) NULL,
    [ServiceRtMainDescription] NVARCHAR (500) NULL,
    [StartDt]                  DATETIME       NOT NULL,
    [IsActive]                 BIT            CONSTRAINT [DF_ServiceRtMain_IsActive] DEFAULT ((1)) NOT NULL,
    [IsDeleted]                BIT            CONSTRAINT [DF_ServiceRtMain_IsDeleted] DEFAULT ((0)) NOT NULL,
    [IsPrivate]                BIT            CONSTRAINT [DF_ServiceRtMain_IsPrivate] DEFAULT ((0)) NOT NULL,
    [IsReadOnly]               BIT            CONSTRAINT [DF_ServiceRtMain_IsReadOnly] DEFAULT ((0)) NOT NULL,
    [RowVersion]               BIGINT         NOT NULL,
    [RecCreatedDt]             DATETIME       NOT NULL,
    [RecLastUpdatedDt]         DATETIME       NOT NULL,
    [RecLastUpdatedBy]         NVARCHAR (100) NOT NULL,
    [RecCreatedBy]             NVARCHAR (100) NOT NULL,
    [UserDomainKey]            BIGINT         NOT NULL,
    CONSTRAINT [PK111] PRIMARY KEY NONCLUSTERED ([ServiceRtMainID] ASC)
);

