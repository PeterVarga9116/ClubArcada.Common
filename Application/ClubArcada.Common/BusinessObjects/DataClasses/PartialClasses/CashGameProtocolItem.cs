using System;

namespace ClubArcada.Common.BusinessObjects.DataClasses
{
    public partial class CashGameProtocolItem
    {
        public CashGameProtocolItem(Guid userId, Guid cashGameId, string text)
        {
            CreatedByUserId = userId;
            CashGameId = cashGameId;
            Text = text;
            DateCreated = DateTime.Now;
            Id = Guid.NewGuid();
        }

        public string DisplayName
        {
            get
            {
                return string.Format("{0} | {1} | {2}", DateCreated.ToString("dd.MM.yyyy HH:mm:ss"), this.CreatedByUser.DisplyName, Text);
            }
        }

        public override string ToString()
        {
            return string.Format("{0} | {1}", DateCreated.ToString("dd.MM.yyyy HH:mm:ss"), Text);
        }
    }
}
