CREATE TABLE [dbo].[CategoryLog] (
    [CategoryLogID] INT IDENTITY (1, 1) NOT NULL,
    [LogCategoryID] INT NOT NULL,
    [LogID]         INT NOT NULL,
    CONSTRAINT [PK_CategoryLog] PRIMARY KEY CLUSTERED ([CategoryLogID] ASC),
    CONSTRAINT [FK_CategoryLog_Log] FOREIGN KEY ([LogID]) REFERENCES [dbo].[Log] ([LogID]),
    CONSTRAINT [FK_CategoryLog_LogCategory] FOREIGN KEY ([LogCategoryID]) REFERENCES [dbo].[LogCategory] ([LogCategoryID])
);

