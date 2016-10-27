using System;
using System.Linq;
using ClubArcada.Common.BusinessObjects.DataClasses;

namespace ClubArcada.Common.BusinessObjects.Data
{
    public class AccountingData
    {
        public static void SetUserLoggedInStateTournament(Credentials cr, Guid userId, bool isLoggedIn)
        {
            using (var app = new CADBDataContext(cr.ConnectionString))
            {
                var entity = app.Accountings.SingleOrDefault(u => u.UserId == userId);

                if (entity.IsNotNull())
                {
                    entity.IsLoggedInTournament = isLoggedIn;
                    app.SubmitChanges();
                }
            }
        }

        public static void SetUserLoggedInStateCash(Credentials cr, Guid userId, bool isLoggedIn)
        {
            using (var app = new CADBDataContext(cr.ConnectionString))
            {
                var entity = app.Accountings.SingleOrDefault(u => u.UserId == userId);

                if (entity.IsNotNull())
                {
                    entity.IsLoggedInCash = isLoggedIn;
                    app.SubmitChanges();
                }
            }
        }
    }
}