CREATE TABLE [dbo].[Department] (
    [DepartmentID]          BIGINT         IDENTITY (1, 1) NOT NULL,
    [DepartmentCode]        NVARCHAR (100) NOT NULL,
    [DepartmentName]        NVARCHAR (255) NULL,
    [DepartmentDescription] NVARCHAR (500) NULL,
    [DepartmentType]        NVARCHAR (255) NOT NULL,
    [CompanyID]             BIGINT         NOT NULL,
    [RowVersion]            BIGINT         CONSTRAINT [DF_Department_RowVersion] DEFAULT ((0)) NOT NULL,
    [IsActive]              BIT            CONSTRAINT [DF__Departmen__IsAct__23893F36] DEFAULT ((1)) NOT NULL,
    [IsDeleted]             BIT            CONSTRAINT [DF__Departmen__IsDel__247D636F] DEFAULT ((0)) NOT NULL,
    [IsPrivate]             BIT            CONSTRAINT [DF__Departmen__IsPri__257187A8] DEFAULT ((0)) NOT NULL,
    [IsReadOnly]            BIT            CONSTRAINT [DF__Departmen__IsRea__2665ABE1] DEFAULT ((0)) NOT NULL,
    [RecCreatedDt]          DATETIME       NOT NULL,
    [RecCreatedBy]          NVARCHAR (100) NOT NULL,
    [RecLastUpdatedDt]      DATETIME       NOT NULL,
    [RecLastUpdatedBy]      NVARCHAR (100) NOT NULL,
    [UserDomainKey]         BIGINT         NOT NULL,
    CONSTRAINT [PK21] PRIMARY KEY NONCLUSTERED ([DepartmentID] ASC),
    CONSTRAINT [RefCompany1931] FOREIGN KEY ([CompanyID]) REFERENCES [dbo].[Company] ([CompanyID])
);

