using Entities;
using System;
using System.Collections.Generic;

namespace Interfaces
{
    public interface IUserDAO
    {
        public void Add(User user);

        public void Edit(User newUser);

        public void Delete(User user);

        public void Clear();

        public List<User> GetAll();
    }
}
