CREATE TABLE [dbo].[HireGroupUpGrade] (
    [HireGroupUpGradeID] BIGINT         IDENTITY (1, 1) NOT NULL,
    [HireGroupID]        BIGINT         NOT NULL,
    [AllowedHireGroupID] BIGINT         NOT NULL,
    [RowVersion]         BIGINT         NOT NULL,
    [IsActive]           BIT            CONSTRAINT [DF__HireGroup__IsAct__0BE6BFCF] DEFAULT ((1)) NOT NULL,
    [IsDeleted]          BIT            CONSTRAINT [DF__HireGroup__IsDel__0CDAE408] DEFAULT ((0)) NOT NULL,
    [IsReadOnly]         BIT            CONSTRAINT [DF__HireGroup__IsRea__0DCF0841] DEFAULT ((0)) NOT NULL,
    [IsPrivate]          BIT            CONSTRAINT [DF__HireGroup__IsPri__0EC32C7A] DEFAULT ((0)) NOT NULL,
    [RecCreatedDt]       DATETIME       NOT NULL,
    [RecCreatedBy]       NVARCHAR (100) NOT NULL,
    [RecLastUpdatedBy]   NVARCHAR (100) NOT NULL,
    [RecLastUpdatedDt]   DATETIME       NOT NULL,
    [UserDomainKey]      BIGINT         NOT NULL,
    CONSTRAINT [PK12_2_1] PRIMARY KEY NONCLUSTERED ([HireGroupUpGradeID] ASC),
    CONSTRAINT [RefHireGroup613] FOREIGN KEY ([HireGroupID]) REFERENCES [dbo].[HireGroup] ([HireGroupID]) ON DELETE CASCADE,
    CONSTRAINT [RefHireGroup615] FOREIGN KEY ([AllowedHireGroupID]) REFERENCES [dbo].[HireGroup] ([HireGroupID])
);



