using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WhileLearnAsp.NetCoreApp.Models
{
    public class Employee
    {
        public int id { get; set; }
        public string FullName { get; set; }
        public string Gender { get; set; }
        public string Department { get; set; }
        public int Managment_id { get; set; }
    }
}
