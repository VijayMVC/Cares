CREATE TABLE [dbo].[UserPageAction] (
    [UserActionID]     BIGINT         IDENTITY (1, 1) NOT NULL,
    [RoleID]           BIGINT         NULL,
    [PageActionID]     BIGINT         NOT NULL,
    [IsActive]         BIT            CONSTRAINT [DF__UserPageA__IsAct__795DFB40] DEFAULT ((1)) NOT NULL,
    [IsDeleted]        BIT            CONSTRAINT [DF__UserPageA__IsDel__7A521F79] DEFAULT ((0)) NOT NULL,
    [IsReadOnly]       BIT            CONSTRAINT [DF__UserPageA__IsRea__7B4643B2] DEFAULT ((0)) NOT NULL,
    [IsPrivate]        BIT            CONSTRAINT [DF__UserPageA__IsPri__7C3A67EB] DEFAULT ((0)) NOT NULL,
    [RecCreatedDt]     DATETIME       NOT NULL,
    [RecCreatedBy]     NVARCHAR (100) NOT NULL,
    [RecLastUpdatedDt] DATETIME       NOT NULL,
    [RecLastUpdatedBy] NVARCHAR (100) NOT NULL,
    [UserDomainKey]    BIGINT         NOT NULL,
    CONSTRAINT [PK121] PRIMARY KEY NONCLUSTERED ([UserActionID] ASC),
    CONSTRAINT [RefPageAction307] FOREIGN KEY ([PageActionID]) REFERENCES [dbo].[PageAction] ([PageActionID]),
    CONSTRAINT [RefRole379] FOREIGN KEY ([RoleID]) REFERENCES [dbo].[Role] ([RoleID])
);

