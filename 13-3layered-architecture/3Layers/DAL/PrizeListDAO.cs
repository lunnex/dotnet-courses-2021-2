using Entities;
using System;
using System.Collections.Generic;
using System.Text;
using Interfaces;
using System.Linq;

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
            List<int> listOfId = new List<int>();
            foreach (Prize prizes in _prizes)
            {
                listOfId.Add(prizes.ID);
            }
            prize.ID = listOfId.Max() + 1;
            _prizes.Add(prize);
        }

        public void Edit(Prize newPrize)//TODO сделать один параметр
        {

            foreach(Prize prize in _prizes)
            {
                if (prize.ID == newPrize.ID)
                {
                    _prizes.Remove(prize);
                }
            }
            _prizes.Insert(newPrize.ID, newPrize);
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
