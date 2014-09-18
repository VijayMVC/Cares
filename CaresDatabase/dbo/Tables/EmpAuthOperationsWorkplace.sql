CREATE TABLE [dbo].[EmpAuthOperationsWorkplace] (
    [EmpAuthOperationsWorkplaceID] BIGINT         IDENTITY (1, 1) NOT NULL,
    [EmployeeID]                   BIGINT         NOT NULL,
    [OperationsWorkplaceID]        BIGINT         NOT NULL,
    [IsDefault]                    BIT            CONSTRAINT [DF__EmpAuthOp__IsDef__5F141958] DEFAULT ((0)) NOT NULL,
    [RowVersion]                   BIGINT         CONSTRAINT [DF__EmpAuthOp__RowVe__60083D91] DEFAULT ((0)) NOT NULL,
    [IsActive]                     BIT            CONSTRAINT [DF__EmpAuthOp__IsAct__60FC61CA] DEFAULT ((1)) NOT NULL,
    [IsPrivate]                    BIT            CONSTRAINT [DF__EmpAuthOp__IsPri__61F08603] DEFAULT ((0)) NOT NULL,
    [IsDeleted]                    BIT            CONSTRAINT [DF__EmpAuthOp__IsDel__62E4AA3C] DEFAULT ((0)) NOT NULL,
    [IsReadOnly]                   BIT            CONSTRAINT [DF__EmpAuthOp__IsRea__63D8CE75] DEFAULT ((0)) NOT NULL,
    [RecCreatedDt]                 DATETIME       NOT NULL,
    [RecCreatedBy]                 NVARCHAR (100) NOT NULL,
    [RecLastUpdatedDt]             DATETIME       NOT NULL,
    [RecLastUpdatedBy]             NVARCHAR (100) NOT NULL,
    [IsOperationDefault]           BIT            CONSTRAINT [DF__EmpAuthOp__IsOpe__64CCF2AE] DEFAULT ((0)) NOT NULL,
    [UserDomainKey]                BIGINT         NOT NULL,
    CONSTRAINT [PK43_1_3_1] PRIMARY KEY NONCLUSTERED ([EmpAuthOperationsWorkplaceID] ASC),
    CONSTRAINT [RefEmployee612] FOREIGN KEY ([EmployeeID]) REFERENCES [dbo].[Employee] ([EmployeeID]),
    CONSTRAINT [RefOperationsWorkplace611] FOREIGN KEY ([OperationsWorkplaceID]) REFERENCES [dbo].[OperationsWorkplace] ([OperationsWorkplaceID])
);

