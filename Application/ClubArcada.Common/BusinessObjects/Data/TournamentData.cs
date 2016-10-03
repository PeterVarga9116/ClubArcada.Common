using System;
using System.Collections.Generic;
using System.Linq;
using ClubArcada.Common.BusinessObjects.DataClasses;

namespace ClubArcada.Common.BusinessObjects.Data
{
    public class TournamentData
    {
        public static Tournament GetById(Credentials cr, Guid id)
        {
            using (var dc = new CADBDataContext(cr.ConnectionString))
            {
                return dc.Tournaments.SingleOrDefault(u => u.Id == id);
            }
        }

        public static List<Tournament> GetList(Credentials cr)
        {
            using (var dc = new CADBDataContext(cr.ConnectionString))
            {
                return dc.Tournaments.ToList();
            }
        }
    }
}