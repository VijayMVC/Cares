CREATE TABLE [dbo].[EmpJobProg] (
    [EmpJobProgID]     BIGINT         IDENTITY (1, 1) NOT NULL,
    [EmployeeID]       BIGINT         NOT NULL,
    [DesignationID]    BIGINT         NOT NULL,
    [WorkplaceID]      BIGINT         NOT NULL,
    [DesigStDt]        DATETIME       NULL,
    [DesigEndDt]       DATETIME       NULL,
    [RowVersion]       BIGINT         CONSTRAINT [DF__EmpJobPro__RowVe__6F4A8121] DEFAULT ((0)) NOT NULL,
    [IsActive]         BIT            CONSTRAINT [DF__EmpJobPro__IsAct__703EA55A] DEFAULT ((1)) NOT NULL,
    [IsPrivate]        BIT            CONSTRAINT [DF__EmpJobPro__IsPri__7132C993] DEFAULT ((0)) NOT NULL,
    [IsDeleted]        BIT            CONSTRAINT [DF__EmpJobPro__IsDel__7226EDCC] DEFAULT ((0)) NOT NULL,
    [IsReadOnly]       BIT            CONSTRAINT [DF__EmpJobPro__IsRea__731B1205] DEFAULT ((0)) NOT NULL,
    [RecCreatedDt]     DATETIME       NOT NULL,
    [RecCreatedBy]     NVARCHAR (100) NOT NULL,
    [RecLastUpdatedDt] DATETIME       NOT NULL,
    [RecLastUpdatedBy] NVARCHAR (100) NOT NULL,
    [UserDomainKey]    BIGINT         NOT NULL,
    CONSTRAINT [PK43_1_3] PRIMARY KEY CLUSTERED ([EmpJobProgID] ASC),
    CONSTRAINT [RefDesignation350] FOREIGN KEY ([DesignationID]) REFERENCES [dbo].[Designation] ([DesignationID]),
    CONSTRAINT [RefEmployee349] FOREIGN KEY ([EmployeeID]) REFERENCES [dbo].[Employee] ([EmployeeID]) ON DELETE CASCADE,
    CONSTRAINT [RefWorkplace351] FOREIGN KEY ([WorkplaceID]) REFERENCES [dbo].[Workplace] ([WorkplaceID])
);



