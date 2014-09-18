CREATE TABLE [dbo].[BusinessSegment] (
    [BusinessSegmentID]          SMALLINT       IDENTITY (1, 1) NOT NULL,
    [BusinessSegmentCode]        NVARCHAR (100) NOT NULL,
    [BusinessSegmentName]        NVARCHAR (255) NULL,
    [BusinessSegmentDescription] NVARCHAR (500) NULL,
    [RowVersion]                 BIGINT         CONSTRAINT [DF_BusinessSegment_RowVersion] DEFAULT ((0)) NOT NULL,
    [IsActive]                   BIT            CONSTRAINT [DF__BusinessS__IsAct__0E8E2250] DEFAULT ((1)) NOT NULL,
    [IsDeleted]                  BIT            CONSTRAINT [DF__BusinessS__IsDel__0F824689] DEFAULT ((0)) NOT NULL,
    [IsPrivate]                  BIT            CONSTRAINT [DF__BusinessS__IsPri__10766AC2] DEFAULT ((0)) NOT NULL,
    [IsReadOnly]                 BIT            CONSTRAINT [DF__BusinessS__IsRea__116A8EFB] DEFAULT ((0)) NOT NULL,
    [RecCreatedDt]               DATETIME       NOT NULL,
    [RecCreatedBy]               NVARCHAR (100) NOT NULL,
    [RecLastUpdatedDt]           DATETIME       NOT NULL,
    [RecLastUpdatedBy]           NVARCHAR (100) NOT NULL,
    [UserDomainKey]              BIGINT         NOT NULL,
    CONSTRAINT [PK75] PRIMARY KEY NONCLUSTERED ([BusinessSegmentID] ASC)
);

