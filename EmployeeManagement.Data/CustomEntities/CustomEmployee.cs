using EmployeeManagement.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.Data.CustomEntities
{
    public class CustomEmployee
    {
        public List<Employee> Employees { get; set; }
        public int Count { get; set; }
    }
}
