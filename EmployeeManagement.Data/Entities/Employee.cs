using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.Data.Entities
{
    public class Employee : User
    {
        public DateTime? LastLoginDate { get; set; }
        public int DepartmentId { get; set; }
        public virtual Department Department { get; set; }
    }
}
