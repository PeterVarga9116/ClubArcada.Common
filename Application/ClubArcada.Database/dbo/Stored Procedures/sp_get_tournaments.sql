CREATE PROCEDURE [dbo].[sp_get_tournaments]
	@onlyFuture bit
AS
BEGIN
		SELECT 
		a.Id,
		t.Name,
		a.PlayerCount,
		a.PlayerCount * t.BuyInPrize + a.ReBuys * t.ReBuyPrize + a.AddOns * t.AddOnPrize AS Bank,
		t.GameType,
		t.IsRunning,
		t.Date,
		t.Description,
		t.DateEnded,
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
		t.DateDeleted,
		t.DateCreated,
		t.CreatedByUserId,
		a.AddOns,
		a.ReBuys
		,tc.PrizePool
		,a.EntryCount
	
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
	
	WHERE ((t.Date >= getdate() AND (@onlyFuture) = 1) OR ((@onlyFuture) = 0)) AND t.DateDeleted IS NULL
	GROUP BY t.Id
	)
	a
	INNER JOIN Tournaments t ON t.Id = a.Id
	Left JOIN TournamentCashouts tc on tc.TournamentId = t.Id

	ORDER BY t.Date
END