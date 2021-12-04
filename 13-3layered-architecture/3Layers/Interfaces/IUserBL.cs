using Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Interfaces
{
    public interface IUserBL
    {
        public void Add(User user);

        public void Edit(User newUser);

        public void Delete(User user);

        public void Clear();

        public List<User> GetAll();
    }
}
