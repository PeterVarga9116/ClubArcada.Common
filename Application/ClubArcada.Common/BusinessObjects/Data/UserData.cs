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

        public static List<User> GetList(Credentials cr)
        {
            using (var dc = new CADBDataContext(cr.ConnectionString))
            {
                return dc.Users.ToList();
            }
        }

        public static User Create(Credentials cr, User user)
        {
            if (IsUserValid(user))
            {
                user.Id = Guid.NewGuid();
                user.CreatedByUserId = cr.UserId;
                user.DateCreated = DateTime.Now;

                using (var dc = new CADBDataContext(cr.ConnectionString))
                {
                    dc.Users.InsertOnSubmit(user);
                    dc.SubmitChanges();
                }

                return GetById(cr, user.Id);
            }
            else
            {
                return null;
            }
        }

        public static User Update(Credentials cr, User user)
        {
            using (var dc = new CADBDataContext(cr.ConnectionString))
            {
                var userToUpdate = dc.Users.SingleOrDefault(u => u.Id == user.Id);

                userToUpdate.AdminLevel = user.AdminLevel;
                userToUpdate.Email = user.Email;
                userToUpdate.FirstName = user.FirstName;
                userToUpdate.IsAdmin = user.IsAdmin;
                userToUpdate.IsAutoReturn = user.IsAutoReturn;
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
    }
}