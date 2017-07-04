using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubArcada.Common.BusinessObjects.DataClasses
{
    public partial class Ticket
    {
        public List<TicketItem> Items { get; set; }

        public decimal Amount
        {
            get
            {
                return Items.IsNotNull() && Items.Any() ? Items.Sum(i => i.Amount) : 0;
            }
            set
            {

            }
        }

        public decimal Stack
        {
            get
            {
                return Items.IsNotNull() && Items.Any() ? Items.Sum(i => i.Stack) : 0;
            }
            set
            {

            }
        }

        public string Nick { get; set; }
    }
}
