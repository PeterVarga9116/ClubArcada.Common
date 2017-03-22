using System;
using System.Collections.Generic;
using System.Linq;
using ClubArcada.Common.BusinessObjects.DataClasses;

namespace ClubArcada.Common.BusinessObjects.Data
{
    public partial class TournamentData
    {
        public static List<Tournament> GetLives(Credentials cr)
        {
            using (var dc = CADBDataContext.New(cr.ConnectionString))
            {
                return dc.Tournaments.Where(t => t.IsRunning).ToList();
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
                return dc.Tournaments.Where(t => t.Date < DateTime.Now && !t.IsRunning).Take(count).ToList();
            }
        }

        public static List<sp_get_tournamentsResult> GetTournaments(Credentials cr, bool? onlyFuture)
        {
            using (var dc = CADBDataContext.New(cr.ConnectionString))
            {
                return dc.sp_get_tournaments(onlyFuture).ToList();
            }
        }
    }
}