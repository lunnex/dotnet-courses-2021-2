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

            for (int i = 0; i < _users.Count; i++)
            {
                _users[i].ID = i;
            }
        }

        public void Edit(User oldUser, User newUser)
        {
            int indexOfOldPrize = _users.FindIndex(0, _users.Count, x => oldUser.ID == newUser.ID);
            _users.Remove(oldUser);
            _users.Insert(indexOfOldPrize, newUser);
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
