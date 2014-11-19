CREATE TABLE [dbo].[AllocationStatus] (
    [AllocationStatusID]          SMALLINT       IDENTITY (1, 1) NOT NULL,
    [AllocationStatusCode]        NVARCHAR (100) NOT NULL,
    [AllocationStatusName]        NVARCHAR (255) NULL,
    [AllocationStatusDescription] NVARCHAR (500) NULL,
    [AllocationStatusKey]         SMALLINT       NULL,
    [RowVersion]                  BIGINT         CONSTRAINT [DF__Allocatio__RowVe__61316BF4] DEFAULT ((0)) NOT NULL,
    [IsActive]                    BIT            CONSTRAINT [DF__Allocatio__IsAct__6225902D] DEFAULT ((1)) NOT NULL,
    [IsDeleted]                   BIT            CONSTRAINT [DF__Allocatio__IsDel__6319B466] DEFAULT ((0)) NOT NULL,
    [IsPrivate]                   BIT            CONSTRAINT [DF__Allocatio__IsPri__640DD89F] DEFAULT ((0)) NOT NULL,
    [IsReadOnly]                  BIT            CONSTRAINT [DF__Allocatio__IsRea__6501FCD8] DEFAULT ((0)) NOT NULL,
    [RecCreatedDt]                DATETIME       NOT NULL,
    [RecCreatedBy]                NVARCHAR (100) NOT NULL,
    [RecLastUpdatedDt]            DATETIME       NOT NULL,
    [RecLastUpdatedBy]            NVARCHAR (100) NOT NULL,
    CONSTRAINT [PK89_1_2] PRIMARY KEY NONCLUSTERED ([AllocationStatusID] ASC)
);



