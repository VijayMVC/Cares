CREATE TABLE [dbo].[PricingStrategy] (
    [PricingStrategyID]          INT            NOT NULL,
    [PricingStrategyCode]        NVARCHAR (100) NOT NULL,
    [PricingStrategyName]        NVARCHAR (255) NULL,
    [PricingStrategyDescription] NVARCHAR (500) NULL,
    [IsActive]                   BIT            CONSTRAINT [DF__PricingSt__IsAct__01342732] DEFAULT ((1)) NOT NULL,
    [IsDeleted]                  BIT            CONSTRAINT [DF__PricingSt__IsDel__02284B6B] DEFAULT ((0)) NOT NULL,
    [IsPrivate]                  BIT            CONSTRAINT [DF__PricingSt__IsPri__031C6FA4] DEFAULT ((0)) NOT NULL,
    [IsReadOnly]                 BIT            CONSTRAINT [DF__PricingSt__IsRea__041093DD] DEFAULT ((0)) NOT NULL,
    [UserDomainKey]              BIGINT         NOT NULL,
    CONSTRAINT [PK165] PRIMARY KEY NONCLUSTERED ([PricingStrategyID] ASC)
);

