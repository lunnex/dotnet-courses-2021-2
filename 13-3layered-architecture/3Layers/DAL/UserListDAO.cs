using Entities;
using Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL
{
    public class UserListDAO : IUserDAO
    {
        private readonly List<User> _users = new List<User>()
        {
            new User (0, "Нильс", "Бор", "07.10.1885", new List<string> {"Нобелевская премия по физике"}),
            new User (1, "Бен", "Афффлек", "15.08.1972", new List<string> {"Золотая малина"}),
            new User (2, "Джек", "Николсон", "22.04.1937", new List<string> {"Оскар"}),
        };

        public void Add(User user)
        {
            _users.Add(user);
        }

        public void Edit(User newUser)//TODO сделать один параметр
        {

            foreach (User user in _users)
            {
                if (user.ID == newUser.ID)
                {
                    _users.Remove(user);
                }
            }
            _users.Insert(newUser.ID, newUser);
        }

        public void Delete(User user)
        {
            _users.Remove(user);
        }

        public void Clear()
        {
            _users.Clear();
        }

        public List<User> GetAll()
        {
            return _users;
        }
    }
}
