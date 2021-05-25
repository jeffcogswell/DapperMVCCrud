using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using NewPeople.Models;
using Dapper;
using Dapper.Contrib.Extensions;

namespace NewPeople.Models
{
    public class OLDDAL
    {
        static MySqlConnection db = new MySqlConnection("Server=localhost;Database=newpeople;Uid=root;Password=abc123");
        public static List<People> GetAll()
        {
            List<People> peeps = db.Query<People>("select * from people order by lastname").ToList();
            return peeps;
        }

        public static void Insert(People peep)
        {
            db.Insert(peep);
        }

        public static People GetOne(int id)
        {
            return db.Get<People>(id);
        }

    }
}
