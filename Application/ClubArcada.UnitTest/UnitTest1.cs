using ClubArcada.Common;
using ClubArcada.Common.BusinessObjects.Data;
using ClubArcada.Common.BusinessObjects.DataClasses;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;

namespace ClubArcada.UnitTest
{
    [TestClass]
    public class UnitTest1
    {
        private static string NewCS = "Data Source=82.119.117.77;Initial Catalog=ACDB_DEV;User ID=ACDB_user; Password=ULwEsjcpDxjKLbL5";
        private static Guid ServiceID = new Guid("4EBB10F7-1CB5-41C1-8051-3328B7FC5A55");

        private static Credentials CR = new Credentials(ServiceID, 4, NewCS);

        [TestMethod]
        public void TestMethod1()
        {
            //var winUser = Common.BusinessObjects.Data.JackpotData.GetWinUser(CR);
            try
            {
                var x = Common.BusinessObjects.Data.TournamentData.GetRecentLightList(CR, 10);
            }
            catch(Exception exp)
            {
                var x = exp;
            }
        }

        //public void EmailUT()
        //{
        //    try
        //    {
        //        var x = 0;
        //        var s = 15 / x;
        //    }
        //    catch (Exception exp)
        //    {
        //        var o = new Common.Mailer.MailObject()
        //        {
        //            Subject = exp.Message,
        //            Body = exp.GetExceptionDetails(),
        //            To = "petervarga@arcade-group.sk".CreateList(),
        //            From = "service@arcade-group.sk",
        //            Password = "vape6931",
        //            SmtpClient = "smtp.websupport.sk",
        //            Port = 25,
        //            UserName = "service@arcade-group.sk"
        //        };

        //        Common.Mailer.Mailer.SendMail(o);
        //    }
        //}

        //public class ItemClass
        //{
        //    public Guid Id { get; set; }

        //    public string Name { get; set; }

        //    public override string ToString()
        //    {
        //        return string.Format("{0}__{1}", Id, Name);
        //    }
        //}
    }
}
