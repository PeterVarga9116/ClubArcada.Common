using System;
using System.Collections.Generic;
using System.Linq;
using ClubArcada.Common.BusinessObjects.DataClasses;

namespace ClubArcada.Common.BusinessObjects.Data
{
    public partial class UserData
    {
        public static User GetById(Credentials cr, Guid id)
        {
            using (var dc = new CADBDataContext(cr.ConnectionString))
            {
                return dc.Users.SingleOrDefault(u => u.Id == id);
            }
        }

        public static User Save(Credentials cr, User item)
        {
            var user = GetById(cr, item.Id);

            if (user.IsNotNull())
            {
                return Update(cr, item);
            }
            else
            {
                return Create(cr, item);
            }
        }

        public static List<User> GetList(Credentials cr)
        {
            using (var dc = new CADBDataContext(cr.ConnectionString))
            {
                return dc.Users.ToList();
            }
        }

        public static List<User> Search(Credentials cr, string searchString)
        {
            var ss = searchString.ToLower().Trim();

            using (var dc = new CADBDataContext(cr.ConnectionString))
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
            using (var dc = new CADBDataContext(cr.ConnectionString))
            {
                return dc.Users.Where(u => u.AdminLevel != 0 && !u.IsBlocked).ToList();
            }
        }

        public static void UpdateAutoReturn(Credentials cr, Guid userId, eAutoReturn autoReturn)
        {
            using (var dc = new CADBDataContext(cr.ConnectionString))
            {
                var user = dc.Users.SingleOrDefault(u => u.Id == userId);
                user.AutoReturnType = (int)autoReturn;
                dc.SubmitChanges();
            }
        }

        public static void OptimizeUsers(Credentials cr)
        {
            using (var dc = new CADBDataContext(cr.ConnectionString))
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
            using (var dc = new CADBDataContext(cr.ConnectionString))
            {
                return !dc.Users.Where(u => u.NickName.ToLower().Contains(nickname.ToLower())).Any();
            }
        }

        private static User Create(Credentials cr, User user)
        {
            if (user.Id == Guid.Empty)
            {
                user.Id = Guid.NewGuid();
            }

            if(user.FirstName == null)
            {
                user.FirstName = string.Empty;
            }

            if(user.LastName == null)
            {
                user.LastName = string.Empty;
            }


            user.CreatedByUserId = cr.UserId;
            user.DateCreated = DateTime.Now;

            using (var dc = new CADBDataContext(cr.ConnectionString))
            {
                dc.Users.InsertOnSubmit(user);
                dc.SubmitChanges();
            }

            return GetById(cr, user.Id);
        }

        private static User Update(Credentials cr, User user)
        {
            using (var dc = new CADBDataContext(cr.ConnectionString))
            {
                var userToUpdate = dc.Users.SingleOrDefault(u => u.Id == user.Id);

                userToUpdate.AdminLevel = user.AdminLevel;
                userToUpdate.Email = user.Email;
                userToUpdate.FirstName = user.FirstName;
                userToUpdate.IsAdmin = user.IsAdmin;
                userToUpdate.AutoReturnType = user.AutoReturnType;
                userToUpdate.IsBlocked = user.IsBlocked;
                userToUpdate.IsTestUser = user.IsTestUser;
                userToUpdate.IsWallet = user.IsWallet;
                userToUpdate.LastName = user.LastName;
                userToUpdate.NickName = user.NickName;
                userToUpdate.Password = user.Password;
                userToUpdate.PhoneNumber = user.PhoneNumber;

                dc.SubmitChanges();
            }

            return GetById(cr, user.Id);
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