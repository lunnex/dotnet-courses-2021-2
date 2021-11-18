using Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Interfaces
{
    public interface IPrizeDAO
    {
        public void Add(Prize prize);

        public void Edit(Prize oldPrize, Prize newPrize);

        public void Delete(Prize prize);

        public void Clear();

        public List<Prize> GetAll();
    }
}
