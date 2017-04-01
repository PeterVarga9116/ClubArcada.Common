using ClubArcada.Common.BusinessObjects.DataClasses;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ClubArcada.Common.BusinessObjects.Data
{
    public partial class TournamentData
    {
        public static List<Tournament> GetLives(Credentials cr)
        {
            using (var dc = CADBDataContext.New(cr.ConnectionString))
            {
                var tournaments = dc.Tournaments.Where(t => t.IsRunning).ToList();
                tournaments.ForEach(t => t.Players = TournamentPlayerData.GetListByTournamentId(cr, t.Id).Select(tp => new TournamentPlayerLight(tp)).ToList());
                return tournaments;
            }
        }

        public static Tournament GetByIdDetailed(Credentials cr, Guid id)
        {
            using (var dc = CADBDataContext.New(cr.ConnectionString))
            {
                var tournament = dc.Tournaments.SingleOrDefault(t => t.Id == id);

                if (tournament.IsNotNull())
                {
                    tournament.CashOut = dc.TournamentCashouts.SingleOrDefault(tc => tc.TournamentId == id);
                    var players = dc.TournamentPlayers.Where(tp => tp.TournamentId == id).OrderBy(tp => tp.Rank).ToList();

                    if (players.IsNotNull() && players.Any())
                    {
                        foreach (var p in players)
                        {
                            p.User = dc.Users.SingleOrDefault(u => u.Id == p.UserId);
                        }

                        tournament.Players = players.Select(pl => new TournamentPlayerLight(pl)).ToList();
                    }
                }

                return tournament;
            }
        }

        public static List<Tournament> GetListByLeagueId(Credentials cr, Guid leagueId)
        {
            using (var dc = CADBDataContext.New(cr.ConnectionString))
            {
                return dc.Tournaments.Where(t => t.LeagueId == leagueId).ToList();
            }
        }

        public static List<Tournament> GetUpcomingList(Credentials cr, int count = 10)
        {
            using (var dc = CADBDataContext.New(cr.ConnectionString))
            {
                return dc.Tournaments.Where(t => t.Date > DateTime.Now).Take(count).ToList();
            }
        }

        public static List<Tournament> GetRecentList(Credentials cr, int count = 10)
        {
            using (var dc = CADBDataContext.New(cr.ConnectionString))
            {
                return dc.Tournaments.Where(t => t.Date < DateTime.Now && !t.IsRunning).OrderByDescending(t => t.Date).Take(count).ToList();
            }
        }

        public static List<sp_get_tournamentsResult> GetTournaments(Credentials cr, bool? onlyFuture)
        {
            using (var dc = CADBDataContext.New(cr.ConnectionString))
            {
                return dc.sp_get_tournaments(onlyFuture).ToList();
            }
        }

        public static List<sp_get_tournament_reportResult> GetTournamentReport(Credentials cr, DateTime dateFrom, DateTime dateTo)
        {
            using (var dc = CADBDataContext.New(cr.ConnectionString))
            {
                return dc.sp_get_tournament_report(dateFrom, dateTo).ToList();
            }
        }
    }
}