using System;
using System.Collections.Generic;
using System.Linq;
using ClubArcada.Common.BusinessObjects.DataClasses;

namespace ClubArcada.Common.BusinessObjects.Data
{
    public partial class UserData
    {
        public static List<User> Search(Credentials cr, string searchString)
        {
            var ss = searchString.ToLower().Trim();

            using (var dc = CADBDataContext.New(cr.ConnectionString))
            {
                return dc.Users.Where(u =>
                u.NickName.ToLower().Contains(ss) ||
                u.FirstName.ToLower().Contains(ss) ||
                u.LastName.ToLower().Contains(ss) ||
                (u.FirstName + " " + u.LastName).ToLower().StartsWith(ss)
                ).ToList();
            }
        }

        public static List<User> GetAdminList(Credentials cr)
        {
            using (var dc = CADBDataContext.New(cr.ConnectionString))
            {
                return dc.Users.Where(u => u.AdminLevel != 0 && !u.IsBlocked).ToList();
            }
        }

        public static List<User> GetBarUsers(Credentials cr)
        {
            using (var dc = CADBDataContext.New(cr.ConnectionString))
            {
                return dc.Users.Where(u => u.AdminLevel == (int)eAdminLevel.Service && !u.IsBlocked).ToList();
            }
        }

        public static void UpdateAutoReturn(Credentials cr, Guid userId, eAutoReturn autoReturn)
        {
            using (var dc = CADBDataContext.New(cr.ConnectionString))
            {
                var user = dc.Users.SingleOrDefault(u => u.Id == userId);
                user.AutoReturnType = (int)autoReturn;
                dc.SubmitChanges();
            }
        }

        public static void OptimizeUsers(Credentials cr)
        {
            using (var dc = CADBDataContext.New(cr.ConnectionString))
            {
                var users = dc.Users.ToList();

                foreach (var user in users)
                {
                    user.FirstName = CapitalizeFirstLetter(user.FirstName);
                    user.LastName = CapitalizeFirstLetter(user.LastName);
                    user.Email = user.Email.Trim().ToLower();
                    user.PhoneNumber = user.PhoneNumber.OptimizePhoneNumber();
                }
            }
        }

        public static User Login(string cs, string email, string password)
        {
            using (var dc = new CADBDataContext(cs))
            {
                return dc.Users.SingleOrDefault(u => u.Email == email && u.Password == password);
            }
        }

        public static bool IsNicknameAvailable(Credentials cr, string nickname)
        {
            using (var dc = CADBDataContext.New(cr.ConnectionString))
            {
                return !dc.Users.Where(u => u.NickName.ToLower().Contains(nickname.ToLower())).Any();
            }
        }

        private static bool IsUserValid(User u)
        {
            bool isValid = true;

            if (u.FirstName.IsNullOrEmpty())
                isValid = false;

            if (u.LastName.IsNullOrEmpty())
                isValid = false;

            if (u.NickName.IsNullOrEmpty())
                isValid = false;

            return isValid;
        }

        public static List<sp_get_balance_user_listResult> GetBalance(Credentials cr, string st)
        {
            using (var dc = CADBDataContext.New(cr.ConnectionString))
            {
                return dc.sp_get_balance_user_list(st).ToList();
            }
        }

        public static List<UserLight> GetListLight(Credentials cr, string searchString)
        {
            searchString = searchString.ToLower();

            using (var dc = CADBDataContext.New(cr.ConnectionString))
            {
                var users = dc.Users.Where(u =>
                u.IsTestUser == false && (
                u.FirstName.ToLower().StartsWith(searchString) ||
                u.LastName.ToLower().StartsWith(searchString) ||
                u.NickName.ToLower().StartsWith(searchString)) 
                ).Select(u => new UserLight(u)).ToList();

                return users;
            }
        }

        public static UserDto GetByIdLight(Credentials cr, Guid id)
        {
            using (var dc = CADBDataContext.New(cr.ConnectionString))
            {
                return new UserDto(dc.Users.SingleOrDefault(u => u.Id == id));
            }
        }

        #region Helpers

        private static string CapitalizeFirstLetter(string word)
        {
            if (word.IsNullOrEmpty())
            {
                return string.Empty;
            }
            else
            {
                return word.First().ToString().ToUpper() + word.Substring(1).Replace(" ", string.Empty).ToLower();
            }
        }

        #endregion Helpers
    }
}