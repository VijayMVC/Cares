CREATE TABLE [dbo].[BPCompany] (
    [BPMainID]          BIGINT         NOT NULL,
    [BPCompanyCode]     NVARCHAR (100) NOT NULL,
    [BPCompanyName]     NVARCHAR (255) NULL,
    [EstablishedSince]  DATETIME       NULL,
    [SwiftCode]         NVARCHAR (100) NULL,
    [AccountNumber]     NVARCHAR (100) NULL,
    [BusinessSegmentID] SMALLINT       NULL,
    [RowVersion]        BIGINT         CONSTRAINT [DF__BPCompany__RowVe__5887175A] DEFAULT ((0)) NOT NULL,
    [RecCreatedBy]      NVARCHAR (100) NOT NULL,
    [RecCreatedDt]      DATETIME       NOT NULL,
    [RecLastUpdatedBy]  NVARCHAR (100) NOT NULL,
    [RecLastUpdatedDt]  DATETIME       NOT NULL,
    [UserDomainKey]     BIGINT         NOT NULL,
    CONSTRAINT [PK70] PRIMARY KEY CLUSTERED ([BPMainID] ASC),
    CONSTRAINT [RefBPMain122] FOREIGN KEY ([BPMainID]) REFERENCES [dbo].[BPMain] ([BPMainID]),
    CONSTRAINT [RefBusinessSegment297] FOREIGN KEY ([BusinessSegmentID]) REFERENCES [dbo].[BusinessSegment] ([BusinessSegmentID])
);

