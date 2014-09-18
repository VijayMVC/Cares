CREATE TABLE [dbo].[ChaufferChargeMain] (
    [ChaufferChargeMainID]          BIGINT         IDENTITY (1, 1) NOT NULL,
    [ChaufferChargeMainCode]        NVARCHAR (100) NOT NULL,
    [TariffTypeCode]                NVARCHAR (100) NOT NULL,
    [ChaufferChargeMainName]        NVARCHAR (255) NULL,
    [ChaufferChargeMainDescription] NVARCHAR (500) NULL,
    [StartDt]                       DATETIME       NOT NULL,
    [RowVersion]                    BIGINT         NOT NULL,
    [IsActive]                      BIT            CONSTRAINT [DF__ChaufferC__IsAct__23F3538A] DEFAULT ((1)) NOT NULL,
    [IsDeleted]                     BIT            CONSTRAINT [DF__ChaufferC__IsDel__24E777C3] DEFAULT ((0)) NOT NULL,
    [IsPrivate]                     BIT            CONSTRAINT [DF__ChaufferC__IsPri__25DB9BFC] DEFAULT ((0)) NOT NULL,
    [IsReadOnly]                    BIT            CONSTRAINT [DF__ChaufferC__IsRea__26CFC035] DEFAULT ((0)) NOT NULL,
    [RecCreatedDt]                  DATETIME       NOT NULL,
    [RecLastUpdatedDt]              DATETIME       NOT NULL,
    [RecCreatedBy]                  NVARCHAR (100) NOT NULL,
    [RecLastUpdatedBy]              NVARCHAR (100) NOT NULL,
    [UserDomainKey]                 BIGINT         NOT NULL,
    CONSTRAINT [PK79_2] PRIMARY KEY NONCLUSTERED ([ChaufferChargeMainID] ASC)
);

