using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubArcada.Common.BusinessObjects.DataClasses
{
    public partial class BusinessUnit
    {
        public string FirendlyDateCreated
        {
            get
            {
                return this.DateCreated.ToString("dd.MM.yyyy hh:mm");
            }
            private set { }
        }
    }
}
