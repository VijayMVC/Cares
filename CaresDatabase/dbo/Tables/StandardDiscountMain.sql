CREATE TABLE [dbo].[StandardDiscountMain] (
    [StandardDiscountMainID]          BIGINT         IDENTITY (1, 1) NOT NULL,
    [TariffTypeCode]                  NVARCHAR (255) NOT NULL,
    [StandardDiscountMainCode]        NVARCHAR (100) NOT NULL,
    [StandardDiscountMainName]        NVARCHAR (255) NULL,
    [StandardDiscountMainDescription] NVARCHAR (500) NULL,
    [RowVersion]                      BIGINT         CONSTRAINT [DF__StandardD__RowVe__65570293] DEFAULT ((0)) NOT NULL,
    [StartDt]                         DATETIME       NOT NULL,
    [EndDt]                           DATETIME       NOT NULL,
    [IsActive]                        BIT            CONSTRAINT [DF__StandardD__IsAct__664B26CC] DEFAULT ((1)) NOT NULL,
    [IsDeleted]                       BIT            CONSTRAINT [DF__StandardD__IsDel__673F4B05] DEFAULT ((0)) NOT NULL,
    [IsPrivate]                       BIT            CONSTRAINT [DF__StandardD__IsPri__68336F3E] DEFAULT ((0)) NOT NULL,
    [IsReadOnly]                      BIT            CONSTRAINT [DF__StandardD__IsRea__69279377] DEFAULT ((0)) NOT NULL,
    [RecCreatedBy]                    NVARCHAR (100) NOT NULL,
    [RecLastUpdatedBy]                NVARCHAR (100) NOT NULL,
    [RecCreatedDt]                    DATETIME       NOT NULL,
    [RecLastUpdatedDt]                DATETIME       NOT NULL,
    [UserDomainKey]                   BIGINT         NOT NULL,
    CONSTRAINT [PK164_1] PRIMARY KEY NONCLUSTERED ([StandardDiscountMainID] ASC)
);

