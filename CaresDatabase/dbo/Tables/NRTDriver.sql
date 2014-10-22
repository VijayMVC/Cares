CREATE TABLE [dbo].[NRTDriver] (
    [NRTDriverID]      BIGINT         IDENTITY (1, 1) NOT NULL,
    [ChaufferID]       BIGINT         NULL,
    [DesigGradeID]     BIGINT         NULL,
    [LicenseExpDt]     DATETIME       NULL,
    [LicenseNo]        NVARCHAR (100) NULL,
    [StartDtTime]      DATETIME       NOT NULL,
    [EndDtTime]        DATETIME       NOT NULL,
    [RowVersion]       BIGINT         CONSTRAINT [DF__NRTDriver__RowVe__405A880E] DEFAULT ((0)) NOT NULL,
    [IsActive]         BIT            CONSTRAINT [DF__NRTDriver__IsAct__414EAC47] DEFAULT ((1)) NOT NULL,
    [IsDeleted]        BIT            CONSTRAINT [DF__NRTDriver__IsDel__4242D080] DEFAULT ((0)) NOT NULL,
    [IsPrivate]        BIT            CONSTRAINT [DF__NRTDriver__IsPri__4336F4B9] DEFAULT ((0)) NOT NULL,
    [IsReadOnly]       BIT            CONSTRAINT [DF__NRTDriver__IsRea__442B18F2] DEFAULT ((0)) NOT NULL,
    [RecCreatedDt]     DATETIME       NOT NULL,
    [RecCreatedBy]     NVARCHAR (100) NOT NULL,
    [RecLastUpdatedDt] DATETIME       NOT NULL,
    [RecLastUpdatedBy] NVARCHAR (100) NOT NULL,
    [NRTVehicleID]     BIGINT         NOT NULL,
    [UserDomainKey]    BIGINT         NOT NULL,
    CONSTRAINT [PK126_2_1_1_1] PRIMARY KEY NONCLUSTERED ([NRTDriverID] ASC),
    CONSTRAINT [RefDesigGrade604] FOREIGN KEY ([DesigGradeID]) REFERENCES [dbo].[DesigGrade] ([DesigGradeID]),
    CONSTRAINT [RefEmployee603] FOREIGN KEY ([ChaufferID]) REFERENCES [dbo].[Employee] ([EmployeeID]),
    CONSTRAINT [RefNRTVehicle596] FOREIGN KEY ([NRTVehicleID]) REFERENCES [dbo].[NRTVehicle] ([NRTVehicleID])
);



