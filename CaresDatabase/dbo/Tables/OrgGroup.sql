CREATE TABLE [dbo].[OrgGroup] (
    [OrgGroupID]          BIGINT         IDENTITY (1, 1) NOT NULL,
    [OrgGroupCode]        NVARCHAR (100) NULL,
    [OrgGroupName]        NVARCHAR (255) NOT NULL,
    [OrgGroupDescription] NVARCHAR (500) NULL,
    [RowVersion]          BIGINT         CONSTRAINT [DF_OrgGroup_RowVersion] DEFAULT ((0)) NOT NULL,
    [IsActive]            BIT            CONSTRAINT [DF__OrgGroup__IsActi__3A6CA48E] DEFAULT ((1)) NOT NULL,
    [IsDeleted]           BIT            CONSTRAINT [DF__OrgGroup__IsDele__3B60C8C7] DEFAULT ((0)) NOT NULL,
    [IsPrivate]           BIT            CONSTRAINT [DF__OrgGroup__IsPriv__3C54ED00] DEFAULT ((0)) NOT NULL,
    [IsReadOnly]          BIT            CONSTRAINT [DF__OrgGroup__IsRead__3D491139] DEFAULT ((0)) NOT NULL,
    [RecCreatedDt]        DATETIME       NOT NULL,
    [RecCreatedBy]        NVARCHAR (100) NOT NULL,
    [RecLastUpdatedDt]    DATETIME       NOT NULL,
    [RecLastUpdatedBy]    NVARCHAR (100) NOT NULL,
    [UserDomainKey]       BIGINT         NOT NULL,
    CONSTRAINT [PK20] PRIMARY KEY NONCLUSTERED ([OrgGroupID] ASC)
);

