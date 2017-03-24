
CREATE PROCEDURE [dbo].[sp_get_cash_report]
	@DateFrom DateTime,
	@DateTo DateTime
AS
BEGIN

SELECT DISTINCT
	t.Date
	,cs.Jackpot
	,cs.Rake
	,u.FirstName + ' ' + u.LastName as 'ModifiedBy'
	,us.FirstName + ' ' + us.LastName as 'CreatedBy'
	--,COUNT(cr.Id) as 'PlayerCount'
	,tc.Tips
	,tc.RunnerHelp
	,tc.Comment

FROM Tournaments t
LEFT JOIN CashStates cs on cs.TournamentId = t.Id
LEFT JOIN Users u on u.Id = t.CreatedByUserId
LEFT JOIN Users us on u.Id = cs.ModifiedByUserId
LEFT JOIN CashPlayers cr on cr.TournamentId = t.Id
LEFT JOIN TournamentCashouts tc on tc.TournamentId = t.Id
WHERE 
	CONVERT(date, t.Date) >= CONVERT(date, @DateFrom) 
	AND CONVERT(date, t.Date) <= CONVERT(date, @DateTo)
	AND t.DateDeleted IS NULL
END