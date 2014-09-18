CREATE TABLE [dbo].[RACustomerDocument] (
    [RACustomerDocumentID]          BIGINT         IDENTITY (1, 1) NOT NULL,
    [RACustomerDocumentDescription] NVARCHAR (500) NULL,
    [RowVersion]                    BIGINT         CONSTRAINT [DF__RACustome__RowVe__05F8DC4F] DEFAULT ((0)) NOT NULL,
    [IsActive]                      BIT            CONSTRAINT [DF__RACustome__IsAct__06ED0088] DEFAULT ((1)) NOT NULL,
    [IsDeleted]                     BIT            CONSTRAINT [DF__RACustome__IsDel__07E124C1] DEFAULT ((0)) NOT NULL,
    [IsPrivate]                     BIT            CONSTRAINT [DF__RACustome__IsPri__08D548FA] DEFAULT ((0)) NOT NULL,
    [IsReadOnly]                    BIT            CONSTRAINT [DF__RACustome__IsRea__09C96D33] DEFAULT ((0)) NOT NULL,
    [RecCreatedDt]                  DATETIME       NOT NULL,
    [RecCreatedBy]                  NVARCHAR (100) NOT NULL,
    [RecLastUpdatedDt]              DATETIME       NOT NULL,
    [RecLastUpdatedBy]              NVARCHAR (100) NOT NULL,
    [DocumentID]                    INT            NOT NULL,
    [RAMainID]                      BIGINT         NOT NULL,
    [UserDomainKey]                 BIGINT         NOT NULL,
    CONSTRAINT [PK126_1_1] PRIMARY KEY NONCLUSTERED ([RACustomerDocumentID] ASC),
    CONSTRAINT [RefDocument507] FOREIGN KEY ([DocumentID]) REFERENCES [dbo].[Document] ([DocumentID]),
    CONSTRAINT [RefRAMain513] FOREIGN KEY ([RAMainID]) REFERENCES [dbo].[RAMain] ([RAMainID])
);

