using HW12.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW12.Interface
{
    public interface IUserRepository
    {
        public User Login(User user);
        public void Register(User user);
        public bool IsUserExists(string username, string password);

    }
}
