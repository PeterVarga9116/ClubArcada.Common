using System;
using System.Linq;
using ClubArcada.Common.BusinessObjects.DataClasses;

namespace ClubArcada.Common.BusinessObjects.Data
{
    public class TransactionsData
    {
        public static Transaction GetById(Credentials cr, Guid id)
        {
            using (var dc = new CADBDataContext(cr.ConnectionString))
            {
                return dc.Transactions.SingleOrDefault(u => u.Id == id);
            }
        }

        public static Transaction Create(Credentials cr, Transaction item)
        {
            if (!Validate(item))
            {
                return null;
            }

            item.Id = Guid.NewGuid();
            item.CreatedByUserId = cr.UserId;
            item.CreatedByApp = cr.Application;
            item.DateAddedToDB = DateTime.Now;
            item.DateDeleted = null;
            item.DatePayed = null;

            using (var dc = new CADBDataContext(cr.ConnectionString))
            {
                dc.Transactions.InsertOnSubmit(item);
                dc.SubmitChanges();
            }

            return GetById(cr, item.Id);
        }

        private static bool Validate(Transaction item)
        {
            bool isValid = true;

            if (item.UserId.IsEmpty())
                isValid = false;

            if (item.Amount == 0)
                isValid = false;

            return isValid;
        }

        private void SendEmail(Transaction item)
        {
            var htmlString = Mailer.MailHelper.GetNewTransactionHtmlString("Test", "Nick", "Test User", 60, -280, "Peter Varga", "Lorem Ipsum bla bla", eApplication.Cashtimer, DateTime.Now, DateTime.Now);
        }
    }
}