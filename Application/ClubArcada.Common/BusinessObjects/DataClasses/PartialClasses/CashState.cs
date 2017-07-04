using Newtonsoft.Json;
using System;

namespace ClubArcada.Common.BusinessObjects.DataClasses
{
    public class CashStateLight
    {
        public CashStateLight(CashState source)
        {
            Id = source.Id;
            Income = string.Format("€ {0}", source.Input);
            Rake = string.Format("€ {0}", source.Rake);
            Jackpot = string.Format("€ {0}", source.Jackpot);
            DateCreated = source.DateCreatedFriendlyDateTime;
            State = source.State;
            Saldo = string.Format("€ {0}", (source.Input - (source.Rake + source.Jackpot)) * -1);
        }

        [JsonProperty("ID")]
        public Guid Id { get; set; }

        [JsonProperty("D")]
        public string DateCreated { get; set; }

        [JsonProperty("R")]
        public string Rake { get; set; }

        [JsonProperty("J")]
        public string Jackpot { get; set; }

        [JsonProperty("I")]
        public string Income { get; set; }

        [JsonProperty("SA")]
        public string Saldo { get; set; }

        [JsonProperty("S")]
        public int State { get; set; }
    }
}
