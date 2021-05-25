using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NewPeople.Models;


namespace NewPeople.Controllers
{
    public class PeopleController : Controller
    {
        public IActionResult Index()
        {
            List<People> peeps = DAL.GetAllPeopleByLastName();
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
            DAL.Create(peep);
            return RedirectToAction("Index");
        }

        public IActionResult editform(int id)
        {
            People peep = DAL.GetIndividualPerson(id);
            return View(peep);
        }

        [HttpPost]
        public IActionResult edit(People peep)
        {
            DAL.EditPerson(peep);
            return RedirectToAction("index");
        }

        public IActionResult deleteform(int id)
        {
            return View(id);
        }

        public IActionResult delete(int id)
        {
            DAL.DeletePerson(id);
            return RedirectToAction("index");
        }
    }
}
