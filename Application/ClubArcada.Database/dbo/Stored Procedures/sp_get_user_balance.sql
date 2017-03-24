
CREATE PROCEDURE [dbo].[sp_get_user_balance]
	-- Add the parameters for the stored procedure here
	@userId uniqueidentifier
AS
BEGIN

	SELECT 
		SUM(Amount2)
	FROM
		Transactions
	WHERE UserId = @userId AND DateDeleted IS NULL
END