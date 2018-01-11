using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestGit.Database;

namespace TestGit.Core
{
    [Serializable]
    public class User
    {
        public User() { }
        User(TestGit.Database.UserData user)
        {
            UserId = user.UserId;
            FirstName = user.FirstName;
            LastName = user.LastName;
            EmailAddress = user.EmailAddress;
        }

        public int UserId { get; protected set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }

        public static List<User> LoadAllUsers()
        {
            using (var context = new TestGitDataContext())
            {
                return (from userData in context.UserDatas
                        select new User(userData)).ToList();
            }
        }

        public static User LoadUserByFilters(int userId)
        {
            using (var context = new TestGitDataContext())
            {
                return (from user in context.UserDatas
                        where user.UserId == userId
                        select new User(user)).Single();
            }
        }

        public void SaveData()
        {
            using (var conext = new TestGitDataContext())
            {
                var dbItem = conext.UserDatas.SingleOrDefault(i => i.UserId == UserId);

                if (dbItem != null)
                {
                    dbItem.FirstName = this.FirstName;
                    dbItem.LastName = this.LastName;
                    dbItem.EmailAddress = this.EmailAddress;

                    conext.SubmitChanges();
                }
                else
                {
                    var newDbItem = new TestGit.Database.UserData();
                    newDbItem.FirstName = this.FirstName;
                    newDbItem.LastName = this.LastName;
                    newDbItem.EmailAddress = this.EmailAddress;

                    conext.UserDatas.InsertOnSubmit(newDbItem);
                    conext.SubmitChanges();
                }
            }
        }

        public static void DeleteUser(int userId)
        {
            using (var context = new TestGitDataContext())
            {
                var deleteUser = (from userData in context.UserDatas.Where(i => i.UserId == userId)
                                  select userData).Single();

                context.UserDatas.DeleteOnSubmit(deleteUser);
                context.SubmitChanges();
            }
        }
    }
}
