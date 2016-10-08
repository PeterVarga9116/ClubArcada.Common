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

        public static List<Tournament> GetListByLeagueId(Credentials cr, Guid leagueId)
        {
            using (var dc = new CADBDataContext(cr.ConnectionString))
            {
                return dc.Tournaments.Where(t => t.LeagueId == leagueId).ToList();
            }
        }

        public static Tournament Save(Credentials cr, Tournament item)
        {
            var tournament = GetById(cr, item.Id);

            if (tournament.IsNotNull())
            {
                return Update(cr, item);
            }
            else
            {
                return Create(cr, item);
            }
        }

        private static Tournament Create(Credentials cr, Tournament item)
        {
            if (item.DateCreated == null)
            {
                item.DateCreated = DateTime.Now;
            }

            if (item.Id == Guid.Empty)
            {
                item.Id = Guid.NewGuid();
            }

            using (var dc = new CADBDataContext(cr.ConnectionString))
            {
                dc.Tournaments.InsertOnSubmit(item);
                dc.SubmitChanges();
            }

            return GetById(cr, item.Id);
        }

        private static Tournament Update(Credentials cr, Tournament item)
        {
            using (var dc = new CADBDataContext(cr.ConnectionString))
            {
                var toUpdate = dc.Tournaments.SingleOrDefault(t => t.Id == item.Id);

                toUpdate.Name = item.Name;
                toUpdate.AddOnPrize = item.AddOnPrize;
                toUpdate.AddOnStack = item.AddOnStack;
                toUpdate.BonusStack = item.BonusStack;
                toUpdate.BountyDesc = item.BountyDesc;
                toUpdate.BuyInPrize = item.BuyInPrize;
                toUpdate.BuyInStack = item.BuyInStack;
                toUpdate.Date = item.Date;
                toUpdate.Description = item.Description;
                toUpdate.FullStackBonus = item.FullStackBonus;
                toUpdate.GTD = item.GTD;
                toUpdate.IsFood = item.IsFood;
                toUpdate.IsFullPointed = item.IsFullPointed;
                toUpdate.IsHidden = item.IsHidden;
                toUpdate.IsLeague = item.IsLeague;
                toUpdate.IsPercentageBonus = item.IsPercentageBonus;
                toUpdate.ReBuyCount = item.ReBuyCount;
                toUpdate.RebuyPrize = item.RebuyPrize;
                toUpdate.RebuyStack = item.RebuyStack;
                toUpdate.SpecialAddonPrize = item.SpecialAddonPrize;
                toUpdate.SpecialAddonStack = item.SpecialAddonStack;
                toUpdate.StructureId = item.StructureId;

                dc.SubmitChanges();
            }

            return GetById(cr, item.Id);
        }
    }
}