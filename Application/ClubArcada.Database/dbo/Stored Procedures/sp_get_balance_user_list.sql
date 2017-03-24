
CREATE PROCEDURE [dbo].[sp_get_balance_user_list]
	@searchString nvarchar(100) = NULL
AS
BEGIN
SELECT
	a.UserId,
	a.Balance,
	u.NickName,
	u.FirstName,
	u.LastName,
	u.PhoneNumber,
	u.AutoReturnType,
	u.IsPersonal,
	u.IsTestUser,
	u.IsWallet
FROM(
	SELECT 
	SUM(t.Amount2) AS Balance
	,t.UserId
	FROM Transactions t
	WHERE t.DateUsed IS NULL AND t.DateDeleted IS NULL
	GROUP BY t.UserId)
	a
	JOIN Users u on u.Id = a.UserId
END