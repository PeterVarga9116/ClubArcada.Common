CREATE TABLE [dbo].[Structures] (
    [Id]              UNIQUEIDENTIFIER NOT NULL,
    [CreatedByUserId] UNIQUEIDENTIFIER NOT NULL,
    [Name]            NVARCHAR (50)    NOT NULL,
    [DateCreated]     DATETIME         NOT NULL,
    [DateDeleted]     DATETIME         NULL,
    CONSTRAINT [PK_Structures] PRIMARY KEY CLUSTERED ([Id] ASC)
);

