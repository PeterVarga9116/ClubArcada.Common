CREATE TABLE [dbo].[Transactions] (
    [Id]                    UNIQUEIDENTIFIER NOT NULL,
    [AttachedTransactionId] UNIQUEIDENTIFIER NULL,
    [UserId]                UNIQUEIDENTIFIER NOT NULL,
    [CreatedByUserId]       UNIQUEIDENTIFIER NOT NULL,
    [Amount]                DECIMAL (18, 2)  NOT NULL,
    [Amount2]               DECIMAL (18, 2)  NOT NULL,
    [TransactionType]       INT              NOT NULL,
    [DateAddedToDB]         DATETIME         NOT NULL,
    [DateCreated]           DATETIME         NOT NULL,
    [DateDeleted]           DATETIME         NULL,
    [DateUsed]              DATETIME         NULL,
    [DatePayed]             DATETIME         NULL,
    [Description]           NVARCHAR (500)   NOT NULL,
    [CreatedByApp]          INT              NOT NULL,
    CONSTRAINT [PK_Transactions] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Transactions_Users] FOREIGN KEY ([UserId]) REFERENCES [dbo].[Users] ([Id])
);


GO


CREATE TRIGGER [dbo].[tr_create_audit_history]
ON [dbo].[Transactions]
FOR INSERT
AS
  BEGIN
      INSERT INTO audithistories
		(
		Id,
		DateCreated,
		ObjectId,
		CreatedByUserId,
		type,
		Description
		)
	VALUES      
		(
		NewId(),
		Getdate(),
		(SELECT Id FROM inserted),
		(SELECT CreatedByUserId FROM inserted),
		1,
		'Transaction for ' + CAST((SELECT u.NickName + ' - ' + u.FirstName + ' ' + u.LastName FROM Users u WHERE u.Id = (SELECT UserId FROM inserted)) AS nvarchar)
		)
  END