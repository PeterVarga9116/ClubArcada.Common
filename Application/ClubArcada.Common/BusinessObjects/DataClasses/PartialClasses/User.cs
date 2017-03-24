namespace ClubArcada.Common.BusinessObjects.DataClasses
{
    public partial class User
    {
        public static User New()
        {
            return new User()
            {
                AdminLevel = 0,
                Email = string.Empty,
                FirstName = string.Empty,
                IsAdmin = false,
                AutoReturnType = (int)eAutoReturn.Full,
                IsBlocked = false,
                IsPersonal = false,
                IsTestUser = false,
                IsWallet = false,
                PhoneNumber = string.Empty,
                NickName = string.Empty,
                LastName = string.Empty,
                Password = string.Empty,
            };
        }

        public string FirendlyDateCreated
        {
            get
            {
                return this.DateCreated.ToString("dd.MM.yyyy HH:mm");
            }
            private set { }
        }

        public string DisplyName
        {
            get
            {
                return string.Format("{0} {1}", FirstName, LastName);
            }
            private set { }
        }

        public string DisplyNameWithNickname
        {
            get
            {
                return string.Format("{0} {1} ~ {2}", FirstName, LastName, NickName);
            }
            private set { }
        }
    }
}