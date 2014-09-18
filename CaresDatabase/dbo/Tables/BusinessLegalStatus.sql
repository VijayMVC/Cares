CREATE TABLE [dbo].[BusinessLegalStatus] (
    [BusinessLegalStatusID]          SMALLINT       IDENTITY (1, 1) NOT NULL,
    [BusinessLegalStatusCode]        NVARCHAR (100) NOT NULL,
    [BusinessLegalStatusName]        NVARCHAR (255) NULL,
    [BusinessLegalStatusDescription] NVARCHAR (500) NULL,
    [RowVersion]                     BIGINT         CONSTRAINT [DF__BusinessL__RowVe__15A53433] DEFAULT ((0)) NOT NULL,
    [IsActive]                       BIT            CONSTRAINT [DF__BusinessL__IsAct__1699586C] DEFAULT ((1)) NOT NULL,
    [IsDeleted]                      BIT            CONSTRAINT [DF__BusinessL__IsDel__178D7CA5] DEFAULT ((0)) NOT NULL,
    [IsPrivate]                      BIT            CONSTRAINT [DF__BusinessL__IsPri__1881A0DE] DEFAULT ((0)) NOT NULL,
    [IsReadOnly]                     BIT            CONSTRAINT [DF__BusinessL__IsRea__1975C517] DEFAULT ((0)) NOT NULL,
    [RecCreatedDt]                   DATETIME       NOT NULL,
    [RecCreatedBy]                   NVARCHAR (100) NOT NULL,
    [RecLastUpdatedDt]               DATETIME       NOT NULL,
    [RecLastUpdatedBy]               NVARCHAR (100) NOT NULL,
    [UserDomainKey]                  BIGINT         NOT NULL,
    CONSTRAINT [PK126] PRIMARY KEY CLUSTERED ([BusinessLegalStatusID] ASC)
);

