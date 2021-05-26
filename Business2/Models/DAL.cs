using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Dapper.Contrib.Extensions;
using Dapper;

namespace Business2.Models
{
    public class DAL
    {
        static public IDbConnection db;

        static public string CurrentUser;

        // Department methods
        // C
        // R: Read All, Read one by ID
        // U
        // D

        // This one is for demonstration purposes only in case you ever need it.
        // We aren't using it in this project.
        public static Department AddDepartment(string id, string name, string location)
        {
            Department dep = new Department() { id = id, name = name, location = location };
            db.Insert(dep);
            return dep;
        }

        public static void AddDepartment(Department dep)
        {
            dep.username = DAL.CurrentUser;
            db.Insert(dep);
        }

        public static List<Department> ReadAllDepartments()
        {
            // If you get an error that it doesn't know "ToList" you need
            // to add the using System.Linq
            return db.GetAll<Department>().ToList();
        }

        // In THIS EXAMPLE, department's id is a string. Often an id is an int,
        // so be careful.
        public static Department ReadOneDepartment(string id)
        {
            return db.Get<Department>(id);
        }

        public static void EditDepartment(Department dep)
        {
            db.Update(dep);
        }

        public static void DeleteDepartment(string id)
        {
            Department tempobj = new Department();
            tempobj.id = id;
            db.Delete(tempobj);
        }

        public static List<Employee> ReadEmployeesInDepartment(string depid)
        {
            // Add "using Dapper" to the top of this file!!!
            return db.Query<Employee>($"select * from employee where department = '{depid}'").ToList();
        }

        public static bool DeleteEmployee(int id)
        {

            Employee emp = db.Get<Employee>(id);

            if (emp.username == DAL.CurrentUser || DAL.CurrentUser == "admin")
            {
                db.Delete(emp);
                return true;
            }

            return false;

            // Alternate way to create an object and initialize a property in it
            //Employee emp = new Employee() { id = id };
            //db.Delete(emp);

            // I wish Dapper would let me do this:
            //db.Delete<Employee>(id);
        }

        public static void AddEmployee(Employee emp)
        {
            emp.username = DAL.CurrentUser;
            db.Insert(emp);
        }

    }
}
