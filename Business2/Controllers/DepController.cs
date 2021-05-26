using Business2.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Business2.Controllers
{
    public class DepController : Controller
    {
        public IActionResult Index()
        {
            List<Department> deps = DAL.ReadAllDepartments();
            return View(deps);
        }

        // This will take a string for department ID, although many tables use an integer
        public IActionResult Detail(string id)
        {

            // Here's an example of how we lock this page down to just admin

            /*if (DAL.CurrentUser != "admin")
            {
                return Content("Sorry you do not have permission to access this page.");
            }*/

            Department dep = DAL.ReadOneDepartment(id);
            ViewBag.depart = dep;
            List<Employee> emps = DAL.ReadEmployeesInDepartment(id);
            return View(emps);
        }

        public IActionResult DeleteEmployee(string dept, int emp)
        {
            if (DAL.DeleteEmployee(emp) == false)
            {
                return Content("Sorry, no access.");
            }
            // Make a dynamic object
            //return RedirectToAction("Detail", new { id = dept } );
            return Redirect($"/dep/Detail?id={dept}");  // Jeff prefers this one
        }

        // To capture the param in the URL (e.g. /dep/AddEmployeeForm/ACCT) we
        // MUST call the parameter "id".
        public IActionResult AddEmployeeForm(string id)
        {
            ViewBag.depid = id;
            return View();
        }

        [HttpPost]
        public IActionResult AddEmployee(Employee emp)
        {
            DAL.AddEmployee(emp);
            return Redirect($"/dep/Detail?id={emp.department}");
        }
    }
}
