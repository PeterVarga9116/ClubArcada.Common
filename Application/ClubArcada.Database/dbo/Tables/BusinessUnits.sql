CREATE TABLE [dbo].[BusinessUnits] (
    [Id]              UNIQUEIDENTIFIER NOT NULL,
    [Name]            NVARCHAR (50)    NOT NULL,
    [DateCreated]     DATETIME         NOT NULL,
    [DateDeleted]     DATETIME         NULL,
    [Address]         NVARCHAR (500)   NULL,
    [Phone]           NVARCHAR (50)    NULL,
    [Email]           NVARCHAR (50)    NULL,
    [HasCalendar]     BIT              CONSTRAINT [DF_BusinessUnits_HasCalendar] DEFAULT ((0)) NOT NULL,
    [ImageId]         UNIQUEIDENTIFIER NULL,
    [CreatedByUserId] UNIQUEIDENTIFIER NOT NULL,
    CONSTRAINT [PK_BusinessUnits] PRIMARY KEY CLUSTERED ([Id] ASC)
);

