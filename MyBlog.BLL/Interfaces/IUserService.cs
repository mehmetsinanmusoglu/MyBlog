﻿using MyBlog.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyBlog.BLL.Interfaces
{
    public interface IUserService
    {
        User GetUSerById(int id);
        User GetUserByUsername(string username);
        void AddUser(User user, string password);
        void UpdateUser(User user);
        void UpdatePassword(int userId, string password);
        void DeleteUser(int id);
        bool VerifyPassword(User user, string password);
    }
}
