using DALDB;
using Entities;
using Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL
{
    public class UserBL : IUserBL
    {
        private readonly UserDAL _userDAO;

        public UserBL(UserDAL userDAO)
        {
            _userDAO = userDAO;
        }

        public void Add(User user)
        {
            _userDAO.Add(user);
        }

        public void Delete(int id)
        {
            _userDAO.Delete(id);
        }

        public void Edit(User newUser)
        {
            _userDAO.Edit(newUser);
        }

        public User Get(int id)
        {
            return _userDAO.Get(id);
        }

        public void Clear()
        {
            _userDAO.Clear();
        }

        public List<User> GetAll()
        {
            return _userDAO.GetAll();
        }
    }
}
