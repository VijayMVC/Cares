CREATE TABLE [dbo].[RAStatusLog] (
    [RAStatusLogID]       BIGINT         NOT NULL,
    [RAMainID]            BIGINT         NOT NULL,
    [RANewStatusID]       SMALLINT       NOT NULL,
    [RAOldStatusID]       SMALLINT       NOT NULL,
    [RAStatusDescription] NVARCHAR (500) NULL,
    [RowVersion]          BIGINT         CONSTRAINT [DF__RAStatusL__RowVe__3D491139] DEFAULT ((0)) NOT NULL,
    [IsActive]            BIT            CONSTRAINT [DF__RAStatusL__IsAct__3E3D3572] DEFAULT ((1)) NOT NULL,
    [IsDeleted]           BIT            CONSTRAINT [DF__RAStatusL__IsDel__3F3159AB] DEFAULT ((0)) NOT NULL,
    [IsPrivate]           BIT            CONSTRAINT [DF__RAStatusL__IsPri__40257DE4] DEFAULT ((0)) NOT NULL,
    [IsReadOnly]          BIT            CONSTRAINT [DF__RAStatusL__IsRea__4119A21D] DEFAULT ((0)) NOT NULL,
    [RecCreatedDt]        DATETIME       NOT NULL,
    [RecCreatedBy]        NVARCHAR (100) NOT NULL,
    [RecLastUpdatedDt]    DATETIME       NOT NULL,
    [RecLastUpdatedBy]    NVARCHAR (100) NOT NULL,
    [UserDomainKey]       BIGINT         NOT NULL,
    CONSTRAINT [PK89_1_4_1] PRIMARY KEY NONCLUSTERED ([RAStatusLogID] ASC),
    CONSTRAINT [RefRAMain624] FOREIGN KEY ([RAMainID]) REFERENCES [dbo].[RAMain] ([RAMainID]),
    CONSTRAINT [RefRAStatus621] FOREIGN KEY ([RAOldStatusID]) REFERENCES [dbo].[RAStatus] ([RAStatusID]),
    CONSTRAINT [RefRAStatus622] FOREIGN KEY ([RANewStatusID]) REFERENCES [dbo].[RAStatus] ([RAStatusID])
);

