CREATE TABLE [dbo].[Images] (
    [Id]              UNIQUEIDENTIFIER NOT NULL,
    [Data]            VARBINARY (MAX)  NOT NULL,
    [Extension]       NVARCHAR (50)    NULL,
    [DateDeleted]     DATETIME         NULL,
    [DateCreated]     DATETIME         NOT NULL,
    [CreatedByUserId] UNIQUEIDENTIFIER NOT NULL,
    CONSTRAINT [PK_Images] PRIMARY KEY CLUSTERED ([Id] ASC)
);

