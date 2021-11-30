using Entities;
using Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL
{
    public class UserBL : IUserBL
    {
        private readonly IUserDAO _userDAO;

        public UserBL(IUserDAO userDAO)
        {
            _userDAO = userDAO;
        }

        public void Add(User user)
        {
            _userDAO.Add(user);
        }

        public void Delete(User user)
        {
            _userDAO.Delete(user);
        }

        public void Edit(User oldUser, User newUser)
        {
            _userDAO.Edit(oldUser, newUser);
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
