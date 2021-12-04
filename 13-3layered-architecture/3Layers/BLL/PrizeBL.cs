using Entities;
using Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL
{
    public class PrizeBL : IPrizeBL
    {
        private readonly IPrizeDAO _prizesDAO;

        public PrizeBL(IPrizeDAO prizeDAO)
        {
            _prizesDAO = prizeDAO;
        }

        public void Add(Prize prize)
        {
            _prizesDAO.Add(prize);
        }

        public void Edit(Prize newPrize)
        {
            _prizesDAO.Edit(newPrize);
        }

        public void Delete(Prize prize)
        {
            _prizesDAO.Delete(prize);
        }

        public void Clear()
        {
            _prizesDAO.Clear();
        }

        public List<Prize> GetAll()
        {
            return _prizesDAO.GetAll();
        }
    }
}
