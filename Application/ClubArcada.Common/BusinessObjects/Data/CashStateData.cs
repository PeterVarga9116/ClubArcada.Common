using ClubArcada.Common.BusinessObjects.DataClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubArcada.Common.BusinessObjects.Data
{
    public partial class CashStateData
    {
        public static List<CashStateLight> GetListLight(Credentials CR)
        {
            return CashStateData.GetList(CR, true, false).OrderByDescending(cs => cs.DateCreated).Select(c => new CashStateLight(c)).ToList();
        }
    }
}
