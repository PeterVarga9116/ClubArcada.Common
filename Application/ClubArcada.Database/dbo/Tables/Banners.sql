CREATE TABLE [dbo].[Banners] (
    [Id]              UNIQUEIDENTIFIER NOT NULL,
    [CreatedByUserId] UNIQUEIDENTIFIER NOT NULL,
    [Description]     NVARCHAR (50)    NOT NULL,
    [Link]            NVARCHAR (50)    NOT NULL,
    [DateCreated]     DATETIME         NOT NULL,
    [DateDeleted]     DATETIME         NULL,
    [DateDeactivated] DATETIME         NULL,
    [SortNumber]      INT              NOT NULL,
    [TargetType]      NVARCHAR (50)    NOT NULL,
    [Data]            VARBINARY (MAX)  NULL,
    CONSTRAINT [PK_Banners] PRIMARY KEY CLUSTERED ([Id] ASC)
);

