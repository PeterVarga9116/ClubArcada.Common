using System;
using System.Collections.Generic;
using System.Linq;
using ClubArcada.Common.BusinessObjects.DataClasses;

namespace ClubArcada.Common.BusinessObjects.Data
{
    public class AuditHistoryData
    {
        public static AuditHistory Create(Credentials cr, AuditHistory item)
        {
            item.DateCreated = DateTime.Now;
            item.Id = Guid.NewGuid();
            item.UserId = cr.UserId;

            using (var dc = CADBDataContext.New(cr.ConnectionString))
            {
                dc.AuditHistories.InsertOnSubmit(item);
                dc.SubmitChanges();
            }

            return item;
        }

        public static List<sp_get_audit_historyResult> GetList(Credentials cr, int count)
        {
            using (var dc = CADBDataContext.New(cr.ConnectionString))
            {
                return dc.sp_get_audit_history(count).ToList();
            }
        }
    }
}