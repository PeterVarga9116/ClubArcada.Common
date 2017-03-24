CREATE TABLE [dbo].[Tickets] (
    [Id]              UNIQUEIDENTIFIER NOT NULL,
    [UserId]          UNIQUEIDENTIFIER NOT NULL,
    [CreatedByUserId] UNIQUEIDENTIFIER NOT NULL,
    [TournamentId]    UNIQUEIDENTIFIER NOT NULL,
    [DateCreated]     DATETIME         NOT NULL,
    [DateDeleted]     DATETIME         NULL,
    [Identification]  INT              CONSTRAINT [DF_Tickets_Identification] DEFAULT ((0)) NOT NULL,
    CONSTRAINT [PK_Tickets] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Tickets_Tournaments] FOREIGN KEY ([TournamentId]) REFERENCES [dbo].[Tournaments] ([Id]),
    CONSTRAINT [FK_Tickets_Users] FOREIGN KEY ([UserId]) REFERENCES [dbo].[Users] ([Id])
);

