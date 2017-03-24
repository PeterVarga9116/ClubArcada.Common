CREATE PROCEDURE [dbo].[sp_get_tournament_report]
	-- Add the parameters for the stored procedure here
	@dateFrom DateTime,
	@dateTo DateTime
AS
BEGIN
		SELECT 
		a.Id,
		t.Name,
		a.PlayerCount,
		a.EntryCount,
		a.PlayerCount * t.BuyInPrize + a.ReBuys * t.ReBuyPrize + a.AddOns * t.AddOnPrize + a.EntryCount * t.BuyInPrize AS Bank,
		t.GameType,
		t.IsRunning,
		t.Date,
		t.Description,
		t.IsFullPointed,
		t.IsLeague,
		t.BuyInPrize,
		t.ReBuyPrize,
		t.AddOnPrize,
		t.BuyInStack,
		t.ReBuyStack,
		t.AddOnStack,
		t.BonusStack,
		t.GTD,
		t.ReBuyCount,
		t.IsFood,
		t.BountyDesc,
		t.SpecialAddonPrize,
		t.SpecialAddonStack,
		t.FullStackBonus,
		t.IsPercentageBonus,
		t.IsHidden,
		a.AddOns,
		a.ReBuys
		,tc.PrizePool AS 'League'
		,tc.Rake
		,tc.Dotation
		
	
	 FROM
	(
	SELECT DISTINCT
		t.Id,	
		COUNT(tr.TournamentId) AS PlayerCount,
		COUNT(tr.TournamentId) + SUM(tr.ReEntryCount)  AS EntryCount,
		SUM(tr.ReBuyCount) AS ReBuys,
		SUM(tr.AddOnCount) AS AddOns
		
	FROM
		Tournaments t
	LEFT JOIN TournamentPlayers tr on tr.TournamentId = t.Id
	
	WHERE t.DateDeleted IS NULL AND GameType != 7 AND GameType != 10 AND
	t.Date >= @dateFrom AND t.Date <= @dateTo


	GROUP BY t.Id
	)
	a
	INNER JOIN Tournaments t ON t.Id = a.Id
	Left JOIN TournamentCashouts tc on tc.TournamentId = t.Id

	ORDER BY t.Date DESC
END