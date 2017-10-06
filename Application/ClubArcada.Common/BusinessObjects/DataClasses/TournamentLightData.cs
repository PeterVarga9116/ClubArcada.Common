using ClubArcada.Common.BusinessObjects.DataClasses;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubArcada.Common.BusinessObjects.DataClasses
{
    public class TournamentLightData
    {
        public TournamentLightData(Tournament source)
        {
            Id = source.Id;
            DisplayName = source.DisplayName;
            DateString = source.DateDisplayName;
            Gtd = string.Format("GTD €{0}", source.GTD);
            Date = source.Date;
            Bank = string.Format("Bank €{0}", source.GTD > source.Bank ? source.GTD : source.Bank);
            Entries = string.Format("Entries: {0}", source.PlayerCount);
            IsLive = source.IsRunning;
            ColorBorder = source.ColorBorder;
            ColorLight = source.ColorLight;
            ColorDark = source.ColorDark;
        }

        [JsonProperty("ID")]
        public Guid Id { get; set; }

        [JsonProperty("N")]
        public string DisplayName { get; set; }

        [JsonProperty("DS")]
        public string DateString { get; set; }

        [JsonProperty("GTD")]
        public string Gtd { get; set; }

        [JsonProperty("D")]
        public DateTime Date { get; set; }

        [JsonProperty("B")]
        public string Bank { get; set; }

        [JsonProperty("E")]
        public string Entries { get; set; }

        [JsonProperty("IL")]
        public bool IsLive { get; set; }

        [JsonProperty("CL")]
        public string ColorLight { get; set; }

        [JsonProperty("CD")]
        public string ColorDark { get; set; }

        [JsonProperty("CB")]
        public string ColorBorder { get; set; }
    }
}
