using ClubArcada.Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace ClubArcada.UnitTest
{
    [TestClass]
    public class UnitTest1
    {

        public void TestMethod1()
        {
            var source = new ItemClass() { Id = Guid.NewGuid(), Name = "SourceName" };

            var target = new ItemClass() { Id = Guid.NewGuid(), Name = "TargetName" };

            string[] igoreList = { "Id", "DateCreated", "CreatedByUserId" };
            var xx = source.IsEqualCompareTo<ItemClass>(target, igoreList);

            var x = target;

        }

        public void EmailUT()
        {
            try
            {
                var x = 0;
                var s = 15 / x;
            }
            catch (Exception exp)
            {
                var o = new Common.Mailer.MailObject()
                {
                    Subject = exp.Message,
                    Body = exp.GetExceptionDetails(),
                    To = "petervarga@arcade-group.sk".CreateList(),
                    From = "service@arcade-group.sk",
                    Password = "vape6931",
                    SmtpClient = "smtp.websupport.sk",
                    Port = 25,
                    UserName = "service@arcade-group.sk"
                };

                Common.Mailer.Mailer.SendMail(o);
            }
        }

        public class ItemClass
        {
            public Guid Id { get; set; }

            public string Name { get; set; }

            public override string ToString()
            {
                return string.Format("{0}__{1}", Id, Name);
            }
        }
    }
}
