using ClubArcada.Common.BusinessObjects.DataClasses;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ClubArcada.Common.BusinessObjects.Data
{
    public partial class StructureData
    {
        public static List<StructureDetail> GetListByStructureId(Credentials cr, Guid structureId)
        {
            using (var dc = CADBDataContext.New(cr.ConnectionString))
            {
                return dc.StructureDetails.Where(i => i.StructureId == structureId).ToList();

            }
        }
    }
}
