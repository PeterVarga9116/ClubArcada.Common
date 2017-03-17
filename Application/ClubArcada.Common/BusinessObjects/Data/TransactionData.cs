using System;
using System.Collections.Generic;
using System.Linq;
using ClubArcada.Common.BusinessObjects.DataClasses;

namespace ClubArcada.Common.BusinessObjects.Data
{
    public partial class TransactionData
    {
        private void SendEmail(Transaction item)
        {
            var htmlString = Mailer.MailHelper.GetNewTransactionHtmlString("Test", "Nick", "Test User", 60, -280, "Peter Varga", "Lorem Ipsum bla bla", eApplication.Cashtimer, DateTime.Now, DateTime.Now);
        }
    }
}