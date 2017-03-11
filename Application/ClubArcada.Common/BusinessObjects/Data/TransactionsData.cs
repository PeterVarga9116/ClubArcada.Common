using System;
using System.Collections.Generic;
using System.Linq;
using ClubArcada.Common.BusinessObjects.DataClasses;

namespace ClubArcada.Common.BusinessObjects.Data
{
    public class TransactionsData
    {
        public static Transaction GetById(Credentials cr, Guid id)
        {
            using (var dc = CADBDataContext.New(cr.ConnectionString))
            {
                return dc.Transactions.SingleOrDefault(u => u.Id == id);
            }
        }

        public static List<Transaction> GetList(Credentials cr)
        {
            using (var dc = CADBDataContext.New(cr.ConnectionString))
            {
                return dc.Transactions.ToList();
            }
        }

        public static Transaction Create(Credentials cr, Transaction item)
        {
            if(item.Id.IsEmpty())
                item.Id = Guid.NewGuid();

            if(item.CreatedByUserId.IsEmpty())
                item.CreatedByUserId = cr.UserId;

            if (item.Description == null)
                item.Description = string.Empty;

            //item.CreatedByApp = cr.Application;

            //item.DateDeleted = null;

            using (var dc = CADBDataContext.New(cr.ConnectionString))
            {
                dc.Transactions.InsertOnSubmit(item);
                dc.SubmitChanges();
            }

            return GetById(cr, item.Id);
        }

        private void SendEmail(Transaction item)
        {
            var htmlString = Mailer.MailHelper.GetNewTransactionHtmlString("Test", "Nick", "Test User", 60, -280, "Peter Varga", "Lorem Ipsum bla bla", eApplication.Cashtimer, DateTime.Now, DateTime.Now);
        }
    }
}