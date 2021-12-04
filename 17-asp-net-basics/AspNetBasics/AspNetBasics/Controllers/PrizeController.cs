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
    public class PrizeController : Controller
    {

        private readonly PrizeDAL _prizeDAL;
        private readonly PrizeBL _prizeBL;
        public PrizeController()
        {
            var connectionStringBuilder = new SqlConnectionStringBuilder();
            connectionStringBuilder.DataSource = "DESKTOP-34RCMFS\\SQLEXPRESS";
            connectionStringBuilder.InitialCatalog = "usersAndPrizes";
            connectionStringBuilder.IntegratedSecurity = true;

            var connection = connectionStringBuilder.ToString();

            _prizeDAL = new PrizeDAL(connection);
            _prizeBL = new PrizeBL(_prizeDAL);
        }

        public IActionResult Index()
        {
            var prizes = _prizeBL.GetAll();
            return View(prizes);
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(int id, string title, string description)
        {
            Prize prize = new Prize(id, title, description);
            _prizeDAL.Add(prize);

            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            _prizeDAL.Delete(id);
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            var prize = _prizeDAL.Get(id);

            return View(prize);
        }

        [HttpPost]
        public IActionResult Edit(int id, string title, string description)
        {
            Prize prize = new Prize(id, title, description);
            _prizeDAL.Edit(prize);

            return RedirectToAction("Index");
        }
    }
}
