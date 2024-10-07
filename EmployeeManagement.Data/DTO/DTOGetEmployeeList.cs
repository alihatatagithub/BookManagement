using EmployeeManagement.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.Data.DTO
{
    public class DTOGetEmployeeList : DTOPaging
    {
        public string? SearchText { get; set; }
        public int? DepartmentId { get; set; }
        public string? OrderName { get; set; }
    }
}
