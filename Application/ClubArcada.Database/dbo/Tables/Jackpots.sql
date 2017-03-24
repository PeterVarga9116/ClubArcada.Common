CREATE TABLE [dbo].[Jackpots] (
    [Id]              UNIQUEIDENTIFIER NOT NULL,
    [DateStarted]     DATETIME         NOT NULL,
    [DateStopped]     DATETIME         NULL,
    [WinUserId]       UNIQUEIDENTIFIER NULL,
    [FloorUserId]     UNIQUEIDENTIFIER NULL,
    [Amount]          DECIMAL (18, 2)  NULL,
    [DateDeleted]     DATETIME         NULL,
    [DateCreated]     DATETIME         NOT NULL,
    [CreatedByUserId] UNIQUEIDENTIFIER NOT NULL,
    CONSTRAINT [PK_Jackpots] PRIMARY KEY CLUSTERED ([Id] ASC)
);

