CREATE TABLE [dbo].[UserFunction] (
    [UserFunctionID]   BIGINT         IDENTITY (1, 1) NOT NULL,
    [RoleID]           BIGINT         NULL,
    [MenuFunctionID]   BIGINT         NOT NULL,
    [RowVersion]       BIGINT         CONSTRAINT [DF_UserFunction_RowVersion] DEFAULT ((0)) NOT NULL,
    [IsActive]         BIT            CONSTRAINT [DF__UserFunct__IsAct__14B10FFA] DEFAULT ((1)) NOT NULL,
    [IsDeleted]        BIT            CONSTRAINT [DF__UserFunct__IsDel__15A53433] DEFAULT ((0)) NOT NULL,
    [IsReadOnly]       BIT            CONSTRAINT [DF__UserFunct__IsRea__1699586C] DEFAULT ((0)) NOT NULL,
    [IsPrivate]        BIT            CONSTRAINT [DF__UserFunct__IsPri__178D7CA5] DEFAULT ((0)) NOT NULL,
    [RecCreatedDt]     DATETIME       NOT NULL,
    [RecCreatedBy]     NVARCHAR (100) NOT NULL,
    [RecLastUpdatedDt] DATETIME       NOT NULL,
    [RecLastUpdatedBy] NVARCHAR (100) NOT NULL,
    [UserDomainKey]    BIGINT         NOT NULL,
    CONSTRAINT [PK117] PRIMARY KEY NONCLUSTERED ([UserFunctionID] ASC),
    CONSTRAINT [RefMenuFunction270] FOREIGN KEY ([MenuFunctionID]) REFERENCES [dbo].[MenuFunction] ([MenuFunctionID]),
    CONSTRAINT [RefRole378] FOREIGN KEY ([RoleID]) REFERENCES [dbo].[Role] ([RoleID])
);

