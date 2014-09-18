CREATE TABLE [dbo].[Operation] (
    [OperationID]          BIGINT         IDENTITY (1, 1) NOT NULL,
    [OperationCode]        NVARCHAR (100) NULL,
    [OperationName]        NVARCHAR (255) NULL,
    [OperationDescription] NVARCHAR (500) NULL,
    [DepartmentID]         BIGINT         NOT NULL,
    [RowVersion]           BIGINT         CONSTRAINT [DF_Operation_RowVersion] DEFAULT ((0)) NOT NULL,
    [IsActive]             BIT            CONSTRAINT [DF__Operation__IsAct__2EFAF1E2] DEFAULT ((1)) NOT NULL,
    [IsDeleted]            BIT            CONSTRAINT [DF__Operation__IsDel__2FEF161B] DEFAULT ((0)) NOT NULL,
    [IsPrivate]            BIT            CONSTRAINT [DF__Operation__IsPri__30E33A54] DEFAULT ((0)) NOT NULL,
    [IsReadOnly]           BIT            CONSTRAINT [DF__Operation__IsRea__31D75E8D] DEFAULT ((0)) NOT NULL,
    [RecCreatedDt]         DATETIME       NOT NULL,
    [RecCreatedBy]         NVARCHAR (100) NOT NULL,
    [RecLastUpdatedDt]     DATETIME       NOT NULL,
    [RecLastUpdatedBy]     NVARCHAR (100) NOT NULL,
    [UserDomainKey]        BIGINT         NOT NULL,
    CONSTRAINT [PK91] PRIMARY KEY NONCLUSTERED ([OperationID] ASC),
    CONSTRAINT [RefDepartment1821] FOREIGN KEY ([DepartmentID]) REFERENCES [dbo].[Department] ([DepartmentID])
);

