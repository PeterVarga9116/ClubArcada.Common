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
            var result = CashStateData.GetList(CR, true, false);

            return result.HasError ? new List<CashStateLight>() : result.Item.OrderByDescending(cs => cs.DateCreated).Select(c => new CashStateLight(c)).ToList();
        }
    }
}
