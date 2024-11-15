﻿using HW12.Entity;
using HW12.Interface;
using HW12.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW12.Service
{
    public class UserService
    {
        IUserRepository userrep;
       
        public UserService()
        {
            userrep = new UserRepository();
        }
        public Result RegisterU(User user)
        {
            if (!userrep.IsUserExists(user.UserName, user.Password))
            {
                if (user.UserName != "" && user.Password != "")
                {
                    userrep.Register(user);

                    return new Result(true, "User registered successfully.");
                }
                else
                {
                    return new Result(false, "Please complete the form.");
                }

            }
            else
            {

                return new Result(false, "User already exists.");
            }

        }
        public Result LoginU(User user)
        {
           MemoryDb.CurrentUser = userrep.Login(user);
            if (MemoryDb.CurrentUser == null)
            {
                return new Result(false, "User or password is incorrect.");
            }
            return new Result(true, "You have successfully logged in..");
        }
       

    }
}
