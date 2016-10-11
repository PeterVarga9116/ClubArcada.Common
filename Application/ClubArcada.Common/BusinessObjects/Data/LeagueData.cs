using System;
using System.Linq;
using ClubArcada.Common.BusinessObjects.DataClasses;

namespace ClubArcada.Common.BusinessObjects.Data
{
    public class LeagueData
    {
        public static League Create(Credentials cr, League item)
        {
            if (item.Id.IsEmpty())
            {
                item.Id = Guid.NewGuid();
            }

            using (var dc = new CADBDataContext(cr.ConnectionString))
            {
                dc.Leagues.InsertOnSubmit(item);
                dc.SubmitChanges();
            }

            return item;
        }

        public static League GetActiveLeague(Credentials cr)
        {
            using (var dc = new CADBDataContext(cr.ConnectionString))
            {
                return dc.Leagues.SingleOrDefault(l => l.IsActive);
            }
        }
    }
}