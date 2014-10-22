CREATE TABLE [dbo].[BPDocument] (
    [BPDocumentID]          BIGINT         IDENTITY (1, 1) NOT NULL,
    [BPDocumentCode]        NVARCHAR (100) NOT NULL,
    [BPDocumentName]        NVARCHAR (255) NULL,
    [BPDocumentDescription] NVARCHAR (500) NULL,
    [Document]              IMAGE          NOT NULL,
    [BPMainID]              BIGINT         NOT NULL,
    [UploadedBy]            NVARCHAR (100) NOT NULL,
    [UploadedDate]          DATETIME       NOT NULL,
    [RowVersion]            BIGINT         CONSTRAINT [DF__BPDocumen__RowVe__2AEB3533] DEFAULT ((0)) NOT NULL,
    [DocumentID]            INT            NOT NULL,
    [UserDomainKey]         BIGINT         NOT NULL,
    [IsActive]              BIT            CONSTRAINT [DF_BPDocument_IsActive] DEFAULT ((0)) NOT NULL,
    [IsReadOnly]            BIT            CONSTRAINT [DF_BPDocument_IsReadOnly] DEFAULT ((0)) NOT NULL,
    [IsPrivate]             BIT            CONSTRAINT [DF_BPDocument_IsPrivate] DEFAULT ((0)) NOT NULL,
    [IsDeleted]             BIT            CONSTRAINT [DF_BPDocument_IsDeleted] DEFAULT ((0)) NOT NULL,
    [RecLastUpdatedDt]      DATETIME       NOT NULL,
    [RecLastUpdatedBy]      NVARCHAR (100) NOT NULL,
    [RecCreatedBy]          NVARCHAR (100) NOT NULL,
    [RecCreatedDt]          DATETIME       NOT NULL,
    CONSTRAINT [PK128] PRIMARY KEY NONCLUSTERED ([BPDocumentID] ASC),
    CONSTRAINT [RefBPMain293] FOREIGN KEY ([BPMainID]) REFERENCES [dbo].[BPMain] ([BPMainID]),
    CONSTRAINT [RefDocument445] FOREIGN KEY ([DocumentID]) REFERENCES [dbo].[Document] ([DocumentID])
);



