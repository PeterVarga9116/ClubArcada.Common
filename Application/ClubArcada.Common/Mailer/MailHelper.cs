using System;

namespace ClubArcada.Common.Mailer
{
    internal class MailHelper
    {
        public static string GetNewTransactionHtmlString(string subject, string nickname, string fullname, decimal amount, decimal balance, string admin, string description, eApplication app, DateTime dateAdded, DateTime date)
        {
            string htmlText = System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceNames() + System.IO.File.ReadAllText(@"\mail_new_transaction.html");

            htmlText.Replace("{{Subject}}", subject);
            htmlText.Replace("{{NickName}}", nickname);
            htmlText.Replace("{{FullName}}", fullname);
            htmlText.Replace("{{Date}}", date.ToString("dd.MM.yyyy HH:mm"));
            htmlText.Replace("{{Amount}}", amount.ToString("0.00"));
            htmlText.Replace("{{Balance}}", balance.ToString("0.00"));

            htmlText.Replace("{{AdminName}}", admin);
            htmlText.Replace("{{DateAddedToDB}}", dateAdded.ToString("dd.MM.yyyy HH:mm"));
            htmlText.Replace("{{Application}}", app.GetDescription());
            htmlText.Replace("{{Description}}", description);

            return htmlText;
        }
    }
}