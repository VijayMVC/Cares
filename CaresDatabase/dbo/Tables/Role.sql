CREATE TABLE [dbo].[Role] (
    [RoleID]           BIGINT         IDENTITY (1, 1) NOT NULL,
    [RoleCode]         NVARCHAR (100) NOT NULL,
    [RoleName]         NVARCHAR (255) NULL,
    [RoleDescription]  NVARCHAR (500) NULL,
    [RowVersion]       BIGINT         CONSTRAINT [DF_Role_RowVersion] DEFAULT ((0)) NOT NULL,
    [IsActive]         BIT            CONSTRAINT [DF__Role__IsActive__6C2EE8AB] DEFAULT ((1)) NOT NULL,
    [IsDeleted]        BIT            CONSTRAINT [DF__Role__IsDeleted__6D230CE4] DEFAULT ((0)) NOT NULL,
    [IsReadOnly]       BIT            CONSTRAINT [DF__Role__IsReadOnly__6E17311D] DEFAULT ((0)) NOT NULL,
    [IsPrivate]        BIT            CONSTRAINT [DF__Role__IsPrivate__6F0B5556] DEFAULT ((0)) NOT NULL,
    [RecCreatedDt]     DATETIME       NOT NULL,
    [RecCreatedBy]     NVARCHAR (100) NOT NULL,
    [RecLastUpdatedDt] DATETIME       NOT NULL,
    [RecLastUpdatedBy] NVARCHAR (100) NOT NULL,
    [UserDomainKey]    BIGINT         NOT NULL,
    CONSTRAINT [PK117_2] PRIMARY KEY CLUSTERED ([RoleID] ASC)
);

