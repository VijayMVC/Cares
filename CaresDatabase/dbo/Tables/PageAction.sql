CREATE TABLE [dbo].[PageAction] (
    [PageActionID]   BIGINT         IDENTITY (1, 1) NOT NULL,
    [PageActionCode] NVARCHAR (100) NOT NULL,
    [PageActionName] NVARCHAR (255) NULL,
    [Description]    NVARCHAR (500) NULL,
    [IsActive]       BIT            CONSTRAINT [DF__PageActio__IsAct__6B44E613] DEFAULT ((1)) NOT NULL,
    [IsDeleted]      BIT            CONSTRAINT [DF__PageActio__IsDel__6C390A4C] DEFAULT ((0)) NOT NULL,
    [IsReadOnly]     BIT            CONSTRAINT [DF__PageActio__IsRea__6D2D2E85] DEFAULT ((1)) NOT NULL,
    [IsPrivate]      BIT            CONSTRAINT [DF__PageActio__IsPri__6E2152BE] DEFAULT ((0)) NOT NULL,
    [MenuFunctionID] BIGINT         NOT NULL,
    [UserDomainKey]  BIGINT         NOT NULL,
    CONSTRAINT [PK120] PRIMARY KEY NONCLUSTERED ([PageActionID] ASC),
    CONSTRAINT [RefMenuFunction306] FOREIGN KEY ([MenuFunctionID]) REFERENCES [dbo].[MenuFunction] ([MenuFunctionID])
);

