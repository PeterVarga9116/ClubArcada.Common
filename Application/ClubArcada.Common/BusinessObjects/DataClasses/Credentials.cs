using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubArcada.Common.BusinessObjects.DataClasses
{
    public class Credentials
    {
        public Credentials(Guid userId, int app, string connectionString)
        {
            UserId = userId;
            Application = app;
            ConnectionString = connectionString;
        }

        public Credentials(string connectionString)
        {
            ConnectionString = connectionString;
        }

        public Guid UserId { get; set; }

        public int Application { get; set; }

        public string ConnectionString { get; set; }
    }
}
