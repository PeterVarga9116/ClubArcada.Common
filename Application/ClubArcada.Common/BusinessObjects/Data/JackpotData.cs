using ClubArcada.Common.BusinessObjects.DataClasses;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ClubArcada.Common.BusinessObjects.Data
{
    public partial class JackpotData
    {
        public static Jackpot GetActive(Credentials cr)
        {
            using (var dc = CADBDataContext.New(cr.ConnectionString))
            {
                return dc.Jackpots.SingleOrDefault(j => !j.DateStopped.HasValue);
            }
        }

        public static void TriggerJackpot(Credentials cr)
        {
            using (var dc = CADBDataContext.New(cr.ConnectionString))
            {
                var activeJackpot = dc.Jackpots.SingleOrDefault(j => !j.DateStopped.HasValue);
                var winUser = GetWinUser(cr);

                if(winUser.IsPersonal)
                {
                    TriggerJackpot(cr);
                    return;
                }

                if (activeJackpot.IsNotNull() && winUser.IsNotNull())
                {
                    activeJackpot.DateStopped = DateTime.Now;
                    //activeJackpot.FloorUserId = floorId;
                    activeJackpot.WinUserId = winUser.Id;
                    activeJackpot.Amount = new decimal(activeJackpot.GetAmount());

                    dc.SubmitChanges();
                }
            }

            var newJackpot = new Jackpot();
            newJackpot.DateStarted = DateTime.Now;
            newJackpot.PrepareToSave(cr);
            Create(cr, newJackpot);
        }

        public static User GetWinUser(Credentials cr)
        {
            var playerIdList = new List<Guid>();

            using (var dc = CADBDataContext.New(cr.ConnectionString))
            {
                playerIdList.AddRange(dc.TournamentPlayers.Where(tp => tp.State != 0).Select(tp => tp.UserId));
                playerIdList.AddRange(dc.CashPlayers.Where(tp => tp.State != 0).Select(tp => tp.UserId));

                var userId = playerIdList.GetRandom();

                var x = UserData.GetById(cr, userId);
                return x;
            }
        }

        public static Jackpot CheckIsWin(Credentials cr)
        {
            using (var dc = CADBDataContext.New(cr.ConnectionString))
            {
                var winJackpot = dc.Jackpots.SingleOrDefault(j => j.DateStopped.HasValue && (DateTime.Now - j.DateStopped.Value) < new TimeSpan(0, 0, 30));
                winJackpot.WinUser = UserData.GetById(cr, winJackpot.WinUserId.Value);
                return winJackpot;
            }
        }
    }
}