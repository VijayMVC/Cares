CREATE TABLE [dbo].[Document] (
    [DocumentID]          INT            IDENTITY (1, 1) NOT NULL,
    [DocumentCode]        NVARCHAR (100) NOT NULL,
    [DocumentName]        NVARCHAR (255) NULL,
    [DocumentDescription] NVARCHAR (500) NULL,
    [RowVersion]          BIGINT         CONSTRAINT [DF__Document__RowVer__558AAF1E] DEFAULT ((0)) NOT NULL,
    [IsActive]            BIT            CONSTRAINT [DF__Document__IsActi__567ED357] DEFAULT ((1)) NOT NULL,
    [IsDeleted]           BIT            CONSTRAINT [DF__Document__IsDele__5772F790] DEFAULT ((0)) NOT NULL,
    [IsPrivate]           BIT            CONSTRAINT [DF__Document__IsPriv__58671BC9] DEFAULT ((0)) NOT NULL,
    [IsReadOnly]          BIT            CONSTRAINT [DF__Document__IsRead__595B4002] DEFAULT ((0)) NOT NULL,
    [RecCreatedDt]        DATETIME       NOT NULL,
    [RecCreatedBy]        NVARCHAR (100) NOT NULL,
    [RecLastUpdatedDt]    DATETIME       NOT NULL,
    [RecLastUpdatedBy]    NVARCHAR (100) NOT NULL,
    [DocumentGroupID]     INT            NOT NULL,
    [UserDomainKey]       BIGINT         NOT NULL,
    CONSTRAINT [PK129_1] PRIMARY KEY NONCLUSTERED ([DocumentID] ASC),
    CONSTRAINT [RefDocumentGroup444] FOREIGN KEY ([DocumentGroupID]) REFERENCES [dbo].[DocumentGroup] ([DocumentGroupID])
);

