CREATE TABLE [dbo].[PaymentTerm] (
    [PaymentTermID]          SMALLINT       IDENTITY (1, 1) NOT NULL,
    [PaymentTermCode]        NVARCHAR (100) NOT NULL,
    [PaymentTermName]        NVARCHAR (255) NULL,
    [PaymentTermDescription] NVARCHAR (500) NULL,
    [PaymentTermKey]         SMALLINT       NULL,
    [RowVersion]             BIGINT         CONSTRAINT [DF__PaymentTe__RowVe__73DA2C14] DEFAULT ((0)) NOT NULL,
    [IsActive]               BIT            CONSTRAINT [DF__PaymentTe__IsAct__74CE504D] DEFAULT ((1)) NOT NULL,
    [IsDeleted]              BIT            CONSTRAINT [DF__PaymentTe__IsDel__75C27486] DEFAULT ((0)) NOT NULL,
    [IsPrivate]              BIT            CONSTRAINT [DF__PaymentTe__IsPri__76B698BF] DEFAULT ((0)) NOT NULL,
    [IsReadOnly]             BIT            CONSTRAINT [DF__PaymentTe__IsRea__77AABCF8] DEFAULT ((0)) NOT NULL,
    [RecCreatedDt]           DATETIME       NOT NULL,
    [RecCreatedBy]           NVARCHAR (100) NOT NULL,
    [RecLastUpdatedDt]       DATETIME       NOT NULL,
    [RecLastUpdatedBy]       NVARCHAR (100) NOT NULL,
    [UserDomainKey]          BIGINT         NOT NULL,
    CONSTRAINT [PK89_1_2_1_1_4] PRIMARY KEY NONCLUSTERED ([PaymentTermID] ASC)
);

