CREATE TABLE [dbo].[EmpStatus] (
    [EmpStatusID]          BIGINT         IDENTITY (1, 1) NOT NULL,
    [EmpStatusCode]        NVARCHAR (100) NOT NULL,
    [EmpStatusName]        NVARCHAR (255) NULL,
    [EmpStatusDescription] NVARCHAR (500) NULL,
    [EmpStatusFlg]         BIT            NOT NULL,
    [RowVersion]           BIGINT         CONSTRAINT [DF__EmpStatus__RowVe__78D3EB5B] DEFAULT ((0)) NOT NULL,
    [IsActive]             BIT            CONSTRAINT [DF__EmpStatus__IsAct__79C80F94] DEFAULT ((1)) NOT NULL,
    [IsPrivate]            BIT            CONSTRAINT [DF__EmpStatus__IsPri__7ABC33CD] DEFAULT ((0)) NOT NULL,
    [IsDeleted]            BIT            CONSTRAINT [DF__EmpStatus__IsDel__7BB05806] DEFAULT ((0)) NOT NULL,
    [IsReadOnly]           BIT            CONSTRAINT [DF__EmpStatus__IsRea__7CA47C3F] DEFAULT ((0)) NOT NULL,
    [RecCreatedDt]         DATETIME       NOT NULL,
    [RecCreatedBy]         NVARCHAR (100) NOT NULL,
    [RecLastUpdatedDt]     DATETIME       NOT NULL,
    [RecLastUpdatedBy]     NVARCHAR (100) NOT NULL,
    [UserDomainKey]        BIGINT         NOT NULL,
    CONSTRAINT [PK43_1_4] PRIMARY KEY CLUSTERED ([EmpStatusID] ASC)
);

