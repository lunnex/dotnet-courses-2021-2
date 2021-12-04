using DALDB;
using Entities;
using Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL
{
    public class PrizeBL : IPrizeBL
    {
        private readonly PrizeDAL _prizesDAL;

        public PrizeBL(PrizeDAL prizeDAO)
        {
            _prizesDAL = prizeDAO;
        }

        public void Add(Prize prize)
        {
            _prizesDAL.Add(prize);
        }

        public void Edit(Prize newPrize)
        {
            _prizesDAL.Edit(newPrize);
        }

        public void Delete(int id)
        {
            _prizesDAL.Delete(id);
        }
        public Prize Get(int id)
        {
            return _prizesDAL.Get(id);
        }

        public void Clear()
        {
            _prizesDAL.Clear();
        }

        public List<Prize> GetAll()
        {
            return _prizesDAL.GetAll();
        }
    }
}
