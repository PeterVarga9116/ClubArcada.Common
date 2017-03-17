using System;
using System.Collections.Generic;
using System.Linq;
using ClubArcada.Common.BusinessObjects.DataClasses;

namespace ClubArcada.Common.BusinessObjects.Data
{
    public partial class AuditHistoryData
    {
        public static List<sp_get_audit_historyResult> GetList(Credentials cr, int count)
        {
            using (var dc = CADBDataContext.New(cr.ConnectionString))
            {
                return dc.sp_get_audit_history(count).ToList();
            }
        }
    }
}