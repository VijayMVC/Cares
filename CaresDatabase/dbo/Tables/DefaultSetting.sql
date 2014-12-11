CREATE TABLE [dbo].[DefaultSetting] (
    [DefaultSettingId]            BIGINT IDENTITY (1, 1) NOT NULL,
    [EmployeeId]                  BIGINT NOT NULL,
    [DefaultOperationId]          BIGINT NULL,
    [DefaultOperationWorkplaceId] BIGINT NULL,
    [DefaultPaymentTermId]        BIGINT NULL,
    CONSTRAINT [PK_DefaultSetting] PRIMARY KEY CLUSTERED ([DefaultSettingId] ASC)
);

