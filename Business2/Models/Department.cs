using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dapper.Contrib.Extensions;

namespace Business2.Models
{
    [Table("department")]
    public class Department
    {
        [Key]
        public string id { get; set; }
        public string username { get; set; }
        public string name { get; set; }
        public string location { get; set; }
    }
}
