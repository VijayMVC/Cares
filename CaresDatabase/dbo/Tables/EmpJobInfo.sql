CREATE TABLE [dbo].[EmpJobInfo] (
    [EmployeeID]       BIGINT         NOT NULL,
    [SupervisorID]     BIGINT         NULL,
    [DesignationID]    BIGINT         NOT NULL,
    [DesigGradeID]     BIGINT         NOT NULL,
    [JobTypeID]        BIGINT         NOT NULL,
    [DepartmentID]     BIGINT         NOT NULL,
    [WorkplaceID]      BIGINT         NULL,
    [JoiningDt]        DATETIME       NOT NULL,
    [Salary]           DECIMAL (9, 2) NULL,
    [RowVersion]       BIGINT         CONSTRAINT [DF__EmpJobInf__RowVe__6A85CC04] DEFAULT ((0)) NOT NULL,
    [IsActive]         BIT            CONSTRAINT [DF__EmpJobInf__IsAct__6B79F03D] DEFAULT ((1)) NOT NULL,
    [IsPrivate]        BIT            CONSTRAINT [DF__EmpJobInf__IsPri__6C6E1476] DEFAULT ((0)) NOT NULL,
    [IsDeleted]        BIT            CONSTRAINT [DF__EmpJobInf__IsDel__6D6238AF] DEFAULT ((0)) NOT NULL,
    [IsReadOnly]       BIT            CONSTRAINT [DF__EmpJobInf__IsRea__6E565CE8] DEFAULT ((0)) NOT NULL,
    [RecCreatedDt]     DATETIME       NOT NULL,
    [RecCreatedBy]     NVARCHAR (100) NOT NULL,
    [RecLastUpdatedDt] DATETIME       NOT NULL,
    [RecLastUpdatedBy] NVARCHAR (100) NOT NULL,
    [UserDomainKey]    BIGINT         NOT NULL,
    CONSTRAINT [PK43_1_1] PRIMARY KEY CLUSTERED ([EmployeeID] ASC),
    CONSTRAINT [RefDepartment340] FOREIGN KEY ([DepartmentID]) REFERENCES [dbo].[Department] ([DepartmentID]),
    CONSTRAINT [RefDesigGrade354] FOREIGN KEY ([DesigGradeID]) REFERENCES [dbo].[DesigGrade] ([DesigGradeID]),
    CONSTRAINT [RefDesignation346] FOREIGN KEY ([DesignationID]) REFERENCES [dbo].[Designation] ([DesignationID]),
    CONSTRAINT [RefEmployee345] FOREIGN KEY ([EmployeeID]) REFERENCES [dbo].[Employee] ([EmployeeID]) ON DELETE CASCADE,
    CONSTRAINT [RefEmployee352] FOREIGN KEY ([SupervisorID]) REFERENCES [dbo].[Employee] ([EmployeeID]),
    CONSTRAINT [RefJobType339] FOREIGN KEY ([JobTypeID]) REFERENCES [dbo].[JobType] ([JobTypeID]),
    CONSTRAINT [RefWorkplace342] FOREIGN KEY ([WorkplaceID]) REFERENCES [dbo].[Workplace] ([WorkplaceID])
);



