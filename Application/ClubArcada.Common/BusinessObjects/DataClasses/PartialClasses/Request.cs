using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubArcada.Common.BusinessObjects.DataClasses
{
    public partial class Request
    {
    }

    public partial class sp_get_requestsResult
    {
        [JsonProperty("DCF")]
        public string DateCreatedFriendly
        {
            get { return this.DateCreated.ToString("dd.MM.yyyy"); }
            set { }
        }

        [JsonProperty("DRF")]
        public string DateResolvedFriendly
        {
            get { return DateCompleted.HasValue ? this.DateCompleted.Value.ToString("dd.MM.yyyy") : ""; }
            set { }
        }

        [JsonProperty("IR")]
        public bool IsResolved
        {
            get { return Status == 0; }
            set { }
        }
    }
}
