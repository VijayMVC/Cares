CREATE TABLE [dbo].[SeasonalDiscountMain] (
    [SeasonalDiscountMainID]          BIGINT         IDENTITY (1, 1) NOT NULL,
    [TariffTypeCode]                  NVARCHAR (255) NOT NULL,
    [SeasonalDiscountMainCode]        NVARCHAR (100) NOT NULL,
    [SeasonalDiscountMainName]        NVARCHAR (255) NULL,
    [SeasonalDiscountMainDescription] NVARCHAR (500) NULL,
    [RowVersion]                      BIGINT         CONSTRAINT [DF__SeasonalD__RowVe__505BE5AD] DEFAULT ((0)) NOT NULL,
    [StartDt]                         DATETIME       NOT NULL,
    [EndDt]                           DATETIME       NOT NULL,
    [IsActive]                        BIT            CONSTRAINT [DF__SeasonalD__IsAct__515009E6] DEFAULT ((1)) NOT NULL,
    [IsDeleted]                       BIT            CONSTRAINT [DF__SeasonalD__IsDel__52442E1F] DEFAULT ((0)) NOT NULL,
    [IsPrivate]                       BIT            CONSTRAINT [DF__SeasonalD__IsPri__53385258] DEFAULT ((0)) NOT NULL,
    [IsReadOnly]                      BIT            CONSTRAINT [DF__SeasonalD__IsRea__542C7691] DEFAULT ((0)) NOT NULL,
    [RecCreatedBy]                    NVARCHAR (100) NOT NULL,
    [RecLastUpdatedBy]                NVARCHAR (100) NOT NULL,
    [RecCreatedDt]                    DATETIME       NOT NULL,
    [RecLastUpdatedDt]                DATETIME       NOT NULL,
    [UserDomainKey]                   BIGINT         NOT NULL,
    CONSTRAINT [PK164_2] PRIMARY KEY NONCLUSTERED ([SeasonalDiscountMainID] ASC)
);

