using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
