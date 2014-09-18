CREATE TABLE [dbo].[StandardRtMain] (
    [StandardRtMainID]          BIGINT         IDENTITY (1, 1) NOT NULL,
    [StandardRtMainCode]        NVARCHAR (100) NOT NULL,
    [TariffTypeCode]            NVARCHAR (100) NOT NULL,
    [StandardRtMainName]        NVARCHAR (255) NULL,
    [StandardRtMainDescription] NVARCHAR (500) NULL,
    [StartDt]                   DATETIME       NOT NULL,
    [EndDt]                     DATETIME       NOT NULL,
    [RowVersion]                BIGINT         NOT NULL,
    [IsActive]                  BIT            NOT NULL,
    [IsDeleted]                 BIT            NOT NULL,
    [IsPrivate]                 BIT            NOT NULL,
    [IsReadOnly]                BIT            NOT NULL,
    [RecCreatedDt]              DATETIME       NOT NULL,
    [RecLastUpdatedDt]          DATETIME       NOT NULL,
    [RecCreatedBy]              NVARCHAR (100) NOT NULL,
    [RecLastUpdatedBy]          NVARCHAR (100) NOT NULL,
    [UserDomainKey]             BIGINT         NOT NULL,
    CONSTRAINT [PK79] PRIMARY KEY NONCLUSTERED ([StandardRtMainID] ASC)
);

