using AspNetBasics.Models;
using BLL;
using DALDB;
using Entities;
using Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetBasics.Controllers
{
    public class UserController : Controller
    {

        private readonly UserDAL _userDAL;
        private readonly UserBL _userBL;

        private readonly PrizeDAL _prizeDAL;
        private readonly PrizeBL _prizeBL;
        public UserController()
        {
            var connectionStringBuilder = new SqlConnectionStringBuilder();
            connectionStringBuilder.DataSource = "DESKTOP-34RCMFS\\SQLEXPRESS";
            connectionStringBuilder.InitialCatalog = "usersAndPrizes";
            connectionStringBuilder.IntegratedSecurity = true;

            var connection = connectionStringBuilder.ToString();

            _userDAL = new UserDAL(connection);
            _userBL = new UserBL(_userDAL);

            _prizeDAL = new PrizeDAL(connection);
            _prizeBL = new PrizeBL(_prizeDAL);
        }

        public IActionResult Index()
        {
            var users = _userBL.GetAll();
            return View(users);
        }

        public IActionResult Add()
        {
            var model = new AddViewModel();
            model.prizes = _prizeBL.GetAll();
            model.prizesIsChecked = new bool[_prizeBL.GetAll().Count];
            return View(model);
        }

        [HttpPost]
        public IActionResult Add(AddViewModel addViewModel)
        {
            List<Prize> checkedPrizeList = new List<Prize>();
            for(int i = 0; i < _prizeBL.GetAll().Count; i++)
            {
                if(addViewModel.prizesIsChecked[i] == true)
                {
                    checkedPrizeList.Add(_prizeBL.GetAll()[i]);
                }
            }
            User user = new User(addViewModel.User.ID, addViewModel.User.FirstName, addViewModel.User.LastName, addViewModel.User.DateOfBirth.ToString(), checkedPrizeList);
            _userDAL.Add(user);

            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            _userDAL.Delete(id);
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            var model = new AddViewModel();
            model.User = _userBL.Get(id);
            model.prizes = _prizeBL.GetAll();
            model.prizesIsChecked = new bool[_prizeBL.GetAll().Count];
            for(int i = 0; i < _userBL.Get(id).ListOfPrize.Count; i++)
            {
                for (int j = i; j < _prizeBL.GetAll().Count; j++)
                {
                    if(_userBL.Get(id).ListOfPrize[i].ID == _prizeBL.GetAll()[j].ID)
                    {
                        model.prizesIsChecked[j] = true;
                    }
                }
            }
            
            return View(model);
        }

        [HttpPost]
        public IActionResult Edit(AddViewModel addViewModel)
        {
            List<Prize> checkedPrizeList = new List<Prize>();
            for (int i = 0; i < addViewModel.prizesIsChecked.Length; i++)
            {
                if (addViewModel.prizesIsChecked[i])
                {
                    checkedPrizeList.Add(_prizeBL.GetAll()[i]);
                }
                    
            }
            User user = new User(addViewModel.User.ID, addViewModel.User.FirstName, addViewModel.User.LastName, addViewModel.User.DateOfBirth.ToString(), checkedPrizeList);
            _userBL.Edit(user);

            return RedirectToAction("Index");
        }

    }
}
