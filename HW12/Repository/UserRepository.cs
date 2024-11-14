using HW12.Entity;
using HW12.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW12.Repository
{
    internal class UserRepository : IUserRepository
    {
        private readonly AppDbContext appDbContext;
       
        public UserRepository()
        {
            appDbContext = new AppDbContext();
        }

        public bool IsUserExists(string username, string password)
        {
            return appDbContext.User.Any(x => x.UserName == username && x.Password == password);
        }

        public User Login(User user)
        {
           return appDbContext.User.Where(x => x.UserName == user.UserName && x.Password==user.Password).FirstOrDefault();
        }

       

        public void Register(User user)
        {
            appDbContext.User.Add(user);
            appDbContext.SaveChanges();
        }
    }
}
