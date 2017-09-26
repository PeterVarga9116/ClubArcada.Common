using Newtonsoft.Json;
using System;

namespace ClubArcada.Common.BusinessObjects.DataClasses
{
    [Serializable]
    public class UserDto
    {
        public UserDto(User source)
        {
            Id = source.Id;
            LastName = source.LastName;
            FirstName = source.FirstName;
            NickName = source.NickName;
            PhoneNumber = source.PhoneNumber;
            Email = source.Email;
            BirthId = source.BirthId;
            CardId = source.PCardId;
            IsPersonal = source.IsPersonal;
            Password = source.Password;
            IsBlocked = source.IsBlocked;
            IsTest = source.IsTestUser;
            IsWallet = source.IsWallet;
            CreatedByUserName = source.CreatedByUser.IsNotNull() ? source.CreatedByUser.DisplyName : string.Empty;
            DateCreated = source.DateCreatedFriendlyDateTime;
        }

        [JsonProperty("ID")]
        public Guid Id { get; set; }

        [JsonProperty("FN")]
        public string FirstName { get; set; }

        [JsonProperty("LN")]
        public string LastName { get; set; }

        [JsonProperty("NN")]
        public string NickName { get; set; }

        [JsonProperty("PN")]
        public string PhoneNumber { get; set; }

        [JsonProperty("EM")]
        public string Email { get; set; }

        [JsonProperty("BI")]
        public string BirthId { get; set; }

        [JsonProperty("CI")]
        public string CardId { get; set; }

        [JsonProperty("IP")]
        public bool IsPersonal { get; set; }

        [JsonProperty("IVP")]
        public bool IsVip { get; set; }

        [JsonProperty("IB")]
        public bool IsBlocked { get; set; }

        [JsonProperty("IT")]
        public bool IsTest { get; set; }

        [JsonProperty("IW")]
        public bool IsWallet { get; set; }

        [JsonProperty("PW")]
        public string Password { get; set; }

        [JsonProperty("CBUN")]
        public string CreatedByUserName { get; set; }

        [JsonProperty("DT")]
        public string DateCreated { get; set; }
    }
}
