using ClubArcada.Common.BusinessObjects.DataClasses;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ClubArcada.Common.BusinessObjects.Data
{
    public partial class TicketData
    {
        public static List<Ticket> GetByTournamentId(Credentials cr, Guid tournamentId)
        {
            using (var dc = CADBDataContext.New(cr.ConnectionString))
            {
                var items = dc.Tickets.Where(t => t.TournamentId == tournamentId).OrderBy(t => t.DateCreated).ToList();

                foreach(var i in items)
                {
                    i.Items = dc.TicketItems.Where(ti => ti.TicketId == i.Id).ToList();
                    i.Nick = dc.Users.SingleOrDefault(u => u.Id == i.UserId).NickName;
                }

                return items;
            }
        }
    }
}
