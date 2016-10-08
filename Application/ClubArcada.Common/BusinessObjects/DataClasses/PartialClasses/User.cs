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
    }
}