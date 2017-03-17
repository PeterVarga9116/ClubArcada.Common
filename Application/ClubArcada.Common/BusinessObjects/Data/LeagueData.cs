using System;
using System.Linq;
using ClubArcada.Common.BusinessObjects.DataClasses;

namespace ClubArcada.Common.BusinessObjects.Data
{
    public partial class LeagueData
    {
        public static League GetActiveLeague(Credentials cr)
        {
            using (var dc = CADBDataContext.New(cr.ConnectionString))
            {
                return dc.Leagues.SingleOrDefault(l => l.IsActive);
            }
        }
    }
}