CREATE TABLE [dbo].[CashIns] (
    [Id]              UNIQUEIDENTIFIER NOT NULL,
    [PlayerId]        UNIQUEIDENTIFIER NOT NULL,
    [CreatedByUserId] UNIQUEIDENTIFIER NOT NULL,
    [Amount]          DECIMAL (18, 2)  NOT NULL,
    [DateCreated]     DATETIME         NOT NULL,
    [DateDeleted]     DATETIME         NULL,
    CONSTRAINT [PK_CashIns] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_CashIns_CashPlayers] FOREIGN KEY ([PlayerId]) REFERENCES [dbo].[CashPlayers] ([Id])
);


GO

CREATE TRIGGER [dbo].[tr_create_audit_history_cashins_oncreate] 
   ON  [dbo].[CashIns] 
   AFTER INSERT
AS 
BEGIN
		 INSERT INTO audithistories
		(
		Id,
		datecreated,
		ObjectId,
		UserId,
		type,
		Description
		)
	VALUES      
		(
		NewId(),
		Getdate(),
		(SELECT Id FROM inserted),
		(SELECT CreatedByUserId FROM inserted),
		4,
		'Cash in €' + (SELECT Amount FROM inserted) + ' for ' + (SELECT u.NickName + ' - ' + u.FirstName + ' ' + u.LastName FROM CashResults cr JOIN Users u on u.Id = cr.UserId WHERE cr.Id = (SELECT PlayerId FROM inserted))
		)

END