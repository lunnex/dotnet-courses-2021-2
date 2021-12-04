using Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Interfaces
{
    public interface IPrizeBL
    {
        public void Add(Prize prize);

        public void Edit(Prize newPrize);

        public void Delete(int id);

        public Prize Get(int id);

        public void Clear();

        public List<Prize> GetAll();
    }
}
