using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dapper.Contrib.Extensions;
using Dapper;
using System.Data;

namespace NewPeople.Models
{
    public class DAL
    {
        public static IDbConnection db;
        
        static public void Create(People peep)
        {
            db.Insert(peep);
        }
        
        static public List<People> GetAllPeopleByLastName()
        {
            //List<People> peeps = db.GetAll<People>().ToList();
            List<People> peeps = db.Query<People>("select * from people order by lastname").ToList();
            return peeps;
        }

        static public List<People> GetAllPeopleWithLastName(string lastname)
        {
            List<People> peeps = db.Query<People>($"select * from people where lastname = '{lastname}' order by lastname").ToList();
            return peeps;
        }

        static public People GetIndividualPerson(int id)
        {
            return db.Get<People>(id);
        }

        static public void EditPerson(People peep)
        {
            db.Update(peep);
        }

        static public void DeletePerson(int id)
        {
            People peep = new People();
            peep.id = id;
            db.Delete<People>(peep);  // delete from People where id = 5;
        }
    }
}
