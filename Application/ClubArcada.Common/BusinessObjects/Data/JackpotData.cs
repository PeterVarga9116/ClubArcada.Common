﻿using System;
using System.Collections.Generic;
using System.Linq;
using ClubArcada.Common.BusinessObjects.DataClasses;

namespace ClubArcada.Common.BusinessObjects.Data
{
    public partial class JackpotData
    {
        public static Jackpot GetActive(Credentials cr)
        {
            using (var dc = CADBDataContext.New(cr.ConnectionString))
            {
                return dc.Jackpots.SingleOrDefault(j => j.DateStopped.IsNull());
            }
        }

        public static void TriggerJackpot(Credentials cr, Guid floorId, Guid winUserId, decimal amount)
        {
            using (var dc = CADBDataContext.New(cr.ConnectionString))
            {
                var activeJackpot = dc.Jackpots.SingleOrDefault(j => j.DateStopped.IsNull());

                activeJackpot.DateStopped = DateTime.Now;
                activeJackpot.FloorUserId = floorId;
                activeJackpot.WinUserId = winUserId;
                activeJackpot.Amount = amount;

                dc.SubmitChanges();
            }

            var newJackpot = new Jackpot();
            newJackpot.PrepareToSave(cr);

            Create(cr, newJackpot);
        }
    }
}