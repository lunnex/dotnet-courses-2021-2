using Entities;
using System;
using System.Collections.Generic;

namespace Interfaces
{
    public interface IUserDAL
    {
        public void Add(User user);

        public void Edit(User newUser);

        public void Delete(int id);
        public User Get(int id);

        public void Clear();

        public List<User> GetAll();
    }
}
