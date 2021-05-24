using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dapper.Contrib.Extensions;
using NewPeople.Models;
using Dapper;

namespace NewPeople.Controllers
{
    public class PeopleController : Controller
    {
        static MySqlConnection db = new MySqlConnection("Server=localhost;Database=newpeople;Uid=root;Password=abc123");
        public IActionResult Index()
        {
            //List<People> peeps = db.GetAll<People>().ToList();
            List<People> peeps = DAL.GetAll();
            return View(peeps);
        }

        // Create needs TWO actions: One gives back a form, and one does the actual inserting into the database table

        public IActionResult CreateForm()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(People peep)
        {
            //db.Insert(peep);
            DAL.Insert(peep);
            return RedirectToAction("Index");
        }

        public IActionResult editform(int id)
        {
            //People peep = db.Get<People>(id);
            People peep = DAL.GetOne(id);
            return View(peep);
        }

        [HttpPost]
        public IActionResult edit(People peep)
        {
            bool s = db.Update(peep);
            return RedirectToAction("index");
        }

        public IActionResult deleteform(int id)
        {
            return View(id);
        }

        public IActionResult delete(int id)
        {
            People peep = db.Get<People>(id);
            db.Delete<People>(peep);
            return RedirectToAction("index");
        }
    }
}
