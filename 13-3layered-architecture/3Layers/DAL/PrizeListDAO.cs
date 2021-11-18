using Entities;
using System;
using System.Collections.Generic;
using System.Text;
using Interfaces;

namespace DAL
{
    public class PrizeListDAO : IPrizeDAO
    {
        private readonly List<Prize> _prizes = new List<Prize>()
        {
            new Prize (0, "Нобелевская премия по физике", ""),
            new Prize (1, "Оскар", ""),
            new Prize (2, "Золотая малина", "")
        };

        public void Add(Prize prize)
        {
            _prizes.Add(prize);

            for(int i = 0; i < _prizes.Count; i++)
            {
                _prizes[i].ID = i;
            }
        }

        public void Edit(Prize oldPrize, Prize newPrize)
        {
            int indexOfOldPrize = _prizes.FindIndex(0, x => oldPrize.ID == newPrize.ID);
            _prizes.Remove(oldPrize);
            _prizes.Insert(indexOfOldPrize, newPrize);
        }

        public void Delete(Prize prize)
        {
            _prizes.Remove(prize);
        }

        public void Clear()
        {
            _prizes.Clear();
        }

        public List<Prize> GetAll()
        {
            return _prizes;
        }
    }
}
