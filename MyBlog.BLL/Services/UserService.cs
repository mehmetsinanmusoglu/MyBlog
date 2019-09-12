using MyBlog.BLL.Interfaces;
using MyBlog.Common.Security;
using MyBlog.DAL.Contexts;
using MyBlog.DAL.Repositories;
using MyBlog.DAL.UnitOfWork;
using MyBlog.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyBlog.BLL.Services
{
    public class UserService : IUserService
    {
        IUnitOfWork<MyBlogContext> _unitOfWork;
        IRepository<User> _userRepository;

        public UserService(IUnitOfWork<MyBlogContext> unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _userRepository = _unitOfWork.GetRespository<User>();
        }


        public void AddUser(User user, string password)
        {
            user.PasswordHash = HashHelper.HashPassword(password);
            _userRepository.Add(user);
        }

        public void DeleteUser(int id)
        {
            var user = _userRepository.GetById(id);
            _userRepository.Delete(user);
        }

        public List<User> GetAllUsers()
        {
            return _userRepository.GetAll().OrderBy(x => x.Id).ToList();
        }

        public User GetUSerById(int id)
        {
            return _userRepository.GetById(id);
        }

        public User GetUserByUsername(string username)
        {
            return _userRepository.Get(x => x.UserName == username);
        }

        public void UpdatePassword(int userId, string password)
        {
            User user = _userRepository.GetById(userId);
            user.PasswordHash = HashHelper.HashPassword(password);
            _unitOfWork.SaveChanges();
        }

        public void UpdateUser(User user)
        {
            User record = _userRepository.GetById(user.Id);
            record.Email = user.Email;
            record.UserType = user.UserType;
            record.UserName = user.UserName;
            _userRepository.Update(record);
            _unitOfWork.SaveChanges();
        }

        public bool VerifyPassword(User user, string password)
        {
            return HashHelper.VerifyHashedPassword(user.PasswordHash, password);
        }
    }
}
