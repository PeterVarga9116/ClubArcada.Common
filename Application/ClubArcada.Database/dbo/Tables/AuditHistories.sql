CREATE TABLE [dbo].[AuditHistories] (
    [Id]              UNIQUEIDENTIFIER NOT NULL,
    [ObjectId]        UNIQUEIDENTIFIER NOT NULL,
    [Description]     NVARCHAR (150)   NOT NULL,
    [Type]            INT              NOT NULL,
    [DateCreated]     DATETIME         NOT NULL,
    [DateDeleted]     DATETIME         NULL,
    [CreatedByUserId] UNIQUEIDENTIFIER NOT NULL,
    CONSTRAINT [PK_AuditHistories] PRIMARY KEY CLUSTERED ([Id] ASC)
);

