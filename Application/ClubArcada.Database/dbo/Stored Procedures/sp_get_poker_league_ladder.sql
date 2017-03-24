
CREATE PROCEDURE [dbo].[sp_get_poker_league_ladder]
	@Count INT,
	@LeagueId UNIQUEIDENTIFIER = null,
	@DateFrom DateTime = null,
	@DateTo DateTime = null
AS
BEGIN
	    SELECT TOP (@Count) a.UserId,
                        a.Points,
                        a.PlayCount,
                        u.NickName,
						a.state
    FROM   (SELECT DISTINCT tr.userid,
                            Sum(tr.points)   AS Points,
                            Count(tr.userid) AS PlayCount,
							Sum(tr.State) AS state
            FROM   TournamentPlayers tr
                   JOIN Tournaments t ON t.Id = tr.TournamentId
                   JOIN leagues l ON l.Id = t.leagueid
            WHERE		(@LeagueId IS NULL OR l.Id = @LeagueId)
					AND t.IsLeague = 1
					AND (@DateFrom IS NULL OR @DateFrom < t.Date)
					AND	(@DateTo IS NULL OR @DateTo > t.Date)
            GROUP  BY tr.UserId) a
           INNER JOIN users u
                   ON u.Id = a.userid
				   WHERE u.IsPersonal = 0 AND u.IsTestUser = 0
    ORDER  BY a.points DESC,
              a.playcount DESC,
              u.nickname 
END