CREATE PROCEDURE sp_get_wallet_transactions
	@userId uniqueidentifier, 
	@dateTimeFrom DateTime
AS
BEGIN
	SELECT 
	t.Amount,
	t.CreatedByApp,
	t.DateAddedToDB,
	t.DateCreated,
	t.TransactionType,
	t.Description,
	u.FirstName + ' ' + u.LastName AS 'CreatedBy',
	us.NickName + ' ~ '+ us.FirstName + ' ' + us.LastName AS 'UserName'
	FROM Transactions t
	RIGHT JOIN Users u on u.Id = t.CreatedByUserId
	RIGHT JOIN Users us on us.Id = t.UserId
	WHERE t.CreatedByUserId = @userId
	AND
	t.DateAddedToDB >= @dateTimeFrom
	AND 
	t.DateDeleted IS NULL
	ORDER BY t.DateAddedToDB DESC
END